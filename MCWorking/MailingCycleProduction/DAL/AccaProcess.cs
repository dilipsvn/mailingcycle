using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.Model;
using System.Data.SqlClient;
using System.Data;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.DAL
{
    class AccaProcess : IAccaProcess
    {
        private const string MODULE_NAME = "Acca";

        public List<AccaInfo> GetCreditCardDetailsForScheduledEvents(DateTime eventDate)
        {
            List<AccaInfo> scheduledAccountInfo = new List<AccaInfo>();
            AccaInfo accInfo = new AccaInfo();
            CreditCardInfo creditCard = null;
            bool success = true;
            
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        SqlParameter[] sqlParam = new SqlParameter[] { new SqlParameter("@event_date", SqlDbType.DateTime) };
                        if (eventDate != DateTime.MinValue)
                            sqlParam[0].Value = eventDate;
                        SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SP_UPDATESCHEDULEDEVENTS"), sqlParam);
                        sqlTran.Commit();
                    }
                    catch(Exception ex)
                    {
                        success = false;
                        sqlTran.Rollback();
                        throw ex;
                    }
                }
            }
            if (success)
            {
                try
                {
                    using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                        CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_GETCREDITCARD"), null))
                    {
                        while (reader.Read())
                        {
                            creditCard = new CreditCardInfo(new LookupInfo(reader.GetInt32(0), reader.GetString(1)),
                                reader.GetString(2), reader.GetString(3), reader.GetString(4),
                                reader.GetInt32(5), reader.GetInt32(6), new AddressInfo(
                                    reader.GetString(7), reader.GetString(8), reader.GetString(9),
                                    new CountryInfo(reader.GetInt32(10), reader.GetString(11), false),
                                    new StateInfo(reader.GetInt32(12), reader.GetString(13)),
                                    reader.GetString(14), "", "", ""));
                            accInfo = new AccaInfo();
                            accInfo.AccaCreditCardInfo = creditCard;
                            accInfo.AccaDesignCategory = (DesignCategory)(Convert.ToInt32(reader["category"]));
                            accInfo.ContactCount = Convert.ToInt32(reader["contact_count"]);
                            accInfo.EventId = Convert.ToInt32(reader["event_id"]);
                            accInfo.EventStatus = (ScheduleEventStatus)(Convert.ToInt32(reader["status"]));
                            accInfo.UserId = Convert.ToInt32(reader["bill_user_id"]);
                            accInfo.EventDate = Convert.ToDateTime(reader["event_date"]);
                            accInfo.FarmName = Convert.ToString(reader["farm_name"]);
                            accInfo.PlanName = Convert.ToString(reader["plan_name"]);
                            accInfo.UserName = Convert.ToString(reader["first_name"]) + " " + Convert.ToString(reader["last_name"]);
                            accInfo.PostalTariff = Convert.ToString(reader["postal_tariff"]);
                            if (reader["message_id"] == DBNull.Value && accInfo.AccaDesignCategory == DesignCategory.PowerKard)
                            {
                                accInfo.EventStatus = ScheduleEventStatus.ACCAError;
                                accInfo.Remarks = "Message not assigned";
                            }
                            bool isEventExists = false;
                            foreach (AccaInfo accaInfo in scheduledAccountInfo)
                            {
                                if (accaInfo.EventId == accInfo.EventId)
                                {
                                    isEventExists = true;
                                    break;
                                }
                            }
                            if (!isEventExists)
                                scheduledAccountInfo.Add(accInfo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return scheduledAccountInfo;
        }

        public List<AccaInfo> UpdateEventInfo(List<AccaInfo> eventsInfo)
        {
            bool success = false;
            AuditEntryInfo auditEntry;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        List<AccaInfo> completedEvents = new List<AccaInfo>();
                        foreach (AccaInfo eventInfo in eventsInfo)
                        {
                            Order order = new Order();
                            if (eventInfo.EventStatus == ScheduleEventStatus.InProgress)
                            {
                                bool isEventPresent = false;
                                foreach (AccaInfo completedEvent in completedEvents)
                                {
                                    if (completedEvent.EventId == eventInfo.EventId)
                                    {
                                        eventInfo.AccaOrderInfo.OrderId = completedEvent.AccaOrderInfo.OrderId;
                                        isEventPresent = true;
                                        break;
                                    }
                                }
                                if (!isEventPresent)
                                {
                                    eventInfo.AccaOrderInfo.OrderId = order.Insert(eventInfo.UserId, eventInfo.AccaOrderInfo,eventInfo.UserId);                                    
                                    UpdateInventory(eventInfo.AccaDesignCategory.ToString(),eventInfo.ContactCount,eventInfo.UserId, sqlTran);
                                    auditEntry = new AuditEntryInfo(Module.AccaProcess, eventInfo.EventId.ToString(), "Updated Inventory",
                                                            eventInfo.UserId, eventInfo.UserId);
                                    AuditTrail.WriteEntry(auditEntry, sqlTran);
                                }
                                completedEvents.Add(eventInfo);
                            }
                            UpdateEventInfoInDB(eventInfo, conn, sqlTran);
                            auditEntry = new AuditEntryInfo(Module.AccaProcess, eventInfo.EventId.ToString(), "Updated event status",
                                                            eventInfo.UserId, eventInfo.UserId);
                            AuditTrail.WriteEntry(auditEntry, sqlTran);
                            
                        }
                        sqlTran.Commit();
                        success = true;
                    }
                    catch
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
            return eventsInfo;
        }

        public void UpdateInventory(string designCategory,int quantity, int userId,SqlTransaction sqlTran)
        {            
            UpdateInventoryInDB(designCategory,quantity,userId, sqlTran);
            if (designCategory == DesignCategory.Brochure.ToString())
                UpdateInventoryInDB(ProductCategory.Envelope.ToString(), quantity, userId, sqlTran);
        }

        private static void UpdateInventoryInDB(string designCategory,int quantity,int userId, SqlTransaction sqlTran)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_DEDUCTINVENTORY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {new SqlParameter("@category_id",SqlDbType.Int),
                    new SqlParameter("@quantity",SqlDbType.Int),
                    new SqlParameter("@user_id",SqlDbType.Int)};
            }
            SQLHelper.CacheParameters("SQL_DEDUCTINVENTORY", parameters);

            string[] enumNames = Enum.GetNames(typeof(ProductCategory));
            int index = 0;
            while (index < enumNames.Length)
            {
                if (enumNames[index] == designCategory)
                    break;
                index++;
            }
            Array enumValues = Enum.GetValues(typeof(ProductCategory));


            parameters[0].Value = Convert.ToInt32(enumValues.GetValue(index));
            parameters[1].Value = quantity;//accaInfo.ContactCount;
            parameters[2].Value = userId;// accaInfo.UserId;

            SQLHelper.ExecuteNonQuery(sqlTran, CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_DEDUCTINVENTORY"), parameters);
        }

        private void UpdateEventInfoInDB(AccaInfo accaInfo,SqlConnection sqlCon,SqlTransaction sqlTran)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_UPDATE_STATUS_EVENT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {new SqlParameter("@status",SqlDbType.Int),
                    new SqlParameter("@remarks",SqlDbType.NVarChar,500),
                    new SqlParameter("@event_id",SqlDbType.Int),
                    new SqlParameter("@order_id",SqlDbType.Int),
                    new SqlParameter("@order_value",SqlDbType.Decimal)};
            }
            SQLHelper.CacheParameters("SP_UPDATE_STATUS_EVENT", parameters);
            parameters[0].Value = Convert.ToInt32(accaInfo.EventStatus);
            parameters[1].Value = accaInfo.Remarks;
            parameters[2].Value = accaInfo.EventId;
            if (accaInfo.EventStatus == ScheduleEventStatus.InProgress)
            {
                parameters[3].Value = accaInfo.AccaOrderInfo.OrderId;
                parameters[4].Value = accaInfo.AccaOrderInfo.Amount;
            }
            else
            {
                parameters[3].Value = DBNull.Value;
                parameters[4].Value = DBNull.Value;
            }
            SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure, 
                SQLHelper.GetSQLStatement(MODULE_NAME, "SP_UPDATESTATUSSCHEDULEDEVENTS"), parameters);
        }

    }
}

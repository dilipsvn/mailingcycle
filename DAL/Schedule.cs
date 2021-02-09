using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.DAL
{
    public enum RecursionType
    {
        Weekly = 1,
        Biweekly,
        Monthly
    };

    /// <summary>
    /// A Data Access Component used to manage Schedule Utilities.
    /// </summary>
    public class Schedule : ISchedule
    {
        private const string MODULE_NAME = "Schedule";

        public Schedule()
		{
			//
		}

        private static DateTime GetNextDate(DateTime eventDate, DayOfWeek dayOfWeek)
        {
            while (eventDate.DayOfWeek != dayOfWeek)
            {
                eventDate = eventDate.AddDays(1);
            }

            return eventDate;
        }

        private static DateTime GetNextDate(DateTime eventDate, int weekNo, 
            DayOfWeek dayOfWeek)
        {
            DateTime resultDate = new DateTime(eventDate.Year, eventDate.Month, 1);

            while (resultDate.DayOfWeek != dayOfWeek)
            {
                resultDate = resultDate.AddDays(1);
            }

            resultDate = resultDate.AddDays(7 * (weekNo - 1));

            if (resultDate < eventDate)
            {
                DateTime newDate;

                if (eventDate.Month == 12)
                {
                    newDate = new DateTime(eventDate.Year + 1, 1, 1);
                }
                else
                {
                    newDate = new DateTime(eventDate.Year, eventDate.Month + 1, 1);
                }

                resultDate = GetNextDate(newDate, weekNo, dayOfWeek);
            }

            return resultDate;
        }

        /// <summary>
        /// Get the list of schedule events for the specified mailing plan.
        /// </summary>
        /// <param name="planId">Internal identifier of the mailing plan.</param>
        /// <param name="startDate">Date on which the mailing plan starts.</param>
        /// <returns>List of schedule events for the specified mailing plan.</returns>
        public List<ScheduleEventInfo> GetPlanEvents(int planId, DateTime startDate)
        {
            List<ScheduleEventInfo> events = new List<ScheduleEventInfo>();

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_MAILING_PLAN_RECURSION");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@plan_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_MAILING_PLAN_RECURSION", parameters);
            }

            parameters[0].Value = planId;

            // Execute the query to read the plan definition.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_MAILING_PLAN_RECURSION"),
                parameters))
            {
                int eventNumber = 0;
                DateTime eventDate = startDate;

                // Loop through the definitions of the mailing plan.
                while (reader.Read())
                {
                    bool isWeekday = reader.GetBoolean(1);
                    int weekNo = reader.GetInt32(2);
                    int recursionOn = reader.GetInt32(3);
                    DayOfWeek dayOfWeek = (DayOfWeek)recursionOn;
                    RecursionType recursionType = (RecursionType)reader.GetInt32(4);
                    int recursionCount = reader.GetInt32(5);
                    LookupInfo category = 
                        new LookupInfo(reader.GetInt32(6), reader.GetString(7));

                    for (int i = 0; i < recursionCount; i++)
                    {
                        eventNumber += 1;

                        if (isWeekday)
                        {
                            if (weekNo == 0)
                            {
                                if (eventNumber == 1)
                                {
                                    eventDate = GetNextDate(eventDate, dayOfWeek);
                                }
                                else
                                {
                                    if (recursionType == RecursionType.Weekly)
                                    {
                                        eventDate = eventDate.AddDays(7);
                                    }
                                    else if (recursionType == RecursionType.Biweekly)
                                    {
                                        eventDate = eventDate.AddDays(14);
                                    }
                                }
                            }
                            else
                            {
                                if (eventNumber == 1)
                                {
                                    eventDate = GetNextDate(eventDate, weekNo, dayOfWeek);
                                }
                                else
                                {
                                    if (recursionType == RecursionType.Monthly)
                                    {
                                        DateTime newDate;

                                        if (eventDate.Month == 12)
                                        {
                                            newDate = new DateTime(eventDate.Year + 1, 1, 1);
                                        }
                                        else
                                        {
                                            newDate = new DateTime(eventDate.Year, eventDate.Month + 1, 1);
                                        }

                                        eventDate = GetNextDate(newDate, weekNo, dayOfWeek);
                                    }
                                }
                            }
                        }

                        ScheduleEventInfo e = new ScheduleEventInfo();
                        e.EventNumber = eventNumber;
                        e.EventDate = eventDate;
                        e.ProductType = category;

                        events.Add(e);
                    }
                }
            }

            return events;
        }

        /// <summary>
        /// Get the mailing plans of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="planType">Type of the plans that need to be fetched.</param>
        /// <returns>Mailing plans of the specified user.</returns>
        public List<ScheduleInfo> GetMailingPlans(int userId, PlanType planType)
        {
            List<ScheduleInfo> schedules = new List<ScheduleInfo>();

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_MAILING_PLANS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_MAILING_PLANS", parameters);
            }

            parameters[0].Value = userId;

            // Execute the query to read the schedules.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_MAILING_PLANS"),
                parameters))
            {
                while (reader.Read())
                {
                    if ((planType == PlanType.Active && reader.GetInt32(9) == 1) ||
                        (planType == PlanType.Completed && reader.GetInt32(9) == 0))
                    {
                        ScheduleInfo schedule = new ScheduleInfo(reader.GetInt32(0),
                            reader.GetString(1),
                            new MailingPlanInfo(reader.GetInt32(2), reader.GetString(3)),
                            reader.GetDateTime(4), reader.GetDateTime(5),
                            reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8));

                        schedules.Add(schedule);
                    }
                    
                }
            }

            return schedules;
        }

        /// <summary>
        /// Gets the scheduled events of the specified schedule.
        /// </summary>
        /// <param name="scheduleId">Internal identifier of the schedule.</param>
        /// <returns>Scheduled events of the specified schedule.</returns>
        public ScheduleInfo GetEvents(int scheduleId)
        {
            ScheduleInfo schedule = null;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_EVENTS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@schedule_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_EVENTS", parameters);
            }

            parameters[0].Value = scheduleId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_EVENTS"),
                parameters))
            {
                if (reader.Read())
                {
                    schedule = new ScheduleInfo();
                    schedule.FarmId = reader.GetInt32(0);
                    schedule.FarmName = reader.GetString(1);
                    schedule.Plan =
                        new MailingPlanInfo(reader.GetInt32(2), reader.GetString(3));
                    schedule.StartDate = reader.GetDateTime(4);
                    schedule.EndDate = reader.GetDateTime(5);

                    ScheduleEventInfo scheduleEvent = new ScheduleEventInfo();
                    scheduleEvent.EventId = reader.GetInt32(6);
                    scheduleEvent.EventNumber = reader.GetInt16(7);
                    scheduleEvent.EventDate = reader.GetDateTime(8);
                    scheduleEvent.ProductType =
                        new LookupInfo(reader.GetInt32(9), reader.GetString(10));
                    scheduleEvent.PostalTariff = reader.GetString(11);
                    scheduleEvent.NumberOfPlots = reader.GetInt32(12);
                    scheduleEvent.NumberOfContacts = reader.GetInt32(13);
                    scheduleEvent.Status =
                        new LookupInfo(reader.GetInt32(14), reader.GetString(15));
                    if (!reader.IsDBNull(16))
                    {
                        scheduleEvent.CompletedOn = reader.GetDateTime(16);
                    }

                    schedule.Events.Add(scheduleEvent);

                    while (reader.Read())
                    {
                        scheduleEvent = new ScheduleEventInfo();
                        scheduleEvent.EventId = reader.GetInt32(6);
                        scheduleEvent.EventNumber = reader.GetInt16(7);
                        scheduleEvent.EventDate = reader.GetDateTime(8);
                        scheduleEvent.ProductType =
                            new LookupInfo(reader.GetInt32(9), reader.GetString(10));
                        scheduleEvent.PostalTariff = reader.GetString(11);
                        scheduleEvent.NumberOfPlots = reader.GetInt32(12);
                        scheduleEvent.NumberOfContacts = reader.GetInt32(13);
                        scheduleEvent.Status =
                            new LookupInfo(reader.GetInt32(14), reader.GetString(15));
                        if (!reader.IsDBNull(16))
                        {
                            scheduleEvent.CompletedOn = reader.GetDateTime(16);
                        }

                        schedule.Events.Add(scheduleEvent);
                    }
                }
            }

            return schedule;
        }

        /// <summary>
        /// Gets the scheduled entries of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Scheduled entries of the specified event.</returns>
        public ScheduleInfo GetEventEntries(int eventId)
        {
            ScheduleInfo schedule = null;

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_GET_EVENT_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_EVENT_DETAILS", parameters);
            }

            parameters[0].Value = eventId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_EVENT_DETAILS"),
                parameters))
            {
                if (reader.Read())
                {
                    schedule = new ScheduleInfo();
                    schedule.FarmId = reader.GetInt32(0);
                    schedule.FarmName = reader.GetString(1);
                    schedule.Plan.MailingPlanId = reader.GetInt32(2);
                    schedule.Plan.Title = reader.GetString(3);
                    schedule.StartDate = reader.GetDateTime(4);
                    schedule.EndDate = reader.GetDateTime(5);

                    schedule.Events.Add(new ScheduleEventInfo());
                    schedule.Events[0].EventId = reader.GetInt32(6);
                    schedule.Events[0].EventNumber = reader.GetInt16(7);
                    schedule.Events[0].EventDate = reader.GetDateTime(8);
                    schedule.Events[0].ProductType.LookupId = reader.GetInt32(9);
                    schedule.Events[0].ProductType.Name = reader.GetString(10);
                    schedule.Events[0].PostalTariff = reader.GetString(11);
                    schedule.Events[0].Status.LookupId = reader.GetInt32(14);
                    schedule.Events[0].Status.Name = reader.GetString(15);
                    if (!reader.IsDBNull(16))
                    {
                        schedule.Events[0].CompletedOn = reader.GetDateTime(16);
                    }
                    if (!reader.IsDBNull(17))
                    {
                        schedule.Events[0].OrderId = reader.GetInt32(17);
                        schedule.Events[0].OrderValue = reader.GetInt32(18);
                    }
                    schedule.Events[0].Notes = reader.GetString(19);
                    schedule.Events[0].MailingListFile = reader.GetString(20);
                    schedule.Events[0].Remarks = reader.GetString(21);
                    schedule.Events[0].MailingCount = reader.GetInt32(33);
                    schedule.Events[0].DesignFile = reader.GetString(34);
                    if (!reader.IsDBNull(35))
                    {
                        schedule.Events[0].RefundAmount = reader.GetDecimal(35);
                    }
                    if (!reader.IsDBNull(36))
                    {
                        schedule.Events[0].ExceptionReported = reader.GetBoolean(36);
                    }

                    if (!reader.IsDBNull(22))
                    {
                        schedule.Events[0].NumberOfPlots += reader.GetInt32(12);
                        schedule.Events[0].NumberOfContacts += reader.GetInt32(13);

                        schedule.Events[0].Entries.Add(new ScheduleEventEntryInfo());
                        schedule.Events[0].Entries[0].PlotId = reader.GetInt32(22);
                        schedule.Events[0].Entries[0].PlotName = reader.GetString(23);
                        if (reader.GetInt32(24) == 0)
                        {
                            schedule.Events[0].Entries[0].NumberOfContacts =
                                reader.GetInt32(25);
                        }
                        else
                        {
                            schedule.Events[0].Entries[0].NumberOfContacts =
                                reader.GetInt32(24);
                        }
                        if (!reader.IsDBNull(26))
                        {
                            schedule.Events[0].Entries[0].Message.MessageId =
                                reader.GetInt32(26);
                            schedule.Events[0].Entries[0].Message.MessageType =
                                (MessageType)reader.GetInt32(27);
                            schedule.Events[0].Entries[0].Message.MessageText =
                                reader.GetString(29);
                            schedule.Events[0].Entries[0].Message.MessageTextShort =
                                reader.GetString(30);
                            schedule.Events[0].Entries[0].Message.IsImage =
                                reader.GetBoolean(31);
                            if (!reader.IsDBNull(32))
                            {
                                schedule.Events[0].Entries[0].Message.FileName =
                                    reader.GetString(32);
                            }
                        }
                    }

                    while (reader.Read())
                    {
                        schedule.Events[0].NumberOfPlots += reader.GetInt32(12);
                        schedule.Events[0].NumberOfContacts += reader.GetInt32(13);

                        ScheduleEventEntryInfo entry = new ScheduleEventEntryInfo();
                        entry.PlotId = reader.GetInt32(22);
                        entry.PlotName = reader.GetString(23);
                        if (reader.GetInt32(24) == 0)
                        {
                            entry.NumberOfContacts = reader.GetInt32(25);
                        }
                        else
                        {
                            entry.NumberOfContacts = reader.GetInt32(24);
                        }
                        if (!reader.IsDBNull(26))
                        {
                            entry.Message.MessageId = reader.GetInt32(26);
                            entry.Message.MessageType = (MessageType)reader.GetInt32(27);
                            entry.Message.MessageText = reader.GetString(29);
                            entry.Message.MessageTextShort = reader.GetString(30);
                            entry.Message.ShortDesc = reader.GetString(30);
                            entry.Message.IsImage = reader.GetBoolean(31);
                            if (!reader.IsDBNull(32))
                            {
                                entry.Message.FileName = reader.GetString(32);
                            }
                        }
                        schedule.Events[0].Entries.Add(entry);
                    }
                }
            }

            return schedule;
        }

        /// <summary>
        /// Updates the postal tariff of the specified mailing event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="postalTariff">Postal tariff of the mailing event.</param>
        /// <param name="notes">Notes of the mailing event.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void UpdatePostalTariff(int eventId, string postalTariff, string notes,
            int userId)
        {
            // Get the event details.
            ScheduleSummaryInfo eve = GetEventSummary(eventId);

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_UPDATE_POSTAL_TARIFF");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int),
                    new SqlParameter("@postal_tariff", SqlDbType.NVarChar, 50),
                    new SqlParameter("@notes", SqlDbType.NVarChar, 2000)
                };

                SQLHelper.CacheParameters("SQL_UPDATE_POSTAL_TARIFF", parameters);
            }

            parameters[0].Value = eventId;
            parameters[1].Value = postalTariff;
            parameters[2].Value = notes;

            using (SqlConnection connection =
                new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_POSTAL_TARIFF"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.ScheduleManagement, 
                            eve.FarmName + "/" + eve.EventNumber.ToString(),
                            "Modified postal tariff", eve.AgentId, userId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Cancels the specified scheduled event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="notes">Notes of the mailing event.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void CancelEvent(int eventId, string notes, int userId)
        {
            // Get the event details.
            ScheduleSummaryInfo eve = GetEventSummary(eventId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_CANCEL_EVENT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int),
                    new SqlParameter("@notes", SqlDbType.NVarChar, 2000)
                };

                SQLHelper.CacheParameters("SQL_CANCEL_EVENT", parameters);
            }

            parameters[0].Value = eventId;
            parameters[1].Value = notes;

            // Check whether the farm needs to be released.
            bool releaseFarm = CanReleaseFarm(eventId);

            using (SqlConnection connection =
                new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_CANCEL_EVENT"),
                            parameters);

                        // Release the farm.
                        if (releaseFarm)
                        {
                            ReleaseFarm(eventId, transaction);
                        }

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.ScheduleManagement,
                            eve.FarmName + "/" + eve.EventNumber.ToString(),
                            "Canceled event", eve.AgentId, userId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Completes the specified scheduled event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="mailingListFile">Mailing list file of the mailing event.</param>
        /// <param name="remarks">Remarks of the mailing event.</param>
        /// <param name="mailingCount">Mailing count of the mailing event.</param>
        /// <param name="orderId">Internal identifier of the order.</param>
        /// <param name="refundAmount">Refund amount for the mailing event.</param>
        /// <param name="designCategory">Product type used in the event.</param>
        /// <param name="refundInventory">Invetory that need to be refunded.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void CompleteEvent(int eventId, string mailingListFile, string remarks,
            int mailingCount, int orderId, decimal refundAmount,
            DesignCategory designCategory, int refundInventory,
            int userId)
        {
            // Get the event details.
            ScheduleSummaryInfo eve = GetEventSummary(eventId);

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_COMPLETE_EVENT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int),
                    new SqlParameter("@mailing_list_file", SqlDbType.NVarChar, 255),
                    new SqlParameter("@remarks", SqlDbType.NVarChar, 250),
                    new SqlParameter("@mailing_count", SqlDbType.Int),
                    new SqlParameter("@refund_amount", SqlDbType.Decimal),
                    new SqlParameter("@order_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_COMPLETE_EVENT", parameters);
            }

            parameters[0].Value = eventId;
            parameters[1].Value = mailingListFile;
            parameters[2].Value = remarks;
            parameters[3].Value = mailingCount;
            if (refundAmount == 0)
            {
                parameters[4].Value = DBNull.Value;
            }
            else
            {
                parameters[4].Value = refundAmount;
            }
            parameters[5].Value = orderId;

            // Get the agent id.
            int agentId = GetAgentId(eventId);

            // Check whether the farm needs to be released.
            bool releaseFarm = CanReleaseFarm(eventId);

            using (SqlConnection connection =
                new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_COMPLETE_EVENT"),
                            parameters);

                        // Update Inventory.
                        if (refundInventory > 0)
                        {
                            AddInventory(eventId, designCategory, refundInventory, 
                                agentId, transaction);
                        }

                        // Release the farm.
                        if (releaseFarm)
                        {
                            ReleaseFarm(eventId, transaction);
                        }

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.ScheduleManagement,
                            eve.FarmName + "/" + eve.EventNumber.ToString(),
                            "Completed event", eve.AgentId, userId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the scheduled event entry details of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <returns>Scheduled event entry details of the specified event.</returns>
        public ScheduleInfo GetEventEntry(int eventId, int plotId)
        {
            ScheduleInfo schedule = null;

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_EVENT_ENTRY_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int),
                    new SqlParameter("@plot_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_EVENT_ENTRY_DETAILS", parameters);
            }

            parameters[0].Value = eventId;
            parameters[1].Value = plotId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_EVENT_ENTRY_DETAILS"),
                parameters))
            {
                if (reader.Read())
                {
                    schedule = new ScheduleInfo();
                    schedule.FarmId = reader.GetInt32(3);
                    schedule.FarmName = reader.GetString(4);
                    schedule.Plan.MailingPlanId = reader.GetInt32(5);
                    schedule.Plan.Title = reader.GetString(6);
                    schedule.StartDate = reader.GetDateTime(7);
                    schedule.EndDate = reader.GetDateTime(8);
                    schedule.Events.Add(new ScheduleEventInfo());
                    schedule.Events[0].EventId = reader.GetInt32(0);
                    schedule.Events[0].EventNumber = reader.GetInt16(1);
                    schedule.Events[0].EventDate = reader.GetDateTime(2);
                    schedule.Events[0].PostalTariff = reader.GetString(9);
                    schedule.Events[0].ProductType.LookupId = reader.GetInt32(10);
                    schedule.Events[0].ProductType.Name = reader.GetString(11);
                    schedule.Events[0].Entries.Add(new ScheduleEventEntryInfo());
                    schedule.Events[0].Entries[0].PlotId = reader.GetInt32(12);
                    schedule.Events[0].Entries[0].PlotName = reader.GetString(13);
                    if (!reader.IsDBNull(14))
                    {
                        schedule.Events[0].Entries[0].Message.MessageId =
                            reader.GetInt32(14);
                        schedule.Events[0].Entries[0].Message.ShortDesc =
                            reader.GetString(15);
                        schedule.Events[0].Entries[0].Message.MessageTextShort =
                            reader.GetString(15);
                        schedule.Events[0].Entries[0].Message.MessageText =
                            reader.GetString(16);
                        schedule.Events[0].Entries[0].Message.MessageType =
                            (MessageType)reader.GetInt32(17);
                    }
                }
            }

            return schedule;
        }

        /// <summary>
        /// Get the active custom messages of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Active custom messages of the specified user.</returns>
        public List<MessageInfo> GetActiveCustomMessages(int userId)
        {
            List<MessageInfo> messages = new List<MessageInfo>();

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_GET_ACTIVE_CUSTOM_MESSAGES");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_ACTIVE_CUSTOM_MESSAGES", parameters);
            }

            parameters[0].Value = userId;

            // Execute the query to read the schedules.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_ACTIVE_CUSTOM_MESSAGES"),
                parameters))
            {
                while (reader.Read())
                {
                    MessageInfo message = new MessageInfo();
                    message.MessageId = reader.GetInt32(0);
                    message.MessageType = (MessageType)reader.GetInt32(1);
                    message.MessageText = reader.GetString(2);
                    message.MessageTextShort = reader.GetString(3);
                    message.IsImage = reader.GetBoolean(4);
                    if (!reader.IsDBNull(5))
                    {
                        message.FileName = reader.GetString(5);
                    }

                    messages.Add(message);
                }
            }

            return messages;
        }

        /// <summary>
        /// Gets the details of the specified message.
        /// </summary>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <returns>Details of the specified message.</returns>
        public MessageInfo GetMessage(int messageId)
        {
            MessageInfo message = null;

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_GET_MESSAGE_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@message_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_MESSAGE_DETAILS", parameters);
            }

            parameters[0].Value = messageId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_MESSAGE_DETAILS"),
                parameters))
            {
                if (reader.Read())
                {
                    message = new MessageInfo();
                    message.MessageId = reader.GetInt32(0);
                    message.MessageType = (MessageType)reader.GetInt32(1);
                    message.MessageText = reader.GetString(2);
                    message.MessageTextShort = reader.GetString(3);
                    message.IsImage = reader.GetBoolean(4);
                    if (!reader.IsDBNull(5))
                    {
                        message.FileName = reader.GetString(5);
                    }
                }
            }

            return message;
        }

        /// <summary>
        /// Inserts the event entry of the specified mailing event.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void InsertEventEntry(int farmId, int plotId, int eventId, int messageId,
            int userId)
        {
            // Get the event entry details.
            ScheduleSummaryInfo eventEntry = GetEventEntrySummary(eventId, plotId);

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_INSERT_EVENT_ENTRY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@farm_id", SqlDbType.Int),
                    new SqlParameter("@plot_id", SqlDbType.Int),
                    new SqlParameter("@event_id", SqlDbType.Int),
                    new SqlParameter("@message_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_INSERT_EVENT_ENTRY", parameters);
            }

            parameters[0].Value = farmId;
            parameters[1].Value = plotId;
            parameters[2].Value = eventId;
            parameters[3].Value = messageId;

            using (SqlConnection connection =
                new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_EVENT_ENTRY"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.ScheduleManagement,
                            eventEntry.FarmName + "/" + eventEntry.EventNumber.ToString() + "/" + eventEntry.PlotName,
                            "Assigned message", eventEntry.AgentId, userId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Updates the event entry of the specified mailing event.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void UpdateEventEntry(int farmId, int plotId, int eventId, int messageId,
            int userId)
        {
            // Get the event entry details.
            ScheduleSummaryInfo eventEntry = GetEventEntrySummary(eventId, plotId);

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_UPDATE_EVENT_ENTRY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@farm_id", SqlDbType.Int),
                    new SqlParameter("@plot_id", SqlDbType.Int),
                    new SqlParameter("@event_id", SqlDbType.Int),
                    new SqlParameter("@message_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_UPDATE_EVENT_ENTRY", parameters);
            }

            parameters[0].Value = farmId;
            parameters[1].Value = plotId;
            parameters[2].Value = eventId;
            parameters[3].Value = messageId;

            using (SqlConnection connection =
                new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_EVENT_ENTRY"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.ScheduleManagement,
                            eventEntry.FarmName + "/" + eventEntry.EventNumber.ToString() + "/" + eventEntry.PlotName,
                            "Modified message", eventEntry.AgentId, userId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the design details of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Design details of the specified event.</returns>
        public DesignInfo GetDesign(int eventId)
        {
            DesignInfo design = null;

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_EVENT_DESIGN");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_EVENT_DESIGN", parameters);
            }

            parameters[0].Value = eventId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_EVENT_DESIGN"),
                parameters))
            {
                if (reader.Read())
                {
                    design = new DesignInfo();
                    design.DesignId = reader.GetInt32(0);
                    design.Size = new SizeF((float)reader.GetDecimal(1),
                        (float)reader.GetDecimal(2));
                    design.Gender = reader.GetString(3);
                    design.OnDesignName = reader.GetString(4);
                    design.Justification = (JustificationType)reader.GetInt32(5);
                    design.Gutter = reader.GetString(6);
                    design.MessageRectangle = new RectangleF((float)reader.GetDecimal(7),
                        (float)reader.GetDecimal(8),
                        (float)reader.GetDecimal(9),
                        (float)reader.GetDecimal(10));
                    design.LowResolutionFile = reader.GetString(11);
                }
            }

            return design;
        }

        /// <summary>
        /// Gets the summary of schedules.
        /// </summary>
        /// <returns>Summary of schedules.</returns>
        public DataTable GetSummary()
        {
            DataTable summary = new DataTable("schedule_summary");

            // Execute the query to read the schedule summary.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_SCHEDULE_SUMMARY"),
                null))
            {
                if (reader != null)
                {
                    summary.Load(reader);
                }
            }

            return summary;
        }

        /// <summary>
        /// Gets the summary of schedules of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Summary of schedules of the specified user.</returns>
        public DataTable GetSummary(int userId)
        {
            DataTable summary = new DataTable("schedule_summary");

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_SCHEDULE_SUMMARY_OF_USER");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_SCHEDULE_SUMMARY_OF_USER", parameters);
            }

            parameters[0].Value = userId;

            // Execute the query to read the schedule summary.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_SCHEDULE_SUMMARY_OF_USER"),
                parameters))
            {
                if (reader != null)
                {
                    summary.Load(reader);
                }
            }

            return summary;
        }

        /// <summary>
        /// Gets a value indicating whether the specified farm is active.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <returns>true if the specified farm is currently active; 
        /// otherwise, false.</returns>
        public bool IsActive(int farmId)
        {
            bool isActive = false;

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_IS_ACTIVE_FARM");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@farm_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_IS_ACTIVE_FARM", parameters);
            }

            parameters[0].Value = farmId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_IS_ACTIVE_FARM"),
                parameters))
            {
                if (reader.Read())
                {
                    isActive = (reader.GetInt32(0) >= 1) ? true : false;
                }
            }

            return isActive;
        }

        /// <summary>
        /// Firms up the specified farm.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="planId">Internal identifier of the mailing plan.</param>
        /// <param name="startDate">Date on which the mailing plan starts.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void FirmUp(int farmId, int planId, DateTime startDate, int userId)
        {
            // Get the list of proposed scheduled events.
            List<ScheduleEventInfo> events = GetPlanEvents(planId, startDate);

            // Get the agent's list of designs.
            Design design = new Design();
            DesignInfo powerkard = new DesignInfo();
            DesignInfo brochure = new DesignInfo();

            List<DesignInfo> designs = design.GetList(userId);

            foreach (DesignInfo designInfo in designs)
            {
                if (designInfo.Category.Name == "PowerKard")
                {
                    powerkard = designInfo;
                }
                else
                {
                    brochure = designInfo;
                }
            }

            // Get the list of active standard messages.
            Message message = new Message();
            List<MessageInfo> messages = message.GetStandardMessageList(true);

            // Get the list of active plots for the farm/plan.
            Farm farm = new Farm();
            FarmInfo farmInfo = farm.GetFarmDetail(farmId);
            List<PlotInfo> plots = farm.GetPlotListSummaryForFarm(farmId);

            // Build the required Xml strings.
            StringBuilder eventsXml = new StringBuilder();
            StringBuilder eventDetailsXml = new StringBuilder();

            eventsXml.Append("<ROOT>");
            eventDetailsXml.Append("<ROOT>");

            int messageIndex = -1;
            DateTime endDate = DateTime.Today;

            foreach (ScheduleEventInfo e in events)
            {
                // Get the design id for the event category.
                int designId = 0;

                if (e.ProductType.Name == "PowerKard")
                {
                    designId = powerkard.DesignId;
                }
                else
                {
                    designId = brochure.DesignId;
                }

                // Get the message id for the event.
                int messageId = 0;

                if (e.ProductType.Name == "PowerKard")
                {
                    messageIndex++;

                    if (messageIndex == messages.Count)
                    {
                        messageIndex = 0;
                    }

                    messageId = messages[messageIndex].MessageId;
                }

                // Set the postal tariff for the event.
                string postalTariff = string.Empty;

                if (e.EventNumber == 1)
                {
                    postalTariff = "Postage Stamps";
                }
                else
                {
                    postalTariff = "Bulk Mail";
                }

                // Prepare the Xml node for the event.
                eventsXml.Append("<Events");
                eventsXml.AppendFormat(" event_number=\"" + e.EventNumber + "\"");
                eventsXml.AppendFormat(" event_date=\"" + e.EventDate + "\"");
                eventsXml.AppendFormat(" design_id=\"" + designId + "\"");
                eventsXml.AppendFormat(" postal_tariff=\"" + postalTariff + "\"");
                eventsXml.AppendFormat(">");
                eventsXml.Append("</Events>");

                // Prepare the Xml node for the event details.
                foreach (PlotInfo plot in plots)
                {
                    eventDetailsXml.Append("<EventDetails");
                    eventDetailsXml.AppendFormat(" plot_id=\"" + plot.PlotId + "\"");
                    eventDetailsXml.AppendFormat(" message_id=\"" + messageId + "\"");
                    eventDetailsXml.AppendFormat(" event_number=\"" + e.EventNumber + "\"");
                    eventDetailsXml.AppendFormat(">");
                    eventDetailsXml.Append("</EventDetails>");
                }

                // Set the end date to the current event's date.
                endDate = e.EventDate;
            }

            eventsXml.Append("</ROOT>");
            eventDetailsXml.Append("</ROOT>");

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SP_FIRM_UP_EVENT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@farm_id", SqlDbType.Int),
                    new SqlParameter("@plan_id", SqlDbType.Int),
                    new SqlParameter("@start_date", SqlDbType.DateTime),
                    new SqlParameter("@end_date", SqlDbType.DateTime),
                    new SqlParameter("@user_id", SqlDbType.Int),
                    new SqlParameter("@events_xml", SqlDbType.Xml),
                    new SqlParameter("@event_details_xml", SqlDbType.Xml)
                };

                SQLHelper.CacheParameters("SP_FIRM_UP_EVENT", parameters);
            }

            parameters[0].Value = farmId;
            parameters[1].Value = planId;
            parameters[2].Value = startDate;
            parameters[3].Value = endDate;
            parameters[4].Value = userId;
            parameters[5].Value = eventsXml.ToString();
            parameters[6].Value = eventDetailsXml.ToString();

            using (SqlConnection connection =
                new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction,
                            CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SP_FIRM_UP_EVENT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmInfo.FarmName, 
                            "Firmed up farm", userId, userId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the summary of schedules report of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="reportType">Type of the events that needs to be displayed.</param>
        /// <param name="mailingPlan">Type of the plans that needs to be included.</param>
        /// <param name="startDate">Start Date of the specified date range.</param>
        /// <param name="endDate">End Date of the specified date range.</param>
        /// <returns>Summary of schedules report of the specified user.</returns>
        public List<ScheduleSummaryInfo> GetSchedulesReportSummary(int userId, string reportType,
            string mailingPlan, string startDate, string endDate)
        {
            List<ScheduleSummaryInfo> schedules = new List<ScheduleSummaryInfo>();

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_SCHEDULE_MANAGEMENT_REPORT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int),
                    new SqlParameter("@report_type", SqlDbType.NVarChar, 10),
                    new SqlParameter("@mailing_plan", SqlDbType.NVarChar, 10),
                    new SqlParameter("@start_date", SqlDbType.NVarChar, 10),
                    new SqlParameter("@end_date", SqlDbType.NVarChar, 10)
                };

                SQLHelper.CacheParameters("SQL_SCHEDULE_MANAGEMENT_REPORT", parameters);
            }

            parameters[0].Value = userId;
            parameters[1].Value = reportType;
            parameters[2].Value = mailingPlan;
            parameters[3].Value = startDate;
            parameters[4].Value = endDate;

            // Execute the query to read the schedules.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_SCHEDULE_MANAGEMENT_REPORT"),
                parameters))
            {
                while (reader.Read())
                {
                    ScheduleSummaryInfo schedule = new ScheduleSummaryInfo();

                    schedule.AgentId = userId;
                    schedule.AgentName = reader.GetString(0) + " " +
                        reader.GetString(1);

                    if (reportType == "F")
                    {
                        schedule.EventType = "Future Events";
                    }
                    else if (reportType == "P")
                    {
                        schedule.EventType = "Past Events";
                    }
                    else
                    {
                        schedule.EventType = "All Events";
                    }

                    if (mailingPlan == "A")
                    {
                        schedule.PlanType = "Active Plans";
                    }
                    else if (mailingPlan == "C")
                    {
                        schedule.PlanType = "Closed Plans";
                    }
                    else
                    {
                        schedule.PlanType = "All Plans";
                    }

                    if (startDate != "" && endDate != "")
                    {
                        schedule.DateRangeStart = startDate;
                        schedule.DateRangeEnd = endDate;
                    }

                    schedule.FarmName = reader.GetString(2);
                    schedule.PlanName = reader.GetString(3);
                    schedule.EventCount = reader.GetInt32(4);
                    schedule.StartDate = reader.GetDateTime(5).ToString("MM/dd/yyyy");
                    schedule.EndDate = reader.GetDateTime(6).ToString("MM/dd/yyyy");
                    schedule.EventNumber = reader.GetInt16(7);
                    schedule.EventDate = reader.GetDateTime(8).ToString("MM/dd/yyyy");
                    schedule.Category = reader.GetString(9);
                    schedule.Status = reader.GetString(10);

                    schedules.Add(schedule);
                }
            }

            return schedules;
        }

        /// <summary>
        /// Gets the summary of schedule events report for the specified parameters.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="planType">Type of the plans that needs to be included.</param>
        /// <param name="eventType">Type of the events that needs to be displayed.</param>
        /// <param name="startDate">Start Date of the specified date range.</param>
        /// <param name="endDate">End Date of the specified date range.</param>
        /// <param name="urlPath">Location of the design file.</param>
        /// <returns>Summary of schedule events report for the specified parameters.</returns>
        public List<ScheduleSummaryInfo> GetScheduleEventsReportSummary(int userId,
            string planType, string eventType, string startDate, string endDate,
            string urlPath)
        {
            List<ScheduleSummaryInfo> schedules = new List<ScheduleSummaryInfo>();

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_SCHEDULE_EVENTS_REPORT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int),
                    new SqlParameter("@plan_type", SqlDbType.NVarChar, 10),
                    new SqlParameter("@event_type", SqlDbType.NVarChar, 10),
                    new SqlParameter("@start_date", SqlDbType.NVarChar, 10),
                    new SqlParameter("@end_date", SqlDbType.NVarChar, 10)
                };

                SQLHelper.CacheParameters("SQL_SCHEDULE_EVENTS_REPORT", parameters);
            }

            parameters[0].Value = userId;
            parameters[1].Value = planType;
            parameters[2].Value = eventType;
            parameters[3].Value = startDate;
            parameters[4].Value = endDate;

            // Execute the query to read the schedules.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_SCHEDULE_EVENTS_REPORT"),
                parameters))
            {
                while (reader.Read())
                {
                    ScheduleSummaryInfo schedule = new ScheduleSummaryInfo();

                    schedule.AgentId = reader.GetInt32(0);
                    schedule.AgentName = reader.GetString(1) + " " +
                        reader.GetString(2);
                    schedule.Phone = reader.GetString(3);
                    schedule.FarmName = reader.GetString(4);
                    schedule.PlanName = reader.GetString(5);
                    schedule.StartDate = reader.GetDateTime(6).ToString("MM/dd/yyyy");
                    schedule.EndDate = reader.GetDateTime(7).ToString("MM/dd/yyyy");
                    schedule.EventCount = reader.GetInt32(8);
                    schedule.EventNumber = reader.GetInt16(9);
                    schedule.EventDate = reader.GetDateTime(10).ToString("MM/dd/yyyy");
                    schedule.Category = reader.GetString(11);
                    schedule.Size = reader.GetDecimal(12).ToString("####.####") +
                        " x " + reader.GetDecimal(13).ToString("####.####") + " inch.";
                    schedule.HighResolutionFile = urlPath + schedule.AgentId + "/" + 
                        reader.GetString(14);
                    schedule.PostalTariff = reader.GetString(15);
                    schedule.Status = reader.GetString(16);
                    if (!reader.IsDBNull(17))
                    {
                        schedule.PlotName = reader.GetString(17);
                    }
                    if (!reader.IsDBNull(18))
                    {
                        schedule.ContactCount = reader.GetInt32(18);
                    }
                    if (!reader.IsDBNull(19))
                    {
                        schedule.MessageId = reader.GetInt32(19);
                    }
                    if (!reader.IsDBNull(20))
                    {
                        schedule.MessageShortText = reader.GetString(20);
                    }

                    schedules.Add(schedule);
                }
            }

            return schedules;
        }

        /// <summary>
        /// Get the list of contacts of the specified schedule event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>List of contacts of the specified schedule event.</returns>
        public List<ScheduleEventContactInfo> GetScheduleEventContacts(int eventId)
        {
            List<ScheduleEventContactInfo> contacts = 
                new List<ScheduleEventContactInfo>();

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_SCHEDULE_EVENT_CONTACTS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_SCHEDULE_EVENT_CONTACTS", parameters);
            }

            parameters[0].Value = eventId;
            
            // Execute the query to read the schedule event contacts.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_SCHEDULE_EVENT_CONTACTS"),
                parameters))
            {
                while (reader.Read())
                {
                    ScheduleEventContactInfo contact = new ScheduleEventContactInfo();

                    contact.EventNumber = reader.GetInt16(0);
                    contact.EventDate = reader.GetDateTime(1).ToString("MM/dd/yyyy");
                    contact.FarmId = reader.GetInt32(2);
                    contact.FarmName = reader.GetString(3);
                    contact.PlanId = reader.GetInt32(4);
                    contact.PlanName = reader.GetString(5);
                    contact.StartDate = reader.GetDateTime(6).ToString("MM/dd/yyyy");
                    contact.EndDate = reader.GetDateTime(7).ToString("MM/dd/yyyy");
                    contact.PlotId = reader.GetInt32(8);
                    contact.PlotName = reader.GetString(9);
                    contact.ContactId = reader.GetInt64(10);
                    contact.FirstName = reader.GetString(11);
                    contact.LastName = reader.GetString(12);
                    contact.Address1 = reader.GetString(13);
                    contact.Address2 = reader.GetString(14);
                    contact.City = reader.GetString(15);
                    contact.State = reader.GetString(16);
                    contact.Zip = reader.GetString(17);
                    contact.Country = reader.GetString(18);

                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        /// <summary>
        /// Gets the mailing labels for the specified schedule event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Mailing labels for the specified schedule event.</returns>
        public List<ScheduleEventMailingLabelInfo> GetMailingLabels(int eventId)
        {
            List<ScheduleEventMailingLabelInfo> mailingLabels = 
                new List<ScheduleEventMailingLabelInfo>();

            // Get the list of contacts of the specified schedule event.
            List<ScheduleEventContactInfo> contacts = GetScheduleEventContacts(eventId);

            // Loop the list to read the mailing labels.
            int plotId = 0;
            int index = 0;

            foreach (ScheduleEventContactInfo entry in contacts)
            {
                string labelText = string.Empty;

                labelText = entry.FirstName + " " + entry.LastName +
                    "<br />" + entry.Address1 +
                    (entry.Address2 == "" ? "" : "<br />" + entry.Address2) +
                    "<br />" + entry.City + ", " + entry.State +
                    "<br />" + entry.Zip + " - " + entry.Country;

                if (entry.PlotId != plotId)
                {
                    index = 1;
                    plotId = entry.PlotId;
                }

                if (index == 1)
                {
                    ScheduleEventMailingLabelInfo label = 
                        new ScheduleEventMailingLabelInfo();

                    label.EventDate = entry.EventDate;
                    label.FarmName = entry.FarmName;
                    label.PlanName = entry.PlanName;
                    label.PlotName = entry.PlotName;
                    label.MailingLabel_1 = labelText;

                    mailingLabels.Add(label);
                }
                else if (index == 2)
                {
                    mailingLabels[mailingLabels.Count - 1].MailingLabel_2 = labelText;
                }
                else
                {
                    mailingLabels[mailingLabels.Count - 1].MailingLabel_3 = labelText;
                    index = 0;
                }

                index++;
            }

            return mailingLabels;
        }

        private int GetAgentId(int eventId)
        {
            int agentId = 0;

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_AGENT_ID");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_AGENT_ID", parameters);
            }

            parameters[0].Value = eventId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_AGENT_ID"),
                parameters))
            {
                if (reader.Read())
                {
                    agentId = reader.GetInt32(0);
                }
            }

            return agentId;
        }

        private void AddInventory(int eventId, DesignCategory designCategory,
            int refundInventory, int agentId, SqlTransaction transaction)
        {
            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_ADD_INVENTORY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@quantity", SqlDbType.Int),
                    new SqlParameter("@owner_id", SqlDbType.Int),
                    new SqlParameter("@category_code", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_ADD_INVENTORY", parameters);
            }

            parameters[0].Value = refundInventory;
            parameters[1].Value = agentId;

            if (designCategory == DesignCategory.PowerKard)
            {
                parameters[2].Value = Convert.ToInt32(ProductCategory.PowerKard);

                SQLHelper.ExecuteNonQuery(transaction,
                    CommandType.Text,
                    SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_ADD_INVENTORY"),
                    parameters);
            }
            else
            {
                parameters[2].Value = Convert.ToInt32(ProductCategory.Brochure);

                SQLHelper.ExecuteNonQuery(transaction,
                    CommandType.Text,
                    SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_ADD_INVENTORY"),
                    parameters);

                parameters[2].Value = Convert.ToInt32(ProductCategory.Envelope);

                SQLHelper.ExecuteNonQuery(transaction,
                    CommandType.Text,
                    SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_ADD_INVENTORY"),
                    parameters);
            }
        }

        private bool CanReleaseFarm(int eventId)
        {
            bool releaseFarm = false;

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_ACTIVE_EVENTS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_ACTIVE_EVENTS", parameters);
            }

            parameters[0].Value = eventId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_ACTIVE_EVENTS"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) == 0)
                    {
                        releaseFarm = true;
                    }
                }
            }

            return releaseFarm;
        }

        private void ReleaseFarm(int eventId, SqlTransaction transaction)
        {
            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_RELEASE_FARM");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_RELEASE_FARM", parameters);
            }

            parameters[0].Value = eventId;

            SQLHelper.ExecuteNonQuery(transaction,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_RELEASE_FARM"),
                parameters);
        }

        /// <summary>
        /// Gets the event details for the specified schedule event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Event details for the specified schedule event.</returns>
        public ScheduleSummaryInfo GetEventSummary(int eventId)
        {
            ScheduleSummaryInfo eve = new ScheduleSummaryInfo();

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_EVENT_SUMMARY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_EVENT_SUMMARY", parameters);
            }

            parameters[0].Value = eventId;

            // Execute the query to get the schedule event summary.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_EVENT_SUMMARY"),
                parameters))
            {
                if (reader.Read())
                {
                    eve.AgentId = reader.GetInt32(0);
                    eve.AgentName = reader.GetString(1) + " " +
                        reader.GetString(2);
                    eve.FarmName = reader.GetString(5);
                    eve.EventNumber = reader.GetInt16(7);
                    eve.EventDate = reader.GetDateTime(8).ToString("MM/dd/yyyy");
                }
            }

            return eve;
        }

        /// <summary>
        /// Gets the event entry details for the specified schedule event entry.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <returns>Event entry details for the specified schedule event entry.</returns>
        public ScheduleSummaryInfo GetEventEntrySummary(int eventId, int plotId)
        {
            ScheduleSummaryInfo eve = new ScheduleSummaryInfo();

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_EVENT_ENTRY_SUMMARY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@event_id", SqlDbType.Int),
                    new SqlParameter("@plot_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_EVENT_ENTRY_SUMMARY", parameters);
            }

            parameters[0].Value = eventId;
            parameters[1].Value = plotId;

            // Execute the query to get the schedule event entry summary.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_EVENT_ENTRY_SUMMARY"),
                parameters))
            {
                if (reader.Read())
                {
                    eve.AgentId = reader.GetInt32(0);
                    eve.AgentName = reader.GetString(1) + " " +
                        reader.GetString(2);
                    eve.FarmName = reader.GetString(5);
                    eve.EventNumber = reader.GetInt16(7);
                    eve.EventDate = reader.GetDateTime(8).ToString("MM/dd/yyyy");
                    eve.PlotName = reader.GetString(11);
                }
            }

            return eve;
        }
    }
}

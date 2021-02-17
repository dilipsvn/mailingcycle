using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.DAL
{
    /// <summary>
    /// A Data Access Component used to manage Farms.
    /// </summary>
    public class Farm : IFarm
    {
        private const string MODULE_NAME = "Farm";

        public Farm()
        {
            //
        }

        /// <summary>
        /// Gets User Name for the Given User Id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>User Name of the Application User</returns>
        public string GetUserName(int userId)
        {
            string userName = "";
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_USER_NAME");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_GET_USER_NAME", parameters);
            }
            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_USER_NAME"),
                parameters))
            {
                if (reader.Read())
                    userName = reader.GetString(0);
            }

            return userName;
        }

        /// <summary>
        /// Get the List of Farms for the user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of FarmInfo Model Object as Farm List</returns>
        public List<FarmInfo> GetFarmListForUser(int userId)
        {
            List<FarmInfo> farms = new List<FarmInfo>();
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_FARM_LIST_FOR_USER");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_FARM_LIST_FOR_USER", parameters);
            }
            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_FARM_LIST_FOR_USER"),
                parameters))
            {

                while (reader.Read())
                {
                    FarmInfo farm = new FarmInfo();
                    farm.FarmId = reader.GetInt32(0); farm.FarmName = reader.GetString(1);
                    farm.CreateDate = reader.GetDateTime(2); farm.UserId = reader.GetInt32(3);
                    farm.LastModifyDate = reader.GetDateTime(5); farm.LastModifyBy = reader.GetInt32(6);
                    farm.Deleted = reader.GetBoolean(7);
                    farms.Add(farm);
                }
            }

            return farms;
        }

        /// <summary>
        /// Get the details of the Farm
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Details of the Farm.</returns>
        public List<FarmInfo> GetFarmSummary(int userId)
        {
            List<FarmInfo> farms = new List<FarmInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_GET_FARM_SUMMARY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SP_GET_FARM_SUMMARY", parameters);
            }

            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_GET_FARM_SUMMARY"),
                parameters))
            {
                while (reader.Read())
                {
                    FarmInfo farmInfo = new FarmInfo(reader.GetInt32(0), reader.GetString(1), new MailingPlanInfo(reader.GetInt32(3), reader.GetString(4)), null, reader.GetDateTime(2), userId, reader.GetInt32(5), reader.GetInt32(6));
                    farmInfo.Firmup = reader.GetBoolean(7);
                    farms.Add(farmInfo);
                }
            }

            return farms;
        }

        /// <summary>
        /// Get the Dleted (Archived) farm details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Farm Details of the specified registration account.</returns>
        public List<FarmInfo> GetArchivedFarmSummary(int userId) 
        {
            List<FarmInfo> farms = new List<FarmInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_GET_FARM_ARCHIVED_SUMMARY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SP_GET_FARM_ARCHIVED_SUMMARY", parameters);
            }

            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_GET_FARM_ARCHIVED_SUMMARY"),
                parameters))
            {
                while (reader.Read())
                {
                    FarmInfo farmInfo = new FarmInfo(reader.GetInt32(0), reader.GetString(1), new MailingPlanInfo(reader.GetInt32(3), reader.GetString(4)), null, reader.GetDateTime(2), userId, reader.GetInt32(5), reader.GetInt32(6), reader.GetBoolean(7));
                    farms.Add(farmInfo);
                }
            }

            return farms;
        }

        /// <summary>
        /// Get the Dleted (Archived) farm details of the specified Farm.
        /// </summary>
        /// <param name="farmId">Farm ID</param>
        /// <returns>FarmInfo Model object as details of the specified Farm.</returns>
        public FarmInfo GetArchivedFarmSummaryDetails(int farmId)
        {
            FarmInfo farm = new FarmInfo();
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_ARCHIVED_FARM_SUMMARY_DETAILS");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SP_ARCHIVED_FARM_SUMMARY_DETAILS", parameters);
            }

            parameters[0].Value = farmId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_ARCHIVED_FARM_SUMMARY_DETAILS"),
                parameters))
            {
                if (reader.Read())
                {
                    farm = new FarmInfo(reader.GetInt32(0), reader.GetString(1), new MailingPlanInfo(reader.GetInt32(3), reader.GetString(4)), null, reader.GetDateTime(2), 0, reader.GetInt32(5), reader.GetInt32(6), reader.GetBoolean(7));
                }
            }

            return farm;
        }

        /// <summary>
        /// Gets the List of Plots for a Farm
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>List of PlotInfo Model object as a Plot List</returns>
        public List<PlotInfo> GetPlotListForFarm(int farmId)
        {
            List<PlotInfo> plots = new List<PlotInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_PLOT_LIST_FOR_FARM");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId", SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_PLOT_LIST_FOR_FARM", parameters);
            }
            parameters[0].Value = farmId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_PLOT_LIST_FOR_FARM"),
                parameters))
            {

                while (reader.Read())
                {
                    PlotInfo plot = new PlotInfo();
                    plot.PlotId = reader.GetInt32(0); plot.PlotName = reader.GetString(1);
                    plot.CreateDate = reader.GetDateTime(2); plot.FarmId = reader.GetInt32(3);
                    plot.LastModifyDate = reader.GetDateTime(4); plot.LastModifyBy = reader.GetInt32(5);
                    plot.Deleted = reader.GetBoolean(6);
                    plots.Add(plot);
                }
            }

            return plots;
        }

        /// <summary>
        /// Get the Dleted (Archived) Plot details of the specified Farm with deleted contact Count.
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>PlotInfo Model Object as Archived Plot Summary List Details</returns>
        public List<PlotInfo> GetArchivedPlotSummary(int farmId)
        {
            List<PlotInfo> plots = new List<PlotInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_GET_PLOT_ARCHIVED_SUMMARY");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SP_GET_PLOT_ARCHIVED_SUMMARY", parameters);
            }
            parameters[0].Value = farmId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_GET_PLOT_ARCHIVED_SUMMARY"),
                parameters))
            {
                while (reader.Read())
                {
                    PlotInfo plot = new PlotInfo(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetBoolean(5));
                    plots.Add(plot);
                }
            }

            return plots;
        }

        /// <summary>
        /// Get the Dleted (Archived) Plot details of the specified Plot with Contact count.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>PlotInfo Model Object as Archived Plot Summary Details</returns>
        public PlotInfo GetArchivedPlotSummaryDetails(int plotId)
        {
            PlotInfo plot = new PlotInfo();
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_GET_PLOT_ARCHIVED_SUMMARY_DETAILS");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SP_GET_PLOT_ARCHIVED_SUMMARY_DETAILS", parameters);
            }
            parameters[0].Value = plotId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_GET_PLOT_ARCHIVED_SUMMARY_DETAILS"),
                parameters))
            {
                if (reader.Read())
                {
                    plot = new PlotInfo(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetBoolean(5));
                }
            }
            return plot;
        }

        /// <summary>
        ///     Get Archived Contact List For Plot
        /// </summary>
        /// <param name="plotId">Plot ID</param>
        /// <returns>ContactInfo Array as Contact details for Archived Contacts</returns>
        public List<ContactInfo> GetArchivedContactListForPlot(int plotId)
        {
            List<ContactInfo> contacts = new List<ContactInfo>();
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_ARCHIVED_CONTACT_LIST_FOR_PLOT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_ARCHIVED_CONTACT_LIST_FOR_PLOT", parameters);
            }
            parameters[0].Value = plotId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_ARCHIVED_CONTACT_LIST_FOR_PLOT"),
                parameters))
            {
                while (reader.Read())
                {
                    //For Float Safe operation for [Acres] field
                    float floatAcres = 0;
                    float.TryParse(reader.GetValue(12).ToString(), out floatAcres);

                    ContactInfo contact = new ContactInfo(reader.GetInt64(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                        reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11),
                        floatAcres, reader.GetString(13), reader.GetString(14), reader.GetString(15),
                        reader.GetString(16), reader.GetString(17), reader.GetString(18), reader.GetString(19),
                        reader.GetString(20), reader.GetString(21), reader.GetDateTime(22), reader.GetDecimal(23),
                        reader.GetDateTime(24), reader.GetDateTime(25), reader.GetInt32(26), reader.GetInt32(27));
                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        /// <summary>
        /// Gets the List of Mailing Plan
        /// </summary>
        /// <returns>Returns the List of Mailing Plan</returns>
        public List<MailingPlanInfo> GetMailingPlanList()
        {
            List<MailingPlanInfo> mailingPlans = new List<MailingPlanInfo>();

            // Execute a query to read the Mailing Plan.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_MAILING_PLAN_LIST"),
                null))
            {
                while (reader.Read())
                {
                    MailingPlanInfo mailingPlan = new MailingPlanInfo(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2));

                    mailingPlans.Add(mailingPlan);
                }
            }

            return mailingPlans;
        }

        /// <summary>
        /// Create a new farm with default plot with contacts
        /// </summary>
        /// <param name="farm">Accepts FarmInfo as input</param>
        public void CreateFarmPlot(FarmInfo fram)
        {
            if (IsFarmExistsForUser(fram.UserId, fram.FarmName))
            {
                throw new Exception("Farm Name already Exist. Please give another Farm Name");
            }
            using (SqlConnection sqlCon = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                sqlCon.Open();
                using (SqlTransaction sqlTrans = sqlCon.BeginTransaction())
                {
                    try
                    {
                        //Add Farm
                        SqlParameter[] parametersFarm = SQLHelper.GetCachedParameters("SQL_INSERT_FARM");
                        if (parametersFarm == null)
                        {
                            parametersFarm = new SqlParameter[] {
                                new SqlParameter("@FarmId",SqlDbType.Int),
                                new SqlParameter("@FarmName",SqlDbType.Text,100),
                                new SqlParameter("@UserId",SqlDbType.BigInt),
                                new SqlParameter("@PlanId",SqlDbType.Int),
                                new SqlParameter("@LastModifiedBy",SqlDbType.Int)
                            };
                            SQLHelper.CacheParameters("SQL_INSERT_FARM", parametersFarm);
                        }
                        parametersFarm[0].Direction = ParameterDirection.Output;
                        parametersFarm[0].Value = 0;
                        parametersFarm[1].Value = fram.FarmName;
                        parametersFarm[2].Value = fram.UserId;
                        if (fram.MailingPlan.MailingPlanId == 0)
                            parametersFarm[3].Value = DBNull.Value;
                        else
                            parametersFarm[3].Value = fram.MailingPlan.MailingPlanId;
                        parametersFarm[4].Value = fram.LastModifyBy;
                        SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_FARM"),
                            parametersFarm);
                        fram.FarmId = (int)parametersFarm[0].Value;


                        //Add Default Plot
                        SqlParameter[] parametersPlot = SQLHelper.GetCachedParameters("SQL_INSERT_PLOT");
                        if (parametersPlot == null)
                        {
                            parametersPlot = new SqlParameter[] {
                                new SqlParameter("@PlotId",SqlDbType.Int),
                                new SqlParameter("@PlotName",SqlDbType.Text,100),
                                new SqlParameter("@FarmId",SqlDbType.BigInt),
                                new SqlParameter("@LastModifiedBy",SqlDbType.Int)
                            };
                            SQLHelper.CacheParameters("SQL_INSERT_PLOT", parametersPlot);
                        }
                        parametersPlot[0].Direction = ParameterDirection.Output;
                        parametersPlot[0].Value = 0;
                        parametersPlot[1].Value = fram.Plots[0].PlotName;
                        parametersPlot[2].Value = fram.FarmId;
                        parametersPlot[3].Value = fram.Plots[0].LastModifyBy;
                        SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_PLOT"),
                            parametersPlot);
                        fram.Plots[0].PlotId = (int)parametersPlot[0].Value;


                        //Add Contact List
                        int contactCount = 0;
                        for (int i = 0; i < fram.Plots[0].Contacts.Count; i++)
                        {
                            SqlParameter[] parametersContact = SQLHelper.GetCachedParameters("SQL_INSERT_CONTACT");
                            if (parametersContact == null)
                            {
                                parametersContact = new SqlParameter[] {
                                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                                    new SqlParameter("@ScheduleNumber",SqlDbType.Int),
                                    new SqlParameter("@OwnerFullName",SqlDbType.Text,100),
                                    new SqlParameter("@Lot",SqlDbType.Int),
                                    new SqlParameter("@Block",SqlDbType.Text,10),
                                    new SqlParameter("@SubDivision",SqlDbType.Text,100),
                                    new SqlParameter("@Filing",SqlDbType.Text,50),
                                    new SqlParameter("@SiteAddress",SqlDbType.Text,255),
                                    new SqlParameter("@Bedrooms",SqlDbType.Int),
                                    new SqlParameter("@FullBath",SqlDbType.Int),
                                    new SqlParameter("@ThreeQuaterBath",SqlDbType.Int),
                                    new SqlParameter("@HalfBath",SqlDbType.Int),
                                    new SqlParameter("@Acres",SqlDbType.Float),
                                    new SqlParameter("@ActMktComb",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerFirstName",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerLastName",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerAddress1",SqlDbType.Text,255),
                                    new SqlParameter("@OwnerAddress2",SqlDbType.Text,255),
                                    new SqlParameter("@OwnerCity",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerState",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerZip",SqlDbType.Text,15),
                                    new SqlParameter("@OwnerCountry",SqlDbType.Text,50),
                                    new SqlParameter("@SaleDate",SqlDbType.DateTime),
                                    new SqlParameter("@TransAmount",SqlDbType.Decimal),
                                    new SqlParameter("@LastModifyBy",SqlDbType.Int),
                                    new SqlParameter("@PlotId",SqlDbType.Int)
                                };
                                SQLHelper.CacheParameters("SQL_INSERT_CONTACT", parametersContact);
                            }
                            parametersContact[0].Direction = ParameterDirection.Output;
                            parametersContact[0].Value = 0;
                            parametersContact[1].Value = fram.Plots[0].Contacts[i].ScheduleNumber;
                            parametersContact[2].Value = fram.Plots[0].Contacts[i].OwnerFullName;
                            parametersContact[3].Value = fram.Plots[0].Contacts[i].Lot;
                            parametersContact[4].Value = fram.Plots[0].Contacts[i].Block;
                            parametersContact[5].Value = fram.Plots[0].Contacts[i].Subdivision;
                            parametersContact[6].Value = fram.Plots[0].Contacts[i].Filing;
                            parametersContact[7].Value = fram.Plots[0].Contacts[i].SiteAddress;
                            parametersContact[8].Value = fram.Plots[0].Contacts[i].Bedrooms;
                            parametersContact[9].Value = fram.Plots[0].Contacts[i].FullBath;
                            parametersContact[10].Value = fram.Plots[0].Contacts[i].ThreeQuarterBath;
                            parametersContact[11].Value = fram.Plots[0].Contacts[i].HalfBath;
                            parametersContact[12].Value = fram.Plots[0].Contacts[i].Acres;
                            parametersContact[13].Value = fram.Plots[0].Contacts[i].ActMktComb;
                            parametersContact[14].Value = fram.Plots[0].Contacts[i].OwnerFirstName;
                            parametersContact[15].Value = fram.Plots[0].Contacts[i].OwnerLastName;
                            parametersContact[16].Value = fram.Plots[0].Contacts[i].OwnerAddress1;
                            parametersContact[17].Value = fram.Plots[0].Contacts[i].OwnerAddress2;
                            parametersContact[18].Value = fram.Plots[0].Contacts[i].OwnerCity;
                            parametersContact[19].Value = fram.Plots[0].Contacts[i].OwnerState;
                            parametersContact[20].Value = fram.Plots[0].Contacts[i].OwnerZip;
                            parametersContact[21].Value = fram.Plots[0].Contacts[i].OwnerCountry;
                            parametersContact[22].Value = fram.Plots[0].Contacts[i].SaleDate;
                            parametersContact[23].Value = fram.Plots[0].Contacts[i].TransAmount;
                            parametersContact[24].Value = fram.Plots[0].Contacts[i].LastModifyBy;
                            parametersContact[25].Value = fram.Plots[0].PlotId;
                            SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_CONTACT"),
                            parametersContact);
                            contactCount++;
                        }
                        //Check atleast one contact is available
                        if (contactCount == 0)
                        {
                            throw new Exception("No Contacts processed. Farm cannot be Empty.");
                        }

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, fram.FarmName,
                            "Added farm", fram.UserId, fram.LastModifyBy);
                        AuditTrail.WriteEntry(auditEntry, sqlTrans);

                        sqlTrans.Commit();
                    }
                    catch (Exception exception)
                    {
                        sqlTrans.Rollback();
                        throw exception;
                    }
                }
            }

        }


        /// <summary>
        /// Gets the count of Farms available by the Farm Name on a pirticular User
        /// </summary>
        /// <param name="userId">User Id of the user</param>
        /// <param name="farmName">Name of the Farm</param>
        /// <returns>Count of Forms</returns>
        public int GetCountOfFarmsForFarmNameOnUser(int userId, string farmName)
        {
            int count = 0;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_COUNT_OF_FARMS_FOR_FARM_NAME_ON_USER");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@userId",SqlDbType.Int),
                    new SqlParameter("@farmName",SqlDbType.NVarChar,100)
                };
                SQLHelper.CacheParameters("SQL_GET_COUNT_OF_FARMS_FOR_FARM_NAME_ON_USER", parameters);
            }
            parameters[0].Value = userId;
            parameters[1].Value = farmName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_COUNT_OF_FARMS_FOR_FARM_NAME_ON_USER"),
                parameters))
            {
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }

            return count;

        }


        /// <summary>
        /// Gets the count of Plots available by the Plot Name on a pirticular Farm
        /// </summary>
        /// <param name="farmId">Plot Id </param>
        /// <param name="plotName">Name of the Plot</param>
        /// <returns>Count of Plots</returns>
        public int GetCountOfPlotsForPlotNameOnFarm(int farmId, string plotName)
        {
            int count = 0;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_COUNT_OF_PLOTS_FOR_PLOT_NAME_ON_FARM");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@PlotName",SqlDbType.NVarChar,100)
                };
                SQLHelper.CacheParameters("SQL_GET_COUNT_OF_PLOTS_FOR_PLOT_NAME_ON_FARM", parameters);
            }
            parameters[0].Value = farmId;
            parameters[1].Value = plotName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_COUNT_OF_PLOTS_FOR_PLOT_NAME_ON_FARM"),
                parameters))
            {
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }

            return count;

        }

        /// <summary>
        /// Create a new plot
        /// </summary>
        /// <param name="Plot">Accepts PlotInfo as input</param>
        public int CreatePlotForMoveContacts(PlotInfo plot)
        {
            // Get the farm details.
            FarmInfo farmInfo = GetFarmDetail(plot.FarmId);
            int userId = GetUserIdForFarm(plot.FarmId);

            // Is it a Duplicate Plot Name
            if (IsPlotExistsForFarm(plot.FarmId, plot.PlotName))
            {
                throw new Exception("Plot Name already Exist. Please Provide a different Plot Name");
            }

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_INSERT_PLOT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                                new SqlParameter("@PlotId",SqlDbType.Int),
                                new SqlParameter("@PlotName",SqlDbType.Text,100),
                                new SqlParameter("@FarmId",SqlDbType.Int),
                                new SqlParameter("@LastModifiedBy",SqlDbType.Int)
                            };
                SQLHelper.CacheParameters("SQL_INSERT_PLOT", parameters);
            }
            parameters[0].Direction = ParameterDirection.Output;
            parameters[0].Value = 0;
            parameters[1].Value = plot.PlotName;
            parameters[2].Value = plot.FarmId;
            parameters[3].Value = plot.LastModifyBy;
            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_PLOT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmInfo.FarmName + "/" + plot.PlotName,
                            "Added plot", userId, plot.LastModifyBy);
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
            return Convert.ToInt32(parameters[0].Value);
        }
        
        /// <summary>
        /// Create a new plot with contacts
        /// </summary>
        /// <param name="Plot">Accepts PlotInfo as input</param>
        public void CreatePlot(PlotInfo plot)
        {
            //Check Duplicate Plot Name
            if(IsPlotExistsForFarm(plot.FarmId,plot.PlotName))
            {
                throw new Exception("Plot Name already in use. Please provide a new Plot Name");
            }
            
            // Get the farm details.
            FarmInfo farmInfo = GetFarmDetail(plot.FarmId);
            int userId = GetUserIdForFarm(plot.FarmId);
            
            using (SqlConnection sqlCon = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                sqlCon.Open();
                using (SqlTransaction sqlTrans = sqlCon.BeginTransaction())
                {
                    try
                    {

                        //Add Plot
                        SqlParameter[] parametersPlot = SQLHelper.GetCachedParameters("SQL_INSERT_PLOT");
                        if (parametersPlot == null)
                        {
                            parametersPlot = new SqlParameter[] {
                                new SqlParameter("@PlotId",SqlDbType.Int),
                                new SqlParameter("@PlotName",SqlDbType.Text,100),
                                new SqlParameter("@FarmId",SqlDbType.BigInt),
                                new SqlParameter("@LastModifiedBy",SqlDbType.Int)
                            };
                            SQLHelper.CacheParameters("SQL_INSERT_PLOT", parametersPlot);
                        }
                        parametersPlot[0].Direction = ParameterDirection.Output;
                        parametersPlot[0].Value = 0;
                        parametersPlot[1].Value = plot.PlotName;
                        parametersPlot[2].Value = plot.FarmId;
                        parametersPlot[3].Value = plot.LastModifyBy;
                        SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_PLOT"),
                            parametersPlot);
                        plot.PlotId = (int)parametersPlot[0].Value;

                        //Add Contact List
                        int contactCount = 0;
                        for (int i = 0; i < plot.Contacts.Count; i++)
                        {
                            SqlParameter[] parametersContact = SQLHelper.GetCachedParameters("SQL_INSERT_CONTACT");
                            if (parametersContact == null)
                            {
                                parametersContact = new SqlParameter[] {
                                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                                    new SqlParameter("@ScheduleNumber",SqlDbType.Int),
                                    new SqlParameter("@OwnerFullName",SqlDbType.Text,100),
                                    new SqlParameter("@Lot",SqlDbType.Int),
                                    new SqlParameter("@Block",SqlDbType.Text,10),
                                    new SqlParameter("@SubDivision",SqlDbType.Text,100),
                                    new SqlParameter("@Filing",SqlDbType.Text,50),
                                    new SqlParameter("@SiteAddress",SqlDbType.Text,255),
                                    new SqlParameter("@Bedrooms",SqlDbType.Int),
                                    new SqlParameter("@FullBath",SqlDbType.Int),
                                    new SqlParameter("@ThreeQuaterBath",SqlDbType.Int),
                                    new SqlParameter("@HalfBath",SqlDbType.Int),
                                    new SqlParameter("@Acres",SqlDbType.Float),
                                    new SqlParameter("@ActMktComb",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerFirstName",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerLastName",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerAddress1",SqlDbType.Text,255),
                                    new SqlParameter("@OwnerAddress2",SqlDbType.Text,255),
                                    new SqlParameter("@OwnerCity",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerState",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerZip",SqlDbType.Text,15),
                                    new SqlParameter("@OwnerCountry",SqlDbType.Text,50),
                                    new SqlParameter("@SaleDate",SqlDbType.DateTime),
                                    new SqlParameter("@TransAmount",SqlDbType.Decimal),
                                    new SqlParameter("@LastModifyBy",SqlDbType.Int),
                                    new SqlParameter("@PlotId",SqlDbType.Int)
                                };
                                SQLHelper.CacheParameters("SQL_INSERT_CONTACT", parametersContact);
                            }
                            parametersContact[0].Direction = ParameterDirection.Output;
                            parametersContact[0].Value = 0;
                            parametersContact[1].Value = plot.Contacts[i].ScheduleNumber;
                            parametersContact[2].Value = plot.Contacts[i].OwnerFullName;
                            parametersContact[3].Value = plot.Contacts[i].Lot;
                            parametersContact[4].Value = plot.Contacts[i].Block;
                            parametersContact[5].Value = plot.Contacts[i].Subdivision;
                            parametersContact[6].Value = plot.Contacts[i].Filing;
                            parametersContact[7].Value = plot.Contacts[i].SiteAddress;
                            parametersContact[8].Value = plot.Contacts[i].Bedrooms;
                            parametersContact[9].Value = plot.Contacts[i].FullBath;
                            parametersContact[10].Value = plot.Contacts[i].ThreeQuarterBath;
                            parametersContact[11].Value = plot.Contacts[i].HalfBath;
                            parametersContact[12].Value = plot.Contacts[i].Acres;
                            parametersContact[13].Value = plot.Contacts[i].ActMktComb;
                            parametersContact[14].Value = plot.Contacts[i].OwnerFirstName;
                            parametersContact[15].Value = plot.Contacts[i].OwnerLastName;
                            parametersContact[16].Value = plot.Contacts[i].OwnerAddress1;
                            parametersContact[17].Value = plot.Contacts[i].OwnerAddress2;
                            parametersContact[18].Value = plot.Contacts[i].OwnerCity;
                            parametersContact[19].Value = plot.Contacts[i].OwnerState;
                            parametersContact[20].Value = plot.Contacts[i].OwnerZip;
                            parametersContact[21].Value = plot.Contacts[i].OwnerCountry;
                            parametersContact[22].Value = plot.Contacts[i].SaleDate;
                            parametersContact[23].Value = plot.Contacts[i].TransAmount;
                            parametersContact[24].Value = plot.Contacts[i].LastModifyBy;
                            parametersContact[25].Value = plot.PlotId;
                            SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_CONTACT"),
                            parametersContact);
                            contactCount++;
                        }
                        
                        // Check if atleast one contact is Added 
                        if (contactCount == 0)
                        {
                            throw new Exception("No Contacts processed. Plot cannot be Empty.");
                        }

                        SqlParameter[] sqlParams = new SqlParameter[]{new SqlParameter("@plot_id",SqlDbType.Int)};
                        sqlParams[0].Value = plot.PlotId;
                        SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_INSERT_PLOT_EVENTS"),
                            sqlParams);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmInfo.FarmName + "/" + plot.PlotName,
                            "Added plot", userId, plot.LastModifyBy);
                        AuditTrail.WriteEntry(auditEntry, sqlTrans);

                        sqlTrans.Commit();
                    }
                    catch (Exception exception)
                    {
                        sqlTrans.Rollback();
                        throw exception;
                    }
                }
            }

        }

        /// <summary>
        /// Get the number plots attached to the Farm
        /// </summary>
        /// <param name="farmId">Farm ID</param>
        /// <returns>Count of plots</returns>
        public int GetPlotCountForFarm(int farmId)
        {
            int count = 0;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_PLOT_COUNT_FOR_FARM");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_GET_PLOT_COUNT_FOR_FARM", parameters);
            }
            parameters[0].Value = farmId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_PLOT_COUNT_FOR_FARM"),
                parameters))
            {
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }

            return count;
        }

        /// <summary>
        /// Get the number Contacts attached to the Plot
        /// </summary>
        /// <param name="farmId">Plot ID</param>
        /// <returns>Count of Contacts</returns>
        public int GetContactCountForPlot(int plotId)
        {
            int count = 0;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_CONTACT_COUNT_FOR_PLOT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_GET_CONTACT_COUNT_FOR_PLOT", parameters);
            }
            parameters[0].Value = plotId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_CONTACT_COUNT_FOR_PLOT"),
                parameters))
            {
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }

            return count;
        }

        /// <summary>
        /// To Delete a Plot
        /// </summary>
        /// <param name="plotId">Plot Id of the Plot Which is to be deleted</param>
        /// <param name="lastModifyBy">Last Modified By User Id</param>
        public void DeletePlot(int plotId, int lastModifyBy)
        {
            // Get the farm & plot details.
            string farmName = GetFarmNameOfPlot(plotId);
            PlotInfo plotInfo = GetPlotDetail(plotId);
            int userId = GetUserIdForPlot(plotId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_DELETE_PLOT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId",SqlDbType.Int),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_DELETE_PLOT", parameters);
            }
            parameters[0].Value = plotId;
            parameters[1].Value = lastModifyBy;
            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_DELETE_PLOT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmName + "/" + plotInfo.PlotName,
                            "Deleted plot", userId, lastModifyBy);
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
        /// To Delete a Farm
        /// </summary>
        /// <param name="farmId">Farm Id of the Farm to be deleted</param>
        /// <param name="lastModifyBy">Last Modified By User Id</param>
        public void DeleteFarm(int farmId, int lastModifyBy)
        {
            // Get the farm details.
            FarmInfo farmInfo = GetFarmDetail(farmId);
            int userId = GetUserIdForFarm(farmId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_DELETE_FARM");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@LastModifyBy", SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_DELETE_FARM", parameters);
            }
            parameters[0].Value = farmId;
            parameters[1].Value = lastModifyBy;

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_DELETE_FARM"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmInfo.FarmName,
                            "Deleted farm", userId, lastModifyBy);
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
        /// updates the farm details and default plot details with contacts
        /// </summary>
        /// <param name="fram">Accepts FarmInfo as input</param>
        public void UpdateFarmPlot(FarmInfo farm)
        {
            // Get the farm details.
            int userId = GetUserIdForFarm(farm.FarmId);

            using (SqlConnection sqlCon = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                sqlCon.Open();
                using (SqlTransaction sqlTrans = sqlCon.BeginTransaction())
                {
                    try
                    {
                        //Get Old Farm Name
                        FarmInfo farmOld = null;
                        SqlParameter[] parametersOldFarm = SQLHelper.GetCachedParameters("SQL_GET_FARM_BASIC_DETAIL");
                        if (parametersOldFarm == null)
                        {
                            parametersOldFarm = new SqlParameter[] {
                                new SqlParameter("@FarmId",SqlDbType.Int)
                            };
                            SQLHelper.CacheParameters("SQL_GET_FARM_BASIC_DETAIL", parametersOldFarm);
                        }
                        parametersOldFarm[0].Value = farm.FarmId;
                        using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                            CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_FARM_BASIC_DETAIL"),
                            parametersOldFarm))
                        {
                            if (reader.Read())
                            {
                                farmOld = new FarmInfo(reader.GetInt32(0),reader.GetString(1),reader.GetDateTime(2),reader.GetInt32(3));
                            }
                        }

                        //Chech for Farm Name Change
                        bool IsFarmNameChanged = false;
                        if (farmOld.FarmName!=farm.FarmName)
                            IsFarmNameChanged = true;

                        //Get Default Plot
                        PlotInfo plot = new PlotInfo();
                        SqlParameter[] parametersDefaultPlot = SQLHelper.GetCachedParameters("SQL_GET_DEFAULT_PLOT_FOR_FARM");
                        if (parametersDefaultPlot == null)
                        {
                            parametersDefaultPlot = new SqlParameter[] {
                                new SqlParameter("@FarmId",SqlDbType.Int)
                            };
                            SQLHelper.CacheParameters("SQL_GET_DEFAULT_PLOT_FOR_FARM", parametersDefaultPlot);
                        }
                        parametersDefaultPlot[0].Value = farm.FarmId;
                        using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                            CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_DEFAULT_PLOT_FOR_FARM"),
                            parametersDefaultPlot))
                        {
                            if (reader.Read())
                            {
                                plot = new PlotInfo(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
                            }
                        }

                        //Incase there is no Default Plot
                        if (plot == null)
                            throw new Exception("No Default Plot");

                        //Update Farm
                        SqlParameter[] parametersFarm = SQLHelper.GetCachedParameters("SQL_UPDATE_FARM");
                        if (parametersFarm == null)
                        {
                            parametersFarm = new SqlParameter[] {
                                new SqlParameter("@FarmId",SqlDbType.Int),
                                new SqlParameter("@FarmName",SqlDbType.Text,100),
                                new SqlParameter("@PlanId",SqlDbType.Int),
                                new SqlParameter("@LastModifiedBy",SqlDbType.Int)
                            };
                            SQLHelper.CacheParameters("SQL_UPDATE_FARM", parametersFarm);
                        }
                        parametersFarm[0].Value = farm.FarmId;
                        parametersFarm[1].Value = farm.FarmName;
                        if (farm.MailingPlan.MailingPlanId == 0)
                            parametersFarm[2].Value = DBNull.Value;
                        else
                            parametersFarm[2].Value = farm.MailingPlan.MailingPlanId;
                        parametersFarm[3].Value = farm.LastModifyBy;
                        SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_FARM"),
                            parametersFarm);

                        //Change Default Plot if farm Name is Changed
                        if(IsFarmNameChanged)
                        {
                            //Incase the new Farm Name is already existing in its Plot List other than Default Plot.
                            if(IsPlotExistsForFarmOnUpdate(farm.FarmId,plot.PlotId,farm.FarmName))
                            {
                                throw new Exception("You are changing Farm Name and this will change the name of Primary Plot.This name already existing in its Plot lists. Please Provide a different Farm name." );
                            }
                            SqlParameter[] parametersPlotName = SQLHelper.GetCachedParameters("SQL_UPDATE_PLOT_NAME");
                            if (parametersPlotName == null)
                            {
                                parametersPlotName = new SqlParameter[] {
                                    new SqlParameter("@PlotName",SqlDbType.Text,100),
                                    new SqlParameter("@PlotId",SqlDbType.Int)
                                };
                                SQLHelper.CacheParameters("SQL_UPDATE_PLOT_NAME", parametersPlotName);
                            }
                            parametersPlotName[0].Value = farm.FarmName;
                            parametersPlotName[1].Value = plot.PlotId;
                            SQLHelper.ExecuteNonQuery(sqlTrans,
                                CommandType.Text,
                                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_PLOT_NAME"),
                                parametersPlotName);
                        }

                        farm.Plots[0].PlotId = plot.PlotId;
                                                
                        //Add Contact List
                        for (int i = 0; i < farm.Plots[0].Contacts.Count; i++)
                        {
                            SqlParameter[] parametersContact = SQLHelper.GetCachedParameters("SQL_INSERT_CONTACT");
                            if (parametersContact == null)
                            {
                                parametersContact = new SqlParameter[] {
                                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                                    new SqlParameter("@ScheduleNumber",SqlDbType.Int),
                                    new SqlParameter("@OwnerFullName",SqlDbType.Text,100),
                                    new SqlParameter("@Lot",SqlDbType.Int),
                                    new SqlParameter("@Block",SqlDbType.Text,10),
                                    new SqlParameter("@SubDivision",SqlDbType.Text,100),
                                    new SqlParameter("@Filing",SqlDbType.Text,50),
                                    new SqlParameter("@SiteAddress",SqlDbType.Text,255),
                                    new SqlParameter("@Bedrooms",SqlDbType.Int),
                                    new SqlParameter("@FullBath",SqlDbType.Int),
                                    new SqlParameter("@ThreeQuaterBath",SqlDbType.Int),
                                    new SqlParameter("@HalfBath",SqlDbType.Int),
                                    new SqlParameter("@Acres",SqlDbType.Float),
                                    new SqlParameter("@ActMktComb",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerFirstName",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerLastName",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerAddress1",SqlDbType.Text,255),
                                    new SqlParameter("@OwnerAddress2",SqlDbType.Text,255),
                                    new SqlParameter("@OwnerCity",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerState",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerZip",SqlDbType.Text,15),
                                    new SqlParameter("@OwnerCountry",SqlDbType.Text,50),
                                    new SqlParameter("@SaleDate",SqlDbType.DateTime),
                                    new SqlParameter("@TransAmount",SqlDbType.Decimal),
                                    new SqlParameter("@LastModifyBy",SqlDbType.Int),
                                    new SqlParameter("@PlotId",SqlDbType.Int)
                                };
                                SQLHelper.CacheParameters("SQL_INSERT_CONTACT", parametersContact);
                            }
                            parametersContact[0].Direction = ParameterDirection.Output;
                            parametersContact[0].Value = 0;
                            parametersContact[1].Value = farm.Plots[0].Contacts[i].ScheduleNumber;
                            parametersContact[2].Value = farm.Plots[0].Contacts[i].OwnerFullName;
                            parametersContact[3].Value = farm.Plots[0].Contacts[i].Lot;
                            parametersContact[4].Value = farm.Plots[0].Contacts[i].Block;
                            parametersContact[5].Value = farm.Plots[0].Contacts[i].Subdivision;
                            parametersContact[6].Value = farm.Plots[0].Contacts[i].Filing;
                            parametersContact[7].Value = farm.Plots[0].Contacts[i].SiteAddress;
                            parametersContact[8].Value = farm.Plots[0].Contacts[i].Bedrooms;
                            parametersContact[9].Value = farm.Plots[0].Contacts[i].FullBath;
                            parametersContact[10].Value = farm.Plots[0].Contacts[i].ThreeQuarterBath;
                            parametersContact[11].Value = farm.Plots[0].Contacts[i].HalfBath;
                            parametersContact[12].Value = farm.Plots[0].Contacts[i].Acres;
                            parametersContact[13].Value = farm.Plots[0].Contacts[i].ActMktComb;
                            parametersContact[14].Value = farm.Plots[0].Contacts[i].OwnerFirstName;
                            parametersContact[15].Value = farm.Plots[0].Contacts[i].OwnerLastName;
                            parametersContact[16].Value = farm.Plots[0].Contacts[i].OwnerAddress1;
                            parametersContact[17].Value = farm.Plots[0].Contacts[i].OwnerAddress2;
                            parametersContact[18].Value = farm.Plots[0].Contacts[i].OwnerCity;
                            parametersContact[19].Value = farm.Plots[0].Contacts[i].OwnerState;
                            parametersContact[20].Value = farm.Plots[0].Contacts[i].OwnerZip;
                            parametersContact[21].Value = farm.Plots[0].Contacts[i].OwnerCountry;
                            parametersContact[22].Value = farm.Plots[0].Contacts[i].SaleDate;
                            parametersContact[23].Value = farm.Plots[0].Contacts[i].TransAmount;
                            parametersContact[24].Value = farm.Plots[0].Contacts[i].LastModifyBy;
                            parametersContact[25].Value = farm.Plots[0].PlotId;
                            SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_CONTACT"),
                            parametersContact);
                        }

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farm.FarmName,
                            "Modified farm", userId, farm.LastModifyBy);
                        AuditTrail.WriteEntry(auditEntry, sqlTrans);

                        sqlTrans.Commit();
                    }
                    catch
                    {
                        sqlTrans.Rollback();
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Updates Plot Information
        /// </summary>
        /// <param name="plot">PlotInfo Model Object as Plot Details</param>
        public void UpdatePlot(PlotInfo plot)
        {
            // Get the farm details.
            string farmName = GetFarmNameOfPlot(plot.PlotId);
            int userId = GetUserIdForPlot(plot.PlotId);

            using (SqlConnection sqlCon = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                sqlCon.Open();
                using (SqlTransaction sqlTrans = sqlCon.BeginTransaction())
                {
                    try
                    {
                        //Check If it is a Default Plot
                        bool IsDefaultPlot = false;
                        int count = 0;
                        SqlParameter[] parametersDefaultPlot = SQLHelper.GetCachedParameters("SQL_CHECK_DEFAULT_PLOT");
                        if (parametersDefaultPlot == null)
                        {
                            parametersDefaultPlot = new SqlParameter[] {
                                new SqlParameter("@PlotId",SqlDbType.Int)
                            };
                            SQLHelper.CacheParameters("SQL_CHECK_DEFAULT_PLOT", parametersDefaultPlot);
                        }
                        parametersDefaultPlot[0].Value = plot.PlotId;
                        using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                            CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_CHECK_DEFAULT_PLOT"),
                            parametersDefaultPlot))
                        {
                            if (reader.Read())
                            {
                                count = reader.GetInt32(0);
                            }
                        }
                        if (count != 0)
                            IsDefaultPlot = true;

                        //Update Plot
                        SqlParameter[] parametersPlot = SQLHelper.GetCachedParameters("SQL_UPDATE_PLOT");
                        if (parametersPlot == null)
                        {
                            parametersPlot = new SqlParameter[] {
                                new SqlParameter("@PlotId",SqlDbType.Int),
                                new SqlParameter("@PlotName",SqlDbType.Text,100),
                                new SqlParameter("@FarmId",SqlDbType.BigInt),
                                new SqlParameter("@LastModifiedBy",SqlDbType.Int)            
                            };
                            SQLHelper.CacheParameters("SQL_UPDATE_PLOT", parametersPlot);
                        }
                        parametersPlot[0].Value = plot.PlotId;
                        parametersPlot[1].Value = plot.PlotName;
                        parametersPlot[2].Value = plot.FarmId;
                        parametersPlot[3].Value = plot.LastModifyBy;
                        SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_PLOT"),
                            parametersPlot);

                        //Check if Default Plot the Update the Farm name same as Plot Name
                        if (IsDefaultPlot)
                        {
                            //Check for existing Farm Name
                            if (IsFarmExistsForUserOnUpdate(userId, plot.FarmId, plot.PlotName))
                            {
                                throw new Exception("You are changing Primary Plot Name which will change the Farm name. A Farm by this name already exisist. Please provide a differnt Plot name.");
                            }

                            SqlParameter[] parametersFarmName = SQLHelper.GetCachedParameters("SQL_UPDATE_FARM_NAME");
                            if (parametersFarmName == null)
                            {
                                parametersFarmName = new SqlParameter[] {
                                    new SqlParameter("@FarmName",SqlDbType.Text,100),
                                    new SqlParameter("@FarmId",SqlDbType.BigInt)
                                };
                                SQLHelper.CacheParameters("SQL_UPDATE_FARM_NAME", parametersFarmName);
                            }
                            parametersFarmName[0].Value = plot.PlotName;
                            parametersFarmName[1].Value = plot.FarmId;
                            SQLHelper.ExecuteNonQuery(sqlTrans,
                                CommandType.Text,
                                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_FARM_NAME"),
                                parametersFarmName);
                        }
                        

                        //Add Contact List
                        for (int i = 0; i < plot.Contacts.Count; i++)
                        {
                            SqlParameter[] parametersContact = SQLHelper.GetCachedParameters("SQL_INSERT_CONTACT");
                            if (parametersContact == null)
                            {
                                parametersContact = new SqlParameter[] {
                                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                                    new SqlParameter("@ScheduleNumber",SqlDbType.Int),
                                    new SqlParameter("@OwnerFullName",SqlDbType.Text,100),
                                    new SqlParameter("@Lot",SqlDbType.Int),
                                    new SqlParameter("@Block",SqlDbType.Text,10),
                                    new SqlParameter("@SubDivision",SqlDbType.Text,100),
                                    new SqlParameter("@Filing",SqlDbType.Text,50),
                                    new SqlParameter("@SiteAddress",SqlDbType.Text,255),
                                    new SqlParameter("@Bedrooms",SqlDbType.Int),
                                    new SqlParameter("@FullBath",SqlDbType.Int),
                                    new SqlParameter("@ThreeQuaterBath",SqlDbType.Int),
                                    new SqlParameter("@HalfBath",SqlDbType.Int),
                                    new SqlParameter("@Acres",SqlDbType.Float),
                                    new SqlParameter("@ActMktComb",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerFirstName",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerLastName",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerAddress1",SqlDbType.Text,255),
                                    new SqlParameter("@OwnerAddress2",SqlDbType.Text,255),
                                    new SqlParameter("@OwnerCity",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerState",SqlDbType.Text,50),
                                    new SqlParameter("@OwnerZip",SqlDbType.Text,15),
                                    new SqlParameter("@OwnerCountry",SqlDbType.Text,50),
                                    new SqlParameter("@SaleDate",SqlDbType.DateTime),
                                    new SqlParameter("@TransAmount",SqlDbType.Decimal),
                                    new SqlParameter("@LastModifyBy",SqlDbType.Int),
                                    new SqlParameter("@PlotId",SqlDbType.Int)
                                };
                                SQLHelper.CacheParameters("SQL_INSERT_CONTACT", parametersContact);
                            }
                            parametersContact[0].Direction = ParameterDirection.Output;
                            parametersContact[0].Value = 0;
                            parametersContact[1].Value = plot.Contacts[i].ScheduleNumber;
                            parametersContact[2].Value = plot.Contacts[i].OwnerFullName;
                            parametersContact[3].Value = plot.Contacts[i].Lot;
                            parametersContact[4].Value = plot.Contacts[i].Block;
                            parametersContact[5].Value = plot.Contacts[i].Subdivision;
                            parametersContact[6].Value = plot.Contacts[i].Filing;
                            parametersContact[7].Value = plot.Contacts[i].SiteAddress;
                            parametersContact[8].Value = plot.Contacts[i].Bedrooms;
                            parametersContact[9].Value = plot.Contacts[i].FullBath;
                            parametersContact[10].Value = plot.Contacts[i].ThreeQuarterBath;
                            parametersContact[11].Value = plot.Contacts[i].HalfBath;
                            parametersContact[12].Value = plot.Contacts[i].Acres;
                            parametersContact[13].Value = plot.Contacts[i].ActMktComb;
                            parametersContact[14].Value = plot.Contacts[i].OwnerFirstName;
                            parametersContact[15].Value = plot.Contacts[i].OwnerLastName;
                            parametersContact[16].Value = plot.Contacts[i].OwnerAddress1;
                            parametersContact[17].Value = plot.Contacts[i].OwnerAddress2;
                            parametersContact[18].Value = plot.Contacts[i].OwnerCity;
                            parametersContact[19].Value = plot.Contacts[i].OwnerState;
                            parametersContact[20].Value = plot.Contacts[i].OwnerZip;
                            parametersContact[21].Value = plot.Contacts[i].OwnerCountry;
                            parametersContact[22].Value = plot.Contacts[i].SaleDate;
                            parametersContact[23].Value = plot.Contacts[i].TransAmount;
                            parametersContact[24].Value = plot.Contacts[i].LastModifyBy;
                            parametersContact[25].Value = plot.PlotId;
                            SQLHelper.ExecuteNonQuery(sqlTrans,
                            CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_CONTACT"),
                            parametersContact);
                        }

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmName + "/" + plot.PlotName,
                            "Modified plot", userId, plot.LastModifyBy);
                        AuditTrail.WriteEntry(auditEntry, sqlTrans);

                        sqlTrans.Commit();
                    }
                    catch
                    {
                        sqlTrans.Rollback();
                        throw;
                    }
                }

            }
        }

        /// <summary>
        /// Get farm details for a Farm Id
        /// </summary>
        /// <param name="FarmId">Farm ID</param>
        /// <returns>FarmInfo Model Object as Farm Details</returns>
        public FarmInfo GetFarmDetail(int farmId)
        {
            FarmInfo farm = new FarmInfo();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_FARM_SUMMARY_DETAIL");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_GET_FARM_SUMMARY_DETAIL", parameters);
            }
            parameters[0].Value = farmId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_FARM_SUMMARY_DETAIL"),
                parameters))
            {
                if (reader.Read())
                {
                    List<PlotInfo> plots = new List<PlotInfo>();
                    plots = GetPlotListSummaryForFarm(farmId);
                    farm = new FarmInfo(reader.GetInt32(0), reader.GetString(1), new MailingPlanInfo(reader.GetInt32(3), reader.GetString(4)), plots, reader.GetDateTime(2), 0, reader.GetInt32(5), reader.GetInt32(6));
                    farm.Firmup = reader.GetBoolean(7);
                }
            }
            return farm;
        }
         
        /// <summary>
        /// Gets the List of Plots for a Farm
        /// </summary>
        /// <param name="FarmId">Farm ID</param>
        /// <returns>PlotInfo as the List of Plots</returns>
        public List<PlotInfo> GetPlotListSummaryForFarm(int farmId)
        {
            List<PlotInfo> plots = new List<PlotInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_PLOT_LIST_SUMMARY_FOR_FARM");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_GET_PLOT_LIST_SUMMARY_FOR_FARM", parameters);
            }
            parameters[0].Value = farmId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_PLOT_LIST_SUMMARY_FOR_FARM"),
                parameters))
            {
                while (reader.Read())
                {
                    PlotInfo plot = new PlotInfo(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4));
                    plots.Add(plot);
                }
            }

            return plots;
        }

        /// <summary>
        /// Gets userId for the Farm
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>User ID</returns>
        public int GetUserIdForFarm(int farmId)
        {
            int userId = 0;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_USER_ID_FOR_FARM");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_GET_USER_ID_FOR_FARM", parameters);
            }
            parameters[0].Value = farmId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_USER_ID_FOR_FARM"),
                parameters))
            {
                if (reader.Read())
                    userId = reader.GetInt32(0);
            }

            return userId;
        }

        /// <summary>
        /// Gets the User Id For Plot
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>User Id</returns>
        public int GetUserIdForPlot(int plotId)
        {
            int userId = 0;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_USER_ID_FOR_PLOT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_GET_USER_ID_FOR_PLOT", parameters);
            }
            parameters[0].Value = plotId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_USER_ID_FOR_PLOT"),
                parameters))
            {
                if (reader.Read())
                    userId = reader.GetInt32(0);
            }

            return userId;
        }

        /// <summary>
        /// Get Plot Detail for a Given Plot Id
        /// </summary>
        /// <param name="PlotId">Plot ID</param>
        /// <returns>PlotInfo Model object as Plot Details</returns>
        public PlotInfo GetPlotDetail(int plotId)
        {
            PlotInfo plot = new PlotInfo();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_PLOT_SUMMARY_DETAIL");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_GET_PLOT_SUMMARY_DETAIL", parameters);
            }
            parameters[0].Value = plotId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_PLOT_SUMMARY_DETAIL"),
                parameters))
            {
                if (reader.Read())
                {
                    List<ContactInfo> contacts = new List<ContactInfo>();
                    contacts = GetContactListForPlot(plotId);
                    plot = new PlotInfo(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4),contacts);
                }
            }

            return plot;
        }

        /// <summary>
        /// Checks the farm duplication
        /// </summary>
        /// <param name="FarmName">Farm Name</param>
        /// <returns>Boolean</returns>
        public bool IsFarmExists(string farmName)
        {
            bool isFarmExists = false;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_IS_FARM_EXISTS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@farmName", SqlDbType.NVarChar,100)
                };

                SQLHelper.CacheParameters("SQL_IS_FARM_EXISTS", parameters);
            }

            parameters[0].Value = farmName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_IS_FARM_EXISTS"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                        isFarmExists = true;
                }
            }

            return isFarmExists;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the farm exists for an User.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="farmName">Farm NAme</param>
        /// <returns>Returns a boolean value indicating whether the farm exists for an user</returns>
        public bool IsFarmExistsForUser(int userId, string farmName)
        {
            bool isFarmExists = false;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_IS_FARM_EXISTS_FOR_USER");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId",SqlDbType.Int),
                    new SqlParameter("@farmName", SqlDbType.NVarChar,100)
                };

                SQLHelper.CacheParameters("SQL_IS_FARM_EXISTS_FOR_USER", parameters);
            }

            parameters[0].Value = userId;
            parameters[1].Value = farmName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_IS_FARM_EXISTS_FOR_USER"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                        isFarmExists = true;
                }
            }

            return isFarmExists;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the farm exists for an User For Update.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="farmId">Farm Id</param>
        /// <param name="farmName">Farm Name</param>
        /// <returns>Returns a boolean value indicating whether the farm exists for an user</returns>
        public bool IsFarmExistsForUserOnUpdate(int userId, int farmId, string farmName)
        {
            bool isFarmExists = false;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_IS_FARM_EXISTS_FOR_USER_ON_UPDATE");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId",SqlDbType.Int),
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@farmName", SqlDbType.NVarChar,100)
                };

                SQLHelper.CacheParameters("SQL_IS_FARM_EXISTS_FOR_USER_ON_UPDATE", parameters);
            }

            parameters[0].Value = userId;
            parameters[1].Value = farmId;
            parameters[2].Value = farmName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_IS_FARM_EXISTS_FOR_USER_ON_UPDATE"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                        isFarmExists = true;
                }
            }

            return isFarmExists;
        }

        /// <summary>
        /// Checks the plot duplication
        /// </summary>
        /// <param name="plotName">plot Name</param>
        /// <returns>Boolean</returns>
        public bool IsPlotExists(string plotName)
        {
            bool isPlotExists = false;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_IS_PLOT_EXISTS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@plotName", SqlDbType.NVarChar,100)
                };

                SQLHelper.CacheParameters("SQL_IS_PLOT_EXISTS", parameters);
            }

            parameters[0].Value = plotName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_IS_PLOT_EXISTS"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                        isPlotExists = true;
                }
            }

            return isPlotExists;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the Plot exists with in the Farm.
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="plotName">Plot Name</param>
        /// <returns>Returns a boolean value indicating whether the Plot exists with in the Farm</returns>
        public bool IsPlotExistsForFarm(int farmId, string plotName)
        {
            bool isPlotExists = false;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_IS_PLOT_EXISTS_FOR_FARM");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@plotName", SqlDbType.NVarChar,100)
                };

                SQLHelper.CacheParameters("SQL_IS_PLOT_EXISTS_FOR_FARM", parameters);
            }

            parameters[0].Value = farmId;
            parameters[1].Value = plotName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_IS_PLOT_EXISTS_FOR_FARM"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                        isPlotExists = true;
                }
            }

            return isPlotExists;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the Plot exists with in the Farm on Update.
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="plotId">Plot Id</param>
        /// <param name="plotName">Plot Name</param>
        /// <returns>Returns a boolean value indicating whether the Plot exists with in the Farm</returns>
        public bool IsPlotExistsForFarmOnUpdate(int farmId, int plotId, string plotName)
        {
            bool isPlotExists = false;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_IS_PLOT_EXISTS_FOR_FARM_ON_UPDATE");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@PlotId",SqlDbType.Int),
                    new SqlParameter("@plotName", SqlDbType.NVarChar,100)
                };

                SQLHelper.CacheParameters("SQL_IS_PLOT_EXISTS_FOR_FARM_ON_UPDATE", parameters);
            }

            parameters[0].Value = farmId;
            parameters[1].Value = plotId;
            parameters[2].Value = plotName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_IS_PLOT_EXISTS_FOR_FARM_ON_UPDATE"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                        isPlotExists = true;
                }
            }

            return isPlotExists;
        }


        /// <summary>
        /// List of contacts in a Plot
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>Array of ContactInfo Model object as Contact List</returns>
        public List<ContactInfo> GetContactListForPlot(int plotId)
        {
            List<ContactInfo> contacts = new List<ContactInfo>();
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_CONTACT_LIST_FOR_PLOT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_CONTACT_LIST_FOR_PLOT", parameters);
            }
            parameters[0].Value = plotId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_CONTACT_LIST_FOR_PLOT"),
                parameters))
            {
                while (reader.Read())
                {
                    //For Float Safe operation for [Acres] field
                    float floatAcres = 0;
                    float.TryParse(reader.GetValue(12).ToString(), out floatAcres);

                    ContactInfo contact = new ContactInfo(reader.GetInt64(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                        reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11),
                        floatAcres, reader.GetString(13), reader.GetString(14), reader.GetString(15),
                        reader.GetString(16), reader.GetString(17), reader.GetString(18), reader.GetString(19),
                        reader.GetString(20), reader.GetString(21), reader.GetDateTime(22), reader.GetDecimal(23),
                        reader.GetDateTime(24), reader.GetDateTime(25), reader.GetInt32(26), reader.GetInt32(27));
                    
                    /*ContactInfo contact = new ContactInfo();
                    contact.ContactId = reader.GetInt64(0);
                    contact.ScheduleNumber = reader.GetInt32(1);
                    contact.OwnerFullName = reader.GetString(2);
                    contact.Lot = reader.GetInt32(3);
                    contact.Block = reader.GetString(4);
                    contact.Subdivision = reader.GetString(5);
                    contact.Filing = reader.GetString(6);
                    contact.SiteAddress = reader.GetString(7);
                    contact.Bedrooms = reader.GetInt32(8);
                    contact.FullBath = reader.GetInt32(9);
                    contact.ThreeQuarterBath = reader.GetInt32(10);
                    contact.HalfBath = reader.GetInt32(11);
                    float temp = 0;
                    float.TryParse(reader.GetValue(12).ToString(),out temp);
                    contact.Acres = temp;
                    contact.ActMktComb = reader.GetString(13);
                    contact.OwnerFirstName = reader.GetString(14);
                    contact.OwnerLastName = reader.GetString(15);
                    contact.OwnerAddress1 = reader.GetString(16);
                    contact.OwnerAddress2 = reader.GetString(17);
                    contact.OwnerCity = reader.GetString(18);
                    contact.OwnerState = reader.GetString(19);
                    contact.OwnerZip = reader.GetString(20);
                    contact.OwnerCountry = reader.GetString(21);
                    contact.SaleDate = reader.GetDateTime(22);
                    contact.TransAmount = reader.GetDecimal(23);
                    contact.CreateDate = reader.GetDateTime(24);
                    contact.LastModifyDate = reader.GetDateTime(25);
                    contact.LastModifyBy = reader.GetInt32(26);
                    contact.PlotId = reader.GetInt32(27); */
                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        /// <summary>
        /// Gets the Contact Details for Contact Id
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>ContactInfo Model Object as Contact Details </returns>
        public ContactInfo GetContactDetails(Int64 contactId)
        {
            ContactInfo contact = new ContactInfo();
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_CONTACT_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@ContactId", SqlDbType.BigInt)
                };

                SQLHelper.CacheParameters("SQL_GET_CONTACT_DETAILS", parameters);
            }
            parameters[0].Value = contactId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_CONTACT_DETAILS"),
                parameters))
            {
                if (reader.Read())
                {
                    float floatAcres = 0;
                    float.TryParse(reader.GetValue(12).ToString(), out floatAcres);
                    contact = new ContactInfo(reader.GetInt64(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                        reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11),
                        floatAcres, reader.GetString(13), reader.GetString(14), reader.GetString(15),
                        reader.GetString(16), reader.GetString(17), reader.GetString(18), reader.GetString(19),
                        reader.GetString(20), reader.GetString(21), reader.GetDateTime(22), reader.GetDecimal(23),
                        reader.GetDateTime(24), reader.GetDateTime(25), reader.GetInt32(26), reader.GetInt32(27));
                }
            }
            return contact;
        }

        /// <summary>
        /// Update Contact Details
        /// </summary>
        /// <param name="contact">ContactInfo Model object as contact details</param>
        public void UpdateContactDetails(ContactInfo contact)
        {
            // Get the farm & plot details.
            string farmName = GetFarmNameOfPlot(contact.PlotId);
            PlotInfo plotInfo = GetPlotDetail(contact.PlotId);
            int userId = GetUserIdForPlot(contact.PlotId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_UPDATE_CONTACT_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                    new SqlParameter("@ScheduleNumber",SqlDbType.Int),
                    new SqlParameter("@OwnerFullName",SqlDbType.Text,100),
                    new SqlParameter("@Lot",SqlDbType.Int),
                    new SqlParameter("@Block",SqlDbType.Text,10),
                    new SqlParameter("@SubDivision",SqlDbType.Text,100),
                    new SqlParameter("@Filing",SqlDbType.Text,50),
                    new SqlParameter("@SiteAddress",SqlDbType.Text,255),
                    new SqlParameter("@Bedrooms",SqlDbType.Int),
                    new SqlParameter("@FullBath",SqlDbType.Int),
                    new SqlParameter("@ThreeQuaterBath",SqlDbType.Int),
                    new SqlParameter("@HalfBath",SqlDbType.Int),
                    new SqlParameter("@Acres",SqlDbType.Float),
                    new SqlParameter("@ActMktComb",SqlDbType.Text,50),
                    new SqlParameter("@OwnerFirstName",SqlDbType.Text,50),
                    new SqlParameter("@OwnerLastName",SqlDbType.Text,50),
                    new SqlParameter("@OwnerAddress1",SqlDbType.Text,255),
                    new SqlParameter("@OwnerAddress2",SqlDbType.Text,255),
                    new SqlParameter("@OwnerCity",SqlDbType.Text,50),
                    new SqlParameter("@OwnerState",SqlDbType.Text,50),
                    new SqlParameter("@OwnerZip",SqlDbType.Text,15),
                    new SqlParameter("@OwnerCountry",SqlDbType.Text,50),
                    new SqlParameter("@SaleDate",SqlDbType.DateTime),
                    new SqlParameter("@TransAmount",SqlDbType.Decimal),
                    new SqlParameter("@LastModifiedBy",SqlDbType.Int),
                    new SqlParameter("@PlotId",SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_UPDATE_CONTACT_DETAILS", parameters);
            }
            parameters[0].Value = contact.ContactId;
            parameters[1].Value = contact.ScheduleNumber;
            parameters[2].Value = contact.OwnerFullName;
            parameters[3].Value = contact.Lot;
            parameters[4].Value = contact.Block;
            parameters[5].Value = contact.Subdivision;
            parameters[6].Value = contact.Filing;
            parameters[7].Value = contact.SiteAddress;
            parameters[8].Value = contact.Bedrooms;
            parameters[9].Value = contact.FullBath;
            parameters[10].Value = contact.ThreeQuarterBath;
            parameters[11].Value = contact.HalfBath;
            parameters[12].Value = contact.Acres;
            parameters[13].Value = contact.ActMktComb;
            parameters[14].Value = contact.OwnerFirstName;
            parameters[15].Value = contact.OwnerLastName;
            parameters[16].Value = contact.OwnerAddress1;
            parameters[17].Value = contact.OwnerAddress2;
            parameters[18].Value = contact.OwnerCity;
            parameters[19].Value = contact.OwnerState;
            parameters[20].Value = contact.OwnerZip;
            parameters[21].Value = contact.OwnerCountry;
            parameters[22].Value = contact.SaleDate;
            parameters[23].Value = contact.TransAmount;
            parameters[24].Value = contact.LastModifyBy;
            parameters[25].Value = contact.PlotId;

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_CONTACT_DETAILS"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement,
                            farmName + "/" + plotInfo.PlotName + "/" + contact.ScheduleNumber.ToString(),
                            "Modified contact", userId, contact.LastModifyBy);
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
        /// Add a New Contact
        /// </summary>
        /// <param name="contact">ContactInfo Model Object as contact Details</param>
        public void AddContact(ContactInfo contact)
        {
            // Get the farm & plot details.
            string farmName = GetFarmNameOfPlot(contact.PlotId);
            PlotInfo plotInfo = GetPlotDetail(contact.PlotId);
            int userId = GetUserIdForPlot(contact.PlotId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_INSERT_CONTACT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                    new SqlParameter("@ScheduleNumber",SqlDbType.Int),
                    new SqlParameter("@OwnerFullName",SqlDbType.Text,100),
                    new SqlParameter("@Lot",SqlDbType.Int),
                    new SqlParameter("@Block",SqlDbType.Text,10),
                    new SqlParameter("@SubDivision",SqlDbType.Text,100),
                    new SqlParameter("@Filing",SqlDbType.Text,50),
                    new SqlParameter("@SiteAddress",SqlDbType.Text,255),
                    new SqlParameter("@Bedrooms",SqlDbType.Int),
                    new SqlParameter("@FullBath",SqlDbType.Int),
                    new SqlParameter("@ThreeQuaterBath",SqlDbType.Int),
                    new SqlParameter("@HalfBath",SqlDbType.Int),
                    new SqlParameter("@Acres",SqlDbType.Float),
                    new SqlParameter("@ActMktComb",SqlDbType.Text,50),
                    new SqlParameter("@OwnerFirstName",SqlDbType.Text,50),
                    new SqlParameter("@OwnerLastName",SqlDbType.Text,50),
                    new SqlParameter("@OwnerAddress1",SqlDbType.Text,255),
                    new SqlParameter("@OwnerAddress2",SqlDbType.Text,255),
                    new SqlParameter("@OwnerCity",SqlDbType.Text,50),
                    new SqlParameter("@OwnerState",SqlDbType.Text,50),
                    new SqlParameter("@OwnerZip",SqlDbType.Text,15),
                    new SqlParameter("@OwnerCountry",SqlDbType.Text,50),
                    new SqlParameter("@SaleDate",SqlDbType.DateTime),
                    new SqlParameter("@TransAmount",SqlDbType.Decimal),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int),
                    new SqlParameter("@PlotId",SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_INSERT_CONTACT", parameters);
            }
            parameters[0].Value = contact.ContactId;
            parameters[1].Value = contact.ScheduleNumber;
            parameters[2].Value = contact.OwnerFullName;
            parameters[3].Value = contact.Lot;
            parameters[4].Value = contact.Block;
            parameters[5].Value = contact.Subdivision;
            parameters[6].Value = contact.Filing;
            parameters[7].Value = contact.SiteAddress;
            parameters[8].Value = contact.Bedrooms;
            parameters[9].Value = contact.FullBath;
            parameters[10].Value = contact.ThreeQuarterBath;
            parameters[11].Value = contact.HalfBath;
            parameters[12].Value = contact.Acres;
            parameters[13].Value = contact.ActMktComb;
            parameters[14].Value = contact.OwnerFirstName;
            parameters[15].Value = contact.OwnerLastName;
            parameters[16].Value = contact.OwnerAddress1;
            parameters[17].Value = contact.OwnerAddress2;
            parameters[18].Value = contact.OwnerCity;
            parameters[19].Value = contact.OwnerState;
            parameters[20].Value = contact.OwnerZip;
            parameters[21].Value = contact.OwnerCountry;
            parameters[22].Value = contact.SaleDate;
            parameters[23].Value = contact.TransAmount;
            parameters[24].Value = contact.LastModifyBy;
            parameters[25].Value = contact.PlotId;

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_CONTACT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement,
                            farmName + "/" + plotInfo.PlotName + "/" + contact.ScheduleNumber.ToString(),
                            "Added contact", userId, contact.LastModifyBy);
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
        /// Delete a contact
        /// </summary>
        /// <param name="contactId">Contact ID to Identify the Contact to be deleted</param>
        /// <param name="lastModifyBy">Last Modify By User ID</param>
        public void DeleteContact(Int64 contactId,int lastModifyBy)
        {
            // Get the farm & plot details.
            ContactInfo contactInfo = GetContactDetails(contactId);
            string farmName = GetFarmNameOfPlot(contactInfo.PlotId);
            PlotInfo plotInfo = GetPlotDetail(contactInfo.PlotId);
            int userId = GetUserIdForPlot(contactInfo.PlotId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_DELETE_CONTACT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_DELETE_CONTACT", parameters);
            }
            parameters[0].Value = contactId;
            parameters[1].Value = lastModifyBy;

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
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_DELETE_CONTACT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement,
                            farmName + "/" + plotInfo.PlotName + "/" + contactInfo.ScheduleNumber.ToString(),
                            "Deleted contact", userId, lastModifyBy);
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
        /// Restore a contact
        /// </summary>
        /// <param name="contactId">Contact ID to Identify the Contact to be Restore</param>
        /// <param name="lastModifyBy">Last Modify By User ID</param>
        public void RestoreContact(Int64 contactId, int lastModifyBy)
        {
            // Get the farm & plot details.
            ContactInfo contactInfo = GetContactDetails(contactId);
            string farmName = GetFarmNameOfPlot(contactInfo.PlotId);
            PlotInfo plotInfo = GetPlotDetail(contactInfo.PlotId);
            int userId = GetUserIdForPlot(contactInfo.PlotId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_RESTORE_CONTACT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_RESTORE_CONTACT", parameters);
            }
            parameters[0].Value = contactId;
            parameters[1].Value = lastModifyBy;

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
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_RESTORE_CONTACT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement,
                            farmName + "/" + plotInfo.PlotName + "/" + contactInfo.ScheduleNumber.ToString(),
                            "Restored contact", userId, lastModifyBy);
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
        /// Move a Contact to a desired Plot. 
        /// </summary>
        /// <param name="contactId">Contact Id on which the operation will happen</param>
        /// <param name="plotId">Plot Id is the ID of the plot to which it will be moved</param>
        /// <param name="newPlotName">New Plot Name</param>
        /// <param name="modifiedBy">It is the User Id who has made this changes</param>
        public void MoveContactToPlot(Int64 contactId, int plotId, string newPlotName, int modifiedBy)
        {
            // Get the farm & plot details.
            ContactInfo contactInfo = GetContactDetails(contactId);
            string farmName = GetFarmNameOfPlot(plotId);
            PlotInfo plotInfo = GetPlotDetail(plotId);
            int userId = GetUserIdForPlot(plotId);

            // For Move Plot
            SqlParameter[] parameterMove = SQLHelper.GetCachedParameters("SQL_MOVE_CONTACT_TO_PLOT");
            if (parameterMove == null)
            {
                parameterMove = new SqlParameter[] {
                    new SqlParameter("@ContactId",SqlDbType.BigInt),
                    new SqlParameter("@PlotId",SqlDbType.Int),
                    new SqlParameter("@NewPlotName",SqlDbType.VarChar,100),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_MOVE_CONTACT_TO_PLOT", parameterMove);
            }
            parameterMove[0].Value = contactId;
            parameterMove[1].Value = plotId;
            parameterMove[2].Value = newPlotName;
            parameterMove[3].Value = modifiedBy;

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
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_MOVE_CONTACT_TO_PLOT"),
                            parameterMove);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement,
                            farmName + "/" + plotInfo.PlotName + "/" + contactInfo.ScheduleNumber.ToString(),
                            "Moved contact to plot", userId, modifiedBy);
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
        /// Gets the Count of Duplicate Farm Name While Editing.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="farmId">Farm Id</param>
        /// <param name="farmName">Farm Name</param>
        /// <returns>Count of Duplicate Farm</returns>
        public int GetCountOfDuplicateFarmNameForEdit(int userId, int farmId, string farmName)
        {
            //GET_COUNT_OF_DUPLICATE_FARM_NAME_FOR_EDIT
            int count = 0;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("GET_COUNT_OF_DUPLICATE_FARM_NAME_FOR_EDIT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId",SqlDbType.Int),
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@FarmName",SqlDbType.NVarChar,100)
                };
                SQLHelper.CacheParameters("GET_COUNT_OF_DUPLICATE_FARM_NAME_FOR_EDIT", parameters);
            }
            parameters[0].Value = userId;
            parameters[1].Value = farmId;
            parameters[2].Value = farmName;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "GET_COUNT_OF_DUPLICATE_FARM_NAME_FOR_EDIT"),
                parameters))
            {
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }

            return count;
        }

        /// <summary>
        /// Gets the Count of Duplicate Plot Names While Editing
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="plotId">Plot Id</param>
        /// <param name="plotName">Plot Name</param>
        /// <returns>Count of Duplicate Plots</returns>
        public int GetCountOfDuplicatePlotNameForEdit(int farmId, int plotId, string plotName)
        {
            int count = 0;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("GET_COUNT_OF_DUPLICATE_PLOT_NAME_FOR_EDIT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@PlotId",SqlDbType.Int),
                    new SqlParameter("@PlotName",SqlDbType.NVarChar,100)
                };
                SQLHelper.CacheParameters("GET_COUNT_OF_DUPLICATE_PLOT_NAME_FOR_EDIT", parameters);
            }
            parameters[0].Value = farmId;
            parameters[1].Value = plotId;
            parameters[2].Value = plotName;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "GET_COUNT_OF_DUPLICATE_PLOT_NAME_FOR_EDIT"),
                parameters))
            {
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }

            return count;
        }

        /// <summary>
        /// To delete Farm and related Plots and Contacts
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="lastModifyBy">LastModifyBy User Id</param>
        public void DeleteFarmPlot(int farmId, int lastModifyBy)
        {
            // Get the farm details.
            FarmInfo farmInfo = GetFarmDetail(farmId);
            int userId = GetUserIdForFarm(farmId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_DELETE_FARM_PLOT_CONTACT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_DELETE_FARM_PLOT_CONTACT", parameters);
            }
            parameters[0].Value = farmId;
            parameters[1].Value = lastModifyBy;

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
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_DELETE_FARM_PLOT_CONTACT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmInfo.FarmName,
                            "Deleted farm", userId, lastModifyBy);
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
        /// To Restore Farm and related Plots and Contacts
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="lastModifyBy">Last Modified by User Id</param>
        public void RestoreFarmPlot(int farmId, int lastModifyBy)
        {
            // Get the farm details.
            FarmInfo farmInfo = GetFarmDetail(farmId);
            int userId = GetUserIdForFarm(farmId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_RESTORE_FARM_PLOT_CONTACT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@FarmId",SqlDbType.Int),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_RESTORE_FARM_PLOT_CONTACT", parameters);
            }
            parameters[0].Value = farmId;
            parameters[1].Value = lastModifyBy;

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
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_RESTORE_FARM_PLOT_CONTACT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmInfo.FarmName,
                            "Restored farm", userId, lastModifyBy);
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
        /// Delete Plot and its Contacts and if Farm is Empty it Deletes the Farm too.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <param name="lastModifyBy">LastModifyBy User Id</param>
        public void DeletePlotContact(int plotId, int lastModifyBy)
        {
            // Get the farm & plot details.
            string farmName = GetFarmNameOfPlot(plotId);
            PlotInfo plotInfo = GetPlotDetail(plotId);
            int userId = GetUserIdForPlot(plotId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_DELETE_PLOT_CONTACT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId",SqlDbType.Int),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_DELETE_PLOT_CONTACT", parameters);
            }
            parameters[0].Value = plotId;
            parameters[1].Value = lastModifyBy;

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
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_DELETE_PLOT_CONTACT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmName + "/" + plotInfo.PlotName,
                            "Deleted plot", userId, lastModifyBy);
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
        /// Restore Plot and its Contacts.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <param name="lastModifyBy">Last Modify By User Id</param>
        public void RestorePlotContact(int plotId, int lastModifyBy)
        {
            // Get the farm & plot details.
            string farmName = GetFarmNameOfPlot(plotId);
            PlotInfo plotInfo = GetPlotDetail(plotId);
            int userId = GetUserIdForPlot(plotId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_RESTORE_PLOT_CONTACT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId",SqlDbType.Int),
                    new SqlParameter("@LastModifyBy",SqlDbType.Int)
                };
                SQLHelper.CacheParameters("SQL_RESTORE_PLOT_CONTACT", parameters);
            }
            parameters[0].Value = plotId;
            parameters[1].Value = lastModifyBy;

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
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_RESTORE_PLOT_CONTACT"),
                            parameters);

                        // Write entry into audit trail.
                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.FarmManagement, farmName + "/" + plotInfo.PlotName,
                            "Restored plot", userId, lastModifyBy);
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
        /// To Check weather a Given Plot is Delault Plot or Not
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>Boolean True if it is a default Plot else False</returns>
        public bool IsDefaultPlot(int plotId)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_CHECK_DEFAULT_PLOT");
            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PlotId",SqlDbType.Int)};
                SQLHelper.CacheParameters("SQL_CHECK_DEFAULT_PLOT", parameters);
            }
            parameters[0].Value = plotId;
            int count = 0;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_CHECK_DEFAULT_PLOT"),
                parameters))
            {
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }

            if (count == 0)
                return false;
            else
                return true;
        }


        /// <summary>
        /// Total Count of Active Farms
        /// </summary>
        /// <returns>Count of Active Farms</returns>
        public int TotalActiveFarmCount()
        {
            int totalActiveFarmCount = 0;
            // Execute a query to read the Active Farm Count.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_TOTAL_ACTIVE_FARMS"),
                null))
            {
                while (reader.Read())
                {
                    totalActiveFarmCount = reader.GetInt32(0);
                }
            }
            return totalActiveFarmCount;
        }

        /// <summary>
        /// Total Count of Archived Farms
        /// </summary>
        /// <returns>Count of Archived Farms</returns>
        public int TotalArchivedFarmCount()
        {
            int totalArchivedFarmCount = 0;
            // Execute a query to read the Archived Farm Count.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_TOTAL_ARCHIVED_FARMS"),
                null))
            {
                while (reader.Read())
                {
                    totalArchivedFarmCount = reader.GetInt32(0);
                }
            }
            return totalArchivedFarmCount;
        }

        /// <summary>
        /// Total Count of Active Plots
        /// </summary>
        /// <returns>Count of Active Plots</returns>
        public int TotalActivePlotCount()
        {
            int totalActivePlotCount = 0;
            // Execute a query to read the Active Plot Count.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_TOTAL_ACTIVE_PLOTS"),
                null))
            {
                while (reader.Read())
                {
                    totalActivePlotCount = reader.GetInt32(0);
                }
            }
            return totalActivePlotCount;
        }

        /// <summary>
        /// Total Count of Archived Plots
        /// </summary>
        /// <returns>Count of Archived Plots</returns>
        public int TotalArchivedPlotCount()
        {
            int totalArchivedPlotCount = 0;
            // Execute a query to read the Archived Plot Count.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_TOTAL_ARCHIVED_PLOTS"),
                null))
            {
                while (reader.Read())
                {
                    totalArchivedPlotCount = reader.GetInt32(0);
                }
            }
            return totalArchivedPlotCount;
        }

        /// <summary>
        /// Total Count of Active Contact
        /// </summary>
        /// <returns>Count of Active Contacts</returns>
        public Int64 TotalActiveContactCount()
        {
            Int64 totalActiveContactCount = 0;
            // Execute a query to read the Active Contact Count.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_TOTAL_ACTIVE_CONTACTS"),
                null))
            {
                while (reader.Read())
                {
                    totalActiveContactCount = Int64.Parse(reader.GetValue(0).ToString());
                }
            }
            return totalActiveContactCount;
        }

        /// <summary>
        /// Total Count of Archived Contact
        /// </summary>
        /// <returns>Count of Archived Contacts</returns>
        public Int64 TotalArchivedContactCount()
        {
            Int64 totalArchivedContactCount = 0;
            // Execute a query to read the Archived Contact Count.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_TOTAL_ARCHIVED_CONTACTS"),
                null))
            {
                while (reader.Read())
                {
                    totalArchivedContactCount = Int64.Parse(reader.GetValue(0).ToString());
                }
            }
            return totalArchivedContactCount;
        }

        /// <summary>
        /// Datatable for Farm Plot Contact Report
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Model object of FarmDetailsReportInfo as Farm Plot Contact Report</returns>
        public List<FarmDetailsReportInfo> ReportForFarmDetails(int userId)
        {
            List<FarmDetailsReportInfo> fdrs = new List<FarmDetailsReportInfo>();
            
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_DETAIL_FARM_REPORT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_DETAIL_FARM_REPORT", parameters);
            }

            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_DETAIL_FARM_REPORT"),
                parameters))
            {
                while (reader.Read())
                {
                    float floatAcres = 0;
                    float.TryParse(reader.GetValue(16).ToString(), out floatAcres);
                    FarmDetailsReportInfo fdr = new FarmDetailsReportInfo();
                    fdr.FarmId = reader.GetInt32(0); 
                    fdr.FarmName = reader.GetString(1); 
                    fdr.PlotId = reader.GetInt32(2); 
                    fdr.PlotName = reader.GetString(3);
                    fdr.ContactId = reader.GetInt64(4); 
                    fdr.ScheduleNumber = reader.GetInt32(5);
                    fdr.OwnerFullName = reader.GetString(6); 
                    fdr.Lot = reader.GetInt32(7);
                    fdr.Block = reader.GetString(8); 
                    fdr.Subdivision = reader.GetString(9); 
                    fdr.Filing = reader.GetString(10); 
                    fdr.SiteAddress = reader.GetString(11);
                    fdr.Bedrooms = reader.GetInt32(12); 
                    fdr.FullBath = reader.GetInt32(13); 
                    fdr.ThreeQuarterBath = reader.GetInt32(14); 
                    fdr.HalfBath = reader.GetInt32(15);
                    fdr.Acres = floatAcres; 
                    fdr.ActMktComb = reader.GetString(17); 
                    fdr.OwnerFirstName = reader.GetString(18); 
                    fdr.OwnerLastName = reader.GetString(19);
                    fdr.OwnerAddress1 = reader.GetString(20); 
                    fdr.OwnerAddress2 = reader.GetString(21); 
                    fdr.OwnerCity = reader.GetString(22); 
                    fdr.OwnerState = reader.GetString(23);
                    fdr.OwnerZip = reader.GetString(24); 
                    fdr.OwnerCountry = reader.GetString(25); 
                    fdr.SaleDate = reader.GetDateTime(26); 
                    fdr.TransAmount = reader.GetDecimal(27);
                    fdr.CreateDate = reader.GetDateTime(28); 
                    fdr.LastModifyDate = reader.GetDateTime(29); 
                    fdr.LastModifyBy = reader.GetInt32(30); 
                    fdr.Deleted = reader.GetBoolean(31);

                    /*
                    FarmDetailsReportInfo fdr = new FarmDetailsReportInfo(reader.GetInt32(0), reader.GetString(1), 
                        reader.GetInt32(2), reader.GetString(3),reader.GetInt64(4), reader.GetInt32(5),
                        reader.GetString(6), reader.GetInt32(7), reader.GetString(8),reader.GetString(9),
                        reader.GetString(10), reader.GetString(11), reader.GetInt32(12), reader.GetInt32(13),
                        reader.GetInt32(14), reader.GetInt32(15), floatAcres, reader.GetString(17),
                        reader.GetString(18), reader.GetString(19), reader.GetString(20), reader.GetString(21),
                        reader.GetString(22), reader.GetString(23), reader.GetString(24), reader.GetString(25),
                        reader.GetDateTime(26), reader.GetDecimal(27), reader.GetDateTime(28),reader.GetDateTime(29),
                        reader.GetInt32(30), reader.GetBoolean(31));
                    */
                    fdrs.Add(fdr);
                }
            }

            return fdrs;
        }

        
        /// <summary>
        /// Gets the List of contacts from the Search ceriteria 
        /// </summary>
        /// <param name="where">String where SQL WHERE clause is configured</param>
        /// <returns>Model object of FarmDetailsReportInfo</returns>
        public List<FarmDetailsReportInfo> GetSearchFarmData(string where)
        {
            List<FarmDetailsReportInfo> fdrs = new List<FarmDetailsReportInfo>();
            string sqlQuery = SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_SEARCH_FARM_DATA");

            sqlQuery = sqlQuery + " " + where;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, sqlQuery, null))
            {
                while (reader.Read())
                {
                    float floatAcres = 0;
                    float.TryParse(reader.GetValue(16).ToString(), out floatAcres);
                    FarmDetailsReportInfo fdr = new FarmDetailsReportInfo();
                    fdr.FarmId = reader.GetInt32(0);
                    fdr.FarmName = reader.GetString(1);
                    fdr.PlotId = reader.GetInt32(2);
                    fdr.PlotName = reader.GetString(3);
                    fdr.ContactId = reader.GetInt64(4);
                    fdr.ScheduleNumber = reader.GetInt32(5);
                    fdr.OwnerFullName = reader.GetString(6);
                    fdr.Lot = reader.GetInt32(7);
                    fdr.Block = reader.GetString(8);
                    fdr.Subdivision = reader.GetString(9);
                    fdr.Filing = reader.GetString(10);
                    fdr.SiteAddress = reader.GetString(11);
                    fdr.Bedrooms = reader.GetInt32(12);
                    fdr.FullBath = reader.GetInt32(13);
                    fdr.ThreeQuarterBath = reader.GetInt32(14);
                    fdr.HalfBath = reader.GetInt32(15);
                    fdr.Acres = floatAcres;
                    fdr.ActMktComb = reader.GetString(17);
                    fdr.OwnerFirstName = reader.GetString(18);
                    fdr.OwnerLastName = reader.GetString(19);
                    fdr.OwnerAddress1 = reader.GetString(20);
                    fdr.OwnerAddress2 = reader.GetString(21);
                    fdr.OwnerCity = reader.GetString(22);
                    fdr.OwnerState = reader.GetString(23);
                    fdr.OwnerZip = reader.GetString(24);
                    fdr.OwnerCountry = reader.GetString(25);
                    fdr.SaleDate = reader.GetDateTime(26);
                    fdr.TransAmount = reader.GetDecimal(27);
                    fdr.CreateDate = reader.GetDateTime(28);
                    fdr.LastModifyDate = reader.GetDateTime(29);
                    fdr.LastModifyBy = reader.GetInt32(30);
                    fdr.Deleted = reader.GetBoolean(31);

                    fdrs.Add(fdr);
                }
            }
            return fdrs;
        }

        /// <summary>
        /// Gets the mailing labels for the specified parameters.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <returns>Mailing labels for the specified parameters.</returns>
        public List<MailingLabelInfo> GetMailingLabels(int userId, int farmId, int plotId)
        {
            List<MailingLabelInfo> mailingLabels = new List<MailingLabelInfo>();

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_MAILING_LABELS_REPORT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int),
                    new SqlParameter("@farm_id", SqlDbType.Int),
                    new SqlParameter("@plot_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_MAILING_LABELS_REPORT", parameters);
            }

            parameters[0].Value = userId;
            parameters[1].Value = farmId;
            parameters[2].Value = plotId;
            
            // Execute the query to read the mailing labels.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_MAILING_LABELS_REPORT"),
                parameters))
            {
                int index = 1;

                while (reader.Read())
                {
                    string labelText = string.Empty;

                    labelText = reader.GetString(2) + " " + reader.GetString(3) +
                        "<br />" + reader.GetString(4) +
                        (reader.GetString(5) == "" ? "" : "<br />" + reader.GetString(5)) +
                        "<br />" + reader.GetString(6) + ", " + reader.GetString(7) +
                        "<br />" + reader.GetString(8) + " - " + reader.GetString(9);

                    if (index == 1)
                    {
                        MailingLabelInfo label = new MailingLabelInfo();

                        label.FarmName = reader.GetString(0);
                        label.PlotName = reader.GetString(1);
                        label.MailingLabel_1 = labelText;

                        mailingLabels.Add(label);
                        index++;
                    }
                    else if (index == 2)
                    {
                        mailingLabels[mailingLabels.Count - 1].MailingLabel_2 = labelText;
                        index++;
                    }
                    else
                    {
                        mailingLabels[mailingLabels.Count - 1].MailingLabel_3 = labelText;
                        index = 1;
                    }
                }
            }

            return mailingLabels;
        }

        /// <summary>
        ///     Get the Summary List of Firmed Up Farms
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="FirmUpStatus">Firm Up Status</param>
        /// <returns>List of FirmUpStatusReportInfo Model Object </returns>
        public List<FirmUpStatusReportInfo> GetFirmUpStatusSummaryDetails(int userId, bool FirmUpStatus)
        {
            List<FirmUpStatusReportInfo> firmUpStatusReportInfos = new List<FirmUpStatusReportInfo>();
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_FIRM_UP_STATUS_REPORT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int),
                    new SqlParameter("@FirmUpStatus", SqlDbType.Bit)
                };

                SQLHelper.CacheParameters("SP_FIRM_UP_STATUS_REPORT", parameters);
            }
            parameters[0].Value = userId;
            parameters[1].Value = FirmUpStatus;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_FIRM_UP_STATUS_REPORT"),
                parameters))
            {
                while (reader.Read())
                {
                    FirmUpStatusReportInfo firmUpStatusReportInfo = new FirmUpStatusReportInfo();
                    firmUpStatusReportInfo.AgentId = reader.GetInt32(0);
                    firmUpStatusReportInfo.AgentFullName = reader.GetString(1);
                    firmUpStatusReportInfo.AgentPhone = reader.GetString(2);
                    firmUpStatusReportInfo.FarmId = reader.GetInt32(3);
                    firmUpStatusReportInfo.FarmName = reader.GetString(4);
                    firmUpStatusReportInfo.FarmCreatedDate = reader.GetDateTime(5);
                    firmUpStatusReportInfo.PlotCount = reader.GetInt32(6);
                    firmUpStatusReportInfo.ContactCount = reader.GetInt32(7);
                    firmUpStatusReportInfo.DeletedContactCount = reader.GetInt32(8);
                    firmUpStatusReportInfo.FirmUpStatus = reader.GetBoolean(9);
                    firmUpStatusReportInfos.Add(firmUpStatusReportInfo);
                }
            }

            return firmUpStatusReportInfos;
        }


        /// <summary>
        ///     Getting Farm Data Report Data which is Agent wise Farm Summary
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="where">SQL Where Condition</param>
        /// <returns>FarmDataReportInfo Model Object List</returns>
        public List<FarmDataReportInfo> GetFarmDataReportData(int userId, string where)
        {
            List<FarmDataReportInfo> dataRows = new List<FarmDataReportInfo>();

            string sqlQuery = SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_FARM_DATA_REPORT");

            if (where != "")
                sqlQuery = sqlQuery + " WHERE " + where;
            
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_FARM_DATA_REPORT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };
            }
            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, sqlQuery,parameters))
            {
                while (reader.Read())
                {
                    FarmDataReportInfo dataRow = new FarmDataReportInfo();
                    dataRow.AgentId = reader.GetInt32(0);
                    dataRow.AgentFullName = reader.GetString(1);
                    dataRow.AgentPhone = reader.GetString(2);
                    dataRow.FarmCount = reader.GetInt32(3);
                    dataRow.FarmId = reader.GetInt32(4);
                    dataRow.FarmName = reader.GetString(5);
                    dataRow.MailingPlanId = reader.GetInt32(6);
                    dataRow.MailingPlanName = reader.GetString(7);
                    dataRow.FarmCreatedDate = reader.GetDateTime(8);
                    dataRow.PlotCount = reader.GetInt32(9);
                    dataRow.ContactCount = reader.GetInt32(10);
                    dataRow.DeletedContactCount = reader.GetInt32(11);
                    dataRow.FirmUpStatus = reader.GetBoolean(12);
                    dataRows.Add(dataRow);
                }
            }
            return dataRows;
        }

        /// <summary>
        ///     Get the Consiquence of Deleting a Contact
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>Consiquence as string</returns>
        public string GetDeleteContactConsiquence(Int64 contactId)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_DELETE_CONTACT_CONSEQUENCE");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@ContactId", SqlDbType.BigInt),
                    new SqlParameter("@MsgText", SqlDbType.VarChar,100)
                };
                SQLHelper.CacheParameters("SP_DELETE_CONTACT_CONSEQUENCE", parameters);
            }
            parameters[0].Value = contactId;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[1].Value = " ";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONNECTION_STRING, CommandType.StoredProcedure,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SP_DELETE_CONTACT_CONSEQUENCE"),
                parameters);

            return parameters[1].Value.ToString();
        }

        private string GetFarmNameOfPlot(int plotId)
        {
            string farmName = string.Empty;

            SqlParameter[] parameters =
                SQLHelper.GetCachedParameters("SQL_GET_FARM_NAME_OF_PLOT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@plot_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_FARM_NAME_OF_PLOT", parameters);
            }

            parameters[0].Value = plotId;

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_FARM_NAME_OF_PLOT"),
                parameters))
            {
                if (reader.Read())
                {
                    farmName = reader.GetString(0);
                }
            }

            return farmName;
        }
    }
}
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
    /// <summary>
    /// A Data Access Component used to manage Design Utilities.
    /// </summary>
    public class Design : IDesign
    {
        private const string MODULE_NAME = "Design";

        public Design()
		{
			//
		}

        /// <summary>
        /// Gets the summary of designs.
        /// </summary>
        /// <returns>Summary of designs.</returns>
        public DataTable GetSummary()
        {
            DataTable summary = new DataTable("design_summary");
            
            // Execute the query to read the design summary.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_DESIGN_SUMMARY"),
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
        /// Get the designs of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Designs of the specified user.</returns>
        public List<DesignInfo> GetList(int userId)
        {
            List<DesignInfo> designs = new List<DesignInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_DESIGNS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_DESIGNS", parameters);
            }

            parameters[0].Value = userId;

            // Execute the query to read the designs.
            using (SqlDataReader reader = 
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_DESIGNS"),
                parameters))
            {
                while (reader.Read())
                {
                    DesignInfo design = new DesignInfo(reader.GetInt32(0),
                        new LookupInfo(reader.GetInt32(1), reader.GetString(2)),
                        new LookupInfo(reader.GetInt32(3), reader.GetString(4)),
                        new SizeF((float)reader.GetDecimal(5), (float)reader.GetDecimal(6)),
                        reader.GetString(9), 
                        new LookupInfo(reader.GetInt32(7), reader.GetString(8)));

                    designs.Add(design);
                }
            }

            return designs;
        }

        /// <summary>
        /// Get all the designs of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>All the designs of the specified user.</returns>
        public List<DesignInfo> GetListAll(int userId)
        {
            List<DesignInfo> designs = new List<DesignInfo>();

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_GET_DESIGNS_ALL");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_DESIGNS_ALL", parameters);
            }

            parameters[0].Value = userId;

            // Execute the query to read the designs.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_DESIGNS_ALL"),
                parameters))
            {
                while (reader.Read())
                {
                    DesignInfo design = new DesignInfo(reader.GetInt32(0),
                        new LookupInfo(reader.GetInt32(1), reader.GetString(2)),
                        new LookupInfo(reader.GetInt32(3), reader.GetString(4)),
                        new SizeF((float)reader.GetDecimal(5), (float)reader.GetDecimal(6)),
                        reader.GetString(9),
                        new LookupInfo(reader.GetInt32(7), reader.GetString(8)));
                    design.LastModifyDate = reader.GetDateTime(10);
                    design.UserId = reader.GetInt32(11);

                    designs.Add(design);
                }
            }

            return designs;
        }

        /// <summary>
        /// Updates the design of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="design">Design of the user.</param>
        public void Update(int userId, DesignInfo design)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_UPDATE_DESIGN");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@design_id", SqlDbType.Int),
                    new SqlParameter("@user_id", SqlDbType.Int),
                    new SqlParameter("@category", SqlDbType.Int),
                    new SqlParameter("@type", SqlDbType.Int),
                    new SqlParameter("@length", SqlDbType.Decimal),
                    new SqlParameter("@width", SqlDbType.Decimal),
                    new SqlParameter("@gender", SqlDbType.NVarChar, 50),
                    new SqlParameter("@on_design_name", SqlDbType.NVarChar, 50),
                    new SqlParameter("@justification", SqlDbType.Int),
                    new SqlParameter("@gutter", SqlDbType.NVarChar, 50),
                    new SqlParameter("@msg_locn_x", SqlDbType.Decimal),
                    new SqlParameter("@msg_locn_y", SqlDbType.Decimal),
                    new SqlParameter("@msg_size_length", SqlDbType.Decimal),
                    new SqlParameter("@msg_size_width", SqlDbType.Decimal),
                    new SqlParameter("@low_res_file", SqlDbType.NVarChar, 255),
                    new SqlParameter("@high_res_file", SqlDbType.NVarChar, 255),
                    new SqlParameter("@extra_file", SqlDbType.NVarChar, 255),
                    new SqlParameter("@status", SqlDbType.Int),
                    new SqlParameter("@last_modify_by", SqlDbType.Int),
                    new SqlParameter("@approve_by", SqlDbType.Int),
                    new SqlParameter("@comments", SqlDbType.Text)
                };

                SQLHelper.CacheParameters("SP_UPDATE_DESIGN", parameters);
            }

            parameters[0].Value = design.DesignId;
            parameters[1].Value = design.UserId;
            parameters[2].Value = design.Category.LookupId;
            parameters[3].Value = design.Type.LookupId;
            parameters[4].Value = design.Size.Width;
            parameters[5].Value = design.Size.Height;
            parameters[6].Value = design.Gender;
            parameters[7].Value = design.OnDesignName;
            parameters[8].Value = design.Justification;
            parameters[9].Value = design.Gutter;
            parameters[10].Value = design.MessageRectangle.X;
            parameters[11].Value = design.MessageRectangle.Y;
            parameters[12].Value = design.MessageRectangle.Width;
            parameters[13].Value = design.MessageRectangle.Height;
            parameters[14].Value = design.LowResolutionFile;
            parameters[15].Value = design.HighResolutionFile;
            parameters[16].Value = design.ExtraFile;
            parameters[17].Value = design.Status.LookupId;
            parameters[18].Value = design.LastModifyBy;
            parameters[19].Value = design.ApproveBy;
            parameters[20].Value = design.Comments;

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, 
                            CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SP_UPDATE_DESIGN"),
                            parameters);

                        // Write entry into audit trail.
                        string action = string.Empty;

                        if (design.DesignId == 0)
                        {
                            if (design.Status.LookupId == 23)
                            {
                                action = "Submitted design";
                            }
                            else
                            {
                                action = "Added design";
                            }
                        }
                        else
                        {
                            if (design.Status.LookupId == 23)
                            {
                                if (design.UserId == design.LastModifyBy)
                                {
                                    action = "Submitted design";
                                }
                                else
                                {
                                    action = "Modified design";
                                }
                            }
                            else if (design.Status.LookupId == 25)
                            {
                                action = "Archived design";
                            }
                            else if (design.Status.LookupId == 26)
                            {
                                action = "Approved design";
                            }
                            else
                            {
                                action = "Modified design";
                            }
                        }

                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.DesignManagement, design.Category.Name,
                            action, design.UserId, design.LastModifyBy);
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
        /// Gets the design details of the specified design.
        /// </summary>
        /// <param name="designId">Internal identifier of the design.</param>
        /// <returns>Design details of the specified design.</returns>
        public DesignInfo Get(int designId)
        {
            DesignInfo design = null;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_DESIGN");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@design_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_DESIGN", parameters);
            }

            parameters[0].Value = designId;

            using (SqlDataReader reader = 
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, 
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_DESIGN"),
                parameters))
            {
                if (reader.Read())
                {
                    DesignUsed used = DesignUsed.Never;

                    if (reader.GetInt32(27) > 0)
                    {
                        used = DesignUsed.FoundActive;
                    }
                    else if (reader.GetInt32(26) > 0)
                    {
                        used = DesignUsed.Found;
                    }

                    design = new DesignInfo(reader.GetInt32(0), reader.GetInt32(1), 
                        new LookupInfo(reader.GetInt32(2), reader.GetString(3)), 
                        new LookupInfo(reader.GetInt32(4), reader.GetString(5)), 
                        new SizeF((float)reader.GetDecimal(6), (float)reader.GetDecimal(7)), 
                        reader.GetString(8), reader.GetString(9), 
                        (JustificationType)reader.GetInt32(10), reader.GetString(11), 
                        new RectangleF((float)reader.GetDecimal(12), (float)reader.GetDecimal(13), (float)reader.GetDecimal(14), (float)reader.GetDecimal(15)), 
                        reader.GetString(16), reader.GetString(17), reader.GetString(18), 
                        new LookupInfo(reader.GetInt32(19), reader.GetString(20)), 
                        reader.GetDateTime(21), reader.GetDateTime(22), reader.GetInt32(23), 
                        reader.GetDateTime(24), reader.GetInt32(25),
                        string.Empty, string.Empty, used);
                }
            }

            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_DESIGN_HISTORY"),
                parameters))
            {
                string eventDetails = string.Empty;

                while (reader.Read())
                {
                    eventDetails += reader.GetDateTime(4).ToString("MM/dd/yyyy");
                    eventDetails += ": ";
                    eventDetails += reader.GetString(1);
                    eventDetails += " [" + reader.GetString(2) + "]";
                    eventDetails += Environment.NewLine;

                    eventDetails += (reader.GetString(3) == "" ? "---" : reader.GetString(3));
                    eventDetails += Environment.NewLine;

                    eventDetails += Environment.NewLine;
                }

                design.History = eventDetails;
            }

            return design;
        }

        /// <summary>
        /// Deletes the specified design.
        /// </summary>
        /// <param name="designId">Internal identifier of the design to delete.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void Delete(int designId, int userId)
        {
            // Get the design details.
            DesignInfo design = Get(designId);

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_DELETE_DESIGN");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@design_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SP_DELETE_DESIGN", parameters);
            }

            parameters[0].Value = designId;

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, 
                            CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SP_DELETE_DESIGN"),
                            parameters);

                        // Write entry into audit trail.
                        string action = string.Empty;

                        if (design.Status.LookupId == 23)
                        {
                            action = "Rejected design";
                        }
                        else
                        {
                            action = "Deleted design";
                        }

                        AuditEntryInfo auditEntry = new AuditEntryInfo(
                            Module.DesignManagement, design.Category.Name,
                            action, design.UserId, userId);
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
        /// Get the design statuses of the specified parameters.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="category">Category of the designs.</param>
        /// <param name="status">Status of the designs.</param>
        /// <returns>The design statuses of the specified parameters.</returns>
        public List<DesignStatusInfo> GetDesignStatuses(int userId, int category, 
            int status)
        {
            List<DesignStatusInfo> designs = new List<DesignStatusInfo>();

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_DESIGN_STATUS_REPORT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int),
                    new SqlParameter("@category", SqlDbType.Int),
                    new SqlParameter("@status", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_DESIGN_STATUS_REPORT", parameters);
            }

            parameters[0].Value = userId;
            parameters[1].Value = category;
            parameters[2].Value = status;

            // Execute the query to read the designs.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_DESIGN_STATUS_REPORT"),
                parameters))
            {
                while (reader.Read())
                {
                    DesignStatusInfo design = new DesignStatusInfo();
                    design.AgentId = reader.GetInt32(0);
                    design.AgentName = reader.GetString(1);
                    design.Phone = reader.GetString(2);
                    design.Category = reader.GetString(3);
                    design.Status = reader.GetString(4);
                    if (!reader.IsDBNull(5))
                    {
                        design.LastModifyDate = reader.GetDateTime(5).ToString("MM/dd/yyyy");
                    }
                    if (!reader.IsDBNull(6))
                    {
                        design.DaysInStatus = reader.GetInt32(6);
                    }

                    designs.Add(design);
                }
            }

            return designs;
        }
    }
}

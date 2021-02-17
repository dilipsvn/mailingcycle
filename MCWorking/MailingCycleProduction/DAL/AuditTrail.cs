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
    /// A Data Access Component used to manage Audit Trail Utilities.
    /// </summary>
    public static class AuditTrail
    {
        private const string MODULE_NAME = "AuditTrail";

        /// <summary>
        /// Writes an entry to the Audit Trail.
        /// </summary>
        /// <param name="auditEntry">Audit entry to be wriiten to the Audit Trail.</param>
        public static void WriteEntry(AuditEntryInfo auditEntry, SqlTransaction transaction)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_WRITE_ENTRY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@module", SqlDbType.NVarChar, 255),
                    new SqlParameter("@record", SqlDbType.NVarChar, 255),
                    new SqlParameter("@action", SqlDbType.NVarChar, 255),
                    new SqlParameter("@owner_id", SqlDbType.Int),
                    new SqlParameter("@modified_by", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_WRITE_ENTRY", parameters);
            }

            parameters[0].Value = auditEntry.ModuleName;
            parameters[1].Value = auditEntry.Record;
            parameters[2].Value = auditEntry.Action;
            parameters[3].Value = auditEntry.OwnerId;
            parameters[4].Value = auditEntry.ModifiedBy;

            SQLHelper.ExecuteNonQuery(transaction, 
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_WRITE_ENTRY"),
                parameters);
        }
    }
}

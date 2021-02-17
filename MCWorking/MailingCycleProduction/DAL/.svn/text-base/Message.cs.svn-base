using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.DAL
{
    class Message : IMessage
    {
        public List<MessageInfo> GetStandardMessageList(bool isAgent)
        {
            List<MessageInfo> msgInfo = new List<MessageInfo>();
            MessageInfo info;
            SqlParameter[] sqlParam = new SqlParameter[] { new SqlParameter("@is_agent", SqlDbType.Bit) };
            sqlParam[0].Value = isAgent;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement("Message", "SP_GET_STD_MESSAGE"), sqlParam))
            {
                while (reader.Read())
                {
                    info = new MessageInfo();
                    info.MessageId = (int)reader["message_id"];
                    info.MessageText = (string)reader["message_text"];
                    info.MessageType = (MessageType)((int)reader["type"]);
                    info.ShortDesc = (string)reader["short_desc"];
                    info.Status = (MessageStatus)((int)reader["status"]);
                    info.UsageCount = (int)(reader["usage_count"]);
                    info.EventInProgress = Convert.ToBoolean(reader["event_in_progress"]);
                    info.IsDefaultMessage = Convert.ToBoolean(reader["is_default_message"]);
                    msgInfo.Add(info);
                }
            }
            return msgInfo;
        }

        public List<MessageInfo> GetCustomMessageList(int userId)
        {
            List<MessageInfo> msgInfo = new List<MessageInfo>();
            MessageInfo info;
            SqlParameter[] sqlParam = new SqlParameter[] { new SqlParameter("@user_id", DbType.Int32) };
            if (userId != 0)
                sqlParam[0].Value = userId;
            else
                sqlParam[0].Value = DBNull.Value;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement("Message", "SP_GET_CUSTOM_MESSAGE"), sqlParam))
            {
                while (reader.Read())
                {
                    info = new MessageInfo();
                    info.MessageId = (int)reader["message_id"];
                    info.MessageText = (string)reader["message_text"];
                    info.MessageType = (MessageType)((int)reader["type"]);
                    //info.MessageTextShort = info.MessageText.Substring(0, 50);
                    info.ShortDesc = (string)reader["short_desc"];
                    info.Status = (MessageStatus)((int)reader["status"]);
                    if (userId != 0)
                    {
                        info.EventInProgress = Convert.ToBoolean(reader["event_in_progress"]);
                        info.UsageCount = (int)(reader["usage_count"]);
                    }
                    info.IsImage = (bool)reader["IsImage"];
                    if (info.IsImage && reader["file_name"] != DBNull.Value)
                        info.MessageText = info.FileName = (string)reader["file_name"];
                    msgInfo.Add(info);
                }
            }
            return msgInfo;
        }

        private static SqlParameter[] GetStdMessageParams()
        {
            SqlParameter[] messageParams = SQLHelper.GetCachedParameters("SQL_INSERT_STDMESSAGE");
            if (messageParams == null)
            {
                messageParams = new SqlParameter[]{
                    new SqlParameter("@message_id",SqlDbType.Int),
                    new SqlParameter("@type",SqlDbType.Int),
                    new SqlParameter("@short_desc",SqlDbType.Text),
                    new SqlParameter("@message_text",SqlDbType.Text),
                    new SqlParameter("@status",SqlDbType.Int),
                    new SqlParameter("@owner_id",SqlDbType.Int),
                    new SqlParameter("@is_image",SqlDbType.Bit),
                    new SqlParameter("@file_name",SqlDbType.NVarChar,255),
                    new SqlParameter("@is_default_message",SqlDbType.Bit)};
                SQLHelper.CacheParameters("SQL_INSERT_STDMESSAGE", messageParams);
            }
            return messageParams;
        }

        private static SqlParameter[] GetUpdateStdMessageParams()
        {
            SqlParameter[] messageParams = SQLHelper.GetCachedParameters("SQL_UPDATE_STDMESSAGE");
            if (messageParams == null)
            {
                messageParams = new SqlParameter[]{
                    new SqlParameter("@message_id",SqlDbType.Int),
                    new SqlParameter("@short_desc",SqlDbType.Text),
                    new SqlParameter("@message_text",SqlDbType.Text),
                    new SqlParameter("@status",SqlDbType.Int),
                     new SqlParameter("@owner_id",SqlDbType.Int),
                    new SqlParameter("@is_image",SqlDbType.Bit),
                    new SqlParameter("@file_name",SqlDbType.NVarChar,255),
                    new SqlParameter("@is_default_message",SqlDbType.Bit)};

                SQLHelper.CacheParameters("SQL_UPDATE_STDMESSAGE", messageParams);
            }
            return messageParams;
        }

        public bool InsertMessage(MessageInfo messageInfo,int userId)
        {
            bool success = false;
            SqlParameter[] messageParameters = GetStdMessageParams();
            messageParameters[0].Value = messageInfo.MessageId;
            messageParameters[1].Value = (int)messageInfo.MessageType;
            messageParameters[2].Value = messageInfo.ShortDesc;
            messageParameters[3].Value = messageInfo.MessageText;
            messageParameters[4].Value = messageInfo.Status;
            messageParameters[5].Value = userId;
            messageParameters[6].Value = messageInfo.IsImage;
            messageParameters[8].Value = messageInfo.IsDefaultMessage;
            if (messageInfo.FileName != string.Empty)
                messageParameters[7].Value = messageInfo.FileName;

            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement("Message", "SP_INSERT_MESSAGE"), messageParameters);
                        success = (noOfRecords > 0);
                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.MessageManagement, messageInfo.ShortDesc, "Inserted message",
                                                            userId, userId);
                        AuditTrail.WriteEntry(auditEntry, sqlTran);
                        sqlTran.Commit();
                    }
                    catch
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
            return success;
        }

        public bool DeleteMessage(int messageId,int userId,int deletedBy)
        {
            bool success = false;
            SqlParameter[] messageParamater = new SqlParameter[] { new SqlParameter("@message_id", DbType.Int32) };
            messageParamater[0].Value = messageId;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement("Message", "SP_DELETE_STD_MESSAGE"), messageParamater);
                        success = (noOfRecords > 0);
                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.MessageManagement, messageId.ToString(), "Deleted message",
                                                            userId,deletedBy);
                        AuditTrail.WriteEntry(auditEntry, sqlTran);
                        sqlTran.Commit();
                    }
                    catch
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
            return success;
        }

        public List<MessageInfo> GetSearchMessages(int messageId, MessageStatus messageStatus, MessageType messageType)
        {
            List<MessageInfo> msgInfo = new List<MessageInfo>();
            MessageInfo info;
            string sql = SQLHelper.GetSQLStatement("Message", "SQL_GET_MESSAGE_DETAILS");
            if (messageId != Int32.MinValue)
                sql += " AND TBL_MESSAGE.message_id like '" + messageId.ToString() + "%'";
            if (messageStatus != MessageStatus.NullStatus)
                sql += " AND TBL_MESSAGE.status = " + (Convert.ToInt32(messageStatus)).ToString();
            if (messageType != MessageType.NullType)
                sql += " AND TBL_MESSAGE.type = '" + (Convert.ToInt32(messageType)).ToString() + "'";
            
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    info = new MessageInfo();
                    info.MessageId = (int)reader["message_id"];
                    info.MessageText = (string)reader["message_text"];
                    info.MessageType = (MessageType)((int)reader["type"]);
                    info.ShortDesc = (string)reader["short_desc"];
                    info.Status = (MessageStatus)((int)reader["status"]);
                    info.IsImage = (bool)reader["IsImage"];
                    if (info.IsImage && reader["file_name"] != DBNull.Value)
                        info.MessageText = info.FileName = (string)reader["file_name"];
                    info.UsageCount = (int)reader["usage_count"];
                    msgInfo.Add(info);
                }
            }
            return msgInfo;
        }

        #region IMessage Members


        public bool UpdateMessage(MessageInfo messageInfo,int userId,int ownerId)
        {
            bool success = false;
            SqlParameter[] messageParameters = GetUpdateStdMessageParams();
            messageParameters[0].Value = messageInfo.MessageId;
            messageParameters[1].Value = messageInfo.ShortDesc;
            messageParameters[2].Value = messageInfo.MessageText;
            messageParameters[3].Value = messageInfo.Status;
            messageParameters[4].Value = ownerId;
            messageParameters[5].Value = messageInfo.IsImage;
            if (messageInfo.FileName != string.Empty && messageInfo.FileName != null)
                messageParameters[6].Value = messageInfo.FileName;
            messageParameters[7].Value = messageInfo.IsDefaultMessage;

            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement("Message", "SP_UPDATE_STD_MESSAGE"), messageParameters);
                        success = (noOfRecords > 0);
                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.MessageManagement, messageInfo.MessageId.ToString(), "Updated message",
                                                            userId, ownerId);
                        AuditTrail.WriteEntry(auditEntry, sqlTran);
                        sqlTran.Commit();
                    }
                    catch
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
            return success;
        }

        #endregion
    }
}

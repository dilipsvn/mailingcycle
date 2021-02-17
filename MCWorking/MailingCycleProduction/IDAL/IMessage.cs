using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.Model;

namespace Irmac.MailingCycle.IDAL
{
    public interface IMessage
    {
        /// <summary>
        /// Gets the standard messages based on the user id.
        /// </summary>
        /// <param name="userId">The user id of the logged in user</param>
        List<MessageInfo> GetStandardMessageList(bool isAgent);

        /// <summary>
        /// Gets the custom messages based on user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The user id of the logged in user</returns>
        List<MessageInfo> GetCustomMessageList(int userId);

        /// <summary>
        /// Inserts a standard message created by admin
        /// </summary>
        /// <param name="messageInfo">The message info object which contains information
        /// given by the admin</param>
        /// <returns>bool value representing success or failure of insert</returns>
        bool InsertMessage(MessageInfo messageInfo,int userId);

        /// <summary>
        /// Deletes a standard message based on message id
        /// </summary>
        /// <param name="messageId">id of the message to be deleted</param>
        /// <returns>bool value representing success or failure of delete</returns>
        bool DeleteMessage(int messageId, int userId, int deletedBy);

        /// <summary>
        /// Updates a standard message based on message id
        /// </summary>
        /// <param name="messageId">id of the message to be updated</param>
        /// <returns>bool value representing success or failure of update</returns>
        bool UpdateMessage(MessageInfo msgInfo,int userId,int ownerId);

        /// <summary>
        /// Gets the records for the report
        /// </summary>
        /// <param name="messageId">id of the message</param>
        /// <param name="messageStatus">message status</param>
        /// <param name="messageType">message type</param>
        /// <returns>list of message info objects</returns>
        List<MessageInfo> GetSearchMessages(int messageId, MessageStatus messageStatus, MessageType messageType);
    }
}

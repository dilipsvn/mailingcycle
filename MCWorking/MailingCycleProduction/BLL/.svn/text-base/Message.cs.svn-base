#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: Message.cs
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/04/2007
	* Author			: Irmac Development Team 
	* Comment			: Message
	* Source			: MailingCycle\BLL\Message.cs

	****************************************************************/
#endregion

# region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.IDAL;
using Irmac.MailingCycle.Model;
using System.Text.RegularExpressions;
#endregion

namespace Irmac.MailingCycle.BLL
{
    /// <summary>
    /// Message component
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets the list of standard messages
        /// </summary>
        /// <param name="isAGent">bool value that represents whether the user is an agent</param>
        /// <returns>List of message info objects</returns>
        public List<MessageInfo> GetStandardMessageList(bool isAGent,string gender,string agentName)
        {
            IMessage message = (IMessage)DALFactory.DAO.Create(DALFactory.Module.Message);
            List<MessageInfo> messageInfo = message.GetStandardMessageList(isAGent);
            if (gender != string.Empty)
            {
                foreach (MessageInfo msgInfo in messageInfo)
                    msgInfo.MessageText = RenderMessage(msgInfo.MessageText, gender, agentName);
            }
            return messageInfo;
        }

        /// <summary>
        /// Gets the list of custom messages
        /// </summary>
        /// <param name="userId">user id of the logged in user</param>
        /// <returns>List of message info objects</returns>
        public List<MessageInfo> GetCustomMessageList(int userId)
        {
            IMessage message = (IMessage)DALFactory.DAO.Create(DALFactory.Module.Message);
            List<MessageInfo> messageInfo = message.GetCustomMessageList(userId);
            return messageInfo; 
        }

        /// <summary>
        /// Inserts a message into database
        /// </summary>
        /// <param name="messageInfo">The message info object containing info that user has entered</param>
        /// <param name="userId">user id of the loggedin user</param>
        /// <returns>bool value that represents success or failure</returns>
        public bool InsertMessage(MessageInfo messageInfo,int userId)
        {
            IMessage message = (IMessage)DALFactory.DAO.Create(DALFactory.Module.Message);
            bool success = message.InsertMessage(messageInfo,userId);
            return success;
        }

        /// <summary>
        /// updates a message into database
        /// </summary>
        /// <param name="messageInfo">The message info object containing info that user has entered</param>
        /// <param name="userId">user id of the loggedin user</param>
        /// <returns>bool value that represents success or failure</returns>
        public bool UpdateMessage(MessageInfo messageInfo,int userId,int ownerId)
        {
            IMessage message = (IMessage)DALFactory.DAO.Create(DALFactory.Module.Message);
            bool success = message.UpdateMessage(messageInfo,userId,ownerId);
            return success;
        }

        /// <summary>
        /// deletes a message from the database
        /// </summary>
        /// <param name="messageId">message id of the message to be deleted</param>
        /// <returns>bool value that represents success or failure</returns>
        public bool DeleteMessage(int messageId,int userId,int deletedBy)
        {
            IMessage message = (IMessage)DALFactory.DAO.Create(Irmac.MailingCycle.DALFactory.Module.Message);
            bool success = message.DeleteMessage(messageId, userId, deletedBy);
            return success;
        }

        public List<MessageInfo> GetSearchMessages(int messageId, MessageStatus messageStatus, MessageType messageType)
        {
            IMessage message = (IMessage)DALFactory.DAO.Create(Irmac.MailingCycle.DALFactory.Module.Message);
            return message.GetSearchMessages(messageId, messageStatus, messageType);
        }

        public static string RenderMessage(string messageText, string gender,string agentName)
        {
            int genderIndex = 0;
            switch(gender.ToLower())
            {
                case "male":
                    genderIndex = 0;
                    break;
                case "female":
                    genderIndex = 1;
                    break;
                case "group":
                    genderIndex = 2;
                    break;               
            }            

            // Replace the agent name wildcard in message text. 
            messageText = messageText.Replace("{ON_DESIGN_NAME}", agentName);

            // Use appropriate phrases based on the gender. 

            Regex regex = new Regex(@"\[[^\v/\[\]]+/[^\v/\[\]]+/[^\v/\[\]]+\]");

            MatchCollection matches = regex.Matches(messageText);

            foreach (Match match in matches)
            {
                string phraseDefinition = match.Value;
                string phraseDetails = phraseDefinition.Substring(1, phraseDefinition.Length - 2);
                string[] phrases = phraseDetails.Split("/".ToCharArray());
                string phrase = phrases[genderIndex];
                messageText = messageText.Replace(phraseDefinition, phrase);
            }
            return messageText;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public enum MessageStatus
    {
        Active = 1,
        InActive = 2,
        NullStatus
    };

    public enum MessageType
    {
        Standard = 1,
        Custom = 2,
        NullType
    };

    [Serializable]
    public class MessageInfo : BaseInfo
    {
        private int messageId;
        private string shortDesc;
        private string messageText;
        private string messageTextShort;     
        private MessageStatus status = MessageStatus.Active;
        private MessageType messageType = MessageType.Standard;
        private bool isImage;
        private string fileName;
        private int usageCount;
        private bool eventInProgress;
        private bool isDefaultMessage;

        public bool IsDefaultMessage
        {
            get { return isDefaultMessage; }
            set { isDefaultMessage = value; }
        }

        public bool EventInProgress
        {
            get { return eventInProgress; }
            set { eventInProgress = value; }
        }

        public int UsageCount
        {
            get { return usageCount; }
            set { usageCount = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public bool IsImage
        {
            get { return isImage; }
            set { isImage = value; }
        }

        public string MessageTextShort
        {
            get { return messageTextShort; }
            set { messageTextShort = value; }
        }

        public MessageType MessageType
        {
            get { return messageType; }
            set { messageType = value; }
        }

        public MessageStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public string ShortDesc
        {
            get { return shortDesc; }
            set { shortDesc = value; }
        }        

        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; }
        }

        public int MessageId
        {
            get { return messageId; }
            set { messageId = value; }
        }
    }
}

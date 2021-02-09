using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model Schedule Event Entries.
    /// </summary>
    [Serializable]
    public class ScheduleEventEntryInfo : BaseInfo
    {
        private int plotId = 0;
        private string plotName = string.Empty;
        private int numberOfContacts = 0;
        private MessageInfo message = new MessageInfo();
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ScheduleEventEntryInfo()
        {
            //
        }

        /// <summary>
        /// Constructor with the specified initial values.
        /// </summary>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <param name="plotName">Name of the plot.</param>
        /// <param name="numberOfContacts">Number of the contacts that are part of the
        /// plot.</param>
        /// <param name="message">Message assigned to the plot.</param>
        public ScheduleEventEntryInfo(int plotId, string plotName, int numberOfContacts,
            MessageInfo message)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.numberOfContacts = numberOfContacts;
            this.message = message;
        }

        public int PlotId
        {
            get
            {
                return plotId;
            }
            set
            {
                plotId = value;
            }
        }

        public string PlotName
        {
            get
            {
                return plotName;
            }
            set
            {
                plotName = value;
            }
        }

        public int NumberOfContacts
        {
            get
            {
                return numberOfContacts;
            }
            set
            {
                numberOfContacts = value;
            }
        }

        public MessageInfo Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }
}

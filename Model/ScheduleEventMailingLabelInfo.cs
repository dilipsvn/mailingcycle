using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model Schedule Event's Mailing Labels.
    /// </summary>
    [Serializable]
    public class ScheduleEventMailingLabelInfo : BaseInfo
    {
        private string eventDate = string.Empty;
        private string farmName = string.Empty;
        private string planName = string.Empty;
        private string plotName = string.Empty;
        private string mailingLabel_1 = string.Empty;
        private string mailingLabel_2 = string.Empty;
        private string mailingLabel_3 = string.Empty;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ScheduleEventMailingLabelInfo()
        {
            //
        }

        public string EventDate
        {
            get
            {
                return eventDate;
            }
            set
            {
                eventDate = value;
            }
        }

        public string FarmName
        {
            get
            {
                return farmName;
            }
            set
            {
                farmName = value;
            }
        }

        public string PlanName
        {
            get
            {
                return planName;
            }
            set
            {
                planName = value;
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

        public string MailingLabel_1
        {
            get
            {
                return mailingLabel_1;
            }
            set
            {
                mailingLabel_1 = value;
            }
        }

        public string MailingLabel_2
        {
            get
            {
                return mailingLabel_2;
            }
            set
            {
                mailingLabel_2 = value;
            }
        }

        public string MailingLabel_3
        {
            get
            {
                return mailingLabel_3;
            }
            set
            {
                mailingLabel_3 = value;
            }
        }
    }
}

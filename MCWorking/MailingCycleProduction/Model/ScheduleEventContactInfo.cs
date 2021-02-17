using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model Schedule Event Contacts.
    /// </summary>
    [Serializable]
    public class ScheduleEventContactInfo : BaseInfo
    {
        private int eventNumber = 0;
        private string eventDate = string.Empty;
        private int farmId = 0;
        private string farmName = string.Empty;
        private int planId = 0;
        private string planName = string.Empty;
        private string startDate = string.Empty;
        private string endDate = string.Empty;
        private int plotId = 0;
        private string plotName = string.Empty;
        private Int64 contactId = 0;
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string address1 = string.Empty;
        private string address2 = string.Empty;
        private string city = string.Empty;
        private string state = string.Empty;
        private string zip = string.Empty;
        private string country = string.Empty;
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ScheduleEventContactInfo()
        {
            //
        }

        public int EventNumber
        {
            get
            {
                return eventNumber;
            }
            set
            {
                eventNumber = value;
            }
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

        public int FarmId
        {
            get
            {
                return farmId;
            }
            set
            {
                farmId = value;
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

        public int PlanId
        {
            get
            {
                return planId;
            }
            set
            {
                planId = value;
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

        public string StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public string EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
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

        public Int64 ContactId
        {
            get
            {
                return contactId;
            }
            set
            {
                contactId = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Address1
        {
            get
            {
                return address1;
            }
            set
            {
                address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public string Zip
        {
            get
            {
                return zip;
            }
            set
            {
                zip = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
    }
}

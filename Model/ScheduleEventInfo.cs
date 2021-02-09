using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Irmac.MailingCycle.Model
{
    public enum ScheduleEventStatus
    {
        Scheduled = 27,
        InProgress,
        Completed,
        Cancelled,
        ACCAInProgress = 41,
        ACCAError = 42
    };

    /// <summary>
    /// Business Entity used to model Schedule Events.
    /// </summary>
    [Serializable]
    public class ScheduleEventInfo : BaseInfo
    {
        private int eventId = 0;
        private int eventNumber = 0;
        private DateTime eventDate;
        private LookupInfo productType = new LookupInfo();
        private string designFile = string.Empty;
        private string postalTariff = string.Empty;
        private int numberOfPlots = 0;
        private int numberOfContacts = 0;
        private LookupInfo status = new LookupInfo();
        private DateTime completedOn;
        private int orderId = 0;
        private int orderValue = 0;
        private string notes = string.Empty;
        private string mailingListFile = string.Empty;
        private string remarks = string.Empty;
        private int mailingCount = 0;
        private decimal refundAmount = 0;
        private bool exceptionReported = false;
        private List<ScheduleEventEntryInfo> entries = new List<ScheduleEventEntryInfo>();
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ScheduleEventInfo()
        {
            //
        }

        /// <summary>
        /// Constructor with the specified initial values.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="eventNumber">Number of the event.</param>
        /// <param name="eventDate">Date of the event.</param>
        /// <param name="productType">Product type used for the event.</param>
        /// <param name="postalTariff">Postal tariff used for the event.</param>
        /// <param name="numberOfPlots">Number of the plots that are part of the
        /// event.</param>
        /// <param name="numberOfContacts">Number of the contacts that are part of the
        /// event.</param>
        /// <param name="status">Status of the event.</param>
        /// <param name="completedOn">Complted date of the event.</param>
        public ScheduleEventInfo(int eventId, int eventNumber, DateTime eventDate,
            LookupInfo productType, string postalTariff, int numberOfPlots,
            int numberOfContacts, LookupInfo status, DateTime completedOn)
        {
            this.eventId = eventId;
            this.eventNumber = eventNumber;
            this.eventDate = eventDate;
            this.productType = productType;
            this.postalTariff = postalTariff;
            this.numberOfPlots = numberOfPlots;
            this.numberOfContacts = numberOfContacts;
            this.status = status;
            this.completedOn = completedOn;
        }

        public int EventId
        {
            get
            {
                return eventId;
            }
            set
            {
                eventId = value;
            }
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

        public DateTime EventDate
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

        public LookupInfo ProductType
        {
            get
            {
                return productType;
            }
            set
            {
                productType = value;
            }
        }

        public string DesignFile
        {
            get
            {
                return designFile;
            }
            set
            {
                designFile = value;
            }
        }

        public string PostalTariff
        {
            get
            {
                return postalTariff;
            }
            set
            {
                postalTariff = value;
            }
        }

        public int NumberOfPlots
        {
            get
            {
                return numberOfPlots;
            }
            set
            {
                numberOfPlots = value;
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

        public LookupInfo Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public DateTime CompletedOn
        {
            get
            {
                return completedOn;
            }
            set
            {
                completedOn = value;
            }
        }

        public int OrderId
        {
            get
            {
                return orderId;
            }
            set
            {
                orderId = value;
            }
        }

        public int OrderValue
        {
            get
            {
                return orderValue;
            }
            set
            {
                orderValue = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public string MailingListFile
        {
            get
            {
                return mailingListFile;
            }
            set
            {
                mailingListFile = value;
            }
        }

        public string Remarks
        {
            get
            {
                return remarks;
            }
            set
            {
                remarks = value;
            }
        }

        public int MailingCount
        {
            get
            {
                return mailingCount;
            }
            set
            {
                mailingCount = value;
            }
        }

        public List<ScheduleEventEntryInfo> Entries
        {
            get
            {
                return entries;
            }
            set
            {
                entries = value;
            }
        }

        public decimal RefundAmount
        {
            get
            {
                return refundAmount;
            }
            set
            {
                refundAmount = value;
            }
        }

        public bool ExceptionReported
        {
            get
            {
                return exceptionReported;
            }
            set
            {
                exceptionReported = value;
            }
        }
    }
}

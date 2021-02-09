#region (C) Irmac USA Inc 2006
/***************************************************************** 

	* All rights are reserved. 
    * File				: CreditCardInfo.cs
    * Created Date      : 03/Nov/2006
	* Last Modify Date  : 03/Nov/20056
	* Author			: Irmac Development Team 
	* Comment			: Class for the Credit card Information
	* Source			: MailingCycle\Model\CreditCardInfo.cs

	****************************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model Credit Cards.
    /// </summary>
    [Serializable]
    public class AccaInfo : BaseInfo
    {
        private CreditCardInfo creditCardInfo;
        private int eventId;
        private ScheduleEventStatus eventStatus;
        private int contactCount;
        private DesignCategory designCategory;
        private int userId;
        private string remarks;
        private OrderInfo orderInfo;
        private DateTime eventDate;
        private string farmName;
        private string planName;
        private string userName;
        private string postalTariff;

        public string PostalTariff
        {
            get { return postalTariff; }
            set { postalTariff = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string PlanName
        {
            get { return planName; }
            set { planName = value; }
        }

        public string FarmName
        {
            get { return farmName; }
            set { farmName = value; }
        }

        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }

        public OrderInfo AccaOrderInfo
        {
            get { return orderInfo; }
            set { orderInfo = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public DesignCategory AccaDesignCategory
        {
            get { return designCategory; }
            set { designCategory = value; }
        }

        public int ContactCount
        {
            get { return contactCount; }
            set { contactCount = value; }
        }

        public ScheduleEventStatus EventStatus
        {
            get { return eventStatus; }
            set { eventStatus = value; }
        }

        public int EventId
        {
            get { return eventId; }
            set { eventId = value; }
        }

        public CreditCardInfo AccaCreditCardInfo
        {
            get { return creditCardInfo; }
            set { creditCardInfo = value; }
        }
        

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AccaInfo()
        {
            //
        }

    }
}

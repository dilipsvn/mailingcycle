using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    [Serializable]
    public class FarmDataReportInfo : BaseInfo
    {
        private int agentId;
        private string agentFullName = string.Empty;
        private string agentPhone = string.Empty;
        private int farmCount;
        private int farmId;
        private string farmName = string.Empty;
        private int mailingPlanId;
        private string mailingPlanName = string.Empty;
        private int plotCount;
        private int contactCount;
        private int deletedContactCount;
        private DateTime farmCreatedDate;
        private bool firmUpStatus;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FarmDataReportInfo()
        {
            //
        }

        /// <summary>
        ///     Constructor to populate all data
        /// </summary>
        /// <param name="agentId">Agent Id</param>
        /// <param name="agentFullName">Agent Full Name</param>
        /// <param name="agentPhone">Agent Phone Number</param>
        /// <param name="farmCount">Total Farm Count of the Agent</param>
        /// <param name="farmId">Farm Id</param>
        /// <param name="farmName">Farm Name</param>
        /// <param name="mailingPlanId">Mailing Plan Id</param>
        /// <param name="mailingPlanName">Mailing Plan Name</param>
        /// <param name="plotCount">Plot Count</param>
        /// <param name="contactCount">Contact Count</param>
        /// <param name="deletedContactCount">Deleted Contact Count</param>
        /// <param name="farmCreatedDate">Farm Created Date</param>
        /// <param name="firmUpStatus">Firmed Up Status</param>
        public FarmDataReportInfo(int agentId, string agentFullName, string agentPhone, int farmCount,
            int farmId, string farmName, int mailingPlanId, string mailingPlanName, 
            int plotCount, int contactCount, int deletedContactCount, DateTime farmCreatedDate, bool firmUpStatus)
        {
            this.agentId = agentId;
            this.agentFullName = agentFullName;
            this.agentPhone = agentPhone;
            this.farmCount = farmCount;
            this.farmId = farmId;
            this.farmName = farmName;
            this.mailingPlanId = mailingPlanId;
            this.mailingPlanName = mailingPlanName;
            this.plotCount = plotCount;
            this.contactCount = contactCount;
            this.deletedContactCount = deletedContactCount;
            this.farmCreatedDate = farmCreatedDate;
            this.firmUpStatus = firmUpStatus;
        }

        public int AgentId
        {
            get { return agentId; }
            set { agentId = value; }
        }

        public string AgentFullName
        {
            get { return agentFullName; }
            set { agentFullName = value; }
        }

        public string AgentPhone
        {
            get { return agentPhone; }
            set { agentPhone = value; }
        }
        
        public int FarmCount
        {
            get { return farmCount; }
            set { farmCount = value; }
        }

        public int FarmId
        {
            get { return farmId; }
            set { farmId = value; }
        }

        public string FarmName
        {
            get { return farmName; }
            set { farmName = value; }
        }

        public int MailingPlanId
        {
            get { return mailingPlanId; }
            set { mailingPlanId = value; }
        }

        public string MailingPlanName
        {
            get { return mailingPlanName; }
            set { mailingPlanName = value; }
        }

        public int PlotCount
        {
            get { return plotCount; }
            set { plotCount = value; }
        }

        public int ContactCount
        {
            get { return contactCount; }
            set { contactCount = value; }
        }

        public int DeletedContactCount
        {
            get { return deletedContactCount; }
            set { deletedContactCount = value; }
        }

        public DateTime FarmCreatedDate
        {
            get { return farmCreatedDate; }
            set { farmCreatedDate = value; }
        }

        public bool FirmUpStatus
        {
            get { return firmUpStatus; }
            set { firmUpStatus = value; }
        }
    }
}

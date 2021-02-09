using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    [Serializable]
    public class FirmUpStatusReportInfo : BaseInfo
    {
        private int agentId;
        private string agentFullName = string.Empty;
        private string agentPhone = string.Empty;
        private int farmId;
        private string farmName = string.Empty;
        private int plotCount;
        private int contactCount;
        private int deletedContactCount;
        private DateTime farmCreatedDate;
        private bool firmUpStatus;

        /// <summary>
        ///     Default Constructor 
        /// </summary>
        public FirmUpStatusReportInfo()
        {
            //Default Constructor
        }

        /// <summary>
        ///     Constructor to populate all data
        /// </summary>
        /// <param name="agentId">Agent Id</param>
        /// <param name="agentFullName">Agent Full Name</param>
        /// <param name="agentPhone">Agent Phone Number</param>
        /// <param name="farmId">Farm Id</param>
        /// <param name="farmName">Farm Name</param>
        /// <param name="plotCount">Plot Count</param>
        /// <param name="contactCount">Contact Count</param>
        /// <param name="deletedContactCount">Deleted Contact Count</param>
        /// <param name="farmCreatedDate">Farm Created Date</param>
        /// <param name="firmUpStatus">Firmed Up Status</param>
        public FirmUpStatusReportInfo(int agentId, string agentFullName, string agentPhone,
            int farmId, string farmName, int plotCount, int contactCount, int deletedContactCount, 
            DateTime farmCreatedDate, bool firmUpStatus)
        {
            this.agentId = agentId;
            this.agentFullName = agentFullName;
            this.agentPhone = agentPhone;
            this.farmId = farmId;
            this.farmName = farmName;
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

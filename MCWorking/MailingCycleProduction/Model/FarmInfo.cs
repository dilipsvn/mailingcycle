using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public enum FarmFileType
    {
        Excel = 1,
        Csv
    };

    /// <summary>
	/// Business Entity used to model Farms.
	/// </summary>
	[Serializable]
	public class FarmInfo : BaseInfo
	{
        private int farmId;
        private string farmName;
        private MailingPlanInfo mailingPlan;
        private List<PlotInfo> plots;
        private DateTime createDate;
        private int userId;
        private DateTime lastModifyDate;
        private int lastModifyBy;
        private bool deleted;
        private bool firmup;
        private Int32 plotCount;
        private Int32 contactCount;
        /// <summary>
		/// Default constructor.
		/// </summary>
		public FarmInfo()
		{
			//
		}

        public FarmInfo(int farmId, string farmName, MailingPlanInfo mailingPlan,List<PlotInfo> plots,DateTime createDate,int userId,Int32 plotCount, Int32 contactCount)
		{
            this.farmId = farmId;
            this.farmName = farmName;
            this.mailingPlan = mailingPlan;
            this.plots = plots;
            this.createDate = createDate;
            this.userId = userId;
            this.plotCount = plotCount;
            this.contactCount = contactCount;
		}

        public FarmInfo(int farmId, string farmName, MailingPlanInfo mailingPlan, List<PlotInfo> plots, DateTime createDate, int userId, Int32 plotCount, Int32 contactCount, bool deleted)
        {
            this.farmId = farmId;
            this.farmName = farmName;
            this.mailingPlan = mailingPlan;
            this.plots = plots;
            this.createDate = createDate;
            this.userId = userId;
            this.plotCount = plotCount;
            this.contactCount = contactCount;
            this.deleted = deleted;
        }

        public FarmInfo(int farmId, string farmName, MailingPlanInfo mailingPlan, List<PlotInfo> plots, DateTime createDate, int userId, Int32 plotCount, Int32 contactCount, DateTime lastModifyDate, int lastModifyBy, bool deleted)
        {
            this.farmId = farmId;
            this.farmName = farmName;
            this.mailingPlan = mailingPlan;
            this.plots = plots;
            this.createDate = createDate;
            this.userId = userId;
            this.plotCount = plotCount;
            this.contactCount = contactCount;
            this.lastModifyDate = lastModifyDate;
            this.lastModifyBy = lastModifyBy;
            this.deleted = deleted;
        }

        public FarmInfo(int farmId, string farmName, MailingPlanInfo mailingPlan, DateTime createDate,int userId)
        {
            this.farmId = farmId;
            this.farmName = farmName;
            this.mailingPlan = mailingPlan;
            this.createDate = createDate;
            this.userId = userId;
        }

        public FarmInfo(int farmId, string farmName, MailingPlanInfo mailingPlan, DateTime createDate, int userId, DateTime lastModifyDate, int lastModifyBy, bool deleted)
        {
            this.farmId = farmId;
            this.farmName = farmName;
            this.mailingPlan = mailingPlan;
            this.createDate = createDate;
            this.userId = userId;
            this.lastModifyDate = lastModifyDate;
            this.lastModifyBy = lastModifyBy;
            this.deleted = deleted;
        }

        public FarmInfo(int farmId, string farmName, DateTime createDate, int userId)
        {
            this.farmId = farmId;
            this.farmName = farmName;
            this.createDate = createDate;
            this.userId = userId;
        }

        public FarmInfo(int farmId, string farmName, DateTime createDate, int userId, DateTime lastModifyDate, int lastModifyBy, bool deleted)
        {
            this.farmId = farmId;
            this.farmName = farmName;
            this.createDate = createDate;
            this.userId = userId;
            this.lastModifyDate = lastModifyDate;
            this.lastModifyBy = lastModifyBy;
            this.deleted = deleted;
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

        public MailingPlanInfo MailingPlan
        {
            get
            {
                return mailingPlan;
            }
            set
            {
                mailingPlan = value;
            }
        }

        public List<PlotInfo> Plots
        {
            get
            {
                return plots;
            }
            set
            {
                plots = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }
            set
            {
                createDate = value;
            }
        }

        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public DateTime LastModifyDate
        {
            get
            {
                return lastModifyDate;
            }
            set
            {
                lastModifyDate = value;
            }
        }

        public int LastModifyBy
        {
            get
            {
                return lastModifyBy;
            }
            set
            {
                lastModifyBy = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return deleted;
            }
            set
            {
                deleted = value;
            }
        }

        public bool Firmup
        {
            get
            {
                return firmup;
            }
            set
            {
                firmup = value;
            }
        }

        public Int32 PlotCount
        {
            get
            {
                return plotCount;
            }
            set
            {
                plotCount = value;
            }
        }

        public Int32 ContactCount
        {
            get
            {
                return contactCount;
            }
            set
            {
                contactCount = value;
            }
        }
    }
}

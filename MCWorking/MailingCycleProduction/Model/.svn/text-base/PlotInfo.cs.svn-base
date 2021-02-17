using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public enum PlotFileType
    {
        Excel = 1,
        Csv
    };

    /// <summary>
    /// Business Entity used to model Plots.
    /// </summary>
    [Serializable]
    public class PlotInfo : BaseInfo
    {
        private int plotId;
        private string plotName;
        private DateTime createDate;
        private int farmId;
        private DateTime lastModifyDate;
        private int lastModifyBy;
        private bool deleted;
        private Int32 contactCount;
        private List<ContactInfo> contacts;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PlotInfo()
        {
            //
        }

        public PlotInfo(int plotId, string plotName,List<ContactInfo> contacts)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.contacts = contacts;
        }

        public PlotInfo(int plotId, string plotName, List<ContactInfo> contacts, DateTime lastModifyDate, int lastModifyBy, bool deleted)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.contacts = contacts;
            this.lastModifyDate = lastModifyDate;
            this.lastModifyBy = lastModifyBy;
            this.deleted = deleted;
        }

        public PlotInfo(int plotId, string plotName, DateTime createDate,int farmId)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.createDate = createDate;
            this.farmId = farmId;
        }

        public PlotInfo(int plotId, string plotName, DateTime createDate, int farmId, DateTime lastModifyDate, int lastModifyBy, bool deleted)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.createDate = createDate;
            this.farmId = farmId;
            this.lastModifyDate = lastModifyDate;
            this.lastModifyBy = lastModifyBy;
            this.deleted = deleted;
        }

        public PlotInfo(int plotId, string plotName, DateTime createDate, int farmId, int contactCount)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.createDate = createDate;
            this.farmId = farmId;
            this.contactCount = contactCount;
        }

        public PlotInfo(int plotId, string plotName, DateTime createDate, int farmId, int contactCount, bool deleted)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.createDate = createDate;
            this.farmId = farmId;
            this.contactCount = contactCount;
            this.deleted = deleted;
        }

        public PlotInfo(int plotId, string plotName, DateTime createDate, int farmId, int contactCount, DateTime lastModifyDate, int lastModifyBy, bool deleted)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.createDate = createDate;
            this.farmId = farmId;
            this.contactCount = contactCount;
            this.lastModifyDate = lastModifyDate;
            this.lastModifyBy = lastModifyBy;
            this.deleted = deleted;
        }

        public PlotInfo(int plotId, string plotName, DateTime createDate, int farmId, int contactCount, List<ContactInfo> contacts)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.createDate = createDate;
            this.farmId = farmId;
            this.contactCount = contactCount;
            this.contacts = contacts;
        }

        public PlotInfo(int plotId, string plotName, DateTime createDate, int farmId, int contactCount, List<ContactInfo> contacts, DateTime lastModifyDate, int lastModifyBy, bool deleted)
        {
            this.plotId = plotId;
            this.plotName = plotName;
            this.createDate = createDate;
            this.farmId = farmId;
            this.contactCount = contactCount;
            this.contacts = contacts;
            this.lastModifyDate = lastModifyDate;
            this.lastModifyBy = lastModifyBy;
            this.deleted = deleted;
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

        public List<ContactInfo> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                contacts = value;
            }
        }

    }
}

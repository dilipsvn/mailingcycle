using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public class FarmDetailsReportInfo : BaseInfo
    {
        private int farmId;
        private string farmName = string.Empty;
        private string plotName = string.Empty;
        private Int64 contactId;
        private int scheduleNumber;
        private string ownerFullName = string.Empty;
        private int lot;
        private string block;
        private string subdivision = string.Empty;
        private string filing;
        private string siteAddress;
        private int bedrooms;
        private int fullBath;
        private int threeQuarterBath;
        private int halfBath;
        private float acres;
        private string actMktComb;
        private string ownerFirstName;
        private string ownerLastName;
        private string ownerAddress1;
        private string ownerAddress2;
        private string ownerCity;
        private string ownerState;
        private string ownerZip;
        private string ownerCountry;
        private DateTime saleDate;
        private decimal transAmount;
        private DateTime createDate;
        private DateTime lastModifyDate;
        private int lastModifyBy;
        private int plotId;
        private bool deleted;
        /// <summary>
            /// Default constructor.
        /// </summary>
        public FarmDetailsReportInfo()
        {
            //
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="farmName">Farm Name</param>
        /// <param name="plotName">PlotName</param>
        /// <param name="plotId">Plot Id</param>
        /// <param name="contactId">Unique Id No for a contact</param>
        /// <param name="scheduleNumber">User defined farm related code</param>
        /// <param name="ownerFullName">Full name of the Owner</param>
        /// <param name="lot">lot number for Agent Identification</param>
        /// <param name="block">block for the property</param>
        /// <param name="subdivision"></param>
        /// <param name="filing"></param>
        /// <param name="siteAddress"></param>
        /// <param name="bedrooms"></param>
        /// <param name="fullBath"></param>
        /// <param name="threeQuarterBath"></param>
        /// <param name="halfBath"></param>
        /// <param name="acres"></param>
        /// <param name="actMktComb"></param>
        /// <param name="ownerFirstName">First Name</param>
        /// <param name="ownerLastName">Last Name</param>
        /// <param name="ownerAddress1">Address Line1</param>
        /// <param name="ownerAddress2">Address Line2</param>
        /// <param name="ownerCity">City</param>
        /// <param name="ownerState">State</param>
        /// <param name="ownerZip">Zip</param>
        /// <param name="ownerCountry">Country</param>
        /// <param name="saleDate">Date of Sale</param>
        /// <param name="transAmount">Transaction Amount</param>
        /// <param name="createDate">Contact Creation Date</param>
        /// <param name="lastModifyDate">Contact Modified Date</param>
        /// <param name="lastModifyBy">Contact Modified by User</param>
        /// <param name="deleted">Plot Deleted Status</param>
        public FarmDetailsReportInfo(int farmId,string farmName,int plotId,string plotName,
            Int64 contactId, int scheduleNumber, string ownerFullName, int lot,
            string block, string subdivision, string filing, string siteAddress,
            int bedrooms, int fullBath, int threeQuarterBath, int halfBath,
            float acres, string actMktComb, string ownerFirstName, string ownerLastName, 
            string ownerAddress1,string ownerAddress2,string ownerCity,string ownerState,
            string ownerZip,string ownerCountry,DateTime saleDate,decimal transAmount,
            DateTime createDate,DateTime lastModifyDate, int lastModifyBy,bool deleted)
        {
            this.farmId = farmId;
            this.farmName = farmName;
            this.plotId = plotId;
            this.plotName = plotName;
            this.contactId = contactId;
            this.scheduleNumber=scheduleNumber;
            this.ownerFullName =ownerFullName;
            this.lot = lot;
            this.block = block;
            this.subdivision=subdivision;
            this.filing = filing;
            this.siteAddress = siteAddress;
            this.bedrooms = bedrooms ;
            this.fullBath =fullBath ;
            this.threeQuarterBath =threeQuarterBath;
            this.halfBath =halfBath;
            this.acres =acres ;
            this.actMktComb =actMktComb;
            this.ownerFirstName =ownerFirstName;
            this.ownerLastName =ownerLastName;
            this.ownerAddress1 =ownerAddress1;
            this.ownerAddress2 = ownerAddress2;
            this.ownerCity = ownerCity;
            this.ownerState = ownerState;
            this.ownerZip = ownerZip;
            this.ownerCountry = ownerCountry;
            this.saleDate =saleDate;
            this.transAmount =transAmount;
            this.createDate=createDate;
            this.lastModifyDate =lastModifyDate;
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

        public int ScheduleNumber
        {
            get
            {
                return scheduleNumber;
            }
            set
            {
                scheduleNumber = value;
            }
        }


        public string OwnerFullName
        {
            get
            {
                return ownerFullName;
            }
            set
            {
                ownerFullName = value;
            }
        }

        public int Lot
        {
            get
            {
                return lot;
            }
            set
            {
                lot = value;
            }
        }


        public string Block
        {
            get
            {
                return block;
            }
            set
            {
                block = value;
            }
        }

        public string Subdivision
        {
            get
            {
                return subdivision;
            }
            set
            {
                subdivision = value;
            }
        }

        public string Filing
        {
            get
            {
                return filing;
            }
            set
            {
                filing = value;
            }
        }

        public string SiteAddress
        {
            get
            {
                return siteAddress;
            }
            set
            {
                siteAddress = value;
            }
        }

        public int Bedrooms
        {
            get
            {
                return bedrooms;
            }
            set
            {
                bedrooms = value;
            }
        }

        public int FullBath
        {
            get
            {
                return fullBath;
            }
            set
            {
                fullBath = value;
            }
        }

        public int ThreeQuarterBath
        {
            get
            {
                return threeQuarterBath;
            }
            set
            {
                threeQuarterBath = value;
            }
        }

        public int HalfBath
        {
            get
            {
                return halfBath;
            }
            set
            {
                halfBath = value;
            }
        }

        public float Acres
        {
            get
            {
                return acres;
            }
            set
            {
                acres = value;
            }
        }

        public string ActMktComb
        {
            get
            {
                return actMktComb;
            }
            set
            {
                actMktComb = value;
            }
        }

        public string OwnerFirstName
        {
            get
            {
                return ownerFirstName;
            }
            set
            {
                ownerFirstName = value;
            }
        }

        public string OwnerLastName
        {
            get
            {
                return ownerLastName;
            }
            set
            {
                ownerLastName = value;
            }
        }

        public string OwnerAddress1
        {
            get
            {
                return ownerAddress1;
            }
            set
            {
                ownerAddress1 = value;
            }
        }

        public string OwnerAddress2
        {
            get
            {
                return ownerAddress2;
            }
            set
            {
                ownerAddress2 = value;
            }
        }

        public string OwnerCity
        {
            get
            {
                return ownerCity;
            }
            set
            {
                ownerCity = value;
            }
        }

        public string OwnerState
        {
            get
            {
                return ownerState;
            }
            set
            {
                ownerState = value;
            }
        }

        public string OwnerZip
        {
            get
            {
                return ownerZip;
            }
            set
            {
                ownerZip = value;
            }
        }

        public string OwnerCountry
        {
            get
            {
                return ownerCountry;
            }
            set
            {
                ownerCountry = value;
            }
        }

        public DateTime SaleDate
        {
            get
            {
                return saleDate;
            }
            set
            {
                saleDate = value;
            }
        }

        public decimal TransAmount
        {
            get
            {
                return transAmount;
            }
            set
            {
                transAmount = value;
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
    }
}

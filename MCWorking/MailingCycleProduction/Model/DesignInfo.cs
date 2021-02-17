using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Irmac.MailingCycle.Model
{
    public enum DesignCategory
    {
        PowerKard = 17,
        Brochure
    };

    public enum DesignType
    {
        Standard = 19,
        Custom
    };

    public enum JustificationType
    {
        None = 0,
        Left,
        Right,
        Center
    };

    public enum DesignStatus
    {
        NotUploaded = 21,
        Uploaded,
        Submitted,
        Hold,
        Inactivated,
        Approved
    };

    public enum DesignUsed
    {
        Never = 0,
        Found,
        FoundActive
    };

    /// <summary>
    /// Business Entity used to model Designs.
    /// </summary>
    [Serializable]
    public class DesignInfo : BaseInfo
    {
        private int designId = 0;
        private int userId = 0;
        private LookupInfo category;
        private LookupInfo type;
        private SizeF size = new SizeF(0, 0);
        private string gender = string.Empty;
        private string onDesignName = string.Empty;
        private JustificationType justification = JustificationType.None;
        private string gutter = string.Empty;
        private RectangleF messageRectangle = new RectangleF(0, 0, 0, 0);
        private string lowResolutionFile = string.Empty;
        private string highResolutionFile = string.Empty;
        private string extraFile = string.Empty;
        private LookupInfo status;
        private DateTime createDate;
        private DateTime lastModifyDate;
        private int lastModifyBy;
        private DateTime approveDate;
        private int approveBy;
        private string comments;
        private string history;
        private DesignUsed used = DesignUsed.Never;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DesignInfo()
        {
            //
        }

        /// <summary>
        /// Constructor with the specified initial values.
        /// </summary>
        /// <param name="designId">Internal identifier of the design.</param>
        /// <param name="category">Category of the design.</param>
        /// <param name="type">Type of the design.</param>
        /// <param name="size">Size of the design.</param>
        /// <param name="lowResolutionFile">Low resolution file location of the 
        /// design.</param>
        /// <param name="status">Status of the design.</param>
        public DesignInfo(int designId, LookupInfo category, LookupInfo type, SizeF size,
            string lowResolutionFile, LookupInfo status)
        {
            this.designId = designId;
            this.category = category;
            this.type = type;
            this.size = size;
            this.lowResolutionFile = lowResolutionFile;
            this.status = status;
        }

        /// <summary>
        /// Constructor with the specified initial values.
        /// </summary>
        /// <param name="designId">Internal identifier of the design.</param>
        /// <param name="userId">Internal identifier of the agent.</param>
        /// <param name="category">Category of the design.</param>
        /// <param name="type">Type of the design.</param>
        /// <param name="size">Size of the design.</param>
        /// <param name="gender">Gender of the Agent that should be used for the
        /// message on the design.</param>
        /// <param name="onDesignName">Name of the Agent that should be used for the
        /// message on the design.</param>
        /// <param name="justification">Justification of the message on the 
        /// design.</param>
        /// <param name="gutter">Gutter of the message on the design.</param>
        /// <param name="messageRectangle">The rectangle in which the message should be
        /// displayed on the design.</param>
        /// <param name="lowResolutionFile">Low resolution file location of the 
        /// design.</param>
        /// <param name="highResolutionFile">High resolution file location of the 
        /// design.</param>
        /// <param name="extraFile">Extra file location of the design.</param>
        /// <param name="status">Status of the design.</param>
        /// <param name="createDate">Created date of the design.</param>
        /// <param name="lastModifyDate">Last modified date of the design.</param>
        /// <param name="lastModifyBy">The internal idetifier of the user that recently
        /// modified the design.</param>
        /// <param name="approveDate">Date on which the design is approved.</param>
        /// <param name="approveBy">The internal idetifier of the user that approved
        /// the design.</param>
        /// <param name="comments">Comments about the design.</param>
        /// <param name="history">History of the design.</param>
        /// <param name="used">Usage status of the design.</param>
        public DesignInfo(int designId, int userId, LookupInfo category, LookupInfo type, 
            SizeF size, string gender, string onDesignName, JustificationType justification, 
            string gutter, RectangleF messageRectangle, string lowResolutionFile, 
            string highResolutionFile, string extraFile, LookupInfo status, 
            DateTime createDate, DateTime lastModifyDate, int lastModifyBy,
            DateTime approveDate, int approveBy, string comments, string history,
            DesignUsed used)
        {
            this.designId = designId;
            this.userId = userId;
            this.category = category;
            this.type = type;
            this.size = size;
            this.gender = gender;
            this.onDesignName = onDesignName;
            this.justification = justification;
            this.gutter = gutter;
            this.messageRectangle = messageRectangle;
            this.lowResolutionFile = lowResolutionFile;
            this.highResolutionFile = highResolutionFile;
            this.extraFile = extraFile;
            this.status = status;
            this.createDate = createDate;
            this.lastModifyDate = lastModifyDate;
            this.lastModifyBy = lastModifyBy;
            this.approveDate = approveDate;
            this.approveBy = approveBy;
            this.comments = comments;
            this.history = history;
            this.used = used;
        }

        public int DesignId
        {
            get
            {
                return designId;
            }
            set
            {
                designId = value;
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

        public LookupInfo Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public LookupInfo Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public SizeF Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public string OnDesignName
        {
            get
            {
                return onDesignName;
            }
            set
            {
                onDesignName = value;
            }
        }

        public JustificationType Justification
        {
            get
            {
                return justification;
            }
            set
            {
                justification = value;
            }
        }

        public string Gutter
        {
            get
            {
                return gutter;
            }
            set
            {
                gutter = value;
            }
        }

        public RectangleF MessageRectangle
        {
            get
            {
                return messageRectangle;
            }
            set
            {
                messageRectangle = value;
            }
        }

        public string LowResolutionFile
        {
            get
            {
                return lowResolutionFile;
            }
            set
            {
                lowResolutionFile = value;
            }
        }

        public string HighResolutionFile
        {
            get
            {
                return highResolutionFile;
            }
            set
            {
                highResolutionFile = value;
            }
        }

        public string ExtraFile
        {
            get
            {
                return extraFile;
            }
            set
            {
                extraFile = value;
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

        public DateTime ApproveDate
        {
            get
            {
                return approveDate;
            }
            set
            {
                approveDate = value;
            }
        }

        public int ApproveBy
        {
            get
            {
                return approveBy;
            }
            set
            {
                approveBy = value;
            }
        }

        public string Comments
        {
            get
            {
                return comments;
            }
            set
            {
                comments = value;
            }
        }

        public string History
        {
            get
            {
                return history;
            }
            set
            {
                history = value;
            }
        }

        public DesignUsed Used
        {
            get
            {
                return used;
            }
            set
            {
                used = value;
            }
        }
    }
}

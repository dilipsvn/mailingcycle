using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
	/// <summary>
	/// Business Entity used to model Mailing Plans.
	/// </summary>
	[Serializable]
	public class MailingPlanInfo : BaseInfo
	{
        private int mailingPlanId;
        private string title;
        private DateTime createDate;
        
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MailingPlanInfo()
		{
			//
		}

		/// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
        /// <param name="mailingPlanId">Internal identifier of the mailing plan</param>
        /// <param name="title">Title of the mailing plan</param>
        public MailingPlanInfo(int mailingPlanId, string title)
		{
            this.mailingPlanId = mailingPlanId;
            this.title = title;
		}

        /// <summary>
        /// Constructor with the specified initial values.
        /// </summary>
        /// <param name="mailingPlanId">Internal identifier of the mailing plan</param>
        /// <param name="title">Title of the mailing plan</param>
        /// <param name="createDate">Start Date of the mailing plan</param>
        public MailingPlanInfo(int mailingPlanId, string title, DateTime createDate)
        {
            this.mailingPlanId = mailingPlanId;
            this.title = title;
            this.createDate = createDate;
        }

        public int MailingPlanId
		{
			get
			{
                return mailingPlanId;
			}
            set
            {
                mailingPlanId = value;
            }
		}

        public string Title
		{
			get
			{
				return title;
			}
            set
            {
                title = value;
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
	}
}

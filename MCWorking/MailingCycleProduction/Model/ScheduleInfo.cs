using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Irmac.MailingCycle.Model
{
    public enum PlanType
    {
        Active,
        Completed
    };

    /// <summary>
    /// Business Entity used to model Schedules.
    /// </summary>
    [Serializable]
    public class ScheduleInfo : BaseInfo
    {
        private int scheduleId = 0;
        private int farmId = 0;
        private string farmName = string.Empty;
        private MailingPlanInfo plan = new MailingPlanInfo();
        private DateTime startDate;
        private DateTime endDate;
        private int numberOfPlots = 0;
        private int numberOfContacts = 0;
        private List<ScheduleEventInfo> events = new List<ScheduleEventInfo>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ScheduleInfo()
        {
            //
        }

        /// <summary>
        /// Constructor with the specified initial values.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="farmName">Name of the farm.</param>
        /// <param name="plan">Plan of the schedule.</param>
        /// <param name="startDate">Start date of the plan.</param>
        /// <param name="endDate">End date of the plan.</param>
        /// <param name="numberOfPlots">Number of the plots that are part of the
        /// schedule.</param>
        /// <param name="numberOfContacts">Number of the contacts that are part of the
        /// schedule.</param>
        /// <param name="scheduleId">Internal identifier of the schedule.</param>
        public ScheduleInfo(int farmId, string farmName, MailingPlanInfo plan,
            DateTime startDate, DateTime endDate, int numberOfPlots,
            int numberOfContacts, int scheduleId)
        {
            this.farmId = farmId;
            this.farmName = farmName;
            this.plan = plan;
            this.startDate = startDate;
            this.endDate = endDate;
            this.numberOfPlots = numberOfPlots;
            this.numberOfContacts = numberOfContacts;
            this.scheduleId = scheduleId;
        }

        public int ScheduleId
        {
            get
            {
                return scheduleId;
            }
            set
            {
                scheduleId = value;
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

        public MailingPlanInfo Plan
        {
            get
            {
                return plan;
            }
            set
            {
                plan = value;
            }
        }

        public DateTime StartDate
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

        public DateTime EndDate
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

        public List<ScheduleEventInfo> Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
            }
        }
    }
}

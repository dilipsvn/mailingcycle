using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.BLL
{
    /// <summary>
    /// A Business Component used to manage Schedule Utilities.
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Get the list of schedule events for the specified mailing plan.
        /// </summary>
        /// <param name="planId">Internal identifier of the mailing plan.</param>
        /// <param name="startDate">Date on which the mailing plan starts.</param>
        /// <returns>List of schedule events for the specified mailing plan.</returns>
        public List<ScheduleEventInfo> GetPlanEvents(int planId, DateTime startDate)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            List<ScheduleEventInfo> events = dao.GetPlanEvents(planId, startDate);

            return events;
        }

        /// <summary>
        /// Get the mailing plans of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="planType">Type of the plans that need to be fetched.</param>
        /// <returns>Mailing plans of the specified user.</returns>
        public List<ScheduleInfo> GetMailingPlans(int userId, PlanType planType)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            List<ScheduleInfo> schedules = dao.GetMailingPlans(userId, planType);

            return schedules;
        }

        /// <summary>
        /// Gets the scheduled events of the specified schedule.
        /// </summary>
        /// <param name="scheduleId">Internal identifier of the schedule.</param>
        /// <returns>Scheduled events of the specified schedule.</returns>
        public ScheduleInfo GetEvents(int scheduleId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            ScheduleInfo schedule = dao.GetEvents(scheduleId);

            return schedule;
        }

        /// <summary>
        /// Gets the scheduled entries of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Scheduled entries of the specified event.</returns>
        public ScheduleInfo GetEventEntries(int eventId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            ScheduleInfo schedule = dao.GetEventEntries(eventId);

            return schedule;
        }

        /// <summary>
        /// Updates the postal tariff of the specified mailing event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="postalTariff">Postal tariff of the mailing event.</param>
        /// <param name="notes">Notes of the mailing event.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void UpdatePostalTariff(int eventId, string postalTariff, string notes,
            int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            try
            {
                dao.UpdatePostalTariff(eventId, postalTariff, notes, userId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Cancels the specified scheduled event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="notes">Notes of the mailing event.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void CancelEvent(int eventId, string notes, int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            try
            {
                dao.CancelEvent(eventId, notes, userId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Completes the specified scheduled event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="mailingListFile">Mailing list file of the mailing event.</param>
        /// <param name="remarks">Remarks of the mailing event.</param>
        /// <param name="mailingCount">Mailing count of the mailing event.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void CompleteEvent(int eventId, string mailingListFile, string remarks,
            int mailingCount, int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            try
            {
                decimal refundAmount = 0;
                int refundInventory = 0;

                // Get the schedule event details.
                ScheduleInfo schedule = dao.GetEventEntries(eventId);

                DesignCategory designCategory = 
                    (DesignCategory)schedule.Events[0].ProductType.LookupId;
                string postalTariff = schedule.Events[0].PostalTariff;
                int numberOfContacts = schedule.Events[0].NumberOfContacts;
                int orderId = schedule.Events[0].OrderId;
                int orderValue = schedule.Events[0].OrderValue;

                // Check whether there are any discripencies in mail quantity.
                if (numberOfContacts != mailingCount)
                {
                    refundInventory = numberOfContacts - mailingCount;
                    refundAmount = orderValue -
                        (AccaProcess.CalculateAmount(designCategory, postalTariff, mailingCount));
                }

                dao.CompleteEvent(eventId, mailingListFile, remarks, mailingCount,
                    orderId, refundAmount, designCategory, refundInventory, userId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the scheduled event entry details of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <returns>Scheduled event entry details of the specified event.</returns>
        public ScheduleInfo GetEventEntry(int eventId, int plotId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            ScheduleInfo schedule = dao.GetEventEntry(eventId, plotId);

            return schedule;
        }

        /// <summary>
        /// Get the active custom messages of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Active custom messages of the specified user.</returns>
        public List<MessageInfo> GetActiveCustomMessages(int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            List<MessageInfo> messages = dao.GetActiveCustomMessages(userId);

            return messages;
        }

        /// <summary>
        /// Gets the details of the specified message.
        /// </summary>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <returns>Details of the specified message.</returns>
        public MessageInfo GetMessage(int messageId, int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            MessageInfo message = dao.GetMessage(messageId);

            if (!message.IsImage)
            {
                // Get the agent's PowerKard design attributes.
                Design design = new Design();
                string onDesignName = string.Empty;
                string gender = string.Empty;

                List<DesignInfo> designs = design.GetList(userId);

                foreach (DesignInfo designInfo in designs)
                {
                    if (designInfo.Category.Name == "PowerKard" && designInfo.DesignId > 0)
                    {
                        DesignInfo powerKard = design.Get(designInfo.DesignId);

                        onDesignName = powerKard.OnDesignName;
                        gender = powerKard.Gender;

                        break;
                    }
                }

                if (onDesignName != "" && gender != "")
                {
                    message.MessageText = Message.RenderMessage(message.MessageText,
                        gender, onDesignName);
                }
            }

            return message;
        }

        /// <summary>
        /// Inserts the event entry of the specified mailing event.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void InsertEventEntry(int farmId, int plotId, int eventId, int messageId,
            int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            try
            {
                dao.InsertEventEntry(farmId, plotId, eventId, messageId, userId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the event entry of the specified mailing event.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void UpdateEventEntry(int farmId, int plotId, int eventId, int messageId,
            int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            try
            {
                dao.UpdateEventEntry(farmId, plotId, eventId, messageId, userId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the design details of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Design details of the specified event.</returns>
        public DesignInfo GetDesign(int eventId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            DesignInfo design = dao.GetDesign(eventId);

            return design;
        }

        /// <summary>
        /// Gets the summary of schedules.
        /// </summary>
        /// <returns>Summary of schedules.</returns>
        public DataTable GetSummary()
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            DataTable summary = dao.GetSummary();

            return summary;
        }

        /// <summary>
        /// Gets the summary of schedules of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Summary of schedules of the specified user.</returns>
        public DataTable GetSummary(int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            DataTable summary = dao.GetSummary(userId);

            return summary;
        }

        /// <summary>
        /// Gets a value indicating whether the specified farm is active.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <returns>true if the specified farm is currently active; 
        /// otherwise, false.</returns>
        public bool IsActive(int farmId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            bool isActive = dao.IsActive(farmId);

            return isActive;
        }

        /// <summary>
        /// Firms up the specified farm.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="planId">Internal identifier of the mailing plan.</param>
        /// <param name="startDate">Date on which the mailing plan starts.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void FirmUp(int farmId, int planId, DateTime startDate, int userId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            try
            {
                dao.FirmUp(farmId, planId, startDate, userId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the summary of schedules report of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="reportType">Type of the events that needs to be displayed.</param>
        /// <param name="mailingPlan">Type of the plans that needs to be included.</param>
        /// <param name="startDate">Start Date of the specified date range.</param>
        /// <param name="endDate">End Date of the specified date range.</param>
        /// <returns>Summary of schedules report of the specified user.</returns>
        public List<ScheduleSummaryInfo> GetSchedulesReportSummary(int userId, string reportType,
            string mailingPlan, string startDate, string endDate)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            List<ScheduleSummaryInfo> schedules = dao.GetSchedulesReportSummary(userId, reportType,
                mailingPlan, startDate, endDate);

            return schedules;
        }

        /// <summary>
        /// Gets the summary of schedule events report for the specified parameters.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="planType">Type of the plans that needs to be included.</param>
        /// <param name="eventType">Type of the events that needs to be displayed.</param>
        /// <param name="startDate">Start Date of the specified date range.</param>
        /// <param name="endDate">End Date of the specified date range.</param>
        /// <param name="urlPath">Location of the design file.</param>
        /// <returns>Summary of schedule events report for the specified parameters.</returns>
        public List<ScheduleSummaryInfo> GetScheduleEventsReportSummary(int userId,
            string planType, string eventType, string startDate, string endDate,
            string urlPath)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            List<ScheduleSummaryInfo> schedules = 
                dao.GetScheduleEventsReportSummary(userId, planType, eventType, 
                startDate, endDate, urlPath);

            return schedules;
        }

        /// <summary>
        /// Get the list of contacts of the specified schedule event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>List of contacts of the specified schedule event.</returns>
        public List<ScheduleEventContactInfo> GetScheduleEventContacts(int eventId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            List<ScheduleEventContactInfo> contacts = 
                dao.GetScheduleEventContacts(eventId);

            return contacts;
        }

        /// <summary>
        /// Gets the mailing labels for the specified schedule event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Mailing labels for the specified schedule event.</returns>
        public List<ScheduleEventMailingLabelInfo> GetMailingLabels(int eventId)
        {
            // Get an instance of the Schedule DAO using the DALFactory
            ISchedule dao = (ISchedule)DALFactory.DAO.Create(DALFactory.Module.Schedule);

            List<ScheduleEventMailingLabelInfo> mailingLabels =
                dao.GetMailingLabels(eventId);

            return mailingLabels;
        }
    }
}

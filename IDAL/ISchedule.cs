using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Irmac.MailingCycle.Model;

namespace Irmac.MailingCycle.IDAL
{
    /// <summary>
    /// Interface for the Schedule DAL.
    /// </summary>
    public interface ISchedule
    {
        /// <summary>
        /// Get the list of schedule events for the specified mailing plan.
        /// </summary>
        /// <param name="planId">Internal identifier of the mailing plan.</param>
        /// <param name="startDate">Date on which the mailing plan starts.</param>
        /// <returns>List of schedule events for the specified mailing plan.</returns>
        List<ScheduleEventInfo> GetPlanEvents(int planId, DateTime startDate);

        /// <summary>
        /// Get the mailing plans of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="planType">Type of the plans that need to be fetched.</param>
        /// <returns>Mailing plans of the specified user.</returns>
        List<ScheduleInfo> GetMailingPlans(int userId, PlanType planType);

        /// <summary>
        /// Gets the scheduled events of the specified schedule.
        /// </summary>
        /// <param name="scheduleId">Internal identifier of the schedule.</param>
        /// <returns>Scheduled events of the specified schedule.</returns>
        ScheduleInfo GetEvents(int scheduleId);

        /// <summary>
        /// Gets the scheduled entries of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Scheduled entries of the specified event.</returns>
        ScheduleInfo GetEventEntries(int eventId);

        /// <summary>
        /// Updates the postal tariff of the specified mailing event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="postalTariff">Postal tariff of the mailing event.</param>
        /// <param name="notes">Notes of the mailing event.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        void UpdatePostalTariff(int eventId, string postalTariff, string notes, 
            int userId);

        /// <summary>
        /// Cancels the specified scheduled event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="notes">Notes of the mailing event.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        void CancelEvent(int eventId, string notes, int userId);

        /// <summary>
        /// Completes the specified scheduled event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="mailingListFile">Mailing list file of the mailing event.</param>
        /// <param name="remarks">Remarks of the mailing event.</param>
        /// <param name="mailingCount">Mailing count of the mailing event.</param>
        /// <param name="orderId">Internal identifier of the order.</param>
        /// <param name="refundAmount">Refund amount for the mailing event.</param>
        /// <param name="designCategory">Product type used in the event.</param>
        /// <param name="refundInventory">Invetory that need to be refunded.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        void CompleteEvent(int eventId, string mailingListFile, string remarks,
            int mailingCount, int orderId, decimal refundAmount,
            DesignCategory designCategory, int refundInventory, 
            int userId);

        /// <summary>
        /// Gets the scheduled event entry details of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <returns>Scheduled event entry details of the specified event.</returns>
        ScheduleInfo GetEventEntry(int eventId, int plotId);

        /// <summary>
        /// Get the active custom messages of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Active custom messages of the specified user.</returns>
        List<MessageInfo> GetActiveCustomMessages(int userId);

        /// <summary>
        /// Gets the details of the specified message.
        /// </summary>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <returns>Details of the specified message.</returns>
        MessageInfo GetMessage(int messageId);

        /// <summary>
        /// Inserts the event entry of the specified mailing event.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        void InsertEventEntry(int farmId, int plotId, int eventId, int messageId,
            int userId);

        /// <summary>
        /// Updates the event entry of the specified mailing event.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="messageId">Internal identifier of the message.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        void UpdateEventEntry(int farmId, int plotId, int eventId, int messageId,
            int userId);

        /// <summary>
        /// Gets the design details of the specified event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Design details of the specified event.</returns>
        DesignInfo GetDesign(int eventId);

        /// <summary>
        /// Gets the summary of schedules.
        /// </summary>
        /// <returns>Summary of schedules.</returns>
        DataTable GetSummary();

        /// <summary>
        /// Gets the summary of schedules of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Summary of schedules of the specified user.</returns>
        DataTable GetSummary(int userId);

        /// <summary>
        /// Gets a value indicating whether the specified farm is active.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <returns>true if the specified farm is currently active; 
        /// otherwise, false.</returns>
        bool IsActive(int farmId);

        /// <summary>
        /// Firms up the specified farm.
        /// </summary>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="planId">Internal identifier of the mailing plan.</param>
        /// <param name="startDate">Date on which the mailing plan starts.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        void FirmUp(int farmId, int planId, DateTime startDate, int userId);

        /// <summary>
        /// Gets the summary of schedules report of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="reportType">Type of the events that needs to be displayed.</param>
        /// <param name="mailingPlan">Type of the plans that needs to be included.</param>
        /// <param name="startDate">Start Date of the specified date range.</param>
        /// <param name="endDate">End Date of the specified date range.</param>
        /// <returns>Summary of schedules report of the specified user.</returns>
        List<ScheduleSummaryInfo> GetSchedulesReportSummary(int userId, string reportType,
            string mailingPlan, string startDate, string endDate);

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
        List<ScheduleSummaryInfo> GetScheduleEventsReportSummary(int userId,
            string planType, string eventType, string startDate, string endDate,
            string urlPath);

        /// <summary>
        /// Get the list of contacts of the specified schedule event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>List of contacts of the specified schedule event.</returns>
        List<ScheduleEventContactInfo> GetScheduleEventContacts(int eventId);

        /// <summary>
        /// Gets the mailing labels for the specified schedule event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Mailing labels for the specified schedule event.</returns>
        List<ScheduleEventMailingLabelInfo> GetMailingLabels(int eventId);

        /// <summary>
        /// Gets the event details for the specified schedule event.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <returns>Event details for the specified schedule event.</returns>
        ScheduleSummaryInfo GetEventSummary(int eventId);

        /// <summary>
        /// Gets the event entry details for the specified schedule event entry.
        /// </summary>
        /// <param name="eventId">Internal identifier of the event.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <returns>Event entry details for the specified schedule event entry.</returns>
        ScheduleSummaryInfo GetEventEntrySummary(int eventId, int plotId);
    }
}

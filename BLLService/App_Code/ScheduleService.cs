using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;

/// <summary>
/// A Service Component used to manage Schedule Utilities.
/// </summary>
[WebService(Namespace = "http://irmac.com/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ScheduleService : System.Web.Services.WebService
{
    public ScheduleService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<ScheduleEventInfo> GetPlanEvents(int planId, DateTime startDate)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        List<ScheduleEventInfo> events = bll.GetPlanEvents(planId, startDate);

        return events;
    }

    [WebMethod]
    public List<ScheduleInfo> GetMailingPlans(int userId, PlanType planType)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        List<ScheduleInfo> schedules = bll.GetMailingPlans(userId, planType);

        return schedules;
    }

    [WebMethod]
    public ScheduleInfo GetEvents(int scheduleId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        ScheduleInfo schedule = bll.GetEvents(scheduleId);

        return schedule;
    }

    [WebMethod]
    public ScheduleInfo GetEventEntries(int eventId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        ScheduleInfo schedule = bll.GetEventEntries(eventId);

        return schedule;
    }

    [WebMethod]
    public void UpdatePostalTariff(int eventId, string postalTariff, string notes,
        int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        bll.UpdatePostalTariff(eventId, postalTariff, notes, userId);
    }

    [WebMethod]
    public void CancelEvent(int eventId, string notes, int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        bll.CancelEvent(eventId, notes, userId);
    }

    [WebMethod]
    public void CompleteEvent(int eventId, string mailingListFile, string remarks,
        int mailingCount, int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        bll.CompleteEvent(eventId, mailingListFile, remarks, mailingCount, userId);
    }

    [WebMethod]
    public ScheduleInfo GetEventEntry(int eventId, int plotId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        ScheduleInfo schedule = bll.GetEventEntry(eventId, plotId);

        return schedule;
    }

    [WebMethod]
    public List<MessageInfo> GetActiveCustomMessages(int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        List<MessageInfo> messages = bll.GetActiveCustomMessages(userId);

        return messages;
    }

    [WebMethod]
    public MessageInfo GetMessage(int messageId, int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        MessageInfo message = bll.GetMessage(messageId, userId);

        return message;
    }

    [WebMethod]
    public void InsertEventEntry(int farmId, int plotId, int eventId, int messageId,
        int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        bll.InsertEventEntry(farmId, plotId, eventId, messageId, userId);
    }

    [WebMethod]
    public void UpdateEventEntry(int farmId, int plotId, int eventId, int messageId,
        int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        bll.UpdateEventEntry(farmId, plotId, eventId, messageId, userId);
    }

    [WebMethod]
    public DesignInfo GetDesign(int eventId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        DesignInfo design = bll.GetDesign(eventId);

        return design;
    }

    [WebMethod]
    public object[] GetSummary()
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        DataTable summary = bll.GetSummary();

        object[] result = Util.GetArray(summary);

        return result;
    }

    [WebMethod]
    public object[] GetSummaryOfUser(int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        DataTable summary = bll.GetSummary(userId);

        object[] result = Util.GetArray(summary);

        return result;
    }

    [WebMethod]
    public bool IsActive(int farmId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        bool isActive = bll.IsActive(farmId);

        return isActive;
    }

    [WebMethod]
    public void FirmUp(int farmId, int planId, DateTime startDate, int userId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        bll.FirmUp(farmId, planId, startDate, userId);
    }

    [WebMethod]
    public List<ScheduleSummaryInfo> GetSchedulesReportSummary(int userId, string reportType,
        string mailingPlan, string startDate, string endDate)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        List<ScheduleSummaryInfo> schedules = bll.GetSchedulesReportSummary(userId, reportType,
            mailingPlan, startDate, endDate);

        return schedules;
    }

    [WebMethod]
    public List<ScheduleSummaryInfo> GetScheduleEventsReportSummary(int userId,
        string planType, string eventType, string startDate, string endDate,
        string urlPath)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        List<ScheduleSummaryInfo> schedules = bll.GetScheduleEventsReportSummary(userId, 
            planType, eventType, startDate, endDate, urlPath);

        return schedules;
    }

    [WebMethod]
    public List<ScheduleEventContactInfo> GetScheduleEventContacts(int eventId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        List<ScheduleEventContactInfo> contacts = 
            bll.GetScheduleEventContacts(eventId);

        return contacts;
    }

    [WebMethod]
    public List<ScheduleEventMailingLabelInfo> GetMailingLabels(int eventId)
    {
        // Get an instance of the Schedule BO
        Schedule bll = new Schedule();

        List<ScheduleEventMailingLabelInfo> mailingLabels =
            bll.GetMailingLabels(eventId);

        return mailingLabels;
    }
}

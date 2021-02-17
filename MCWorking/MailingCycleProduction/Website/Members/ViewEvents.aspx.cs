using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.Model;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using ScheduleService = Irmac.MailingCycle.BLLServiceLoader.Schedule;

public partial class Members_ViewEvents : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_ViewEvents));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected enum EventType
    {
        Future = 0,
        Past
    };

    private void SetHyperLink(HyperLink hyperLink, string navigateUrl)
    {
        if (navigateUrl == "")
        {
            hyperLink.Font.Bold = true;
            hyperLink.Font.Underline = false;
            hyperLink.ForeColor = Color.Black;
            hyperLink.NavigateUrl = "";
        }
        else
        {
            hyperLink.Font.Bold = false;
            hyperLink.Font.Underline = true;
            hyperLink.ForeColor = Color.Blue;
            hyperLink.NavigateUrl = navigateUrl;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        // Get the query string values.
        NameValueCollection coll = Request.QueryString;

        int id = Convert.ToInt32(coll.Get("id"));
        EventType eventType = EventType.Future;
        if (coll.Get("et") != "" && coll.Get("et") != null)
        {
            eventType = (EventType)Convert.ToInt32(coll.Get("et"));
        }
        else
        {
            if (coll.Get("ptype") != "" && coll.Get("ptype") != null)
            {
                if (Convert.ToInt32(coll.Get("ptype")) == 1)
                {
                    eventType = EventType.Past;
                }
            }
        }
        int agentId = Convert.ToInt32(coll.Get("aId"));
        string agentName = coll.Get("aName");
        int planType = Convert.ToInt32(coll.Get("ptype"));
        int pageNumber = Convert.ToInt32(coll.Get("pg"));

        // Display the agent name if one exists.
        if (agentName != "")
        {
            AgentNameLabel.Text = "Agent Name: " + agentName + "&nbsp;";
        }

        // Set the screen elements based on the type of events that are displayed.
        string queryString = "?id=" + id.ToString() +
            "&aId=" + agentId.ToString() +
            "&aName=" + agentName +
            "&et=" + (Convert.ToInt32(eventType) == 0 ? "1" : "0") +
            "&ptype=" + planType.ToString() +
            "&pg=" + pageNumber.ToString();

        if (eventType == EventType.Future)
        {
            SetHyperLink(FutureEventsHyperLink, "");
            SetHyperLink(PastEventsHyperLink, "~/Members/ViewEvents.aspx" + queryString);
        }
        else
        {
            SetHyperLink(PastEventsHyperLink, "");
            SetHyperLink(FutureEventsHyperLink, "~/Members/ViewEvents.aspx" + queryString);
        }

        LegendTitleLabel.Text = "List of " + eventType.ToString() + " Events";

        if (!IsPostBack)
        {
            // Get the logged in account information.
            RegistrationService.LoginInfo loginInfo =
                (RegistrationService.LoginInfo)Session["loginInfo"];

            // Set the required query string varables into hidden fields.
            IdHiddenField.Value = id.ToString();
            EventTypeHiddenField.Value = Convert.ToInt32(eventType).ToString();
            AgentIdHiddenField.Value = agentId.ToString();
            AgentNameHiddenField.Value = agentName;
            PlanTypeHiddenField.Value = planType.ToString();
            PageNumberHiddenField.Value = pageNumber.ToString();

            // Get the schedule details and display.
            try
            {
                ScheduleService.ScheduleService scheduleService = serviceLoader.GetSchedule();
                ScheduleService.ScheduleInfo schedule = scheduleService.GetEvents(id);

                FarmLabel.Text = schedule.FarmName;
                MailingPlanLabel.Text = schedule.Plan.Title;
                StartDateLabel.Text = schedule.StartDate.ToString("MM/dd/yyyy");
                EndDateLabel.Text = schedule.EndDate.ToString("MM/dd/yyyy");

                IList<ScheduleService.ScheduleEventInfo> events = 
                    new List<ScheduleService.ScheduleEventInfo>();

                foreach (ScheduleService.ScheduleEventInfo eve in schedule.Events)
                {
                    if (eventType == EventType.Future)
                    {
                        if (eve.EventDate >= DateTime.Today)
                        {
                            events.Add(eve);
                        }
                    }
                    else
                    {
                        if (eve.EventDate < DateTime.Today)
                        {
                            events.Add(eve);
                        }
                    }
                }

                if (eventType == EventType.Future)
                {
                    FutureEventsDataGrid.Visible = true;
                    FutureEventsDataGrid.DataSource = events;
                    FutureEventsDataGrid.DataBind();
                    PastEventsDataGrid.Visible = false;
                }
                else
                {
                    PastEventsDataGrid.Visible = true;
                    PastEventsDataGrid.DataSource = events;
                    PastEventsDataGrid.DataBind();
                    FutureEventsDataGrid.Visible = false;
                }

                if (events.Count == 0)
                {
                    NoRecordsTable.Visible = true;
                }
                else
                {
                    NoRecordsTable.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                ErrorMessageLabel.Visible = true;

                log.Error("Unknown Error", ex);
            }
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        string queryString = "?aId=" + AgentIdHiddenField.Value +
            "&ptype=" + PlanTypeHiddenField.Value +
            "&pg=" + PageNumberHiddenField.Value;

        Response.Redirect("~/Members/ScheduleManagement.aspx" + queryString);
    }
}

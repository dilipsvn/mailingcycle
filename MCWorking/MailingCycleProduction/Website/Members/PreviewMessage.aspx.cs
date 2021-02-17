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
using MessageService = Irmac.MailingCycle.BLLServiceLoader.Message;

public partial class Members_PreviewMessage : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_PreviewMessage));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected enum EventType
    {
        Future = 0,
        Past
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        // Get the query string values.
        NameValueCollection coll = Request.QueryString;

        int id = Convert.ToInt32(coll.Get("id"));
        int eventId = Convert.ToInt32(coll.Get("eId"));
        int scheduleId = Convert.ToInt32(coll.Get("sId"));
        EventType eventType = EventType.Future;
        if (coll.Get("et") != "" && coll.Get("et") != null)
        {
            eventType = (EventType)Convert.ToInt32(coll.Get("et"));
        }
        int agentId = Convert.ToInt32(coll.Get("aId"));
        string agentName = coll.Get("aName");
        string mode = string.Empty;
        if (coll.Get("mode") != "" && coll.Get("mode") != null)
        {
            mode = coll.Get("mode");
        }
        int planType = Convert.ToInt32(coll.Get("ptype"));
        int pageNumber = Convert.ToInt32(coll.Get("pg"));

        // Display the agent name if one exists.
        if (agentName != "")
        {
            AgentNameLabel.Text = "Agent Name: " + agentName + "&nbsp;";
        }

        if (!IsPostBack)
        {
            // Set the required query string varables into hidden fields.
            IdHiddenField.Value = id.ToString();
            EventIdHiddenField.Value = eventId.ToString();
            ScheduleIdHiddenField.Value = scheduleId.ToString();
            EventTypeHiddenField.Value = Convert.ToInt32(eventType).ToString();
            AgentIdHiddenField.Value = agentId.ToString();
            AgentNameHiddenField.Value = agentName;
            ModeHiddenField.Value = mode;
            PlanTypeHiddenField.Value = planType.ToString();
            PageNumberHiddenField.Value = pageNumber.ToString();

            try
            {
                // Get the schedule event entry details and display.
                ScheduleService.ScheduleService scheduleService =
                    serviceLoader.GetSchedule();
                ScheduleService.ScheduleInfo schedule = 
                    scheduleService.GetEventEntry(eventId, id);

                EventNumberLabel.Text = schedule.Events[0].EventNumber.ToString();
                EventDateLabel.Text = schedule.Events[0].EventDate.ToString("MM/dd/yyyy");
                FarmLabel.Text = schedule.FarmName;
                MailingPlanLabel.Text = schedule.Plan.Title;
                StartDateLabel.Text = schedule.StartDate.ToString("MM/dd/yyyy");
                EndDateLabel.Text = schedule.EndDate.ToString("MM/dd/yyyy");
                PlotLabel.Text = schedule.Events[0].Entries[0].PlotName;

                // Get the design details for the event entry.
                ScheduleService.DesignInfo design =
                    scheduleService.GetDesign(eventId);

                int index = design.LowResolutionFile.LastIndexOf(".");
                string pageImagePath = ConfigurationManager.AppSettings["ApprovedDesignRoot"] +
                    "\\ExtractedPages\\" + 
                    design.LowResolutionFile.Substring(0, index) + 
                    "_Page.jpg";

                if (!File.Exists(pageImagePath))
                {
                    pageImagePath = ConfigurationManager.AppSettings["ApprovedDesignRoot"] +
                        "\\ExtractedPages\\dummy_page.jpg";

                    ErrorMessageLabel.Text = "The preview message is not available. Please try again after some time or contact your administrator.";
                    ErrorMessageLabel.Visible = true;
                }

                float zoomFactor;
                RectangleF messageRectangleActual;
                Util.CalculateMessageActual(design.MessageRectangle, design.Size,
                    pageImagePath, out zoomFactor, out messageRectangleActual);

                pageImagePath = pageImagePath.Substring(pageImagePath.IndexOf("\\Members\\ApprovedDesignPages"));
                pageImagePath = pageImagePath.Replace("\\", "/");

                DesignImage.ImageUrl = "~" + pageImagePath;

                DesignTextLayer.Style.Add("left", messageRectangleActual.X.ToString() + "px");
                DesignTextLayer.Style.Add("top", messageRectangleActual.Y.ToString() + "px");
                DesignTextLayer.Style.Add("width", messageRectangleActual.Width.ToString() + "px");
                DesignTextLayer.Style.Add("height", messageRectangleActual.Height.ToString() + "px");
                DesignTextLayer.Style.Add("clip", "rect(0px " + messageRectangleActual.Width.ToString() + "px " + messageRectangleActual.Height.ToString() + "px 0px)");

                DesignText.Style.Add("zoom", zoomFactor.ToString());
                if (Session["MessagePreviewType"].ToString() == "text")
                {
                    DesignText.InnerHtml = Session["MessagePreviewText"].ToString();
                }
                else
                {
                    MessageImage.ImageUrl = Session["MessagePreviewText"].ToString();
                    MessageImage.Visible = true;
                }

                if (!ClientScript.IsStartupScriptRegistered(this.GetType(), "Startup"))
                {
                    String scriptString = "<script language=JavaScript>";
                    scriptString += "var ctrlPrefix = 'ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_';";
                    scriptString += "var left = document.getElementById(ctrlPrefix + 'DesignImageLayer').offsetLeft;";
                    scriptString += "var top = document.getElementById(ctrlPrefix + 'DesignImageLayer').offsetTop;";
                    scriptString += "var leftOffset = document.getElementById(ctrlPrefix + 'DesignTextLayer').offsetLeft;";
                    scriptString += "var topOffset = document.getElementById(ctrlPrefix + 'DesignTextLayer').offsetTop;";
                    scriptString += "document.getElementById(ctrlPrefix + 'DesignTextLayer').style.left = left + leftOffset;";
                    scriptString += "document.getElementById(ctrlPrefix + 'DesignTextLayer').style.top = top + topOffset;";
                    scriptString += "</script>";

                    ClientScript.RegisterStartupScript(this.GetType(), "Startup", scriptString);
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
        string queryString = "?id=" + IdHiddenField.Value +
            "&eId=" + EventIdHiddenField.Value +
            "&sId=" + ScheduleIdHiddenField.Value +
            "&aId=" + AgentIdHiddenField.Value +
            "&aName=" + AgentNameHiddenField.Value +
            "&et=" + EventTypeHiddenField.Value +
            "&mode=" + ModeHiddenField.Value +
            "&fm=pmp" +
            "&ptype=" + PlanTypeHiddenField.Value +
            "&pg=" + PageNumberHiddenField.Value;

        Response.Redirect("~/Members/AssignMessage.aspx" + queryString);
    }
}

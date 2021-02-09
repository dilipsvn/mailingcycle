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

public partial class Members_AssignMessage : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_AssignMessage));
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

            // Get the schedule event entry details and display.
            try
            {
                ScheduleService.ScheduleService scheduleService =
                    serviceLoader.GetSchedule();
                ScheduleService.ScheduleInfo schedule = 
                    scheduleService.GetEventEntry(eventId, id);

                EventNumberLabel.Text = schedule.Events[0].EventNumber.ToString();
                EventDateLabel.Text = schedule.Events[0].EventDate.ToString("MM/dd/yyyy");
                FarmIdHiddenField.Value = schedule.FarmId.ToString();
                FarmLabel.Text = schedule.FarmName;
                MailingPlanLabel.Text = schedule.Plan.Title;
                StartDateLabel.Text = schedule.StartDate.ToString("MM/dd/yyyy");
                EndDateLabel.Text = schedule.EndDate.ToString("MM/dd/yyyy");

                PlotLabel.Text = schedule.Events[0].Entries[0].PlotName;
                PrevMessageIdHiddenField.Value = 
                    schedule.Events[0].Entries[0].Message.MessageId.ToString();

                if (coll.Get("fm") != "" && coll.Get("fm") != null && coll.Get("fm") == "pmp")
                {
                    if (Session["MessagePreviewTextId"].ToString().Length >= 6)
                    {
                        MessageTypeDropDownList.SelectedValue = 
                            Session["MessagePreviewTypeId"].ToString();
                        MessageTypeDropDownList_Changed(MessageTypeDropDownList, new EventArgs());
                        MessageDropDownList.SelectedValue =
                            Session["MessagePreviewTextId"].ToString();
                        MessageDropDownList_Changed(MessageDropDownList, new EventArgs());
                    }
                    else
                    {
                        MessageTypeDropDownList_Changed(MessageTypeDropDownList, new EventArgs());
                    }
                }
                else
                {
                    if (schedule.Events[0].Entries[0].Message.MessageId != 0)
                    {
                        if (schedule.Events[0].Entries[0].Message.MessageType ==
                            ScheduleService.MessageType.Standard)
                        {
                            MessageTypeDropDownList.SelectedValue = "1";
                        }
                        else
                        {
                            MessageTypeDropDownList.SelectedValue = "2";
                        }
                        MessageTypeDropDownList_Changed(MessageTypeDropDownList, new EventArgs());
                        MessageDropDownList.SelectedValue =
                            schedule.Events[0].Entries[0].Message.MessageId.ToString();
                        MessageDropDownList_Changed(MessageDropDownList, new EventArgs());
                    }
                    else
                    {
                        MessageTypeDropDownList_Changed(MessageTypeDropDownList, new EventArgs());
                    }
                }

                if (mode == "view")
                {
                    MessageTypeDropDownList.Enabled = false;
                    MessageDropDownList.Enabled = false;
                    SaveButton.Enabled = false;
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

    protected void MessageTypeDropDownList_Changed(object sender, EventArgs e)
    {
        try
        {
            int messageType = Convert.ToInt32(MessageTypeDropDownList.SelectedValue);

            if (messageType == (int)MessageType.Standard)
            {
                MessageService.MessageService messageService =
                    serviceLoader.GetMessage();
                
                MessageDropDownList.DataSource = 
                    messageService.GetStandardMessageList(true, string.Empty, string.Empty);

                MessageDropDownList.DataValueField = "MessageId";
                MessageDropDownList.DataTextField = "ShortDesc";
            }
            else
            {
                ScheduleService.ScheduleService scheduleService =
                    serviceLoader.GetSchedule();

                MessageDropDownList.DataSource =
                    scheduleService.GetActiveCustomMessages(Convert.ToInt32(AgentIdHiddenField.Value));

                MessageDropDownList.DataValueField = "MessageId";
                MessageDropDownList.DataTextField = "MessageTextShort";
            }

            MessageDropDownList.DataBind();

            MessageDropDownList.Items.Insert(0, new ListItem("<Select a Message>", "-1"));

            MessageDropDownList_Changed(MessageDropDownList, new EventArgs());
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }

    protected void MessageDropDownList_Changed(object sender, EventArgs e)
    {
        try
        {
            ScheduleService.ScheduleService scheduleService =
                    serviceLoader.GetSchedule();
            int messageId = Convert.ToInt32(MessageDropDownList.SelectedValue);

            if (messageId == -1)
            {
                MessageImagePanel.Visible = false;
                MessageTextPanel.Visible = true;
                MessageTextLiteral.Text = string.Empty;
            }
            else
            {
                ScheduleService.MessageInfo message = scheduleService.GetMessage(messageId,
                    Convert.ToInt32(AgentIdHiddenField.Value));

                if (message.IsImage)
                {
                    MessageTextPanel.Visible = false;
                    MessageImagePanel.Visible = true;
                    MessageTextImage.ImageUrl = "/website/CustomMessage/" + message.FileName;
                }
                else
                {
                    MessageImagePanel.Visible = false;
                    MessageTextPanel.Visible = true;
                    MessageTextLiteral.Text = message.MessageText;
                }
            }
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }

    protected void PreviewButton_Click(object sender, EventArgs e)
    {
        string queryString = "?id=" + IdHiddenField.Value +
            "&eId=" + EventIdHiddenField.Value +
            "&sId=" + ScheduleIdHiddenField.Value +
            "&aId=" + AgentIdHiddenField.Value +
            "&aName=" + AgentNameHiddenField.Value +
            "&et=" + EventTypeHiddenField.Value +
            "&mode=" + ModeHiddenField.Value +
            "&ptype=" + PlanTypeHiddenField.Value +
            "&pg=" + PageNumberHiddenField.Value;

        if (MessageTextPanel.Visible)
        {
            Session["MessagePreviewType"] = "text";
            Session["MessagePreviewText"] = MessageTextLiteral.Text;
        }
        else
        {
            Session["MessagePreviewType"] = "image";
            Session["MessagePreviewText"] = MessageTextImage.ImageUrl;
        }

        Session["MessagePreviewTypeId"] = MessageTypeDropDownList.SelectedValue;
        Session["MessagePreviewTextId"] = MessageDropDownList.SelectedValue;

        Response.Redirect("~/Members/PreviewMessage.aspx" + queryString);
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        int farmId = Convert.ToInt32(FarmIdHiddenField.Value);
        int plotId = Convert.ToInt32(IdHiddenField.Value);
        int eventId = Convert.ToInt32(EventIdHiddenField.Value);
        int messageId = Convert.ToInt32(MessageDropDownList.SelectedValue);

        try
        {
            ScheduleService.ScheduleService scheduleService =
                serviceLoader.GetSchedule();

            if (Convert.ToInt32(PrevMessageIdHiddenField.Value) == 0)
            {
                scheduleService.InsertEventEntry(farmId, plotId, eventId, messageId,
                    loginInfo.UserId);
            }
            else
            {
                scheduleService.UpdateEventEntry(farmId, plotId, eventId, messageId,
                    loginInfo.UserId);
            }

            CancelButton_Click(CancelButton, new EventArgs());
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        string queryString = "?id=" + EventIdHiddenField.Value +
            "&sId=" + ScheduleIdHiddenField.Value +
            "&aId=" + AgentIdHiddenField.Value +
            "&aName=" + AgentNameHiddenField.Value +
            "&et=" + EventTypeHiddenField.Value +
            "&ptype=" + PlanTypeHiddenField.Value +
            "&pg=" + PageNumberHiddenField.Value;

        Response.Redirect("~/Members/ViewEvent.aspx" + queryString);
    }
}

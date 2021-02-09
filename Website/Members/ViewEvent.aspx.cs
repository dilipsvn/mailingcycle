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

public partial class Members_ViewEvent : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_ViewEvent));
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
        int scheduleId = Convert.ToInt32(coll.Get("sId"));
        EventType eventType = EventType.Future;
        if (coll.Get("et") != "" && coll.Get("et") != null)
        {
            eventType = (EventType)Convert.ToInt32(coll.Get("et"));
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

        if (!IsPostBack)
        {
            // Get the logged in account information.
            RegistrationService.LoginInfo loginInfo =
                (RegistrationService.LoginInfo)Session["loginInfo"];

            // Set the required query string varables into hidden fields.
            IdHiddenField.Value = id.ToString();
            ScheduleIdHiddenField.Value = scheduleId.ToString();
            EventTypeHiddenField.Value = Convert.ToInt32(eventType).ToString();
            AgentIdHiddenField.Value = agentId.ToString();
            AgentNameHiddenField.Value = agentName;
            PlanTypeHiddenField.Value = planType.ToString();
            PageNumberHiddenField.Value = pageNumber.ToString();

            try
            {
                // Get the schedule event details and display.
                ScheduleService.ScheduleService scheduleService = 
                    serviceLoader.GetSchedule();
                ScheduleService.ScheduleInfo schedule = 
                    scheduleService.GetEventEntries(id);

                EventNumberLabel.Text = schedule.Events[0].EventNumber.ToString();
                EventDateLabel.Text = schedule.Events[0].EventDate.ToString("MM/dd/yyyy");
                FarmLabel.Text = schedule.FarmName;
                MailingPlanLabel.Text = schedule.Plan.Title;
                StartDateLabel.Text = schedule.StartDate.ToString("MM/dd/yyyy");
                EndDateLabel.Text = schedule.EndDate.ToString("MM/dd/yyyy");
                string designFile = schedule.Events[0].DesignFile;
                DesignHyperLink.Text = designFile.Substring(designFile.IndexOf("_") + 1);
                DesignHyperLink.NavigateUrl = "~/Members/UserData/" +
                    AgentIdHiddenField.Value + "/" + designFile;
                DesignHyperLink.Target = "_blank";
                if (schedule.Events[0].Status.LookupId == (int)ScheduleEventStatus.Completed)
                {
                    StatusLabel.Text = schedule.Events[0].Status.Name +
                        " on " + schedule.Events[0].CompletedOn.ToString("MM/dd/yyyy hh:mm tt");
                }
                else
                {
                    StatusLabel.Text = schedule.Events[0].Status.Name;
                }
                ProductTypeHiddenField.Value = schedule.Events[0].ProductType.Name;
                ProductTypeLabel.Text = schedule.Events[0].ProductType.Name;
                PostalTariffDropDownList.SelectedValue = schedule.Events[0].PostalTariff;
                if (schedule.Events[0].Status.LookupId != (int)ScheduleEventStatus.Scheduled)
                {
                    PostalTariffDropDownList.Enabled = false;
                }
                if (schedule.Events[0].OrderValue == 0)
                {
                    TotalChargesPanel.Visible = false;
                }
                else
                {
                    TotalChargesPanel.Visible = true;
                    TotalChargesLabel.Text = schedule.Events[0].OrderValue.ToString("####.#0");

                    if (schedule.Events[0].RefundAmount == 0)
                    {
                        RefundAmountPanel.Visible = false;
                    }
                    else
                    {
                        RefundAmountPanel.Visible = true;
                        RefundAmountLabel.Text = schedule.Events[0].RefundAmount.ToString("####.#0");
                    }
                }

                // Set the notes panel based on the status of the event and role of the user.
                if ((schedule.Events[0].Status.LookupId == (int)ScheduleEventStatus.Scheduled)
                    && (loginInfo.Role != RegistrationService.UserRole.Agent))
                {
                    NotesReadOnlyPanel.Visible = false;
                    NotesReadWritePanel.Visible = true;
                    NotesTextBox.Text = schedule.Events[0].Notes;
                }
                else
                {
                    NotesReadWritePanel.Visible = false;
                    NotesReadOnlyPanel.Visible = true;
                    NotesLabel.Text = schedule.Events[0].Notes;
                }

                // Display plot's information.
                if (schedule.Events[0].Status.LookupId == (int)ScheduleEventStatus.Scheduled)
                {
                    PastEventDetailsDataGrid.Visible = false;
                    FutureEventDetailsDataGrid.Visible = true;
                    FutureEventDetailsDataGrid.DataSource = schedule.Events[0].Entries;
                    FutureEventDetailsDataGrid.DataBind();
                }
                else
                {
                    FutureEventDetailsDataGrid.Visible = false;
                    PastEventDetailsDataGrid.Visible = true;
                    PastEventDetailsDataGrid.DataSource = schedule.Events[0].Entries;
                    PastEventDetailsDataGrid.DataBind();
                }

                if (schedule.Events[0].Entries.Length == 0)
                {
                    NoRecordsTable.Visible = true;
                }
                else
                {
                    NoRecordsTable.Visible = false;
                }

                // Set the printer remarks panel based on the status of the event and role of
                // the user.
                if (schedule.Events[0].Status.LookupId == (int)ScheduleEventStatus.InProgress)
                {
                    if (loginInfo.Role == RegistrationService.UserRole.Printer)
                    {
                        PrinterRemarksPanel.Visible = true;
                    }
                    else
                    {
                        PrinterRemarksPanel.Visible = false;
                    }
                }
                else if (schedule.Events[0].Status.LookupId == (int)ScheduleEventStatus.Completed)
                {
                    PrinterRemarksPanel.Visible = true;
                    PrinterRemarksRWPanel.Visible = false;
                    PrinterRemarksROPanel.Visible = true;

                    // Display Data.
                    string file = schedule.Events[0].MailingListFile;
                    MailingListFileHyperLink.Text = file.Substring(file.IndexOf("_") + 1);
                    MailingListFileHyperLink.NavigateUrl = "~/Members/MailingLists/" + file;
                    MailingListFileHyperLink.Target = "_blank";
                    MailingCountLabel.Text = schedule.Events[0].MailingCount.ToString();
                    RemarksLabel.Text = schedule.Events[0].Remarks;

                    if (schedule.Events[0].RefundAmount == 0)
                    {
                        ExceptionReportedPanel.Visible = false;
                    }
                    else
                    {
                        ExceptionReportedPanel.Visible = true;

                        if (schedule.Events[0].ExceptionReported)
                        {
                            ExceptionReportedImage.ImageUrl = "~/Images/tick.gif";
                        }
                        else
                        {
                            ExceptionReportedImage.ImageUrl = "~/Images/cross.gif";
                        }
                    }
                }
                else
                {
                    PrinterRemarksPanel.Visible = false;
                }

                // Set the action buttons based on the role and status.
                if (schedule.Events[0].Status.LookupId == (int)ScheduleEventStatus.Scheduled)
                {
                    if (loginInfo.Role == RegistrationService.UserRole.Agent)
                    {
                        ReadWriteButtonsPanel.Visible = true;
                    }
                    else
                    {
                        CancelEventButtonsPanel.Visible = true;
                    }
                }
                else if (schedule.Events[0].Status.LookupId == (int)ScheduleEventStatus.InProgress)
                {
                    if (loginInfo.Role == RegistrationService.UserRole.Printer)
                    {
                        CompleteEventButtonsPanel.Visible = true;
                    }
                    else
                    {
                        ReadOnlyButtonsPanel.Visible = true;
                    }
                }
                else
                {
                    ReadOnlyButtonsPanel.Visible = true;
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

    protected void FutureEventDetails_Created(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (ProductTypeHiddenField.Value == DesignCategory.Brochure.ToString())
            {
                ((HyperLink)e.Item.Cells[4].Controls[1]).Enabled = false;
            }
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        int eventId = Convert.ToInt32(IdHiddenField.Value);
        string postalTariff = PostalTariffDropDownList.SelectedValue;
        string notes = string.Empty;
        if (NotesReadOnlyPanel.Visible)
        {
            notes = NotesLabel.Text.Trim();
        }
        else
        {
            notes = NotesTextBox.Text.Trim();
        }
        
        try
        {
            ScheduleService.ScheduleService scheduleService = 
                serviceLoader.GetSchedule();

            scheduleService.UpdatePostalTariff(eventId, postalTariff, notes,
                loginInfo.UserId);

            CancelButton_Click(SaveButton, new EventArgs());
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }

    protected void CancelEventButton_Click(object sender, EventArgs e)
    {
        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        int eventId = Convert.ToInt32(IdHiddenField.Value);
        string notes = NotesTextBox.Text.Trim();

        try
        {
            ScheduleService.ScheduleService scheduleService =
                serviceLoader.GetSchedule();

            scheduleService.CancelEvent(eventId, notes, loginInfo.UserId);

            CancelButton_Click(BackButton, new EventArgs());
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }

    protected void CompleteEventButton_Click(object sender, EventArgs e)
    {
        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        int eventId = Convert.ToInt32(IdHiddenField.Value);
        string mailingListFile = string.Empty;
        string remarks = RemarksTextBox.Text.Trim();
        int mailingCount = Convert.ToInt32(MailingCountTextBox.Text);

        try
        {
            // Get the upload location.
            string path = Server.MapPath("~/Members/MailingLists");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Validate mailing list file.
            if (MailingListFileUpload.HasFile)
            {
                if (!(MailingListFileUpload.FileName.ToLower().EndsWith(".xls") ||
                    MailingListFileUpload.FileName.ToLower().EndsWith(".csv")))
                {
                    ErrorMessageLabel.Text = "Enter a valid Mailing List File (.xls and .csv only).";
                    ErrorMessageLabel.Visible = true;

                    return;
                }
            }

            // Upload the file.
            if (MailingListFileUpload.HasFile)
            {
                mailingListFile = eventId + "_" + MailingListFileUpload.FileName;

                MailingListFileUpload.SaveAs(path + "\\" + mailingListFile);
            }

            // Save the data.
            ScheduleService.ScheduleService scheduleService =
                serviceLoader.GetSchedule();

            scheduleService.CompleteEvent(eventId, mailingListFile, remarks, 
                mailingCount, loginInfo.UserId);
            
            CancelButton_Click(BackButton, new EventArgs());
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
        string queryString = "?id=" + ScheduleIdHiddenField.Value +
            "&aId=" + AgentIdHiddenField.Value +
            "&aName=" + AgentNameHiddenField.Value +
            "&et=" + EventTypeHiddenField.Value +
            "&ptype=" + PlanTypeHiddenField.Value +
            "&pg=" + PageNumberHiddenField.Value;

        Response.Redirect("~/Members/ViewEvents.aspx" + queryString);
    }

    protected void ViewContactsButton_Click(object sender, EventArgs e)
    {
        string queryString = "?id=" + IdHiddenField.Value +
            "&sId=" + ScheduleIdHiddenField.Value +
            "&aId=" + AgentIdHiddenField.Value +
            "&aName=" + AgentNameHiddenField.Value +
            "&et=" + EventTypeHiddenField.Value +
            "&ptype=" + PlanTypeHiddenField.Value +
            "&pg=" + PageNumberHiddenField.Value;

        Response.Redirect("~/Members/ViewEventContacts.aspx" + queryString);
    }
}

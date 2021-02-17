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
using System.Collections.Generic;
using System.Collections.Specialized;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;
using ScheduleService = Irmac.MailingCycle.BLLServiceLoader.Schedule;

public partial class Members_FirmUpCalendar : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_FirmUpCalendar));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        // Get the query string values.
        NameValueCollection coll = Request.QueryString;

        int farmId = Convert.ToInt32(coll.Get("farmId"));
        DateTime startDate = Convert.ToDateTime(coll.Get("start_date"));

        if (!IsPostBack)
        {
            // Get the logged in account information.
            RegistrationService.LoginInfo loginInfo =
                (RegistrationService.LoginInfo)Session["loginInfo"];

            // Set the required query string varables into hidden fields.
            FarmIdHiddenField.Value = farmId.ToString();
            StartDateHiddenField.Value = startDate.ToString("MM/dd/yyyy");

            try
            {
                // Get the farm details and display.
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                FarmService.FarmInfo farm = farmService.GetFarmDetail(farmId);

                FarmNameLabel.Text = farm.FarmName;
                PlotCountLabel.Text = farm.PlotCount.ToString();
                ContactCountLabel.Text = farm.ContactCount.ToString();
                int planId = farm.MailingPlan.MailingPlanId;
                PlanIdHiddenField.Value = planId.ToString();
                MailingPlanLabel.Text = farm.MailingPlan.Title;
                CreatedOnLabel.Text = farm.CreateDate.ToString("MM/dd/yyyy");

                // Get the scheduled events and display.
                ScheduleService.ScheduleService scheduleService = 
                    serviceLoader.GetSchedule();
                IList<ScheduleService.ScheduleEventInfo> events =
                    scheduleService.GetPlanEvents(planId, startDate);

                EventsDataGrid.DataSource = events;
                EventsDataGrid.DataBind();
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                ErrorMessageLabel.Visible = true;

                log.Error("Unknown Error", ex);
            }
        }
    }

    protected void FirmUpButton_Click(object sender, EventArgs e)
    {
        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        // Get the required data.
        int farmId = Convert.ToInt32(FarmIdHiddenField.Value);
        int planId = Convert.ToInt32(PlanIdHiddenField.Value);
        DateTime startDate = Convert.ToDateTime(StartDateHiddenField.Value);
        int userId = loginInfo.UserId;

        try
        {
            // Save the data.
            ScheduleService.ScheduleService scheduleService =
                serviceLoader.GetSchedule();

            scheduleService.FirmUp(farmId, planId, startDate, userId);

            try
            {
                Util.Schedule.SendEmailAsFirmedUp(FarmNameLabel.Text, 
                    MailingPlanLabel.Text, startDate, loginInfo.FirstName,
                    loginInfo.LastName, Request.ApplicationPath);
            }
            catch (Exception ex)
            {
                log.Error("Unknown Error", ex);
            }

            string queryString = "?farmId=" + FarmIdHiddenField.Value;

            Response.Redirect("~/Members/ViewFarm.aspx" + queryString, true);
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
        string queryString = "?farmId=" + FarmIdHiddenField.Value +
            "&start_date=" + StartDateHiddenField.Value;

        Response.Redirect("~/Members/FirmUp.aspx" + queryString);
    }
}

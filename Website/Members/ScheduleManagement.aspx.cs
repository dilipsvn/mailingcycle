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
using System.Drawing;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.Model;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using ScheduleService = Irmac.MailingCycle.BLLServiceLoader.Schedule;

public partial class Agent_ScheduleManagement : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Agent_ScheduleManagement));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    #region Private Methods

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

    private void DisplayMailingPlans(int agentId, ScheduleService.PlanType planType)
    {
        try
        {
            ScheduleService.ScheduleService scheduleService = serviceLoader.GetSchedule();
            IList<ScheduleService.ScheduleInfo> schedules =
                scheduleService.GetMailingPlans(agentId, planType);

            if (schedules.Count == 0)
            {
                ActivePlansDataGrid.AllowPaging = false;
            }
            else
            {
                if (schedules.Count > ActivePlansDataGrid.PageSize)
                {
                    ActivePlansDataGrid.AllowPaging = true;
                }
                else
                {
                    ActivePlansDataGrid.AllowPaging = false;
                }

                ActivePlansDataGrid.CurrentPageIndex =
                    Convert.ToInt32(PageNumberHiddenField.Value);
            }

            ActivePlansDataGrid.DataSource = schedules;
            ActivePlansDataGrid.DataBind();

            if (schedules.Count == 0)
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

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        ScheduleService.PlanType planType = ScheduleService.PlanType.Active;
        int pageNumber = 0;
        int agentId = 0;

        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        if (loginInfo.Role == RegistrationService.UserRole.Agent)
        {
            agentId = loginInfo.UserId;
        }

        if (!IsPostBack)
        {
            // Get the query string values.
            NameValueCollection coll = Request.QueryString;

            if (coll.Get("ptype") != "" && coll.Get("ptype") != null)
            {
                planType = (ScheduleService.PlanType)Convert.ToInt32(coll.Get("ptype"));
            }

            if (coll.Get("pg") != "" && coll.Get("pg") != null)
            {
                pageNumber = Convert.ToInt32(coll.Get("pg"));
            }

            if (coll.Get("aId") != "" && coll.Get("aId") != null)
            {
                agentId = Convert.ToInt32(coll.Get("aId"));
            }

            if (loginInfo.Role != RegistrationService.UserRole.Agent)
            {
                try
                {
                    AgentSelectionPanel.Visible = true;

                    // Get the list of agents and display.
                    CommonService.CommonService commonService = serviceLoader.GetCommon();

                    AgentNameDropDownList.DataSource = commonService.GetAgentsList();
                    AgentNameDropDownList.DataValueField = "UserId";
                    AgentNameDropDownList.DataTextField = "UserName";
                    AgentNameDropDownList.DataBind();

                    AgentNameDropDownList.Items.Insert(0, new ListItem("<Select an Agent>", "-1"));

                    // Get the query string values and set the agent id.
                    if (agentId != 0)
                    {
                        AgentNameDropDownList.SelectedValue = agentId.ToString();

                        AgentNameHiddenField.Value = AgentNameDropDownList.SelectedItem.Text;
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
        else
        {
            planType = (ScheduleService.PlanType)Convert.ToInt32(PlanTypeHiddenField.Value);
            pageNumber = Convert.ToInt32(PageNumberHiddenField.Value);

            if (AgentSelectionPanel.Visible == true)
            {
                agentId = Convert.ToInt32(AgentNameDropDownList.SelectedValue);

                AgentNameHiddenField.Value = AgentNameDropDownList.SelectedItem.Text;
            }
            else
            {
                agentId = Convert.ToInt32(AgentIdHiddenField.Value);
            }
        }

        // Set the required query string values in hidden fields.
        PlanTypeHiddenField.Value = Convert.ToInt32(planType).ToString();
        PageNumberHiddenField.Value = pageNumber.ToString();
        AgentIdHiddenField.Value = agentId.ToString();

        // Set the screen elements based on the type of plans that are displayed.
        string queryString = "?aId=" + agentId.ToString() +
            "&ptype=" + (planType == ScheduleService.PlanType.Active ? Convert.ToInt32(ScheduleService.PlanType.Completed) : Convert.ToInt32(ScheduleService.PlanType.Active)) +
            "&pg=0";

        if (planType == ScheduleService.PlanType.Active)
        {
            SetHyperLink(ActivePlansHyperLink, "");
            LegendTitleLabel.Text = "List of Active Mailing Plans";

            SetHyperLink(CompletedPlansHyperLink, "~/Members/ScheduleManagement.aspx" + queryString);
        }
        else
        {
            SetHyperLink(CompletedPlansHyperLink, "");
            LegendTitleLabel.Text = "List of Completed Mailing Plans";

            SetHyperLink(ActivePlansHyperLink, "~/Members/ScheduleManagement.aspx" + queryString);
        }

        // Load the agent specific schedule details.
        DisplayMailingPlans(agentId, planType);
    }

    protected void GoButton_Click(object sender, EventArgs e)
    {
        // Load the agent specific schedule details.
        if (Convert.ToInt32(AgentNameDropDownList.SelectedValue) == -1)
        {
            AgentIdHiddenField.Value = "0";
            AgentNameHiddenField.Value = "";
        }
        else
        {
            AgentIdHiddenField.Value = AgentNameDropDownList.SelectedValue;
            AgentNameHiddenField.Value = AgentNameDropDownList.SelectedItem.Text;
        }

        DisplayMailingPlans(Convert.ToInt32(AgentNameDropDownList.SelectedValue),
            (ScheduleService.PlanType)Convert.ToInt32(PlanTypeHiddenField.Value));
    }

    protected void Plans_Changed(object sender, DataGridPageChangedEventArgs e)
    {
        PageNumberHiddenField.Value = e.NewPageIndex.ToString();

        DisplayMailingPlans(Convert.ToInt32(AgentIdHiddenField.Value),
            (ScheduleService.PlanType)Convert.ToInt32(PlanTypeHiddenField.Value));
    }
}

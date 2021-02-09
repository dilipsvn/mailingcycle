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
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;

public partial class Members_MailingLabelsReportCriteria : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_MailingLabelsReportCriteria));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        if (!IsPostBack)
        {
            // Populate agents into dropdown list.
            try
            {
                CommonService.CommonService commonService =
                    serviceLoader.GetCommon();

                AgentDropDownList.DataSource = commonService.GetAgentsList();
                AgentDropDownList.DataValueField = "UserId";
                AgentDropDownList.DataTextField = "UserName";
                AgentDropDownList.DataBind();

                AgentDropDownList.Items.Insert(0, new ListItem("<Select an Agent>", "0"));
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                ErrorMessageLabel.Visible = true;

                log.Error("Unknown Error", ex);
            }
        }
    }

    protected void Agent_Changed(object sender, EventArgs e)
    {
        // Populate farms into dropdown list.
        try
        {
            PlotDropDownList.Items.Clear();
            PlotDropDownList.Items.Insert(0, new ListItem("<All Plots>", "0"));

            int agentId = Convert.ToInt32(AgentDropDownList.SelectedValue);

            FarmService.FarmService farmService = serviceLoader.GetFarm();

            FarmDropDownList.DataSource = farmService.GetFarmSummary(agentId);
            FarmDropDownList.DataValueField = "FarmId";
            FarmDropDownList.DataTextField = "FarmName";
            FarmDropDownList.DataBind();

            FarmDropDownList.Items.Insert(0, new ListItem("<All Farms>", "0"));
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }

    protected void Farm_Changed(object sender, EventArgs e)
    {
        // Populate plots into dropdown list.
        try
        {
            int farmId = Convert.ToInt32(FarmDropDownList.SelectedValue);

            FarmService.FarmService farmService = serviceLoader.GetFarm();

            PlotDropDownList.DataSource = farmService.GetFarmDetail(farmId).Plots;
            PlotDropDownList.DataValueField = "PlotId";
            PlotDropDownList.DataTextField = "PlotName";
            PlotDropDownList.DataBind();

            PlotDropDownList.Items.Insert(0, new ListItem("<All Plots>", "0"));
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }
}

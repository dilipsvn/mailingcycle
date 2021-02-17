#region Namespaces

using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Irmac.MailingCycle.BLLServiceLoader;
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLL;

using log4net;
using log4net.Config;
#endregion

public partial class Members_ArchivedPlotList : System.Web.UI.Page
{

    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Members_ArchivedPlotList));
    #endregion

    #endregion

    #region Properties
    public bool IsAgentRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Agent);
        }
    }

    public int LoginUserId
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return regInfo.UserId;
        }
    }
    #endregion

    public int GetAgentId()
    {
        if (IsAgentRole)
            return LoginUserId;
        else
            return Convert.ToInt32(UserIdHiddenField.Value.ToString());
    }
    #region Event Handlers

    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int farmId = 0;
            if ((Request.QueryString["farmId"] != "") && (Request.QueryString["farmId"] != null))
                int.TryParse(Request.QueryString["farmId"], out farmId);

            if (farmId == 0)
                Response.Redirect("~/Members/ArchivedFarmList.aspx");

            FarmIdHiddenField.Value = farmId.ToString();

            try
            {
                // Get the common web service instance.

                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                int userId = farmService.GetUserIdForFarm(farmId);
                UserIdHiddenField.Value = userId.ToString();
                if (!IsAgentRole)
                {
                    ForAgentPanel.Visible = true;
                    ForAgentUserNameLabel.Text = farmService.GetUserName(userId);
                    ForAgentUserIdHiddenField.Value = userId.ToString();
                }
                else
                {
                    ForAgentPanel.Visible = false;
                }

                FarmService.FarmInfo farm = farmService.GetArchivedFarmSummaryDetails(farmId);

                if (farm.FarmId == 0)
                {
                    Response.Redirect("~/Members/ArchivedFarmList.aspx", true);
                }
                else
                {
                    farm.UserId = GetAgentId();
                    FarmNameLabel.Text = farm.FarmName;
                    MailingPlanLabel.Text = farm.MailingPlan.Title;
                    CreateDateLabel.Text = farm.CreateDate.ToShortDateString();
                    FarmContactCountLabel.Text = farm.ContactCount.ToString();
                    PlotCountLabel.Text = farm.PlotCount.ToString();
                    FarmService.PlotInfo[] Plots = farmService.GetArchivedPlotSummary(farmId);
                    PlotListGridView.DataSource = Plots;
                    PlotListGridView.DataBind();
                    for (int i = 0; i < PlotListGridView.Rows.Count; i++)
                    {
                        if (Plots[i].Deleted)
                            PlotListGridView.Rows[i].ForeColor = System.Drawing.Color.DarkKhaki;
                        else
                        {
                            PlotListGridView.Rows[i].ForeColor = System.Drawing.Color.Green;
                            PlotListGridView.Rows[i].Cells[0].Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("UNKNOWN ERROR:", ex);
                ErrorLiteral.Text = "Unknown Error Please contact Administrator:";
            }
        }
    }

    protected void RestorePlotButton_Click(object sender, EventArgs e)
    {
        bool jumpError = false;
        try 
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            for (int i = 0; i < PlotListGridView.Rows.Count; i++)
            {
                GridViewRow row = PlotListGridView.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("PlotIdCheckBox")).Checked;
                if (isChecked)
                {
                    int plotId = int.Parse(((CheckBox)row.FindControl("PlotIdCheckBox")).ToolTip);
                    farmService.RestorePlotContact(plotId, LoginUserId);
                }
            }

            int farmId = int.Parse(FarmIdHiddenField.Value.ToString());
            FarmService.FarmInfo farm = farmService.GetArchivedFarmSummaryDetails(farmId);
            FarmNameLabel.Text = farm.FarmName;
            MailingPlanLabel.Text = farm.MailingPlan.Title;
            CreateDateLabel.Text = farm.CreateDate.ToShortDateString();
            FarmContactCountLabel.Text = farm.ContactCount.ToString();
            PlotCountLabel.Text = farm.PlotCount.ToString();

            FarmService.PlotInfo[] Plots = farmService.GetArchivedPlotSummary(farmId);
            
            PlotListGridView.DataSource = Plots;
            PlotListGridView.DataBind();
            for (int i = 0; i < PlotListGridView.Rows.Count; i++)
            {
                if (Plots[i].Deleted)
                    PlotListGridView.Rows[i].ForeColor = System.Drawing.Color.DarkKhaki;
                else
                {
                    PlotListGridView.Rows[i].ForeColor = System.Drawing.Color.Green;
                    PlotListGridView.Rows[i].Cells[0].Enabled = false;
                }
            }


        }
        catch(Exception exception) 
        {
            if (exception.Message.Contains("Parent Farm is in Deleted State. Plot Cannot be restored"))
                ErrorLiteral.Text = "Parent Farm is in Deleted State. Plot Cannot be restored";
            else
            {
                log.Error("UNKNOWN ERROR WHILE RESTORING CONTACT:", exception);
                ErrorLiteral.Text = "Unknown Error Please contact Administrator:";
                jumpError = true;
            }
            if (jumpError)
                Response.Redirect("~/Members/ArchivedFarmList.aspx");
        }
    }
    #endregion

    #endregion


}

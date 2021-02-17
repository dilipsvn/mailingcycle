#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ArchivedFarmList.aspx
    * Created Date      : 11/20/2007
	* Last Modify Date  : 11/20/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to restore the farms
	* Source			: MailingCycle\ArchivedFarmList.aspx.cs

	****************************************************************/
#endregion

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
using Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLL;
using log4net;
using log4net.Config;
#endregion

public partial class Members_ArchivedFarmList : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
        protected static readonly ILog log = LogManager.GetLogger(typeof(Members_ArchivedFarmList));
        private bool deleted;
    #endregion

    #endregion

    #region Properties
    public bool IsArchived
    {
        set
        {
            deleted = value;
        }
        get
        {
            return deleted;
        }
    }
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
    #region Event Handlers
    protected int GetAgentId()
    {
        RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
        int agentId = 0;
        if (IsAgentRole)
        {
            agentId = LoginUserId;
        }
        else
        {
            if (AgentListDropDownList.SelectedIndex == 0)
            {
                AgentListErrorLiteral.Text = "Please Select an Agent";
            }
            else
            {
                AgentListErrorLiteral.Text = "";
                int.TryParse(AgentListDropDownList.SelectedValue.ToString(), out agentId);
            }
        }
        return agentId;
    }

    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        IsArchived = true;
        if (!Page.IsPostBack)
        {
            try
            {
                // Get the common web service instance.

                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                if (IsAgentRole)
                {
                    AgentListPanel.Visible = false;
                    FarmService.FarmInfo[] farmList;
                    farmList = farmService.GetArchivedFarmSummary(GetAgentId());
                    FarmGridView.DataSource = farmList;
                    FarmGridView.DataBind();
                    if (farmList.Length == 0)
                        NoFarmDataPanel.Visible = true;
                    else
                    {
                        NoFarmDataPanel.Visible = false;
                        for (int i = 0; i < FarmGridView.Rows.Count; i++)
                        {
                            if (farmList[i].Deleted == true)
                                FarmGridView.Rows[i].ForeColor = System.Drawing.Color.Red;
                            else if (farmList[i].PlotCount == 0)
                                FarmGridView.Rows[i].ForeColor = System.Drawing.Color.Green;
                            else
                                FarmGridView.Rows[i].ForeColor = System.Drawing.Color.DarkKhaki;
                            if (farmList[i].Deleted == false)
                                FarmGridView.Rows[i].Cells[0].Enabled = false;
                        }
                    }
                }
                else
                {
                    AgentListPanel.Visible = true;
                    CommonService commonService = serviceLoader.GetCommon();
                    AgentListDropDownList.DataSource = commonService.GetAgentsList();
                    AgentListDropDownList.DataValueField = "UserId";
                    AgentListDropDownList.DataTextField = "UserName";
                    AgentListDropDownList.DataBind();
                    AgentListDropDownList.Items.Insert(0, "Select an Agent");
                }
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR:", exception);
                ErrorLiteral.Text = "UNKNOWN ERROR. Contact Administrator";
            }

        }
    }

    protected void SelectedAgentButton_Click(object sender, EventArgs e)
    {
        try
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();
            FarmService.FarmInfo[] farmList;
            farmList = farmService.GetArchivedFarmSummary(GetAgentId());
            FarmGridView.DataSource = farmList;
            FarmGridView.DataBind();
            if (farmList.Length == 0)
                NoFarmDataPanel.Visible = true;
            else
            {
                NoFarmDataPanel.Visible = false;
                for (int i = 0; i < FarmGridView.Rows.Count; i++)
                {
                    if (farmList[i].Deleted == true)
                        FarmGridView.Rows[i].ForeColor = System.Drawing.Color.Red;
                    else if (farmList[i].PlotCount == 0)
                        FarmGridView.Rows[i].ForeColor = System.Drawing.Color.Green;
                    else
                        FarmGridView.Rows[i].ForeColor = System.Drawing.Color.DarkKhaki;
                }
            }
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR:", exception);
            ErrorLiteral.Text = "UNKNOWN ERROR. Contact Administrator";
        }
    }

    protected void RestoreFarmButton_Click(object sender, EventArgs e)
    {

        try
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            for (int i = 0; i < FarmGridView.Rows.Count; i++)
            {
                GridViewRow row = FarmGridView.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("FarmIdCheckBox")).Checked;
                if (isChecked)
                {
                    int farmId = int.Parse(((CheckBox)row.FindControl("FarmIdCheckBox")).ToolTip);
                    farmService.RestoreFarmPlot(farmId, LoginUserId);
                }
            }

            FarmService.FarmInfo[] farmList;
            farmList = farmService.GetArchivedFarmSummary(GetAgentId());
            FarmGridView.DataSource = farmList;
            FarmGridView.DataBind();
            if (farmList.Length == 0)
                NoFarmDataPanel.Visible = true;
            else
            {
                NoFarmDataPanel.Visible = false;
                for (int i = 0; i < FarmGridView.Rows.Count; i++)
                {
                    if (farmList[i].Deleted == true)
                        FarmGridView.Rows[i].ForeColor = System.Drawing.Color.Red;
                    else if (farmList[i].PlotCount == 0)
                        FarmGridView.Rows[i].ForeColor = System.Drawing.Color.Green;
                    else
                        FarmGridView.Rows[i].ForeColor = System.Drawing.Color.DarkKhaki;
                }
            }
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE RESTORE FARM:", exception);
            MessageLiteral.Text = "Error: Unable to Restore Farm";
        }
    }

    #endregion

    #endregion
}

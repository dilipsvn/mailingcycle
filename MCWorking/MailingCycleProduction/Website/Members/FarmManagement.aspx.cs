#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: FarmManagement.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/04/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to manage the farms
	* Source			: MailingCycle\FarmManagement.aspx.cs

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

public partial class FarmManagement : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
        protected static readonly ILog log = LogManager.GetLogger(typeof(FarmManagement));
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

    public bool IsPrinterRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Printer);
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

    #region Methods
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
    #endregion
    #region Event Handlers

    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPrinterRole)
        {
            CreateFarmButton.Visible = false;
            ArchivedFarmHyperLink.Visible = false;
        }

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
                    FillFarmGrid(0);
                }
                else
                {
                    AgentListPanel.Visible = true;
                    CommonService commonService = serviceLoader.GetCommon();
                    AgentListDropDownList.DataSource = commonService.GetAgentsList();
                    AgentListDropDownList.DataValueField = "UserId";
                    AgentListDropDownList.DataTextField = "UserName";
                    AgentListDropDownList.DataBind();
                    AgentListDropDownList.Items.Insert(0,"Select an Agent");
                }
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR WHILE LOADING FARM MANAGEMENT:", exception);
                ErrorLiteral.Text = "UNKNOWN ERROR. Contact Administrator";
            }

        }
    }

    protected void SelectedAgentButton_Click(object sender, EventArgs e)
    {
        FillFarmGrid(0);
    }

    private void FillFarmGrid(int pageNumber)
    {
        try
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            FarmService.FarmInfo[] farms = farmService.GetFarmSummary(GetAgentId());
            FarmGridView.DataSource = farms;
            FarmGridView.PageIndex = pageNumber;
            FarmGridView.DataBind();

            if (farms.Length == 0)
            {
                NoFarmDataPanel.Visible = true;
            }
            else
            {
                NoFarmDataPanel.Visible = false;

                if (IsPrinterRole)
                {
                    for (int i = 0; i < FarmGridView.Rows.Count; i++)
                    {
                        FarmGridView.Rows[i].Cells[0].FindControl("EditHyperLink").Visible = false;
                    }

                    ArchivedFarmHyperLink.Visible = false;
                }
            }
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR:", exception);
            ErrorLiteral.Text = "UNKNOWN ERROR. Contact Administrator";
        }
    }

    protected void CreateFarmButton_Click(object sender, EventArgs e)
    {
        int userId = 0;
        userId = GetAgentId();
        if (userId != 0)
            Response.Redirect("~/Members/CreateFarm.aspx?userId=" + userId.ToString());
    }

    protected void FarmGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FillFarmGrid(e.NewPageIndex);
    }
    
    #endregion

    #endregion
    
}

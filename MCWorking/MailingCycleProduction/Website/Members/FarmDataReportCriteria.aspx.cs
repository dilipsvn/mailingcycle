#region (C) Irmac USA Inc 2008
/***************************************************************** 

	* All rights are reserved. 
    * File				: FarmDataReport.aspx
    * Created Date      : 01/07/2008
	* Last Modify Date  : 01/08/2008
	* Author			: Irmac Development Team 
	* Comment			: Page is used for Farm Data Report Criteria
	* Source			: Members/FarmDataReport.aspx.cs

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

public partial class Members_FarmDataReportCriteria : System.Web.UI.Page
{

    #region Field Declarations

        #region Form specific variable declaration
            protected static readonly ILog log = LogManager.GetLogger(typeof(Members_FarmDataReportCriteria));
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

    protected void LoadConditionData()
    {
        FarmCountConditionDropDownList.Items.Add(new ListItem("Between", "Between"));
        FarmCountConditionDropDownList.Items.Add(new ListItem("=", "eq"));
        FarmCountConditionDropDownList.Items.Add(new ListItem(">", "gt"));
        FarmCountConditionDropDownList.Items.Add(new ListItem(">=", "gte"));
        FarmCountConditionDropDownList.Items.Add(new ListItem("<", "lt"));
        FarmCountConditionDropDownList.Items.Add(new ListItem("<=", "lte"));

        PlotCountConditionDropDownList.Items.Add(new ListItem("Between", "Between"));
        PlotCountConditionDropDownList.Items.Add(new ListItem("=", "eq"));
        PlotCountConditionDropDownList.Items.Add(new ListItem(">", "gt"));
        PlotCountConditionDropDownList.Items.Add(new ListItem(">=", "gte"));
        PlotCountConditionDropDownList.Items.Add(new ListItem("<", "lt"));
        PlotCountConditionDropDownList.Items.Add(new ListItem("<=", "lte"));

        ContactCountConditionDropDownList.Items.Add(new ListItem("Between", "Between"));
        ContactCountConditionDropDownList.Items.Add(new ListItem("=", "eq"));
        ContactCountConditionDropDownList.Items.Add(new ListItem(">", "gt"));
        ContactCountConditionDropDownList.Items.Add(new ListItem(">=", "gte"));
        ContactCountConditionDropDownList.Items.Add(new ListItem("<", "lt"));
        ContactCountConditionDropDownList.Items.Add(new ListItem("<=", "lte"));

        DeletedContactsCountConditionDropDownList.Items.Add(new ListItem("Between", "Between"));
        DeletedContactsCountConditionDropDownList.Items.Add(new ListItem("=", "eq"));
        DeletedContactsCountConditionDropDownList.Items.Add(new ListItem(">", "gt"));
        DeletedContactsCountConditionDropDownList.Items.Add(new ListItem(">=", "gte"));
        DeletedContactsCountConditionDropDownList.Items.Add(new ListItem("<", "lt"));
        DeletedContactsCountConditionDropDownList.Items.Add(new ListItem("<=", "lte"));
    }
        
    #endregion
    
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadConditionData();
            try
            {
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();

                AgentListPanel.Visible = true;
                CommonService commonService = serviceLoader.GetCommon();
                AgentListDropDownList.DataSource = commonService.GetAgentsList();
                AgentListDropDownList.DataValueField = "UserId";
                AgentListDropDownList.DataTextField = "UserName";
                AgentListDropDownList.DataBind();
                AgentListDropDownList.Items.Insert(0, "All Agents");

                IList<FarmService.MailingPlanInfo> mailingPlans = farmService.GetMailingPlanList();
                MailingPlanDropDownList.DataSource = mailingPlans;
                MailingPlanDropDownList.DataValueField = "MailingPlanId";
                MailingPlanDropDownList.DataTextField = "Title";
                MailingPlanDropDownList.DataBind();
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR WHILE LOADIN FARM DATA REPORT CRITERIA:", exception);
            }
        }
    }
    #endregion

}

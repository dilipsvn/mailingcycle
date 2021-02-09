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

public partial class Members_FirmUpStatus : System.Web.UI.Page
{
    #region Field Declarations

        #region Form specific variable declaration
            protected static readonly ILog log = LogManager.GetLogger(typeof(Members_FirmUpStatus));
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
            AgentListErrorLiteral.Text = "";
            int.TryParse(AgentListDropDownList.SelectedValue.ToString(), out agentId);
        }
        return agentId;
    }
    #endregion

    #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    // Get the common web service instance.

                    ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                    FarmService.FarmService farmService = serviceLoader.GetFarm();
                    if (IsAgentRole)
                    {
                        AgentListDropDownList.Items.Clear();
                        AgentListDropDownList.Items.Add(new ListItem(LoginUserId.ToString(), LoginUserId.ToString()));
                        AgentListDropDownList.SelectedIndex = 0;
                        AgentListPanel.Visible = false;
                    }
                    else 
                    {
                        AgentListPanel.Visible = true;
                        CommonService commonService = serviceLoader.GetCommon();
                        AgentListDropDownList.DataSource = commonService.GetAgentsList();
                        AgentListDropDownList.DataValueField = "UserId";
                        AgentListDropDownList.DataTextField = "UserName";
                        AgentListDropDownList.DataBind();
                        AgentListDropDownList.Items.Insert(0, "All Agents");
                    }
                    FarmStatusDropDownList.Items.Add(new ListItem("Firmed Up", "Firmed Up"));
                    FarmStatusDropDownList.Items.Add(new ListItem("Not Firmed Up", "Not Firmed Up"));
                }
                catch (Exception exception)
                {
                    log.Error("UNKNOWN ERROR WHILE LOADING FARM MANAGEMENT:", exception);
                }
            }
        }
    #endregion
}

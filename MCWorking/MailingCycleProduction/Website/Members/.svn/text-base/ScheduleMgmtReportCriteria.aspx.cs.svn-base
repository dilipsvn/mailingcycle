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

public partial class Members_ScheduleMgmtReportCriteria : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_ScheduleMgmtReportCriteria));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        if (!IsPostBack)
        {
            // Get the logged in account information.
            RegistrationService.LoginInfo loginInfo =
                (RegistrationService.LoginInfo)Session["loginInfo"];

            if (loginInfo.Role == RegistrationService.UserRole.Agent)
            {
                AgentIdHiddenField.Value = loginInfo.UserId.ToString();
            }
            else
            {
                try
                {
                    AgentSelectionPanel.Visible = true;

                    // Get the list of agents and display.
                    CommonService.CommonService commonService =
                        serviceLoader.GetCommon();

                    AgentNameDropDownList.DataSource = commonService.GetAgentsList();
                    AgentNameDropDownList.DataValueField = "UserId";
                    AgentNameDropDownList.DataTextField = "UserName";
                    AgentNameDropDownList.DataBind();

                    AgentNameDropDownList.Items.Insert(0,
                        new ListItem("<Select an Agent>", "-1"));
                }
                catch (Exception ex)
                {
                    ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                    ErrorMessageLabel.Visible = true;

                    log.Error("Unknown Error", ex);
                }
            }
        }
    }
}

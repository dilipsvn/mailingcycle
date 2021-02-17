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
using DesignService = Irmac.MailingCycle.BLLServiceLoader.Design;

public partial class Members_DesignStatusReportCriteria : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_DesignStatusReportCriteria));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        if (!IsPostBack)
        {
            // Populate data into dropdown lists.
            try
            {
                CommonService.CommonService commonService =
                    serviceLoader.GetCommon();

                // Agents.
                AgentDropDownList.DataSource = commonService.GetAgentsList();
                AgentDropDownList.DataValueField = "UserId";
                AgentDropDownList.DataTextField = "UserName";
                AgentDropDownList.DataBind();

                AgentDropDownList.Items.Insert(0, new ListItem("<All Agents>", "0"));

                // Categories.
                CategoryDropDownList.DataSource = 
                    commonService.GetLookups("Design Category");
                CategoryDropDownList.DataValueField = "LookupId";
                CategoryDropDownList.DataTextField = "Name";
                CategoryDropDownList.DataBind();

                CategoryDropDownList.Items[0].Text = "<All Categories>";

                // Statuses.
                StatusDropDownList.DataSource =
                    commonService.GetLookups("Design Status");
                StatusDropDownList.DataValueField = "LookupId";
                StatusDropDownList.DataTextField = "Name";
                StatusDropDownList.DataBind();

                StatusDropDownList.Items[0].Text = "<All Statuses>";
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

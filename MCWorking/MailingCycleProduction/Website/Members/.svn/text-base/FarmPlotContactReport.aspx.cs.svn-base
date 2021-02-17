#region Namespaces
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
using Irmac.MailingCycle.BLLServiceLoader;
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLL;
using log4net;
using log4net.Config;
using Microsoft.Reporting.WebForms;
#endregion

public partial class Members_FarmPlotContactReport : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Members_FarmPlotContactReport));
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

    #region Methods
    protected int GetAgentId()
    {
        int AgentId = 0;
        if (IsAgentRole)
        {
            AgentId = LoginUserId;
        }
        else
        {
            int.TryParse(AgentListDropDownList.SelectedItem.Value.ToString(), out AgentId);
        }
        return AgentId;
    }
    #endregion

    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();
            
            //Check for Admin Login
            if (!IsPostBack)
            {
                ReportViewerUserControl1.ReportHeight = 580;
                ReportViewerUserControl1.ReportWidth = 800;
                if (IsAgentRole)
                {
                    AgentListPanel.Visible = false;
                    //Populate Report
                    FarmService.FarmDetailsReportInfo[] details = farmService.ReportForFarmDetails(GetAgentId());

                    //ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("FarmDetailsReportInfo", details));
                    ReportViewerUserControl1.DataSource = details;
                    ReportViewerUserControl1.DataSourceName = "FarmDetailsReportInfo";
                    ReportViewerUserControl1.ReportPath = "Members/Reports/FarmPlotContactListReport.rdlc";
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
            else
            {
                if (!IsAgentRole)
                {
                    if (AgentListDropDownList.SelectedIndex > 0)
                    {
                        //Populate Report
                        FarmService.FarmDetailsReportInfo[] details = farmService.ReportForFarmDetails(GetAgentId());
                        //ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("FarmDetailsReportInfo", details));
                        //ReportViewer1.LocalReport.Refresh();

                        ReportViewerUserControl1.DataSource = details;
                        ReportViewerUserControl1.DataSourceName = "FarmDetailsReportInfo";
                        ReportViewerUserControl1.ReportPath = "Members/Reports/FarmPlotContactListReport.rdlc";
                    }
                }
            }
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE LOADING FARM PLOT REPORT:", exception);
            ErrorLiteral.Text = "UNKNOWN ERROR: Contact Administrator";
        }

    }
    protected void SelectedAgentButton_Click(object sender, EventArgs e)
    {
        
    }
    #endregion
}

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
#endregion

public partial class Members_FarmDataReport : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Members_FarmDataReport));
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

    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int userId = 0;
            string where = "";
            if (Request.QueryString["userId"] != null)
                int.TryParse(Request.QueryString["userId"], out userId);
            if (Request.QueryString["where"] != null)
                where = Request.QueryString["where"];
            ReportViewerUserControl1.ReportHeight = 580;
            ReportViewerUserControl1.ReportWidth = 800;

            try
            {
                // Get the common web service instance.
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                FarmService.FarmDataReportInfo[] data = farmService.GetFarmDataReportData(userId,where);
                ReportViewerUserControl1.DataSource = data;
                ReportViewerUserControl1.DataSourceName = "FarmDataReportInfo";
                ReportViewerUserControl1.ReportPath = "Members/Reports/FarmDataReport.rdlc";
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR WHILE LOADING FARM DATA REPORT:", exception);
            }
        }
    }
    #endregion
}

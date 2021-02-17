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

public partial class Members_DesignStatusReport : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_DesignStatusReport));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        if (!IsPostBack)
        {
            // Get the query string values.
            NameValueCollection coll = Request.QueryString;

            int agentId = Convert.ToInt32(coll.Get("aId"));
            int categoryId = Convert.ToInt32(coll.Get("cId"));
            int statusId = Convert.ToInt32(coll.Get("sId"));

            // Set the report viewer control's size.
            ReportViewerControl.ReportWidth = 875;
            ReportViewerControl.ReportHeight = 615;

            // Get the report data.
            try
            {
                DesignService.DesignService designService = 
                    serviceLoader.GetDesign();
                IList<DesignService.DesignStatusInfo> statuses = 
                    designService.GetDesignStatuses(agentId, categoryId, statusId);

                ReportViewerControl.DataSource = statuses;
                ReportViewerControl.DataSourceName = "DesignStatusInfo";
                ReportViewerControl.ReportPath = "Members/Reports/DesignStatusReport.rdlc";
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

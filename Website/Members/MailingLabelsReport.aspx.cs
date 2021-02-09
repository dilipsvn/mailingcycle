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
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;

public partial class Members_MailingLabelsReport : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_MailingLabelsReport));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        if (!IsPostBack)
        {
            // Get the query string values.
            NameValueCollection coll = Request.QueryString;

            int agentId = Convert.ToInt32(coll.Get("aId"));
            int farmId = Convert.ToInt32(coll.Get("fId"));
            int plotId = Convert.ToInt32(coll.Get("pId"));

            // Set the report viewer control's size.
            ReportViewerControl.ReportWidth = 875;
            ReportViewerControl.ReportHeight = 615;

            // Get the report data.
            try
            {
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                IList<FarmService.MailingLabelInfo> mailingLabels = 
                    farmService.GetMailingLabels(agentId, farmId, plotId);

                ReportViewerControl.DataSource = mailingLabels;
                ReportViewerControl.DataSourceName = "MailingLabelInfo";
                ReportViewerControl.ReportPath = "Members/Reports/MailingLabelsReport.rdlc";
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

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
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLLServiceLoader;
using System.Collections.Generic;
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;


public partial class Members_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the common web service instance.
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        FarmService.FarmService farmService = serviceLoader.GetFarm();
        FarmService.FarmDetailsReportInfo[] details = farmService.ReportForFarmDetails(100001);

        ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("FarmDetailsReportInfo", details));
    }
}

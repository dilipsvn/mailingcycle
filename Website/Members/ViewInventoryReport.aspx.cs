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
using Irmac.MailingCycle.BLLServiceLoader.Order;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class ViewInventoryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        char[] delim = new char[]{'|'};
        DateTime startDate = (Convert.ToDateTime(Request.QueryString["startDate"]));
        DateTime endDate = (Convert.ToDateTime(Request.QueryString["endDate"]));
        int userId = Convert.ToInt32(Request.QueryString["userId"]);
        OrderService orderService = ServiceAccess.GetInstance().GetOrder();
        InventoryItemReportInfo[] orderInfo = orderService.GetSearchInventory(userId, startDate, endDate);
        ReportViewerUserControl1.DataSource = orderInfo;
        ReportViewerUserControl1.DataSourceName = "InventoryItemReportInfo";
        ReportViewerUserControl1.ReportPath = "Members/Reports/InventoryReport.rdlc";
        List<ReportParameter> ReportParameters = new List<ReportParameter>();
        ReportParameter param = new ReportParameter("StartDate", startDate.ToShortDateString());
        ReportParameters.Add(param);
        param = new ReportParameter("EndDate", endDate.ToShortDateString());
        ReportParameters.Add(param);
        ReportViewerUserControl1.ReportParameters = ReportParameters;        
    }
}

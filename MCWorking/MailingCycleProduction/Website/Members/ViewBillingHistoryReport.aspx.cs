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

public partial class ViewBillingHistoryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime startDate = (Convert.ToDateTime(Request.QueryString["startDate"]));
        DateTime endDate = (Convert.ToDateTime(Request.QueryString["endDate"]));
        int userId = Convert.ToInt32(Request.QueryString["userId"]);
        OrderService orderService = ServiceAccess.GetInstance().GetOrder();
        OrderInfo[] orderInfo = orderService.GetSearchOrders(userId, Int32.MinValue, Int32.MinValue, startDate, endDate);
        char[] delim = new char[]{'|'};        
        ReportViewerUserControl1.DataSource = orderInfo;
        ReportViewerUserControl1.DataSourceName = "OrderInfo";
        ReportViewerUserControl1.ReportPath = "Members/Reports/BillingHistory.rdlc";
        List<ReportParameter> ReportParameters = new List<ReportParameter>();
        ReportParameter param = new ReportParameter("StartDate", startDate.ToShortDateString());
        ReportParameters.Add(param);
        param = new ReportParameter("EndDate", endDate.ToShortDateString());
        ReportParameters.Add(param);
        ReportViewerUserControl1.ReportParameters = ReportParameters;
    }
}

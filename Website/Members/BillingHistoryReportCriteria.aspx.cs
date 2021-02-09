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
using Irmac.MailingCycle.BLLServiceLoader.Order;
using Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLLServiceLoader;

public partial class BillingHistoryReportCriteria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            DateRangePanel.Visible = false;
            StartDateLink.HRef = "javascript: NewCal('" + StartDateTextBox.ClientID + "','mmddyyyy')";
            EndDateLink.HRef = "javascript: NewCal('" + EndDateTextBox.ClientID + "','mmddyyyy')";            
        }
    }

    protected void LaunchButton_Click(object sender, EventArgs e)
    {
        OrderService orderService = ServiceAccess.GetInstance().GetOrder();
        LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
        int userId = regInfo.UserId;
        DateTime startDate = DateTime.MinValue;
        DateTime endDate = DateTime.MinValue;
        switch (ReportTypeDropDownList.SelectedValue)
        {
            case "1":
                startDate = Convert.ToDateTime(DateTime.Now.Month.ToString() + "/" + "01/" + DateTime.Now.Year.ToString());
                endDate = DateTime.Now;
                break;
            case "2":
                startDate = Convert.ToDateTime("01/01" + "/" + DateTime.Now.Year.ToString());
                endDate = DateTime.Now;
                break;
            case "3":
                startDate = Convert.ToDateTime(StartDateTextBox.Text);
                endDate = Convert.ToDateTime(EndDateTextBox.Text);
                break;
        }       
        
        string script = "<script language=JavaScript id='PopupWindow'>";
        script += "var iWidth = 900;";
        script += "var iHeight = 650;";
        script += "var iLeft = (screen.width - iWidth) / 2;";
        script += "var iTop = ((screen.height - iHeight) / 2) - 20;";

        script += "var sFeatures = \"toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,\";";
        script += "var sSize = \"width=\" + iWidth + \",height=\" + iHeight + \",left=\" + iLeft + \",top=\" + iTop + \"\";";
        script += "window.open('ViewBillingHistoryReport.aspx?userId=" + userId.ToString() +
            "&startDate=" + startDate.ToShortDateString() + "&endDate=" + endDate.ToShortDateString() + "',\"ReportViewer\", sFeatures + sSize);";
        script += "</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "ShowImageDiv", script);        
    }
    protected void ShowDateRange(object sender, EventArgs e)
    {
        if (ReportTypeDropDownList.SelectedValue == "3")
            DateRangePanel.Visible = true;
        else
            DateRangePanel.Visible = false;
    }
}

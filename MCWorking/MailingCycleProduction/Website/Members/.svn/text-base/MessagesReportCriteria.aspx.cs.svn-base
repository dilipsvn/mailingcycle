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
using Irmac.MailingCycle.BLLServiceLoader.Message;
using Irmac.MailingCycle.BLLServiceLoader;

public partial class MessagesReportCriteria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillListFromEnum(CategoryDropDownList, typeof(MessageType));
            CategoryDropDownList.Items.RemoveAt(2);
            CategoryDropDownList.Items.Insert(0, new ListItem("<Select a category>", Convert.ToInt32(MessageType.NullType).ToString()));
            FillListFromEnum(StatusDropDownList, typeof(MessageStatus));
            StatusDropDownList.Items.RemoveAt(2);
            StatusDropDownList.Items.Insert(0, new ListItem("<Select a Status>", Convert.ToInt32(MessageStatus.NullStatus).ToString()));
        }
    }

    private void FillListFromEnum(DropDownList dropDownList, Type enumObject)
    {
        string[] enumNames = Enum.GetNames(enumObject);
        int arrCount = 0;
        while (arrCount < enumNames.Length)
        {
            dropDownList.Items.Add(new ListItem(enumNames[arrCount], arrCount.ToString()));
            arrCount++;
        }
    }
    protected void LaunchButton_Click(object sender, EventArgs e)
    {
        MessageService messageService = ServiceAccess.GetInstance().GetMessage();
        int messageId = MessageIdTextBox.Text == string.Empty ? Int32.MinValue : Convert.ToInt32(MessageIdTextBox.Text);
        MessageType msgType = (MessageType)Convert.ToInt32(CategoryDropDownList.SelectedValue);
        MessageStatus msgStatus = (MessageStatus)Convert.ToInt32(StatusDropDownList.SelectedValue);

        string script = "<script language=JavaScript id='PopupWindow'>";
        script += "var iWidth = 900;";
        script += "var iHeight = 650;";
        script += "var iLeft = (screen.width - iWidth) / 2;";
        script += "var iTop = ((screen.height - iHeight) / 2) - 20;";

        script += "var sFeatures = \"toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,\";";
        script += "var sSize = \"width=\" + iWidth + \",height=\" + iHeight + \",left=\" + iLeft + \",top=\" + iTop + \"\";";       
        script += "window.open('ViewMessagesReport.aspx?messageId=" + messageId.ToString() +
            "&msgType=" + Convert.ToInt32(msgType).ToString() + "&msgStatus=" + Convert.ToInt32(msgStatus).ToString() + "',\"ReportViewer\", sFeatures + sSize);";
        script += "</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "ShowImageDiv", script);                
    }
}

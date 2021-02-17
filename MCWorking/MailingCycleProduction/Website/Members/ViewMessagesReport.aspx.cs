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
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using Irmac.MailingCycle.BLLServiceLoader.Message;
using System.IO;

public partial class ViewMessagesReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int messageId = Convert.ToInt32(Request.QueryString["messageId"]);
        MessageStatus msgStatus = (MessageStatus)Convert.ToInt32(Request.QueryString["msgStatus"]);
        MessageType msgType = (MessageType)Convert.ToInt32(Request.QueryString["msgType"]);
        MessageService messageService = ServiceAccess.GetInstance().GetMessage();
        MessageInfo[] messageInfo = messageService.GetSearchMessages(messageId, msgStatus, msgType);
        foreach (MessageInfo info in messageInfo)
        {
            if (info != null && info.MessageText != string.Empty)
            {
                StringReader stringReader = new StringReader(info.MessageText);
                //Read the first line
                string line = stringReader.ReadLine();
                while (line.IndexOf(">") >= 0)
                {
                    int start = line.IndexOf("<");
                    int end = line.IndexOf(">");
                    line = line.Remove(start, end - start + 1);
                }
                //loop till the next non-empty line
                while (stringReader.Peek() >= 0)
                {
                    line = stringReader.ReadLine();
                    while (line.IndexOf(">") >= 0)
                    {
                        int start = line.IndexOf("<");
                        int end = line.IndexOf(">");
                        line = line.Remove(start, end - start + 1);
                    }
                    if (line != string.Empty && line != "&nbsp;")
                        break;
                }
                info.MessageText = line;
            }
        }
        ReportViewerUserControl1.DataSource = messageInfo;
        ReportViewerUserControl1.DataSourceName = "MessageInfo";
        ReportViewerUserControl1.ReportPath = "Members/Reports/MessagesReport.rdlc";        
    }
}

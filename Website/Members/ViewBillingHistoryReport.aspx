<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewBillingHistoryReport.aspx.cs" Inherits="ViewBillingHistoryReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="../WebUserControls/ReportViewerUserControl.ascx" TagName="ReportViewerUserControl"
    TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>Billing History Report</title>
</head>

<body style="font-family:Verdana;font-size:8pt">
<form id="ReportForm" runat="server">
        <div>
            <table border="1" cellspacing="0" cellpadding="0" width="100%">
                
                <tr>
                    <td>
                        <img src="../Images/spacer.gif" width="1" height="1" /></td>
                </tr>
                <tr>
                    <td>
                        <uc1:ReportViewerUserControl ID="ReportViewerUserControl1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
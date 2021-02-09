<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleMgmtReport.aspx.cs"
    Inherits="Members_ScheduleMgmtReport" %>

<%@ Register Src="../WebUserControls/ReportViewerUserControl.ascx" TagName="ReportViewerUserControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mailing Cycle Schedule Management Report</title>
</head>
<body style="font-family: Verdana; font-size: 8pt">
    <form id="ReportForm" runat="server">
        <div>
            <table border="1" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="ErrorMessageLabel" runat="server" Visible="false" CssClass="errormessage"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="../Images/spacer.gif" width="1" height="1" /></td>
                </tr>
                <tr>
                    <td>
                        <uc1:ReportViewerUserControl ID="ReportViewerControl" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

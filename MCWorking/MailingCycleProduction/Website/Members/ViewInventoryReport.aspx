<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewInventoryReport.aspx.cs" Inherits="ViewInventoryReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="../WebUserControls/ReportViewerUserControl.ascx" TagName="ReportViewerUserControl"
    TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>Inventory Report</title>
</head>

<body style="font-family:Verdana;font-size:8pt">
<form id="FarmPlotReport" runat="server"><table width=100%>
<tr><td width="100%">
    <uc1:ReportViewerUserControl ID="ReportViewerUserControl1" runat="server" />       
    </td>
</tr>    
</table>
</form>
</body>
</html>
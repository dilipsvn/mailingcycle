<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportViewerUserControl.ascx.cs" Inherits="WebUserControls_ReportViewerUserControl" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
 <center><h6><asp:Label ID="PrintInfo">Please Export to PDF for printing the reports</asp:Label></h6></center>
 <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="480px" Width="720px" ProcessingMode="local" ShowBackButton="true" ShowDocumentMapButton="true" ShowExportControls="true" ShowFindControls="true" ShowParameterPrompts="false" ShowReportBody="true" SizeToReportContent="true" ShowToolBar="true" ShowZoomControl="true" DocumentMapCollapsed="true">
                
        <LocalReport ></LocalReport>
        </rsweb:ReportViewer>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Members_test" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="right-content-mainsection">
    <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td height="30" class="tableheading">
                Detail Report of Farm,Plot and Contact
            </td>
        </tr>
        <tr>
            <td class="rowborder">
                <img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
        <tr>
            <td>
            <p>&nbsp;</p>
            <p>
               <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    height="400px" width="720px"  ProcessingMode="local" ShowBackButton="true" ShowDocumentMapButton="true" ShowExportControls="true" ShowFindControls="true" ShowParameterPrompts="false" ShowReportBody="true" SizeToReportContent="true" ShowToolBar="true" ShowZoomControl="true" DocumentMapCollapsed="true">
                    <LocalReport ReportPath="Members\Reports\testReport.rdlc">
                    </LocalReport>
                </rsweb:ReportViewer>
            </p>
            </td>
        </tr>
        <tr>
            <td class="rowborder">
                <img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
    </table>
</div>

</asp:Content>


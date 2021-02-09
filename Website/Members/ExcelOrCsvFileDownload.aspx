<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ExcelOrCsvFileDownload.aspx.cs" Inherits="Members_ExcelOrCsvFileDownload" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
    Export to Excel or CSV File
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Error : 
                    <asp:literal ID="ErrorLiteral" runat="server" Text=""></asp:literal>
                </td>
            </tr>
            <tr>
                <td> &nbsp; </td>
            </tr>
        </table>
    </div>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FarmPlotContactReport.aspx.cs" Inherits="Members_FarmPlotContactReport" Title="Mailing Cycle Farm Plot Contact Report" %>

<%@ Register Src="../WebUserControls/ReportViewerUserControl.ascx" TagName="ReportViewerUserControl"
    TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mailing Cycle Farm Plot Contact Report</title>
</head>
<body style="font-family:Verdana;font-size:8pt">
    <form id="FarmPlotReport" runat="server">
        <div>
            <table cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <asp:Panel ID="AgentListPanel" runat="server" Width="100%" Visible="false">
                            <fieldset>
                                <legend class="LegendText">Agent List</legend>
                                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                                    <tr>
                                        <td width="24%">
                                            <asp:Label ID="AgentListLabel" runat="server" Text="Select an Agent" AssociatedControlID="AgentListDropDownList"></asp:Label></td>
                                        <td width="24%">
                                            <asp:DropDownList ID="AgentListDropDownList" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="15%">
                                            <asp:Button ID="SelectedAgentButton" runat="server" Text="Go" OnClick="SelectedAgentButton_Click" />
                                        </td>
                                        <td width="35%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="24%">&nbsp;</td>
                                        <td width="24%">
                                            <asp:Label ID="AgentListErrorLiteral" runat="server" cssClass="errormessage"></asp:Label>
                                        </td>
                                        <td width="50%" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="rowborder">
                        <img src="../images/transparent.gif" width="1" height="3" /></td>
                </tr>
                <tr>
                    <td>
                        <uc1:ReportViewerUserControl ID="ReportViewerUserControl1" runat="server" />
                        &nbsp;<p>&nbsp;</p>
                        <p>
                            &nbsp;</p>
                        <p>&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="rowborder">
                        <img src="../images/transparent.gif" width="1" height="1" /></td>
                </tr>
            </table>
        </div>
    </form>
</body> 
</html> 
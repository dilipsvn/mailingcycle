<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="Welcome.aspx.cs" Inherits="Agent_Welcome" Title="Mailing Cycle Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Dashboard
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="33%" align="center" valign="top">
                                <a href="FarmManagement.aspx">
                                    <img src="../Images/farm_mgt.jpg" width="120" height="80" alt="Farm Management" />
                                    <h4 style="margin: 10px 0px 10px 0px">
                                        Farm Management</h4>
                                </a>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2"><asp:Label id="FarmPlotLabel" runat="Server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><asp:Label id="ContactLabel" runat="Server"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="34%" align="center" valign="top">
                                <a href="DesignManagement.aspx">
                                    <img src="../Images/design_mgt.jpg" width="120" height="80" alt="Design Management" />
                                    <h4 style="margin: 10px 0px 10px 0px">
                                        Design Management</h4>
                                </a>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="right">Powerkard:&nbsp;</td>
                                        <td align="left"><i><asp:Label id="PowerKardStatusLabel" runat="server"></asp:Label></i></td>
                                    </tr>
                                    <tr>
                                        <td align="right">Brochure:&nbsp;</td>
                                        <td align="left"><i><asp:Label id="BrochureStatusLabel" runat="server"></asp:Label></i></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="33%" align="center" valign="top">
                                <a href="MessageManagement.aspx">
                                    <img src="../Images/message_mgt.jpg" alt="Message Management" width="120" height="80" />
                                    <h4 style="margin: 10px 0px 10px 0px">
                                        Message Management</h4>
                                </a>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="right">Standard:&nbsp;</td>
                                        <td align="left"><asp:Label id="StandardMessagesLabel" runat="Server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right">Custom:&nbsp;</td>
                                        <td align="left"><asp:Label id="CustomMessagesLabel" runat="Server"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr><td colspan="3" height="50">&nbsp;</td></tr>
                        <tr>
                            <td align="center" valign="top">
                                <a href="Inventory.aspx">
                                    <img src="../Images/inventory_mgt.jpg" alt="Inventory Management" width="120" height="80" />
                                    <h4 style="margin: 10px 0px 10px 0px">
                                        Inventory Management</h4>
                                </a>
                                <asp:Label id="InventoryLabel" runat="server"></asp:Label>
                            <asp:Repeater ID="InventoryRepeater" runat="server">
                                <ItemTemplate>
                                    <asp:Label ID="ProductTypeLabel" runat="server" Text='<%#Eval("ProductType")%>'></asp:Label>:
                                    <asp:Label ID="QuantityLabel" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label><br />
                                </ItemTemplate>
                            </asp:Repeater>
                            </td>
                            <td align="center" valign="top">
                                <a href="ScheduleManagement.aspx">
                                    <img src="../Images/schedule_mgt.jpg" alt="Schedule Management" width="120" height="80" />
                                    <h4 style="margin: 10px 0px 10px 0px">
                                        Schedule Management</h4>
                                </a>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label id="ActivePlansLabel" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label id="DelayedPlansLabel" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="center" valign="top">
                            <asp:Panel id="UserManagementPanel" runat="server">
                                <a href="SearchUsers.aspx">
                                    <img src="../Images/schedule_mgt.jpg" alt="User Management" width="120" height="80" />
                                    <h4 style="margin: 10px 0px 10px 0px">
                                        User Management</h4>
                                </a>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label id="UsersLabel" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            </td>
                        </tr>
                    </table> 
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td height="50">
                </td>
            </tr>
            <tr>
                <td style="background-color: #c9cacd">
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="WelcomeHelpPanel" runat="server" visible="false">
                        <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    Upd - Uploaded, Sub - Submitted, App - Approved
                                </td>
                            </tr>
                        </table>
                    </asp:Panel> 
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

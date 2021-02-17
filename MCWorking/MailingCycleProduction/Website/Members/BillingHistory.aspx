<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="BillingHistory.aspx.cs" Inherits="BillingHistory" Title="Mailing Cycle Billing History" %>
<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Billing History
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="tableheading">
                    <asp:Literal ID="TitleLiteral" runat="server">View your Orders</asp:Literal> </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <asp:panel id="AgentPanel" runat="server" visible=false>
                    
                         <tr>
                        <td >
                            <fieldset>
                                
                                <legend class="LegendText">Agent Selection</legend>
                                <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="t3" nowrap>
                                            <uc1:ListOfAgentsWebUserControl ID="ListOfAgentsWebUserControl1" runat="server" AutoPostBack="false" />
                                            <asp:button runat=server cssclass="buttonfont" text="Go" style="width: 30px" ID="GoButton" CausesValidation="true" OnClick="GoButton_Click" />                                            
                                            <asp:CustomValidator runat=server ID="AgentRFValidator" ControlToValidate="ListOfAgentsWebUserControl1" ErrorMessage="Please select an agent" OnServerValidate="ServerValidation" ></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2">
                                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                </table>                                
                            </fieldset>
                        </td>
                    </tr>
                    </asp:panel>
                    </table>
                    <img src="../Images/spacer.gif" width="1" height="8" /><br />
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText"><asp:Literal ID="SubTitleLiteral" runat="server">List of Orders</asp:Literal> </legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <asp:Label id="ErrorLiteral" runat="server" CssClass="errormessage"></asp:Label>
                                    <asp:GridView AutoGenerateColumns="False" ID="BillingGridView" runat="server" BorderWidth="1" AllowPaging="True" PageSize="20" OnPageIndexChanging="SearchUsersResultGridView_PageIndexChanging" cellspacing="0" cellpadding="4" width="100%" style="border-collapse: collapse" OnRowDataBound="BillingGridView_RowDataBound" OnRowCommand="BillingGridView_RowCommand">
                                    <Columns>
                                        <asp:ButtonField ItemStyle-Width="20%" ButtonType =Link CommandName="ViewTransaction" HeaderText="Order ID" DataTextField="OrderId" />
                                        <asp:BoundField HeaderText="Agent" DataField="UserName" Visible=false />
                                        <asp:BoundField ItemStyle-Width="15%" DataField="Date" HeaderText="Order Date" />
                                        <asp:BoundField ItemStyle-Width="20%" HeaderText="Order Type" />
                                        <asp:BoundField ItemStyle-Width="20%" DataField="Type" HeaderText="Payment Type" />
                                        <asp:BoundField ItemStyle-Width="25%" HeaderText="Payment Details" />
                                        <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Right" HeaderText="Amount (US $)" DataField="Amount" />
                                    </Columns>
                                    </asp:GridView>
                                    <table id="NoRecordsTable" runat="server" visible="false" border="1" cellspacing="0"
                                        cellpadding="5" width="100%" height="60px" style="border-collapse: collapse">
                                        <tr>
                                            <td nowrap align="center" class="errormessage">
                                                No Billing history available.</td>
                                        </tr>
                                    </table>
                                </fieldset>
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
                            <td align="center">
                                <asp:Button runat="server" cssclass="buttonfont" PostBackUrl="~/Members/searchOrders.aspx" text="Back" Visible="false" style="width: 100px" ID="BackButton" />
                            </td>
                        </tr>    
        </table>
    </div>
</asp:Content>
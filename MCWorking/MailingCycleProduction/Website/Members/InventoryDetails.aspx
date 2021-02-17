<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="InventoryDetails.aspx.cs" Inherits="InventoryDetails" Title="Mailing Cycle Inventory Transactions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Inventory Transactions
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                View your Inventory transactions
                            </td>
                            <td align="right">
                                <asp:Literal ID="AgentLiteral" runat="server"></asp:Literal>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>                    
                    </table> 
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                              <fieldset>
                                                <legend class="LegendText"><asp:literal id="CategoryTypeLiteral" runat="server"></asp:literal></legend>
                                                <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                                <tr>
                                            <td colspan="5">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                                    <tr>
                                                        <td class="t3"> Quantity on Hand: 
                                                        <asp:literal id="QuantityOnHandLiteral" runat="server"></asp:literal></td>
                                                    
                                                    <td colspan=4>&nbsp;</td>
                                                    </tr>
                                                <tr>
                                            <td colspan="5">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                                </table>
                                                <table border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse">                        
                                                    <asp:Repeater   ID="InventoryRepeater" runat="server" >
                                                    <HeaderTemplate>                    
                                                              <thead><tr>
                                                                                <th width="16%" nowrap>
                                                                                    Transaction ID</th>
                                                                                <th width="16%" nowrap>
                                                                                    Type</th>
                                                                                <th width="16%" nowrap>
                                                                                    Date</th>
                                                                                <th width="12%" nowrap>
                                                                                    Quantity</th>
                                                                      </tr> </thead>                 
                                                                        
                                                    </HeaderTemplate>
                                                    <ItemTemplate>   
                                                    <tbody>
                                                    <tr>
                                                            <td>
                                                                <asp:Literal ID="TransactionIDLiteral" runat="server" Text='<%# Eval("TransactionId") %>'></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="TypeLiteral" runat="server" Text='<%# Convert.ToString(Eval("OrderTransactionType")) %>'></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="DateLiteral" runat="server" Text='<%# Convert.ToDateTime(Eval("TransactionDate")).ToShortDateString() %>'></asp:Literal></td>
                                                            <td align="right">
                                                                <asp:Literal ID="QuantityLiteral" runat="server" Text='<%# Eval("Quantity") %>'></asp:Literal></td>                                                            
                                                     </tr>                                                                        
                                                    </ItemTemplate>                                                    
                                                    </asp:Repeater>
                                                </tbody></table>
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
                    <asp:button cssclass="buttonfont" Text="Back" id="BackButton" OnClick="BackButton_Click" runat="server" style="width: 80px" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

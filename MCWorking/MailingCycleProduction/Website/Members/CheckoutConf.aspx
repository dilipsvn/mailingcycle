<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="CheckoutConf.aspx.cs" Inherits="CheckoutConf" Title="Mailing Cycle Order Cofirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Order Confirmation
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                Order Placed
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
                    <img src="../images/transparent.gif" width="1" height="1" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Your Order (<b><asp:Literal ID="OrderLiteral" runat="server"></asp:Literal></b>) has been Successfully Generated..... </td>
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
                                    <legend class="LegendText">Order Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2">
                                                Order No:
                                            </td>
                                            <td width="80%" class="t3">
                                                <asp:Literal ID="OrderNoLiteral" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Transaction No:
                                            </td>
                                            <td class="t3">
                                                <asp:Literal ID="TransactionNoLiteral" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                               Order Date :
                                            </td>
                                            <td class="t3">
                                                <asp:Literal ID="OrderDateLiteral" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                               Payment Details:
                                            </td>
                                            <td class="t3">
                                                <asp:Literal ID="PaymentDetailsLiteral" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap valign="top">
                                                Billing Address:
                                            </td>
                                            <td class="t3">
                                                <asp:Literal ID="BillingAddressLiteral" runat="server"></asp:Literal>
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
                    </table>
                    <img src="../Images/spacer.gif" width="1" height="8" /><br />
                
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">List of ordered products</legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <asp:Label id="ErrorLiteral" runat="server" CssClass="errormessage"></asp:Label>
                                    <table border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse">
                                    <tr style="border-bottom-style:none"><td colspan=6 style="border-bottom-style:none">
                                    <asp:GridView AutoGenerateColumns="false" cellspacing="0" cellpadding="5" width="100%" runat="server" ID="CartGridView" BorderWidth="1" >
                                    <Columns>
                                        <asp:BoundField HeaderText="Product Id" ItemStyle-Width="15%" DataField="ProductId" />
                                        <asp:TemplateField HeaderText="Description" ItemStyle-Width="40%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="DescLabel" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Quantity"  ItemStyle-Width="10%" DataField="Quantity" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Price (US $)" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" DataField="Price" />
                                        <asp:BoundField HeaderText="Total (US $)" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" DataField="TotalPrice" />
                                    </Columns>
                                    </asp:GridView>
                                    </td></tr>
                                        
                                    <tr >
                                        <td colspan="4" align="right">
                                            Sub Total: </td>
                                        <td align="right" width="10%">
                                            <asp:Literal id="SubTotalLiteral" runat="server"></asp:Literal> </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Shipping &amp; Handling Charges: </td>
                                        <td align="right">
                                            <asp:Literal id="ShippingLiteral" runat="server"></asp:Literal></td>     
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Tax: </td>
                                        <td align="right">
                                            <asp:Literal id="TaxLiteral" runat="server"></asp:Literal></td>                                        
                                    </tr>
                                            <tr>
                                                <td colspan="4" align="right">Discount:                                                                                                       
                                                </td>
                                                <td align="right">
                                                    <asp:Literal id="DiscountLiteral" runat="server"></asp:Literal></td>                                               
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="right">
                                                    <strong>Grand Total:</strong> </td>
                                                <td align="right">
                                                    <strong><asp:Literal id="GrandTotalLiteral" runat="server"></asp:Literal></strong></td>   
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
                    <asp:Button ID="BackButton" class="buttonfont" width="80px" runat="server" Text="Done" onClick="DoneButton_Click"/>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

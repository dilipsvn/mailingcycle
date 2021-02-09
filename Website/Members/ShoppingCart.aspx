<%@ Page ValidateRequest="false" Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" Title="Mailing Cycle Shopping Cart" %>
<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Shopping Cart
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    View your Shopping Cart
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
                                            <asp:button runat=server cssclass="buttonfont" text="Go" style="width: 30px" ID="GoButton" OnClick="GoButton_Click" CausesValidation="true"  />                                            
                                            <asp:CustomValidator runat=server ID="AgentRFValidator" ControlToValidate="ListOfAgentsWebUserControl1" OnServerValidate="ServerValidation" ErrorMessage="Please select an agent"></asp:CustomValidator>
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
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">List of products in the cart</legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <asp:Label id="ErrorLiteral" runat="server" CssClass="errormessage"></asp:Label>
                                    <asp:panel id="CartPanel" runat="server">
                                    <table border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse">
                                    <tr style="border-bottom-style:none"><td colspan=6 style="border-bottom-style:none">
                                    <asp:GridView AutoGenerateColumns="false" cellspacing="0" cellpadding="5" width="100%" runat="server" ID="CartGridView" BorderWidth="1" OnRowCommand="CartGridView_Command">
                                    <Columns>
                                        <asp:BoundField HeaderText="Product Id" ItemStyle-Width="15%" DataField="ProductId" />
                                        <asp:TemplateField HeaderText="Description" ItemStyle-Width="40%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="DescLabel" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity" ItemStyle-Width="10%" >
                                        <ItemTemplate>
                                            <asp:TextBox Text='<%# Eval("Quantity") %>' width="50" runat="server" ID="QuantityTextBox"></asp:TextBox>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Price (US $)" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" DataField="Price" />
                                        <asp:BoundField HeaderText="Total (US $)" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" DataField="TotalPrice" />
                                        <asp:ButtonField ControlStyle-CssClass="buttonfont" ButtonType=Button Text="Remove" CommandName="RemoveItem" />                                                                               
                                    </Columns>
                                    </asp:GridView>
                                    </td></tr>
                                        
                                    <tr >
                                        <td colspan="4" align="right">
                                            Sub Total: </td>
                                        <td align="right" width="10%">
                                            <asp:Literal id="SubTotalLiteral" runat="server"></asp:Literal> </td>
                                         <td width="11%" >&nbsp; 
                                         </td>                                       
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Shipping &amp; Handling Charges: </td>
                                        <td align="right">
                                            <asp:Literal id="ShippingLiteral" runat="server"></asp:Literal></td>     
                                        <td width="11%" >&nbsp; 
                                         </td>                                                                          
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Tax: </td>
                                        <td align="right">
                                            <asp:Literal id="TaxLiteral" runat="server"></asp:Literal></td>                                        
                                        <td width="11%" >&nbsp; 
                                         </td>                                       
                                    </tr>
                                            <tr>
                                                <td colspan="4">                                                   
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td width="30%">Promotion Code :</td>
                                                            <td><asp:TextBox runat="server" id="PCodeTextBox" width="80" maxlength="10" />
                                                            &nbsp;<asp:Button id="PCodeButton" Text="Apply" runat="server" OnClick="PCodeButton_Click" />
                                                            <asp:Label runat="server" id="DiscountErrorLiteral" CssClass="errormessage"></asp:Label> </td>
                                                            <td><span id="pcodeError">&nbsp;</span></td>
                                                            <td align=right>Discount:</td>
                                                        </tr>
                                                    </table>                                                   
                                                </td>
                                                <td align="right">
                                                    <asp:Literal id="DiscountLiteral" runat="server"></asp:Literal></td>                                               
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="right">
                                                    <strong>Grand Total:</strong> </td>
                                                <td align="right">
                                                    <strong><asp:Literal id="GrandTotalLiteral" runat="server"></asp:Literal></strong></td>   
                                                <td width="11%"  >&nbsp; 
                                         </td>                                                                                    
                                            </tr>
                                    </table>
                                    </asp:panel>
                                    <table id="NoRecordsTable" runat="server" visible="false" border="1" cellspacing="0"
                                        cellpadding="5" width="100%" height="60px" style="border-collapse: collapse">
                                        <tr>
                                            <td align="center" class="errormessage">
                                                <asp:label runat="server" id="NoRecordsLabel" visible=false></asp:label></td>
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
                    <input class="buttonfont" type="button" value="Continue Shopping" style="width: 120px" onclick="javascript:location.href='Productcatalog.aspx'" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:button cssclass="buttonfont" text="Recalculate" id="RecalculateButton" runat="server" onclick="RecalculateButton_Click" style="width: 80px"/>
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:button cssclass="buttonfont" text="Checkout" id="CheckOutButton" style="width: 80px" OnClick="CheckOutButton_Click" runat="server" />
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
                    <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                            <td class="Notes" valign="top">
                                If you've made changes in the quantity for any item , please click on the recalculate button to update your total.                                                
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


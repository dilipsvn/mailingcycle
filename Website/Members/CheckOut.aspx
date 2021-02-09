<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" Title="Mailing Cycle Place Your Order" %>

<%@ Register Src="../WebUserControls/CreditCardWebUserControl.ascx" TagName="CreditCardWebUserControl"
    TagPrefix="uc1" %>
    <%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Place Your Order
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <script type="text/javascript">
    function openHelp(path)
    {
        var iWidth = 450;
        var iHeight = screen.height - 100;
        var iLeft = (screen.width - iWidth) - 12;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
        window.open(path, "Help", sFeatures + sSize);
    }
</script>   
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                Checkout
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
                <asp:ValidationSummary ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:" />
            </td>
        </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">List of ordering products</legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <asp:Label id="ErrorLiteral" runat="server" CssClass="errormessage"></asp:Label>
                                    <asp:UpdatePanel  id="CartPanel" runat="server">
                                    <ContentTemplate>
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
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                    <tr><td><img src="../Images/spacer.gif" width="1" height="8" /><br /></td></tr>
                    <tr><td align="right"> <asp:Button ID="ChangeCardDetailsButton" CausesValidation="false" CssClass="buttonfont" width="120px" runat="server" Text="Change Card Details" OnClick="ChangeCardDetailsButton_Click" /></td></tr>
                    <tr><td width="98%">
                                <asp:label id="CardLabel" visible=false runat="server"></asp:label>
                                <uc1:CreditCardWebUserControl ID="CreditCardDetails1" runat="server" />
                                
                            
                   </td></tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="PayNowButton" CssClass="buttonfont" width="120px" runat="server" Text="Place Your Order" OnClick="PayNowButton_Click" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="BackButton" CausesValidation="false" CssClass="buttonfont" width="80px" runat="server" Text="Back" OnClick="BackButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


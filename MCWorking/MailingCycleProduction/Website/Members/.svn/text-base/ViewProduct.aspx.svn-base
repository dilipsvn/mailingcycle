<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="ViewProduct"  Title="Mailing Cycle View Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
    View Product
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript">
    function deleteItem(msg)
    {
        confirm(msg);
    }
    </script>
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="tableheading">
                    View the product details</td>
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
                <asp:Label runat="server" ID="ErrorLiteral" CssClass="errormessage"></asp:Label>
            </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Product details</legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <table border="0" cellspacing="0" cellpadding="4" width="100%" style="border-collapse: collapse">
                                        <tr>
                                            <td class="t2" width="30%" align="left" valign="top">
                                                <asp:Image ID="ProductImage" runat="server" width="250" height="150" BorderWidth="0" />                                                
                                            </td>
                                            <td width="10%" ><img src="../images/transparent.gif" width="1" height="1" /></td>
                                            <td width="60%" align="left" valign="top">
                                                <table border="0" cellspacing="2" cellpadding="3" width="100%" style="border-collapse: collapse">
                                                    <tr>
                                                        <td><asp:Label ID="BriefDescLabel" runat="server"></asp:Label>                                                      
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td><asp:Label ID="ProductIdLabel" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><asp:Label ID="ProductPriceLabel" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:button id="ShoppingCartButton" cssclass="shopping-cart-button" text="Add to Cart" runat="server" OnClick="AddToCart" />
                                                            <asp:Label ID="CustomProductLabel" runat="server" >Please call customer service at 1-800-XYZ-ABCD to place an order of PowerKards based on your custom design.</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <table border="0" cellspacing="5" cellpadding="6" width="100%" style="border-collapse: collapse">
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="ExtDescLabel"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
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
                    <asp:button runat="server" Visible="false" id="EditButton" cssclass="buttonfont" text="Edit Product" style="width: 80px" OnClick="EditButton_Click" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:button cssclass="buttonfont" Visible="false" runat=server text="Delete Product" style="width: 90px" onclick="DeleteButton_Click" id="DeleteButton" OnClientClick="javascript: return confirm('You are about to delete a product. Are you sure?');" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:button cssclass="buttonfont" text="Back" style="width: 80px" onclick="BackButton_Click" runat="server" id="BackButton" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table> 
    </div>

</asp:Content>


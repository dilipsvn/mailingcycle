<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" Title="Mailing Cycle Product List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
    Product List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="right-content-mainsection">
    <table width="100%" cellspacing="0" cellpadding="0" class="toptable">
        <tr>
            <td height="30" class="tableheading">
                View Product List
            </td>
        </tr>
        <tr>
            <td class="rowborder">
                <img src="../images/transparent.gif" width="1" height="1" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="ErrorLiteral" CssClass="errormessage"></asp:Label>
            </td>
            </tr>            
        <tr>
            <td>
                <!-- Content panel for Powerkard -->
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText"><asp:literal id="SubTitleLiteral" runat=server></asp:literal></legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                       <asp:GridView BorderWidth="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse" ID="ProductListGridView" runat="server" autogeneratecolumns="false" OnRowCommand="ProductListGridView_RowCommand" OnRowDataBound="ProductListGridView_RowDataBound">
                                                    <Columns>
                                                        <asp:ButtonField ButtonType=Image ItemStyle-Width="5%" Visible=false ImageUrl="~/Images/edit_icon.gif" CommandName="EditProduct" />   
                                                        <asp:ButtonField  ButtonType="link" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left" DataTextField="ProductId" HeaderText="Product ID" CommandName="ViewProduct"/>
                                                        <asp:TemplateField HeaderText="Description" ItemStyle-Width="40%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="DescLabel" runat="server" Text='<%# Eval("BriefDescWithQuantity") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TotalPrice" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" ReadOnly="true" HeaderText="Price (US $)" />
                                                        <asp:BoundField DataField="ProductStatus" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%" ReadOnly="true" HeaderText="Product Status" />
                                                        <asp:TemplateField ItemStyle-HorizontalAlign=Center >
                                                        <ItemTemplate>
                                                                <asp:Button ID="AddToCartButton" Text="Add To Cart" runat="server" CssClass="shopping-cart-button" CommandArgument='<%# Eval("ProductId") %>' OnClick="AddToCart" />
                                                            <asp:Label ID="CustomProductLabel" runat="server" >Please call customer service at 1-800-XYZ-ABCD to place an order of PowerKards based on your custom design.</asp:Label>
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>   
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
                        <tr>
                            <td>
                                
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
                <asp:button id="ViewShoppingCartButton" text="View Shopping Cart" runat="server" cssclass="view-shopping-cart-button" OnClick="ViewShoppingCartButton_Click" />            
                <img src="../Images/spacer.gif" width="10" height="1" />
                <input class="buttonfont" type="button" value="Back" style="width: 80px" onclick="javascript:location.href='ProductCatalog.aspx'" />
            </td>
        </tr>
        <tr>
            <td>
                <img src="../Images/spacer.gif" width="1" height="20" /></td>
        </tr>
    </table>
</div>

</asp:Content>
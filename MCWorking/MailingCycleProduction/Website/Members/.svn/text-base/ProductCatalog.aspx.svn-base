<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ProductCatalog.aspx.cs" Inherits="ProductCatalog" Title="Mailing Cycle Product Catalog" %>

<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
    Product Catalog
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="right-content-mainsection">
    <table width="100%" cellspacing="0" class="toptable">
        <tr>
            <td height="30" class="tableheading">
                Select a product category
            </td>
        </tr>
        <tr>
            <td class="rowborder">
                <img src="../images/transparent.gif" width="1" height="1" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" width="98%">
                    <asp:Panel id="AddPanel" runat="server" visible="false">
                    <tr>
                        <td align="right">
                            <input class="buttonfont" type="button" value="Add Product" onclick="javascript: document.location.href='CreateProduct.aspx'"
                                style="width: 80px" />
                        </td>
                    </tr>
                    </asp:Panel>
                    <tr>
                        <td>
                            <img src="../images/transparent.gif" width="1" height="4" /></td>
                    </tr>
                    <tr>
                    <td>
                <asp:Label runat="server" ID="ErrorLiteral" CssClass="errormessage"></asp:Label>
            </tr></td>
                </table>
            
                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                    <tr>
                        <td>
                            <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    <tr>
                                    <asp:DataList ItemStyle-HorizontalAlign=Center width="100%" RepeatColumns="3" cellspacing="2" cellpadding="3"  OnItemDataBound="ProductListDataList_ItemDataBound" RepeatDirection="Horizontal" ID="ProductListDataList" runat="server">                                    
                                    <ItemTemplate>
                                        <img src="../Images/spacer.gif" width="1" height="1" />
                                        <asp:HyperLink ID="ProductHyperLink" runat="server">
                                        <asp:Image ID="ProductImage" runat=server />                                         
                                        <h5 style="margin: 10px 0px 10px 0px" >
                                               <asp:Literal runat="server" id="ProductTypeLiteral"></asp:Literal>
                                         </h5>                                      
                                         </asp:HyperLink> 
                                    </ItemTemplate>
                                    </asp:DataList></tr>                                  
                                </table> 
                        </td> 
                    </tr> 
                </table>
                <img src="../Images/spacer.gif" width="1" height="16" /><br />
                <asp:panel id="AgentPanel" runat="server" visible=false>
                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                    <tr>
                        <td >
                            <fieldset>
                                
                                <legend class="LegendText">Custom Product Category (Agent Specific)</legend>
                                <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="t3" nowrap>
                                            <uc1:ListOfAgentsWebUserControl ID="ListOfAgentsWebUserControl1" runat="server" AutoPostBack="false" />
                                            <asp:button runat=server cssclass="buttonfont" text="Go" style="width: 30px" ID="GoButton" OnClick="GoButton_Click" CausesValidation="true"  />                                            
                                            <asp:CustomValidator runat="server" id="AgentRFValidator" ControlToValidate="ListOfAgentsWebUserControl1" OnServerValidate="ServerValidation" ErrorMessage="Please select an agent" />
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
                </asp:panel>
                <img src="../Images/spacer.gif" width="1" height="8" /><br />
                
            </td>
        </tr>
        <tr>
            <td>
                <img src="../Images/spacer.gif" width="1" height="8" /></td>
        </tr>
    </table>
</div>


</asp:Content>


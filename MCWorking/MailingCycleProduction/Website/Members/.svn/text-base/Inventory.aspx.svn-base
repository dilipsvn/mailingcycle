<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="Inventory.aspx.cs" Inherits="Inventory" Title="Mailing Cycle Inventory" %>
<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Inventory
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    View your Inventory
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
                    <img src="../Images/spacer.gif" width="1" height="8" /><br /></td></tr>
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                                <tr>
                                    <td>
                                        <asp:Repeater ID="InventoryGridView" runat="server" OnItemDataBound="InventoryGridView_DataBound" OnItemCommand="InventoryGridView_Command">
                                            <ItemTemplate>                       
                                                <fieldset >
                                                <legend class="LegendText"><%# Convert.ToString(Eval("CategoryType")).EndsWith("s") ? Convert.ToString(Eval("CategoryType")).Replace("_", " ") : Convert.ToString(Eval("CategoryType")).Replace("_", " ") + "s"%></legend>
                                                <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                                <tr>
                                            <td colspan="5">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                                    <tr>
                                                        <td class="t3"> Quantity on Hand: 
                                                        <%# Eval("QuantityOnHand") %></td>
                                                    
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
                                                    <FooterTemplate>
                                                    </tbody></table>
                                                    
                                                    </FooterTemplate>
                                                    </asp:Repeater>
                                                <div style="text-align: right; padding-top: 2px; padding-bottom: 2px">
                                                                        <b>&#187; <asp:LinkButton runat="server" ID="InventoryLink" CommandName="InventoryLink"  Text ="More Transactions"></asp:LinkButton></b></div>
                                                </fieldset>
                                            </ItemTemplate>
                                        
                                        </asp:Repeater> 
                                        <table id="NoRecordsTable" runat="server" visible="false" border="1" cellspacing="0"
                                        cellpadding="5" width="100%" height="60px" style="border-collapse: collapse">
                                        <tr>
                                            <td nowrap align="center" class="errormessage">
                                                No inventory records available.</td>
                                        </tr>
                                    </table>  </td></tr>  
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

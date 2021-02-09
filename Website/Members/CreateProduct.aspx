<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="CreateProduct.aspx.cs" Inherits="CreateProduct" Title="Mailing Cycle Add Product" %>

<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Add Product
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    <!--
    function showAgentId()
    {
        document.getElementById("AgentIDLabel").style.visibility = "visible";
        document.getElementById("AgentIDCombo").style.visibility = "visible";
    }
    function hideAgentId()
    {
        document.getElementById("AgentIDLabel").style.visibility = "hidden";
        document.getElementById("AgentIDCombo").style.visibility = "hidden";
    }
    function ChkProductType()
    {
        if(document.getElementById("ProductCatg").value=="Custom")
        {
            showAgentId();
        }
        else
        {
            hideAgentId();
        }
    }
    //-->
</script>
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <asp:Literal id="SubTitleLiteral" runat="server">
                    Please fill Product details in the below form</asp:Literal>                    
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
                <td class="Notes" style="padding-left: 20px">
                    Fields marked with <span class="MandatoryMark">*</span> are mandatory</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
            <td>
                <asp:Label runat="server" ID="ErrorLiteral" CssClass="errormessage"></asp:Label>
                <asp:ValidationSummary ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:" />
            </td>
        </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Product Details</legend>
                                    <table border="0" cellspacing="3" cellpadding="2" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="35%" class="t2">
                                                Product Category:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="35%" class="t3">
                                                <asp:DropDownList ID="ProductCatalogDropDownList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ProductCatalogDropDownList_SelectedIndexChanged"></asp:DropDownList>    
                                                <asp:RequiredFieldValidator Display="none" ErrorMessage="Product Category Is Required" ID="ProductCatalogDropDownListRFValidator" runat="server" ControlToValidate="ProductCatalogDropDownList" InitialValue="<Select a product type>">
                                                </asp:RequiredFieldValidator>                                            
                                            </td>
                                            
                                            <td width="40%" nowrap>
                                                <asp:Panel ID="AgentPanel" runat="server" Visible="false">
                                                    <uc1:ListOfAgentsWebUserControl ID="ListOfAgentsWebUserControl1" AutoPostBack="false" runat="server" /> 
                                                    <asp:CustomValidator ErrorMessage="Please select an agent" ID="ListOfAgentsWebUserControlRFValidator"
                                                     runat="server" ControlToValidate="ListOfAgentsWebUserControl1" OnServerValidate="ValidateAgents" Display="None" Enabled=false>
                                                </asp:CustomValidator>                                                 
                                                </asp:Panel>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Product ID:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" colspan="3">
                                                <asp:TextBox MaxLength="30" ID="ProductIdTextBox" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="none" ErrorMessage="Product ID Is Required" ID="ProductIdTextBoxRFValidator" runat="server" ControlToValidate="ProductIdTextBox">
                                                </asp:RequiredFieldValidator> 
                                                 <asp:CustomValidator ErrorMessage="Product Id already exists" ID="ProductIdTextBoxCustomValidator"
                                                     runat="server" ControlToValidate="ProductIdTextBox" OnServerValidate="CheckProductId" Display="None" ></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" valign="top">
                                                Brief Description:
                                            </td>
                                            <td class="t3" colspan="3">
                                                <asp:TextBox runat="server" ID="BriefDescTextBox" TextMode=MultiLine Rows="4" Columns="60">
                                                </asp:TextBox>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" valign="top">
                                                Extended Description:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" colspan="3">
                                                <asp:TextBox runat="server" ID="ExtDescTextBox" TextMode=MultiLine Rows="6" Columns="60"></asp:TextBox>  
                                                <asp:RequiredFieldValidator ID="ExtDescTextBoxRFValidator" ControlToValidate="ExtDescTextBox" runat="server" Display="none" ErrorMessage="Extended description is required">
                                                </asp:RequiredFieldValidator>                                              
                                            </td>
                                        </tr>
                                        <asp:Panel id="StatusPanel" runat="server">
                                        <tr>
                                            <td class="t2">
                                               Product Status:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" colspan="3">
                                                <asp:Label ID="ProductStatusLabel" runat="server"></asp:Label>                                                
                                            </td>
                                        </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td colspan="4">
                                                <img src="../images/transparent.gif" width="1" height="8" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" colspan="4">
                                                 <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt" HeaderStyle-Height="15px"  AutoGenerateColumns="false"  runat="server" ID="ProductListGridView" BorderWidth="1" cellspacing="0" cellpadding="5" width="98%" style="border-collapse: collapse"
                                                 OnItemDataBound="ProductListGridView_ItemDataBound">
                                                <Columns>
                                                    <asp:BoundColumn  visible="false" DataField="ProductTypeId" ReadOnly=true></asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Product Type" DataField="ProductType" ReadOnly=true></asp:BoundColumn>
                                                    <asp:TemplateColumn ItemStyle-Width="20%"  HeaderText="Custom Size" >
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CustomSizeCheckBox" AutoPostBack="true" OnCheckedChanged="customCheck_CheckedChanged" runat="server" />
                                                            <asp:label id="NAPanel" visible="false" runat="server" text="-NA-"></asp:label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Size">
                                                    <ItemTemplate>
                                                        <asp:Panel ID="SizePanel" runat="server" Visible=false>
                                                        <asp:TextBox ID="SizeText1" maxlength="5" width="50"  runat="server"></asp:TextBox> X
                                                        <asp:TextBox ID="SizeText2" maxlength="5" width="50"  runat="server"></asp:TextBox>
                                                        </asp:Panel>
                                                        <asp:panel id="SizeDropDownPanel" runat="server">
                                                        <asp:DropDownList ID="SizeDropDownList" runat=server DataSource='<%#Eval("Size") %>' >
                                                        </asp:DropDownList></asp:panel>
                                                    </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Quantity">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="QuantityTextBox" maxlength="5" width="50" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>                                                    
                                                </Columns>
                                                </asp:DataGrid>
                                                <asp:CustomValidator ID="ProductListGridViewCustomValidator"
                                                     runat="server" OnServerValidate="ValidateProductTypes" Display="none">
                                                </asp:CustomValidator> 
                                                </td>
                                         </tr>
                            
                                            <tr>
                                                <td colspan="3" >
                                                <table width="100%"><tr><td colspan = 4>&nbsp;</td><td align=right><strong>Final Price (US $):</strong>&nbsp;<span class="MandatoryMark">*</span></td>
                                                <td><asp:TextBox runat="server" id="FinalPriceTextBox" /> 
                                                <asp:RequiredFieldValidator ID="FinalPriceTextBoxRFValidator" ControlToValidate="FinalPriceTextBox" runat="server" Display="none" ErrorMessage="Price is required">
                                                </asp:RequiredFieldValidator></table></td>
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
                <td align=center>
                    <table><tr><td>
                    <asp:Button CssClass="buttonfont" text="Save" style="width: 80px" ID="SaveButton"  runat="server" OnClick="SaveButton_Click"/></td>
                    <asp:panel id="editpanel" runat=server>
                    <td><img src="../Images/spacer.gif" width="1" height="1" />
                    <asp:Button cssclass="buttonfont" visible="false" runat="server" Text="Activate" style="width: 80px" id="ActivateButton" CommandName="Activate" onclick="SaveButton_Click" /></td>
                    <td><img src="../Images/spacer.gif" width="1" height="1" />
                    <asp:Button cssclass="buttonfont" visible="false" runat="server" Text="Hold" style="width: 80px" id="HoldButton" CommandName="Hold" onclick="SaveButton_Click" /></td>
                    <td><img src="../Images/spacer.gif" width="1" height="1" />
                    <asp:Button cssclass="buttonfont" runat="server" visible="false" Text="Obsolete" style="width: 80px" id="ObsoleteButton" CommandName="Obsolete" onclick="SaveButton_Click" /></td></asp:panel>
                    <td><img src="../Images/spacer.gif" width="1" height="1" />
                    <asp:Button causesvalidation="false" cssclass="buttonfont" runat="server" Text="Cancel" style="width: 80px" id="CancelButton" onclick="CancelButton_Click" /><td></tr></table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ModifyFarm.aspx.cs" Inherits="Agent_ModifyFarm" Title="Mailing Cycle Edit Farm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Edit Farm
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-content-mainsection">
    <asp:Panel ID="Panel1" runat="server" Height="450px" Width="100%">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%">Please modify farm details in the below form</td>
                            <td width="40%" align="right">
                                <asp:Literal ID="ForAgentLiteral" runat="server"></asp:Literal>
                                <asp:HiddenField ID="ForAgentUserIdHiddenField" runat="server" />
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
                <td class="Notes" style="padding-left: 20px">
                    Fields marked with <span class="MandatoryMark">*</span> are mandatory</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <span id="error_Login" class="errormessage">
                                    <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
                                </span>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </td>
            </tr>
            <tr>
                <td>
                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>                                                                                   
                                    <asp:ValidationSummary ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:" />
                                </td>
                            </tr>
                        </table> 
                        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend class="LegendText">Farm Details</legend>
                                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                            <tr>
                                                <td width="20%" class="t2">
                                                    <asp:HiddenField ID="FarmIdHiddenField" runat="server" />
                                                    <asp:HiddenField ID="PlotIdHiddenField" runat="server" />
                                                    <asp:HiddenField ID="UserIdHiddenField" runat="server" />
                                                    <asp:Label ID="FarmNameLabe" runat="server" Text="Farm Name" AssociatedControlID="FarmNameTextBox"></asp:Label>&nbsp;<span class="MandatoryMark">*</span>
                                                </td>
                                                <td width="80%" class="t3">
                                                    &nbsp;<asp:TextBox ID="FarmNameTextBox" runat="server" MaxLength="100" Width="200px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="FarmNameRequiredFieldValidator" runat="server" ControlToValidate="FarmNameTextBox"
                                                        Display="None" ErrorMessage="Farm Name is Required" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td class="t2">
                                                    <asp:Label ID="ContactListLabel" runat="server" Text="File to import" AssociatedControlID="ContactListFileUpload"></asp:Label>:&nbsp;<span class="MandatoryMark">*</span>
                                                </td>
                                                <td class="t3">
                                                    &nbsp;<asp:FileUpload ID="ContactListFileUpload" runat="server" Width="288px" />
                                                    <asp:RequiredFieldValidator ID="ContactListFileRequiredFieldValidator" runat="server"
                                                        ControlToValidate="ContactListFileUpload" Display="None" ErrorMessage="Contact List File (xls / csv) required."></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td class="t2">
                                                    &nbsp;</td>
                                                <td class="t3">
                                                    <a target="_blank" href="../SampleFarm.xls"><span style="vertical-align: middle">Click
                                                        here for sample file</span> <span style="vertical-align: middle">
                                                            <img src="../Images/Excel.JPG" width="16" height="16" /></span> </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="t2">
                                                    <asp:Label ID="MailingPlanLabel" runat="server" Text="Mailing Plan" AssociatedControlID="MailingPlanDropDownList"></asp:Label>:
                                                </td>
                                                <td class="t3">
                                                    &nbsp;<asp:DropDownList ID="MailingPlanDropDownList" runat="server" Width="208px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="MailingPlanRequiredFieldValidator" runat="server"
                                                        ControlToValidate="MailingPlanDropDownList" Display="None" ErrorMessage="Select a Mailing Plan"></asp:RequiredFieldValidator></td>
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
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="ModifyFarmButton" cssClass="buttonfont" runat="server" Text="Save" OnClick="ModifyFarmButton_Click" Width="72px" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="CancelFarmButton" cssClass="buttonfont" runat="server" Text="Cancel" OnClick="CancelFarmButton_Click" Width="72px" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="Panel2" runat="server" Height="450px" Width="100%">
         <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%">Please Confirm the farm Contact Details from the file you have uploaded</td>
                            <td width="40%" align="right">
                                <asp:Literal ID="ForAgentLiteral1" runat="server"></asp:Literal>
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
                    <span id="Span1" class="errormessage">
                        <asp:Literal ID="ErrorLiteral1" runat="server"></asp:Literal>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Uploaded Contacts</legend>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button cssClass="buttonfont" ID="ApproveButton" runat="server" Text="Approve" OnClick="ApproveButton_Click" />&nbsp;&nbsp;&nbsp;
                                                <asp:Button cssClass="buttonfont" ID="ReloadButton" runat="server" Text="Reload File" OnClick="ReloadButton_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/transparent.gif" width="1" height="4" /></td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="ContactListGridView" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" AllowPaging="true" OnPageIndexChanging="ContactListGridView_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="First Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="OwnerFirstNameLabel" Text='<%#Eval("ownerFirstName")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Last Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="OwnerLastNameLabel" Text='<%#Eval("ownerLastName")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address Line 1">
                                                <ItemTemplate>
                                                    <asp:Label ID="OwnerAddress1Label" Text='<%#Eval("ownerAddress1")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address Line 2">
                                                <ItemTemplate>
                                                    <asp:Label ID="OwnerAddress2Label" Text='<%#Eval("ownerAddress2")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City">
                                                <ItemTemplate>
                                                    <asp:Label ID="OwnerCityLabel" Text='<%#Eval("ownerCity")%>' runat="server"></asp:Label>    
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State">
                                                <ItemTemplate>
                                                    <asp:Label ID="OwnerStateLabel" Text='<%#Eval("ownerState")%>' runat="server"></asp:Label>    
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Zip">
                                                <ItemTemplate>
                                                    <asp:Label ID="OwnerZipLabel" Text='<%#Eval("ownerZip")%>' runat="server"></asp:Label>    
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Country">
                                                <ItemTemplate>
                                                    <asp:Label ID="OwnerCountryLabel" Text='<%#Eval("ownerCountry")%>' runat="server"></asp:Label>    
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                    </table>                                    
                </td>
            </tr>
            <tr>
                <td align="center">
                </td>
            </tr>
        </table>      
    </asp:Panel>
        
    </div>
</asp:Content>

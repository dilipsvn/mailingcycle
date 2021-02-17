<%@ Page Language="C#" MasterPageFile="AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="CreatePlot.aspx.cs" Inherits="Agent_CreatePlot" Title="Mailing Cycle Add Plot" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Add Plot
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%">Please fill plot details in the below form</td>
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
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Farm Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2">
                                                Name:
                                            </td>
                                            <td width="80%" class="t3">
                                                <asp:Label ID="FarmNameLabel" runat="server" Text=""></asp:Label>
                                                <asp:hiddenfield ID="FarmIdHiddenField" runat="server"></asp:hiddenfield>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Contact Count:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="FarmContactCountLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Mailing Plan:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="MailingPlanLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Created On:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="CreateDateLabel" runat="server" Text=""></asp:Label>
                                                <asp:hiddenfield ID="UserIdHiddenField" runat="server"></asp:hiddenfield>
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
                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <span id="error_Login" class="errormessage">
                                        <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
                                    </span>                                                                                    
                                    <asp:ValidationSummary ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:" />
                                </td>
                            </tr>
                        </table> 
                        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend class="LegendText">Plot Details</legend>
                                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                            <tr>
                                                <td width="20%" class="t2">
                                                    <asp:Label ID="PlotNameLabel" runat="server" Text="Name" AssociatedControlID="PlotNameTextBox"></asp:Label>&nbsp;<span class="MandatoryMark">*</span>
                                                </td>
                                                <td width="80%" class="t3">
                                                    &nbsp;<asp:TextBox ID="PlotNameTextBox" runat="server" MaxLength="100" Width="200px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PlotNameRequiredFieldValidator" runat="server" ControlToValidate="PlotNameTextBox"
                                                        Display="None" ErrorMessage="Plot Name is Required" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
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
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="CreatePlotButton" cssClass="buttonfont" runat="server" Text="Save" OnClick="CreatePlotButton_Click" Width="72px" />
                                    <img src="../Images/spacer.gif" width="10px" height="1" />
                                    <input class="buttonfont" type="button" value="Cancel" style="width: 80px" onclick="javascript:location.href='ViewFarm.aspx?farmId=<%=Request.QueryString["farmId"] %>'" id="CancelButton" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel> 
                    <asp:Panel ID="Panel2" runat="server" Height="450px" Width="100%">
                         <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td height="30" class="tableheading">
                                    Please Confirm the farm Contact Details from the file you have uploaded
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
                                                    <asp:GridView ID="ContactListGridView" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="ContactListGridView_PageIndexChanging">
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
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

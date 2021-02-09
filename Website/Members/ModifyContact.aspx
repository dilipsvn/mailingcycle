<%@ Page Language="C#" MasterPageFile="AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ModifyContact.aspx.cs" Inherits="ModifyContact" Title="Mailing Cycle Edit Contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Edit Contact
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Include/datetimepicker.js"></script>
    
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%">Please modify contact details in the below form</td>
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
                    <img src="../../images/transparent.gif" width="1" height="1" /></td>
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
                                    <legend class="LegendText">Plot Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2">
                                                Plot Name:
                                            </td>
                                            <td width="80%" class="t3">
                                                <asp:label id="PlotNameLabel" runat="server" text=""></asp:label>
                                                <asp:HiddenField ID="PlotIdHiddenField" runat="server" />&nbsp;
                                                <asp:HiddenField ID="FarmIdHiddenField" runat="server" />
                                                <asp:HiddenField ID="UserIdHiddenField" runat="server" />
                                                <asp:HiddenField ID="ParentPageHiddenField" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Contact Count:
                                            </td>
                                            <td class="t3">
                                                <asp:label id="ContactCountLabel" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Created On:
                                            </td>
                                            <td class="t3">
                                                <asp:label id="CreateDateLabel" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Last Modified On:
                                            </td>
                                            <td class="t3">
                                                04/17/2007 11:43 AM
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
                                    <legend class="LegendText">Contact Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2">
                                                Contact ID :<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="30%" class="t3">
                                                <asp:Label ID="ContactIdLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td width="20%" class="t2" nowrap>
                                                Schedule #:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="30%" class="t3">
                                                <asp:TextBox ID="ScheduleNumberTextBox" runat="server" MaxLength="5" Width="72px" TabIndex="1"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="ScheduleNumberRegularExpressionValidator" runat="server"
                                                    ControlToValidate="ScheduleNumberTextBox" ErrorMessage="Schedule #  must be a Number" ValidationExpression="^[0-9]*$" Width="192px" Display="none" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="ScheduleNumberRequiredFieldValidator" runat="server"
                                                    ControlToValidate="ScheduleNumberTextBox" Display="none" SetFocusOnError="true" ErrorMessage="Schedule Number is Required"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Owner Full Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="OwnerFullNameTextBox" runat="server" MaxLength="100" TabIndex="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="OwnerFullNameRequiredFieldValidator" Display="none" SetFocusOnError="true" runat="server"
                                                    ControlToValidate="OwnerFullNameTextBox" ErrorMessage="Owner Full Name is Required"></asp:RequiredFieldValidator></td>
                                            <td class="t2" nowrap>
                                                Lot:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="LotTextBox" runat="server" MaxLength="5" Width="72px" TabIndex="3"></asp:TextBox>
                                                <asp:RegularExpressionValidator  Display="none" SetFocusOnError="true" ID="LotNumberRegularExpressionValidator" runat="server"
                                                    ControlToValidate="LotTextBox" ErrorMessage="Lot must be a number" ValidationExpression="^[0-9]*$"
                                                    Width="112px"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="LotNumberRequiredFieldValidator" Display="none" SetFocusOnError="true" runat="server" ControlToValidate="LotTextBox"
                                                    ErrorMessage="Lot Number is Required"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Block:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="BlockTextBox" runat="server" MaxLength="10" Width="56px" TabIndex="4"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="BlockRequiredFieldValidator" Display="none" SetFocusOnError="true" runat="server" ControlToValidate="BlockTextBox"
                                                    ErrorMessage="Block is required"></asp:RequiredFieldValidator></td>
                                            <td class="t2" nowrap>
                                                Subdivision Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="SubDivisionTextBox" runat="server" MaxLength="100" Width="176px" TabIndex="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="SubDivisionRequiredFieldValidator" Display="none" SetFocusOnError="true" runat="server"
                                                    ControlToValidate="SubDivisionTextBox" ErrorMessage="SubDivision is required"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Filing #:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="FilingTextBox" runat="server" MaxLength="50" Width="112px" TabIndex="6"></asp:TextBox></td>
                                            <td class="t2" nowrap style="height: 22px">
                                                Site Address:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" style="height: 22px">
                                                <asp:TextBox ID="SiteAddressTextBox" runat="server" MaxLength="255" Width="176px" TabIndex="7"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap style="height: 22px">
                                                Bedrooms:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" style="height: 22px">
                                                <asp:TextBox ID="BedroomsTextBox" runat="server" MaxLength="3" Width="56px" TabIndex="8"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display="none" SetFocusOnError="true" ID="BedroomsRegularExpressionValidator" runat="server"
                                                    ControlToValidate="BedroomsTextBox" ErrorMessage="Bedrooms must be a number" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator></td>
                                            <td class="t2" nowrap>
                                                # Full Baths:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="FullBathTextBox" runat="server" MaxLength="3" Width="56px" TabIndex="9"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display="none" SetFocusOnError="true" ID="FullBathRegularExpressionValidator" runat="server"
                                                    ControlToValidate="FullBathTextBox" ErrorMessage="Full Bath must be a number" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                # 3/4 Baths:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="ThreeQuarterBathTextBox" runat="server" MaxLength="3" Width="56px" TabIndex="10"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display="none" SetFocusOnError="true" ID="ThreeQuarterBathRegularExpressionValidator" runat="server"
                                                    ControlToValidate="ThreeQuarterBathTextBox" ErrorMessage="Three Quarter bath must be a Number" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator></td>
                                            <td class="t2" nowrap>
                                                # 1/2 Baths:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="HalfBathTextBox" runat="server" MaxLength="3" Width="56px" TabIndex="11"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display="none" SetFocusOnError="true" ID="HalfBathRegularExpressionValidator" runat="server"
                                                    ControlToValidate="HalfBathTextBox" ErrorMessage="Half bath must be a number" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Acres:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="AcresTextBox" runat="server" MaxLength="6" Width="56px" TabIndex="12"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display="none" SetFocusOnError="true" ID="AcresRegularExpressionValidator" runat="server"
                                                    ControlToValidate="AcresTextBox" ErrorMessage="Acres must be a decimal Number" ValidationExpression="^[0-9]+\.?[0-9]*$"></asp:RegularExpressionValidator></td>
                                            <td class="t2" nowrap>
                                                Act Mkt Comb:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="ActMktCombTextBox" runat="server" MaxLength="50" Width="112px" TabIndex="13"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Owner First Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="OwnerFirstNameTextBox" runat="server" MaxLength="50" Width="136px" TabIndex="14"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="none" SetFocusOnError="true" ID="OwnerFirstNameRequiredFieldValidator" runat="server" ErrorMessage="Owner First Name is Required" ControlToValidate="OwnerFirstNameTextBox"></asp:RequiredFieldValidator></td>
                                            <td class="t2" nowrap>
                                                Owner Last Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="OwnerLastNameTextBox" runat="server" MaxLength="50" TabIndex="15" Width="136px"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="none" SetFocusOnError="true" ID="OwnerLastNameRequiredFieldValidator" runat="server" ErrorMessage="Owner Last Name Required" ControlToValidate="OwnerLastNameTextBox"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap style="height: 26px">
                                                Owner Address 1:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" style="height: 26px">
                                                <asp:TextBox ID="OwnerAddress1TextBox" runat="server" TabIndex="16" Width="184px"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="none" SetFocusOnError="true" ID="OwnerAddress1RequiredFieldValidator" runat="server" ErrorMessage="Address Line 1 is required" ControlToValidate="OwnerAddress1TextBox"></asp:RequiredFieldValidator></td>
                                            <td class="t2" nowrap style="height: 26px">
                                                Owner Address 2:&nbsp;
                                            </td>
                                            <td class="t3" style="height: 26px">
                                                <asp:TextBox ID="OwnerAddress2TextBox" runat="server" TabIndex="17" Width="184px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap style="height: 26px">
                                                Owner City:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" style="height: 26px">
                                                <asp:TextBox ID="OwnerCityTextBox" runat="server" MaxLength="50" TabIndex="18"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="OwnerCityRequiredFieldValidator" Display="none" SetFocusOnError="true" runat="server" ControlToValidate="OwnerCityTextBox"
                                                    ErrorMessage="Owner City is Required"></asp:RequiredFieldValidator></td>
                                            <td class="t2" nowrap style="height: 26px">
                                                Owner State:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" style="height: 26px">
                                                <asp:TextBox ID="OwnerStateTextBox" runat="server" MaxLength="50" TabIndex="19" Width="144px"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="none" SetFocusOnError="true" ID="OwnerStateRequiredFieldValidator" runat="server"
                                                    ControlToValidate="OwnerStateTextBox" ErrorMessage="Owner State is Required"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Owner Zip:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="OwnerZipTextBox" runat="server" MaxLength="15" Width="80px" TabIndex="20"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display="none" SetFocusOnError="true" ID="OwnerZipRegularExpressionValidator" runat="server"
                                                    ControlToValidate="OwnerZipTextBox" ErrorMessage="Provide a Valid Zip Code" ValidationExpression="(\d{5}(-\d{4})?)|([A-Z]{1}\d{1}[A-Z]{1} \d{1}[A-Z]{1}\d{1})"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator Display="none" SetFocusOnError="true" ID="OwnerZipRequiredFieldValidator" runat="server" ControlToValidate="OwnerZipTextBox"
                                                    ErrorMessage="Owner Zip is Required"></asp:RequiredFieldValidator></td>
                                            <td class="t2" nowrap>
                                                Owner Country:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="OwnerCountryTextBox" runat="server" Width="144px" MaxLength="50" TabIndex="21"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="none" SetFocusOnError="true" ID="OwnerCountryRequiredFieldValidator" runat="server"
                                                    ControlToValidate="OwnerCountryTextBox" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Sale Date:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="SaleDateTextBox" runat="server" MaxLength="10" Width="80px" TabIndex="22"></asp:TextBox><a href="javascript: NewCal('ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_SaleDateTextBox','mmddyyyy')"><img
                                                    src="../images/dtp.gif" width="16" height="16" border="0" alt="Pick a date"></a>
                                                <asp:RegularExpressionValidator Display="none" SetFocusOnError="true" ID="SaleDateRegularExpressionValidator" runat="server"
                                                    ControlToValidate="SaleDateTextBox" ErrorMessage="Must enter a Valid Sale Date"
                                                    ValidationExpression="^([0-1]?[1-9]|[1-9])(/|-)([0-2]?[0-9]|3?[0-1])(/|-)[1-2][0-9][0-9][0-9]$"></asp:RegularExpressionValidator></td>
                                            <td class="t2" nowrap>
                                                Transfer Amount:
                                            </td>
                                            <td class="t3">
                                                <span class="Notes">US $
                                                    <asp:TextBox ID="TransAmountTextBox" runat="server" TabIndex="23" Width="104px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator Display="none" SetFocusOnError="true" ID="TransactionAmountRegularExpressionValidator"
                                                        runat="server" ControlToValidate="TransAmountTextBox" ErrorMessage="Provide a Valid Transaction Amount"
                                                        ValidationExpression="^[0-9]+\.?[0-9]*$" Width="176px"></asp:RegularExpressionValidator></span></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
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
                    <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="buttonfont" OnClick="SaveButton_Click" Width="72px" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="CancelButton" CausesValidation="false" runat="server" Text="Cancel" CssClass="buttonfont" Width="80px" OnClick="CancelButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

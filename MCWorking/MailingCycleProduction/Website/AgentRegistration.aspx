<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AgentRegistration.aspx.cs" EnableEventValidation="false" Inherits="AgentRegistration" Title="Mailing Cycle Agent Registration" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelMenu" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Agent Registration (Step 1 of 3)
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="Include/Functions.js"></script>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Please fill your registration details in the below form
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
                                    <legend class="LegendText">Account Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                User Name:&nbsp;<span class="MandatoryMark">*</span>
                                               <!-- <p><asp:Literal ID="testpath" runat="server"></asp:Literal> </p>-->
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:TextBox ID="UserNameTextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameTextBoxRFValidator" SetFocusOnError="true" runat="server" ErrorMessage="UserName is required" InitialValue="" ControlToValidate="UserNameTextBox" Display="none" Width="1px"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator SetFocusOnError="true" ID="UserNameCustomValidator" runat="server" OnServerValidate="checkUserName" ErrorMessage="Invalid User Name.User name cannot be of less than 8 charaters and cannot have spaces." Display="none" ControlToValidate="UserNameTextBox"></asp:CustomValidator>
                                                <asp:CustomValidator SetFocusOnError="true" ID="UniqueUserNameCustomValidator" runat="server" OnServerValidate="CheckUniqueUserName" ErrorMessage="User Name is already existing" Display="none" ControlToValidate="UserNameTextBox"></asp:CustomValidator>
                                            </td>
                                            <td width="22%" class="t2" nowrap>
                                                Email:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="256" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="EmailTextBoxRFValidator" runat="server" ErrorMessage="Email is required" InitialValue="" ControlToValidate="EmailTextBox" Display="none"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator  SetFocusOnError="true" ID="EmailTextBoxREValidator" runat="server" ErrorMessage="Invalid Email."
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTextBox" Display="none"></asp:RegularExpressionValidator>
                                                <asp:CustomValidator SetFocusOnError="true" ID="EmailTextBoxCustomValidator" runat="server" OnServerValidate="CheckUniqueEmail" ErrorMessage="Email address is already existing" Display="none" ControlToValidate="EmailTextBox"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Password:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="PasswordTextBox" runat="server" MaxLength="128" Width="150px" TextMode="Password"></asp:TextBox>
                                                &nbsp;<a href="javascript: openHelp('Help/PasswordGuidelines.htm');"><img
                                                    src="Images/helpIcon.gif" /></a>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="PasswordTextBoxRFValidator" runat="server" ErrorMessage="Password is required" InitialValue="" ControlToValidate="PasswordTextBox" Display="none"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator SetFocusOnError="true" ID="PasswordTextBoxCustomValidator" runat="server" OnServerValidate="checkPassword" ErrorMessage="Invalid password.Password cannot be of less than 7 charaters and greater than 20 characters." Display="none" ControlToValidate="PasswordTextBox"></asp:CustomValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Re-enter Password:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="ReEnterTextBox" runat="server" MaxLength="128" Width="150px" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="ReEnterTextBoxRFValidator" runat="server" ErrorMessage="Re Enter Password is required" InitialValue="" ControlToValidate="ReEnterTextBox" Display="none"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" SetFocusOnError="true" runat="server" ErrorMessage="Password and Re-Enter password is not same" ControlToValidate="ReEnterTextBox" ControlToCompare="PasswordTextBox" Display="none"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Secret Question:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:DropDownList ID="SecretQuestionDropDownList" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="SecretQuestionDropDownListRFValidator" runat="server" ErrorMessage="Select a Secret Question" InitialValue="0" ControlToValidate="SecretQuestionDropDownList" Display="none"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="SecQuestionHiddenField" runat="server" />
                                            </td>
                                            <td class="t2" nowrap>
                                                Secret Answer:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="SecretAnswerTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="SecretAnswerTextBoxRFValidator" runat="server" ErrorMessage="Secret Answer is required" InitialValue="" ControlToValidate="SecretAnswerTextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
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
                    <img src="../Images/spacer.gif" width="1" height="8" /><br />
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Personal Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                First Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:TextBox ID="FirstNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="FirstNameTextBoxRFValidator" runat="server" ErrorMessage="First Name is required" InitialValue="" ControlToValidate="FirstNameTextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="22%" class="t2" nowrap>
                                                Middle Name:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:TextBox ID="MiddleNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Last Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="LastNameTextBoxRFValidator" SetFocusOnError="true" runat="server" ErrorMessage="Last Name is required" InitialValue="" ControlToValidate="LastNameTextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Company Name:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="CompanyNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Address Line 1:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="Address1TextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Address1TextBoxRFValidator" runat="server" SetFocusOnError="true" ErrorMessage="Address1 is required" InitialValue="" ControlToValidate="Address1TextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Address Line 2:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="Address2TextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                City:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="CityTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CityTextBoxRFValidator" runat="server" SetFocusOnError="true" ErrorMessage="City is required" InitialValue="" ControlToValidate="CityTextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Country:
                                            </td>
                                            <td class="t3">
                                                <asp:DropDownList ID="CountryDropDownList" runat="server" OnSelectedIndexChanged="CountryDropDownList_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                State/Province:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                    <contenttemplate>
                                                        <asp:DropDownList id="StateDropDownList" runat="server" >
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator id="StateDropDownListRFValidator" runat="server" Display="none" ControlToValidate="StateDropDownList" InitialValue="0" ErrorMessage="Select a State" SetFocusOnError="true"></asp:RequiredFieldValidator> 
                                                    </contenttemplate>
                                                    <triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="CountryDropDownList" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                    </triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="t2" nowrap>
                                                Zip:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <asp:TextBox ID="ZipTextBox" Width="80px" MaxLength="10" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ZipRequiredFieldValidator" ControlToValidate="ZipTextBox"
                                                    InitialValue="" ErrorMessage="Zip is required" SetFocusOnError="true" Display="none"
                                                    runat="server"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="ZipCustomValidator" ControlToValidate="ZipTextBox" ClientValidationFunction="MCU_ValidateZip"
                                                    ErrorMessage="Invalid Zip." SetFocusOnError="true" Display="None" runat="server"></asp:CustomValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Phone:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="PhoneTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PhoneTextBoxRFValidator" runat="server" ErrorMessage="Phone is required" SetFocusOnError="true" InitialValue="" ControlToValidate="PhoneTextBox" Display="none"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator  SetFocusOnError="true" ID="PhoneTextBoxREValidator" runat="server" ErrorMessage="Invalid Phone Number."
                                                ValidationExpression="((((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}) ?)|(\d{10})" ControlToValidate="PhoneTextBox" Display="none"></asp:RegularExpressionValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Mobile:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="MobileTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Fax:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="FaxTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                &nbsp;</td>
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
                    <asp:Button CssClass="buttonfont" ID="MembershipButton" runat="server" OnClick="MembershipButton_Click" Text="Proceed to Membership" Width="150px" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button CausesValidation="false" CssClass="buttonfont" ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Cancel" Width="80px" />
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
                            <td>
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                Address specified at Personal Details section will be used as your default Shipping
                                Address.</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                If the account and personal details are as per your requirements; click the 'Proceed to Membership' button to complete your registration.</td>
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

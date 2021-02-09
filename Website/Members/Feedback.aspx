<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Members_Feedback" Title="Feedback" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Feedback
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="right-content-mainsection">
    <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td height="30" class="tableheading">
                Please fill the feedback details in the below form
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
                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                        <tr>
                            <td class="Notes" style="padding-left: 20px">
                                Fields marked with <span class="MandatoryMark">*</span> are mandatory
                            </td>
                            <td align="right">
                                <span id="MessagesSpan">
                                    <asp:Label ID="MessagesLabel" runat="server" cssClass="MessageText"></asp:Label>
                                </span>                                                                                    
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            
                        </tr>
                    </table>                     
                </td>
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
                                    <legend class="LegendText">Feedback Details</legend>
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
                                                <asp:TextBox ID="FirstNameTextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="FirstNameTextBoxRFValidator" runat="server" ControlToValidate="FirstNameTextBox" ErrorMessage="First name is required" Display=None></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="22%" class="t2" nowrap>
                                                Middle Name:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:TextBox ID="MiddleNameTextBox" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Last Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="LastNameTextBoxRFValidator" runat="server" ControlToValidate="LastNameTextBox" ErrorMessage="Last name is required" Display=None></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Company Name:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="CompanyNameTextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Address Line 1:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="AddressLine1TextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="AddressLine1TextBoxRFValidator" runat="server" ControlToValidate="AddressLine1TextBox" ErrorMessage="Address is required" Display=None></asp:RequiredFieldValidator>                                            
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Address Line 2:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="AddressLine2TextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                City:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="CityTextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CityTextBoxRFValidator" runat="server" ControlToValidate="CityTextBox" ErrorMessage="City is required" Display=None></asp:RequiredFieldValidator>                                                                                        
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
                                                        <asp:DropDownList id="StateDropDownList" runat="server">
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
                                                <asp:RegularExpressionValidator  SetFocusOnError="true" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Phone Number."
                                                ValidationExpression="((((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}) ?)|(\d{10})" ControlToValidate="MobileTextBox" Display="none"></asp:RegularExpressionValidator>                                            
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Fax:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="FaxTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                            <td class="t2" nowrap>
                                                Email:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3" nowrap>
                                               <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="256" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="EmailTextBoxRFValidator" runat="server" ErrorMessage="Email is required" InitialValue="" ControlToValidate="EmailTextBox" Display="none"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator  SetFocusOnError="true" ID="EmailTextBoxREValidator" runat="server" ErrorMessage="Invalid Email."
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTextBox" Display="none"></asp:RegularExpressionValidator>                                            
                                            </td>
                                        </tr>
                                        <tr>
              	                            <td valign="top" class="t2"><asp:label  ID="CommentsLabel" runat="server" Text="Comments:"></asp:Label>&nbsp;<span class="MandatoryMark">*</span></td>
             	                             <td valign="top" class="t3" colspan="3">
             	                                <asp:TextBox ID="CommentsTextBox" runat="server" Columns="60" rows="6" TextMode="MultiLine"></asp:TextBox>
             	                                <asp:RequiredFieldValidator ID="CommentsTextBoxRFValidator" runat="server" ControlToValidate="CommentsTextBox" ErrorMessage="Comments are required" Display=None></asp:RequiredFieldValidator>
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
                </td>
	    	</tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button CssClass="buttonfont" ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Save" Width="150px" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button CausesValidation="false" CssClass="buttonfont" ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Cancel" Width="80px" />                
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
	    </table>
    </div>
</asp:Content>


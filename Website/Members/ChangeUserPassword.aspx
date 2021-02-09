<%@ Page Language="C#" MasterPageFile="AgentMasterPage.master" AutoEventWireup="true" CodeFile="ChangeUserPassword.aspx.cs" Inherits="ChangeUserPassword" Title="Mailing Cycle Change Password" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Change Password
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function openHelp(path)
    {
        var iWidth = 300;
        var iHeight = screen.height - 100;
        var iLeft = (screen.width - iWidth) - 12;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
        window.open(path, "Help", sFeatures + sSize);
    }
    </script>
<div class="right-content-mainsection">
    <table width="100%" cellspacing="0" class="toptable">
        <tr>
            <td height="30" class="tableheading">
                Please change to your new password here
            </td>
        </tr>
        <tr>
            <td class="rowborder"><img src="../images/transparent.gif" width="1" height="1" /></td>
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
                                    <legend class="LegendText">Password Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                          <td valign="top" class="t2">&nbsp;</td>
                                          <td valign="top" class="t2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                          <td valign="middle" width="30%" class="t2"><asp:label id="OldPasswordLabel" runat="server" text="Old Password :"></asp:label>&nbsp;<span class="MandatoryMark">*</span></td>
                                          <td width="70%" valign="top" class="t3">
                                            <asp:textbox runat="server" id="OldPasswordTextBox" size="30" textmode="password"></asp:textbox>
                                            <asp:RequiredFieldValidator ID="OldPasswordTextBoxRFValidator" runat="server" ErrorMessage="Old Password is required" InitialValue="" ControlToValidate="OldPasswordTextBox" Display="none"></asp:RequiredFieldValidator>
                                        </td>
                                        </tr>
                                        <tr>
                                          <td valign="middle" class="t2">New Password :&nbsp;<span class="MandatoryMark">*</span></td>
                                          <td valign="top" class="t3">
                                            <asp:textbox runat="server" id="NewPasswordTextBox" size="30" textmode="password"></asp:textbox>
                                            <asp:RequiredFieldValidator ID="NewPasswordTextBoxRFValidator" runat="server" ErrorMessage="New Password is required" InitialValue="" ControlToValidate="NewPasswordTextBox" Display="none"></asp:RequiredFieldValidator>
                                            &nbsp;<a href="javascript: openHelp('../Help/PasswordGuidelines.htm');"><img src="../Images/helpIcon.gif" /></a></td>
                                        </tr>
                                        <tr>
                                          <td valign="middle" class="t2">Re-enter New Password :&nbsp;<span class="MandatoryMark">*</span> </td>
                                          <td valign="top" class="t3">
                                            <asp:textbox runat="server" id="ReEnterPasswordTextBox" size="30" textmode="password"></asp:textbox>
                                            <asp:RequiredFieldValidator ID="ReEnterPasswordTextBoxRFValidator" runat="server" ErrorMessage="Re Enter Password is required" InitialValue="" ControlToValidate="ReEnterPasswordTextBox" Display="none"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ErrorMessage="Password and Re-Enter password is not same" ControlToValidate="ReEnterPasswordTextBox" ControlToCompare="NewPasswordTextBox" Display="none"></asp:CompareValidator>
                                            <asp:CustomValidator SetFocusOnError="true" ID="PasswordTextBoxCustomValidator" runat="server" OnServerValidate="checkPassword" ErrorMessage="Invalid password.Password cannot be of less than 7 charaters and greater than 20 characters." Display="none" ControlToValidate="ReEnterPasswordTextBox"></asp:CustomValidator>
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
                </td>
			</tr>
            <tr>
                <td><img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button CssClass="buttonfont" ID="SaveButton" Text="Save" Width="80px"
                        runat="Server" OnClick="SaveButton_Click" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <input class="buttonfont" type="button" value="Cancel" style="width: 80px" onclick="javascript:location.href='welcome.aspx'" />
                </td>
            </tr>
            <tr>
                <td><img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
		</table>
	</div>
</asp:Content>
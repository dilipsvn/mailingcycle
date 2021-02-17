<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ForgotUserPassword.aspx.cs" Inherits="ForgotUserPassword" Title="Mailing Cycle Forgot Password" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelMenu"
    runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Forgot your Password?
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    <!--
	function showDiv(mid)
	{
		document.getElementById(mid).style.visibility = "visible";
		document.getElementById(mid).style.position = "absolute";
		document.getElementById(mid).style.top = 270;
	}
	
	function hideDiv(mid)
	{
		document.getElementById(mid).style.visibility = "hidden";
	}
	
	function doStep2()
	{
		hideDiv('ForgetPwdStep1');
		hideDiv('ForgetPwdStep3');
		showDiv('ForgetPwdStep2');
	}
	
	function doStep3()
	{
		hideDiv('ForgetPwdStep1');
		hideDiv('ForgetPwdStep2');
		showDiv('ForgetPwdStep3');
	}
    // -->
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    <asp:Label ID="PageDescriptionLabel" runat="server" Text="Before you can reset your password, you need to type your Mailing Cycle User Name below."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ErrorMessageLabel" runat="server" Visible="false" CssClass="errormessage"></asp:Label>
                    <asp:ValidationSummary ID="ErrorValidationSummary" runat="server" EnableClientScript="true"
                        HeaderText="&nbsp;Please correct the below errors:" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="ForgetPwdStep1Panel" runat="server">
                        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                            <tr>
                                <td>
                                    <fieldset>
                                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                            <tr>
                                                <td width="20%" class="t2">
                                                    <asp:Label ID="UserNameLabel" runat="server" Text="User Name:"></asp:Label></td>
                                                <td width="80%" class="t3">
                                                    <asp:TextBox ID="UserNameTextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameTextBoxRFValidator" runat="server" ErrorMessage="User Name is Required."
                                                        InitialValue="" Display="none" ControlToValidate="UserNameTextBox" Width="1px"></asp:RequiredFieldValidator>
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
                                    <asp:Button CssClass="buttonfont" ID="ForgetPwdStep1Button" Text="Continue" Width="80px"
                                        runat="Server" OnClick="ForgetPwdStep1Button_Click" />
                                    <img src="../Images/spacer.gif" width="10px" height="1" />
                                    <input class="buttonfont" type="button" value="Cancel" style="width: 80px" onclick="javascript: document.location.href='UserLogin.aspx'" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="../Images/spacer.gif" width="1" height="160" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="ForgetPwdStep2Panel" runat="server" Visible="false">
                        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                            <tr>
                                <td>
                                    <fieldset>
                                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                            <tr>
                                                <td width="20%" height="28" class="t2">
                                                    <asp:Label ID="SecurityQuestionLabel" runat="server" Text="Secret Question:"></asp:Label>
                                                </td>
                                                <td width="80%" class="t3">
                                                    <span style="font-weight: bold; font-style: italic; color: #336699">
                                                        <asp:Label ID="SecurityQuestion" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="t2">
                                                    <asp:Label runat="server" ID="SecurityAnswerLabel" Text="Secret Answer:"></asp:Label></td>
                                                <td class="t3">
                                                    <asp:TextBox ID="SecurityAnswerTextBox" runat="server" MaxLength="50" Width="150px"
                                                        CausesValidation="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="SecurityAnswerTextBoxRFValidator" runat="server"
                                                        ErrorMessage="Secret Answer is Required." InitialValue="" Display="none" ControlToValidate="SecurityAnswerTextBox"></asp:RequiredFieldValidator>
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
                                    <asp:Button CssClass="buttonfont" ID="ForgetPwdStep2Button" Text="Continue" Width="80px"
                                        runat="Server" OnClick="ForgetPwdStep2Button_Click" />
                                    <img src="../Images/spacer.gif" width="10px" height="1" />
                                    <input class="buttonfont" type="button" value="Cancel" style="width: 80px" onclick="javascript: document.location.href='UserLogin.aspx'" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="../Images/spacer.gif" width="1" height="130" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="ForgetPwdStep3Panel" runat="server" Visible="false">
                        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                            <tr>
                                <td>
                                    <fieldset>
                                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                            <tr>
                                                <td id="SuccessText" runat="server" colspan="2" class="t2">
                                                    An email message with reset password has been sent to the email address you provided
                                                    during registration.<br />
                                                    <br />
                                                    If you do not receive reset password email from us, please check your spam, bulk,
                                                    or junk mail folders. If you find the email there, your ISP or your own software
                                                    spam-blocker or filters are diverting our email.
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
                                    <input class="buttonfont" type="button" value="OK" style="width: 80px" onclick="javascript: document.location.href='UserLogin.aspx'" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="../Images/spacer.gif" width="1" height="140" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="AgentMasterPage.master" AutoEventWireup="true" CodeFile="ChangeSecurityQuestion.aspx.cs" Inherits="ChangeSecurityQuestion" Title="Mailing Cycle Change Secret Question" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Change Secret Question
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../Include/Functions.js"></script>
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
                Please change your secret question here
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
                                    <legend class="LegendText">Security Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                          <td width="25%" valign="middle" class="t2"><asp:label id="PasswordLabel" runat="server" text="Password:"></asp:label>&nbsp;<span class="MandatoryMark">*</span></td>
                                          <td width="75%" valign="top" class="t3">
                                                <asp:TextBox ID="PasswordTextBox" runat="server" MaxLength="128" Width="150px" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordTextBoxRFValidator" runat="server" ErrorMessage="Password is required" InitialValue="" ControlToValidate="PasswordTextBox" Display="none"></asp:RequiredFieldValidator>
                                        </tr>
                                        <tr>
                                          <td valign="middle" class="t2">Secret Question:&nbsp;<span class="MandatoryMark">*</span></td>
                                          <td valign="top" class="t3">
                                                <asp:DropDownList ID="SecretQuestionDropDownList" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="SecretQuestionDropDownListRFValidator" runat="server" ErrorMessage="Select a Secret Question" InitialValue="0" ControlToValidate="SecretQuestionDropDownList" Display="none"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="SecQuestionHiddenField" runat="server" />
                                          </td>
                                        </tr>
                                        <tr>
                                          <td valign="middle" class="t2">Secret Answer:&nbsp;<span class="MandatoryMark">*</span> </td>
                                          <td valign="top" class="t3">
                                                <asp:TextBox ID="SecretAnswerTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="SecretAnswerTextBoxRFValidator" runat="server" ErrorMessage="Secret Answer is required" InitialValue="" ControlToValidate="SecretAnswerTextBox" Display="none"></asp:RequiredFieldValidator>
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
            <tr><td><img src="../Images/spacer.gif" width="1" height="8" /></td>
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


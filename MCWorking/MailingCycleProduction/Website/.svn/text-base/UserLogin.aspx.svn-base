<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" Title="Mailing Cycle User Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelMenu" Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Visible="false" runat="server">
    User Login
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="right-content-mainsection">
    <table width="100%" cellspacing="0" class="toptable">
        <tr>
            <td height="30" class="tableheading">
               Please login below with your User Name and Password: 
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
            <td align="center">
                <asp:Label ID="MessageLabel" runat="server" CssClass="errormessage"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" width="50%" align="center">
                    <tr>
                        <td>
                            <fieldset>
                                <legend class="LegendText">Login to Mailing Cycle </legend>
                                <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                    <tr>
                                        <td colspan="2"><img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="t2">
                                            <span id="error_Login" class="errormessage">
                                                <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
                                            </span>                                                                                    
                                            <asp:ValidationSummary CssClass="errormessage" ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    <tr>
                                        <td width="20%" valign="middle" class="t2">User Name:</td>
                                        <td width="30%" valign="top" class="t3">
                                            <asp:TextBox ID="UserNameTextBox" runat="server" Width="170" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="UserNameTextBoxRFValidator" runat="server" ErrorMessage="UserName is required" InitialValue="" ControlToValidate="UserNameTextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td valign="middle" class="t2">Password:</td>
                                        <td valign="top" class="t3">
                                            <asp:TextBox ID="PasswordTextBox" runat="server" Width="170" MaxLength="30" TextMode="Password"></asp:TextBox></td>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="PasswordTextBoxRFValidator" runat="server" ErrorMessage="Password is required" InitialValue="" ControlToValidate="PasswordTextBox" Display="none"></asp:RequiredFieldValidator>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    <tr>
                                      <td colspan="2" valign="top">Forgot your Password? <a href="ForgotUserPassword.aspx">Click here</a> to reset.</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" Width="80px" CssClass="buttonfont" text="Login" OnClick="LoginButton_Click" />
                                            <img src="../Images/spacer.gif" width="10px" height="1" />
                                            <input class="buttonfont" type="button" value="Cancel" style="width: 80px" onclick="javascript:location.href='Default.aspx'" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><img src="../Images/spacer.gif" width="1" height="1" /></td>
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
                <td height="50">
                </td>
            </tr>
			
            <tr>
                <td height="10">
                </td>
            </tr>
            <!--
            <tr>
                <td>
                    <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                <strong>Agent Login:</strong> User Name is 'Agent' and password is 'Agent123'.                        
                            </td> 
                        </tr>
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                <strong>Admin Login:</strong> User Name is 'Admin' and password is 'Admin123'. <br />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                <strong>Printer Login:</strong> User Name is 'Printer' and password is 'Printer123'. <br />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                <strong>CSR Login:</strong> User Name is 'Csr' and password is 'Csr123'. 
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            -->
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


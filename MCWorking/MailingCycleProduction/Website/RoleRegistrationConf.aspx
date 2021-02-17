<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RoleRegistrationConf.aspx.cs" Inherits="RoleRegistrationConf" Title="Untitled Page" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderLeftPanelMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Registration <span style="font-size: 0.8em">(Step 2 of 2)</span>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript">
    function cancelRegistration()
    {
        if (confirm("Your registration has not been completed. If you cancel now all the registration data will be lost.\n\nAre you sure you want to cancel your registration?") == true)
            return true;
        else
            return false;
    }
    </script>
    
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Please review your registration details and confirm
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
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                User Name:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:Label ID="UserNameLabel" runat="server"></asp:Label>
                                            </td>
                                            <td width="22%" class="t2" nowrap>
                                                Email:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:Label ID="Emailabel" runat="server"></asp:Label>
                                            </td>
                                            <td width="22%" class="t2" nowrap>
                                                Role:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:Label ID="RoleLabel" runat="server"></asp:Label>
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
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                First Name:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:Label ID="FirstNameLabel" runat="server"></asp:Label>
                                            </td>
                                            <td width="22%" class="t2" nowrap>
                                                Middle Name:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:Label ID="MiddleNameLabel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Last Name:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="LastNameLabel" runat="server"></asp:Label>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Company Name:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="CompanyNameLabel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Address Line 1:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="Address1Label" runat="server"></asp:Label>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Address Line 2:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="Address2Label" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                City:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="CityLabel" runat="server"></asp:Label>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Country:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="CountryLabel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                State/Province:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="StateLabel" runat="server"></asp:Label>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Zip:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="ZipLabel" runat="server"></asp:Label>
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
                    <asp:Button CssClass="buttonfont" ID="FinishButton" runat="server" OnClick="FinishButton_Click" Text="Finish" Width="80px" />
                
                    <img src="../Images/spacer.gif" width="10px" height="1" />

                    <asp:Button CssClass="buttonfont" ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Cancel" Width="80px" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <input class="buttonfont" type="button" value="Back" style="width: 80px" onclick="javascript: document.location.href='RoleRegistration.aspx'" />
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
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                If you wish to change the account, personal, or payment details; click the 'Back' button.</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                If you would like to cancel the transaction; click on the 'Cancel' button. If you
                                                cancel all the registration data will be lost.</td>
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


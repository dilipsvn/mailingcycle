<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ViewUser.aspx.cs" Inherits="ViewUser" Title="View User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
View User
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    View User Details
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
                            </td>
                        </tr>
                    </table> 
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">User Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                User Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:HiddenField ID="UserIdHiddenField" runat="server" />
                                                <asp:Label ID="UserNameLabel" runat="server"></asp:Label>
                                            </td>
                                            <td width="22%" class="t2" nowrap>
                                                User Role:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:Label ID="RoleLabel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                First Name:&nbsp;<span class="MandatoryMark">*</span>
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
                                                Last Name:&nbsp;<span class="MandatoryMark">*</span>
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
                                                Address Line 1:&nbsp;<span class="MandatoryMark">*</span>
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
                                                City:&nbsp;<span class="MandatoryMark">*</span>
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
                                                State/Province:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="StateLabel" runat="server"></asp:Label>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Zip:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="ZipLabel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Phone:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="PhoneLabel" runat="server"></asp:Label>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Mobile:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="MobileLabel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Fax:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="FaxLabel" runat="server"></asp:Label>
                                            </td>
                                            <td class="t2" nowrap>
                                                Email:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td>
                                                <asp:Label ID="EmailLabel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Status:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="StatusLabel" runat="server"></asp:Label>
                                            </td>
                                            <td class="t2" nowrap>&nbsp;
                                            </td>
                                            <td>&nbsp;
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
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button CssClass="buttonfont" ID="EditUserButton" Text="Edit User" Width="80px" runat="Server" OnClick="EditUserButton_Click" />
                                <asp:Image ID="EditSpaceImage" ImageUrl="../Images/spacer.gif" Width="1" Height="1" runat="server" />
                                <asp:Button ID="ActivateUserButton" visible="false" runat="server" Text="Activate User" CssClass="buttonfont" Width="100px" OnClick="ActivateUserButton_Click" OnClientClick="javascript: return confirm('Are you sure you want to Activate this User?');"  />
                                <asp:Image ID="ActivateSpaceImage" ImageUrl="../Images/spacer.gif" Width="1" Height="1" runat="server" />
                                <asp:Button ID="InactivateUserButton" visible="false" runat="server" Text="Inactivate User" CssClass="buttonfont" Width="100px" OnClick="InactivateUserButton_Click" OnClientClick="javascript: return confirm('Are you sure you want to Inactivate this User?');"  />
                                <asp:Image ID="InActivateSpaceImage" ImageUrl="../Images/spacer.gif" Width="1" Height="1" runat="server" />
                                <asp:Button CssClass="buttonfont" visible="false" ID="ApproveUserButton" Text="Approve User" Width="100px"
                                    runat="Server" OnClick="ApproveUserButton_Click"  OnClientClick="javascript: return confirm('Are you sure you want to Approve this User?');"  />
                                    <img src="../Images/spacer.gif" width="1" height="1" />
                                <asp:Image ID="ApproveSpaceImage" ImageUrl="../Images/spacer.gif" Width="1" Height="1" runat="server" />
                                <asp:Button CssClass="buttonfont" visible="false" ID="RejectUserButton" Text="Reject User" Width="100px"
                                    runat="Server" OnClick="RejectUserButton_Click" OnClientClick="javascript: return confirm('Are you sure you want to Reject this User?');"  />
                                    <img src="../Images/spacer.gif" width="1" height="1" />
                                <asp:Image ID="RejectSpaceImage" ImageUrl="../Images/spacer.gif" Width="1" Height="1" runat="server" />
                                <asp:Button CssClass="buttonfont" ID="BackButton" Text="Back" Width="80px"
                                    runat="Server" OnClick="BackButton_Click"/>
                            </td>
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


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RoleRegistrationThanks.aspx.cs" Inherits="RoleRegistrationThanks" Title="Untitled Page" %>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolderLeftPanelMenu"
    runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="ContentPlaceHomePage" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Registration Finished<span style="font-size: 0.8em"></span>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Registration Completed
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
                                    <legend class="LegendText">Registration</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td>
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                please check your email for access clearance mail from MailingCycle Administrator before accessing the application.                                          
                                                <br />
                                                <input class="buttonfont" type="button" value="Home Page" style="width: 80px" onclick="javascript:location.href='Default.aspx'" />
                                                <!--<input class="buttonfont" type="button" value="Dashboard" style="width: 80px" onclick="javascript:location.href='Members/welcome.aspx'" />-->

                                            </td>
                                        </tr>
                                    </table> 
                                </fieldset> 
                            </td> 
                        </tr>
                    </table> 
                </td> 
            </tr> 
        </table> 
    </div> 
</asp:Content>


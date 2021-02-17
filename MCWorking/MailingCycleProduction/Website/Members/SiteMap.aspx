<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="SiteMap.aspx.cs" Inherits="Members_SiteMap" Title="Site Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Site Map
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="right-content-mainsection">
    <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td height="30" class="tableheading">
                Please click on any of the link below to jump directly to the concerned page             
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
                        <td width="49%" valign="top">
                            <fieldset>
                                <legend class="LegendText">Mailing Cycle Pages(No Login Required)</legend>
                                <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                    <tr>
                                        <td>
                                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    <tr>
                                        <td width="50%" valign="top" class="t2">
                                            <p>
                                            <ul>
                                                <li><a href="Aboutus.aspx">About us</a></li>
                                                <li><a href="Feedback.aspx">Feedback</a><br /></li>
                                                <li><a href="Contactus.aspx">Contact Us</a><br /></li>
                                                <li><a href="SiteMap.aspx">Sitemap</a></li>
                                            </ul>
                                            </p>
                                        </td>
                                    </tr>
                                </table>
                            
                            </td>
                            <td width="2%" align="center" style="padding-top: 6px">
                                <img src="../Images/blue_dot.jpg" width="1"/>
                            </td>
                            <td width="49%" valign="top">
                                <fieldset>
                                    <legend class="LegendText">Mailing Cycle Pages(Login Required)</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td>
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="50%" valign="top" class="t2">
                                                <p>
                                                <ul>
                                                    <li><a href="Welcome.aspx">Dashboard</a></li>
                                                    <li><a href="DesignManagement.aspx">Manage/Upload Designs</a><br /></li>
                                                    <li><a href="ScheduleManagement.aspx">Mailing Cycle Schedule</a><br /></li>
                                                    <li><a href="MessageManagement.aspx">Manage your Messages</a></li>
                                                    <li><a href="FarmManagement.aspx">Manage your Farm List</a></li>
                                                    <li><a href="Inventory.aspx">View Inventory</a></li>
                                                </ul>
                                                </p>
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


<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="SearchUsersResults.aspx.cs" Inherits="Admin_SearchUsersResults" Title="Mailing Cycle User Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
User Management
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Users result - 7 Users found
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
                                    <legend class="LegendText">Search Results</legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    
                                    <table border="1" cellspacing="0" cellpadding="4" width="100%" style="border-collapse: collapse">
                                        <thead>
                                            <tr>
                                                <th width="4%">
                                                    &nbsp;</th>
                                                <th width="15%">User Name</th>
                                                <th width="15%">First Name</th>
                                                <th width="15%">Last Name</th>
                                                <th width="15%">City</th>
                                                <th width="10%">State</th>
                                                <th width="10%">Zip</th>
                                                <th width="10%">UserRole</th>
                                                <th width="6%">Status</th>
                                            </tr>
                                        </thead> 
                                        <tbody>
		                                    <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyUser.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
		                                        <td><a href="ViewUser.aspx">admin</a></td>
		                                        <td>Amy</td>
		                                        <td>Smith</td>
		                                        <td>Eagan</td>
		                                        <td>MN</td>
		                                        <td>55122</td>
		                                        <td>Administrator</td>
		                                        <td>Active</td>
		                                    </tr>
		                                    <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyUser.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
		                                        <td><a href="ViewUser.aspx">CSR</a></td>
		                                        <td>
                                                    Kevin</td>
		                                        <td>Smith</td>
		                                        <td>Eagan</td>
		                                        <td>MN</td>
		                                        <td>55122</td>
		                                        <td>
                                                    CSR</td>
		                                        <td>Active</td>
		                                    </tr>
		                                    <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyUser.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
		                                        <td><a href="ViewUser.aspx">CHD</a></td>
		                                        <td>
                                                    Chandra</td>
		                                        <td>
                                                    Deval</td>
		                                        <td>Eagan</td>
		                                        <td>MN</td>
		                                        <td>55122</td>
		                                        <td>
                                                    Administrator</td>
		                                        <td>
                                                    Active</td>
		                                    </tr>
		                                    <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyUser.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
		                                        <td><a href="ViewUser.aspx">ARD</a></td>
		                                        <td>
                                                    Aurthor</td>
		                                        <td>
                                                    Anderson</td>
		                                        <td>
                                                    Woodbury</td>
		                                        <td>MN</td>
		                                        <td>
                                                    55126</td>
		                                        <td>
                                                    Printer</td>
		                                        <td>
                                                    Inactive</td>
		                                    </tr>
		                                    <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyUser.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
		                                        <td><a href="ViewUser.aspx">AmySmith</a></td>
		                                        <td>Amy</td>
		                                        <td>Smith</td>
		                                        <td>Eagan</td>
		                                        <td>MN</td>
		                                        <td>55122</td>
		                                        <td>Printer</td>
		                                        <td>Active</td>
		                                    </tr>
                                        </tbody> 
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
                    <input class="buttonfont" type="button" value="Back" style="width: 80px" onclick="javascript: document.location.href='SearchUsers.aspx'" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
        </table>
    </div>
</asp:Content>


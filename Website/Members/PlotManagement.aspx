<%@ Page Language="C#" MasterPageFile="AgentMasterPage.master" AutoEventWireup="true" CodeFile="PlotManagement.aspx.cs" Inherits="PlotManagement" Title="Mailing Cycle Plot Management" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Plot Management
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="right-content-mainsection">
    <table width="100%" cellspacing="0" class="toptable">
        <tr>
            <td height="30" class="tableheading">
                Plot Management
            </td>
        </tr>
        <tr>
            <td class="rowborder"><img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
        <tr>
            <td>
            <fieldset>
                <legend class="LegendText">Farm Header</legend>
                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td height="30" class="t2"><strong>Farm Name: </strong></td>
                        <td>West - Zone </td>
                        <td><strong>#of Contacts: </strong></td>
                        <td>2465</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="30" class="t2"><strong>Created on: </strong></td>
                        <td>04/17/2007</td>
                        <td><strong>Last Modified: </strong></td>
                        <td >04/17/2007 11:43 AM </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </fieldset> 
            </td>
        </tr>
        <tr>
          <td class="rowborder"><img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
        <tr>
            <td align="right">
                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <input type="button" name="CreatePlot" value="Create Plot" onclick="javascript:location.href='CreatePlot.aspx'"/>
                            <input type="button" name="ModifyPlot" value="Modify Plot" onclick="javascript:location.href='ModifyPlot.aspx'" />
                            <input type="button" name="DeletePlot" value="Delete Plot"  onclick="javascript:alert('Selected Plot will be deleted with the confirmation')"/>
                            <input type="button" name="ViewContacts" value="View Contacts"  onclick="javascript:location.href='ContactManagement.aspx'"/>
                        </td>
                   </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                    <tr>
                          <td class="fieldheading">&nbsp;</td>
                          <td class="fieldheading">Plot Name</td>
                          <td class="fieldheading">Created On</td>
                          <td class="fieldheading"># of Contacts</td>
                          <td class="fieldheading">Message Type</td>
                          <td class="fieldheading">&nbsp;</td>
                          <td>&nbsp;</td>
                    </tr>
                    <tr>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td class="t2">West - 3 </td>
                          <td class="t3">04/17/2007</td>
                          <td class="t2" style="text-align: right;">2465</td>
                          <td class="t3">Standard</td>
                          <td class="t3">&nbsp;</td>
                    </tr>
                    <tr>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td class="t2">East - 3 </td>
                          <td class="t3">04/17/2007</td>
                          <td class="t2" style="text-align: right;">1200</td>
                          <td class="t3">Custom</td>
                          <td class="t3">&nbsp;</td>
                    </tr>
                    <tr>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height="30" class="t2">South - 3 </td>
                          <td class="t3">04/17/2007</td>
                          <td class="t2" style="text-align: right;">545</td>
                          <td >Custom</td>
                          <td >&nbsp;</td>
                    </tr>
                    <tr>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height="30" class="t2">North - 3 </td>
                          <td class="t3">04/17/2007</td>
                          <td class="t2" style="text-align: right;">454</td>
                          <td class="t3">Not Selected</td>
                          <td class="t3">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
          <td valign="top" class="rowborder"><img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
    </table>
</div>
</asp:Content>


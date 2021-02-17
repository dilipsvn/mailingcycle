<%@ Page Language="C#" MasterPageFile="AgentMasterPage.master" AutoEventWireup="true" CodeFile="ContactManagement.aspx.cs" Inherits="ContactManagement" Title="Mailing Cycle Contact Management" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Contact Management
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript">
function OpenWindow(url)
{
    window.open(url,"MovetoPlot","toolbar=0,scrollbars=0,location=0,statusbar=1,menubar=0,resizable=1,width=350,height=250,left = 262,top = 159");
}
</script>
<div class="right-content-mainsection">
    <table width="100%" cellspacing="0" class="toptable">
        <tr>
            <td height="30" class="tableheading">
                Contact Management
            </td>
        </tr>
        <tr>
            <td class="rowborder"><img src="../../images/transparent.gif" width="1" height="1" /></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td height="30" class="t2"><strong>Farm Name: </strong></td>
                        <td>West - Zone </td>
                        <td><strong>Plot Name</strong></td>
                        <td>West - 3</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="30" class="t2"><strong>#of Contacts:</strong></td>
                        <td>2000</td>
                        <td><strong>Created on:</strong></td>
                        <td>04/17/2007</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="30" class="t2"><strong>Last Modified:</strong></td>
                        <td>04/17/2007  11:43 AM</td>
                        <td><strong></strong></td>
                        <td></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
              <td colspan="6" class="rowborder"><img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:Button ID="CreateContactButton" runat="server" Text="Create Contact" OnClick="CreateButton_Click" />
                            <asp:Button ID="ModifyContactButton" runat="server" Text="Modify Contact" OnClick="ModifyButton_Click" />
                            <asp:Button ID="DeleteContactButton" runat="server" Text="Delete Contact" onClientClick="javascript:alert('Selected Contact will be deleted with the confirmation')"/>
                            <asp:Button ID="ExporttoExcelButton" runat="server" Text="Export to Microsoft Excel" onClick="ExportButton_Click" />
                            <asp:Button ID="MovetoPlotContactButton" runat="server" Text="Move to Plot" onClientClick="javascript:OpenWindow('MovetoPlot.aspx')"/>
                        </td>                                
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                    <thead>
					    <tr>
                            <td class="fieldheading">&nbsp;</td>
							<td class="fieldheading">Schedule #</td>
							<td class="fieldheading"">Name</td>
							<td class="fieldheading">Lot#</td>
							<td class="fieldheading">Block#</td>
							<td class="fieldheading">Filing#</td>
							<td class="fieldheading">City</td>
							<td class="fieldheading">State</td>
							<td class="fieldheading">Zip</td>
						</tr>
                    </thead>
					<tbody>
                         <tr height=18 style='height:13.2pt'>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                            
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num="6505968">6505968</td>
                          <td class=xl24 style='border-top:none;border-left:none'>SNOWBRIDGE SQUARE
                          CONDOMINIUM ASSN</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>COPPER MOUNTAIN</td>
                          <td class=xl24 style='border-top:none;border-left:none'>CO</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>80443</td>
                         </tr>

                         <tr height=18 style='height:13.2pt'>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num>4008724</td>
                          <td class=xl24 style='border-top:none;border-left:none'>SNOWSCAPE HOMEOWNERS
                          ASSOCIATION</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>SILVERTHORNE</td>
                          <td class=xl24 style='border-top:none;border-left:none'>CO</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>80498</td>
                         </tr>

                         <tr height=18 style='height:13.2pt'>
                        <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num>601530</td>
                          <td class=xl24 style='border-top:none;border-left:none'>SCHOUTEN TRUSTEE
                          NORMAN J</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>9494</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>2</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>PELLA</td>
                          <td class=xl24 style='border-top:none;border-left:none'>IA</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>50219</td>
                         </tr>

                         <tr height=18 style='height:13.2pt'>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num>601531</td>
                          <td class=xl24 style='border-top:none;border-left:none'>COLLETT JR JEFFREY L</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>9495</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>2</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>FORT COLLINS</td>
                          <td class=xl24 style='border-top:none;border-left:none'>CO</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>80525</td>
                         </tr>

                         <tr height=18 style='height:13.2pt'>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num>601532</td>
                          <td class=xl24 style='border-top:none;border-left:none'>MILTON FRANCES</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>94101</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>2</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>WOLFE CITY</td>
                          <td class=xl24 style='border-top:none;border-left:none'>TX</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>75496</td>
                         </tr>

                         <tr height=18 style='height:13.2pt'>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num>601533</td>
                          <td class=xl24 style='border-top:none;border-left:none'>GEBHART DANIELLE</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>94102</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>2</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>DENVER</td>
                          <td class=xl24 style='border-top:none;border-left:none'>CO</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>80209</td>
                         </tr>

                         <tr height=18 style='height:13.2pt'>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num>601534</td>
                          <td class=xl24 style='border-top:none;border-left:none'>OGDEN ROBERT C</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>94103</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>2</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>LITTLETON</td>
                          <td class=xl24 style='border-top:none;border-left:none'>CO</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>80123</td>
                         </tr>

                         <tr height=18 style='height:13.2pt'>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num>601535</td>
                          <td class=xl24 style='border-top:none;border-left:none'>HULING JERRY L</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>94104</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>2</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>LITTLETON</td>
                          <td class=xl24 style='border-top:none;border-left:none'>CO</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>80125</td>
                         </tr>

                         <tr height=18 style='height:13.2pt'>
                          <td><input type="checkbox" name="SelectPlot" /></td>
                          <td height=18 class=xl24 align=right style='height:13.2pt;border-top:none'
                          x:num>601536</td>
                          <td class=xl24 style='border-top:none;border-left:none'>WARWICK JULIA D</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>94105</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>2</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>0</td>
                          <td class=xl24 style='border-top:none;border-left:none'>SILVERTHORNE</td>
                          <td class=xl24 style='border-top:none;border-left:none'>CO</td>
                          <td class=xl24 align=right style='border-top:none;border-left:none' x:num>80498</td>
                         </tr>
                         <tr>
                            <td colspan="9" align="right">
                            <a href="ContactManagement.aspx">Page</a>&nbsp;&nbsp;&nbsp;
                                <a href="ContactManagement.aspx">1</a>
                                <a href="ContactManagement.aspx">2</a>
                                <a href="ContactManagement.aspx">3</a>
                                <a href="ContactManagement.aspx">4</a>
                                <a href="ContactManagement.aspx">5</a>
                                <a href="ContactManagement.aspx">6</a>
                                <a href="ContactManagement.aspx">Next</a>&nbsp;&nbsp;&nbsp;
                            </td>
                         </tr>
					</tbody>
                </table>
			</td>
        </tr>
        <tr>
          <td colspan="6" class="rowborder"><img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
    </table>
</div>
</asp:Content>


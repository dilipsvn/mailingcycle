<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ViewFarm.aspx.cs" Inherits="ViewFarm" Title="Mailing Cycle View Farm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    View Farm
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    function deleteItem(msg)
    {
        confirm(msg);
    }
    
    function FirmUpFarm()
    {
        var firmUpStatus = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_FirmUpStatusHiddenField").value;
        
        if (firmUpStatus == "MP_REQ") {
            alert("You cannot firm up the farm, as no mailing plan is specified.");
            return false;
        } else if (firmUpStatus == "DESIGN_REQ") {
            alert("You cannot firm up the farm, as the required approved designs for the mailing plan are not available.");
            return false;
        } else if (firmUpStatus == "CC_INVALID") {
            alert("You cannot firm up the farm, as your credit card is expired.");
            return false;
        } else {
            return true;
        }
    }
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%">Manage your farm and plots</td>
                            <td width="40%" align="right">
                                <asp:Literal ID="ForAgentLiteral" runat="server"></asp:Literal>
                                <asp:HiddenField ID="ForAgentUserIdHiddenField" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" /></td>
            </tr>
            <tr>
                <td align="right">
                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                        <tr>
                            <td align="right">
                                    <asp:Label ID="ErrorLiteral" runat="server" cssClass="MessageText"></asp:Label>
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
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Farm Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2">
                                                Name:
                                            </td>
                                            <td width="80%" class="t3">
                                                <asp:Label ID="FarmNameLabel" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="FarmIdHiddenField" runat="server" />
                                                <asp:HiddenField ID="UserIdHiddenField" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Contact Count:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="FarmContactCountLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Mailing Plan:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="MailingPlanLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Created On:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="CreateDateLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Firmup Status:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="FirmupStatusLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Plot Count:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="PlotCountLabel" runat="server" Text=""></asp:Label>
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
                    <img src="../Images/spacer.gif" width="1" height="8" /><br />
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">List of Plots</legend>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td align="right" style="height: 24px">
                                                <asp:button ID="CreatePlotButton" runat="server" text="Add Plot" CssClass="buttonfont" Width="80px" OnClick="CreatePlotButton_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/transparent.gif" width="1" height="4" /></td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="PlotListGridView" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="PlotListGridView_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" ">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="EditHyperLink" runat="server" ImageUrl="~/Images/edit_icon.gif" NavigateUrl='<%# Eval("PlotId","~/Members/ModifyPlot.aspx?plotId={0}&farmId=" + Request.QueryString["farmId"] + "&PageName=ViewFarm.aspx") %>' />
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Plot Name">
                                                <ItemTemplate>
                                                    <asp:Image ID="PrimaryPlotImage" runat="server" ImageUrl="~/Images/primaryplot.jpg" Visible="false"></asp:Image>
                                                    <asp:HyperLink ID="FarmNameHyperLink" runat="server" Text='<%#Eval("PlotName")%>' NavigateUrl='<%# Eval("PlotId","~/Members/ViewPlot.aspx?plotId={0}") %>'></asp:HyperLink>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Created On">
                                                <ItemTemplate>
                                                    <asp:Label ID="FarmCreateDateLabel" Text='<%#Eval("CreateDate", "{0:MM/dd/yyyy}")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Count">
                                                <ItemTemplate>
                                                    <asp:Label ID="ContactCountLabel" Text='<%#Eval("ContactCount")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="align-right" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <!-- old Prototype Table
                                    <table border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse">
                                        <thead>
                                            <tr>
                                                <th width="4%">
                                                    &nbsp;</th>
                                                <th width="46%" nowrap>
                                                    Name</th>
                                                <th width="15%" nowrap>
                                                    Contact Count</th>
                                                <th width="15%" nowrap>
                                                    Created On</th>
                                                <th width="20%" nowrap>
                                                    Last Modified On</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyPlot.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
                                                <td nowrap>
                                                    <a href="javascript: document.location.href='ViewPlot.aspx'">West - 1</a>
                                                </td>
                                                <td align="right">
                                                    965</td>
                                                <td>
                                                    04/17/2007</td>
                                                <td>
                                                    04/17/2007 11:43 AM</td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyPlot.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
                                                <td nowrap>
                                                    <a href="javascript: document.location.href='ViewPlot.aspx'">West - 2</a>
                                                </td>
                                                <td align="right">
                                                    500</td>
                                                <td>
                                                    04/17/2007</td>
                                                <td>
                                                    04/17/2007 11:43 AM</td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyPlot.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
                                                <td nowrap>
                                                    <a href="javascript: document.location.href='ViewPlot.aspx'">West - 3</a>
                                                </td>
                                                <td align="right">
                                                    500</td>
                                                <td>
                                                    04/17/2007</td>
                                                <td>
                                                    04/17/2007 11:43 AM</td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <a href="javascript: document.location.href='ModifyPlot.aspx'">
                                                        <img src="../Images/edit_icon.gif" width="16" height="16" border="0" /></a></td>
                                                <td nowrap>
                                                    <a href="javascript: document.location.href='ViewPlot.aspx'">West - Zone</a>
                                                </td>
                                                <td align="right">
                                                    500</td>
                                                <td>
                                                    04/17/2007</td>
                                                <td>
                                                    04/17/2007 11:43 AM</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    -->
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
                    <asp:Button ID="EditFarmButton" runat="server" Text="Edit Farm" CssClass="buttonfont" Width="80px" OnClick="EditFarmButton_Click" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="DeleteFarmButton" runat="server" Text="Delete Farm" CssClass="buttonfont" Width="80px" OnClick="DeleteFarmButton_Click" OnClientClick="javascript: return confirm('Are you sure you want to delete this farm?');"  />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <span ID="FirmUpButtonPanel" runat="server" visible="false">
                        <asp:Button ID="FirmUpButton" Text="Firm Up" CssClass="buttonfont" Width="80px" runat="server"
                            OnClientClick="javascript: return FirmUpFarm();" OnClick="FirmUpButton_Click" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                    </span>
                    <input class="buttonfont" type="button" value="Back" style="width: 80px" onclick="javascript:location.href='FarmManagement.aspx'" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="FirmUpStatusHiddenField" runat="server" Value="" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

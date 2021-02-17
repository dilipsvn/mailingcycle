<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ScheduleManagement.aspx.cs" Inherits="Agent_ScheduleManagement" Title="Mailing Cycle Schedule Management" %>

<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Schedule Management
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    <!--
    var ctrlPrefix = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_";
    var designMode = 1;
    
    function SetMode(mode)
    {
        designMode = mode;
    }
    
    function AgentNameValidate(source, arguments)
    {
        if (designMode == 0) {
            if (arguments.Value == -1) {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        } else {
            arguments.IsValid = true;
        }
    }
    
    function ViewEvents(id)
    {
        var queryString = "?id=" + id +
            "&aId=" + document.getElementById(ctrlPrefix + "AgentIdHiddenField").value +
            "&aName=" + document.getElementById(ctrlPrefix + "AgentNameHiddenField").value +
            "&ptype=" + document.getElementById(ctrlPrefix + "PlanTypeHiddenField").value +
            "&pg=" + document.getElementById(ctrlPrefix + "PageNumberHiddenField").value;
        
        document.location.replace("ViewEvents.aspx" + queryString);
    }
    // -->
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    View your mailing plan schedules.
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ErrorMessageLabel" runat="server" Visible="false" CssClass="errormessage"></asp:Label><asp:ValidationSummary
                        ID="ErrorValidationSummary" runat="server" EnableClientScript="true" HeaderText="&nbsp;Please correct the below errors:" />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <asp:Panel ID="AgentSelectionPanel" runat="server" Visible="false">
                                    <fieldset>
                                        <legend class="LegendText">Agent Selection</legend>
                                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="t2" nowrap>
                                                    Agent Name:&nbsp;<span class="MandatoryMark">*</span></td>
                                                <td width="75%" class="t3">
                                                    <asp:DropDownList ID="AgentNameDropDownList" runat="server">
                                                        <asp:ListItem Value="-1">&lt;Select an Agent&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Button ID="GoButton" runat="server" CssClass="buttonfont" Text="Go" Width="40px"
                                                        OnClientClick="SetMode(0)" OnClick="GoButton_Click" />
                                                    <asp:CustomValidator ID="AgentNameCustomValidator" runat="server" ControlToValidate="AgentNameDropDownList"
                                                        ClientValidationFunction="AgentNameValidate" ErrorMessage="Agent Name is Required."
                                                        Display="None" SetFocusOnError="true"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <br />
                                </asp:Panel>
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
                                <asp:HyperLink ID="ActivePlansHyperLink" runat="server">Active Mailing Plans</asp:HyperLink>
                                |
                                <asp:HyperLink ID="CompletedPlansHyperLink" runat="server">Completed Mailing Plans</asp:HyperLink></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">
                                        <asp:Label ID="LegendTitleLabel" runat="server" Text=""></asp:Label></legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt"
                                        HeaderStyle-Height="15px" AutoGenerateColumns="false" runat="server" ID="ActivePlansDataGrid"
                                        BorderWidth="1" CellSpacing="0" CellPadding="5" Width="100%" Style="border-collapse: collapse"
                                        AllowPaging="True" PageSize="20" PagerStyle-Mode="NumericPages" OnPageIndexChanged="Plans_Changed">
                                        <Columns>
                                            <asp:HyperLinkColumn HeaderStyle-Width="30%" ItemStyle-Wrap="false" HeaderText="Farm"
                                                DataNavigateUrlField="ScheduleId" DataNavigateUrlFormatString="javascript: ViewEvents({0});"
                                                DataTextField="FarmName"></asp:HyperLinkColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="19%" ItemStyle-Wrap="false" HeaderText="Mailing Plan">
                                                <ItemTemplate>
                                                    <asp:Label ID="MailingPlanLabel" Text='<%# Eval("Plan.Title") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="12%" ItemStyle-Wrap="false" HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="StartDateLabel" Text='<%# Eval("StartDate", "{0:MM/dd/yyyy}") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="12%" ItemStyle-Wrap="false" HeaderText="End Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="EndDateLabel" Text='<%# Eval("EndDate", "{0:MM/dd/yyyy}") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn HeaderStyle-Width="12%" ItemStyle-Wrap="false" HeaderText="Plot Count"
                                                DataField="NumberOfPlots" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundColumn HeaderStyle-Width="15%" ItemStyle-Wrap="false" HeaderText="Contact Count"
                                                DataField="NumberOfContacts" ItemStyle-HorizontalAlign="Right" />
                                        </Columns>
                                    </asp:DataGrid>
                                    <table id="NoRecordsTable" runat="server" visible="false" border="1" cellspacing="0"
                                        cellpadding="5" width="100%" height="60px" style="border-collapse: collapse">
                                        <tr>
                                            <td nowrap align="center" class="errormessage">
                                                No mailing plans available.</td>
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
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="AgentIdHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="AgentNameHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="PlanTypeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="PageNumberHiddenField" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

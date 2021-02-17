<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ViewEvents.aspx.cs" Inherits="Members_ViewEvents" Title="Mailing Cycle View Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    View Events
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    <!--
    var ctrlPrefix = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_";
    
    function ViewEvent(id)
    {
        var queryString = "?id=" + id +
            "&sId=" + document.getElementById(ctrlPrefix + "IdHiddenField").value +
            "&aId=" + document.getElementById(ctrlPrefix + "AgentIdHiddenField").value +
            "&aName=" + document.getElementById(ctrlPrefix + "AgentNameHiddenField").value +
            "&et=" + document.getElementById(ctrlPrefix + "EventTypeHiddenField").value +
            "&ptype=" + document.getElementById(ctrlPrefix + "PlanTypeHiddenField").value +
            "&pg=" + document.getElementById(ctrlPrefix + "PageNumberHiddenField").value;
        
        document.location.replace("ViewEvent.aspx" + queryString);
    }
    
    function openHelp(path)
    {
        var iWidth = 300;
        var iHeight = screen.height - 100;
        var iLeft = (screen.width - iWidth) - 12;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
        window.open(path, "Help", sFeatures + sSize);
    }
    // -->
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                View your mailing plan events.
                            </td>
                            <td align="right">
                                <asp:Label ID="AgentNameLabel" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ErrorMessageLabel" runat="server" Visible="false" CssClass="errormessage"></asp:Label>
                    <asp:ValidationSummary ID="ErrorValidationSummary" runat="server" EnableClientScript="true"
                        HeaderText="&nbsp;Please correct the below errors:" />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Mailing Plan Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2" nowrap>
                                                Farm:</td>
                                            <td width="80%" class="t3">
                                                <asp:Label ID="FarmLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Mailing Plan:</td>
                                            <td class="t3">
                                                <asp:Label ID="MailingPlanLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Start Date:</td>
                                            <td class="t3">
                                                <asp:Label ID="StartDateLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                End Date:</td>
                                            <td class="t3">
                                                <asp:Label ID="EndDateLabel" runat="server" Text=""></asp:Label></td>
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
                                <asp:HyperLink ID="FutureEventsHyperLink" runat="server">Future Events</asp:HyperLink>
                                |
                                <asp:HyperLink ID="PastEventsHyperLink" runat="server">Past Events</asp:HyperLink></td>
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
                                        HeaderStyle-Height="15px" AutoGenerateColumns="false" runat="server" ID="FutureEventsDataGrid"
                                        BorderWidth="1" CellSpacing="0" CellPadding="5" Width="100%" Style="border-collapse: collapse"
                                        Visible="false">
                                        <Columns>
                                            <asp:BoundColumn HeaderStyle-Width="10%" ItemStyle-Wrap="false" HeaderText="Event #"
                                                DataField="EventNumber" />
                                            <asp:HyperLinkColumn HeaderStyle-Width="12%" ItemStyle-Wrap="false" HeaderText="Event Date"
                                                DataNavigateUrlField="EventId" DataNavigateUrlFormatString="javascript: ViewEvent({0});"
                                                DataTextField="EventDate" DataTextFormatString="{0:MM/dd/yyyy}"></asp:HyperLinkColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="15%" ItemStyle-Wrap="false" HeaderText="Product Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="ProductTypeLabel" Text='<%# Eval("ProductType.Name") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn HeaderStyle-Width="15%" ItemStyle-Wrap="false" HeaderText="Postal Tariff"
                                                DataField="PostalTariff" />
                                            <asp:TemplateColumn HeaderStyle-Width="12%" ItemStyle-Wrap="false" HeaderText="Plot Count"
                                                ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="PlotCountLabel" Text='<%# Eval("Status.Name").ToString() == "Cancelled" ? "-" : Eval("NumberOfPlots") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="15%" ItemStyle-Wrap="false" HeaderText="Contact Count"
                                                ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="ContactCountLabel" Text='<%# Eval("Status.Name").ToString() == "Cancelled" ? "-" : Eval("NumberOfContacts") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="21%" ItemStyle-Wrap="false" HeaderText="Status">
                                                <HeaderTemplate>
                                                    Status<span style="position: absolute; z-index: 2">&nbsp;<a href="javascript: openHelp('../Help/EventStatus.htm');"><img
                                                        src="../Images/helpIcon.gif" /></a></span>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="StatusLabel" Text='<%# Eval("Status.Name") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                    </asp:DataGrid>
                                    <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt"
                                        HeaderStyle-Height="15px" AutoGenerateColumns="false" runat="server" ID="PastEventsDataGrid"
                                        BorderWidth="1" CellSpacing="0" CellPadding="5" Width="100%" Style="border-collapse: collapse"
                                        Visible="false">
                                        <Columns>
                                            <asp:BoundColumn HeaderStyle-Width="10%" ItemStyle-Wrap="false" HeaderText="Event #"
                                                DataField="EventNumber" />
                                            <asp:HyperLinkColumn HeaderStyle-Width="12%" ItemStyle-Wrap="false" HeaderText="Event Date"
                                                DataNavigateUrlField="EventId" DataNavigateUrlFormatString="javascript: ViewEvent({0});"
                                                DataTextField="EventDate" DataTextFormatString="{0:MM/dd/yyyy}"></asp:HyperLinkColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="15%" ItemStyle-Wrap="false" HeaderText="Product Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="ProductTypeLabel" Text='<%# Eval("ProductType.Name") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn HeaderStyle-Width="15%" ItemStyle-Wrap="false" HeaderText="Postal Tariff"
                                                DataField="PostalTariff" />
                                            <asp:TemplateColumn HeaderStyle-Width="15%" ItemStyle-Wrap="false" HeaderText="Contact Count"
                                                ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="ContactCountLabel" Text='<%# Eval("Status.Name").ToString() == "Cancelled" ? "-" : Eval("NumberOfContacts") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="13%" ItemStyle-Wrap="false" HeaderText="Status">
                                                <HeaderTemplate>
                                                    Status<span style="position: absolute; z-index: 2">&nbsp;<a href="javascript: openHelp('../Help/EventStatus.htm');"><img
                                                        src="../Images/helpIcon.gif" /></a></span>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="StatusLabel" Text='<%# Eval("Status.Name") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="20%" ItemStyle-Wrap="false" HeaderText="Completed On">
                                                <ItemTemplate>
                                                    <asp:Label ID="CompletedOnLabel" Text='<%# Eval("CompletedOn", "{0:MM/dd/yyyy}") == "01/01/0001" ? "-" : Eval("CompletedOn", "{0:MM/dd/yyyy hh:mm tt}") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                    </asp:DataGrid>
                                    <table id="NoRecordsTable" runat="server" visible="false" border="1" cellspacing="0"
                                        cellpadding="5" width="100%" height="60px" style="border-collapse: collapse">
                                        <tr>
                                            <td nowrap align="center" class="errormessage">
                                                No events available.</td>
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
                    <asp:Button ID="BackButton" Text="Back" CssClass="buttonfont" Width="80px" runat="server"
                        OnClick="CancelButton_Click" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="IdHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="EventTypeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="AgentIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="AgentNameHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="PlanTypeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="PageNumberHiddenField" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

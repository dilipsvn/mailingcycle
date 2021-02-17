<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ViewEventContacts.aspx.cs" Inherits="Members_ViewEventContacts" Title="Mailing Cycle View Event Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    View Event Contacts
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    var ctrlPrefix = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_";
    
	function LaunchReport()
	{
        var eventId = document.getElementById(ctrlPrefix + "IdHiddenField").value;
        
        var queryString = "?eId=" + eventId;
        
        var iWidth = 900;
        var iHeight = 650;
        var iLeft = (screen.width - iWidth) / 2;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + "";
        
        window.open("EventMailingLabelsReport.aspx" + queryString, "ReportViewer", sFeatures + sSize);
        
        return false;
	}
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                Please view the event contacts in the below form.
                            </td>
                            <td align="right">
                                <asp:Label ID="AgentNameLabel" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../../images/transparent.gif" width="1" height="1" />
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
                                <fieldset>
                                    <legend class="LegendText">Event Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2" nowrap>
                                                Event #:</td>
                                            <td width="80%" class="t3">
                                                <asp:Label ID="EventNumberLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Event Date:</td>
                                            <td class="t3">
                                                <asp:Label ID="EventDateLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Farm:</td>
                                            <td class="t3">
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
                                <fieldset>
                                    <legend class="LegendText">List of Contacts</legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt"
                                        HeaderStyle-Height="15px" AutoGenerateColumns="false" runat="server" ID="ContactsGrid"
                                        BorderWidth="1" CellSpacing="0" CellPadding="5" Width="100%" Style="border-collapse: collapse"
                                        Visible="true" OnItemDataBound="Contact_Bound" AllowPaging="True" PageSize="20"
                                        PagerStyle-Mode="NumericPages" OnPageIndexChanged="Contacts_Changed">
                                        <Columns>
                                            <asp:BoundColumn HeaderStyle-Width="30%" HeaderText="Plot" DataField="PlotName" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundColumn HeaderStyle-Width="12%" HeaderText="Contact Id" DataField="ContactId"
                                                ItemStyle-VerticalAlign="Top" />
                                            <asp:TemplateColumn HeaderStyle-Width="26%" HeaderText="Name" ItemStyle-VerticalAlign="Top">
                                                <ItemTemplate>
                                                    <asp:Label ID="NameLabel" Text='<%# Eval("FirstName").ToString() + " " + Eval("LastName") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="32%" HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="AddressLabel" Text='<%# Eval("Address1").ToString() + "<br />" + (Eval("Address2").ToString() == "" ? "" : (Eval("Address2").ToString() + "<br />")) + Eval("City").ToString() + ", " + Eval("State").ToString() + "<br />" + Eval("Zip").ToString() + " - " + Eval("Country").ToString() %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                    </asp:DataGrid>
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
                    <asp:Button ID="ExportButton" Text="Export to Microsoft Excel" CssClass="buttonfont"
                        Width="160px" runat="server" OnClick="ExportButton_Click" CausesValidation="true" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="ReportButton" Text="Mailing Labels Report" CssClass="buttonfont"
                        Width="140px" runat="server" OnClientClick="javascript: return LaunchReport();"
                        CausesValidation="true" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="CancelButton" Text="Back" CssClass="buttonfont" Width="80px" runat="server"
                        OnClick="CancelButton_Click" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="IdHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="ScheduleIdHiddenField" runat="server" Value="" />
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

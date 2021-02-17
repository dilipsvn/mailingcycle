<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="FirmUpCalendar.aspx.cs" Inherits="Members_FirmUpCalendar" Title="Mailing Cycle Firm Up Plan Schedule" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Firm Up Plan Schedule
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
	function FirmUpPlan()
    {
        return confirm("Are you sure you want to firm up the plan?");
    }
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    View the schedule events of the mailing plan for the specified start date and firm
                    up.
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
                                    <legend class="LegendText">Farm Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="24%" class="t2" nowrap>
                                                Name:</td>
                                            <td width="76%" class="t3">
                                                <asp:Label ID="FarmNameLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Plot Count:</td>
                                            <td class="t3">
                                                <asp:Label ID="PlotCountLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Contact Count:</td>
                                            <td class="t3">
                                                <asp:Label ID="ContactCountLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Mailing Plan:</td>
                                            <td class="t3">
                                                <asp:Label ID="MailingPlanLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Created On:</td>
                                            <td class="t3">
                                                <asp:Label ID="CreatedOnLabel" runat="server" Text=""></asp:Label></td>
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
                                    <legend class="LegendText">Schedule Events</legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt"
                                        HeaderStyle-Height="15px" AutoGenerateColumns="false" runat="server" ID="EventsDataGrid"
                                        BorderWidth="1" CellSpacing="0" CellPadding="5" Width="100%" Style="border-collapse: collapse">
                                        <Columns>
                                            <asp:BoundColumn ItemStyle-Wrap="false" HeaderText="Event #"
                                                DataField="EventNumber" />
                                            <asp:BoundColumn ItemStyle-Wrap="false" HeaderText="Event Date"
                                                DataField="EventDate" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:TemplateColumn ItemStyle-Wrap="false" HeaderText="Product Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="ProductTypeLabel" Text='<%# Eval("ProductType.Name") %>' runat="server"></asp:Label>
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
                    <asp:Button ID="FirmUpButton" Text="Firm Up" CssClass="buttonfont" Width="80px" runat="server"
                        OnClientClick="javascript: return FirmUpPlan();" OnClick="FirmUpButton_Click"
                        CausesValidation="true" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="CancelButton" Text="Cancel" CssClass="buttonfont" Width="80px" runat="server"
                        OnClick="CancelButton_Click" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td height="50">
                </td>
            </tr>
            <tr>
                <td style="background-color: #c9cacd">
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                If the Mailing Plan Schedule Events are as per your requirements; click on
                                <i>'Firm Up'</i> button to firm up your mailing plan.
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="FarmIdHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="PlanIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="StartDateHiddenField" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

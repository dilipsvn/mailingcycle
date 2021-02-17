<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="PreviewMessage.aspx.cs" Inherits="Members_PreviewMessage" Title="Mailing Cycle Preview Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Preview Message
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                Please view the preview of the message in the below form.
                            </td>
                            <td align="right">
                                <asp:Label ID="AgentNameLabel" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../../images/transparent.gif" width="1" height="1" /></td>
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
                    &nbsp;</td>
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
                                            <td class="t2" nowrap>
                                                Plot:</td>
                                            <td class="t3">
                                                <asp:Label ID="PlotLabel" runat="server" Text=""></asp:Label></td>
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
                                    <legend class="LegendText">Message Preview</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td>
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                <div id="DesignImageLayer" style="position: relative; z-index: 1" runat="server">
                                                    <asp:Image ID="DesignImage" runat="server" /></div>
                                                <div id="DesignTextLayer" style="position: absolute; z-index: 2; zoom: 100%" runat="server">
                                                    <div id="DesignText" runat="server">
                                                        <asp:Image ID="MessageImage" runat="server" Visible="false" /></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
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
                <td align="center">
                    <asp:Button ID="CancelButton" Text="Back" CssClass="buttonfont" Width="80px" runat="server"
                        OnClick="CancelButton_Click" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="IdHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="PrevMessageIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="EventIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="ScheduleIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="EventTypeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="AgentIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="AgentNameHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="ProductTypeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="ModeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="PlanTypeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="PageNumberHiddenField" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

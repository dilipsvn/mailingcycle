<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="AssignMessage.aspx.cs" Inherits="Members_AssignMessage" Title="Mailing Cycle Assign Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Assign Message
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                Please modify message details in the below form.
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="Notes" style="padding-left: 20px">
                    Fields marked with <span class="MandatoryMark">*</span> are mandatory</td>
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
                                    <legend class="LegendText">Message Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2" nowrap>
                                                Plot:</td>
                                            <td width="80%" class="t3">
                                                <asp:Label ID="PlotLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Message Type:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="MessageTypeDropDownList" runat="server" AutoPostBack="true"
                                                    CausesValidation="false" OnSelectedIndexChanged="MessageTypeDropDownList_Changed">
                                                    <asp:ListItem Value="1">Standard</asp:ListItem>
                                                    <asp:ListItem Value="2">Custom</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Message:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <asp:DropDownList ID="MessageDropDownList" runat="server" AutoPostBack="true" CausesValidation="false"
                                                    OnSelectedIndexChanged="MessageDropDownList_Changed">
                                                    <asp:ListItem Value="-1">&lt;Select a Message&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="MessageRequiredFieldValidator" ControlToValidate="MessageDropDownList"
                                                    Display="None" ErrorMessage="Message is Required." InitialValue="-1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap valign="top">
                                                Message Text:</td>
                                            <td class="t3">
                                                <asp:Panel ID="MessageTextPanel" Style="border: 1px dotted #336699; width: 500px;
                                                    padding: 5px 5px 5px 5px" runat="server">
                                                    <asp:Literal ID="MessageTextLiteral" runat="server"></asp:Literal>
                                                </asp:Panel>
                                                <asp:Panel ID="MessageImagePanel" Style="border: 1px dotted #336699; width: 500px;
                                                    padding: 5px 5px 5px 5px" runat="server" Visible="false">
                                                    <asp:Image ID="MessageTextImage" Width="500px" runat="server" />
                                                </asp:Panel>
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
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="PreviewButton" Text="Preview Message" CssClass="buttonfont" Width="120px"
                        runat="server" OnClick="PreviewButton_Click" CausesValidation="true" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="SaveButton" Text="Save" CssClass="buttonfont" Width="80px" runat="server"
                        OnClick="SaveButton_Click" CausesValidation="true" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="CancelButton" Text="Cancel" CssClass="buttonfont" Width="80px" runat="server"
                        OnClick="CancelButton_Click" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="IdHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="PrevMessageIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="FarmIdHiddenField" runat="server" Value="" />
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

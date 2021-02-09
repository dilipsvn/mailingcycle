<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ViewEvent.aspx.cs" Inherits="Members_ViewEvent" Title="Mailing Cycle View Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    View Event
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    <!--
    var ctrlPrefix = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_";
    
    function AssignMessage(id)
    {
        var queryString = "?id=" + id +
            "&eId=" + document.getElementById(ctrlPrefix + "IdHiddenField").value +
            "&sId=" + document.getElementById(ctrlPrefix + "ScheduleIdHiddenField").value +
            "&aId=" + document.getElementById(ctrlPrefix + "AgentIdHiddenField").value +
            "&aName=" + document.getElementById(ctrlPrefix + "AgentNameHiddenField").value +
            "&et=" + document.getElementById(ctrlPrefix + "EventTypeHiddenField").value +
            "&ptype=" + document.getElementById(ctrlPrefix + "PlanTypeHiddenField").value +
            "&pg=" + document.getElementById(ctrlPrefix + "PageNumberHiddenField").value;
        
        document.location.replace("AssignMessage.aspx" + queryString);
    }
    
    function ViewMessage(id)
    {
        var queryString = "?id=" + id +
            "&eId=" + document.getElementById(ctrlPrefix + "IdHiddenField").value +
            "&sId=" + document.getElementById(ctrlPrefix + "ScheduleIdHiddenField").value +
            "&aId=" + document.getElementById(ctrlPrefix + "AgentIdHiddenField").value +
            "&aName=" + document.getElementById(ctrlPrefix + "AgentNameHiddenField").value +
            "&et=" + document.getElementById(ctrlPrefix + "EventTypeHiddenField").value +
            "&mode=view" +
            "&ptype=" + document.getElementById(ctrlPrefix + "PlanTypeHiddenField").value +
            "&pg=" + document.getElementById(ctrlPrefix + "PageNumberHiddenField").value;
        
        document.location.replace("AssignMessage.aspx" + queryString);
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
                                View your mailing plan event details.
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
                                    <legend class="LegendText">Event Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="3">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2" nowrap>
                                                Event #:</td>
                                            <td width="30%" class="t3">
                                                <asp:Label ID="EventNumberLabel" runat="server" Text=""></asp:Label></td>
                                            <td width="50%" class="t2" rowspan="6" valign="top">
                                                <fieldset>
                                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                                        <tr>
                                                            <td colspan="2">
                                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td width="40%" class="t2" nowrap>
                                                                Product Type:</td>
                                                            <td width="60%" class="t3">
                                                                <asp:Label ID="ProductTypeLabel" runat="server" Text=""></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="t2" nowrap>
                                                                Postal Tariff:</td>
                                                            <td class="t3">
                                                                <asp:DropDownList ID="PostalTariffDropDownList" runat="server">
                                                                    <asp:ListItem Value="Bulk Mail">Bulk Mail</asp:ListItem>
                                                                    <asp:ListItem Value="Postage Stamps">Postage Stamps</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="TotalChargesPanel" runat="server">
                                                            <tr>
                                                                <td class="t2" nowrap>
                                                                    Total Charges:</td>
                                                                <td class="t3">
                                                                    <span class="Notes">US $</span>
                                                                    <asp:Label ID="TotalChargesLabel" runat="server" Text="" Width="60px" style="text-align:right"></asp:Label></td>
                                                            </tr>
                                                            <asp:Panel ID="RefundAmountPanel" runat="server">
                                                                <tr>
                                                                    <td class="t2" nowrap>
                                                                        Refund Amount:</td>
                                                                    <td class="t3">
                                                                        <span class="Notes">US $</span>
                                                                        <asp:Label ID="RefundAmountLabel" runat="server" Text="" Width="60px" style="text-align:right"></asp:Label></td>
                                                                </tr>
                                                            </asp:Panel>
                                                        </asp:Panel>
                                                        <tr>
                                                            <td colspan="2">
                                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
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
                                                Design:</td>
                                            <td class="t3" colspan="2">
                                                <asp:HyperLink ID="DesignHyperLink" runat="server"></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Status:</td>
                                            <td class="t3" colspan="2">
                                                <asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <asp:Panel ID="NotesReadOnlyPanel" runat="server" Visible="false">
                                                <td class="t2" nowrap>
                                                    Notes:</td>
                                                <td class="t3" colspan="2">
                                                    <asp:Label ID="NotesLabel" runat="server" Text=""></asp:Label></td>
                                            </asp:Panel>
                                            <asp:Panel ID="NotesReadWritePanel" runat="server">
                                                <td class="t2" nowrap valign="top">
                                                    Notes:&nbsp;<span class="MandatoryMark">*</span></td>
                                                <td class="t3" colspan="2">
                                                    <asp:TextBox ID="NotesTextBox" runat="server" TextMode="Multiline" Wrap="true" Rows="2"
                                                        Columns="64"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="NotesRequiredFieldValidator" ControlToValidate="NotesTextBox"
                                                        Display="None" ErrorMessage="Notes is Required." runat="server" /></td>
                                            </asp:Panel>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
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
                                    <legend class="LegendText">List of Plots</legend>
                                    <img src="../images/transparent.gif" width="1" height="8" /><br />
                                    <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt"
                                        HeaderStyle-Height="15px" AutoGenerateColumns="false" runat="server" ID="FutureEventDetailsDataGrid"
                                        BorderWidth="1" CellSpacing="0" CellPadding="5" Width="100%" Style="border-collapse: collapse"
                                        Visible="true" OnItemCreated="FutureEventDetails_Created">
                                        <Columns>
                                            <asp:BoundColumn HeaderStyle-Width="20%" HeaderText="Plot" DataField="PlotName" />
                                            <asp:BoundColumn HeaderStyle-Width="15%" HeaderText="Contact Count" DataField="NumberOfContacts"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:TemplateColumn HeaderStyle-Width="15%" HeaderText="Message Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="MessageTypeLabel" Text='<%# Convert.ToInt32(Eval("Message.MessageId")) == 0 ? "" : Eval("Message.MessageType").ToString() %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="32%" HeaderText="Message">
                                                <ItemTemplate>
                                                    <asp:Label ID="MessageLabel" Text='<%# Eval("Message.MessageTextShort") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="18%" HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="MessageHyperLink" NavigateUrl='<%# "javascript: AssignMessage(" + Eval("PlotId").ToString() + ");" %>'
                                                        Text='<%# Convert.ToInt32(Eval("Message.MessageId")) == 0 ? "[Assign Message]" : "[Update Message]" %>'
                                                        runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                    </asp:DataGrid>
                                    <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt"
                                        HeaderStyle-Height="15px" AutoGenerateColumns="false" runat="server" ID="PastEventDetailsDataGrid"
                                        BorderWidth="1" CellSpacing="0" CellPadding="5" Width="100%" Style="border-collapse: collapse"
                                        Visible="true" OnItemCreated="FutureEventDetails_Created">
                                        <Columns>
                                            <asp:BoundColumn HeaderStyle-Width="20%" HeaderText="Plot" DataField="PlotName" />
                                            <asp:BoundColumn HeaderStyle-Width="15%" HeaderText="Contact Count" DataField="NumberOfContacts"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:TemplateColumn HeaderStyle-Width="15%" HeaderText="Message Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="MessageTypeLabel" Text='<%# Convert.ToInt32(Eval("Message.MessageId")) == 0 ? "" : Eval("Message.MessageType").ToString() %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="32%" HeaderText="Message">
                                                <ItemTemplate>
                                                    <asp:Label ID="MessageLabel" Text='<%# Eval("Message.MessageTextShort") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderStyle-Width="18%" HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="MessageHyperLink" NavigateUrl='<%# "javascript: ViewMessage(" + Eval("PlotId").ToString() + ");" %>'
                                                        Text="[View Message]" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                    </asp:DataGrid>
                                    <table id="NoRecordsTable" runat="server" visible="false" border="1" cellspacing="0"
                                        cellpadding="5" width="100%" height="60px" style="border-collapse: collapse">
                                        <tr>
                                            <td nowrap align="center" class="errormessage">
                                                No plots available.</td>
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
            <asp:Panel ID="PrinterRemarksPanel" runat="server">
                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend class="LegendText">Printer Remarks</legend>
                                        <asp:Panel ID="PrinterRemarksRWPanel" runat="server">
                                            <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                                </tr>
                                                <tr>
                                                    <td width="20%" class="t2" nowrap>
                                                        Mailing List File:&nbsp;<span class="MandatoryMark">*</span></td>
                                                    <td width="80%" class="t3">
                                                        <asp:FileUpload ID="MailingListFileUpload" runat="server" Width="450px" />
                                                        <asp:RequiredFieldValidator ID="MailingListFileRequiredFieldValidator" ControlToValidate="MailingListFileUpload"
                                                            Display="None" ErrorMessage="Mailing List File is Required." runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="t2" nowrap>
                                                        Mailing Count:&nbsp;<span class="MandatoryMark">*</span></td>
                                                    <td class="t3">
                                                        <asp:TextBox ID="MailingCountTextBox" runat="server" CssClass="textbox" Width="80"
                                                            MaxLength="6"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="MailingCountRequiredFieldValidator" ControlToValidate="MailingCountTextBox"
                                                            Display="None" ErrorMessage="Mailing Count is Required." runat="server" />
                                                        <asp:RangeValidator ID="MailingCountRangeValidator" ControlToValidate="MailingCountTextBox"
                                                            MinimumValue="1" MaximumValue="999999" Type="Integer" EnableClientScript="true"
                                                            Display="None" ErrorMessage="Enter a valid Mailing Count." runat="server" /></td>
                                                </tr>
                                                <tr>
                                                    <td class="t2" nowrap valign="top">
                                                        Remarks:</td>
                                                    <td class="t3">
                                                        <asp:TextBox ID="RemarksTextBox" runat="server" TextMode="Multiline" Wrap="true"
                                                            Rows="2" Columns="64"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="PrinterRemarksROPanel" runat="server" Visible="false">
                                            <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                                </tr>
                                                <tr>
                                                    <td width="20%" class="t2" nowrap>
                                                        Mailing List File:</td>
                                                    <td width="80%" class="t3">
                                                        <asp:HyperLink ID="MailingListFileHyperLink" runat="server"></asp:HyperLink></td>
                                                </tr>
                                                <tr>
                                                    <td class="t2" nowrap>
                                                        Mailing Count:</td>
                                                    <td class="t3">
                                                        <asp:Label ID="MailingCountLabel" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="t2" nowrap valign="top">
                                                        Remarks:</td>
                                                    <td class="t3">
                                                        <asp:Label ID="RemarksLabel" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <asp:Panel ID="ExceptionReportedPanel" runat="server" Visible="false">
                                                    <tr>
                                                        <td class="t2" nowrap>
                                                            Exception Reported:</td>
                                                        <td class="t3">
                                                            <asp:Image ID="ExceptionReportedImage" runat="server" ImageUrl="" Height="16px"></asp:Image></td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td colspan="3">
                                                        <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
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
            </asp:Panel>
            <tr>
                <td align="center">
                    <asp:Panel ID="ReadOnlyButtonsPanel" runat="server" Visible="false">
                        <asp:Button ID="BackButton" Text="Back" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
                    <asp:Panel ID="ReadWriteButtonsPanel" runat="server" Visible="false">
                        <asp:Button ID="SaveButton" Text="Save" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="SaveButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="BackButton1" Text="Back" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
                    <asp:Panel ID="CancelEventButtonsPanel" runat="server" Visible="false">
                        <asp:Button ID="CancelEventButton" Text="Cancel Event" CssClass="buttonfont" Width="100px"
                            runat="server" OnClick="CancelEventButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="SaveButton1" Text="Save" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="SaveButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="BackButton2" Text="Back" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
                    <asp:Panel ID="CompleteEventButtonsPanel" runat="server" Visible="false">
                        <asp:Button ID="ViewContactsButton" Text="View Contacts" CssClass="buttonfont" Width="100px"
                            runat="server" OnClick="ViewContactsButton_Click" CausesValidation="false" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="CompleteEventButton" Text="Complete Event" CssClass="buttonfont"
                            Width="100px" runat="server" OnClick="CompleteEventButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="BackButton3" Text="Back" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
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
                    <asp:HiddenField ID="ProductTypeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="PlanTypeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="PageNumberHiddenField" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

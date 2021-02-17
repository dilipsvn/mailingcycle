<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ScheduleEventsReportCriteria.aspx.cs" Inherits="Members_ScheduleEventsReportCriteria"
    Title="Mailing Cycle Schedule & Events Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Schedule & Events Report
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    var ctrlPrefix = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_";
    
	function CalendarPicker(ctrlID, hiidenID)
	{
	    var textBox = ctrlPrefix + ctrlID + "," + ctrlPrefix + hiidenID;
	    
	    var iWidth = 160;
        var iHeight = 160;
        var iLeft = window.event.clientX;
        var iTop = window.event.clientY;
        
	    var sFeatures = "toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + "";
        
		window.open('DatePicker.aspx?sA=1&field=' + textBox,'CalendarPicker',sFeatures + sSize);
	}
	
	function LaunchReport()
	{
	    var bValid = false;
	    
	    WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions('ctl00$ctl00$ContentPlaceHolder1$ContentPlaceHolder1$LaunchButton', '', true, '', '', false, false));
	    bValid = ValidatorCommonOnSubmit();
	    
	    if (bValid) {
	        var agentList = document.getElementById(ctrlPrefix + "AgentDropDownList");
	        var planList = document.getElementById(ctrlPrefix + "MailingPlanDropDownList");
	        var eventList = document.getElementById(ctrlPrefix + "EventDropDownList");
	        var startDateField = document.getElementById(ctrlPrefix + "StartDateHiddenField");
	        var endDateField = document.getElementById(ctrlPrefix + "EndDateHiddenField");
	        
	        var queryString = "?aId=" + agentList.options[agentList.selectedIndex].value +
                "&pType=" + planList.options[planList.selectedIndex].value +
                "&eType=" + eventList.options[eventList.selectedIndex].value +
                "&sDate=" + startDateField.value +
                "&eDate=" + endDateField.value;
            
            var iWidth = 900;
            var iHeight = 650;
            var iLeft = (screen.width - iWidth) / 2;
            var iTop = ((screen.height - iHeight) / 2) - 20;
            
	        var sFeatures = "toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,";
            var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + "";
	        
            window.open("ScheduleEventsReport.aspx" + queryString, "ReportViewer", sFeatures + sSize);
        }
        
        return false;
	}
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    Please specify your selection criteria for schedule and events report in the below
                    form.</td>
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
                                    <legend class="LegendText">Report Criteria</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2" nowrap>
                                                Agent:</td>
                                            <td width="80%" class="t3">
                                                <asp:DropDownList ID="AgentDropDownList" runat="server">
                                                    <asp:ListItem Value="0">&lt;All Agents&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Mailing Plan:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="MailingPlanDropDownList" runat="server">
                                                    <asp:ListItem Value="*">&lt;All Plans&gt;</asp:ListItem>
                                                    <asp:ListItem Value="A">Active Plans</asp:ListItem>
                                                    <asp:ListItem Value="C">Closed Plans</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Event:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="EventDropDownList" runat="server">
                                                    <asp:ListItem Value="*">&lt;All Events&gt;</asp:ListItem>
                                                    <asp:ListItem Value="F">Future Events</asp:ListItem>
                                                    <asp:ListItem Value="P">Past Events</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Start Date:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <asp:TextBox ID="StartDateTextBox" runat="server" CssClass="textbox" Width="100"
                                                    MaxLength="10" ReadOnly="true" Text=""></asp:TextBox>&nbsp;<a href="javascript: //"
                                                        onclick="javascript: CalendarPicker('StartDateTextBox', 'StartDateHiddenField')"><img
                                                            src="../images/dtp.gif" width="16" height="16" border="0"></a>
                                                <asp:RequiredFieldValidator ID="StartDateRequiredFieldValidator" ControlToValidate="StartDateTextBox"
                                                    Display="None" ErrorMessage="Start Date is Required." InitialValue="" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                End Date:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <asp:TextBox ID="EndDateTextBox" runat="server" CssClass="textbox" Width="100" MaxLength="10"
                                                    ReadOnly="true" Text=""></asp:TextBox>&nbsp;<a href="javascript: //" onclick="javascript: CalendarPicker('EndDateTextBox', 'EndDateHiddenField')"><img
                                                        src="../images/dtp.gif" width="16" height="16" border="0"></a>
                                                <asp:RequiredFieldValidator ID="EndDateRequiredFieldValidator" ControlToValidate="EndDateTextBox"
                                                    Display="None" ErrorMessage="End Date is Required." InitialValue="" runat="server" />
                                                <asp:CompareValidator ID="EndDateCompareValidator" ControlToValidate="EndDateTextBox"
                                                    ControlToCompare="StartDateTextBox" EnableClientScript="True" Type="Date" Operator="GreaterThan"
                                                    Display="None" ErrorMessage="End Date should be grater than Start Date." runat="server" />
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
                    <asp:Button ID="LaunchButton" Text="Launch" CssClass="buttonfont" Width="80px" runat="server"
                        OnClientClick="javascript: return LaunchReport();" CausesValidation="true" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <input id="CancelButton" type="reset" value="Clear All" runat="server" class="buttonfont"
                        style="width: 80px" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="StartDateHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="EndDateHiddenField" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

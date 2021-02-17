<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ScheduleMgmtReportCriteria.aspx.cs" Inherits="Members_ScheduleMgmtReportCriteria"
    Title="Mailing Cycle Schedule Management Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Schedule Management Report
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
	
	function IsRangeValid()
	{
	    var ctrlStartDate = document.getElementById(ctrlPrefix + "StartDateTextBox");
        var ctrlEndDate = document.getElementById(ctrlPrefix + "EndDateTextBox");
        
        if (((ctrlStartDate.value == "") && (ctrlEndDate.value == "")) || 
            ((ctrlStartDate.value != "") && (ctrlEndDate.value != ""))) {
            return true;
        } else {
            return false;
        }
	}
	
	function StartDateValidate(source, arguments)
	{
	    if (IsRangeValid()) {
	        arguments.IsValid = true;
	    } else {
	        var ctrlDate = document.getElementById(ctrlPrefix + "EndDateTextBox");
	        
	        if (ctrlDate.value == "") {
	            arguments.IsValid = false;
	        } else {
	            arguments.IsValid = true;
	        }
	    }
	}
	
	function EndDateValidate(source, arguments)
	{
	    if (IsRangeValid()) {
	        arguments.IsValid = true;
	    } else {
	        var ctrlDate = document.getElementById(ctrlPrefix + "StartDateTextBox");
	        
	        if (ctrlDate.value == "") {
	            arguments.IsValid = false;
	        } else {
	            arguments.IsValid = true;
	        }
	    }
	}
	
	function LaunchReport()
	{
	    var bValid = false;
	    
	    WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions('ctl00$ctl00$ContentPlaceHolder1$ContentPlaceHolder1$LaunchButton', '', true, '', '', false, false));
	    bValid = ValidatorCommonOnSubmit();
	    
	    if (bValid) {
	        var agentIdField = document.getElementById(ctrlPrefix + "AgentIdHiddenField");
	        var agentId = 0;
	        
	        if (agentIdField.value == "") {
	            var agentNameDropDownList = document.getElementById(ctrlPrefix + "AgentNameDropDownList");
	            agentId = agentNameDropDownList.options[agentNameDropDownList.selectedIndex].value;
	        } else {
	            agentId = agentIdField.value;
	        }
	        
	        var reportTypeDropDownList = document.getElementById(ctrlPrefix + "ReportTypeDropDownList");
	        var mailingPlanDropDownList = document.getElementById(ctrlPrefix + "MailingPlanDropDownList");
	        var startDateHiddenField = document.getElementById(ctrlPrefix + "StartDateHiddenField");
	        var endDateHiddenField = document.getElementById(ctrlPrefix + "EndDateHiddenField");
	        
	        var queryString = "?aId=" + agentId +
                "&rType=" + reportTypeDropDownList.options[reportTypeDropDownList.selectedIndex].value +
                "&mPlan=" + mailingPlanDropDownList.options[mailingPlanDropDownList.selectedIndex].value +
                "&sDate=" + startDateHiddenField.value +
                "&eDate=" + endDateHiddenField.value;
            
            var iWidth = 900;
            var iHeight = 650;
            var iLeft = (screen.width - iWidth) / 2;
            var iTop = ((screen.height - iHeight) / 2) - 20;
            
	        var sFeatures = "toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,";
            var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + "";
	        
            window.open("ScheduleMgmtReport.aspx" + queryString, "ReportViewer", sFeatures + sSize);
        }
        
        return false;
	}
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    Please specify your selection criteria for schedule management report in the below
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
                                        <asp:Panel ID="AgentSelectionPanel" runat="server" Visible="false">
                                            <tr>
                                                <td class="t2" nowrap>
                                                    Agent Name:&nbsp;<span class="MandatoryMark">*</span></td>
                                                <td class="t3">
                                                    <asp:DropDownList ID="AgentNameDropDownList" runat="server">
                                                        <asp:ListItem Value="-1">&lt;Select an Agent&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="AgentNameRequiredFieldValidator" ControlToValidate="AgentNameDropDownList"
                                                        Display="None" ErrorMessage="Agent Name is Required." InitialValue="-1" runat="server" />
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td width="20%" class="t2" nowrap>
                                                Report Type:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td width="80%" class="t3">
                                                <asp:DropDownList ID="ReportTypeDropDownList" runat="server">
                                                    <asp:ListItem Value="-1">&lt;Select a Report Type&gt;</asp:ListItem>
                                                    <asp:ListItem Value="F">Future Events</asp:ListItem>
                                                    <asp:ListItem Value="P">Past Events</asp:ListItem>
                                                    <asp:ListItem Value="*">All Events</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReportTypeRequiredFieldValidator" ControlToValidate="ReportTypeDropDownList"
                                                    Display="None" ErrorMessage="Report Type is Required." InitialValue="-1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Mailing Plan:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <asp:DropDownList ID="MailingPlanDropDownList" runat="server">
                                                    <asp:ListItem Value="-1">&lt;Select a Mailing Plan&gt;</asp:ListItem>
                                                    <asp:ListItem Value="A">Active Plans</asp:ListItem>
                                                    <asp:ListItem Value="C">Closed Plans</asp:ListItem>
                                                    <asp:ListItem Value="*">All Plans</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="MailingPlanRequiredFieldValidator" ControlToValidate="MailingPlanDropDownList"
                                                    Display="None" ErrorMessage="Mailing Plan is Required." InitialValue="-1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Start Date:</td>
                                            <td class="t3">
                                                <asp:TextBox ID="StartDateTextBox" runat="server" CssClass="textbox" Width="100"
                                                    MaxLength="10" ReadOnly="true" Text=""></asp:TextBox>&nbsp;<a href="javascript: //"
                                                        onclick="javascript: CalendarPicker('StartDateTextBox', 'StartDateHiddenField')"><img
                                                            src="../images/dtp.gif" width="16" height="16" border="0"></a>
                                                <asp:CustomValidator ID="StartDateCustomValidator" runat="server" ControlToValidate="StartDateTextBox"
                                                    ClientValidationFunction="StartDateValidate" ErrorMessage="End Date is Required."
                                                    Display="None"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                End Date:</td>
                                            <td class="t3">
                                                <asp:TextBox ID="EndDateTextBox" runat="server" CssClass="textbox" Width="100" MaxLength="10"
                                                    ReadOnly="true" Text=""></asp:TextBox>&nbsp;<a href="javascript: //" onclick="javascript: CalendarPicker('EndDateTextBox', 'EndDateHiddenField')"><img
                                                        src="../images/dtp.gif" width="16" height="16" border="0"></a>
                                                <asp:CustomValidator ID="EndDateCustomValidator" runat="server" ControlToValidate="EndDateTextBox"
                                                    ClientValidationFunction="EndDateValidate" ErrorMessage="Start Date is Required."
                                                    Display="None"></asp:CustomValidator>
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
                    <asp:HiddenField ID="AgentIdHiddenField" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

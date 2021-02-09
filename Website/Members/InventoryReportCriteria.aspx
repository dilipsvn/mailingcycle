<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="InventoryReportCriteria.aspx.cs" Inherits="InventoryReportCriteria" Title="Inventory Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Billing History Report
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../Include/datetimepicker.js"></script>
    <script language="javascript">
	function CalendarPicker(ctrl)
	{
	    var textBox = ctrl;//"ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_StartDateTextBox,ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_StartDateHiddenField";
	    
	    var iWidth = 160;
        var iHeight = 160;
        var iLeft = window.event.clientX;
        var iTop = window.event.clientY;
        
	    var sFeatures = "toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
		window.open('DatePicker.aspx?field=' + textBox,'CalendarPicker',sFeatures + sSize);
	}
    </script>
    <script language="javascript">
        function OpenReport()
            {
                var w = 800;
                var h = 600;
                
                var left = (screen.width - w) / 2;
                var top = (screen.height - h) / 2;
                
                window.location.href = "rpt_BillingHistory.aspx";
            }    
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Inventory Report Criteria
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
            <tr><td><asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please correct the below errors:" /></td></tr>
            <tr><td><asp:Label id="ErrorLiteral" runat="server" CssClass="errormessage"></asp:Label></td>
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
                                                <img src="../../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2">Report Type:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="ReportTypeDropDownList" runat="server" OnSelectedIndexChanged="ShowDateRange" AutoPostBack="true">
                                                    <asp:ListItem Value="0">&lt;Select a Report Type&gt;</asp:ListItem>
                                                    <asp:ListItem Value="1">Month-to-Date</asp:ListItem>
                                                    <asp:ListItem Value="2">Year-to-Date</asp:ListItem>
                                                    <asp:ListItem Value="3">Date Range</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator display="none" ID="ReportTypeRFValidator" runat="server" ControlToValidate="ReportTypeDropDownList" InitialValue="0" ErrorMessage="Please select a report type"></asp:RequiredFieldValidator>
                                                
                                            </td>
                                        </tr>
                                        <asp:Panel ID="DateRangePanel" runat="server" Visible="true">
                                            <tr>
                                                <td class="t2">Start Date:</td>
                                                <td class="t3">
                                                     <asp:TextBox ID="StartDateTextBox" runat="server" CssClass="textbox" Width="100"
                                                    MaxLength="10" ReadOnly="true" Text=""></asp:TextBox>&nbsp;<a href="javascript: //" runat="server" id="StartDateLink"
                                                        ><img src="../images/dtp.gif" width="16"
                                                            height="16" border="0"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="t2">End Date:</td>
                                                <td class="t3">
                                                    <asp:TextBox ID="EndDateTextBox" runat="server" CssClass="textbox" Width="100"
                                                    MaxLength="10" ReadOnly="true" Text=""></asp:TextBox>&nbsp;<a href="javascript: //" runat="server" id="EndDateLink"
                                                        ><img src="../images/dtp.gif" width="16"
                                                            height="16" border="0"></a>
                                                        <asp:CompareValidator ID="DateCompareValidator" runat="server" controltovalidate="EndDateTextBox" ControlToCompare="StartDateTextBox" Operator=GreaterThan Type=Date ErrorMessage="Please enter end date greater than start date" Display="None"></asp:CompareValidator></td>                                                        
                                            </tr>
                                        </asp:Panel>
                                    </table> 
                                </fieldset> 
                            </td> 
                        </tr> 
                    </table> 
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <img src="../../Images/spacer.gif" width="1" height="8" /></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button cssclass="buttonfont" Text="Launch" style="width: 100px" ID="LaunchButton" runat="server"  onclick="LaunchButton_Click"/>
                                <img src="../../Images/spacer.gif" width="10px" height="1" />
                                <input class="buttonfont" type="reset" value="Clear All" style="width: 100px"/>
                            </td>
                        </tr>                    
                    </table> 
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>



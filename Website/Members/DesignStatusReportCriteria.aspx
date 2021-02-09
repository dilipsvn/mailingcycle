<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="DesignStatusReportCriteria.aspx.cs" Inherits="Members_DesignStatusReportCriteria"
    Title="Mailing Cycle Design Status Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Design Status Report
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    var ctrlPrefix = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_";
    
	function LaunchReport()
	{
        var agentList = document.getElementById(ctrlPrefix + "AgentDropDownList");
        var categoryList = document.getElementById(ctrlPrefix + "CategoryDropDownList");
        var statusList = document.getElementById(ctrlPrefix + "StatusDropDownList");
        
        var queryString = "?aId=" + agentList.options[agentList.selectedIndex].value +
            "&cId=" + categoryList.options[categoryList.selectedIndex].value +
            "&sId=" + statusList.options[statusList.selectedIndex].value;
        
        var iWidth = 900;
        var iHeight = 650;
        var iLeft = (screen.width - iWidth) / 2;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + "";
        
        window.open("DesignStatusReport.aspx" + queryString, "ReportViewer", sFeatures + sSize);
        
        return false;
	}
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    Please specify your selection criteria for design status report in the below
                    form.</td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../../images/transparent.gif" width="1" height="1" />
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
                                                Category:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="CategoryDropDownList" runat="server">
                                                    <asp:ListItem Value="0">&lt;All Categories&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Status:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="StatusDropDownList" runat="server">
                                                    <asp:ListItem Value="0">&lt;All Statuses&gt;</asp:ListItem>
                                                </asp:DropDownList>
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
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

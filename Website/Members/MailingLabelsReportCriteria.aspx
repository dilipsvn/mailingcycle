<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="MailingLabelsReportCriteria.aspx.cs" Inherits="Members_MailingLabelsReportCriteria"
    Title="Mailing Cycle Mailing Labels Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Mailing Labels Report
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    var ctrlPrefix = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_";
    
	function LaunchReport()
	{
	    var bValid = false;
	    
	    WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions('ctl00$ctl00$ContentPlaceHolder1$ContentPlaceHolder1$LaunchButton', '', true, '', '', false, false));
	    bValid = ValidatorCommonOnSubmit();
	    
	    if (bValid) {
            var agentList = document.getElementById(ctrlPrefix + "AgentDropDownList");
            var farmList = document.getElementById(ctrlPrefix + "FarmDropDownList");
            var plotList = document.getElementById(ctrlPrefix + "PlotDropDownList");
            
            var queryString = "?aId=" + agentList.options[agentList.selectedIndex].value +
                "&fId=" + farmList.options[farmList.selectedIndex].value +
                "&pId=" + plotList.options[plotList.selectedIndex].value;
            
            var iWidth = 900;
            var iHeight = 650;
            var iLeft = (screen.width - iWidth) / 2;
            var iTop = ((screen.height - iHeight) / 2) - 20;
            
            var sFeatures = "toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,";
            var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + "";
            
            window.open("MailingLabelsReport.aspx" + queryString, "ReportViewer", sFeatures + sSize);
        }
        
        return false;
	}
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    Please specify your selection criteria for mailing labels report in the below form.</td>
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
                                                Agent:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td width="80%" class="t3">
                                                <asp:DropDownList ID="AgentDropDownList" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="Agent_Changed">
                                                    <asp:ListItem Value="0">&lt;Select an Agent&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="AgentRequiredFieldValidator" ControlToValidate="AgentDropDownList"
                                                    Display="None" ErrorMessage="Agent is Required." InitialValue="0" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Farm:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="FarmDropDownList" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="Farm_Changed">
                                                    <asp:ListItem Value="0">&lt;All Farms&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Plot:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="PlotDropDownList" runat="server">
                                                    <asp:ListItem Value="0">&lt;All Plots&gt;</asp:ListItem>
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

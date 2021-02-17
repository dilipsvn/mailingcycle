<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="FirmUpStatus.aspx.cs" Inherits="Members_FirmUpStatus" Title="Mailing Cycle Firm-Up Status Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <script type="text/javascript">
            <!--
            function doReport()
            {
                firmedUp = "Firmed Up";
                userId = "0";
                
                var allSelectTags = document.getElementsByTagName("select");
                for(i = 0; i < allSelectTags.length; i++)
                {
                    if(allSelectTags[i].name.indexOf("AgentListDropDownList") >= 0)
                        userId = allSelectTags[i].options[allSelectTags[i].selectedIndex].value;
                    
                    if(allSelectTags[i].name.indexOf("FarmStatusDropDownList") >= 0)   
                        firmedUp = allSelectTags[i].options[allSelectTags[i].selectedIndex].value;
                }
                URL = 'FirmUpStatusReport.aspx?UserId=' + userId +  '&FirmUpStatus=' + firmedUp;
                openPopupWindow(URL,640,820);
            }
            //-->
        </script>
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Farm Status Report Criteria
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="AgentListPanel" runat="server" Height="60px" Width="100%" Visible="false">
                        <fieldset>
                            <legend class="LegendText">Agent List</legend>
                            <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                                <tr>
                                    <td width="24%">
                                        <asp:Label ID="AgentListLabel" runat="server" Text="Select an Agent" AssociatedControlID="AgentListDropDownList"></asp:Label></td>
                                    <td width="24%">
                                        <asp:DropDownList ID="AgentListDropDownList" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="15%">
                                        &nbsp;
                                    </td>
                                    <td width="35%">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="24%">&nbsp;</td>
                                    <td width="24%">
                                        <asp:Label ID="AgentListErrorLiteral" runat="server" cssClass="errormessage"></asp:Label>
                                    </td>
                                    <td width="50%" colspan="2">
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="5" cellspacing="1" width="100%">
                        <tr>
                            <td width="24%">Farm Status :</td>
                            <td width="76%">
                                <asp:DropDownList ID="FarmStatusDropDownList" runat="server">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ReportButton" runat="server" Text="Launch Report" CssClass="buttonfont" Width="80px" OnClientClick="doReport();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


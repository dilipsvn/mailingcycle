<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="FarmDataReportCriteria.aspx.cs" Inherits="Members_FarmDataReportCriteria" Title="Mailing Cycle Farm Data Report Criteria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    <!--
        function doReport()
        {
            var userId = "0";
            var where = "";
            var farmCountCondition = "";
            var farmCountValue1 = "";
            var farmCountValue2 = "";
            var plotCountCondition = "";
            var plotCountValue1 = "";
            var plotCountValue2 = "";
            var contactCountCondition = "";
            var contactCountValue1 = "";
            var contactCountValue2 = "";
            var deletedContactCountCondition = "";
            var deletedContactCountValue1 = "";
            var deletedContactCountValue2 = "";
            var mailingPlanId = "";
            var andsyntax = "";
            
            var allSelectTags = document.getElementsByTagName("select");
            for(i = 0; i < allSelectTags.length; i++)
            {
                if(allSelectTags[i].name.indexOf("FarmCountConditionDropDownList") >= 0)
                    farmCountCondition = allSelectTags[i].options[allSelectTags[i].selectedIndex].value;
                
                if(allSelectTags[i].name.indexOf("PlotCountConditionDropDownList") >= 0)   
                    plotCountCondition = allSelectTags[i].options[allSelectTags[i].selectedIndex].value;
                    
                if(allSelectTags[i].name.indexOf("ContactCountConditionDropDownList") >= 0)
                    contactCountCondition = allSelectTags[i].options[allSelectTags[i].selectedIndex].value; 
                
                if(allSelectTags[i].name.indexOf("DeletedContactsCountConditionDropDownList") >= 0)   
                    deletedContactCountCondition = allSelectTags[i].options[allSelectTags[i].selectedIndex].value;
                    
                if(allSelectTags[i].name.indexOf("MailingPlanDropDownList") >= 0)
                    mailingPlanId = allSelectTags[i].options[allSelectTags[i].selectedIndex].value;
                    
                if(allSelectTags[i].name.indexOf("AgentListDropDownList") >= 0)
                    userId = allSelectTags[i].options[allSelectTags[i].selectedIndex].value;    
            }
            
            var allInputTags = document.getElementsByTagName("input");
            for(i = 0; i < allInputTags.length; i++)
            {
                if(allInputTags[i].type == "text")
                {
                    if(allInputTags[i].name.indexOf("FarmCountValue1TextBox") >= 0)
                        farmCountValue1 = allInputTags[i].value;
                    if(allInputTags[i].name.indexOf("FarmCountValue2TextBox") >= 0)
                        farmCountValue2 = allInputTags[i].value;
                    
                    if(allInputTags[i].name.indexOf("PlotCountValue1TextBox") >= 0)
                        plotCountValue1 = allInputTags[i].value;
                    if(allInputTags[i].name.indexOf("PlotCountValue2TextBox") >= 0)
                        plotCountValue2 = allInputTags[i].value;
                        
                    if(allInputTags[i].name.indexOf("ContactCountValue1TextBox") >= 0)
                        contactCountValue1 = allInputTags[i].value;
                    if(allInputTags[i].name.indexOf("ContactCountValue2TextBox") >= 0)
                        contactCountValue2 = allInputTags[i].value;
                        
                    if(allInputTags[i].name.indexOf("DeletedContactsCountValue1TextBox") >= 0)
                        deletedContactCountValue1 = allInputTags[i].value;
                    if(allInputTags[i].name.indexOf("DeletedContactsCountValue2TextBox") >= 0)
                        deletedContactCountValue2 = allInputTags[i].value;
                }
            }
            
            if(farmCountValue1 != "")
            {
                if(farmCountCondition == "Between")
                {
                    if (farmCountValue2 != "")
                        where = where + "FarmCount Between " + farmCountValue1 + " AND " + farmCountValue2;
                }
                else if(farmCountCondition == "gt")
                    where = where + "FarmCount > " + farmCountValue1;
                else if(farmCountCondition == "gte")
                    where = where + "FarmCount >= " +  farmCountValue1;
                else if(farmCountCondition == "eq")
                    where = where + "FarmCount = " +  farmCountValue1;
                else if(farmCountCondition == "lt")
                    where = where + "FarmCount < " + farmCountValue1;
                else if(farmCountCondition == "lte")
                    where = where + "FarmCount <= " +  farmCountValue1;
            }
            
            if(where.length > 0)
                andsyntax = " AND ";
            else
                andsyntax = "";
                
            if(plotCountValue1 != "")
            {
                if(plotCountCondition == "Between")
                {
                    if (plotCountValue2 != "")
                        where = where + andsyntax + "PlotCount Between " + plotCountValue1 + " AND " + plotCountValue2;
                }
                else if(plotCountCondition == "gt")
                    where = where + andsyntax + "PlotCount > " + plotCountValue1;
                else if(plotCountCondition == "gte")
                    where = where + andsyntax + "PlotCount >= " +  plotCountValue1;
                else if(plotCountCondition == "eq")
                    where = where + andsyntax + "PlotCount = " +  plotCountValue1;
                else if(plotCountCondition == "lt")
                    where = where + andsyntax + "PlotCount < " + plotCountValue1;
                else if(plotCountCondition == "lte")
                    where = where + andsyntax + "PlotCount <= " +  plotCountValue1;
            } 
            
            if(where.length > 0)
                andsyntax = " AND ";
            else
                andsyntax = "";
                
            if(contactCountValue1 != "")
            {
                if(contactCountCondition == "Between")
                {
                    if (contactCountValue2 != "")
                        where = where + andsyntax + "ContactCount Between " + contactCountValue1 + " AND " + contactCountValue2;
                }
                else if(contactCountCondition == "gt")
                    where = where + andsyntax + "ContactCount > " + contactCountValue1;
                else if(contactCountCondition == "gte")
                    where = where + andsyntax + "ContactCount >= " +  contactCountValue1;
                else if(contactCountCondition == "eq")
                    where = where + andsyntax + "ContactCount = " +  contactCountValue1;
                else if(contactCountCondition == "lt")
                    where = where + andsyntax + "ContactCount < " + contactCountValue1;
                else if(contactCountCondition == "lte")
                    where = where + andsyntax + "ContactCount <= " +  contactCountValue1;
            }
            
            if(where.length > 0)
                andsyntax = " AND ";
            else
                andsyntax = "";
            
            if(deletedContactCountValue1 != "")
            {
                if(deletedContactCountCondition == "Between")
                {
                    if (deletedContactCountValue2 != "")
                        where = where + andsyntax + "DeletedContactCount Between " + deletedContactCountValue1 + " AND " + deletedContactCountValue2;
                }
                else if(deletedContactCountCondition == "gt")
                    where = where + andsyntax + "DeletedContactCount > " + deletedContactCountValue1;
                else if(deletedContactCountCondition == "gte")
                    where = where + andsyntax + "DeletedContactCount >= " +  deletedContactCountValue1;
                else if(deletedContactCountCondition == "eq")
                    where = where + andsyntax + "DeletedContactCount = " +  deletedContactCountValue1;
                else if(deletedContactCountCondition == "lt")
                    where = where + andsyntax + "DeletedContactCount < " + deletedContactCountValue1;
                else if(deletedContactCountCondition == "lte")
                    where = where + andsyntax + "DeletedContactCount <= " +  deletedContactCountValue1;
            }
            
            if(where.length > 0)
                andsyntax = " AND ";
            else
                andsyntax = "";
                
            if(mailingPlanId != "0")
            {
                where = where + andsyntax + "PlanId = " + mailingPlanId;
            }
                  
            //alert(where);
            
            URL = 'FarmDataReport.aspx?UserId=' + userId +  '&where=' + where;
            openPopupWindow(URL,640,820);
        }
    //-->
    </script>
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Farm Data Report Criteria
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
                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                        <tr>
                            <td style="width: 15%;">
                                <asp:Label ID="FarmCountLabel" runat="server" Text="Farm Count" AssociatedControlID="FarmCountConditionDropDownList"></asp:Label></td>
                            <td style="width: 35%;">
                                <asp:DropDownList ID="FarmCountConditionDropDownList" runat="server">
                                </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="FarmCountValue1TextBox" runat="server" Width="40px"></asp:TextBox> &lt; &gt;
                                <asp:TextBox ID="FarmCountValue2TextBox" runat="server" Width="40px"></asp:TextBox>
                            </td>
                            <td style="width: 15%;">
                                <asp:Label ID="MailingPlanLabel" runat="server" Text="Mailing Plan" AssociatedControlID="MailingPlanDropDownList"></asp:Label></td>
                            <td style="width: 35%;">
                                <asp:DropDownList ID="MailingPlanDropDownList" runat="server">
                                </asp:DropDownList>
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="PlotCountLabel" runat="server" Text="Plot Count" AssociatedControlID="PlotCountConditionDropDownList"></asp:Label></td>
                            <td><asp:DropDownList ID="PlotCountConditionDropDownList" runat="server">
                                </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="PlotCountValue1TextBox" runat="server" Width="40px"></asp:TextBox> &lt; &gt;
                                <asp:TextBox ID="PlotCountValue2TextBox" runat="server" Width="40px"></asp:TextBox>
                            </td>
                            <td><!-- Date Created --></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ContactCountLabel" runat="server" Text="Contact Count" AssociatedControlID="ContactCountConditionDropDownList"></asp:Label></td>
                            <td><asp:DropDownList ID="ContactCountConditionDropDownList" runat="server">
                                </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="ContactCountValue1TextBox" runat="server" Width="40px"></asp:TextBox> &lt; &gt;
                                <asp:TextBox ID="ContactCountValue2TextBox" runat="server" Width="40px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="DeletedContactsCountLabel" runat="server" Text="Deleted Contacts" AssociatedControlID="DeletedContactsCountConditionDropDownList"></asp:Label></td>
                            <td><asp:DropDownList ID="DeletedContactsCountConditionDropDownList" runat="server">
                                </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="DeletedContactsCountValue1TextBox" runat="server" Width="40px"></asp:TextBox> &lt; &gt;
                                <asp:TextBox ID="DeletedContactsCountValue2TextBox" runat="server" Width="40px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center;">
                                <asp:Button ID="ReportButton" runat="server" Text="Launch Report" CssClass="buttonfont" Width="100px" OnClientClick="doReport();" /></td>
                        </tr>
                        <tr>
                            <td colspan="4">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


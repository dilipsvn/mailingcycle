<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ArchivedFarmList.aspx.cs" Inherits="Members_ArchivedFarmList" Title="Archived Farm List" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
Archived Farm List
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    function deleteItem(msg)
    {
        confirm(msg);
    }
    
    function checkFarmRestore()
    {
        //Check atleast one farm is selected
         var allInputTags = document.getElementsByTagName("input");
         var selected = false;
         for(i = 0; i < allInputTags.length; i++)
         {
            if(allInputTags[i].type == "checkbox")
                if(allInputTags[i].checked)
                    selected = true;
         }
         if(!selected)
         {
            alert("Select atleast one Farm to Restore!");
            return false;
         }
         return confirm("Are you sure you want to restore the Farm/s");
    }
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Manage your Archived farms
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
                                        <asp:Button ID="SelectedAgentButton" runat="server" Text="Go" OnClick="SelectedAgentButton_Click" />
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
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td align="right">
                                <asp:hyperlink ID="ActiveFarmHyperLink" runat="server" NavigateUrl="~/Members/FarmManagement.aspx" >[Active Farm Data]</asp:hyperlink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">List of Archived Farms</legend>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:button ID="RestoreFarmButton" runat="server" text="Restore Farm" CssClass="buttonfont" Width="80px" OnClick="RestoreFarmButton_Click" OnClientClick="javascript: return checkFarmRestore();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/transparent.gif" width="1" height="4" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:literal ID="MessageLiteral" runat="server"></asp:literal>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="FarmGridView" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" AllowPaging="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" ">
                                                <ItemTemplate>
                                                    <asp:CheckBox id="FarmIdCheckBox" runat="server" Value='<%#Eval("FarmId")%>' ToolTip='<%#Eval("FarmId")%>'></asp:CheckBox>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Farm Name">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="FarmNameHyperLink" runat="server" Text='<%#Eval("FarmName")%>' NavigateUrl='<%# Eval("FarmId","~/Members/ArchivedPlotList.aspx?farmId={0}") %>'></asp:HyperLink>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Created On">
                                                <ItemTemplate>
                                                    <asp:Label ID="FarmCreateDateLabel" Text='<%# Eval("CreateDate", "{0:MM/dd/yyyy}")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mailing Plan">
                                                <ItemTemplate>
                                                    <asp:Label ID="MailingPlanLabel" Text='<%#Eval("mailingPlan.title")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Plot Count">
                                                <ItemTemplate>
                                                    <asp:Label ID="PlotCountLabel" Text='<%#Eval("PlotCount")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="align-right" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Count">
                                                <ItemTemplate>
                                                    <asp:Label ID="ContactCountLabel" Text='<%#Eval("ContactCount")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="align-right" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Farm Delete">
                                                <ItemTemplate>
                                                    <asp:Label ID="DeletedLabel" Text='<%#Eval("Deleted")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Panel ID="NoFarmDataPanel" runat="server" Height="60px" Width="100%" Visible="false">
                                    <table border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse">
                                        <thead>
                                            <tr>
                                                <th bgcolor="#e4e4e4" height="20px">&nbsp;&nbsp;</th>
                                                <th bgcolor="#e4e4e4" height="20px">Farm Name</th>
                                                <th bgcolor="#e4e4e4" height="20px">Farm Name</th>
                                                <th bgcolor="#e4e4e4" height="20px">Created on</th>
                                                <th bgcolor="#e4e4e4" height="20px">Mailing Plan</th>
                                                <th bgcolor="#e4e4e4" height="20px">Plot Count</th>
                                                <th bgcolor="#e4e4e4" height="20px">Contact Count</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td colspan="7" style="font-style:italic; text-align:center;">
                                                    No records to display.....
                                                </td>
                                            </tr>
                                        </tbody>
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
           
            <tr>
                <td height="50">
                </td>
            </tr>
            <tr>
                <td style="background-color: #c9cacd">
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            
            <tr>
                <td>
                    <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                            <td class="Notes">
                               Deleted farms/Plots/Contacts will remain in archive for 2 weeks from the deleted date. After 2 weeks it will automatically delete from the system.
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
        </table>
    </div>
</asp:Content>

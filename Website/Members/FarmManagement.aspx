<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="FarmManagement.aspx.cs" Inherits="FarmManagement" Title="Mailing Cycle Farm Management" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Farm Management
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    function deleteItem(msg)
    {
        confirm(msg);
    }
    
    function checkFarmDeletion()
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
            alert("Select atleast one Farm to Delete !");
            return false;
         }
         return confirm("Are you sure you want to delete the Farm/s");
    }
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Manage your farms
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
                    <asp:panel id="AgentListPanel" runat="server" height="60px" width="100%" visible="false">
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
                    </asp:panel>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td align="right">
                                <asp:hyperlink id="ArchivedFarmHyperLink" runat="server" navigateurl="~/Members/ArchivedFarmList.aspx">[Archived Farm Data]</asp:hyperlink>
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
                                    <legend class="LegendText">List of Farms</legend>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:literal id="ErrorLiteral" runat="server"></asp:literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:button id="CreateFarmButton" runat="server" text="Add Farm" cssclass="buttonfont"
                                                    width="80px" onclick="CreateFarmButton_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/transparent.gif" width="1" height="4" /></td>
                                        </tr>
                                    </table>
                                    <asp:GridView id="FarmGridView" runat="server" autogeneratecolumns="false" gridlines="Both"
                                        width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="FarmGridView_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" ">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="EditHyperLink" runat="server" ImageUrl="~/Images/edit_icon.gif" NavigateUrl='<%# Eval("FarmId","~/Members/ModifyFarm.aspx?farmId={0}&Page=FarmManagement.aspx") %>' />
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Farm Name">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="FarmNameHyperLink" runat="server" Text='<%#Eval("FarmName")%>' NavigateUrl='<%# Eval("FarmId","~/Members/ViewFarm.aspx?farmId={0}") %>'></asp:HyperLink>
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
                                            <asp:TemplateField HeaderText="Firm Up">
                                                <ItemTemplate>
                                                    <asp:Label ID="FirmUpStatusLabel" Text='<%#Eval("Firmup")%>' runat="server"></asp:Label>
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
                                        </Columns>
                                    </asp:gridview>
                                    <asp:panel id="NoFarmDataPanel" runat="server" height="60px" width="100%" visible="false">
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
                                            <tr style="height: 25px;">
                                                <td colspan="7" style="font-style:italic; text-align:center; color: Red;">
                                                    No Farms to display.....
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:panel>
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
        </table>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ArchivedPlotList.aspx.cs" Inherits="Members_ArchivedPlotList" Title="Archived Plot List" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Archived Plot List
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    function deleteItem(msg)
    {
        confirm(msg);
    }
    function checkPlotRestore()
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
            alert("Select atleast one Plot to Restore!");
            return false;
         }
         return confirm("Are you sure you want to restore the Plot/s");
    }
    
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Manage your archived plots
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="ForAgentPanel" runat="server" Height="40px" Width="100%" Visible="false">
                        <fieldset>
                            <legend class="LegendText">For Agent</legend>
                            <table border="0" cellspacing="2" cellpadding="1">
                                <tr>
                                    <td>Agent User Name:</td>
                                    <td>
                                        <asp:Label ID="ForAgentUserNameLabel" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="ForAgentUserIdHiddenField" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                        <tr>
                            <td align="right">
                                    <asp:Label ID="ErrorLiteral" runat="server" cssClass="MessageText"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
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
                                    <legend class="LegendText">Farm Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2">
                                                Name:
                                            </td>
                                            <td width="80%" class="t3">
                                                <asp:Label ID="FarmNameLabel" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="FarmIdHiddenField" runat="server" />
                                                <asp:HiddenField ID="UserIdHiddenField" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Contact Count:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="FarmContactCountLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Mailing Plan:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="MailingPlanLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Created On:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="CreateDateLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Plot Count:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="PlotCountLabel" runat="server" Text=""></asp:Label>
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
                    <img src="../Images/spacer.gif" width="1" height="8" /><br />
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Archived List of Plots</legend>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td align="right" style="height: 24px">
                                                <asp:button ID="RestorePlotButton" runat="server" text="Restore Plot" CssClass="buttonfont" Width="80px" OnClick="RestorePlotButton_Click" OnClientClick="javascript: return checkPlotRestore();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/transparent.gif" width="1" height="4" /></td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="PlotListGridView" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" AllowPaging="true" PageSize="20">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" ">
                                                <ItemTemplate>
                                                    <asp:CheckBox id="PlotIdCheckBox" runat="server" Value='<%#Eval("PlotId")%>' ToolTip='<%#Eval("PlotId")%>'></asp:CheckBox>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="smalltype2" />
                                                <HeaderStyle BackColor="#e4e4e4" CssClass="boldtxt" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Plot Name">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="FarmNameHyperLink" runat="server" Text='<%#Eval("PlotName")%>' NavigateUrl='<%# Eval("PlotId","~/Members/ArchivedContactList.aspx?plotId={0}") %>'></asp:HyperLink>
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
                                            <asp:TemplateField HeaderText="Contact Count">
                                                <ItemTemplate>
                                                    <asp:Label ID="ContactCountLabel" Text='<%#Eval("ContactCount")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" CssClass="align-right" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Plot Deleted">
                                                <ItemTemplate>
                                                    <asp:Label ID="DeletedLabel" Text='<%#Eval("Deleted")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#FFFFFF" />
                                                <HeaderStyle BackColor="#e4e4e4" Height="25px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
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
                    <input class="buttonfont" type="button" value="Back" style="width: 80px" onclick="javascript:location.href='ArchivedFarmList.aspx'" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

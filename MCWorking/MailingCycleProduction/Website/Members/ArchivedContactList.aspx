<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ArchivedContactList.aspx.cs" Inherits="Members_ArchivedContactList" Title="Archived Contact List" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Archived Contact List
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    function checkContactRestore()
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
            alert("Select atleast one Contact to Restore!");
            return false;
         }
         return confirm("Are you sure you want to restore these Contact/s");
    }
    
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Manage your archived contacts
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
                                    <asp:Label ID="MessageLiteral" runat="server" cssClass="MessageText"></asp:Label>
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
                                    <legend class="LegendText">Plot Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2">
                                                Plot Name:
                                            </td>
                                            <td width="80%" class="t3">
                                                <asp:label id="PlotNameLabel" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Contact Count:
                                            </td>
                                            <td class="t3">
                                                <asp:label id="ContactCountLabel" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Created On:
                                            </td>
                                            <td class="t3">
                                                <asp:label id="CreateDateLabel" runat="server" text=""></asp:label>
                                                <asp:HiddenField ID="PlotIdHiddenField" runat="server" />&nbsp;<asp:HiddenField ID="FarmIdHiddenField" runat="server" />
                                                <asp:HiddenField ID="UserIdHiddenField" runat="server" />
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
                                    <legend class="LegendText">List of Archived Contacts</legend>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td align="right" style="height: 24px">
                                                <asp:button ID="RestoreContactButton" runat="server" text="Restore Contact" CssClass="buttonfont" Width="100px" OnClick="RestoreContactButton_Click" OnClientClick="javascript: return checkContactRestore();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/transparent.gif" width="1" height="4" /></td>
                                        </tr>
                                    </table>
                                            <div style="border-collapse: collapse;width:100%">

                                            <asp:GridView ID="ContactListGridView" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" PageSize="20" OnPageIndexChanging="ContactListGridView_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText=" " HeaderStyle-Width="4%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ContactIdCheckBox" Value='<%#Eval("ContactId")%>' ToolTip='<%#Eval("ContactId")%>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Schedule #" HeaderStyle-Width="12%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="ScheduleNumberLabel" Text='<%#Eval("ScheduleNumber")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name" HeaderStyle-Width="26%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="OwnerFullNameHyperLink" Text='<%#Eval("OwnerFullName")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Lot" HeaderStyle-Width="6%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LotNumberLabel" Text='<%#Eval("Lot")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Block" HeaderStyle-Width="6%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="BlockLabel" Text='<%#Eval("Block")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Filing" HeaderStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="FilingLabel" Text='<%#Eval("Filing")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="City" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="OwnerCityLabel" Text='<%#Eval("OwnerCity")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="State" HeaderStyle-Width="6%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="OwnerStateLabel" Text='<%#Eval("OwnerState")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Zip" HeaderStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="OwnerZipLabel" Text='<%#Eval("OwnerZip")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            </div> 
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
                <td align="center" style="height: 24px">
                    <asp:Button ID="BackButton" runat="server" Text="Back" Width="80px" CssClass="buttonfont" OnClick="BackButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

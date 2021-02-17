<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="SearchFarmDataResults.aspx.cs" Inherits="SearchFarmDataResults" Title="Mailing Cycle Farm Data Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Farm Data Results
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript">
    function CheckboxSelected() 
    {
        var CheckStatus=false;
        var allInputTags = document.getElementsByTagName("input");
        
        for(i = 0; i < allInputTags.length; i++)
        {
             if(allInputTags[i].type == "checkbox")
                if(allInputTags[i].checked)
                    CheckStatus = true;
        }
        
        if(CheckStatus)
        {
            return confirm("Are you sure you want to delete these selected contacts?");
        }
        else
        {
            alert("Please Select atleast One Contact Checkbox to delete");
            return CheckStatus;
        }
    }
</script>
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%">Farm data results - 10 contacts found</td>
                            <td width="40%" align="right">
                                <asp:Literal ID="ForAgentLiteral" runat="server"></asp:Literal>
                                <asp:HiddenField ID="ForAgentUserIdHiddenField" runat="server" />
                                <asp:HiddenField ID="PlotIdHiddenField" runat="server" />&nbsp;<asp:HiddenField ID="FarmIdHiddenField" runat="server" />
                                <asp:HiddenField ID="UserIdHiddenField" runat="server" />
                            </td>
                        </tr>
                    </table>
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
                                    <legend class="LegendText">Search Results</legend>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td align="right" style="height: 24px">
                                                    <asp:Button ID="DeleteContactButton" runat="server" Text="Delete" Width="80px" CssClass="buttonfont" OnClick="DeleteContactButton_Click" OnClientClick="javascript: return CheckboxSelected();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="../images/transparent.gif" width="1" height="4" /></td>
                                            </tr>
                                        </table>
                                            <div style="border-collapse: collapse;width:100%">

                                            <asp:GridView ID="ContactListGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20" OnPageIndexChanging="ContactListGridView_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="  " HeaderStyle-Width="4%">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="EditContactHyperLink" runat="server" ImageUrl="~/Images/edit_icon.gif" NavigateUrl='<%# Eval("ContactId","~/Members/ModifyContact.aspx?contactId={0}") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" " HeaderStyle-Width="4%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ContactIdCheckBox" Value='<%#Eval("ContactId")%>' ToolTip='<%#Eval("ContactId")%>' runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Farm" HeaderStyle-Width="12%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="FarmLabel" Text='Farm' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Plot" HeaderStyle-Width="12%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="PlotLabel" Text='Plot' runat="server"></asp:Label>
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
                                                            <asp:HyperLink ID="OwnerFullNameHyperLink" runat="server" NavigateUrl='<%#Eval("ContactId","~/Members/ViewContact.aspx?contactId={0}") %>' Text='<%#Eval("OwnerFullName")%>'></asp:HyperLink>
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
                <td align="center">
                    <input class="buttonfont" type="button" value="Back" style="width: 80px" onclick="javascript: document.location.href='SearchFarmData.aspx'" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


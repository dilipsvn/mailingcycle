<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="SearchUsers.aspx.cs" Inherits="SearchUsers" Title="Mailing Cycle User Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
User Management
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <asp:Literal ID="ResultCountLiteral" runat="server"></asp:Literal>
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
            <tr><td><asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please correct the below errors:" /></td></tr>
            <tr><td><asp:Label id="ErrorLiteral" runat="server" CssClass="errormessage"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Panel id="SearchCriteriaPanel" runat="server">
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Search Criteria</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2">User Role: </td>
                                            <td class="t3">
                                                <asp:DropDownList ID="RoleDropDownList" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">First Name:</td>
                                            <td class="t3">
                                                <asp:TextBox ID="FirstNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">Last Name:</td>
                                            <td class="t3">
                                                <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">User Name:</td>
                                            <td class="t3">
                                                <asp:TextBox ID="UserNameTextBox" runat="server" MaxLength="50" Width="150px" CausesValidation="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table> 
                                </fieldset> 
                            </td> 
                        </tr> 
                    </table> 
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <img src="../Images/spacer.gif" width="1" height="8" /></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button runat="server" cssclass="buttonfont" text="Search Users" style="width: 100px" ID="SearchButton" onClick="SearchUsers_Click"/>
                                <img src="../Images/spacer.gif" width="10px" height="1" />
                                <input class="buttonfont" type="reset" value="Clear All" style="width: 100px"/>
                            </td>
                        </tr>                    
                    </table> 

                    </asp:Panel>
                    <asp:Panel id="SearchResultsPanel" runat="server" visible="false">
                                            <fieldset>
                            <legend class="LegendText">Search Result</legend>
                            <br /><br />
                            <asp:GridView ID="SearchUsersResultGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20" OnRowDataBound="SetPermissions" OnPageIndexChanging="SearchUsersResultGridView_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="   ">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="EditUserHyperLink" runat="server" ImageUrl="~/Images/edit_icon.gif" NavigateUrl='<%# Eval("UserId","~/Members/ModifyUser.aspx?UserId={0}&PageName=SearchUsers.aspx") %>' />
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="UserNameHyperLink" runat="server" Text='<%#Eval("UserName")%>' NavigateUrl='<%# Eval("UserId","~/Members/ViewUser.aspx?UserId={0}&SearchPageName=SearchUsers.aspx") %>'></asp:HyperLink>
                                            <asp:Label ID="UserNameLabel" Text='<%#Eval("UserName")%>' runat="server" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="12%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name">
                                        <ItemTemplate>
                                            <asp:Label ID="FirstNameLabel" Text='<%#Eval("FirstName")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label ID="LastNameLabel" Text='<%#Eval("LastName")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="CityLabel" Text='<%#Eval("Address.City")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State">
                                        <ItemTemplate>
                                            <asp:Label ID="StateLabel" Text='<%#Eval("Address.State.Name")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Zip">
                                        <ItemTemplate>
                                            <asp:Label ID="ZipLabel" Text='<%#Eval("Address.Zip")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Role">
                                        <ItemTemplate>
                                            <asp:Label ID="RoleLabel" Text='<%#Eval("role")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="StatusLabel" Text='<%#Eval("Status")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="16%" />
                                    </asp:TemplateField>
                                    
                                    
                                    
                                    
                                    
                                </Columns>
                            </asp:GridView>
                        </fieldset>
                        <br />
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Button id="BackButton" runat="server" text="Back" cssClass="buttonfont" onClick="BackToSearchPanel_Click" width="80px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel> 
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


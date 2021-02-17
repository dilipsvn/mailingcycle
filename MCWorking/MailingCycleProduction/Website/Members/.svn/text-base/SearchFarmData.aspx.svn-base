<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="SearchFarmData.aspx.cs" Inherits="Members_SearchFarmData" Title="Search Farm Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Search Farm Data
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    
    //Check Vlidation (atleast one contact to be checked)
    function CheckboxSelected() 
    {
        var CheckStatus=false;
        var allInputTags = document.getElementsByTagName("input");
        var contactIdHiddenField;
        
        //Get Contact Id Hidden Field
        for(i = 0; i < allInputTags.length; i++)
            if(allInputTags[i].type == "hidden")
                if(allInputTags[i].name.indexOf("DeleteContactIdHiddenField") > 0)
                    contactIdHiddenField = allInputTags[i];
        
        //Check for checked CheckBox
        for(i = 0; i < allInputTags.length; i++)
        {
             if(allInputTags[i].type == "checkbox")
                if(allInputTags[i].checked)
                {
                    CheckStatus = true;
                    //contactIdHiddenField.value = allInputTags[i].getParentNode().title;
                }
        }
        
        if(!CheckStatus)
        {
            alert("Please Select atleast One Contact Checkbox to delete");
            return false;
        }
        
        return true;
    }
    
    //This is a function to check only one contact at a time
    function onCheckingCheckbox(ccbox)
    {
        var allInputTags = document.getElementsByTagName("input");
        for(i = 0; i < allInputTags.length; i++)
        {
            if(allInputTags[i].type == "checkbox")
                if(allInputTags[i].name != ccbox.name)
                    allInputTags[i].checked = false;
        }
    }
</script>
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%"><asp:Literal ID="ResultCountLiteral" runat="server"></asp:Literal></td>
                            <td width="50%" align="right">
                                <asp:Literal ID="ForAgentLiteral" runat="server"></asp:Literal>
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
                    <asp:HiddenField ID="DeleteMessageHiddenField" runat="server" />
                    <asp:HiddenField ID="DeleteConformationHiddenField" runat="server" />
                    <asp:HiddenField ID="DeleteContactIdHiddenField" runat="server" />
                    <asp:Panel ID="AgentListPanel" runat="server" Height="60px" Width="100%" Visible="false">
                        <fieldset>
                            <legend class="LegendText">Agent List</legend>
                            <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                                <tr>
                                    <td width="20%">
                                        <asp:Label ID="AgentListLabel" runat="server" Text="Select an Agent" AssociatedControlID="AgentListDropDownList"></asp:Label></td>
                                    <td width="30%">
                                        <asp:DropDownList ID="AgentListDropDownList" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="20%">
                                        <asp:Button ID="SelectedAgentButton" runat="server" Text="Go" OnClick="SelectedAgentButton_Click" />
                                    </td>
                                    <td width="30%">
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="SearchCriteriaPane" runat="server" Height="250px" Width="100%" Visible="true">
                        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend class="LegendText">Search Criteria</legend>
                                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                            <tr>
                                                <td colspan="4">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="2" height="1" />&nbsp;<asp:CheckBox ID="ArchivedCheckBox"
                                                        runat="server" Text="Exclude Archived Contact Data" /></td>
                                                <td colspan="2">
                                                    <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td width="18%" class="t2" nowrap>
                                                    <asp:label  id="FarmNameSearchLabel" runat="server" text="Farm:"></asp:Label>                                            
                                                </td> 
                                                <td width="30%" class="t3">
                                                    <asp:DropDownList id="FarmDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FarmDropDownList_SelectedIndexChanged" Width="136px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="18%" class="t2">
                                                    <asp:label  id="PlotNameSearchLabel" runat="server" text="Plot:"></asp:Label>
                                                </td>
                                                <td width="34%" class="t3">
                                                    <asp:DropDownList id="PlotDropDownList" runat="server" Width="144px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="t2" nowrap>
                                                    Schedule #:
                                                </td>
                                                <td class="t3">
                                                    <asp:TextBox ID="ScheduleNumberTextBox" runat="server" MaxLength="6" Width="128px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="ScheduleNumberRegularExpressionValidator" runat="server"
                                                        ControlToValidate="ScheduleNumberTextBox" ErrorMessage="Please Provide a Number"
                                                        ValidationExpression="[1-9][0-9]*" Display="Dynamic"></asp:RegularExpressionValidator></td>
                                                <td class="t2" nowrap>
                                                    Owner Full Name:
                                                </td>
                                                <td class="t3">
                                                    <asp:TextBox ID="OwnerFullNameTextBox" runat="server" MaxLength="100" Width="136px"></asp:TextBox>
                                                </td>
                                            </tr>                                        
                                            <tr>
                                                <td class="t2" nowrap>
                                                    Lot:
                                                </td>
                                                <td class="t3">
                                                    <asp:TextBox ID="LotTextBox" runat="server" MaxLength="5" Width="128px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="LotRegularExpressionValidator" runat="server"
                                                        ControlToValidate="LotTextBox" ErrorMessage="Please provide a number" ValidationExpression="[1-9][0-9]*" Display="Dynamic" Width="152px"></asp:RegularExpressionValidator></td>
                                                <td class="t2" nowrap>
                                                    Block:
                                                </td>
                                                <td class="t3">
                                                    <asp:TextBox ID="BlockTextBox" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                                </td>
                                            </tr>                                        
                                            <tr>
                                                <td class="t2" nowrap>
                                                        Filing #:
                                                </td>
                                                <td class="t3">
                                                    <asp:TextBox ID="FilingTextBox" runat="server" MaxLength="100" Width="128px"></asp:TextBox>
                                                </td>
                                                <td class="t2" nowrap>
                                                    Owner City:
                                                </td>
                                                <td class="t3">
                                                    <asp:TextBox ID="OwnerCityTextBox" runat="server" MaxLength="50" Width="136px"></asp:TextBox>
                                                </td>
                                            </tr>                                        
                                            <tr>
                                                <td class="t2" nowrap>
                                                     Owner State:
                                                </td>
                                                <td class="t3">
                                                    <asp:TextBox ID="OwnerStateTextBox" runat="server" MaxLength="50" Width="128px"></asp:TextBox>
                                                </td>
                                                <td class="t2" nowrap>
                                                    Owner Zip:
                                                </td>
                                                <td class="t3">
                                                    <asp:TextBox ID="OwnerZipTextBox" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator
                                                        ID="OwnerZipRegularExpressionValidator" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="OwnerZipTextBox"
                                                        ErrorMessage="Provide a Valid Zip Code" ValidationExpression="(\d{5}(-\d{4})?)|([A-Z]{1}\d{1}[A-Z]{1} \d{1}[A-Z]{1}\d{1})"></asp:RegularExpressionValidator>
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
                                    <img src="../Images/spacer.gif" width="1" height="8" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="SearchContactsButton" runat="server" Text="Search Contacts" CssClass="buttonfont" Width="100px" OnClick="SearchContactsButton_Click" />
                                    <img src="../Images/spacer.gif" width="10px" height="1" />
                                    <input class="buttonfont" type="reset" value="Clear All" style="width: 100px"/>
                                </td>
                            </tr>                    
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="SearchResultPane" runat="server" Width="100%" Visible="false">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td style="width: 30%;">
                                    &nbsp;
                                </td>
                                <td style="text-align: right;width: 70%;">
                                    <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="buttonfont" OnClientClick="javascript: return CheckboxSelected();" OnClick="DeleteButton_Click"></asp:Button>&nbsp;&nbsp&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Literal ID="MessageLiteral" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                        
                        <fieldset>
                            <legend class="LegendText">Search Result</legend>
                            <br /><br />
                            <asp:GridView ID="SearchFarmResultGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20" OnPageIndexChanging="SearchFarmResultGridView_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="   ">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="EditContactHyperLink" runat="server" ImageUrl="~/Images/edit_icon.gif" NavigateUrl='<%# Eval("ContactId","~/Members/ModifyContact.aspx?contactId={0}&parentPage=SearchFarmData.aspx") %>' />
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="    ">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectContactCheckBox" runat="server" Value='<%#Eval("ContactId")%>' ToolTip='<%#Eval("ContactId")%>' onClick='onCheckingCheckbox(this)'/>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Farm and Plot Name">
                                        <ItemTemplate>
                                            <asp:Label ID="FarmNameLabel" Text='<%#Eval("FarmName")%>' runat="server"></asp:Label> /
                                            <asp:Label ID="PlotNameLabel" Text='<%#Eval("PlotName")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="18%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Schedule #">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="ScheduleNumberHyperLink" runat="server" NavigateUrl='<%#Eval("ContactId","~/Members/ViewContact.aspx?contactId={0}&parentPage=SearchFarmData.aspx") %>' Text='<%#Eval("ScheduleNumber")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="12%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="OwnerFullNameLabel" Text='<%#Eval("OwnerFullName")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lot">
                                        <ItemTemplate>
                                            <asp:Label ID="LotNumberLabel" Text='<%#Eval("Lot")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Block">
                                        <ItemTemplate>
                                            <asp:Label ID="BlockLabel" Text='<%#Eval("Block")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Filing">
                                        <ItemTemplate>
                                            <asp:Label ID="FilingLabel" Text='<%#Eval("Filing")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="OwnerCityLabel" Text='<%#Eval("OwnerCity")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State">
                                        <ItemTemplate>
                                            <asp:Label ID="OwnerStateLabel" Text='<%#Eval("OwnerState")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Zip">
                                        <ItemTemplate>
                                            <asp:Label ID="OwnerZipLabel" Text='<%#Eval("OwnerZip")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deleted">
                                        <ItemTemplate>
                                            <asp:Label ID="DeletedLabel" Text='<%#Eval("Deleted")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="White" CssClass="smalltype2" />
                                        <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Height="25px" Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="NoSearchResultPane" runat="server" Height="300px" Width="100%" Visible="false">
                                <table border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse">
                                    <thead>
                                        <tr>
                                            <th bgcolor="#e4e4e4" height="20px">&nbsp;&nbsp;</th>
                                            <th bgcolor="#e4e4e4" height="20px">&nbsp;&nbsp;</th>
                                            <th bgcolor="#e4e4e4" height="20px">Farm and Plot Name</th>
                                            <th bgcolor="#e4e4e4" height="20px">Schedule #</th>
                                            <th bgcolor="#e4e4e4" height="20px">Name</th>
                                            <th bgcolor="#e4e4e4" height="20px">Block</th>
                                            <th bgcolor="#e4e4e4" height="20px">Filing</th>
                                            <th bgcolor="#e4e4e4" height="20px">City</th>
                                            <th bgcolor="#e4e4e4" height="20px">State</th>
                                            <th bgcolor="#e4e4e4" height="20px">Zip</th>
                                            <th bgcolor="#e4e4e4" height="20px">Deleted</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr style="height: 25px;">
                                            <td colspan="11" style="font-style:italic; text-align:center; color: Red;">
                                                No Search Result to Display
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </fieldset>
                        <br />
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Button ID="BackToSearchPanel" runat="server" Text="Back" CssClass="buttonfont" OnClick="BackToSearchPanel_Click" Width="80px"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel> 
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>


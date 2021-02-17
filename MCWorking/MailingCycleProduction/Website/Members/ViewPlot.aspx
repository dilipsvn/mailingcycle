<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ViewPlot.aspx.cs" Inherits="ViewPlot" Title="Mailing Cycle View Plot" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    View Plot
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    function CheckboxSelected() 
    {
        var CheckStatus=false;
        var numberOfSelectedContacts = 0;
        var defaultContact = "";
        var contactCount = 0;
        var allInputTags = document.getElementsByTagName("input");
        
        for(i = 0; i < allInputTags.length; i++)
        {
             if(allInputTags[i].type == "checkbox")
             {
                if(allInputTags[i].checked)
                {
                    numberOfSelectedContacts++;
                    CheckStatus = true;
                }
             }
             else if(allInputTags[i].type == "hidden")
             {
                if (allInputTags[i].name.indexOf("DefaultContactHiddenField") > 0)
                    defaultContact = allInputTags[i].value;
                
                if (allInputTags[i].name.indexOf("ContactCountHiddenField") > 0)
                    contactCount = allInputTags[i].value; 
             }
        }
        
        if(CheckStatus)
        {
            if(numberOfSelectedContacts < contactCount)
                return confirm("Are you sure you want to delete these selected contacts?");
            else if (numberOfSelectedContacts = contactCount)
            {
                if(defaultContact == "true")
                    return confirm("This is a Primary Plot. This action will delete the Farm. Are you sure you want to delete these selected contacts?");
                else    
                    return confirm("You are emptying the Plot. This action will delete the Plot. Are you sure you want to delete these selected contacts?");
            }
        }
        else
        {
            alert("Please Select atleast One Contact Checkbox to delete");
            return CheckStatus;
        }
    }
    
    function openExcelFile()
    {
        window.open("../SampleFarm.xls", "ExportContacts");
    }
    
    function moveTo()
    {
        var w = 300;
        var h = 220;
        
        var left = (screen.width - w) / 2;
        var top = (screen.height - h) / 2;
        var farmId = "";
        var plotId = "";
        var contactIds = "";
        var url = "MoveContacts.aspx";
        var defaultContact = "";
        var contactCount = 0;
        var numberOfSelectedContacts = 0;
        var proceedFlag = false;
        
        //Get the Required Parameters
        var allInputTags = document.getElementsByTagName("input");
        for(i = 0; i < allInputTags.length; i++)
        {       
            if(allInputTags[i].type == "hidden")
            {
                //Getting Plot Id
                if (allInputTags[i].name.indexOf("PlotIdHiddenField") >= 0)
                   plotId = allInputTags[i].value;
                
                //Getting Farm Id
                if (allInputTags[i].name.indexOf("FarmIdHiddenField") >= 0)
                   farmId = allInputTags[i].value;
                
                //Getting Default Contact count   
                if (allInputTags[i].name.indexOf("DefaultContactHiddenField") > 0)
                    defaultContact = allInputTags[i].value;
                
                //Getting Total Contact Count in the Plot
                if (allInputTags[i].name.indexOf("ContactCountHiddenField") > 0)
                    contactCount = allInputTags[i].value;
                
            }
            else if(allInputTags[i].type == "checkbox")
            {
                if(allInputTags[i].checked)
                {
                    numberOfSelectedContacts++;
                    if(contactIds == "")
                        contactIds = allInputTags[i].parentNode.title;
                    else 
                        contactIds = contactIds + ";" + allInputTags[i].parentNode.title; 
                }
            }       
        }
        
        if (contactIds == "")
        {
            alert("Please select the Contacts to move.");
        }
        else
        {
            if(numberOfSelectedContacts >= contactCount)
            {
                if(defaultContact == "true")
                    alert("Moveing all the contacts from the Primary Plot is not allowed");
                else
                    proceedFlag = confirm("Moveing all the contacts from the Plot will result in deletion of Parent Plot. Are you sure you want to proceed?");
            }
            else
                proceedFlag = true;
            if(proceedFlag)
            {
                url = url + "?farmId=" + farmId + "&plotId=" + plotId + "&contactIds=" + contactIds;
                window.open(url, "MoveContacts", "toolbar=0,scrollbars=0,location=0,statusbar=1,menubar=0,resizable=0,width=" + w + ",height=" + h + ",left=" + left + ",top=" + top + "");
            }
        }
    }
    
    function plotDeleteConformation()
    {
        var allInputTags = document.getElementsByTagName("input");
        var defaultPlotFlag = "";
        for(i = 0; i < allInputTags.length; i++)
        {
            if(allInputTags[i].type == "hidden")
            {
                if (allInputTags[i].name.indexOf("DefaultPlotFlagHiddenField") >= 0)
                    defaultPlotFlag = allInputTags[i].value;
            }
        }
        
        if(defaultPlotFlag == "true")
            return confirm("This is a Primary Plot. By deleting the Plot you will delete the Parent Farm. Are you sure you want to delete this plot?");
        else
            return confirm("Are you sure you want to delete this plot?");
        
    }
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%">Manage your plot and contacts</td>
                            <td width="40%" align="right">
                                <asp:Literal ID="ForAgentLiteral" runat="server"></asp:Literal>
                                <asp:HiddenField ID="ForAgentUserIdHiddenField" runat="server" />
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
                                                <asp:HiddenField ID="DefaultPlotFlagHiddenField" runat="server" />
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
                                    <legend class="LegendText">List of Contacts</legend>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td align="right" style="height: 24px">
                                                <asp:Button ID="AddContactButton" runat="server" Text="Add Contact" Width="80px" CssClass="buttonfont" OnClick="AddContactButton_Click" />
                                                <img src="../Images/spacer.gif" width="4px" height="1" />
                                                <asp:Button ID="MoveToButton" runat="server" Text="Move to Plot" CssClass="buttonfont" Width="80px" OnClientClick="javascript: moveTo();" ToolTip="Move Selected contacts to a Plot" CausesValidation="False" UseSubmitBehavior="False" />
                                                <img src="../Images/spacer.gif" width="4px" height="1" />
                                                <asp:Button ID="DeleteContactButton" runat="server" Text="Delete" Width="80px" CssClass="buttonfont" OnClick="DeleteContactButton_Click" OnClientClick="javascript: return CheckboxSelected();" />
                                                <img src="../Images/spacer.gif" width="4px" height="1" />
                                                <asp:Button ID="ExportToExcelButton" runat="server" Text="Export to Microsoft Excel" CssClass="buttonfont" Width="160px" CausesValidation="False" UseSubmitBehavior="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/transparent.gif" width="1" height="4" /></td>
                                        </tr>
                                    </table>
                                    <div style="border-collapse: collapse;width:100%">
                                        <asp:HiddenField ID="ContactCountHiddenField" runat="server" />
                                        <asp:HiddenField ID="DefaultContactHiddenField" runat="server" />
                                        <asp:GridView ID="ContactListGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20" OnPageIndexChanging="ContactListGridView_PageIndexChanging" width="100%">
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
                <td align="center" style="height: 24px">
                    <asp:Button ID="EditPlotButton" runat="server" Text="Edit Plot" Width="80px" CssClass="buttonfont" OnClick="EditPlotButton_Click" />
                    &nbsp;<img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="DeletePlotButton" runat="server" Text="Delete Plot" Width="80px" CssClass="buttonfont" OnClick="DeletePlotButton_Click" OnClientClick="javascript: return plotDeleteConformation();"  />
                    &nbsp;<img src="../Images/spacer.gif" width="10px" height="1" />
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

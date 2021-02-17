<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="CustomMessages.aspx.cs" Inherits="CustomMessages" Title="Mailing Cycle Message Management" %>

<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Message Management
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="../Include/Functions.js"></script>
    <script language="javascript">
    function deleteItem(msg)
    {
        confirm(msg);
    }
    </script>


<div class="right-content-mainsection">
    <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td height="30" class="tableheading">
            <table width="100%">
            <tr>
                <td>
                Manage your messages</td>
                <td align=right>
                <asp:Label id="AgentLabel" runat="server" Visible="false"></asp:Label></td>
             </tr>
             </table>
            </td>
        </tr>
        <tr>
            <td class="rowborder">
                <img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" align="left">
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;<a href="javascript: document.location.href='MessageManagement.aspx';">Standard Messages</a> |                             
                        </td>    
                        <td>                    
                             <uc1:ListOfAgentsWebUserControl id="ListOfAgentsWebUserControl1" runat="server">
                             </uc1:ListOfAgentsWebUserControl>
                             &nbsp;<span style="font-size: 1.0em; font-weight: bold">Custom Messages</span>                              
                        </td>
                    </tr>
                </table>
		    </td>
        </tr>
        <tr>
        <td><asp:label runat="server" id=ErrorMessageLabel visible=false CssClass="errormessage"></asp:label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
		<tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                    <tr>
                        <td>
                            <fieldset>
                                <legend class="LegendText">List of Custom Messages</legend>
                                 <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <tr>
                                        <td align="right">
                                            <asp:button runat="server" cssclass="buttonfont" style="width:130px" text="Add Custom Message" id="AddMessageButton" OnClick="AddMessageButton_Click"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="../images/transparent.gif" width="1" height="4" /></td>
                                    </tr>
                                </table>
                                <br />
                                <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt" HeaderStyle-Height="15px"  AutoGenerateColumns="false" runat="server" ID="MessageDataGrid" BorderWidth="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse" OnPageIndexChanged="MessageDataGrid_PageIndexChanged" PageSize="20" OnRowCommand="MessageDataGrid_RowCommand" OnItemCommand="MessageDataGrid_ItemCommand" OnItemDataBound="MessageDataGrid_ItemDataBound" PagerStyle-Mode="NumericPages">
                                <Columns>
                                    <asp:TemplateColumn>
                                        <ItemTemplate>
                                            <asp:ImageButton id="EditMessageButton" CausesValidation="false" CommandName="EditMessage" ToolTip="Edit Custom Message" ImageUrl="~/Images/edit_icon.gif" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:ButtonColumn ButtonType="LinkButton" CommandName="ShowMessage" HeaderStyle-Width="15%" DataTextField="MessageId" HeaderText="Message Id" CausesValidation="false"></asp:ButtonColumn>
                                    <asp:BoundColumn HeaderStyle-Width="35%"  DataField="ShortDesc" ReadOnly="true" HeaderText="Short Description"/> 
                                    <asp:BoundColumn HeaderStyle-Width="25%"  DataField="Status" ReadOnly="true" HeaderText="Status"/>    
                                    <asp:TemplateColumn HeaderStyle-Width="46%">
                                        <HeaderTemplate>
                                            Message Text &nbsp;<a href="javascript: openHelp('../Help/MessageRendering.htm');"><img
                                                    src="../Images/helpIcon.gif" /></a>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat=server ID="MessageTextLabel" Text=<%#Eval("MessageText") %>></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                </asp:DataGrid>       
                                <table id="NoRecordsTable" runat="server" visible="false" border="1" cellspacing="0"
                                        cellpadding="5" width="100%" height="60px" style="border-collapse: collapse">
                                        <tr>
                                            <td nowrap align="center" class="errormessage">
                                                No custom messages available.</td>
                                        </tr>
                                    </table>                           
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


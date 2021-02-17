<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="MessageManagement.aspx.cs" Inherits="MessageManagement" Title="Mailing Cycle Message Management" %>
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
    function ClientValidate(source, arguments)
   {
      if (arguments.Value == "0")
      {
         arguments.IsValid=false;
         return;
      }
      arguments.IsValid=true;     
   }

    </script>


<div class="right-content-mainsection">
    <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td height="30" class="tableheading">
                Manage your messages
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
            <td style="height: 19px">
                <table border="0" cellspacing="0" cellpadding="0" align="left">
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;<span style="font-size: 1.0em; font-weight: bold">Standard Messages</span> |
                         </td>                         
                         <asp:Panel ID="AgentsPanel" runat="server" Visible="false">
                         <td align=left>
                             <uc1:ListOfAgentsWebUserControl id="ListOfAgentsWebUserControl1" runat="server">
                             </uc1:ListOfAgentsWebUserControl>                                                     
                         </td>
                          </asp:Panel>
                         <td align=left>
                            &nbsp;<asp:LinkButton ID="CustomMessagesLink" Text="Custom Messages" style="font-size: 1.0em;" CausesValidation="true" runat="server" OnClick="CustomMessagesLink_Click"></asp:LinkButton>                             
                            <asp:CustomValidator runat="server" id="AgentRFValidator" ControlToValidate="ListOfAgentsWebUserControl1" OnServerValidate="ServerValidation" ClientValidationFunction="ClientValidate" Enabled="false" ErrorMessage="Please select an agent" />

                        </td>
                    </tr>
                </table>
		    </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label id="ErrorMessageLabel" runat=server visible="false" CssClass="errormessage"></asp:Label></td>
        </tr>
		<tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                    <tr>
                        <td>
                            <fieldset>
                                <legend class="LegendText">List of Standard Messages</legend>
                                <asp:panel id="AddStdMessagePanel" runat="server" visible="false">
                                 <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <tr>
                                        <td align="right">
                                            <input class="buttonfont" style="width:130px" type="button" value="Add Standard Message" onclick="javascript: document.location.href='CreateStandardMessage.aspx?fromPage=MessageManagement'"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="../images/transparent.gif" width="1" height="4" /></td>
                                    </tr>
                                </table>
                                </asp:panel>
                                <asp:DataGrid HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt" HeaderStyle-Height="15px"  AutoGenerateColumns="false" runat="server" PageSize="20" ID="MessageDataGrid" BorderWidth="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse: collapse" OnPageIndexChanged="MessageDataGrid_PageIndexChanged" OnItemCommand="MessageDataGrid_ItemCommand" OnItemDataBound="MessageDataGrid_ItemDataBound" AllowPaging="True" PagerStyle-Mode="NumericPages">                                
                                <Columns>                                
                                    <asp:TemplateColumn>                                        
                                        <ItemTemplate>
                                            <asp:ImageButton CausesValidation="false" id="EditMessageButton" CommandName="EditMessage" ImageUrl="~/Images/edit_icon.gif" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:ButtonColumn CommandName="ShowMessage" DataTextField="MessageId" HeaderText="Message Id"></asp:ButtonColumn>
                                    <asp:BoundColumn  DataField="ShortDesc" ReadOnly="True" HeaderText="Short Description">
                                        <HeaderStyle Width="35%" />
                                    </asp:BoundColumn>  
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
                                    <HeaderStyle BackColor="#E4E4E4" CssClass="boldtxt" Font-Bold="True" Height="15px" />
                                </asp:DataGrid>    
                                 <table id="NoRecordsTable" runat="server" visible="false" border="1" cellspacing="0"
                                        cellpadding="5" width="100%" height="60px" style="border-collapse: collapse">
                                        <tr>
                                            <td nowrap align="center" class="errormessage">
                                                No standard messages available.</td>
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


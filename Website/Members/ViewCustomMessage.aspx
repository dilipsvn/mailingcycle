<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ViewCustomMessage.aspx.cs" Inherits="ViewCustomMessage" Title="Mailing Cycle View Custom Message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
View Custom Message
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
                Manage your custom message</td>
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
		    <td>
		        &nbsp;
		    </td>
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
                                <legend class="LegendText">Custom Message Details</legend>
                                <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    <tr>
                                        <td width="22%" class="t2" nowrap>
                                            Message Id:
                                        </td>
                                        <td width="78%" class="t3">
                                            <asp:Label runat="server" ID="MessageIdLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="t2" nowrap>
                                            Short Description:
                                        </td>
                                        <td class="t3"><asp:Label runat="server" ID="ShortDescLabel"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="t2" nowrap>
                                            Status:
                                        </td>
                                        <td class="t3">
                                            <asp:Label runat="server" ID="StatusLabel"></asp:Label>
                                        </td>
                                    </tr>                                   
                                    <tr>
                                        <td class="t2" valign="top" nowrap>
                                            Message Text:&nbsp;<a href="javascript: openHelp('../Help/MessageRendering.htm');"><img
                                                    src="../Images/helpIcon.gif" /></a>
                                        </td>
                                        <td class="t3" align="left">
                                            <asp:Panel runat="server" ID="MessageTextPanel" style="border: 1px dotted #336699; width: 500px; padding: 5px 5px 5px 5px">                                               
                                           <asp:Literal runat="server" id="MessageTextLiteralText"></asp:Literal>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="MessageImagePanel" style="border: 1px dotted #336699; width: 500px; padding: 5px 5px 5px 5px">                                               
                                            <asp:Image runat="server" ID="MessageImage" width= 500px height=400px/>
                                            </asp:Panel>
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
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">                
                    <asp:Button CssClass="buttonfont" ID="EditButton" Text="Edit Custom Message" style="width: 140px" OnClick="EditButton_Click"  runat="server"/>
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                   <asp:Button Text="Delete Custom Message" ID="DeleteButton" CSSclass="buttonfont" runat="server" OnClick="DeleteButton_Click" OnClientClick="javascript: return confirm('You are about to delete a message. Are you sure?');"/>
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button Text="Back" ID="BackButton" CSSclass="buttonfont" style="width: 80px" runat="server" OnClick="BackButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

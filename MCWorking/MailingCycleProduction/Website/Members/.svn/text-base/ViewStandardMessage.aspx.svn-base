<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ViewStandardMessage.aspx.cs" Inherits="ViewStandardMessage" Title="Mailing Cycle View Standard Message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
View Standard Message
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
               View standard message with wild card characters
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
                                <legend class="LegendText">Standard Message Details</legend>
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
                                        <td class="t3">
                                            <asp:Label runat="server" ID="ShortDescLabel" Width="300"></asp:Label>
                                        </td>
                                    </tr>
                                    <asp:panel id="StatusPanel" runat="server" visible="false">
                                    <tr>
                                        <td class="t2" nowrap>
                                            Status:
                                        </td>
                                        <td class="t3">
                                            <asp:Label runat="server" ID="StatusLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    </asp:panel>
                                    <tr>
                                        <td class="t2" nowrap>
                                            Default Message:
                                        </td>
                                        <td class="t3">
                                            <asp:Label runat="server" ID="DefaultMessageLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="t2" valign="top" nowrap>
                                            Message Text:&nbsp;<a href="javascript: openHelp('../Help/MessageRendering.htm');"><img
                                                    src="../Images/helpIcon.gif" /></a>
                                        </td>
                                        <td class="t3" align="left">
                                         <div style="border: 1px dotted #336699; width: 500px; padding: 5px 5px 5px 5px">
                                           <asp:Literal runat="server" id="MessageTextLiteralText"></asp:Literal>
                                          </div>
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
            <tr><td><img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button Text="Edit Standard Message" CSSclass="buttonfont" id="EditButton" runat="server" Visible="false" OnClick="EditButton_Click" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button Text="Delete Standard Message"  CSSclass="buttonfont" ID="DeleteButton" runat="server" Visible="false" OnClick="DeleteButton_Click" OnClientClick="javascript: return confirm('You are about to delete a message. Are you sure?');"/>
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <input class="buttonfont" type="button" value="Back" style="width: 80px" onclick="javascript:location.href='MessageManagement.aspx'" />
                </td>
            </tr>
            <tr>
                <td><img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

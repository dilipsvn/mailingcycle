<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="MessagesReportCriteria.aspx.cs" Inherits="MessagesReportCriteria" Title="Mailing Cycle Messages Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Messages Report
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">       

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Messages Report Criteria
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../../images/transparent.gif" width="1" height="1" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr><td><asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please correct the below errors:" /></td></tr>
            <tr><td><asp:Label id="ErrorLiteral" runat="server" CssClass="errormessage"></asp:Label></td>            
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Report Criteria</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2">Category:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="CategoryDropDownList" runat="server">                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">Message Id:</td>
                                            <td class="t3">
                                                <asp:textbox id="MessageIdTextBox" runat="server"></asp:textbox>
                                                <asp:RegularExpressionValidator ID="MessageIdTextBoxRegExpValidator" runat="server" ControlToValidate="MessageIdTextBox" ValidationExpression="^[0-9]*$" ErrorMessage="Please enter a valid message id" Display="None"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">Status:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="StatusDropDownList" runat="server">                                                   
                                                </asp:DropDownList>
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
                                <img src="../../Images/spacer.gif" width="1" height="8" /></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button cssclass="buttonfont" text="Launch" style="width: 100px"  runat="server" ID="LaunchButton" OnClick="LaunchButton_Click" />
                                <img src="../../Images/spacer.gif" width="10px" height="1" />
                                <input class="buttonfont" type="reset" value="Clear All" style="width: 100px"/>
                            </td>
                        </tr>                    
                    </table> 
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


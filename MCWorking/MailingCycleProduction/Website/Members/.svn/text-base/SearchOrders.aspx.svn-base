<%@ Page ValidateRequest="false" Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="SearchOrders.aspx.cs" Inherits="SearchOrders" Title="Mailing Cycle Search Orders" %>
<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Search Orders
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../Include/datetimepicker.js"></script>
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Search for the Orders
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
                                        <asp:Panel ID="AgentPanel" runat="server" Visible=false>
                                        <tr>
                                            <td class="t2">Agent:</td>
                                            <td class="t3">
                                                 <uc1:ListOfAgentsWebUserControl ID="ListOfAgentsWebUserControl1" runat="server" AutoPostBack="false" />
                                            </td>
                                        </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td class="t2">Order ID:</td>
                                            <td class="t3">
                                                <asp:TextBox ID="OrderIdTextBox" runat="server" MaxLength=20></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="OrderIdTextBoxRegExpValidator" runat="server" ControlToValidate="OrderIdTextBox" ValidationExpression="^[0-9]*$" ErrorMessage="Please enter a valid order id" Display="None"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">Card Type:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="CardTypeDropDownList" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                            <tr>
                                                <td class="t2">Start Date:</td>
                                                <td class="t3">
                                                    <asp:TextBox runat="server" ID="StartDateTextBox"></asp:TextBox>&nbsp;<a runat="server" id="StartDateLink" ><img
                                                        src="../images/dtp.gif" width="16" height="16" border="0" alt="Pick a date" ></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="t2">End Date:</td>
                                                <td class="t3">
                                                    <asp:TextBox runat="server" ID="EndDateTextBox"></asp:TextBox>&nbsp;<a runat="server" id="EndDateLink" ><img
                                                        src="../images/dtp.gif" width="16" height="16" border="0" alt="Pick a date"></a>
                                                        <asp:CompareValidator ID="DateCompareValidator" runat="server" controltovalidate="EndDateTextBox" ControlToCompare="StartDateTextBox" Operator=GreaterThan Type=Date ErrorMessage="Please enter end date greater than start date" Display="None"></asp:CompareValidator></td>
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
                                <asp:Button runat="server" cssclass="buttonfont" text="Search Orders" style="width: 100px" ID="SearchButton" onclick="SearchButton_Click"/>
                                <img src="../Images/spacer.gif" width="10px" height="1" />
                                <input class="buttonfont" type="reset" value="Clear All" style="width: 100px"/>
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


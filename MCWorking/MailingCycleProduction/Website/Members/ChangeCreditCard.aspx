<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ChangeCreditCard.aspx.cs" Inherits="ChangeCreditCard" Title="Mailing Cycle Update Credit Card Details" %>

<%@ Register Src="../WebUserControls/CreditCardWebUserControl.ascx" TagName="CreditCardWebUserControl"
    TagPrefix="uc1" %>
    <%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" runat="server">
    Update Credit Card Details
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="scriptmanager1" runat="server"></asp:ScriptManager>

    <script type="text/javascript">
    function openHelp(path)
    {
        var iWidth = 450;
        var iHeight = screen.height - 100;
        var iLeft = (screen.width - iWidth) - 12;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
        window.open(path, "Help", sFeatures + sSize);
    }
    
    function cancelRegistration()
    {
        if (confirm("Your registration has not been completed. If you do not accept now all the registration data will be lost.\n\nAre you sure you want to cancel your registration?") == true)
        {
            document.location.href = "Default.aspx";
        }
    }
    </script>

    <div class="right-content-mainsection">
                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <span id="error_Login" class="errormessage">
                                    <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
                                </span>                                                                                    
                                <asp:ValidationSummary ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:"/>
                            </td>
                        </tr>
                    </table> 

        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Please modify your credit card details in the below form
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
                <td>
                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                        <tr>
                            <td class="Notes" style="padding-left: 20px">
                                Fields marked with <span class="MandatoryMark">*</span> are mandatory
                            </td>
                            <td align="right">
                                <span id="MessagesSpan">
                                    <asp:Label ID="MessagesLabel" runat="server" cssClass="MessageText"></asp:Label>
                                </span>                                                                                    
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <uc1:CreditCardWebUserControl id="CreditCardWebUserControl1" runat="server">
                    </uc1:CreditCardWebUserControl>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button CssClass="buttonfont" ID="SaveButton" Text="Save" Width="80px" runat="Server" OnClick="SaveButton_Click" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <input class="buttonfont" type="button" value="Cancel" style="width: 80px" onclick="javascript: document.location.href='welcome.aspx'" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


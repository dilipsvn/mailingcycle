<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ChangeProfile.aspx.cs" Inherits="ChangeProfile" Title="Mailing Cycle Update Profile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Update Profile
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    function openHelp(path)
    {
        var iWidth = 300;
        var iHeight = screen.height - 100;
        var iLeft = (screen.width - iWidth) - 12;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
        window.open(path, "Help", sFeatures + sSize);
    }
    
    function newQuestion(list)
    {
        if (list.options[list.selectedIndex].value == -2)
        {
            var vTextData = window.prompt("Please enter your own secret question:", "");
            
            if (vTextData != null)
            {
                if (vTextData != "")
                {
                    var index = list.length - 1;
                    
                    var oOption = document.createElement("OPTION");
                    list.options.add(oOption, index);
                    oOption.innerText = vTextData;
                    oOption.value = "0";
                    
                    list.selectedIndex = index;
                }
            }
        }
    }
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Please modify profile details in the below form
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
                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <span id="error_Login" class="errormessage">
                                    <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
                                </span>                                                                                    
                                <asp:ValidationSummary ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:" />
                            </td>
                        </tr>
                    </table> 
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Personal Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                First Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:TextBox ID="FirstNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="FirstNameTextBoxRFValidator" runat="server" ErrorMessage="First Name is required" InitialValue="" ControlToValidate="FirstNameTextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="22%" class="t2" nowrap>
                                                Middle Name:
                                            </td>
                                            <td width="28%" class="t3" nowrap>
                                                <asp:TextBox ID="MiddleNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Last Name:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="LastNameTextBoxRFValidator" SetFocusOnError="true" runat="server" ErrorMessage="Last Name is required" InitialValue="" ControlToValidate="LastNameTextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Company Name:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="CompanyNameTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Address Line 1:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="Address1TextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Address1TextBoxRFValidator" runat="server" SetFocusOnError="true" ErrorMessage="Address1 is required" InitialValue="" ControlToValidate="Address1TextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Address Line 2:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="Address2TextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                City:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="CityTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CityTextBoxRFValidator" runat="server" SetFocusOnError="true" ErrorMessage="City is required" InitialValue="" ControlToValidate="CityTextBox" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Country:
                                            </td>
                                            <td class="t3">
                                                <asp:DropDownList ID="CountryDropDownList" runat="server" OnSelectedIndexChanged="CountryDropDownList_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                State/Province:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:DropDownList ID="StateDropDownList" runat="server">
                                                        </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="StateDropDownListRFValidator" SetFocusOnError="true" runat="server" ErrorMessage="Select a State" InitialValue="0" ControlToValidate="StateDropDownList" Display="none"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="t2" nowrap>
                                                Zip:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <asp:TextBox ID="ZipTextBox" Width="80px" MaxLength="10" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ZipRequiredFieldValidator" ControlToValidate="ZipTextBox"
                                                    InitialValue="" ErrorMessage="Zip is required" SetFocusOnError="true" Display="none"
                                                    runat="server"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="ZipCustomValidator" ControlToValidate="ZipTextBox" ClientValidationFunction="MCU_ValidateZip"
                                                    ErrorMessage="Invalid Zip." SetFocusOnError="true" Display="None" runat="server"></asp:CustomValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Phone:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="PhoneTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PhoneTextBoxRFValidator" runat="server" ErrorMessage="Phone is required" SetFocusOnError="true" InitialValue="" ControlToValidate="PhoneTextBox" Display="none"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator  SetFocusOnError="true" ID="PhoneTextBoxREValidator" runat="server" ErrorMessage="Invalid Phone Number."
                                                ValidationExpression="((((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}) ?)|(\d{10})" ControlToValidate="PhoneTextBox" Display="none"></asp:RegularExpressionValidator>
                                            </td>
                                            <td class="t2" nowrap style="word-wrap: break-word">
                                                Mobile:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="MobileTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Fax:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="FaxTextBox" runat="server" MaxLength="128" Width="150px"></asp:TextBox>
                                            </td>
                                            <td class="t2" nowrap>
                                                Email:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="256" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="EmailTextBoxRFValidator" SetFocusOnError="true" runat="server" ErrorMessage="Email is required" InitialValue="" ControlToValidate="EmailTextBox" Display="none"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator  SetFocusOnError="true" ID="EmailTextBoxREValidator" runat="server" ErrorMessage="Invalid Email."
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTextBox" Display="none"></asp:RegularExpressionValidator>
                                                <asp:CustomValidator SetFocusOnError="true" ID="EmailTextBoxCustomValidator" runat="server" OnServerValidate="CheckUniqueEmail" ErrorMessage="Email address is already existing" Display="none" ControlToValidate="EmailTextBox"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
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
                    <asp:Button CssClass="buttonfont" ID="SaveButton" Text="Save" Width="80px"
                        runat="Server" OnClick="SaveButton_Click" />
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

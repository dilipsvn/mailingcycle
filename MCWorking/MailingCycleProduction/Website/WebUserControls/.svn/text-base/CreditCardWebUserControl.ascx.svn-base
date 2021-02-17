<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreditCardWebUserControl.ascx.cs" Inherits="WebUserControls_CreditCardWebUserControl" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<script type="text/javascript">

function ValidateCCNumber(sender, args)
{
    //var oCardType = document.all("*CardTypeDropDownList*");
    var allInputTags = document.getElementsByTagName("select");
    var oCardType;
    for(i = 0; i < allInputTags.length; i++)
         {
            if(allInputTags[i].name.indexOf("CardTypeDropDownList") > 0)
                oCardType = allInputTags[i];
         }
    var sCardType = oCardType.options(oCardType.selectedIndex).text;
    var sCardTypeValue = oCardType.options(oCardType.selectedIndex).value;
    var re;

    if(sCardTypeValue!=0)
    {
        if (sCardType == "Visa")
        {
            // Visa: length 16, prefix 4, dashes optional.
            re = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
        }
        else if (sCardType == "Master")
        {
            // Mastercard: length 16, prefix 51-55, dashes optional.
            re = /^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$/;
        }
        else if (sCardType == "Discover")
        {
            // Discover: length 16, prefix 6011, dashes optional.
            re = /^6011-?\d{4}-?\d{4}-?\d{4}$/;
        }
        else if (sCardType == "American Express")
        {
            // American Express: length 15, prefix 34 or 37.
            re = /^3[4,7]\d{13}$/;
        }
        else if (sCardType == "Diners")
        {
            // Diners: length 14, prefix 30, 36, or 38.
            re = /^3[0,6,8]\d{12}$/;
        }
    
        if (!re.test(args.Value))
        {
            args.IsValid = false;
            return;
        }
    
        // Remove all dashes for the checksum checks to eliminate negative numbers
        var cardNumber = args.Value.split("-").join("");
        
        // Checksum ("Mod 10")
        // Add even digits in even length strings or odd digits in odd length strings.
        var checksum = 0;
        for (var i = (2-(cardNumber.length % 2)); i <= cardNumber.length; i+=2)
        {
            checksum += parseInt(cardNumber.charAt(i-1));
        }
    
        // Analyze odd digits in even length strings or even digits in odd length strings.
        for (var i = (cardNumber.length % 2) + 1; i < cardNumber.length; i+=2)
        {
            var digit = parseInt(cardNumber.charAt(i-1)) * 2;
            if (digit < 10)
            {
                checksum += digit;
            }
            else
            {
                checksum += (digit-9);
            }
        }
        if ((checksum % 10) == 0)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
} 
</script>
<table border="0" cellspacing="1" cellpadding="1" width="100%">
    <tr>
        <td>
            <fieldset>
                <legend class="LegendText">Credit Card Details</legend>
                <table border="0" cellspacing="2" cellpadding="1" width="100%">
                    <tr>
                        <td colspan="4">
                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                    </tr>
                    <tr>
                        <td width="22%" class="t2" nowrap>
                            Card Type :&nbsp;<span class="MandatoryMark">*</span>
                        </td>
                        <td width="28%" class="t3" nowrap>
                            <asp:DropDownList ID="CardTypeDropDownList" runat="server" OnSelectedIndexChanged="CardTypeDropDownList_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="CardTypeDropDownListRFValidator" runat="server" ControlToValidate="CardTypeDropDownList"
                            ErrorMessage="Card Type is Required" SetFocusOnError="true" InitialValue="0" Display="none"></asp:RequiredFieldValidator>
                        </td>
                        <td width="22%" class="t2" nowrap>
                            Card Number:&nbsp;<span class="MandatoryMark">*</span>
                        </td>
                        <td width="28%" class="t3" nowrap>
                            <asp:TextBox ID="CardNumberTextBox" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CardNumberTextBoxRFValidator" SetFocusOnError="true" runat="server" ControlToValidate="CardNumberTextBox"
                            ErrorMessage="Card No is Required" Display="none"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CardNumberTextBoxCustomValidator" SetFocusOnError="true" runat="server" Display="none" ControlToValidate="CardNumberTextBox" ClientValidationFunction="ValidateCCNumber" OnServerValidate="CreditCard_ServerValidate" ErrorMessage="Please enter a valid Card No."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="t2" nowrap>
                            Expiry Date:&nbsp;<span class="MandatoryMark">*</span>
                        </td>
                        <td class="t3" nowrap>
                            <asp:DropDownList ID="CardMonthDropDownList" runat="server" Width="40px">
                            <asp:ListItem Value="1">01</asp:ListItem>
                            <asp:ListItem Value="2">02</asp:ListItem>
                            <asp:ListItem Value="3">03</asp:ListItem>
                            <asp:ListItem Value="4">04</asp:ListItem>
                            <asp:ListItem Value="5">05</asp:ListItem>
                            <asp:ListItem Value="6">06</asp:ListItem>
                            <asp:ListItem Value="7">07</asp:ListItem>
                            <asp:ListItem Value="8">08</asp:ListItem>
                            <asp:ListItem Value="9">09</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="11">11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="CardYearDropDownList" runat="server">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="CCExpiryCustomValidator" runat="server" Display="none" SetFocusOnError="true" ErrorMessage="Please Check the Expiry Date or your Card has Expired"
                            OnServerValidate="CCExpiryCustomValidator_ServerValidate" Width="248px" ControlToValidate="cardYearDropDownList"></asp:CustomValidator>                                                
                        </td>
                        <td class="t2" nowrap>
                            CVV Number:
                        </td>
                        <td class="t3" nowrap>
                            <asp:TextBox ID="CVVNumberTextBox" runat="server" MaxLength="50" Width="30px"></asp:TextBox>&nbsp;
                            <asp:HyperLink ID="HelpHyperLink" runat="server" ImageUrl="~/Images/helpIcon.gif" NavigateUrl="javascript: openHelp('./Help/CvvNumber.htm')"></asp:HyperLink>
                        </td>
                            
                    </tr>
                    <tr>
                        <td class="t2" nowrap>
                            Name on Card:&nbsp;<span class="MandatoryMark">*</span>
                        </td>
                        <td class="t3">
                            <asp:TextBox ID="CardHolderNameTextBox" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CardHolderNameTextBoxRFValidator" SetFocusOnError="true" runat="server" ControlToValidate="CardHolderNameTextBox" ErrorMessage="Card Holder Name is Required" Display="none"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <fieldset>
                <legend class="LegendText">Billing Address Details</legend>
                <table border="0" cellspacing="2" cellpadding="1" width="100%">
                    <tr>
                        <td colspan="4">
                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                    </tr>
                    <tr>
                        <td width="22%" class="t2" nowrap>
                            Address Line 1:&nbsp;<span class="MandatoryMark">*</span>
                        </td>
                        <td width="28%" class="t3">
                            <asp:TextBox ID="BillingAddress1TextBox" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="BillingAddress1TextBoxRFValidator" runat="server" SetFocusOnError="true" ControlToValidate="BillingAddress1TextBox" ErrorMessage="Billing Address1 is Required" Display="none"></asp:RequiredFieldValidator>
                        </td>
                        <td width="22%" class="t2" nowrap style="word-wrap: break-word">
                            Address Line 2:
                        </td>
                        <td width="28%" class="t3">
                            <asp:TextBox ID="BillingAddress2TextBox" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="t2" nowrap>
                            City:&nbsp;<span class="MandatoryMark">*</span>
                        </td>
                        <td class="t3">
                            <asp:TextBox ID="BillingCityTextBox" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="BillingCityTextBoxRFValidator" runat="server" SetFocusOnError="true" ControlToValidate="BillingCityTextBox" ErrorMessage="Billing City is Required" Display="none"></asp:RequiredFieldValidator>
                        </td>
                        <td class="t2" nowrap style="word-wrap: break-word">
                            Country:
                        </td>
                        <td class="t3">
                            <asp:DropDownList ID="BillingCountryDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="BillingCountryDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="t2" nowrap>
                            State/Province:&nbsp;<span class="MandatoryMark">*</span>
                        </td>
                        <td class="t3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                            <asp:DropDownList ID="BillingStateDropDownList" runat="server" OnSelectedIndexChanged="BillingStateDropDownList_SelectedIndexChanged" ></asp:DropDownList><asp:RequiredFieldValidator ID="BillingStateDropDownListRFValidator" runat="server" SetFocusOnError="true" ControlToValidate="billingStateDropDownList"
                            ErrorMessage="Billing State is Required" InitialValue="0" Display="none"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BillingCountryDropDownList" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="t2" nowrap>
                            Zip:&nbsp;<span class="MandatoryMark">*</span></td>
                        <td class="t3">
                            <asp:TextBox ID="BillingZipTextBox" Width="80px" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="BillingZipRequiredFieldValidator" ControlToValidate="BillingZipTextBox"
                                InitialValue="" ErrorMessage="Billing Zip is required" SetFocusOnError="true" Display="none"
                                runat="server"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="BillingZipCustomValidator" ControlToValidate="BillingZipTextBox" ClientValidationFunction="MCU_ValidateZip"
                                ErrorMessage="Invalid Billing Zip." SetFocusOnError="true" Display="None" runat="server"></asp:CustomValidator></td>
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

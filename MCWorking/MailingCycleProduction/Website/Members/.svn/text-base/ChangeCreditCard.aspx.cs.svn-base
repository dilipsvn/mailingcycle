#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ChangeCreditCard.aspx
    * Created Date      : 30/Aug/2007
	* Last Modify Date  : 28/Sep/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to change the payment details for registration
	* Source			: MailingCycle\Agent\ChangeCreditCard.aspx.cs

	****************************************************************/
#endregion

#region Namespaces

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Irmac.MailingCycle.BLLServiceLoader;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLL;
using System.Text.RegularExpressions;
#endregion


public partial class ChangeCreditCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ((HyperLink)CreditCardWebUserControl1.FindControl("HelpHyperLink")).NavigateUrl = "javascript: openHelp('../Help/CvvNumber.htm')";
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

            RegistrationService.CreditCardInfo creditCardInfo = registrationService.GetCreditCard(loginInfo.UserId);

            //((CustomValidator)CreditCardWebUserControl1.FindControl("CardNumberTextBoxCustomValidator")).Enabled = false;

            if (creditCardInfo != null)
            {
                ((DropDownList)CreditCardWebUserControl1.FindControl("CardTypeDropDownList")).SelectedValue = creditCardInfo.Type.LookupId.ToString();
                ((TextBox)CreditCardWebUserControl1.FindControl("CardNumberTextBox")).Text = creditCardInfo.Number;
                ((DropDownList)CreditCardWebUserControl1.FindControl("CardMonthDropDownList")).SelectedValue = creditCardInfo.ExpirationMonth.ToString();
                ((DropDownList)CreditCardWebUserControl1.FindControl("CardYearDropDownList")).SelectedValue = creditCardInfo.ExpirationYear.ToString();
                ((TextBox)CreditCardWebUserControl1.FindControl("CVVNumberTextBox")).Text = creditCardInfo.CvvNumber;
                ((TextBox)CreditCardWebUserControl1.FindControl("CardHolderNameTextBox")).Text = creditCardInfo.HolderName;

                ((TextBox)CreditCardWebUserControl1.FindControl("BillingAddress1TextBox")).Text = creditCardInfo.Address.Address1;
                ((TextBox)CreditCardWebUserControl1.FindControl("BillingAddress2TextBox")).Text = creditCardInfo.Address.Address2;
                ((TextBox)CreditCardWebUserControl1.FindControl("BillingCityTextBox")).Text = creditCardInfo.Address.City;
                ((DropDownList)CreditCardWebUserControl1.FindControl("BillingCountryDropDownList")).SelectedValue = creditCardInfo.Address.Country.CountryId.ToString();
                ((DropDownList)CreditCardWebUserControl1.FindControl("BillingStateDropDownList")).SelectedValue = creditCardInfo.Address.State.StateId.ToString();

                ((TextBox)CreditCardWebUserControl1.FindControl("BillingZipTextBox")).Text = creditCardInfo.Address.Zip;
            }
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool isExpiryValid = false;
            bool isCardNumberValid = false;

            ((CustomValidator)CreditCardWebUserControl1.FindControl("CCExpiryCustomValidator")).Validate();
            if (Page.IsValid)
                isExpiryValid = true;
            ((CustomValidator)CreditCardWebUserControl1.FindControl("CardNumberTextBoxCustomValidator")).Validate();
            if (Page.IsValid)
                isCardNumberValid = true;

            if (isExpiryValid==true && isCardNumberValid==true)
            {
                ErrorLiteral.Text = "";
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
                RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

                RegistrationService.CreditCardInfo creditCardInfo = new RegistrationService.CreditCardInfo();

                RegistrationService.StateInfo billingState = new RegistrationService.StateInfo();
                billingState.StateId = Convert.ToInt32(((DropDownList)CreditCardWebUserControl1.FindControl("BillingStateDropDownList")).SelectedValue);
                billingState.Name = ((DropDownList)CreditCardWebUserControl1.FindControl("BillingStateDropDownList")).SelectedItem.Text;

                RegistrationService.CountryInfo billingCountry = new RegistrationService.CountryInfo();
                billingCountry.CountryId = Convert.ToInt32(((DropDownList)CreditCardWebUserControl1.FindControl("BillingCountryDropDownList")).SelectedValue);
                billingCountry.Name = ((DropDownList)CreditCardWebUserControl1.FindControl("BillingCountryDropDownList")).SelectedItem.Text;

                RegistrationService.AddressInfo billingAddress = new RegistrationService.AddressInfo();
                billingAddress.Address1 = ((TextBox)CreditCardWebUserControl1.FindControl("BillingAddress1TextBox")).Text;
                billingAddress.Address2 = ((TextBox)CreditCardWebUserControl1.FindControl("BillingAddress2TextBox")).Text;
                billingAddress.City = ((TextBox)CreditCardWebUserControl1.FindControl("BillingCityTextBox")).Text;
                billingAddress.State = billingState;
                billingAddress.Zip = ((TextBox)CreditCardWebUserControl1.FindControl("BillingZipTextBox")).Text;
                billingAddress.Country = billingCountry;

                RegistrationService.LookupInfo creditCardType = new RegistrationService.LookupInfo();
                creditCardType.LookupId = Convert.ToInt32(((DropDownList)CreditCardWebUserControl1.FindControl("CardTypeDropDownList")).SelectedValue);
                creditCardType.Name = ((DropDownList)CreditCardWebUserControl1.FindControl("CardTypeDropDownList")).SelectedItem.Text;

                creditCardInfo.Type = creditCardType;
                creditCardInfo.Number = ((TextBox)CreditCardWebUserControl1.FindControl("CardNumberTextBox")).Text;
                creditCardInfo.CvvNumber = ((TextBox)CreditCardWebUserControl1.FindControl("CVVNumberTextBox")).Text;
                creditCardInfo.HolderName = ((TextBox)CreditCardWebUserControl1.FindControl("CardHolderNameTextBox")).Text;
                creditCardInfo.ExpirationMonth = Convert.ToInt32(((DropDownList)CreditCardWebUserControl1.FindControl("CardMonthDropDownList")).SelectedValue);
                creditCardInfo.ExpirationYear = Convert.ToInt32(((DropDownList)CreditCardWebUserControl1.FindControl("CardYearDropDownList")).SelectedValue);
                creditCardInfo.Address = billingAddress;


                registrationService.UpdateCreditCard(loginInfo.UserId, creditCardInfo);
            }
            else
                ErrorLiteral.Text = " ";
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = "Error in Update";
        }
        if (ErrorLiteral.Text == "")
            MessagesLabel.Text = "Credit Card Information Updated Successfully";
    }
}

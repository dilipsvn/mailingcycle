#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: AgentRegisterationFee.aspx
    * Created Date      : 30/Aug/2007
	* Last Modify Date  : 20/Sep/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to provide the payment details for registration
	* Source			: MailingCycle\AgentRegisterationfee.aspx.cs

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


public partial class AgentRegistrationFee : System.Web.UI.Page
{

    #region Field Declarations

    #region Form specific variable declaration

    #endregion

    #endregion

    #region Event Handlers

    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        DontAcceptButton.Attributes.Add("onClick", "return cancelRegistration()");
        if (!Page.IsPostBack)
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService commonService = serviceLoader.GetCommon();


            // Get the Membership fee
            CommonService.PropertyInfo property = commonService.GetProperty("Membership Fee");
            MembershipFeeLiteral.Text = property.Value.ToString();

            if (Session["registrationInfo"] != null)
                InitializeValuesFromSession();

        }
    }
    #endregion

    #region Custom Event Handler

    protected void InitializeValuesFromSession()
    {

        RegistrationService.RegistrationInfo registration = (RegistrationService.RegistrationInfo)Session["registrationInfo"];


        if (registration.CreditCard != null)
        {
           ((DropDownList)CreditCardDetails1.FindControl("CardTypeDropDownList")).SelectedValue = registration.CreditCard.Type.LookupId.ToString();
            ((TextBox)CreditCardDetails1.FindControl("CardNumberTextBox")).Text = registration.CreditCard.Number;
            ((DropDownList)CreditCardDetails1.FindControl("CardMonthDropDownList")).SelectedValue = registration.CreditCard.ExpirationMonth.ToString();
            ((DropDownList)CreditCardDetails1.FindControl("CardYearDropDownList")).SelectedValue = registration.CreditCard.ExpirationYear.ToString();
            ((TextBox)CreditCardDetails1.FindControl("CVVNumberTextBox")).Text = registration.CreditCard.CvvNumber;
            ((TextBox)CreditCardDetails1.FindControl("CardHolderNameTextBox")).Text = registration.CreditCard.HolderName;
            ((TextBox)CreditCardDetails1.FindControl("BillingAddress1TextBox")).Text = registration.CreditCard.Address.Address1;
            ((TextBox)CreditCardDetails1.FindControl("BillingAddress2TextBox")).Text = registration.CreditCard.Address.Address2;
            ((TextBox)CreditCardDetails1.FindControl("BillingCityTextBox")).Text = registration.CreditCard.Address.City;
    //        ((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedValue = registration.CreditCard.Address.State.StateId.ToString();
      //      ((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).SelectedValue = registration.CreditCard.Address.Country.CountryId.ToString();
            ((TextBox)CreditCardDetails1.FindControl("BillingZipTextBox")).Text = registration.CreditCard.Address.Zip;
        }




    }


    protected void AcceptButton_Click(object sender, EventArgs e)
    {

        if (Page.IsValid == true)
        {
            CaptureValuesIntoSession();
            Response.Redirect("AgentRegistrationConf.aspx");
        }
    }

    protected void DontAcceptButton_Click(object sender, EventArgs e)
    {
        Session["registrationInfo"] = null;
        Response.Redirect("Default.aspx");
    }

    private void CaptureValuesIntoSession()
    {
        RegistrationService.RegistrationInfo registration = (RegistrationService.RegistrationInfo)Session["registrationInfo"];

        RegistrationService.CreditCardInfo creditCard = new RegistrationService.CreditCardInfo();

        RegistrationService.StateInfo billingState = new RegistrationService.StateInfo();
        billingState.StateId = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedValue);
        billingState.Name = ((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedItem.Text;

        RegistrationService.CountryInfo billingCountry = new RegistrationService.CountryInfo();
        billingCountry.CountryId = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).SelectedValue);
        billingCountry.Name = ((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).SelectedItem.Text;

        RegistrationService.AddressInfo billingAddress = new RegistrationService.AddressInfo();
        billingAddress.Address1 = ((TextBox)CreditCardDetails1.FindControl("BillingAddress1TextBox")).Text;
        billingAddress.Address2 = ((TextBox)CreditCardDetails1.FindControl("BillingAddress2TextBox")).Text;
        billingAddress.City = ((TextBox)CreditCardDetails1.FindControl("BillingCityTextBox")).Text;
        billingAddress.State = billingState;
        billingAddress.Zip = ((TextBox)CreditCardDetails1.FindControl("BillingZipTextBox")).Text;
        billingAddress.Country = billingCountry;

        RegistrationService.LookupInfo creditCardType = new RegistrationService.LookupInfo();
        creditCardType.LookupId = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("CardTypeDropDownList")).SelectedValue);
        creditCardType.Name = ((DropDownList)CreditCardDetails1.FindControl("CardTypeDropDownList")).SelectedItem.Text;

        creditCard.Type = creditCardType;
        creditCard.Number = ((TextBox)CreditCardDetails1.FindControl("CardNumberTextBox")).Text;
        creditCard.CvvNumber = ((TextBox)CreditCardDetails1.FindControl("CVVNumberTextBox")).Text;
        creditCard.HolderName = ((TextBox)CreditCardDetails1.FindControl("CardHolderNameTextBox")).Text;
        creditCard.ExpirationMonth = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("CardMonthDropDownList")).SelectedValue);
        creditCard.ExpirationYear = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("CardYearDropDownList")).SelectedValue);
        creditCard.Address = billingAddress;

        registration.CreditCard = creditCard;
        Session["registrationInfo"] = registration;
    }

    #endregion

    #endregion

}

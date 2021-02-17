#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ChangeProfile.aspx
    * Created Date      : 30/Aug/2007
	* Last Modify Date  : 28/Sep/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to update the profile of the Realtor
	* Source			: MailingCycle\ChangeProfile.aspx.cs

	****************************************************************/
#endregion

#region Namespaces

using System;
using System.Data.SqlClient;
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
#endregion

public partial class ChangeProfile : System.Web.UI.Page
{
    RegistrationService.RegistrationInfo registration;

    protected void Page_Load(object sender, EventArgs e)
    {
        Util.Validations.RegisterZipScriptBlock(Page.ClientScript, this.GetType(),
            CountryDropDownList.ClientID);

        if (!Page.IsPostBack)
        {
            // Get the common web service instance.

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService commonService = serviceLoader.GetCommon();

            // Get the list of contries and populate.
            IList<CommonService.CountryInfo> countries = commonService.GetCountries();

            CountryDropDownList.DataSource = countries;
            CountryDropDownList.DataValueField = "CountryId";
            CountryDropDownList.DataTextField = "Name";
            CountryDropDownList.DataBind();

            CountryDropDownList.Items.FindByText("United States").Selected = true;
            CountryDropDownList_SelectedIndexChanged(CountryDropDownList, new EventArgs());

            if (Session["loginInfo"] != null && Session["loginInfo"] != "")
                InitializeValuesFromSession();
        }
    }


    protected void InitializeValuesFromSession()
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
        RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

        RegistrationService.RegistrationInfo registration = registrationService.GetDetails(loginInfo.UserId);

        FirstNameTextBox.Text = registration.FirstName;
        MiddleNameTextBox.Text = registration.MiddleName;
        LastNameTextBox.Text = registration.LastName;
        CompanyNameTextBox.Text = registration.CompanyName;
        Address1TextBox.Text = registration.Address.Address1;
        Address2TextBox.Text = registration.Address.Address2;
        CityTextBox.Text = registration.Address.City;
        StateDropDownList.SelectedValue = registration.Address.State.StateId.ToString();
        CountryDropDownList.SelectedValue = registration.Address.Country.CountryId.ToString();
        ZipTextBox.Text = registration.Address.Zip;
        PhoneTextBox.Text = registration.Address.Phone;
        MobileTextBox.Text = registration.Address.Mobile;
        FaxTextBox.Text = registration.Address.Fax;
        EmailTextBox.Text = registration.Email;
        CountryDropDownList_SelectedIndexChanged(CountryDropDownList, new EventArgs());
    }

    protected void CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList countryDropDownList = (DropDownList)sender;

        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();

            StateDropDownList.Items.Clear();
            int countryId = Convert.ToInt32(countryDropDownList.SelectedValue);

            if (countryId == 0)
            {
                StateDropDownList.Items.Add(new ListItem("&lt;Select a State&gt;", "0"));
            }
            else
            {
                CommonService.CommonService commonService = serviceLoader.GetCommon();
                IList<CommonService.StateInfo> states = commonService.GetStates(countryId);

                StateDropDownList.DataSource = states;
                StateDropDownList.DataValueField = "StateId";
                StateDropDownList.DataTextField = "Name";
                StateDropDownList.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                ErrorLiteral.Text = "";
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
                RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

                RegistrationService.RegistrationInfo registration = new RegistrationService.RegistrationInfo();

                // Get user's personal modified information.
                RegistrationService.StateInfo state = new RegistrationService.StateInfo();
                state.StateId = Convert.ToInt32(StateDropDownList.SelectedValue);
                state.Name = StateDropDownList.SelectedItem.Text;

                RegistrationService.CountryInfo country = new RegistrationService.CountryInfo();
                country.CountryId = Convert.ToInt32(CountryDropDownList.SelectedValue);
                country.Name = CountryDropDownList.SelectedItem.Text;


                RegistrationService.AddressInfo address = new RegistrationService.AddressInfo();
                address.Address1 = Address1TextBox.Text;
                address.Address2 = Address2TextBox.Text;
                address.City = CityTextBox.Text;
                address.State = state;
                address.Zip = ZipTextBox.Text;
                address.Country = country;
                address.Phone = PhoneTextBox.Text;
                address.Fax = FaxTextBox.Text;
                address.Mobile = MobileTextBox.Text;

                registration.UserId = loginInfo.UserId;
                registration.UserName = loginInfo.UserName;
                registration.FirstName = FirstNameTextBox.Text;
                registration.MiddleName = MiddleNameTextBox.Text;
                registration.LastName = LastNameTextBox.Text;
                registration.CompanyName = CompanyNameTextBox.Text;
                registration.Address = address;
                registration.Email = EmailTextBox.Text;
                registration.Role = loginInfo.Role;
                registration.Status = loginInfo.Status;
                registrationService.Update(registration,loginInfo.UserId);
            }
            catch (Exception ex)
            {
                ErrorLiteral.Text = "Error in Update";
            }
            if (ErrorLiteral.Text == "")
                MessagesLabel.Text = "Profile Updated Successfully";
        }
}

    protected void CheckUniqueEmail(Object source, ServerValidateEventArgs args)
    {
        string email = args.Value;
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();
        RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];


        if (registrationService.IsEmailExists(email,loginInfo.UserId))
            args.IsValid = false;
        else
            args.IsValid = true;
    }

}

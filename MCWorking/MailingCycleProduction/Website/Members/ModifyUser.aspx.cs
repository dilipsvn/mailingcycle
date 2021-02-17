#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ModifyUser.aspx
    * Created Date      : 19/Dec/2007
	* Last Modify Date  : 19/Dec/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to update the profile of the User
	* Source			: MailingCycle\ModifyUser.aspx.cs

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

public partial class ModifyUser : System.Web.UI.Page
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

            RoleDropDownList.Items.Add(new ListItem(RegistrationService.UserRole.Agent.ToString(), Convert.ToInt32(RegistrationService.UserRole.Agent).ToString()));
            RoleDropDownList.Items.Add(new ListItem(RegistrationService.UserRole.Printer.ToString(), Convert.ToInt32(RegistrationService.UserRole.Printer).ToString()));
            RoleDropDownList.Items.Add(new ListItem(RegistrationService.UserRole.CSR.ToString(), Convert.ToInt32(RegistrationService.UserRole.CSR).ToString()));
            RoleDropDownList.Items.Add(new ListItem(RegistrationService.UserRole.Admin.ToString(), Convert.ToInt32(RegistrationService.UserRole.Admin).ToString()));
            RoleDropDownList.DataBind();

            if (Request.QueryString["UserId"] != "")
                InitializeValuesFromSession();
            else
                Response.Redirect("SearchUsers.aspx");
        }
    }


    protected void InitializeValuesFromSession()
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

        int userId = -1;


        if (Request.QueryString["UserId"] != "")
            userId = Convert.ToInt32(Request.QueryString["UserId"]);
        else
            Response.Redirect("SearchUsers.aspx");


        UserIdHiddenField.Value = userId.ToString();
        RegistrationService.RegistrationInfo registration = registrationService.GetDetails(userId);

        UserNameTextBox.Text = registration.UserName;

        foreach (ListItem listItem in RoleDropDownList.Items)
        {
            if (listItem.Text == registration.Role.ToString())
            {
                listItem.Selected = true;
                break;
            }
        }

        StatusTextBox.Text = registration.Status.ToString();

        if (StatusTextBox.Text == "ApprovalRequired")
            StatusTextBox.Text = "Approval Required";


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

                if (StatusTextBox.Text == "Approval Required")
                    StatusTextBox.Text = "ApprovalRequired";
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

                RegistrationService.RegistrationInfo registration = new RegistrationService.RegistrationInfo();

                // Get user's personal modified information.
                RegistrationService.StateInfo state = new RegistrationService.StateInfo();
                RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];


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

                registration.UserId = Convert.ToInt32(UserIdHiddenField.Value);
                registration.UserName = UserNameTextBox.Text;
                registration.FirstName = FirstNameTextBox.Text;
                registration.MiddleName = MiddleNameTextBox.Text;
                registration.LastName = LastNameTextBox.Text;
                registration.CompanyName = CompanyNameTextBox.Text;
                registration.Address = address;
                registration.Email = EmailTextBox.Text;
                registration.Role = (Irmac.MailingCycle.BLLServiceLoader.Registration.UserRole)Enum.Parse(typeof(Irmac.MailingCycle.BLLServiceLoader.Registration.UserRole), RoleDropDownList.SelectedValue, true);
                registration.Status = (Irmac.MailingCycle.BLLServiceLoader.Registration.RegistrationStatus)Enum.Parse(typeof(Irmac.MailingCycle.BLLServiceLoader.Registration.RegistrationStatus), StatusTextBox.Text, true);

                registrationService.Update(registration,loginInfo.UserId);

            }
            catch (Exception ex)
            {
                ErrorLiteral.Text = "Error in Update";
            }
            if (ErrorLiteral.Text == "")
                RedirectPage(Request.QueryString["PageName"]);
        }
    }


    private void RedirectPage(string pageName)
    {
        string selectedValue = Request.QueryString["selectedCriteria"];
        pageName = Request.QueryString["PageName"] + "?selectedCriteria=" + selectedValue + "&UserId=" + UserIdHiddenField.Value;
        Response.Redirect(pageName);
    }


    protected void CancelButton_Click(object sender, EventArgs e)
    {
        RedirectPage(Request.QueryString["PageName"]);
    }

    protected void CheckUniqueEmail(Object source, ServerValidateEventArgs args)
    {
        string email = args.Value;
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

        if (registrationService.IsEmailExists(email, Convert.ToInt32(UserIdHiddenField.Value)))
            args.IsValid = false;
        else
            args.IsValid = true;
    }

}

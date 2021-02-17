#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: RoleRegisteration.aspx
    * Created Date      : 11/09/2007
	* Last Modify Date  : 11/09/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to Register other roles
	* Source			: MailingCycle\RoleRegisteration.aspx.cs

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
using log4net;
using log4net.Config;
#endregion

public partial class RoleRegistration : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(RoleRegistration));
    #endregion

    #endregion

    #region Event Handlers

    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        Util.Validations.RegisterZipScriptBlock(Page.ClientScript, this.GetType(),
            CountryDropDownList.ClientID);

        if (!Page.IsPostBack)
        {

            try
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

                // Get the list of secret questions and populate.
                IList<CommonService.LookupInfo> secretQuestions = commonService.GetLookups("Secret Question");

                SecretQuestionDropDownList.DataSource = secretQuestions;
                SecretQuestionDropDownList.DataValueField = "LookupId";
                SecretQuestionDropDownList.DataTextField = "Name";
                SecretQuestionDropDownList.DataBind();
                //SecretQuestionDropDownList.Items.Add(new ListItem(" ", "100"));

                SecretQuestionDropDownList.Attributes.Add("onChange", "javascript: newQuestion(this);");

                RoleDropDownList.Items.Add(new ListItem(RegistrationService.UserRole.Printer.ToString(), Convert.ToInt32(RegistrationService.UserRole.Printer).ToString()));
                RoleDropDownList.Items.Add(new ListItem(RegistrationService.UserRole.CSR.ToString(), Convert.ToInt32(RegistrationService.UserRole.CSR).ToString()));
                RoleDropDownList.Items.Add(new ListItem(RegistrationService.UserRole.Admin.ToString(), Convert.ToInt32(RegistrationService.UserRole.Admin).ToString()));

                
                //RoleDropDownList.DataSource = Enum.GetValues(typeof(Irmac.MailingCycle.BLLServiceLoader.Registration.UserRole));
                //RoleDropDownList.DataBind();
            }
            catch (Exception ex)
            {
                log.Error("UNKNOWN ERROR:", ex);
                ErrorLiteral.Text = "An unknown error occurred. Please try again. If the problem persists, please contact your system administrator.";
            }
            if (Session["registrationInfo"] != null)
                InitializeValuesFromSession();
        }
        else
        {
            if ((SecQuestionHiddenField.Value != "") && (SecretQuestionDropDownList.SelectedValue == "13"))
            {
                SecretQuestionDropDownList.SelectedItem.Text = SecQuestionHiddenField.Value;
            }
        }
    }
    #endregion
    #region Custom Event Handler

    protected void InitializeValuesFromSession()
    {

        RegistrationService.RegistrationInfo registration = (RegistrationService.RegistrationInfo)Session["registrationInfo"];

        UserNameTextBox.Text = registration.UserName;
        EmailTextBox.Text = registration.Email;

        ListItem li = SecretQuestionDropDownList.Items.FindByText(registration.PasswordQuestion);
        if (li == null)
        {
            SecretQuestionDropDownList.SelectedValue = "13";
            SecretQuestionDropDownList.Items.FindByValue("13").Text = registration.PasswordQuestion;
            //SecretQuestionDropDownList.SelectedItem.Text = registration.PasswordQuestion;
        }
        else
            SecretQuestionDropDownList.SelectedValue = li.Value;

        SecretAnswerTextBox.Text = registration.PasswordAnswer;
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
        RoleDropDownList.SelectedValue = (Convert.ToInt32(registration.Role)).ToString();
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
            log.Error("UNKNOWN ERROR:", ex);
        }
    }

    protected void MembershipButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            CaptureValuesIntoSession();
            Response.Redirect("RoleRegistrationConf.aspx");
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Session["registrationInfo"] = null;
        Response.Redirect("Default.aspx");
    }

    protected void checkUserName(Object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length < 8)
        {
            args.IsValid = false;
            return;
        }
        if (args.Value.IndexOf(" ") >= 0)
        {
            args.IsValid = false;
            return;
        }
        args.IsValid = true;
    }

    protected void checkPassword(Object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length < 7 || args.Value.Length > 20)
        {
            args.IsValid = false;
            return;
        }
        args.IsValid = true;
    }

    private void CaptureValuesIntoSession()
    {

        // Get user's personal information.
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

        RegistrationService.RegistrationInfo registration = new RegistrationService.RegistrationInfo();
        registration.UserName = UserNameTextBox.Text;
        registration.Email = EmailTextBox.Text;
        registration.Password = PasswordTextBox.Text;
        if ((SecQuestionHiddenField.Value != "") && (SecretQuestionDropDownList.SelectedValue == "13"))
        {
            SecretQuestionDropDownList.SelectedItem.Text = SecQuestionHiddenField.Value;
        }

        registration.PasswordQuestion = SecretQuestionDropDownList.SelectedItem.Text;
        registration.PasswordAnswer = SecretAnswerTextBox.Text;


        registration.FirstName = FirstNameTextBox.Text;
        registration.MiddleName = MiddleNameTextBox.Text;
        registration.LastName = LastNameTextBox.Text;
        registration.CompanyName = CompanyNameTextBox.Text;
        registration.Address = address;
        registration.Status = Irmac.MailingCycle.BLLServiceLoader.Registration.RegistrationStatus.ApprovalRequired;
        registration.Role = (Irmac.MailingCycle.BLLServiceLoader.Registration.UserRole)Enum.Parse(typeof(Irmac.MailingCycle.BLLServiceLoader.Registration.UserRole), RoleDropDownList.SelectedValue, true);
        registration.CreditCard = null;

        Session["registrationInfo"] = registration;


    }

    protected void CheckUniqueUserName(Object source, ServerValidateEventArgs args)
    {
        string userName = args.Value;
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();


        if (registrationService.GetUserDetails(userName) != null)
            args.IsValid = false;
        else
            args.IsValid = true;
    }


    protected void CheckUniqueEmail(Object source, ServerValidateEventArgs args)
    {
        string email = args.Value;
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();


        if (registrationService.IsEmailExists(email,-1))
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    #endregion
    #endregion
}

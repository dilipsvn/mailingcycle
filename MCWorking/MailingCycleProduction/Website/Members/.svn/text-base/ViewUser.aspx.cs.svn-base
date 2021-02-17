#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ViewUser.aspx
    * Created Date      : 19/Dec/2007
	* Last Modify Date  : 19/Dec/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to update the profile of the User
	* Source			: MailingCycle\ViewUser.aspx.cs

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
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using TemplateParser;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Irmac.MailingCycle.BLLServiceLoader;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLL;
#endregion

public partial class ViewUser : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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

        if (registration.Status == Irmac.MailingCycle.BLLServiceLoader.Registration.RegistrationStatus.ApprovalRequired)
        {
            ApproveUserButton.Visible = true;
            RejectUserButton.Visible = true;

            //ApprovePanel.Visible = true;
        }
        else
        {
            //ActivatePanel.Visible = true;
            if (registration.Status == Irmac.MailingCycle.BLLServiceLoader.Registration.RegistrationStatus.Active)
            {
                InactivateUserButton.Visible = true;
                ActivateSpaceImage.Visible = false;
                ApproveSpaceImage.Visible = false;
                RejectSpaceImage.Visible = false;
            }
            else
            {
                ActivateUserButton.Visible = true;
                InActivateSpaceImage.Visible = false;
                ApproveSpaceImage.Visible = false;
                RejectSpaceImage.Visible = false;
            }
        }


        UserNameLabel.Text = registration.UserName;
        RoleLabel.Text  = registration.Role.ToString();
        FirstNameLabel.Text = registration.FirstName;
        MiddleNameLabel.Text = registration.MiddleName;
        LastNameLabel.Text = registration.LastName;
        CompanyNameLabel.Text = registration.CompanyName;
        Address1Label.Text = registration.Address.Address1;
        Address2Label.Text = registration.Address.Address2;
        CityLabel.Text = registration.Address.City;
        StateLabel.Text = registration.Address.State.Name;
        CountryLabel.Text = registration.Address.Country.Name;
        ZipLabel.Text = registration.Address.Zip;
        PhoneLabel.Text = registration.Address.Phone;
        MobileLabel.Text = registration.Address.Mobile;
        FaxLabel.Text = registration.Address.Fax;
        EmailLabel.Text = registration.Email;
        StatusLabel.Text = registration.Status.ToString();

        if (StatusLabel.Text == "ApprovalRequired")
            StatusLabel.Text = "Approval Required";

    }


    protected void EditUserButton_Click(object sender, EventArgs e)
    {
        string selectedValue = Request.QueryString["selectedCriteria"];
        Response.Redirect("ModifyUser.aspx?UserId=" + Request.QueryString["UserId"] 
            + "&selectedCriteria=" + selectedValue + "&PageName=ViewUser.aspx");
    }

    protected void InactivateUserButton_Click(object sender, EventArgs e)
    {
        try
        {
            ApproveRejectUser(RegistrationService.RegistrationStatus.Inactive);
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = "Error in Inactivating the user";
        }
        string selectedValue = Request.QueryString["selectedCriteria"];
        if (ErrorLiteral.Text == "")
            Response.Redirect("SearchUsers.aspx" + "?selectedCriteria=" + selectedValue);
    }

    protected void ActivateUserButton_Click(object sender, EventArgs e)
    {
        try
        {
            ApproveRejectUser(RegistrationService.RegistrationStatus.Active);
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = "Error in activating the user";
        }
        string selectedValue = Request.QueryString["selectedCriteria"];
        if (ErrorLiteral.Text == "")
            Response.Redirect("SearchUsers.aspx" + "?selectedCriteria=" + selectedValue);
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        string selectedValue = Request.QueryString["selectedCriteria"];
        if (ErrorLiteral.Text == "")
            Response.Redirect("SearchUsers.aspx" + "?selectedCriteria=" + selectedValue);
    }

    protected void ApproveUserButton_Click(object sender, EventArgs e)
    {
        try
        {
            ApproveRejectUser(RegistrationService.RegistrationStatus.Active);
            SendApproveEmail();
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = "Error in Approving the user";
        }
        string selectedValue = Request.QueryString["selectedCriteria"];
        if (ErrorLiteral.Text == "")
            Response.Redirect("SearchUsers.aspx" + "?selectedCriteria=" + selectedValue);
    }


    private void ApproveRejectUser(RegistrationService.RegistrationStatus status)
    {
            try
        {
            int userId;
            ErrorLiteral.Text = "";
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

            RegistrationService.RegistrationInfo registration = new RegistrationService.RegistrationInfo();
            RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];

            userId  = Convert.ToInt32(UserIdHiddenField.Value);
            registrationService.UpdateStatus(userId, status,loginInfo.UserId);
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = "Error in Update";
        }
    }


    protected void RejectUserButton_Click(object sender, EventArgs e)
    {
        try
        {
            int userId = Convert.ToInt32(UserIdHiddenField.Value);
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();
            RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];

            registrationService.DeleteUser(userId,loginInfo.UserId);
            SendRejectEmail();
            SendRejectEmailCSR();
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = "Error in Rejecting the user";
        }
        string selectedValue = Request.QueryString["selectedCriteria"];
        if (ErrorLiteral.Text == "")
            Response.Redirect("SearchUsers.aspx" + "?selectedCriteria=" + selectedValue);
    }


    protected void SendApproveEmail()
    {
        try
        {
            ///Creating HTML MAil from HTML Template
            Hashtable templateVars = new Hashtable();
            String emailTemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_AccountApproved.html";
            templateVars.Add("FIRST_NAME", FirstNameLabel.Text);
            templateVars.Add("LAST_NAME", LastNameLabel.Text);
            Parser parser = new Parser(emailTemplateFilePath, templateVars);

            string toAddress = EmailLabel.Text;
            string subject = "Your Account is Approved With Mailing Cycle";

            MailAddressCollection mailAddresses = new MailAddressCollection();
            mailAddresses.Add(toAddress);

            Util.Mail.Send(emailTemplateFilePath, templateVars, mailAddresses, subject, Request.ApplicationPath);
        }
        catch (Exception ex)
        {
            //log.Error("User Approve Email Sending Failed", ex);
            ErrorLiteral.Text = "User Approve Email Sending Failed !!! ";
        }
    }

    protected void SendRejectEmail()
    {
        try
        {
            ///Creating HTML MAil from HTML Template
            Hashtable templateVars = new Hashtable();
            String emailTemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_AccountRejected.html";
            templateVars.Add("FIRST_NAME", FirstNameLabel.Text);
            templateVars.Add("LAST_NAME", LastNameLabel.Text);
            Parser parser = new Parser(emailTemplateFilePath, templateVars);

            string toAddress = EmailLabel.Text;
            string subject = "Your Account is Rejected With Mailing Cycle";

            MailAddressCollection mailAddresses = new MailAddressCollection();
            mailAddresses.Add(toAddress);

            Util.Mail.Send(emailTemplateFilePath, templateVars, mailAddresses, subject, Request.ApplicationPath);
        }
        catch (Exception ex)
        {
            //log.Error("User Reject Email Sending Failed", ex);
            ErrorLiteral.Text = "User Reject Email Sending Failed !!! ";
        }
    }

    protected void SendRejectEmailCSR()
    {
        try
        {
            ///Creating HTML MAil from HTML Template
            Hashtable templateVars = new Hashtable();
            String emailTemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_AccountRejected_CSR.html";
            templateVars.Add("USER_NAME", UserNameLabel.Text);
            templateVars.Add("FIRST_NAME", FirstNameLabel.Text);
            templateVars.Add("LAST_NAME", LastNameLabel.Text);
            templateVars.Add("EMAIL", EmailLabel.Text);
            Parser parser = new Parser(emailTemplateFilePath, templateVars);

            string toAddress = EmailLabel.Text;
            string subject = "Account is Rejected With Mailing Cycle";

            // Send email to all the CSR's.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService commonService = serviceLoader.GetCommon();
            IList<CommonService.RegistrationInfo> users =
                commonService.GetUsersByRole(CommonService.UserRole.CSR.ToString());

            MailAddressCollection mailAddresses = new MailAddressCollection();
            foreach (CommonService.RegistrationInfo user in users)
            {
                mailAddresses.Add(user.Email);
            }

            if(mailAddresses.Count>0)
            Util.Mail.Send(emailTemplateFilePath, templateVars, mailAddresses, subject, Request.ApplicationPath);
        }
        catch (Exception ex)
        {
            //log.Error("User Reject Email Sending Failed", ex);
            ErrorLiteral.Text = "User Reject Email Sending Failed !!! ";
        }
    }

}

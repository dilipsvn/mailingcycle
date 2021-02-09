#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ForgotUserPassword.aspx
    * Created Date      : 30/Aug/2007
	* Last Modify Date  : 30/Aug/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to Register the Realtor
	* Source			: MailingCycle\ForgotUserPassword.aspx.cs

	****************************************************************/
#endregion

#region Namespaces
using System.Net.Mail;
using System.Net;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
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
using Irmac.MailingCycle.BLL;
using TemplateParser;
using TemplateParser.Modificators;
using log4net;
#endregion

public partial class ForgotUserPassword : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(ForgotUserPassword));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();
    RegistrationService.RegistrationInfo registrationInfo = 
        new RegistrationService.RegistrationInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;
    }

    private bool IsUserExists(string userName)
    {
        bool isValid = false;

        try
        {
            RegistrationService.RegistrationService registrationService =
                serviceLoader.GetRegistration();
            registrationInfo = registrationService.GetUserDetails(userName);

            if (registrationInfo != null)
            {
                ViewState.Add("RegistrationInfo", registrationInfo);

                isValid = true;
            }
        }
        catch (Exception ex)
        {
            log.Error("Unknown Error", ex);
        }

        return isValid;
    }

    protected void ForgetPwdStep1Button_Click(object sender, EventArgs e)
    {
        if (IsUserExists(UserNameTextBox.Text) == true)
        {
            PageDescriptionLabel.Text = "Provide the answer you had entered while registration.";

            ForgetPwdStep1Panel.Visible = false;
            ForgetPwdStep2Panel.Visible = true;
            ForgetPwdStep3Panel.Visible = false;

            SecurityQuestion.Text = registrationInfo.PasswordQuestion + "?";
        }
        else
        {
            ErrorMessageLabel.Text = "Error: Invalid User Name";
            ErrorMessageLabel.Visible = true;
        }
    }

    private bool SendPasswordEmail()
    {
        bool result = false;

        try
        {
            // Creating HTML Mail from HTML Template.
            Hashtable templateVars = new Hashtable();

            templateVars.Add("FIRST_NAME", registrationInfo.FirstName);
            templateVars.Add("PASSWORD", registrationInfo.Password);
            templateVars.Add("URL", CommonEvents.GetDynamicPath(Request));

            Parser parser = new Parser(AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_ForgotPassword.html", 
                templateVars);

            // Creating Mail Message Body.
            MailMessage mailmsg = new MailMessage();

            mailmsg.To.Add(registrationInfo.Email);
            mailmsg.From = new MailAddress("MailingCycle@MailingCycle.com");
            mailmsg.Subject = "Your Mailing Cycle Account Password";
            mailmsg.IsBodyHtml = true;
            mailmsg.Body = parser.Parse();
            mailmsg.Priority = MailPriority.Normal;

            Configuration config = 
                WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
            MailSettingsSectionGroup mailSettings = 
                config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;

            if (mailSettings != null)
            {
                int port = mailSettings.Smtp.Network.Port;
                string host = mailSettings.Smtp.Network.Host;
                string password = mailSettings.Smtp.Network.Password;
                string username = mailSettings.Smtp.Network.UserName;

                SmtpClient smtpclient = new SmtpClient(host, 587);
                smtpclient.Credentials = new NetworkCredential(username, password);
                smtpclient.EnableSsl = true;

                smtpclient.Send(mailmsg);
            }

            result = true;
        }
        catch (Exception ex)
        {
            PageDescriptionLabel.Text = "Failure sending email.";
            SuccessText.InnerHtml = "Unable to reset your password due to failure in sending mail." +
                "<br /><br />Please try again or contact your system administrator.";

            log.Error("Unknown Error", ex);
        }

        return result;
    }

    protected void ForgetPwdStep2Button_Click(object sender, EventArgs e)
    {
        registrationInfo = 
            (RegistrationService.RegistrationInfo)ViewState["RegistrationInfo"];

        if (SecurityAnswerTextBox.Text == registrationInfo.PasswordAnswer)
        {
            PageDescriptionLabel.Text = "Email message has been sent to your email address.";
            SuccessText.InnerHtml = "An email message with reset password has been sent to " +
                "the email address you provided during registration.<br /><br />" +
                "If you do not receive reset password email from us, please check your " +
                "spam, bulk, or junk mail folders. If you find the email there, your " +
                "ISP or your own software spam-blocker or filters are diverting our email.";

            ForgetPwdStep1Panel.Visible = false;
            ForgetPwdStep2Panel.Visible = false;
            ForgetPwdStep3Panel.Visible = true;

            // Generate a new password and save it.
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            registrationInfo.Password = password;

            RegistrationService.RegistrationService registrationService =
                serviceLoader.GetRegistration();
            registrationService.UpdatePassword(registrationInfo);

            // Send email to the user.
            SendPasswordEmail();
        }
        else
        {
            ErrorMessageLabel.Text = "Error: Invalid Secret Answer";
            ErrorMessageLabel.Visible = true;
        }
    }
}

#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: RoleRegisteration.aspx
    * Created Date      : 11/09/2007
	* Last Modify Date  : 11/09/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to Register the other role
	* Source			: MailingCycle\RoleRegisteration.aspx.cs

	****************************************************************/
#endregion

#region Namespaces
using mailService = System.Net.Mail;
using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;
using Irmac.MailingCycle.BLLServiceLoader;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using OrderService = Irmac.MailingCycle.BLLServiceLoader.Order;
using Irmac.MailingCycle.BLL;
using registrationdal = Irmac.MailingCycle.DAL;
using TemplateParser;
using TemplateParser.Modificators;
using log4net;
using log4net.Config;

#endregion


public partial class RoleRegistrationConf : System.Web.UI.Page
{

    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(RoleRegistrationConf));
    #endregion


    #endregion

    #region Event Handlers

    #region Page Event Handler
    protected void Page_Load(object sender, EventArgs e)
    {

        CancelButton.Attributes.Add("onClick", "return cancelRegistration()");
        if (!Page.IsPostBack)
        {

            if (Session["registrationInfo"] != null)
            {
                RegistrationService.RegistrationInfo registration = (RegistrationService.RegistrationInfo)Session["registrationInfo"];

                UserNameLabel.Text = registration.UserName;
                Emailabel.Text = registration.Email;
                RoleLabel.Text = registration.Role.ToString();
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
            }
        }

    }
    #endregion

    #region Custom Event Handler
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Session["registrationInfo"] = null;
        Response.Redirect("Default.aspx");
    }

    protected void FinishButton_Click(object sender, EventArgs e)
    {
        ErrorLiteral.Text = "";
        RegistrationService.RegistrationInfo registration = (RegistrationService.RegistrationInfo)Session["registrationInfo"];
        int userId = 0;

        try
        {

            // Insert the registration details

            // Get the service loader
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();

            RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();
            userId = registrationService.Insert(registration);
        }
        catch (Exception ex)
        {
            log.Error("User Registration is not sucessful", ex);
            ErrorLiteral.Text = "User registration failed";
        }

        if (ErrorLiteral.Text == "")
        {
            RegistrationService.LoginInfo loginInfo = new RegistrationService.LoginInfo();
            loginInfo.UserId = userId;
            loginInfo.UserName = registration.UserName;
            loginInfo.FirstName = registration.FirstName;
            loginInfo.LastName = registration.LastName;
            loginInfo.Role = registration.Role;
            loginInfo.Status = registration.Status;

            SendRegistrationEmail(registration);
            Session["registrationInfo"] = null;
            Response.Redirect("RoleRegistrationThanks.aspx");
        }
    }

    protected void SendRegistrationEmail(RegistrationService.RegistrationInfo registration)
    {
        try
        {
            string URLAddress = "";
            URLAddress = CommonEvents.GetDynamicPath(Request);
            ///Creating HTML MAil from HTML Template
            Hashtable templateVars = new Hashtable();
            String emailTemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_CreateAccount_OtherRoles.html";
            templateVars.Add("FIRST_NAME", registration.FirstName);
            templateVars.Add("LAST_NAME", registration.LastName);
            templateVars.Add("USER_NAME", registration.UserName);
            templateVars.Add("PASSWORD", registration.Password);
            templateVars.Add("URL", URLAddress);
            templateVars.Add("IMAGE_PATH", AppDomain.CurrentDomain.BaseDirectory);
            Parser parser = new Parser(emailTemplateFilePath, templateVars);

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService cs = serviceLoader.GetCommon();
            IList<CommonService.LookupInfo> info = cs.GetLookups("FeedBackEmailTo");
            string toAddress = info[1].Name;

            //Creating Mail Message Body
            MailMessage mailmsg = new MailMessage();
            mailmsg.To.Add(registration.Email);
            mailmsg.Bcc.Add("shailu521@yahoo.com");
            mailmsg.From = new MailAddress("MailingCycle@MailingCycle.com");
            mailmsg.Subject = "MailingCycle Registration Confirmation";
            mailmsg.IsBodyHtml = true;
            mailmsg.Body = parser.Parse();
            mailmsg.Priority = MailPriority.Normal;

            Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);

            MailSettingsSectionGroup mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
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

        }
        catch (Exception ex)
        {
            log.Error("User Registration Email Sending Failed", ex);
            ErrorLiteral.Text = "User registration Successful. But Confirmation email could not be sent !!! ";
        }
    }


    #endregion

    #endregion

}

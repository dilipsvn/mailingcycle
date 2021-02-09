#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: AgentRegisteration.aspx
    * Created Date      : 30/Aug/2007
	* Last Modify Date  : 30/Aug/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to Register the Realtor
	* Source			: MailingCycle\AgentRegisteration.aspx.cs

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


public partial class AgentRegistrationConf : System.Web.UI.Page
{

    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(AgentRegistrationConf));
    #endregion


    #endregion

    #region Event Handlers

    #region Page Event Handler
    protected void Page_Load(object sender, EventArgs e)
    {

        CancelButton.Attributes.Add("onClick", "return cancelRegistration()");
        if (!Page.IsPostBack)
        {

            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService commonService = serviceLoader.GetCommon();


            // Get the Membership fee
            CommonService.PropertyInfo property = commonService.GetProperty("Membership Fee");
            MembershipFeeLabel.Text = property.Value.ToString();

            if (Session["registrationInfo"] != null)
            {
                RegistrationService.RegistrationInfo registration = (RegistrationService.RegistrationInfo)Session["registrationInfo"];

                UserNameLabel.Text = registration.UserName;
                Emailabel.Text = registration.Email;
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

                CardTypeLabel.Text = registration.CreditCard.Type.Name;
                CardNumberLabel.Text = registration.CreditCard.Number.Substring(registration.CreditCard.Number.Length - 4).PadLeft(registration.CreditCard.Number.Length, '*');
                ExpiryDateLabel.Text = registration.CreditCard.ExpirationMonth + " " + registration.CreditCard.ExpirationYear;
                DateTime expiryDate = DateTime.Parse(ExpiryDateLabel.Text);
                ExpiryDateLabel.Text = expiryDate.ToString("y");
                CardHolderNameLabel.Text = registration.CreditCard.HolderName;
                BillingAddress1Label.Text = registration.CreditCard.Address.Address1;
                BillingAddress2Label.Text = registration.CreditCard.Address.Address2;
                BillingCityLabel.Text = registration.CreditCard.Address.City;
                BillingCountryLabel.Text = registration.CreditCard.Address.Country.Name;
                BillingStateLabel.Text = registration.CreditCard.Address.State.Name;
                BillingZipLabel.Text = registration.CreditCard.Address.Zip;


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
        int userId=0;
        OrderService.OrderInfo orderInfo = new OrderService.OrderInfo();
        int membershipFee;

        try
        {

            // Get the service loader
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();

            CommonService.CommonService commonService = serviceLoader.GetCommon();
            // Get the Membership fee
            CommonService.PropertyInfo property = commonService.GetProperty("Membership Fee");
            membershipFee = Convert.ToInt32(property.Value);


            // Insert the registration details


           RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();
           userId = registrationService.Insert(registration);


            // Insert the membership details

           if (registration.Role == Irmac.MailingCycle.BLLServiceLoader.Registration.UserRole.Agent)
           {
               try
               {
                   OrderService.CreditCardInfo creditCard = new OrderService.CreditCardInfo();

                   OrderService.StateInfo billingState = new OrderService.StateInfo();
                   billingState.StateId = registration.Address.State.StateId;
                   billingState.Name = registration.Address.State.Name;

                   OrderService.CountryInfo billingCountry = new OrderService.CountryInfo();
                   billingCountry.CountryId = registration.Address.Country.CountryId;
                   billingCountry.Name = registration.Address.Country.Name;

                   OrderService.AddressInfo billingAddress = new OrderService.AddressInfo();
                   billingAddress.Address1 = registration.Address.Address1;
                   billingAddress.Address2 = registration.Address.Address2;
                   billingAddress.City = registration.Address.City;
                   billingAddress.State = billingState;
                   billingAddress.Zip = registration.Address.Zip;
                   billingAddress.Country = billingCountry;

                   OrderService.LookupInfo creditCardType = new OrderService.LookupInfo();
                   creditCardType.LookupId = registration.CreditCard.Type.LookupId;
                   creditCardType.Name = registration.CreditCard.Type.Name;

                   creditCard.Type = creditCardType;
                   creditCard.Number = registration.CreditCard.Number;
                   creditCard.CvvNumber = registration.CreditCard.CvvNumber;
                   creditCard.HolderName = registration.CreditCard.HolderName;
                   creditCard.ExpirationMonth = registration.CreditCard.ExpirationMonth;
                   creditCard.ExpirationYear = registration.CreditCard.ExpirationYear;
                   creditCard.Address = billingAddress;

                   orderInfo.Number = 100;
                   orderInfo.Type = Irmac.MailingCycle.BLLServiceLoader.Order.OrderType.MembershipFee;
                   orderInfo.Date = DateTime.Now;
                   orderInfo.Amount = membershipFee;
                   orderInfo.CreditCard = creditCard;
                   orderInfo.TransactionCode = -1;
                   orderInfo.TransactionMessage = "Dummy Transaction";
                   orderInfo.Items = null;

                   OrderService.OrderService orderService = serviceLoader.GetOrder();
                   orderService.Insert(userId, orderInfo,userId);
               }
               catch (Exception ex)
               {
                   log.Error("Transaction is not sucessful",ex);
                   ErrorLiteral.Text = "credit card transaction failed";
               }
           }
        }
        catch (Exception ex)
        {
            log.Error("User Registration is not sucessful",ex);
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
            Session["loginInfo"] = loginInfo;
            Response.Redirect("AgentRegistrationThanks.aspx");
        }
    }

    protected void SendRegistrationEmail(RegistrationService.RegistrationInfo registration)
    {
        bool IsDevelopmentPC = true;
        string URLAddress = "";
        try
        {
            URLAddress = CommonEvents.GetDynamicPath(Request);
            ///Creating HTML MAil from HTML Template
            Hashtable templateVars = new Hashtable();
            String emailTemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_CreateAccount.html";
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

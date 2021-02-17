#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: Feedback.aspx
    * Created Date      : 02/Nov/2007
	* Last Modify Date  : 02/Nov/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to get the feedback
	* Source			: MailingCycle\Feedback.aspx.cs

	****************************************************************/
#endregion

#region Namespaces

using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TemplateParser;
using System.Net;
using System.Net.Mail;
using Irmac.MailingCycle.BLLServiceLoader;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using log4net;
using log4net.Config;

#endregion

public partial class Members_Feedback : System.Web.UI.Page
{
    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Members_Feedback));
    #endregion

    # region Eventhandlers

    protected void Page_Load(object sender, EventArgs e)
    {
        Util.Validations.RegisterZipScriptBlock(Page.ClientScript, this.GetType(),
            CountryDropDownList.ClientID);

        if (!IsPostBack)
        {
            try
            {
                CommonEvents.LoadCountries(CountryDropDownList);
                CountryDropDownList.Items.FindByText("United States").Selected = true;
                CountryDropDownList_SelectedIndexChanged(CountryDropDownList, new EventArgs());
            }
            catch (Exception ex)
            {
                log.Error("UNKNOWN ERROR:", ex);
                ErrorLiteral.Text = "An unknown error occurred. Please try again. If the problem persists, please contact your system administrator.";
            }
        }
    }

    protected void CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList countryDropDownList = (DropDownList)sender;
            CommonEvents.LoadStates(countryDropDownList, StateDropDownList);
        }
        catch (Exception ex)
        {
            log.Error("UNKNOWN ERROR:", ex);
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        SendFeedBackMail();
        ClearText();
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    private void SendFeedBackMail()
    {
        try
        {
            ///Creating HTML MAil from HTML Template
            bool IsDevelopmentPC = true;
            string URLAddress = CommonEvents.GetDynamicPath(Request);
            Hashtable templateVars = new Hashtable();
            templateVars.Add("FIRSTNAME", FirstNameTextBox.Text.Trim());
            templateVars.Add("LASTNAME", LastNameTextBox.Text.Trim());
            templateVars.Add("MIDDLENAME", MiddleNameTextBox.Text.Trim());
            templateVars.Add("ADDRESS1", AddressLine1TextBox.Text.Trim());
            templateVars.Add("ADDRESS2", AddressLine2TextBox.Text.Trim());
            templateVars.Add("CITY", CityTextBox.Text.Trim());
            templateVars.Add("STATE", StateDropDownList.SelectedItem.Text);
            templateVars.Add("COUNTRY", CountryDropDownList.SelectedItem.Text);
            templateVars.Add("ZIPCODE", ZipTextBox.Text.Trim());
            templateVars.Add("PHONE", PhoneTextBox.Text.Trim());
            templateVars.Add("MOBILE", MobileTextBox.Text.Trim());
            templateVars.Add("FAX", FaxTextBox.Text.Trim());
            templateVars.Add("EMAIL", EmailTextBox.Text.Trim());
            templateVars.Add("COMPANYNAME", CompanyNameTextBox.Text.Trim());
            templateVars.Add("COMMENTS", CommentsTextBox.Text.Trim());
            templateVars.Add("URL", URLAddress);
            templateVars.Add("IMAGE_PATH", AppDomain.CurrentDomain.BaseDirectory);
            Parser parser = new Parser(AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_Feedback.html", templateVars);
            SendEmail(parser.Parse(),false);

            templateVars = new Hashtable();
            templateVars.Add("FIRSTNAME", FirstNameTextBox.Text.Trim());
            templateVars.Add("LASTNAME", LastNameTextBox.Text.Trim());
            templateVars.Add("MIDDLENAME", MiddleNameTextBox.Text.Trim());
            templateVars.Add("URL", URLAddress);
            templateVars.Add("IMAGE_PATH", AppDomain.CurrentDomain.BaseDirectory);
            parser = new Parser(AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_Feedback_User.html", templateVars);
            SendEmail(parser.Parse(),true);
        }
        catch (Exception ex)
        {
            log.Error("Unknown Error", ex);
            ErrorLiteral.Text = "Feedback could not be sent. Please try again.";
        }
    }

    private void SendEmail(string mailBody,bool toUser)
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        CommonService.CommonService cs = serviceLoader.GetCommon();
        MailMessage mailmsg = new MailMessage();
        if (!toUser)
        {
            IList<CommonService.LookupInfo> info = cs.GetLookups("FeedBackEmailTo");
            string toAddress = info[1].Name;

            //Creating Mail Message Body

            mailmsg.To.Add(toAddress);
            mailmsg.From = new MailAddress(EmailTextBox.Text.Trim(), FirstNameTextBox.Text.Trim());
            mailmsg.Subject = "Feedback for MailingCycle";
        }
        else
        {
            mailmsg.To.Add(EmailTextBox.Text.Trim());
            mailmsg.From = new MailAddress("MailingCycle@MailingCycle.com");
            mailmsg.Subject = "Thankyou for your feedback";
        }
        mailmsg.IsBodyHtml = true;
        mailmsg.Body = mailBody;
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

        MessagesLabel.Text = "Feedback sent successfully. Thank you.";
    }

    private void ClearText()
    {
        FirstNameTextBox.Text = "";
        LastNameTextBox.Text = "";
        MiddleNameTextBox.Text = "";
        AddressLine1TextBox.Text = "";
        AddressLine2TextBox.Text = "";
        CityTextBox.Text = "";
        StateDropDownList.SelectedIndex = 0;
        CountryDropDownList.SelectedIndex = 0;
        ZipTextBox.Text = "";
        PhoneTextBox.Text = "";
        MobileTextBox.Text = "";
        FaxTextBox.Text = "";
        EmailTextBox.Text = "";
        CompanyNameTextBox.Text = "";
        CommentsTextBox.Text = "";

    }
    #endregion
}

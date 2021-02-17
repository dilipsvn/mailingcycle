#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: UserLogin.aspx
    * Created Date      : 30/Aug/2007
	* Last Modify Date  : 22/Sep/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to Login
	* Source			: MailingCycle\UserLogin.aspx.cs

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
#endregion


public partial class UserLogin : System.Web.UI.Page
{

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        RegistrationService.LoginInfo loginInfo = new RegistrationService.LoginInfo();

        string userName;
        string password;

        userName = UserNameTextBox.Text;
        password = PasswordTextBox.Text;

        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

        loginInfo = registrationService.Login(userName, password);

        if (loginInfo != null)
        {
            Session["loginInfo"] = loginInfo;
            Response.Redirect("~/Members/Welcome.aspx");
        }
        else
        {
            ErrorLiteral.Text = "Error: Invalid UserName or Password";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Message"] == "SessionExpired")
                MessageLabel.Text = "Session Expired....Please Login Again!<br><br>";

            //UserNameTextBox.Text = "agent";
            //PasswordTextBox.Text = "agent123";
        }
    }
}

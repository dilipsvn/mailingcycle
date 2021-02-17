#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ChangeUserPassword.aspx
    * Created Date      : 30/Aug/2007
	* Last Modify Date  : 27/Sep/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to change the password of the Realtor
	* Source			: MailingCycle\Agent\ChangeUserPassword.aspx.cs

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
using Irmac.MailingCycle.BLL;
#endregion

public partial class ChangeUserPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                ErrorLiteral.Text = "";
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
                RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

                RegistrationService.RegistrationInfo registration = registrationService.GetDetails(loginInfo.UserId);
                if (OldPasswordTextBox.Text == registration.Password)
                {
                    if (OldPasswordTextBox.Text == NewPasswordTextBox.Text)
                    {
                        ErrorLiteral.Text = "Error: New password cannot be same as Old";
                    }
                    else
                    {
                        registration.Password = NewPasswordTextBox.Text;
                        registrationService.UpdatePassword(registration);
                    }
                }
                else
                {
                    ErrorLiteral.Text = "Error: Invalid Old Password";
                }
                if (ErrorLiteral.Text == "")
                    MessagesLabel.Text = "Password Updated Successfully";
            }
        }
        catch (Exception ex)
        {

        }
       
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
}

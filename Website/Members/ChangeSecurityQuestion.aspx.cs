#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ChangeSecruityQuestion.aspx
    * Created Date      : 30/Aug/2007
	* Last Modify Date  : 27/Sep/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to change the secruity details of the Realtor
	* Source			: MailingCycle\Agent\ChangeSecruityQuestion.aspx.cs

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
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLL;
#endregion

public partial class ChangeSecurityQuestion : System.Web.UI.Page
{
    RegistrationService.RegistrationInfo registration;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            // Get the common web service instance.

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService commonService = serviceLoader.GetCommon();

            // Get the list of secret questions and populate.
            IList<CommonService.LookupInfo> secretQuestions = commonService.GetLookups("Secret Question");

            SecretQuestionDropDownList.DataSource = secretQuestions;
            SecretQuestionDropDownList.DataValueField = "LookupId";
            SecretQuestionDropDownList.DataTextField = "Name";
            SecretQuestionDropDownList.DataBind();
            //SecretQuestionDropDownList.Items.Add(new ListItem(" ", "100"));


            RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

            registration = registrationService.GetDetails(loginInfo.UserId);



            ListItem questionItem = new ListItem();
            questionItem = SecretQuestionDropDownList.Items.FindByText(registration.PasswordQuestion);

            if (questionItem == null)
            {
                //SecretQuestionDropDownList.SelectedValue = "13";
                //SecretQuestionDropDownList.Items.FindByValue("13").Text = registration.PasswordQuestion;
            }
            else
                //SecretQuestionDropDownList.SelectedValue = questionItem.Value;


            //SecretAnswerTextBox.Text = registration.PasswordAnswer;
            SecretQuestionDropDownList.Attributes.Add("onChange", "javascript: newQuestion(this);");
        }
        else
        {
            if ((SecQuestionHiddenField.Value != "") && (SecretQuestionDropDownList.SelectedValue == "13"))
            {
                SecretQuestionDropDownList.SelectedItem.Text = SecQuestionHiddenField.Value;
            }
        }

    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            ErrorLiteral.Text = "";
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            RegistrationService.RegistrationService registrationService = serviceLoader.GetRegistration();

            RegistrationService.RegistrationInfo registration = registrationService.GetDetails(loginInfo.UserId);

            if (PasswordTextBox.Text == registration.Password)
            {
                registration.PasswordQuestion = SecretQuestionDropDownList.SelectedItem.Text;
                registration.PasswordAnswer = SecretAnswerTextBox.Text;
                registrationService.UpdateSecretDetails(registration);
            }
            else
            {
                ErrorLiteral.Text = "Error: Invalid Password";
            }

        }
        catch (Exception ex)
        {

        }
        if (ErrorLiteral.Text == "")
            MessagesLabel.Text = "Secret details Updated Successfully";
    }

}

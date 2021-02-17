#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ChangeRegistrationFee.aspx
    * Created Date      : 11/Dec/2007
	* Last Modify Date  : 11/Dec/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to add/update the registration fee details
	* Source			: MailingCycle\ChangeRegisterationfee.aspx.cs

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
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLL;
using System.Text.RegularExpressions;
#endregion

public partial class Members_ChangeRegistrationFee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RegistrationFeeTextBoxRFValidator.Enabled = false;
            FeeRegularExpressionValidator.Enabled = false;
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService commonService = serviceLoader.GetCommon();


            // Get the Membership fee
            CommonService.PropertyInfo property = commonService.GetProperty("Membership Fee");

            if (property != null)
            {
                if (property.Value.ToString() != "" && property.Value.ToString() != null)
                {
                    RegistrationFeeLabel.Visible = true;
                    RegistrationFeeLabel.Text = property.Value.ToString();
                    EditFeeButton.Visible = true;
                    SaveFeeButton.Visible = false;
                }
            }
            else
            {
                AddRegistrationFeeButton.Visible = true;
            }
        }
    }

    protected void SaveFeeButton_Click(object sender, EventArgs e)
    {

        // Get the common web service instance.
        RegistrationFeeTextBoxRFValidator.Enabled = true;
        RegistrationFeeTextBoxRFValidator.Validate();
        FeeRegularExpressionValidator.Enabled = true;
        FeeRegularExpressionValidator.Validate();
        if (Page.IsValid)
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService commonService = serviceLoader.GetCommon();

            commonService.InsertProperty("Membership Fee", RegistrationFeeTextBox.Text);
            Response.Redirect("ChangeRegistrationFee.aspx");
        }
    }

    protected void EditFeeButton_Click(object sender, EventArgs e)
    {
        RegistrationFeeLabel.Visible = false;
        RegistrationFeeTextBox.Visible = true;
        RegistrationFeeTextBox.Text = RegistrationFeeLabel.Text;
        EditFeeButton.Visible = false;
        SaveFeeButton.Visible = true;
        CancelButton.Visible = true;
    }

    protected void AddRegistrationFee_Click(object sender, EventArgs e)
    {
        AddRegistrationFeeButton.Visible = false;
        RegistrationFeeLabel.Visible = false;
        RegistrationFeeTextBox.Visible = true;
        EditFeeButton.Visible = false;
        SaveFeeButton.Visible = true;
        CancelButton.Visible = true;
    }

}

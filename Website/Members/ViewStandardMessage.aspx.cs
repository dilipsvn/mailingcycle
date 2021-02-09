#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ViewCustomMessage.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to display the custom messages
	* Source			: MailingCycle\ViewCustomMessage.aspx.cs

	****************************************************************/
#endregion

#region Namespaces
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLLServiceLoader.Message;
using Irmac.MailingCycle.BLLServiceLoader;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader.Registration;
#endregion

public partial class ViewStandardMessage : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(ViewStandardMessage));

    #region Properties
    public bool IsAdminRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Admin);
        }
    }
    public bool IsAgentRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Agent);
        }
    }
    #endregion

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MessageInfo dataSource = (MessageInfo)Session["SelectedMessage"];
            MessageIdLabel.Text = dataSource.MessageId.ToString();
            ShortDescLabel.Text = dataSource.ShortDesc;
            StatusLabel.Text = dataSource.Status.ToString();
            MessageTextLiteralText.Text = dataSource.MessageText;
            DefaultMessageLabel.Text = dataSource.IsDefaultMessage.ToString();
            if (IsAdminRole)
            {
                DeleteButton.Visible = true;
                EditButton.Visible = true;
                if (dataSource.EventInProgress)
                {
                    DeleteButton.Enabled = false;
                    EditButton.Enabled = false;
                }
                else if (dataSource.UsageCount > 0 || dataSource.IsDefaultMessage)
                {
                    DeleteButton.Enabled = false;
                }
                else
                {
                    DeleteButton.Enabled = true;
                    EditButton.Enabled = true;
                }
            }
            if (!IsAgentRole)
            {
                StatusPanel.Visible = true;
            }
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/MessageManagement.aspx");
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        MessageService msgService = serviceLoader.GetMessage();
        try
        {
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            int deletedBy = regInfo.UserId;
            msgService.DeleteMessage(Convert.ToInt32(MessageIdLabel.Text), deletedBy, deletedBy);
            Response.Redirect("~/Members/MessageManagement.aspx");
        }
        catch (Exception ex)
        {
            log.Error("Unknown Error", ex);
            ErrorMessageLabel.Text = "Unable to delete the message";
        }
    }
    protected void EditButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateStandardMessage.aspx?fromModify=1&fromPage=EditMessage");
    }
    #endregion
}

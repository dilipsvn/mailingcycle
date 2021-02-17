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
using Irmac.MailingCycle.BLLServiceLoader.Message;
using Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLLServiceLoader;
using log4net;
#endregion

public partial class ViewCustomMessage : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(ViewCustomMessage));

    #region Properties
    public bool IsAgentRole
    {
        get
        {
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            return (regInfo.Role == UserRole.Agent);
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            DeleteButton.Visible = true;
            EditButton.Visible = true;
            MessageInfo dataSource = (MessageInfo)Session["SelectedMessage"];
            MessageIdLabel.Text = dataSource.MessageId.ToString();
            ShortDescLabel.Text = dataSource.ShortDesc;
            StatusLabel.Text = dataSource.Status.ToString();
            if (dataSource.EventInProgress)
            {
                DeleteButton.Enabled = false;
                EditButton.Enabled = false;
            }
            else if (dataSource.UsageCount > 0)
            {
                DeleteButton.Enabled = false;
            }
            else
            {
                DeleteButton.Enabled = true;
                EditButton.Enabled = true;
            }
            if (dataSource.IsImage)
            {             
                MessageImagePanel.Visible = true;
                MessageTextPanel.Visible = false;
                LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
                string userId = regInfo.UserId.ToString();                
                MessageImage.ImageUrl = "/Members/UserData/" + userId + "/Images/" + dataSource.FileName;
            }
            else
            {                
                MessageImagePanel.Visible = false;
                MessageTextPanel.Visible = true;
                MessageTextLiteralText.Text = dataSource.MessageText;                
            }
            if (!IsAgentRole)
            {
                AgentLabel.Text = "Selected Agent: " + Convert.ToString(Session["SelectedAgentName"]);
                AgentLabel.Visible = true;
            }
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        if (!IsAgentRole)
            Response.Redirect("CustomMessages.aspx?userId=" + Convert.ToInt32(Request.QueryString["userId"]));
        else
            Response.Redirect("CustomMessages.aspx");
    }

    protected void EditButton_Click(object sender, EventArgs e)
    {
        if (!IsAgentRole)
            Response.Redirect("~/Members/CreateCustomMessage.aspx?fromModify=1&fromPage=EditMessage&userId=" 
                + Convert.ToInt32(Request.QueryString["userId"]));
        else
            Response.Redirect("~/Members/CreateCustomMessage.aspx?fromModify=1&fromPage=EditMessage");
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        MessageService msgService = serviceLoader.GetMessage();
        try
        {
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            int deletedBy = regInfo.UserId;
            int userId = IsAgentRole ? deletedBy : Convert.ToInt32(Request.QueryString["userId"]);
            msgService.DeleteMessage(Convert.ToInt32(MessageIdLabel.Text),userId,deletedBy);
            Response.Redirect("CustomMessages.aspx?userId=" + Convert.ToInt32(Request.QueryString["userId"]));
        }
        catch (Exception ex)
        {
            log.Error("Unknown Error", ex);
            ErrorMessageLabel.Text = "Unable to delete the message";
        }
    }
    #endregion
}

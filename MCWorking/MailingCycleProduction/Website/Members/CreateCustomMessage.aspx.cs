#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CreateCustomMessage.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to create the custom message
	* Source			: MailingCycle\CreateCustomMessage.aspx.cs

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
using System.Xml;
using Irmac.MailingCycle.BLLServiceLoader.Message;
using Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLLServiceLoader;
using log4net;
using System.Collections.Generic;
using System.IO;
using Irmac.MailingCycle.BLLServiceLoader.Design;
#endregion

public partial class CreateCustomMessage : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(CreateCustomMessage));

    #region Properties
    private bool IsFromModifyPage
    {
        get
        {
            return (Request.QueryString["fromModify"] != null && Request.QueryString["fromModify"].ToString() == "1");
        }
    }
    public bool IsAgentRole
    {
        get
        {
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            return (regInfo.Role == UserRole.Agent);
        }
    }
    #endregion

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            if (!IsAgentRole && Request.QueryString["userId"] == null ||
                (IsFromModifyPage && Request.QueryString["MessageId"] == null && Session["SelectedMessage"] == null))
            {
                RedirectPage(string.Empty);
            }

            FillStatusDropDown();
            FillStandardMessages();
            MessageTextRFValidator.Enabled = true;
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            int userId = 0;
            if (!IsAgentRole)
                userId = Convert.ToInt32(Request.QueryString["userId"]);
            else
                userId = regInfo.UserId;
            string path = Server.MapPath("~/Members/UserData/" + userId.ToString() + "/Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] files = dirInfo.GetFiles();
            ExistingImagesGridview.DataSource = files;
            ExistingImagesGridview.DataBind();
            
            if (IsFromModifyPage)
            {
                TitleLabel.Text = "Modify Custom Message";
                SubTitleLabel.Text = "Please modify custom message details in the below form";
                MessageInfo dataSource = (MessageInfo)Session["SelectedMessage"];
                if (Session["SelectedMessage"] == null)
                {
                    MessageService msgService = ServiceAccess.GetInstance().GetMessage();                    
                    IList<MessageInfo> messageInfo = msgService.GetCustomMessageList(userId);
                    foreach (MessageInfo msgInfo in messageInfo)
                    {
                        if (msgInfo.MessageId == Convert.ToInt32(Request.QueryString["MessageId"]))
                        {
                            dataSource = msgInfo;
                            break;
                        }
                    }
                }
                MessageIdPanel.Visible = true;
                MessageIdLabel.Text = dataSource.MessageId.ToString();
                foreach (ListItem listItem in StatusDropDownList.Items)
                {
                    if (listItem.Text == dataSource.Status.ToString())
                    {
                        listItem.Selected = true;
                        break;
                    }
                }
                ShortDescTextBox.Text = dataSource.ShortDesc;
                HTMLEditTextBox.Text = dataSource.MessageText;
                if (dataSource.UsageCount > 0)
                    StatusDropDownList.Enabled = false;
            }
            if (!IsAgentRole)
            {
                RegistrationService regservice = ServiceAccess.GetInstance().GetRegistration();
                RegistrationInfo registrInfo = regservice.GetDetails(Convert.ToInt32(Request.QueryString["userId"]));
                AgentLabel.Text = "Selected Agent: " + registrInfo.UserName;
                AgentLabel.Visible = true;
            }
        }
        else
        {
            
            if (MessageTextHidden.Value != null && MessageTextHidden.Value != string.Empty)
            {
                FileInfo fileInfo = new FileInfo(MessageTextHidden.Value);
                FileStream fs = fileInfo.OpenRead();
                string userId;
                if (!IsAgentRole)
                    userId = Request.QueryString["userId"];
                else
                {
                    LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
                    userId = regInfo.UserId.ToString();
                }
                string path = Server.MapPath("~/Members/UserData/" + userId + "/Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream writeStream = File.Open(path + "/" + fileInfo.Name, FileMode.Create, FileAccess.Write);
                               
                int length = 100;
                while (length < fs.Length)
                {
                    byte[] readBytes = new byte[100];
                    int noBytesRead = fs.Read(readBytes, 0, 100);
                    for (int i = 0; i < readBytes.Length; i++)
                    {
                        writeStream.WriteByte(readBytes[i]);
                    }
                    length += noBytesRead;                    
                }
                writeStream.Flush();
                writeStream.Close();
                fs.Close();
            }
        }
    }

    protected void ExistingImagesGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            FileInfo dataSource = (FileInfo)e.Row.DataItem;
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            string userId = regInfo.UserId.ToString();
            HtmlAnchor imageLink = (HtmlAnchor)e.Row.FindControl("ImageLink");
            imageLink.HRef = "javascript:SelectImages('http://" + Request.Url.Authority + "/" +
                Request.Url.Segments[1] + "Members/UserData/" + userId + "/" + "Images/" + dataSource.Name + "');";
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    protected void InsertImage_Click(object sender, EventArgs e)
    {
        //throw new Exception("The method or operation is not implemented.");
    }    
    protected void StatusDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        MessageInfo[] dataSource = (MessageInfo[])ViewState["DataSource"];
        foreach (MessageInfo msgInfo in dataSource)
        {
            if (msgInfo.MessageId.ToString() == StandardMessagesDropDownList.SelectedValue)
            {
                HTMLEditTextBox.Text = msgInfo.MessageText;
                break;
            }
        }
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            MessageService messageService = serviceLoader.GetMessage();
            MessageInfo msgInfo = new MessageInfo();
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            msgInfo.MessageText = HTMLEditTextBox.Text;
            msgInfo.MessageType = MessageType.Custom;
            msgInfo.ShortDesc = ShortDescTextBox.Text;
            msgInfo.Status = (MessageStatus)Convert.ToInt32(StatusDropDownList.SelectedValue);
            msgInfo.IsImage = false;
            bool success = true;
            bool successImage = true;
            int userId;
            if (!IsAgentRole )
                userId = Convert.ToInt32(Request.QueryString["userId"]);
            else
                userId = regInfo.UserId;            
            if (successImage)
            {
                if (IsFromModifyPage)
                {
                    msgInfo.MessageId = Convert.ToInt32(MessageIdLabel.Text);
                    try
                    {
                        success = messageService.UpdateMessage(msgInfo, userId,regInfo.UserId);
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        log.Error("Unknown error", ex);
                    }
                }
                else
                {
                    try
                    {
                        success = messageService.InsertMessage(msgInfo, userId);
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        log.Error("Unknown error", ex);
                    }
                }
            }
            else
                success = false;
            if (!success)
            {
                ErrorLiteral.Text = "Message could not be saved. Please try later.";
                ErrorLiteral.Visible = true;
            }
            else
            {
                Session["SelectedMessage"] = msgInfo;
                RedirectPage("?userId=" + Convert.ToString(Request.QueryString["userId"]));
            }
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        if (!IsAgentRole)
            RedirectPage("?userId=" + Convert.ToInt32(Request.QueryString["userId"]));
        else
            RedirectPage(string.Empty);
    }
    #endregion

    #region Methods
    private void RedirectPage(string queryString)
    {
        string redirectPage = Convert.ToString(Request.QueryString["fromPage"]);
        string redirectUrl;
        switch (redirectPage)
        {
            case "MessageManagement":
                redirectUrl = "~/Members/CustomMessages.aspx" + queryString;
                break;
            case "EditMessage":
                redirectUrl = "~/Members/ViewCustomMessage.aspx" + queryString;
                break;
            default:
                redirectUrl = "~/Members/CustomMessages.aspx" + queryString;
                break;
        }
        Response.Redirect(redirectUrl);
    }
    protected void SaveImageFile(object sender, EventArgs e)
    {
        ImageFileNameRegExpValidator.Validate();
        if (ImageFileNameRegExpValidator.IsValid)
        {
            if (ImageFileName.FileBytes.Length > 500 * 1024)
            {
                ErrorLiteral.Text = "File size must be lesser than 500kb";
                ErrorLiteral.Visible = true;
            }
            else
            {

                Boolean fileOK = false;
                bool success = true;
                string userId;
                if (!IsAgentRole)
                    userId = Request.QueryString["userId"];
                else
                {
                    LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
                    userId = regInfo.UserId.ToString();
                }
                string path = Server.MapPath("~/Members/UserData/" + userId + "/Images/");
                if (ImageFileName.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(ImageFileName.FileName).ToLower();
                    String[] allowedExtensions = 
                    { ".gif", ".png", ".jpeg", ".jpg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        ImageFileName.PostedFile.SaveAs(path + ImageFileName.FileName);
                        if (!IsAgentRole)
                            userId = Request.QueryString["userId"];
                        else
                        {
                            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
                            userId = regInfo.UserId.ToString();
                        }
                        path = Server.MapPath("~/Members/UserData/" + userId + "/Images/");
                        DirectoryInfo dirInfo = new DirectoryInfo(path);
                        
                        IList<FileInfo> files = dirInfo.GetFiles();
                        List<FileInfo> f1 = new List<FileInfo>();
                        
                        ExistingImagesGridview.DataSource = files;
                        ExistingImagesGridview.DataBind();
                        string script = "<script language=JavaScript id='PopupWindow'>";
                        script += "imageDiv = document.getElementById(\"ExistingImagesDiv\");";
                        script += "imageDiv.style.display='block';";
                        script += "imageDiv = document.getElementById(\"FileUploadDiv\");";
                        script += "imageDiv.style.display='block';";
                        script += "s('IMAGE_FORM'+'" + HTMLEditTextBox.ClientID + "');";
                        script += "</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "ShowImageDiv", script);
                        ErrorLiteral.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        log.Error("Unknown error", ex);
                        ErrorLiteral.Text = "File could not be uploaded.";
                        ErrorLiteral.Visible = true;
                        success = false;
                    }
                }
                else
                {
                    ErrorLiteral.Text = "Cannot accept files of this type.";
                    ErrorLiteral.Visible = true;
                    success = false;
                }
            }
        }
    }


    private void FillStandardMessages()
    {
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            MessageService msgService = serviceLoader.GetMessage();
            int userId = 0;
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            if (IsAgentRole)
            {

                userId = regInfo.UserId;
            }
            else
                userId = Convert.ToInt32(Request.QueryString["userId"]);
            DesignService designService = ServiceAccess.GetInstance().GetDesign();
            DesignInfo[] designs = designService.GetList(userId);
            string gender = string.Empty;
            string onDesignName = string.Empty;
            bool isDesignAvl = true;

            if (designs != null)
            {
                foreach (DesignInfo designInfo in designs)
                {
                    if (designInfo != null && designInfo.DesignId > 0)
                    {
                        DesignInfo allDesignInfo = designService.Get(designInfo.DesignId);
                        if (allDesignInfo.Status.Name.ToLower() != "approved")
                        {
                            isDesignAvl = false;
                        }
                        else if (allDesignInfo.Gender != string.Empty && allDesignInfo.OnDesignName != string.Empty)
                        {
                            gender = allDesignInfo.Gender;
                            onDesignName = allDesignInfo.OnDesignName;
                            break;
                        }
                    }
                    else
                        isDesignAvl = false;
                }
            }
            if (isDesignAvl)
            {
                MessageInfo[] messageInfo = msgService.GetStandardMessageList(regInfo.Role == UserRole.Agent, gender, onDesignName);
                StandardMessagesDropDownList.DataSource = messageInfo;
                ViewState["DataSource"] = StandardMessagesDropDownList.DataSource;
                StandardMessagesDropDownList.DataTextField = "ShortDesc";
                StandardMessagesDropDownList.DataValueField = "MessageId";
                StandardMessagesDropDownList.DataBind();
            }
            else
                StandardMessagesDropDownList.Enabled = false;
            StandardMessagesDropDownList.Items.Insert(0, new ListItem("<Select a standard message>", "0"));
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = "Unable to load standard messages.";
            ErrorLiteral.Visible = true;
            log.Error("Unknown error", ex);
        }
    }

    private void FillStatusDropDown()
    {
        LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
        StatusDropDownList.Items.Add(new ListItem(MessageStatus.Active.ToString(), Convert.ToInt32(MessageStatus.Active).ToString()));
        StatusDropDownList.Items.Add(new ListItem(MessageStatus.InActive.ToString(), Convert.ToInt32(MessageStatus.InActive).ToString()));
        StatusDropDownList.DataBind();
    }

    protected void CheckShortDesc(object source, ServerValidateEventArgs arguments)
    {
        if (arguments.Value.Trim() == string.Empty)
        {
            arguments.IsValid = false;
        }
    }
    #endregion
}

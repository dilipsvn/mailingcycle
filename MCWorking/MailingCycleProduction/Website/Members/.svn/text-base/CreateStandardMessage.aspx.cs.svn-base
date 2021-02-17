#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CreateStandardMessage.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to create the custom message
	* Source			: MailingCycle\CreateStandardMessage.aspx.cs

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
using Irmac.MailingCycle.BLLServiceLoader.Message;
using Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
using System.IO;
using Irmac.MailingCycle.BLLServiceLoader.Design;
#endregion

public partial class CreateStandardMessage : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(CreateStandardMessage));

    #region Properties
    private bool IsFromModifyPage
    {
        get
        {
            return (Request.QueryString["fromModify"] != null && Request.QueryString["fromModify"].ToString() == "1");
        }
    }
    #endregion

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((IsFromModifyPage && Request.QueryString["MessageId"] == null && Session["SelectedMessage"] == null))
            {
                RedirectPage();
            } 
            FillStatusDropDown();
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            int userId = regInfo.UserId;
            string path = Server.MapPath("~/Members/UserData/" + userId.ToString() + "/Images/");
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
                TitleLabel.Text = "Modify Standard Message";
                SubTitleLabel.Text = "Please modify standard message details in the below form";                
                MessageInfo dataSource = (MessageInfo)Session["SelectedMessage"];
                if (Session["SelectedMessage"] == null)
                {
                    MessageService msgService = ServiceAccess.GetInstance().GetMessage();                    
                    userId = regInfo.UserId;
                    DesignService designService = ServiceAccess.GetInstance().GetDesign();
                    DesignInfo[] designs = designService.GetList(regInfo.UserId);
                    string gender = string.Empty;
                    string onDesignName = string.Empty;

                    foreach (DesignInfo designInfo in designs)
                    {
                        DesignInfo allDesignInfo = designService.Get(designInfo.DesignId);
                        if (allDesignInfo.Gender != string.Empty && allDesignInfo.OnDesignName != string.Empty)
                        {
                            gender = allDesignInfo.Gender;
                            onDesignName = allDesignInfo.OnDesignName;
                            break;
                        }
                    }

                    MessageInfo[] messageInfo = msgService.GetStandardMessageList(false, gender, onDesignName);                    
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
                ShortDescText.Text = dataSource.ShortDesc;
                HTMLEditTextBox.Text = dataSource.MessageText;
                DefaultMessageCheckBox.Checked = dataSource.IsDefaultMessage;
                if (dataSource.UsageCount > 0)
                    StatusDropDownList.Enabled = false;
                if (dataSource.IsDefaultMessage)
                    DefaultMessageCheckBox.Enabled = false;
            }
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        RedirectPage();
    }

    protected void ExistingImagesGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            FileInfo dataSource = (FileInfo)e.Row.DataItem;
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            string userId = regInfo.UserId.ToString();
            string path = Server.MapPath("~/Members/UserData/" + userId + "/Images/");
            HtmlAnchor imageLink = (HtmlAnchor)e.Row.FindControl("ImageLink");
            imageLink.HRef = "javascript:SelectImages('http://" + Request.Url.Authority + "/" +
                Request.Url.Segments[1] + "Members/UserData/" + userId + "/Images/" + dataSource.Name + "');";
        }
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
                LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
                string userId = regInfo.UserId.ToString();
                string path = Server.MapPath("~/Members/UserData/" + userId + "/Images/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
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
                        userId = regInfo.UserId.ToString();
                        path = Server.MapPath("~/Members/UserData/" + userId + "/Images/");
                        DirectoryInfo dirInfo = new DirectoryInfo(path);
                        FileInfo[] files = dirInfo.GetFiles();
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

    private void RedirectPage()
    {
        string redirectPage = Convert.ToString(Request.QueryString["fromPage"]);
        string redirectUrl;
        switch (redirectPage)
        {
            case "MessageManagement":
                redirectUrl = "~/Members/MessageManagement.aspx";
                break;
            case "EditMessage":
                redirectUrl = "~/Members/ViewStandardMessage.aspx";
                break;
            default:
                redirectUrl = "~/Members/MessageManagement.aspx";
                break;
        }
        Response.Redirect(redirectUrl);
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            MessageService messageService = serviceLoader.GetMessage();
            MessageInfo msgInfo = new MessageInfo();
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            bool success = true;
            if (IsFromModifyPage)
            {
                msgInfo.MessageId = Convert.ToInt32(MessageIdLabel.Text);
                msgInfo.MessageText = HTMLEditTextBox.Text;
                msgInfo.MessageType = MessageType.Standard;
                msgInfo.ShortDesc = ShortDescText.Text;
                msgInfo.Status = (MessageStatus)Convert.ToInt32(StatusDropDownList.SelectedValue);
                msgInfo.IsDefaultMessage = DefaultMessageCheckBox.Checked;
                try
                {
                    success = messageService.UpdateMessage(msgInfo, regInfo.UserId,regInfo.UserId);
                }
                catch (Exception ex)
                {
                    success = false;
                    log.Error("Unknown error", ex);
                }
            }
            else
            {
                msgInfo.MessageText = HTMLEditTextBox.Text;
                msgInfo.MessageType = MessageType.Standard;
                msgInfo.ShortDesc = ShortDescText.Text;
                msgInfo.IsImage = false;
                msgInfo.Status = (MessageStatus)Convert.ToInt32(StatusDropDownList.SelectedValue);
                try
                {
                    success = messageService.InsertMessage(msgInfo, regInfo.UserId);
                }
                catch (Exception ex)
                {
                    success = false;
                    log.Error("Unknown error", ex);
                }
            }
            if (!success)
                ErrorLiteral.Text = "Message could not be saved. Please try later.";
            else
            {
                Session["SelectedMessage"] = msgInfo;
                RedirectPage();
            }
        }
    }
    #endregion

    #region Methods
    private void FillStatusDropDown()
    {
        StatusDropDownList.Items.Add(new ListItem(MessageStatus.Active.ToString(), Convert.ToInt32(MessageStatus.Active).ToString()));
        StatusDropDownList.Items.Add(new ListItem(MessageStatus.InActive.ToString(), Convert.ToInt32(MessageStatus.InActive).ToString()));
        StatusDropDownList.DataBind();
    }

    //private bool CheckFields()
    //{
    //    bool valid = true;
    //    if (ShortDescText.Text.Trim() == string.Empty)
    //    {
    //        ShortDescErrorLabel.Visible = true;
    //        ErrorLiteral.Text = ShortDescErrorLabel.Text;
    //        valid = false;
    //    }
    //    if (HTMLEditTextBox.Text.Trim() == string.Empty)
    //    {
    //        MessageTextErrorLabel.Visible = true;
    //        ErrorLiteral.Text += "<br>" + MessageTextErrorLabel.Text;
    //        valid = false;
    //    }        
    //    return valid;
    //}

    protected void CheckShortDesc(object source, ServerValidateEventArgs arguments)
    {
        if (arguments.Value.Trim() == string.Empty)
        {
            arguments.IsValid = false;
        }
    }
    #endregion
}

#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CustomMessages.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to display the custom messages
	* Source			: MailingCycle\CustomMessages.aspx.cs

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
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Message;
using Irmac.MailingCycle.BLLServiceLoader.Common;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using System.IO;
using log4net;
#endregion

public partial class CustomMessages : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(CustomMessages));

    #region Properties
    public bool IsAgentRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Agent);
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        ListOfAgentsWebUserControl1.OnSelectChanged += new EventHandler(ListOfAgentsWebUserControl1_OnSelectChanged);
        if (!IsPostBack)
        {
            Session["SelectedMessage"] = null;
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            ListOfAgentsWebUserControl1.Visible = false;
            if (regInfo.Role != RegistrationService.UserRole.Agent)
            {
                ListOfAgentsWebUserControl1.Visible = true;
                ListOfAgentsWebUserControl1.FillDropDown();
                ListOfAgentsWebUserControl1.SelectedValue = Request.QueryString["userId"].ToString();
                AgentLabel.Text = "Selected Agent: " + ListOfAgentsWebUserControl1.SelectedText;
                Session["SelectedAgentName"] = ListOfAgentsWebUserControl1.SelectedText;
                AgentLabel.Visible = true;
                AddMessageButton.Visible = false;
            }
            FillMessageDataGrid();         
        }
    }

    void ListOfAgentsWebUserControl1_OnSelectChanged(object sender, EventArgs e)
    {
        FillMessageDataGrid();
        AgentLabel.Text = "Selected Agent: " + ListOfAgentsWebUserControl1.SelectedText;
        Session["SelectedAgentName"] = ListOfAgentsWebUserControl1.SelectedText;
    }
    
    protected void AddButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/CreateCustomMessage.aspx?fromPage=MessageManagement");
    }

    protected void AddMessageButton_Click(object sender, EventArgs e)
    {
        if (!IsAgentRole)
            Response.Redirect("CreateCustomMessage.aspx?userId=" + ListOfAgentsWebUserControl1.SelectedValue + "&fromPage=MessageManagement");
        else
            Response.Redirect("CreateCustomMessage.aspx?fromPage=MessageManagement");
    }

    protected void MessageDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "ShowMessage")
        {
            MessageInfo[] dataSource = (MessageInfo[])ViewState["dataSource"];
            MessageInfo msgInfo = dataSource[e.Item.DataSetIndex];
            Session["SelectedMessage"] = msgInfo;
            if (!IsAgentRole)
                Response.Redirect("ViewCustomMessage.aspx?userId=" + ListOfAgentsWebUserControl1.SelectedValue);
            else
                Response.Redirect("ViewCustomMessage.aspx");
        }
        else if (e.CommandName == "EditMessage")
        {
            MessageInfo[] dataSource = (MessageInfo[])ViewState["dataSource"];
            MessageInfo msgInfo = dataSource[e.Item.DataSetIndex];
            Session["SelectedMessage"] = msgInfo;
            if (!IsAgentRole)
                Response.Redirect("CreateCustomMessage.aspx?fromModify=1&fromPage=MessageManagement&userId=" 
                    + ListOfAgentsWebUserControl1.SelectedValue);
            else
                Response.Redirect("CreateCustomMessage.aspx?fromModify=1&fromPage=MessageManagement");
        }
    }

    protected void MessageDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        MessageInfo info = (MessageInfo)e.Item.DataItem;
        if (info != null && info.EventInProgress)
        {
            ImageButton imageButton = (ImageButton)e.Item.FindControl("EditMessageButton");
            imageButton.Enabled = false;
            imageButton.ToolTip = "Event in progress.Cannot modify message";
        }
        if (info != null && !info.IsImage && info.MessageText != string.Empty)
        {
            StringReader stringReader = new StringReader(info.MessageText);
            string line = stringReader.ReadLine();
            //loop till the next non-empty line
            while(stringReader.Peek() >= 0)
            {
                line = stringReader.ReadLine();
                while (line.IndexOf(">") >= 0)
                {
                    int start = line.IndexOf("<");
                    int end = line.IndexOf(">");
                    line = line.Remove(start, end - start + 1);
                }
                if(line != string.Empty && line != "&nbsp;")
                    break;
            }
            if (line.Length > 50 && !line.StartsWith("<IMG"))
                e.Item.Cells[4].Text = line.Substring(0, 50) + "...";
            else if(!line.StartsWith("<IMG"))
                e.Item.Cells[4].Text = line;
        }
    }

    protected void MessageDataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        MessageDataGrid.CurrentPageIndex = e.NewPageIndex;
        MessageDataGrid.DataSource = (MessageInfo[])ViewState["dataSource"];
        MessageDataGrid.DataBind();
    }
    #endregion

    #region Methods
    private void FillMessageDataGrid()
    {
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            MessageService messageService = serviceLoader.GetMessage();
            int userId;
            if (IsAgentRole)
                userId = regInfo.UserId;
            else
                userId = Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
            MessageInfo[] dataSource = messageService.GetCustomMessageList(userId);
            if (dataSource.Length == 0)
            {
                NoRecordsTable.Visible = true;
            }
            else
            {
                NoRecordsTable.Visible = false;
                MessageDataGrid.DataSource = dataSource;
                ViewState["dataSource"] = MessageDataGrid.DataSource;
                MessageDataGrid.DataBind();
            }
            
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to load the message list.";
            ErrorMessageLabel.Visible = true;
            log.Error("Unknown Error", ex);
        }
    }
    #endregion
}

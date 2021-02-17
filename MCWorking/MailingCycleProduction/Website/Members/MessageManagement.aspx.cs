#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: MessageManagement.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to display the standard messages
	* Source			: MailingCycle\MessageManagement.aspx.cs

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
using System.IO;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Message;
using Irmac.MailingCycle.BLLServiceLoader.Common;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using System.Text;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader.Design;
#endregion

public partial class MessageManagement : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(MessageManagement));

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
        if (!IsPostBack)
        {
            Session["SelectedMessage"] = null;
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            if (regInfo.Role != RegistrationService.UserRole.Agent)
            {
                AgentsPanel.Visible = true;
                AgentRFValidator.ControlToValidate = "ListOfAgentsWebUserControl1";
                AgentRFValidator.Enabled = true;
                try
                {
                    ListOfAgentsWebUserControl1.AutoPostBack = false;
                    ListOfAgentsWebUserControl1.FillDropDown();
                }
                catch (Exception ex)
                {
                    ErrorMessageLabel.Text = "Unable to load the agents list";
                    ErrorMessageLabel.Visible = true;
                    log.Error("Unknown error", ex);
                }                
            }
            
            MessageService messageService = serviceLoader.GetMessage();
            bool isAgent = (regInfo.Role == RegistrationService.UserRole.Agent);
            try
            {
                DesignService designService = ServiceAccess.GetInstance().GetDesign();
                MessageInfo[] dataSource = null;                
                string gender = string.Empty;
                string onDesignName = string.Empty;

                if (isAgent)
                {
                    DesignInfo[] designs = designService.GetList(regInfo.UserId);
                    if (designs != null)
                    {
                        foreach (DesignInfo designInfo in designs)
                        {
                            if (designInfo != null && designInfo.DesignId > 0 && designInfo.Status.Name.ToLower() == "approved")
                            {
                                DesignInfo allDesignInfo = designService.Get(designInfo.DesignId);
                                if (allDesignInfo.Gender != string.Empty && allDesignInfo.OnDesignName != string.Empty)
                                {
                                    gender = allDesignInfo.Gender;
                                    onDesignName = allDesignInfo.OnDesignName;
                                    break;
                                }
                            }
                        }
                    }
                }
                dataSource = messageService.GetStandardMessageList(isAgent, gender,onDesignName);
                if (dataSource == null || dataSource.Length == 0)
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
                ErrorMessageLabel.Text = "Unable to load the messages";
                ErrorMessageLabel.Visible = true;
                log.Error("Unknown error", ex);
            }            
            if (!IsAgentRole)
            {
                MessageDataGrid.Columns[0].Visible = true;
                AgentRFValidator.Enabled = true;
                AddStdMessagePanel.Visible = true;
            }
            else
                MessageDataGrid.Columns[0].Visible = false;
        }
    }
    
    protected void MessageDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "ShowMessage")
        {
            MessageInfo[] dataSource = (MessageInfo[])ViewState["dataSource"];
            MessageInfo msgInfo = dataSource[e.Item.DataSetIndex];
            Session["SelectedMessage"] = msgInfo;
            Response.Redirect("ViewStandardMessage.aspx");
        }
        else if (e.CommandName == "EditMessage")
        {
            MessageInfo[] dataSource = (MessageInfo[])ViewState["dataSource"];
            MessageInfo msgInfo = dataSource[e.Item.DataSetIndex];
            Session["SelectedMessage"] = msgInfo;
            Response.Redirect("CreateStandardMessage.aspx?fromModify=1&fromPage=MessageManagement");
        }
    }
    protected void MessageDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        MessageInfo info = (MessageInfo)e.Item.DataItem;
        if (info != null & !IsAgentRole && info.EventInProgress)
        {
            ImageButton imageButton = (ImageButton)e.Item.FindControl("EditMessageButton");
            imageButton.Enabled = false;
            imageButton.ToolTip = "Event in progress.Cannot modify message";
        }        
        if (info != null && info.MessageText != string.Empty)
        {
            StringReader stringReader = new StringReader(info.MessageText);
            //Read the first line
            string line = stringReader.ReadLine();
            while (line.IndexOf(">") >= 0)
            {
                int start = line.IndexOf("<");
                int end = line.IndexOf(">");
                line = line.Remove(start, end - start + 1);
            }
            //loop till the next non-empty line
            while (stringReader.Peek() >= 0)
            {
                line = stringReader.ReadLine();
                while (line.IndexOf(">") >= 0)
                {
                    int start = line.IndexOf("<");
                    int end = line.IndexOf(">");
                    line = line.Remove(start, end - start + 1);
                }
                if (line != string.Empty && line != "&nbsp;")
                    break;
            }
            if (line.Length > 50 && !line.StartsWith("<IMG"))
                e.Item.Cells[3].Text = line.Substring(0, 50) + "...";
            else if (!line.StartsWith("<IMG"))
                e.Item.Cells[3].Text = line;
        }
    }
    protected void CustomMessagesLink_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (!IsAgentRole)
            {
                Response.Redirect("~/Members/CustomMessages.aspx?userId=" + ListOfAgentsWebUserControl1.SelectedValue.ToString());
            }
            else
                Response.Redirect("~/Members/CustomMessages.aspx");
        }
    }

    protected void MessageDataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        MessageDataGrid.CurrentPageIndex = e.NewPageIndex;
        MessageDataGrid.DataSource = (MessageInfo[])ViewState["dataSource"];
        MessageDataGrid.DataBind();
    }

    protected void ServerValidation(object source, ServerValidateEventArgs arguments)
    {
        arguments.IsValid = (ListOfAgentsWebUserControl1.SelectedValue != "0");
    }
    #endregion
    
}

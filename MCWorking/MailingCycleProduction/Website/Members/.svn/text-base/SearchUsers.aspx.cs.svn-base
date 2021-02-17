#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: SearchUsers.aspx
    * Created Date      : 12/19/2007
	* Last Modify Date  : 12/19/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to search Users
	* Source			: MailingCycle\SearchUsers.aspx.cs

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
using System.Collections.Generic;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
#endregion

public partial class SearchUsers : System.Web.UI.Page
{

    protected static readonly ILog log = LogManager.GetLogger(typeof(SearchUsers));


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillListFromEnum(RoleDropDownList, typeof(RegistrationService.UserRole));
                RoleDropDownList.Items.RemoveAt(4);
                RoleDropDownList.Items.Insert(0, new ListItem("<Select a Role>", Convert.ToInt32(RegistrationService.UserRole.NullValue).ToString()));
                ResultCountLiteral.Text = "Search for the Users";
                if (Request.QueryString["selectedCriteria"] != null)
                {
                    string[] selectedCriteria = Request.QueryString["selectedCriteria"].Split(new char[] { '|' });
                    foreach (ListItem item in RoleDropDownList.Items)
                    {
                        if (item.Text == selectedCriteria[0])
                        {
                            item.Selected = true;
                            break;
                        }
                    }                    
                    FirstNameTextBox.Text = selectedCriteria[1];
                    LastNameTextBox.Text = selectedCriteria[2];
                    UserNameTextBox.Text = selectedCriteria[3];
                    SearchUsers_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error loading roles", ex);
                ErrorLiteral.Text = "Error loading roles";
            }
        }        
    }


    private void FillListFromEnum(DropDownList dropDownList, Type enumObject)
    {
        string[] enumNames = Enum.GetNames(enumObject);
        int arrCount = 0;
        while (arrCount < enumNames.Length)
        {
            dropDownList.Items.Add(new ListItem(enumNames[arrCount], arrCount.ToString()));
            arrCount++;
        }
    }

    protected void SetPermissions(object sender, GridViewRowEventArgs e)
    {

            // Get the logged in account information.
            RegistrationService.LoginInfo loginInfo = 
                (RegistrationService.LoginInfo)Session["loginInfo"];
            RegistrationService.RegistrationInfo regInfo = (RegistrationService.RegistrationInfo)e.Row.DataItem;
            RegistrationService.UserRole userRole = (RegistrationService.UserRole)Convert.ToInt32(RoleDropDownList.SelectedValue);
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string userName = UserNameTextBox.Text;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string rowuserRole = ((Label)e.Row.FindControl("RoleLabel")).Text;
            string rowuserStatus = ((Label)e.Row.FindControl("StatusLabel")).Text;

            ((HyperLink)e.Row.FindControl("EditUserHyperLink")).NavigateUrl = 
                "~/Members/ModifyUser.aspx?UserId=" + regInfo.UserId + "&PageName=SearchUsers.aspx" +
                "&selectedCriteria=" + userRole + "|" + firstName + "|" + lastName + "|" + userName;

            ((HyperLink)e.Row.FindControl("UserNameHyperLink")).NavigateUrl =
                "~/Members/ViewUser.aspx?UserId=" + regInfo.UserId + "&PageName=SearchUsers.aspx" +
                "&selectedCriteria=" + userRole + "|" + firstName + "|" + lastName + "|" + userName;

            if (loginInfo.Role == RegistrationService.UserRole.CSR)
            {
                if (rowuserRole != RegistrationService.UserRole.Agent.ToString())
                {
                    ((HyperLink)e.Row.FindControl("EditUserHyperLink")).Enabled = false;
                    ((HyperLink)e.Row.FindControl("UserNameHyperLink")).Enabled = false;
                }
            }
            else
            if (loginInfo.Role == RegistrationService.UserRole.Printer)
            {
                SearchUsersResultGridView.Columns[0].Visible = false;
                ((HyperLink)e.Row.FindControl("UserNameHyperLink")).Visible = false;
                ((Label)e.Row.FindControl("UserNameLabel")).Visible = true;
            }

        if (rowuserStatus == "ApprovalRequired")
            ((Label)e.Row.FindControl("StatusLabel")).Text = "Approval Required";
        }
    }

    protected void SearchUsers_Click(object sender, EventArgs e)
    {
        RegistrationService.RegistrationService registrationService = ServiceAccess.GetInstance().GetRegistration();


        RegistrationService.UserRole userRole = (RegistrationService.UserRole)Convert.ToInt32(RoleDropDownList.SelectedValue);
        string firstName = FirstNameTextBox.Text;
        string lastName = LastNameTextBox.Text;
        string userName = UserNameTextBox.Text;
        try
        {
            RegistrationService.RegistrationInfo[] searchResults = registrationService.GetUsersList(userRole, firstName, lastName, userName);
            SearchUsersResultGridView.DataSource = searchResults;
            SearchUsersResultGridView.DataBind();
            ViewState["dataSource"] = searchResults;
            SearchCriteriaPanel.Visible = false;
            SearchResultsPanel.Visible = true;
            ResultCountLiteral.Text = "Users result - " + searchResults.Length + " users found";
        }
        catch (Exception ex)
        {
            log.Error("Error searching Users", ex);
            ErrorLiteral.Text = "Error searching Users";
        }
    }

    protected void BackToSearchPanel_Click(object sender, EventArgs e)
    {
        SearchCriteriaPanel.Visible = true;
        SearchResultsPanel.Visible = false;
        ResultCountLiteral.Text = "Search for the Users";
    }

    protected void SearchUsersResultGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchUsersResultGridView.PageIndex = e.NewPageIndex;
        SearchUsersResultGridView.DataSource = (RegistrationService.RegistrationInfo[])ViewState["dataSource"];
        SearchUsersResultGridView.DataBind();
    }
}

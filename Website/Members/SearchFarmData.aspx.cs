#region Namespaces
using System;
using System.Data;
using System.Data.SqlClient;
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
using System.Text;
using Irmac.MailingCycle.BLLServiceLoader;
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLL;
using log4net;
using log4net.Config;
#endregion
public partial class Members_SearchFarmData : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Members_SearchFarmData));
    #endregion

    #endregion

    #region Properties
    public bool IsAgentRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Agent);
        }
    }

    public bool IsPrinterRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Printer);
        }
    }

    public int LoginUserId
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return regInfo.UserId;
        }
    }
    #endregion

    #region Methods
    
    protected string GenerateSearchCondition()
    {
        String where = "";
        //User Id
        where = " WHERE TBL_FARM.User_Id = " + GetAgentId().ToString();
        
        //Archived Contacts Check
        if (ArchivedCheckBox.Checked)
        {
            where = where + " AND TBL_CONTACT.deleted = 0";
        }

        //Specific Farm and Plot
        if (!FarmDropDownList.SelectedValue.ToString().Equals("0"))
        {
            where = where + " AND TBL_FARM.Farm_Id = '" + FarmDropDownList.SelectedValue.ToString() + "'";
            if (!PlotDropDownList.SelectedValue.ToString().Equals("0"))
                where = where + " AND TBL_PLOT.Plot_Id = '" + PlotDropDownList.SelectedValue.ToString() + "'";
        }

        //Schedule Number
        if (ScheduleNumberTextBox.Text.Trim() != "")
            where = where + " AND TBL_CONTACT.schedule_number = " + ScheduleNumberTextBox.Text;
        
        //Owner Full Name
        if (OwnerFullNameTextBox.Text.Trim() != "")
        {
            where = where + " AND TBL_CONTACT.owner_fullname LIKE '%" + OwnerFullNameTextBox.Text + "%'";
        }

        //Lot
        if (LotTextBox.Text.Trim() != "")
        {
            where = where + " AND TBL_CONTACT.lot = " + LotTextBox.Text;
        }

        //Block
        if (BlockTextBox.Text.Trim() != "")
        {
            where = where + " AND TBL_CONTACT.block = '" + BlockTextBox.Text + "'";
        }

        //Filing
        if (FilingTextBox.Text.Trim() != "")
        {
            where = where + " AND TBL_CONTACT.filing = '" + FilingTextBox.Text + "'";
        }

        //City
        if (OwnerCityTextBox.Text.Trim() != "")
        {
            where = where + " AND TBL_CONTACT.owner_city LIKE '%" + OwnerCityTextBox.Text + "%'";
        }

        //State
        if (OwnerStateTextBox.Text.Trim() != "")
        {
            where = where + " AND TBL_CONTACT.owner_state LIKE '%" + OwnerStateTextBox.Text + "%'";
        }

        //Zip
        if (OwnerZipTextBox.Text.Trim() != "")
        {
            where = where + " AND TBL_CONTACT.owner_zip = '" + OwnerZipTextBox.Text + "'";
        }

        return where;
    }

    protected int GetAgentId()
    {
        int AgentId = 0;
        if (IsAgentRole)
        {
            AgentId = LoginUserId;
        }
        else
        {
            int.TryParse(AgentListDropDownList.SelectedItem.Value.ToString(), out AgentId);
        }
        return AgentId;
    }
    #endregion

    #region Event Handlers
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // Register the client side script.
        ClientScriptManager csManager = Page.ClientScript;
        Type type = this.GetType();
        string newLine = Environment.NewLine;

        if (!csManager.IsClientScriptBlockRegistered(type, "BodyLoadScript"))
        {
            StringBuilder csText = new StringBuilder();
            csText.Append("<script type=\"text/javascript\">" + newLine);
            csText.Append("<!--" + newLine);
            csText.Append("function onBodyLoad() {" + newLine);
            csText.Append("    var allInputTags = document.getElementsByTagName(\"input\");" + newLine);
            csText.Append("    var msg = \"\";" + newLine);
            csText.Append("    var conformation;" + newLine);
            csText.Append("    for(i = 0; i < allInputTags.length; i++) {" + newLine);
            csText.Append("        if(allInputTags[i].type == \"hidden\") {" + newLine);
            csText.Append("            if(allInputTags[i].name.indexOf(\"DeleteMessageHiddenField\") >= 0)" + newLine);
            csText.Append("                msg = allInputTags[i].value;" + newLine);
            csText.Append("            else if(allInputTags[i].name.indexOf(\"DeleteConformationHiddenField\") >= 0)" + newLine);
            csText.Append("                conformation = allInputTags[i];" + newLine);
            csText.Append("        }" + newLine);
            csText.Append("    } " + newLine);
            csText.Append("    if (msg != \"\") {" + newLine);
            csText.Append("        if (confirm(msg))" + newLine);
            csText.Append("            conformation.value = \"true\";" + newLine);
            csText.Append("        else" + newLine);
            csText.Append("            conformation.value = \"false\";" + newLine);
            csText.Append("        document.forms[0].submit();" + newLine);
            csText.Append("    }" + newLine); 
            csText.Append("}" + newLine);
            csText.Append("document.body.onload = onBodyLoad;" + newLine);
            csText.Append("// -->" + newLine);
            csText.Append("</script>");
            csManager.RegisterClientScriptBlock(type, "BodyLoadScript", csText.ToString(), false);
        }

        if (!IsPostBack)
        {
            DeleteMessageHiddenField.Value = "";
            DeleteConformationHiddenField.Value = "";
            DeleteContactIdHiddenField.Value = "";
            try
            {
                // Get the common web service instance.
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                SearchCriteriaPane.Visible = true;
                SearchResultPane.Visible = false;
                if (IsAgentRole)
                {
                    AgentListPanel.Visible = false;
                    FarmDropDownList.DataSource = farmService.GetFarmListForUser(GetAgentId());
                    FarmDropDownList.DataValueField = "FarmId";
                    FarmDropDownList.DataTextField = "FarmName";
                    FarmDropDownList.DataBind();
                    FarmDropDownList.Items.Insert(0, new ListItem("All Farms", "0"));
                    PlotDropDownList.Items.Add(new ListItem("All Plots", "0"));
                }
                else
                {
                    AgentListPanel.Visible = true;
                    SearchCriteriaPane.Visible = false;
                    CommonService commonService = serviceLoader.GetCommon();
                    AgentListDropDownList.DataSource = commonService.GetAgentsList();
                    AgentListDropDownList.DataValueField = "UserId";
                    AgentListDropDownList.DataTextField = "UserName";
                    AgentListDropDownList.DataBind();
                    AgentListDropDownList.Items.Insert(0, "Select an Agent");
                }
                ResultCountLiteral.Text = "Search for the Farm Contacts";
                if ((Request.QueryString["accessType"] != "") && (Request.QueryString["accessType"] != null) && (Request.QueryString["accessType"] == "old"))
                {
                    if (Session["SearchFarmDataWhere"] != null)
                    {
                        string where = Session["SearchFarmDataWhere"].ToString();
                        int pageIndex = 1;
                        if (Session["SearchFarmDataPageIndex"] != null)
                            pageIndex = int.Parse(Session["SearchFarmDataPageIndex"].ToString());

                        FarmService.FarmDetailsReportInfo[] farms = farmService.GetSearchFarmData(where);
                        SearchFarmResultGridView.DataSource = farms;
                        SearchFarmResultGridView.PageIndex = pageIndex;
                        SearchFarmResultGridView.DataBind();

                        //Disable actions on deleted Contacts
                        for (int i = 0; i < SearchFarmResultGridView.Rows.Count; i++)
                            if (farms[SearchFarmResultGridView.Rows[i].DataItemIndex].Deleted)
                                SearchFarmResultGridView.Rows[i].Cells[1].Enabled = false;

                        if (IsPrinterRole)
                        {
                            SearchFarmResultGridView.Columns[0].Visible = false;
                            SearchFarmResultGridView.Columns[1].Visible = false;
                            DeleteButton.Visible = false;
                        }

                        SearchCriteriaPane.Visible = false;
                        SearchResultPane.Visible = true;
                        ResultCountLiteral.Text = "Farm data results - " + farms.Length + " Contacts found.";
                        if (!IsAgentRole)
                        {
                            AgentListPanel.Visible = false;
                            if (where.Contains("TBL_FARM.User_Id = "))
                            {
                                int startPos = where.IndexOf("TBL_FARM.User_Id = ") + "TBL_FARM.User_Id = ".Length;
                                int endPos = where.IndexOf(" AND ");
                                endPos = endPos - startPos;
                                string agentid = where.Substring(startPos, endPos);
                                for (int i = 0; i < AgentListDropDownList.Items.Count; i++)
                                {
                                    if (AgentListDropDownList.Items[i].Value.ToString().Equals(agentid))
                                    {
                                        AgentListDropDownList.SelectedIndex = i;
                                    }
                                }
                                ForAgentLiteral.Text = AgentListDropDownList.SelectedValue + " / " + AgentListDropDownList.SelectedItem.Text;
                            }
                        }
                        MessageLiteral.Text = "";
                    }
                }
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR WHILE LOADING SEARCH FARM:", exception);
                ErrorLiteral.Text = "UNKNOWN ERROR: Please Contact Administrator";
            }
        }
        else
        {
            if ((!DeleteMessageHiddenField.Value.ToString().Equals("")) && (DeleteConformationHiddenField.Value.ToString().Equals("true")))
            {
                // List of Contacts to be deleted
                List<Int64> contactIdList = new List<Int64>();
                for (int i = 0; i < SearchFarmResultGridView.Rows.Count; i++)
                {
                    GridViewRow row = SearchFarmResultGridView.Rows[i];
                    bool isChecked = ((CheckBox)row.FindControl("SelectContactCheckBox")).Checked;

                    if (isChecked)
                    {
                        Int64 temp = Int64.Parse(((CheckBox)row.FindControl("SelectContactCheckBox")).ToolTip);
                        contactIdList.Add(temp);
                    }
                }
                
                try
                {
                    // Get the common web service instance.

                    ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                    FarmService.FarmService farmService = serviceLoader.GetFarm();
                    for (int j = 0; j < contactIdList.Count; j++)
                        farmService.DeleteContact(contactIdList[j], LoginUserId);
                    MessageLiteral.Text = "Selected Contacts have been Deleted";
                    int CurrentPageIndex = SearchFarmResultGridView.PageIndex;

                    string where = GenerateSearchCondition();
                    FarmService.FarmDetailsReportInfo[] farms = farmService.GetSearchFarmData(where);
                    SearchFarmResultGridView.DataSource = farms;
                    SearchFarmResultGridView.PageIndex = CurrentPageIndex;
                    SearchFarmResultGridView.DataBind();

                    //Disable actions on deleted Contacts
                    for (int k = 0; k < SearchFarmResultGridView.Rows.Count; k++)
                        if (farms[SearchFarmResultGridView.Rows[k].DataItemIndex].Deleted)
                            SearchFarmResultGridView.Rows[k].Cells[1].Enabled = false;

                    ResultCountLiteral.Text = "Found " + farms.Length + " matching records.";
                }
                catch (Exception exception)
                {
                    log.Error("UNKNOWN ERROR WHILE DELECTING CONATACTS:", exception);
                    MessageLiteral.Text = "UNKNOWN ERROR : Please Contact Administrator";
                }
            }
            DeleteMessageHiddenField.Value = "";
            DeleteConformationHiddenField.Value = "";
            DeleteContactIdHiddenField.Value = "";
        }
    }

    protected void SelectedAgentButton_Click(object sender, EventArgs e)
    {
        if (AgentListDropDownList.SelectedIndex > 0)
        {
            SearchCriteriaPane.Visible = true;
            AgentListErrorLiteral.Text = "";
        }
        else
        {
            AgentListErrorLiteral.Text = "Please Select an Agent.";
            return;
        }
        try
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm(); 
            FarmDropDownList.DataSource = farmService.GetFarmListForUser(GetAgentId());
            FarmDropDownList.DataValueField = "FarmId";
            FarmDropDownList.DataTextField = "FarmName";
            FarmDropDownList.DataBind();
            FarmDropDownList.Items.Insert(0, new ListItem("All Farms", "0"));
            PlotDropDownList.Items.Add(new ListItem("All Plots", "0"));
            
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR IN SEARCH FARM AGENT SELECTION:", exception);
            ErrorLiteral.Text = "UNKNOWN ERROR: Please Contact Administrator";
        }
    }

    protected void SearchContactsButton_Click(object sender, EventArgs e)
    {
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            string where = GenerateSearchCondition();
            FarmService.FarmDetailsReportInfo[] farms = farmService.GetSearchFarmData(where);
            SearchFarmResultGridView.DataSource = farms;
            SearchFarmResultGridView.DataBind();

            //Disable actions on deleted Contacts
            for (int i = 0; i < SearchFarmResultGridView.Rows.Count; i++)
            {
                if (farms[SearchFarmResultGridView.Rows[i].DataItemIndex].Deleted)
                    SearchFarmResultGridView.Rows[i].Cells[1].Enabled = false;
            }

            if (IsPrinterRole)
            {
                SearchFarmResultGridView.Columns[0].Visible = false;
                SearchFarmResultGridView.Columns[1].Visible = false;
                DeleteButton.Visible = false;
            }

            SearchCriteriaPane.Visible = false;
            SearchResultPane.Visible = true;
            ResultCountLiteral.Text = "Farm data results - " + farms.Length + " Contacts found.";
            if (farms.Length == 0)
                NoSearchResultPane.Visible = true;
            else
                NoSearchResultPane.Visible = false;
            if (!IsAgentRole)
            {
                AgentListPanel.Visible = false;
                ForAgentLiteral.Text = AgentListDropDownList.SelectedValue.ToString() + " / " + AgentListDropDownList.SelectedItem.Text;
            }
            MessageLiteral.Text = "";
            Session["SearchFarmDataWhere"] = where;
            Session["SearchFarmDataPageIndex"] = "1";
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR IN SEARCH FARM RESULT FETCHING:", exception);
            ErrorLiteral.Text = "UNKNOWN ERROR: Please Contact Administrator";
        }
    }

    protected void SearchFarmResultGridView_PageIndexChanging(object sender,
                        GridViewPageEventArgs e)
    {
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            string where = "";
            if (Session["SearchFarmDataWhere"] != null)
                where = Session["SearchFarmDataWhere"].ToString();
            else
                where = GenerateSearchCondition();

            FarmService.FarmDetailsReportInfo[] farms = farmService.GetSearchFarmData(where);
            SearchFarmResultGridView.DataSource = farms;
            SearchFarmResultGridView.PageIndex = e.NewPageIndex;
            SearchFarmResultGridView.DataBind();

            //Disable actions on deleted Contacts
            for (int i = 0; i < SearchFarmResultGridView.Rows.Count; i++)
                if (farms[SearchFarmResultGridView.Rows[i].DataItemIndex].Deleted)
                    SearchFarmResultGridView.Rows[i].Cells[1].Enabled = false;
            MessageLiteral.Text = "";
            Session["SearchFarmDataPageIndex"] = e.NewPageIndex.ToString();
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR IN SEARCH FARM RESULT FETCHING:", exception);
            ErrorLiteral.Text = "UNKNOWN ERROR: Please Contact Administrator";
        }
    }

    protected void FarmDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (FarmDropDownList.SelectedValue.ToString().Equals("0"))
        {
            PlotDropDownList.Items.Clear();
            PlotDropDownList.Items.Add(new ListItem("All Plots", "0"));
        }
        else
        {
            try
            {
                int farmId = 0;
                farmId = int.Parse(FarmDropDownList.SelectedValue.ToString());
                // Get the common web service instance.
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                PlotDropDownList.DataSource = farmService.GetPlotListForFarm(farmId);
                PlotDropDownList.DataValueField = "PlotId";
                PlotDropDownList.DataTextField = "PlotName";
                PlotDropDownList.DataBind();
                PlotDropDownList.Items.Insert(0, new ListItem("All Plots", "0"));
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR IN SEARCH FARM FARM SELECTION CHANGED:", exception);
                ErrorLiteral.Text = "UNKNOWN ERROR: Please Contact Administrator";
            }
        }
    }
    
    protected void BackToSearchPanel_Click(object sender, EventArgs e)
    {
        SearchCriteriaPane.Visible = true;
        SearchResultPane.Visible = false;
        if (!IsAgentRole)
        {
            AgentListPanel.Visible = true;
            ForAgentLiteral.Text = "";
        }
        ResultCountLiteral.Text = "Search for the Farm Contacts";
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        Int64 contactId = 0;
        
        for (int i = 0; i < SearchFarmResultGridView.Rows.Count; i++)
        {
            GridViewRow row = SearchFarmResultGridView.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("SelectContactCheckBox")).Checked;
            if (isChecked)
                contactId = Int64.Parse(((CheckBox)row.FindControl("SelectContactCheckBox")).ToolTip);
        }
        
        try
        {
            // Get the common web service instance.

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            DeleteMessageHiddenField.Value = farmService.GetDeleteContactConsiquence(contactId) + " Are you sure you want to delete the Contact.";
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE DELECTING CONATACTS:", exception);
            MessageLiteral.Text = "UNKNOWN ERROR : Please Contact Administrator";
        }

        /*
         * OLD Bulk DELETE Code
        // List of Contacts to be deleted
        List<Int64> contactIdList = new List<Int64>();
        for (int i = 0; i < SearchFarmResultGridView.Rows.Count; i++)
        {
            GridViewRow row = SearchFarmResultGridView.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("SelectContactCheckBox")).Checked;

            if (isChecked)
            {
                Int64 temp = Int64.Parse(((CheckBox)row.FindControl("SelectContactCheckBox")).ToolTip);
                contactIdList.Add(temp);
            }
        }

        if (contactIdList.Count > 0)
        {
            // Delete the List of Selected Contacts
            try
            {
                // Get the common web service instance.

                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();

                for (int j = 0; j < contactIdList.Count; j++)
                    farmService.DeleteContact(contactIdList[j], LoginUserId);
                MessageLiteral.Text = "Selected Contacts have been Deleted";
                int CurrentPageIndex = SearchFarmResultGridView.PageIndex;

                string where = GenerateSearchCondition();
                FarmService.FarmDetailsReportInfo[] farms = farmService.GetSearchFarmData(where);
                SearchFarmResultGridView.DataSource = farms;
                SearchFarmResultGridView.PageIndex = CurrentPageIndex;
                SearchFarmResultGridView.DataBind();

                //Disable actions on deleted Contacts
                for (int k = 0; k < SearchFarmResultGridView.Rows.Count; k++)
                    if (farms[SearchFarmResultGridView.Rows[k].DataItemIndex].Deleted)
                        SearchFarmResultGridView.Rows[k].Cells[1].Enabled = false;

                ResultCountLiteral.Text = "Found " + farms.Length + " matching records.";
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR WHILE DELECTING CONATACTS:", exception);
                MessageLiteral.Text = "UNKNOWN ERROR : Please Contact Administrator";
            }
        }
         */
    }

    #endregion
}

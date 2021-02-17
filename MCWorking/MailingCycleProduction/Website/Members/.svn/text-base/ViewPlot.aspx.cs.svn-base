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
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLL;

using log4net;
using log4net.Config;
#endregion


public partial class ViewPlot : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(ViewPlot));
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
    public int GetAgentId()
    {
        if (IsAgentRole)
            return LoginUserId;
        else
            return Convert.ToInt32(UserIdHiddenField.Value.ToString());
    }
    #endregion

    #region Event Handlers

    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsPrinterRole)
            {
                MoveToButton.Enabled = false;
                DeleteContactButton.Enabled = false;
                DeletePlotButton.Enabled = false;
                AddContactButton.Enabled = false;
                EditPlotButton.Enabled = false;
            }
            int plotId = 0;

            if ((Request.QueryString["plotId"] != "") && (Request.QueryString["plotId"] != null))
                int.TryParse(Request.QueryString["plotId"], out plotId);

            if (plotId == 0)
                Response.Redirect("~/Members/FarmManagement.aspx");

            ExportToExcelButton.CausesValidation = false;
            ExportToExcelButton.OnClientClick = "javascript: window.open('./ExcelOrCsvFileDownload.aspx?plotId=" + plotId.ToString() + "');"; 
            PlotIdHiddenField.Value = plotId.ToString();

            try
            {
                // Get the common web service instance.
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                int userId = farmService.GetUserIdForPlot(plotId);
                UserIdHiddenField.Value = userId.ToString();
                if (!IsAgentRole)
                {
                    ForAgentLiteral.Visible = true;
                    RegistrationService.RegistrationService regservice = serviceLoader.GetRegistration();
                    RegistrationService.RegistrationInfo regInfo = regservice.GetDetails(userId);
                    ForAgentLiteral.Text = "Selected Agent: " + regInfo.UserName + " / " + regInfo.FirstName + " " + regInfo.LastName + "&nbsp;";
                    ForAgentUserIdHiddenField.Value = userId.ToString();
                }
                else
                {
                    ForAgentLiteral.Visible = false;
                }
                FarmService.PlotInfo plot = farmService.GetPlotDetail(plotId);
                PlotNameLabel.Text = plot.PlotName;
                ContactCountLabel.Text = plot.ContactCount.ToString();
                CreateDateLabel.Text = plot.CreateDate.ToShortDateString();
                FarmIdHiddenField.Value = plot.FarmId.ToString();
                ContactListGridView.DataSource = plot.Contacts;
                ContactListGridView.DataBind();
                
                //Default Plot flag for validation in Javascript
                if(farmService.IsDefaultPlot(plotId))
                    DefaultPlotFlagHiddenField.Value = "true";
                else
                    DefaultPlotFlagHiddenField.Value = "false";

                //Validation related Data stored in Hidden Field 
                if (farmService.IsDefaultPlot(plot.PlotId))
                {
                    DefaultContactHiddenField.Value = "true";
                    MoveToButton.Enabled = true;

                    //Move to for single contact in a default plot disabled

                    /*if (plot.Contacts.Length < 2)
                        MoveToButton.Enabled = false;
                    else
                        MoveToButton.Enabled = true;*/
                }
                else
                {
                    DefaultContactHiddenField.Value = "false";
                    MoveToButton.Enabled = true;
                }

                ContactCountHiddenField.Value = plot.Contacts.Length.ToString();
                
                //For Single Contact in Default Plot
                if(IsPrinterRole)
                    for (int i = 0; i < plot.Contacts.Length; i++)
                    {
                        ContactListGridView.Rows[i].Cells[0].FindControl("EditContactHyperLink").Visible = false;
                        ContactListGridView.Rows[i].Cells[0].FindControl("ContactIdCheckBox").Visible = false;
                    }
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR:", exception);
            }
        }
    }

    protected void ContactListGridView_PageIndexChanging(object sender,
                        GridViewPageEventArgs e)
    {
        try
        {
            // Get the common web service instance.

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            int plotId = 0;
            int.TryParse(PlotIdHiddenField.Value, out plotId);
            FarmService.ContactInfo[] contacts = farmService.GetContactListForPlot(plotId);
            ContactListGridView.DataSource = contacts;
            ContactListGridView.PageIndex = e.NewPageIndex;
            ContactListGridView.DataBind();

            //Validation related Data stored in Hidden Field 
            if (farmService.IsDefaultPlot(plotId))
            {
                DefaultContactHiddenField.Value = "true";
                MoveToButton.Enabled = true;
                //Move to for single contact in a default plot disabled
                /*if (contacts.Length < 2)
                    MoveToButton.Enabled = false;
                else
                    MoveToButton.Enabled = true;*/
            }
            else
            {
                DefaultContactHiddenField.Value = "false";
                MoveToButton.Enabled = true;
            }

            ContactCountHiddenField.Value = contacts.Length.ToString();
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR:", exception);
        }
    }
    protected void AddContactButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/CreateContact.aspx?plotId=" + PlotIdHiddenField.Value.ToString());
    }
    protected void DeleteContactButton_Click(object sender, EventArgs e)
    {
        // List of Contacts to be deleted
        List<Int64> contactIdList = new List<Int64>();
        for (int i = 0; i < ContactListGridView.Rows.Count; i++)
        {
            GridViewRow row = ContactListGridView.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("ContactIdCheckBox")).Checked;

            if (isChecked)
            {
                Int64 temp = Int64.Parse(((CheckBox)row.FindControl("ContactIdCheckBox")).ToolTip);
                contactIdList.Add(temp);
            }
        }

        if (contactIdList.Count < 1) // Atleast One Contact to be selected
            MessageLiteral.Text = "Select Atleast One Contact to Delete";
        else
        {
            // Delete the List of Selected Contacts
            try
            {
                // Get the common web service instance.

                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();

                for (int i = 0; i < contactIdList.Count; i++)
                    farmService.DeleteContact(contactIdList[i], LoginUserId);
                MessageLiteral.Text = "Selected Contact List deleted";

                int plotId = 0;
                int.TryParse(PlotIdHiddenField.Value, out plotId);

                int plotContactCount = farmService.GetContactCountForPlot(plotId);

                // Check If Plot is Empty
                if (plotContactCount > 0)
                {
                    ContactCountLabel.Text = plotContactCount.ToString();
                    FarmService.ContactInfo[] contacts = farmService.GetContactListForPlot(plotId);
                    ContactListGridView.DataSource = contacts;
                    ContactListGridView.DataBind();
                    if (farmService.IsDefaultPlot(plotId))
                        DefaultContactHiddenField.Value = "true";
                    else
                        DefaultContactHiddenField.Value = "false";

                    ContactCountHiddenField.Value = contacts.Length.ToString();
                }
                else // Action for Empty Plot is to remove the Plot
                {
                    farmService.DeletePlot(plotId,LoginUserId);
                    //Check for Empty Farm
                    if (farmService.GetPlotCountForFarm(Convert.ToInt32(FarmIdHiddenField.Value)) > 0)
                        Response.Redirect("~/Members/ViewFarm.aspx?farmId=" + FarmIdHiddenField.Value.ToString());
                    else // Action for Empty Farm is to remove Farm
                    {
                        farmService.DeleteFarm(Convert.ToInt32(FarmIdHiddenField.Value), LoginUserId);
                        Response.Redirect("~/Members/FarmManagement.aspx");
                    }
                }
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR WHILE DELETE CONTACT:", exception);
                if (exception.Message.Contains("This action will cause Farm to be deleted and the Parent-Farm is Active. Hence Contact Cannot be deleted"))
                    MessageLiteral.Text = "This action will cause Farm to be deleted and the Parent-Farm is Active. Hence Contact Cannot be deleted";

                else
                    MessageLiteral.Text = "Error: Unable to Delete Contact";
            }
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/ViewFarm.aspx?farmId=" + FarmIdHiddenField.Value.ToString());
    }

    protected void ExportToExcelButton_Click(object sender, EventArgs e)
    {
        //ExcelOrCsvFileDownload.aspx;
        /*
        try
        {
            // Get the common web service instance.

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            int plotId = 0;
            int.TryParse(PlotIdHiddenField.Value, out plotId);
            RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];

            String fileName = farmService.ExportContactListToExcel(loginInfo.UserId, plotId);

            Response.Redirect("~/Members/UserData/" + loginInfo.UserId.ToString() + "/" + fileName);
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE EXPORTING CONTACT LIST:", exception);
            MessageLiteral.Text = "Error: Unable to Export Contact List to Excel File";
        }
       */

    }
    protected void EditPlotButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/ModifyPlot.aspx?plotId=" + PlotIdHiddenField.Value.ToString() + "&farmId=" + FarmIdHiddenField.Value.ToString() + "&PageName=ViewPlot.aspx");
    }
    protected void DeletePlotButton_Click(object sender, EventArgs e)
    {
        try
        {
            // Get the common web service instance.

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            int plotId = 0;
            int.TryParse(PlotIdHiddenField.Value, out plotId);

            farmService.DeletePlotContact(plotId,LoginUserId);
            int farmId = 0;
            int.TryParse(FarmIdHiddenField.Value.ToString(), out farmId);
            int plotCount = farmService.GetPlotCountForFarm(farmId);
            if (plotCount == 0)
            {
                Response.Redirect("~/Members/FarmManagement.aspx");
            }
            else
            {
                Response.Redirect("~/Members/ViewFarm.aspx?farmId=" + FarmIdHiddenField.Value.ToString());
            }
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE DELETING PLOT:", exception);
            if (exception.Message.Contains("This action will cause Farm to be deleted and the Parent-Farm is Active. Hence Plot Cannot be deleted"))
                MessageLiteral.Text = "Error: Farm is currently Firmed Up. It is not possible to delete any Firmed Up mailing plan or Farm. If you still want to delete it, please speak to Customer Service 1-800-Mailing";

            else
                MessageLiteral.Text = "Error: Unable to delete Plot";
        }
    }
    #endregion

    #endregion
    
}

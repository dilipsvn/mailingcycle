#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CreatePlot.aspx
    * Created Date      : 10/25/2007
	* Last Modify Date  : 10/25/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to create the Plot
	* Source			: MailingCycle\CreatePlot.aspx.cs

	****************************************************************/
#endregion

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
using Irmac.MailingCycle.Model;

using log4net;
using log4net.Config;
#endregion


public partial class Agent_CreatePlot : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Agent_CreatePlot));
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

    public int LoginUserId
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return regInfo.UserId;
        }
    }
    #endregion

    #region Event Handlers
    #region Page Event Handler
    
    protected int GetAgentId()
    {
        if (IsAgentRole)
            return LoginUserId;
        else
            return Convert.ToInt32(UserIdHiddenField.Value.ToString());
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;

            int farmId = 0;
            if ((Request.QueryString["farmId"] != "") && (Request.QueryString["farmId"] != null))
                int.TryParse(Request.QueryString["farmId"], out farmId);

            if (farmId == 0)
                Response.Redirect("~/Members/FarmManagement.aspx");

            FarmIdHiddenField.Value = farmId.ToString();
            try
            {
                // Get the common web service instance.

                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                int userId = farmService.GetUserIdForFarm(farmId);
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

                FarmService.FarmInfo farm = farmService.GetFarmDetail(farmId);
                FarmNameLabel.Text = farm.FarmName;
                MailingPlanLabel.Text = farm.MailingPlan.Title;
                CreateDateLabel.Text = farm.CreateDate.ToShortDateString();
                FarmContactCountLabel.Text = farm.ContactCount.ToString();

            }
            catch (Exception ex)
            {
                log.Error("UNKNOWN ERROR:", ex);
            }
        }
    }

    protected void CreatePlotButton_Click(object sender, EventArgs e)
    {
        //Store Plot Details and Plot Contact details into the Session
        try
        {

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();
            
            //Checking File Type
            if (!ContactListFileUpload.HasFile)
            {
                ErrorLiteral.Text = "Please Select The File";
                return;
            }

            IList<FarmService.ContactInfo> contacts;

            if (ContactListFileUpload.FileName.EndsWith(".csv"))
            {
                contacts = farmService.GetFarmListFromFile(ContactListFileUpload.FileName, Irmac.MailingCycle.BLLServiceLoader.Farm.ContactFileType.Csv, ContactListFileUpload.FileBytes, LoginUserId);
            }
            else
            {
                if (ContactListFileUpload.FileName.EndsWith(".xls"))
                {
                    contacts = farmService.GetFarmListFromFile(ContactListFileUpload.FileName, Irmac.MailingCycle.BLLServiceLoader.Farm.ContactFileType.Excel, ContactListFileUpload.FileBytes, LoginUserId);
                }
                else
                {
                    ErrorLiteral.Text = "Invalid File Uploaded. Please Check your file Extention (Must be either .csv or .xls)";
                    return;
                }
            }

            if (farmService.IsPlotNameDuplicateWhileAddingNewPlot(Convert.ToInt32(Request.QueryString["farmId"]), PlotNameTextBox.Text))
            {
                ErrorLiteral.Text = "Plot name already exists, Please enter a different Plot name";
                return;
            }


            ContactListGridView.DataSource = contacts;
            ContactListGridView.DataBind();
            Panel1.Visible = false;
            Panel2.Visible = true;
            Session["Contacts"] = contacts;
            ErrorLiteral.Text = "";
        }
        catch (Exception ex)
        {
            log.Error("UNKNOWN ERROR:", ex);
            if (ex.Message.Contains("Irmac.MailingCycle.BLL.NoDataException"))
            {
                ErrorLiteral.Text = "The file does not have any data.";
            }
            else if (ex.Message.Contains("Irmac.MailingCycle.BLL.InvalidFormatException"))
            {
                ErrorLiteral.Text = "The file is in invalid format.";
            }
            else if (ex.Message.Contains("Irmac.MailingCycle.BLL.InvalidDataException"))
            {
                ErrorLiteral.Text = "Incomplete data in the uploaded file.";
            }
            else if (ex.Message.Contains("Irmac.MailingCycle.BLL.InvalidFieldDataException"))
            {
                ErrorLiteral.Text = "Incomplete data in the uploaded file.";
            }
            else if (ex.Message.Contains("Plot Name already in use. Please provide a new Plot Name"))
            {
                ErrorLiteral.Text = "Plot Name already in use. Please provide a new Plot Name";
            }
            else if (ex.Message.Contains("No valid Contact records in uploaded File."))
            {
                ErrorLiteral.Text = "No valid Contact records in uploaded File.";
            }
            else
            {
                ErrorLiteral.Text = "Unknown Error. Please Contact Administrator.";
            }
        }
    }

    protected void ContactListGridView_PageIndexChanging(object sender,
                        GridViewPageEventArgs e)
    {
        ContactListGridView.DataSource = (IList<FarmService.ContactInfo>)Session["Contacts"];
        ContactListGridView.PageIndex = e.NewPageIndex;
        ContactListGridView.DataBind();
    }

    protected void ApproveButton_Click(object sender, EventArgs e)
    {
        bool isError = false;
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();
            IList<FarmService.ContactInfo> contacts = (IList<FarmService.ContactInfo>)Session["Contacts"];
            Session.Remove("Contacts");
            FarmService.PlotInfo plot = new FarmService.PlotInfo();

            plot.PlotId = 0;
            plot.PlotName = PlotNameTextBox.Text;
            plot.FarmId = Convert.ToInt32(FarmIdHiddenField.Value.ToString());
            plot.Contacts = (FarmService.ContactInfo[])contacts;
            plot.LastModifyBy = LoginUserId;
            farmService.CreatePlot(plot);
        }
        catch (Exception exception)
        {
            if (exception.Message.Contains("Plot Name already in use. Please provide a new Plot Name"))
            {
                ErrorLiteral.Text = "Plot Name already in use. Please provide a new Plot Name";
            }
            else if (exception.Message.Contains("No Contacts processed. Plot cannot be Empty."))
            {
                ErrorLiteral.Text = "No Contacts processed. Plot cannot be Empty.";
            }
            else
            {
                ErrorLiteral.Text = "UNKNOWN ERROR WHILE CREATING A PLOT. Please Contact Administrator";
                log.Error("UNKNOWN ERROR WHILE CREATING A PLOT:", exception);
            }
            isError = true;
        }
        if(!isError)
            Response.Redirect("~/Members/ViewFarm.aspx?farmId=" + Request.QueryString["farmId"]);
    }

    protected void ReloadButton_Click(object sender, EventArgs e)
    {
        Session.Remove("Contacts");
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    #endregion


    #endregion
    



}

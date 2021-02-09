#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CreateFarm.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to create the farm
	* Source			: MailingCycle\CreateFarm.aspx.cs

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

public partial class CreateFarm : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(CreateFarm));
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
                try
                {
                    // Get the common web service instance.
                    int userId = 0;
                    
                    if ((Request.QueryString["userId"] != "") && (Request.QueryString["userId"] != null))
                        int.TryParse(Request.QueryString["userId"], out userId);
                    
                    if (userId == 0)
                        Response.Redirect("~/Members/FarmManagement.aspx");

                    UserIdHiddenField.Value = userId.ToString();
                    ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                    FarmService.FarmService farmService = serviceLoader.GetFarm();

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

                    IList<FarmService.MailingPlanInfo> mailingPlans = farmService.GetMailingPlanList();
                    MailingPlanDropDownList.DataSource = mailingPlans;
                    MailingPlanDropDownList.DataValueField = "MailingPlanId";
                    MailingPlanDropDownList.DataTextField = "Title";
                    MailingPlanDropDownList.DataBind();
                }
                catch (Exception ex)
                {
                    log.Error("UNKNOWN ERROR:", ex);
                }
            }
        }

        protected void CreateFarmButton_Click(object sender, EventArgs e)
        {
            //Store Farm Details and Farm Contact details into the Session
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

                //Check for Duplicate Farm Name
                if (farmService.IsFarmNameDuplicateWhileAddingNewFarm(GetAgentId(), FarmNameTextBox.Text))
                {
                    ErrorLiteral.Text = "Farm name already exists, Please enter a different farm name";
                    return;
                }

                //Load the Contact File List
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

                ContactListGridView.DataSource = contacts;
                ContactListGridView.DataBind();
                Panel1.Visible = false;
                Panel2.Visible = true;
                Session["Contacts"] = contacts;
                ErrorLiteral.Text = "";
            }
            catch (Exception ex)
            {
                log.Error("UNKNOWN ERROR WHILE CONTACT FILE UPLOAD:", ex);
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
                else if (ex.Message.Contains("Farm Name already Exist. Please give another name"))
                {
                    ErrorLiteral.Text = "Farm Name already Exist. Please give another name.";
                }
                else if (ex.Message.Contains("No valid Contact records in the uploaded File."))
                {
                    ErrorLiteral.Text = "No valid Contact records in the uploaded File.";
                }
                else
                {
                    ErrorLiteral.Text = "Unknown Error. Please Contact Administrator.";
                }
            }
        }

        protected void ContactListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
                FarmService.FarmInfo farm = new FarmService.FarmInfo();
                farm.FarmName = FarmNameTextBox.Text;
                farm.MailingPlan = new FarmService.MailingPlanInfo();
                farm.MailingPlan.MailingPlanId = int.Parse(MailingPlanDropDownList.SelectedValue);
                farm.LastModifyBy = LoginUserId;
                farm.Plots = new FarmService.PlotInfo[1];
                farm.Plots[0] = new FarmService.PlotInfo();
                farm.Plots[0].PlotId = 0;
                farm.Plots[0].PlotName = FarmNameTextBox.Text;
                farm.Plots[0].Contacts = (FarmService.ContactInfo[])contacts;
                farm.Plots[0].LastModifyBy = LoginUserId;
                farm.UserId = GetAgentId();
                farmService.CreateFarmPlot(farm);
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("No Contacts processed. Farm cannot be Empty."))
                {
                    ErrorLiteral.Text = "No Contacts processed. Farm cannot be Empty.";
                }
                else
                {
                    log.Error("UNKNOWN ERROR WHILE CREATING Farm:", exception);
                    ErrorLiteral.Text = "UNKNOWN ERROR WHILE CREATING Farm. Please Contact Administrator";
                }
                isError = true;
            }
            if(!isError)
                Response.Redirect("~/Members/FarmManagement.aspx");
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

#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ModifyFarm.aspx
    * Created Date      : 10/22/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to modify the farm
	* Source			: MailingCycle\ModifyFarm.aspx.cs

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
using ScheduleService = Irmac.MailingCycle.BLLServiceLoader.Schedule;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;

using log4net;
using log4net.Config;
#endregion

public partial class Agent_ModifyFarm : System.Web.UI.Page
{

    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Agent_ModifyFarm));
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

    public int GetAgentId()
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

                int farmId = 0;
                if((Request.QueryString["farmId"]!="") && (Request.QueryString["farmId"] != null))
                    int.TryParse(Request.QueryString["farmId"], out farmId );

                if (farmId == 0)
                    Response.Redirect("~/Members/FarmManagement.aspx");

                // Get the common web service instance.

                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                ScheduleService.ScheduleService scheduleService = serviceLoader.GetSchedule();

                IList<FarmService.MailingPlanInfo> mailingPlans = farmService.GetMailingPlanList();
                MailingPlanDropDownList.DataSource = mailingPlans;
                MailingPlanDropDownList.DataValueField = "MailingPlanId";
                MailingPlanDropDownList.DataTextField = "Title";
                MailingPlanDropDownList.DataBind();

                FarmService.FarmInfo farm = farmService.GetFarmDetail(farmId);
                farm.UserId = farmService.GetUserIdForFarm(farmId);
                UserIdHiddenField.Value = farm.UserId.ToString();
                if (!IsAgentRole)
                {
                    ForAgentLiteral.Visible = true;
                    RegistrationService.RegistrationService regservice = serviceLoader.GetRegistration();
                    RegistrationService.RegistrationInfo regInfo = regservice.GetDetails(farm.UserId);
                    ForAgentLiteral.Text = "Selected Agent: " + regInfo.UserName + " / " + regInfo.FirstName + " " + regInfo.LastName + "&nbsp;";
                    ForAgentUserIdHiddenField.Value = farm.UserId.ToString();
                }
                else
                {
                    ForAgentLiteral.Visible = false;
                }


                FarmIdHiddenField.Value = farm.FarmId.ToString();
                PlotIdHiddenField.Value = farm.Plots[0].PlotId.ToString();
                FarmNameTextBox.Text = farm.FarmName;
                MailingPlanDropDownList.SelectedValue = farm.MailingPlan.MailingPlanId.ToString();
                if (farm.Plots[0].ContactCount > 0)
                    ContactListFileRequiredFieldValidator.Enabled = false;
                if (farm.Firmup)
                    MailingPlanDropDownList.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("UNKNOWN ERROR:", ex);
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

    protected void ModifyFarmButton_Click(object sender, EventArgs e)
    {
        //Store Farm Details and Farm Contact details into the Session
        try
        {

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();
                        
            //Checking For Duplicate Farm Name
            if (farmService.IsFarmNameDuplicateWhileEditingFarm(
                GetAgentId(),
                Convert.ToInt32(FarmIdHiddenField.Value), 
                FarmNameTextBox.Text))
            {
                ErrorLiteral.Text = "Farm name already exists, Please enter a different farm name";
                return;
            }

            IList<FarmService.ContactInfo> contacts=null;
            //Checking File Type
            if (ContactListFileUpload.HasFile)
            {

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
            }

            if (contacts != null)
            {
                ContactListGridView.DataSource = contacts;
                ContactListGridView.DataBind();
                Panel1.Visible = false;
                Panel2.Visible = true;
                Session["Contacts"] = contacts;
                if (!IsAgentRole)
                {
                    ForAgentLiteral1.Visible = true;
                    ForAgentLiteral1.Text = ForAgentLiteral.Text;
                }
                else
                    ForAgentLiteral1.Visible = false;

                ErrorLiteral.Text = "";
            }
            else
            {
                FarmService.FarmInfo farm = new FarmService.FarmInfo();
                farm.FarmId = Convert.ToInt32(FarmIdHiddenField.Value);
                farm.FarmName = FarmNameTextBox.Text;
                farm.MailingPlan = new FarmService.MailingPlanInfo();
                farm.MailingPlan.MailingPlanId = int.Parse(MailingPlanDropDownList.SelectedValue);
                farm.LastModifyBy = LoginUserId;
                farm.Plots = new FarmService.PlotInfo[1];
                farm.Plots[0] = new FarmService.PlotInfo();
                farm.Plots[0].PlotId = Convert.ToInt32(PlotIdHiddenField.Value);
                farm.Plots[0].PlotName = FarmNameTextBox.Text;
                farm.Plots[0].LastModifyBy = LoginUserId;
                farm.Plots[0].Contacts = null;
                farm.UserId = GetAgentId();
                farmService.UpdateFarmPlot(farm);
                Response.Redirect(GetRedirectURL());
            }
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
            else if (ex.Message.Contains("Farm Name already Exist"))
            {
                ErrorLiteral.Text = "Farm Name already exists";
            }
            else if (ex.Message.Contains("You are changing Farm Name and this will change the name of Primary Plot.This name already existing in its Plot lists. Please Provide a different Farm name."))
            {
                ErrorLiteral.Text = "You are changing Farm Name and this will change the name of Primary Plot.This name already existing in its Plot lists. Please Provide a different Farm name.";
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

    protected void ApproveButton_Click(object sender, EventArgs e)
    {
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();
            
            IList<FarmService.ContactInfo> contacts = (IList<FarmService.ContactInfo>)Session["Contacts"];
            Session.Remove("Contacts");
            FarmService.FarmInfo farm = new FarmService.FarmInfo();
            farm.FarmId = Convert.ToInt32(FarmIdHiddenField.Value);
            farm.FarmName = FarmNameTextBox.Text;
            farm.MailingPlan = new FarmService.MailingPlanInfo();
            farm.MailingPlan.MailingPlanId = int.Parse(MailingPlanDropDownList.SelectedValue);
            farm.LastModifyBy = LoginUserId;
            farm.Plots = new FarmService.PlotInfo[1];
            farm.Plots[0] = new FarmService.PlotInfo();
            farm.Plots[0].PlotId = Convert.ToInt32(PlotIdHiddenField.Value);
            farm.Plots[0].PlotName = FarmNameTextBox.Text;
            farm.Plots[0].LastModifyBy = LoginUserId;
            farm.Plots[0].Contacts = (FarmService.ContactInfo[])contacts;
            farm.UserId = GetAgentId();
            farmService.UpdateFarmPlot(farm);
            Response.Redirect(GetRedirectURL());
        }
        catch (Exception exception)
        {
            if (exception.Message.Contains("You are changing Farm Name and this will change the name of Primary Plot.This name already existing in its Plot lists. Please Provide a different Farm name."))
            {
                ErrorLiteral1.Text = "You are changing Farm Name and this will change the name of Primary Plot.This name already existing in its Plot lists. Please Provide a different Farm name.";
            }
            else
            {
                ErrorLiteral1.Text = "UNKNOWN ERROR! PLEASE CONTACT ADMINISTRATOR";
                log.Error("UNKNOWN ERROR WHILE APPROVING THE CONTACT LISTS IN MODIFY FARM:", exception);
            }
        }

    }

    protected void ReloadButton_Click(object sender, EventArgs e)
    {
        Session.Remove("Contacts");
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    private string GetRedirectURL()
    {
        string pageName = Request.QueryString["Page"];
        string URL = "";
        if (pageName.ToUpper() == "FARMMANAGEMENT.ASPX")
            URL = pageName;
        else
            if (pageName.ToUpper() == "VIEWFARM.ASPX")
                URL = pageName + "?FarmId=" + FarmIdHiddenField.Value;
        return URL;
    }


    protected void CancelFarmButton_Click(object sender, EventArgs e)
    {
       Response.Redirect(GetRedirectURL());
    }                    

}

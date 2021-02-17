#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: Welcome.aspx
    * Created Date      : 10/16/2007
	* Last Modify Date  : 10/16/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to display the Dashboard Summary
	* Source			: MailingCycle\Welcome.aspx.cs

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
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using DesignService = Irmac.MailingCycle.BLLServiceLoader.Design;
using ProductService = Irmac.MailingCycle.BLLServiceLoader.Product;
using ScheduleService = Irmac.MailingCycle.BLLServiceLoader.Schedule;
using Irmac.MailingCycle.BLLServiceLoader.Message;
using Irmac.MailingCycle.BLL;
using log4net;
using log4net.Config;

#endregion

public partial class Agent_Welcome : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Agent_Welcome));
    #endregion

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["loginInfo"] == null || Session["loginInfo"] == "")
            Response.Redirect("../userLogin.aspx?Message=SessionExpired");

        RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
        bool isAgent = (loginInfo.Role == RegistrationService.UserRole.Agent);
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();

        // ************Populate the Farm Data************
        
        FarmService.FarmService farmService = serviceLoader.GetFarm();
        int farmCount=0;
        int plotCount=0;
        long contactCount=0;

        if (isAgent)
        {
            FarmService.FarmInfo[] farmInfo = farmService.GetFarmSummary(loginInfo.UserId);
            farmCount = farmInfo.Length;
            for (int i = 0; i < farmCount; i++)
            {
                plotCount = plotCount + farmInfo[i].PlotCount;
                contactCount = contactCount + farmInfo[i].ContactCount;
            }
        }   
        else
        {
            farmCount = farmService.TotalActiveFarmCount();
            plotCount = farmService.TotalActivePlotCount();
            contactCount = farmService.TotalActiveContactCount();
        }

        FarmPlotLabel.Text = farmCount.ToString() + " Farms / " + plotCount + " Plots";
        ContactLabel.Text = contactCount.ToString() + " Contacts";

        // ************Populate Messages Data************
        MessageService messageService = serviceLoader.GetMessage();
        StandardMessagesLabel.Text = messageService.GetStandardMessageList(isAgent,string.Empty,string.Empty).Length + " messages";

        if(isAgent)
        CustomMessagesLabel.Text = messageService.GetCustomMessageList(loginInfo.UserId).Length + " messages";
        else
        CustomMessagesLabel.Text = messageService.GetCustomMessageList(0).Length  + " messages";


    // ************Populate design Data************
        DesignService.DesignService designService = serviceLoader.GetDesign();

        if (isAgent)
        {
            IList<DesignService.DesignInfo> designs =
                designService.GetList(loginInfo.UserId);

            DesignService.DesignInfo design = new DesignService.DesignInfo();
            DesignService.DesignInfo brochure = new DesignService.DesignInfo();

            foreach (DesignService.DesignInfo designInfo in designs)
            {
                if (designInfo.Category.Name == "PowerKard")
                {
                    design = designInfo;
                }
                else
                {
                    brochure = designInfo;
                }
            }

            PowerKardStatusLabel.Text = design.Status.Name.ToString();
            BrochureStatusLabel.Text = brochure.Status.Name.ToString();
        }
        else
        {
            object[] designStatusArray;
            DataTable designStatusTable = new DataTable();
            designStatusArray = designService.GetSummary();
            designStatusTable = Util.GetDataTable(designStatusArray);

            if(designStatusTable!=null)
            {

                PowerKardStatusLabel.Text = PowerKardStatusLabel.Text + designStatusTable.Rows[0][3] + " - " + designStatusTable.Rows[0][4] + ",";
                PowerKardStatusLabel.Text = PowerKardStatusLabel.Text + designStatusTable.Rows[1][3] + " - " + designStatusTable.Rows[1][4] + ",";
                PowerKardStatusLabel.Text = PowerKardStatusLabel.Text + designStatusTable.Rows[4][3] + " - " + designStatusTable.Rows[4][4] + ",";
                PowerKardStatusLabel.Text = PowerKardStatusLabel.Text.Substring(0,PowerKardStatusLabel.Text.Length-1);

                PowerKardStatusLabel.Text = PowerKardStatusLabel.Text.Replace("Uploaded", "Upd");
                PowerKardStatusLabel.Text = PowerKardStatusLabel.Text.Replace("Submitted", "Sub");
                PowerKardStatusLabel.Text = PowerKardStatusLabel.Text.Replace("Approved", "App");

                BrochureStatusLabel.Text = BrochureStatusLabel.Text + designStatusTable.Rows[5][3] + " - " + designStatusTable.Rows[5][4] + ",";
                BrochureStatusLabel.Text = BrochureStatusLabel.Text + designStatusTable.Rows[6][3] + " - " + designStatusTable.Rows[6][4] + ",";
                BrochureStatusLabel.Text = BrochureStatusLabel.Text + designStatusTable.Rows[9][3] + " - " + designStatusTable.Rows[9][4] + ",";
                BrochureStatusLabel.Text = BrochureStatusLabel.Text.Substring(0, BrochureStatusLabel.Text.Length - 1);

                BrochureStatusLabel.Text = BrochureStatusLabel.Text.Replace("Uploaded", "Upd");
                BrochureStatusLabel.Text = BrochureStatusLabel.Text.Replace("Submitted", "Sub");
                BrochureStatusLabel.Text = BrochureStatusLabel.Text.Replace("Approved", "App");

                WelcomeHelpPanel.Visible = true;
            }
        }
        // ************Populate Inventory Data************

       ProductService.ProductService productService = serviceLoader.GetProduct();
       ProductService.ProductItemInfo[] productItemInfo;
       
       if(isAgent)
           productItemInfo = productService.GetInventoryTotalCount(loginInfo.UserId);
       else
           productItemInfo = productService.GetInventoryTotalCount(0);

       if (productItemInfo.Length < 1)
           InventoryLabel.Text = "PowerKards:0<br>Brochures:0";

       InventoryRepeater.DataSource = productItemInfo;
       InventoryRepeater.DataBind();

       // ************Populate Schedule Management Data************
       ScheduleService.ScheduleService scheduleService = serviceLoader.GetSchedule();

        object[] SchedulePlansArray;
        DataTable SchedulePlansTable = new DataTable();
        if(isAgent)
            SchedulePlansArray = scheduleService.GetSummaryOfUser(loginInfo.UserId);
        else
            SchedulePlansArray = scheduleService.GetSummary();

        SchedulePlansTable = Util.GetDataTable(SchedulePlansArray);

        if (SchedulePlansTable != null)
        {
            ActivePlansLabel.Text = SchedulePlansTable.Rows[0][0].ToString() + ": " + SchedulePlansTable.Rows[0][1].ToString();
            if(Convert.ToInt32(SchedulePlansTable.Rows[1][1].ToString())>0)
                DelayedPlansLabel.Text = SchedulePlansTable.Rows[1][0].ToString() + ": " + SchedulePlansTable.Rows[1][1].ToString();
        }

        //********* Populate User Management Info **********

        if (isAgent)
            UserManagementPanel.Visible = false;
        else
        {
            object[] usersArray;
            DataTable usersTable = new DataTable();
            RegistrationService.RegistrationService registrationService = ServiceAccess.GetInstance().GetRegistration();

            usersArray = registrationService.GetApprovalRequiredUsers();
            usersTable = Util.GetDataTable(usersArray);
            RegistrationService.UserRole userRole;
            if (usersTable != null)
            {
                if (usersTable.Rows.Count < 1)
                    UsersLabel.Text = "No Users waiting for approval";
                else
                {
                    for (int i = 0; i < usersTable.Rows.Count; i++)
                    {
                        userRole = (RegistrationService.UserRole)((Convert.ToInt32(usersTable.Rows[i][0].ToString())-1));
                        UsersLabel.Text = UsersLabel.Text + userRole.ToString() + " : " + usersTable.Rows[i][1].ToString() + "<br>";
                    }
                }
            }
        }
    }
}

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

public partial class SearchFarmDataResults : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(SearchFarmDataResults));
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

    public int GetAgentId()
    {
        if (IsAgentRole)
            return LoginUserId;
        else
            return Convert.ToInt32(UserIdHiddenField.Value.ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int plotId = 100107;

            //if ((Request.QueryString["plotId"] != "") && (Request.QueryString["plotId"] != null))
            //    int.TryParse(Request.QueryString["plotId"], out plotId);

            //if (plotId == 0)
            //    Response.Redirect("~/Members/FarmManagement.aspx");

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
                FarmIdHiddenField.Value = plot.FarmId.ToString();
                ContactListGridView.DataSource = plot.Contacts;
                ContactListGridView.DataBind();

                //Block Edit Course for the Printer
                /*
                if (IsPrinterRole)
                {
                    ContactListGridView.Columns.RemoveAt(0);
                    ContactListGridView.Columns.RemoveAt(1);
                    
                    for (int i = 0; i < plot.Contacts.Length; i++)
                    {
                        ContactListGridView.Rows[i].Cells[0].FindControl("EditContactHyperLink").Visible = false;
                        ContactListGridView.Rows[i].Cells[0].FindControl("ContactIdCheckBox").Visible = false;
                    }
                }
                */
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
            ContactListGridView.DataSource = farmService.GetContactListForPlot(plotId);
            ContactListGridView.PageIndex = e.NewPageIndex;
            ContactListGridView.DataBind();
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR:", exception);
        }
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
                    ContactListGridView.DataSource = farmService.GetContactListForPlot(plotId);
                    ContactListGridView.DataBind();
                }
                else // Action for Empty Plot is to remove the Plot
                {
                    farmService.DeletePlot(plotId, LoginUserId);
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
                MessageLiteral.Text = "Error: Unable to Delete Contact";
            }
        }
    }

}

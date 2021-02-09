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


public partial class Members_ArchivedContactList : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Members_ArchivedContactList));
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

    #region Methords
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
            int plotId = 0;

            if ((Request.QueryString["plotId"] != "") && (Request.QueryString["plotId"] != null))
                int.TryParse(Request.QueryString["plotId"], out plotId);

            if (plotId == 0)
                Response.Redirect("~/Members/ArchivedPlotList.aspx");

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
                    ForAgentPanel.Visible = true;
                    ForAgentUserIdHiddenField.Value = userId.ToString();
                    ForAgentUserNameLabel.Text = farmService.GetUserName(userId);
                }
                else
                {
                    ForAgentPanel.Visible = false;
                }

                //Getting Archived Plot Header Details 
                FarmService.PlotInfo plot = farmService.GetArchivedPlotSummaryDetails(plotId);
                
                //Getting Parent Farm Details
                FarmService.FarmInfo farm = farmService.GetArchivedFarmSummaryDetails(plot.FarmId);
                
                PlotNameLabel.Text = farm.FarmName + " / " + plot.PlotName;
                ContactCountLabel.Text = plot.ContactCount.ToString();
                CreateDateLabel.Text = plot.CreateDate.ToShortDateString();
                FarmIdHiddenField.Value = plot.FarmId.ToString();
                
                FarmService.ContactInfo[] contacts = farmService.GetArchivedContactListForPlot(plotId);
                ContactListGridView.DataSource = contacts;
                ContactListGridView.DataBind();
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR LOADING ARCHIVE CONTACT LIST:", exception);
                MessageLiteral.Text = "UNKNOWN ERROR: Please Contact Administrator";
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
            int plotId = int.Parse(PlotIdHiddenField.Value.ToString());
            FarmService.ContactInfo[] contacts = farmService.GetArchivedContactListForPlot(plotId);
            ContactListGridView.DataSource = contacts;
            ContactListGridView.PageIndex = e.NewPageIndex;
            ContactListGridView.DataBind();
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR IN ARCHIVE CONTACT LIST PAGINATION:", exception);
            MessageLiteral.Text = "UNKNOWN ERROR: Please Contact Administrator";
        }
    }

    protected void RestoreContactButton_Click(object sender, EventArgs e)
    {
        bool jumpError = false;
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();
            int plotId = int.Parse(PlotIdHiddenField.Value.ToString());

            for (int i = 0; i < ContactListGridView.Rows.Count; i++)
            {
                GridViewRow row = ContactListGridView.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("ContactIdCheckBox")).Checked;
                if (isChecked)
                {
                    Int64 contactId = Int64.Parse(((CheckBox)row.FindControl("ContactIdCheckBox")).ToolTip);
                    farmService.RestoreContact(contactId, LoginUserId);
                }
            }

            FarmService.ContactInfo[] contacts = farmService.GetArchivedContactListForPlot(plotId);

            if (contacts.Length == 0)
            {
                Response.Redirect("~/Members/ArchivedPlotList.aspx");
            }
            else
            {
                //Getting Archived Plot Header Details 
                FarmService.PlotInfo plot = farmService.GetArchivedPlotSummaryDetails(plotId);

                //Getting Parent Farm Details
                FarmService.FarmInfo farm = farmService.GetArchivedFarmSummaryDetails(plot.FarmId);

                PlotNameLabel.Text = farm.FarmName + " / " + plot.PlotName;
                ContactCountLabel.Text = plot.ContactCount.ToString();
                CreateDateLabel.Text = plot.CreateDate.ToShortDateString();

                ContactListGridView.DataSource = contacts;
                ContactListGridView.DataBind();
            }
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE RESTORING CONTACT:", exception);
            if (exception.Message.Contains("Parent Plot / Farm is not active. Contact cannot be restored."))
                MessageLiteral.Text = "Parent Plot / Farm is not active. Contact cannot be restored.";
            else
            {
                MessageLiteral.Text = "UNKNOWN ERROR: Please Contact Administrator";
                jumpError = true;
            }
        }
        if(jumpError)
            Response.Redirect("~/Members/ArchivedPlotList.aspx?farmId=" + FarmIdHiddenField.Value.ToString());
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/ArchivedPlotList.aspx?farmId=" + FarmIdHiddenField.Value.ToString());
    }

    #endregion

    #endregion
    

}

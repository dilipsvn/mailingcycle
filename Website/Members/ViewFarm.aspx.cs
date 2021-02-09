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
using DesignService = Irmac.MailingCycle.BLLServiceLoader.Design;
using ScheduleService = Irmac.MailingCycle.BLLServiceLoader.Schedule;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLL;

using log4net;
using log4net.Config;
#endregion

public partial class ViewFarm : System.Web.UI.Page
{

    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(ViewFarm));
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
    #region Event Handlers

    #region Page Event Handler
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsPrinterRole)
            {
                DeleteFarmButton.Enabled = false;
                EditFarmButton.Enabled = false;
                FirmUpButton.Enabled = false;
                CreatePlotButton.Enabled = false;
            }
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
                if (farm.Firmup)
                    FirmupStatusLabel.Text = "Firmed Up";
                else
                    FirmupStatusLabel.Text = "Not Firmed Up";
                FarmContactCountLabel.Text = farm.ContactCount.ToString();
                PlotCountLabel.Text = farm.PlotCount.ToString();

                FillPlotGrid(farm.Plots, 0);

                // ***************** Firm Up ***************** \\
                if (IsAgentRole)
                {
                    // Set the firm up button visible to agent.
                    FirmUpButtonPanel.Visible = true;

                    // Get the mailing plan of the farm.
                    int mailingPlanId = farm.MailingPlan.MailingPlanId;

                    // Get the design details of the agent.
                    DesignService.DesignService designService = serviceLoader.GetDesign();
                    DesignService.DesignInfo design = new DesignService.DesignInfo();
                    DesignService.DesignInfo brochure = new DesignService.DesignInfo();

                    RegistrationService.LoginInfo loginInfo =
                        (RegistrationService.LoginInfo)Session["loginInfo"];
                    IList<DesignService.DesignInfo> designs =
                        designService.GetList(loginInfo.UserId);

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

                    // Get the credit card details of the logged in agent.
                    RegistrationService.RegistrationService registrationService = 
                        serviceLoader.GetRegistration();
                    RegistrationService.CreditCardInfo creditCard = 
                        registrationService.GetCreditCard(loginInfo.UserId);
                    bool isCreditCardValid = false;

                    if (creditCard != null)
                    {
                        DateTime expirationDate = 
                            new DateTime(creditCard.ExpirationYear, 
                                        creditCard.ExpirationMonth, 
                                        1);

                        expirationDate = expirationDate.AddMonths(1);

                        if (expirationDate > DateTime.Today)
                        {
                            isCreditCardValid = true;
                        }
                    }

                    // Check whether the farm is ready for firm up.
                    if (mailingPlanId == 0)
                    {
                        FirmUpStatusHiddenField.Value = "MP_REQ";
                    }
                    else if (mailingPlanId == 100003)
                    {
                        // 8 x 8.
                        if (design.Status.Name != "Approved")
                        {
                            FirmUpStatusHiddenField.Value = "DESIGN_REQ";
                        }
                    }
                    else
                    {
                        if (design.Status.Name != "Approved" || 
                            brochure.Status.Name != "Approved")
                        {
                            FirmUpStatusHiddenField.Value = "DESIGN_REQ";
                        }
                    }

                    if (!isCreditCardValid)
                    {
                        FirmUpStatusHiddenField.Value = "CC_INVALID";
                    }

                    if (farm.Firmup)
                    {
                        FirmUpButton.Enabled = false;
                    }
                }
                // ******************************************* \\
            }
            catch (Exception ex)
            {
                log.Error("UNKNOWN ERROR:", ex);
                ErrorLiteral.Text = "Unknown Error Please contact Administrator:";
            }
        }        
    }

    private void FillPlotGrid(FarmService.PlotInfo[] plots, int pageNumber)
    {
        PlotListGridView.DataSource = plots;
        PlotListGridView.PageIndex = pageNumber;
        PlotListGridView.DataBind();

        if (PlotListGridView.Rows.Count > 0)
        {
            PlotListGridView.Rows[0].Cells[1].FindControl("PrimaryPlotImage").Visible = true;

            for (int i = 0; i < PlotListGridView.Rows.Count; i++)
            {
                PlotListGridView.Rows[i].Cells[0].FindControl("EditHyperLink").Visible = false;
            }
        }
    }

    protected void EditFarmButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/ModifyFarm.aspx?Page=ViewFarm.aspx&farmId=" + FarmIdHiddenField.Value.ToString());
    }

    protected void DeleteFarmButton_Click(object sender, EventArgs e)
    {
        bool isError = false;
        try
        {
            // Get the common web service instance.

            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            int farmId = 0;
            int.TryParse(FarmIdHiddenField.Value.ToString(), out farmId);
            farmService.DeleteFarmPlot(farmId,LoginUserId);
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE DELETING FARM:", exception);
            isError = true;
            if (exception.Message.Contains("Farm is Firmed Up. Cannot Delete this Farm"))
                ErrorLiteral.Text = "Error: " + FarmNameLabel.Text + " farm is currently Firmed Up. It is not possible to delete any Firmed Up mailing plan or Farm. If you still want to delete it, please speak to Customer Service 1-800-Mailing";
            else
                ErrorLiteral.Text = "Unknown Error Deleting Farm. Please Contact Administrator";
        }
        if (!isError)
            Response.Redirect("~/Members/FarmManagement.aspx");
    }

    protected void FirmUpButton_Click(object sender, EventArgs e)
    {
        string queryString = "?farmId=" + FarmIdHiddenField.Value;

        Response.Redirect("~/Members/FirmUp.aspx" + queryString);
    }
    
    protected void CreatePlotButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/CreatePlot.aspx?farmId=" + FarmIdHiddenField.Value.ToString());
    }

    protected void PlotListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        FarmService.FarmService farmService = serviceLoader.GetFarm();

        int farmId = Convert.ToInt32(FarmIdHiddenField.Value);
        FarmService.FarmInfo farm = farmService.GetFarmDetail(farmId);

        FillPlotGrid(farm.Plots, e.NewPageIndex);
    }

    #endregion

    #endregion
}

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

public partial class ViewContact : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(ViewContact));
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
                DeleteContactButton.Enabled = false;
                EditContactButton.Enabled = false;
            }

            Int64 contactId = 0;
            if ((Request.QueryString["contactId"] != "") && (Request.QueryString["contactId"] != null))
                Int64.TryParse(Request.QueryString["contactId"],out contactId);

            if (contactId == 0)
                Response.Redirect("~/Members/FarmManagement.aspx");

            if ((Request.QueryString["parentPage"] != "") && (Request.QueryString["parentPage"] != null))
                ParentPageHiddenField.Value = Request.QueryString["parentPage"];
            else
                ParentPageHiddenField.Value = "";

            try
            {
                //Get the common web service instance.
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();

                //Getting Required Data
                FarmService.ContactInfo contact = farmService.GetContactDetails(contactId);
                FarmService.PlotInfo plot = farmService.GetPlotDetail(contact.PlotId);
                FarmService.FarmInfo farm = farmService.GetFarmDetail(plot.FarmId);
                int contactCount = farmService.GetContactCountForPlot(contact.PlotId);

                int userId = farmService.GetUserIdForFarm(plot.FarmId);
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

                //Header Details
                FarmNameLabel.Text = farm.FarmName;
                PlotNameLabel.Text = plot.PlotName;
                ContactCountLabel.Text = contactCount.ToString();
                ContactCountHiddenField.Value = contactCount.ToString();

                if (farmService.IsDefaultPlot(plot.PlotId))
                    DefaultPlotFlagHiddenField.Value = "true";
                else
                    DefaultPlotFlagHiddenField.Value = "false";
                
                CreatedOnLabel.Text = contact.CreateDate.ToShortDateString();
                ModifiedOnLable.Text = contact.LastModifyDate.ToShortDateString();

                //Hidden Fields
                FarmIdHiddenField.Value = farm.FarmId.ToString();
                PlotIdHiddenField.Value = plot.PlotId.ToString();
                ContactIdHiddenField.Value = contact.ContactId.ToString();

                //Contact Details
                ContactIdLabel.Text = contact.ContactId.ToString();
                ScheduleNumberLabel.Text = contact.ScheduleNumber.ToString();
                OwnerFullNameLabel.Text = contact.OwnerFullName;
                LotNumberLabel.Text = contact.Lot.ToString();
                BlockLabel.Text = contact.Block;
                SubdivisionLabel.Text = contact.Subdivision;
                FilingLabel.Text = contact.Filing;
                SiteAddressLabel.Text = contact.SiteAddress;
                BedroomsLabel.Text = contact.Bedrooms.ToString();
                FullBathLabel.Text = contact.FullBath.ToString();
                ThreeQuarterBathLabel.Text = contact.ThreeQuarterBath.ToString();
                HalfBathLabel.Text = contact.HalfBath.ToString();
                AcresLabel.Text = contact.Acres.ToString();
                ActMktComboLabel.Text = contact.ActMktComb;
                OwnerFirstNameLabel.Text = contact.OwnerFirstName;
                OwnerLastNameLabel.Text = contact.OwnerLastName;
                OwnerAddress1Label.Text = contact.OwnerAddress1;
                OwnerArrdess2Label.Text = contact.OwnerAddress2;
                OwnerCityLabel.Text = contact.OwnerCity;
                OwnerStateLabel.Text = contact.OwnerState;
                OwnerZipLabel.Text = contact.OwnerZip;
                OwnerCountryLabel.Text = contact.OwnerCountry;
                SaleDateLabel.Text = contact.SaleDate.ToShortDateString();
                TransAmountLabel.Text = contact.TransAmount.ToString();
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR:", exception);
                ErrorLiteral.Text = "UNKNOWN ERROR: Contact Administrator";
            }
        }

    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        if (ParentPageHiddenField.Value.ToString() == "")
            Response.Redirect("~/Members/ViewPlot.aspx?plotId=" + PlotIdHiddenField.Value.ToString() + "&accessType=old");
        else
            if (ParentPageHiddenField.Value.ToString().Equals("SearchFarmData.aspx"))
                Response.Redirect("~/Members/" + ParentPageHiddenField.Value.ToString() + "?accessType=old");
    }

    protected void DeleteContactButton_Click(object sender, EventArgs e)
    {
        bool isError = false;
        try
        {
            //Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();

            farmService.DeleteContact(Convert.ToInt64(ContactIdHiddenField.Value.ToString()), LoginUserId);
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE DELETE CONTACT:", exception);
            isError = true;
            if (exception.Message.Contains("This action will cause Farm to be deleted and the Parent-Farm is Active. Hence Contact Cannot be deleted"))
                ErrorLiteral.Text = "Error: This action will cause Farm to be deleted and the Parent-Farm is Active. Hence Contact Cannot be deleted.";
            else
                ErrorLiteral.Text = "UNKNOWN ERROR WHILE DELETE CONTACT: Contact Administrator";
        }
        if (!isError)
        {
            int contactCount = int.Parse(ContactCountHiddenField.Value.ToString());

            if (ParentPageHiddenField.Value.ToString() == "")
            {
                if (contactCount < 2)
                {
                    if (DefaultPlotFlagHiddenField.Value.ToString().Equals("true"))
                        Response.Redirect("~/Members/FarmManagement.aspx");
                    else
                        Response.Redirect("~/Members/ViewFarm.aspx?farmId=" + FarmIdHiddenField.Value.ToString());
                }
                else
                    Response.Redirect("~/Members/ViewPlot.aspx?plotId=" + PlotIdHiddenField.Value.ToString());
            }
            else
                if (ParentPageHiddenField.Value.ToString().Equals("SearchFarmData.aspx"))
                    Response.Redirect("~/Members/" + ParentPageHiddenField.Value.ToString() + "?accessType=old");

        }
    }

    protected void EditContactButton_Click(object sender, EventArgs e)
    {
        if (ParentPageHiddenField.Value.ToString() == "")
            Response.Redirect("~/Members/ModifyContact.aspx?contactId=" + ContactIdHiddenField.Value.ToString());
        else
            Response.Redirect("~/Members/ModifyContact.aspx?contactId=" + ContactIdHiddenField.Value.ToString() + "&parentPage=" + ParentPageHiddenField.Value.ToString());
    }

    #endregion

    #endregion

    
}

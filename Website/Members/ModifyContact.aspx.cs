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

public partial class ModifyContact : System.Web.UI.Page
{
    #region Field Declarations

        #region Form specific variable declaration
        protected static readonly ILog log = LogManager.GetLogger(typeof(ModifyContact));
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

    #region Event Handlers

        #region Page Event Handler
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    Int64 contactId = 0;
                    if ((Request.QueryString["contactId"] != "") && (Request.QueryString["contactId"] != null))
                        Int64.TryParse(Request.QueryString["contactId"], out contactId);

                    if (contactId == 0)
                        Response.Redirect("~/Members/FarmManagement.aspx");

                    if ((Request.QueryString["parentPage"] != "") && (Request.QueryString["parentPage"] != null))
                        ParentPageHiddenField.Value = Request.QueryString["parentPage"];
                    else
                        ParentPageHiddenField.Value = "";

                    try
                    {
                        // Get the common web service instance.

                        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                        FarmService.FarmService farmService = serviceLoader.GetFarm();

                        FarmService.ContactInfo contact = farmService.GetContactDetails(contactId);

                        int userId = farmService.GetUserIdForPlot(contact.PlotId);
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
                        ContactIdLabel.Text = contact.ContactId.ToString();
                        ScheduleNumberTextBox.Text = contact.ScheduleNumber.ToString();
                        OwnerFullNameTextBox.Text = contact.OwnerFullName;
                        LotTextBox.Text = contact.Lot.ToString();
                        BlockTextBox.Text = contact.Block;
                        SubDivisionTextBox.Text = contact.Subdivision;
                        FilingTextBox.Text = contact.Filing;
                        SiteAddressTextBox.Text = contact.SiteAddress;
                        BedroomsTextBox.Text = contact.Bedrooms.ToString();
                        FullBathTextBox.Text = contact.FullBath.ToString();
                        ThreeQuarterBathTextBox.Text = contact.ThreeQuarterBath.ToString();
                        HalfBathTextBox.Text = contact.HalfBath.ToString();
                        AcresTextBox.Text = contact.Acres.ToString();
                        ActMktCombTextBox.Text = contact.ActMktComb;
                        OwnerFirstNameTextBox.Text = contact.OwnerFirstName;
                        OwnerLastNameTextBox.Text = contact.OwnerLastName;
                        OwnerAddress1TextBox.Text = contact.OwnerAddress1;
                        OwnerAddress2TextBox.Text = contact.OwnerAddress2;
                        OwnerCityTextBox.Text = contact.OwnerCity;
                        OwnerStateTextBox.Text = contact.OwnerState;
                        OwnerZipTextBox.Text = contact.OwnerZip;
                        OwnerCountryTextBox.Text = contact.OwnerCountry;
                        SaleDateTextBox.Text = contact.SaleDate.ToShortDateString();
                        TransAmountTextBox.Text = contact.TransAmount.ToString();
                        PlotIdHiddenField.Value = contact.PlotId.ToString();

                        FarmService.PlotInfo plot = farmService.GetPlotDetail(Convert.ToInt32(PlotIdHiddenField.Value));
                        PlotNameLabel.Text = plot.PlotName;
                        ContactCountLabel.Text = plot.ContactCount.ToString();
                        CreateDateLabel.Text = plot.CreateDate.ToShortDateString();

                    }
                    catch (Exception exception)
                    {
                        log.Error("UNKNOWN ERROR:", exception);
                    }
                }
            }
            protected void SaveButton_Click(object sender, EventArgs e)
            {
                bool isError = false;
                try
                {
                    // Get the common web service instance.

                    ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                    FarmService.FarmService farmService = serviceLoader.GetFarm();
                    FarmService.ContactInfo contact = new Irmac.MailingCycle.BLLServiceLoader.Farm.ContactInfo();

                    contact.ContactId = Int64.Parse(ContactIdLabel.Text);
                    
                    if (!ScheduleNumberTextBox.Text.Trim().Equals(""))
                        contact.ScheduleNumber = int.Parse(ScheduleNumberTextBox.Text);
                    else
                        contact.ScheduleNumber = 0;
                    
                    contact.OwnerFullName = OwnerFullNameTextBox.Text;
                    
                    if (!LotTextBox.Text.Trim().Equals(""))
                        contact.Lot = int.Parse(LotTextBox.Text);
                    else
                        contact.Lot = 0;
                    
                    contact.Block = BlockTextBox.Text;
                    contact.Subdivision = SubDivisionTextBox.Text;
                    contact.Filing = FilingTextBox.Text;
                    contact.SiteAddress = SiteAddressTextBox.Text;
                    
                    if (!BedroomsTextBox.Text.Trim().Equals(""))
                        contact.Bedrooms = int.Parse(BedroomsTextBox.Text);
                    else
                        contact.Bedrooms = 0;
                    
                    if (!FullBathTextBox.Text.Trim().Equals(""))
                        contact.FullBath = int.Parse(FullBathTextBox.Text);
                    else
                        contact.FullBath = 0;
                    
                    if (!ThreeQuarterBathTextBox.Text.Trim().Equals(""))
                        contact.ThreeQuarterBath = int.Parse(ThreeQuarterBathTextBox.Text);
                    else
                        contact.ThreeQuarterBath = 0;
                    
                    if (!HalfBathTextBox.Text.Trim().Equals(""))
                        contact.HalfBath = int.Parse(HalfBathTextBox.Text);
                    else
                        contact.HalfBath = 0;

                    if (!AcresTextBox.Text.Trim().Equals(""))
                        contact.Acres = float.Parse(AcresTextBox.Text);
                    else
                        contact.Acres = 0;

                    contact.ActMktComb = ActMktCombTextBox.Text;
                    contact.OwnerFirstName = OwnerFirstNameTextBox.Text;
                    contact.OwnerLastName = OwnerLastNameTextBox.Text;
                    contact.OwnerAddress1 = OwnerAddress1TextBox.Text;
                    contact.OwnerAddress2 = OwnerAddress2TextBox.Text;
                    contact.OwnerCity = OwnerCityTextBox.Text;
                    contact.OwnerState = OwnerStateTextBox.Text;
                    contact.OwnerZip = OwnerZipTextBox.Text;
                    contact.OwnerCountry = OwnerCountryTextBox.Text;
                    contact.SaleDate = DateTime.Parse(SaleDateTextBox.Text);
                    
                    if (!TransAmountTextBox.Text.Trim().Equals(""))
                        contact.TransAmount = decimal.Parse(TransAmountTextBox.Text);
                    else
                        contact.TransAmount = 0;
                    
                    contact.LastModifyBy = LoginUserId;
                    contact.PlotId = int.Parse(PlotIdHiddenField.Value.ToString());
                    farmService.UpdateContactDetails(contact);
                }
                catch (Exception exception)
                {
                    log.Error("UNKNOWN ERROR:", exception);
                    isError = true;
                }
                if (!isError)
                    if (ParentPageHiddenField.Value.ToString() == "")
                        Response.Redirect("~/Members/ViewPlot.aspx?plotId=" + PlotIdHiddenField.Value.ToString());
                    else
                        if (ParentPageHiddenField.Value.ToString().Equals("SearchFarmData.aspx"))
                            Response.Redirect("~/Members/" + ParentPageHiddenField.Value.ToString() + "?accessType=old");
                        else
                            Response.Redirect("~/Members/" + ParentPageHiddenField.Value.ToString());
            }

            protected void CancelButton_Click(object sender, EventArgs e)
            {
                if (ParentPageHiddenField.Value.ToString() == "")
                    Response.Redirect("~/Members/ViewPlot.aspx?plotId=" + PlotIdHiddenField.Value.ToString());
                else
                    if (ParentPageHiddenField.Value.ToString().Equals("SearchFarmData.aspx"))
                        Response.Redirect("~/Members/" + ParentPageHiddenField.Value.ToString() + "?accessType=old");
                    else
                        Response.Redirect("~/Members/" + ParentPageHiddenField.Value.ToString());
            }
        #endregion

    #endregion
    

}

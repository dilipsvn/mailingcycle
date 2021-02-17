using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;

public partial class Members_FirmUp : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_FirmUp));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        // Get the query string values.
        NameValueCollection coll = Request.QueryString;

        int farmId = Convert.ToInt32(coll.Get("farmId"));
        if (coll.Get("start_date") != "" && coll.Get("start_date") != null)
        {
            StartDateTextBox.Text = coll.Get("start_date");
            StartDateHiddenField.Value = coll.Get("start_date");
        }

        if (!IsPostBack)
        {
            // Get the logged in account information.
            RegistrationService.LoginInfo loginInfo =
                (RegistrationService.LoginInfo)Session["loginInfo"];

            // Set the required query string varables into hidden fields.
            FarmIdHiddenField.Value = farmId.ToString();

            try
            {
                // Get the farm details and display.
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                FarmService.FarmInfo farm = farmService.GetFarmDetail(farmId);

                FarmNameLabel.Text = farm.FarmName;
                PlotCountLabel.Text = farm.PlotCount.ToString();
                ContactCountLabel.Text = farm.ContactCount.ToString();
                MailingPlanLabel.Text = farm.MailingPlan.Title;
                CreatedOnLabel.Text = farm.CreateDate.ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                ErrorMessageLabel.Visible = true;

                log.Error("Unknown Error", ex);
            }
        }
    }

    protected void IAcceptButton_Click(object sender, EventArgs e)
    {
        string queryString = "?farmId=" + FarmIdHiddenField.Value +
            "&start_date=" + StartDateHiddenField.Value;

        Response.Redirect("~/Members/FirmUpCalendar.aspx" + queryString);
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        string queryString = "?farmId=" + FarmIdHiddenField.Value;

        Response.Redirect("~/Members/ViewFarm.aspx" + queryString);
    }
}

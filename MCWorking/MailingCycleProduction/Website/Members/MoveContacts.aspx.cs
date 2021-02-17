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

public partial class MoveContacts : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(MoveContacts));
    #endregion

    #endregion

    #region Event Handlers

    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int farmId = 0;
            int plotId = 0;
            string contactIdsFromGET = "";

            if ((Request.QueryString["farmId"] != "") && (Request.QueryString["farmId"] != null))
                int.TryParse(Request.QueryString["farmId"], out farmId);

            if ((Request.QueryString["plotId"] != "") && (Request.QueryString["plotId"] != null))
                int.TryParse(Request.QueryString["plotId"], out plotId);

            contactIdsFromGET = Request.QueryString["contactIds"];

            FarmIdHiddenField.Value = farmId.ToString();
            PlotIdHiddenField.Value = plotId.ToString();
            ContactIdsHiddenField.Value = contactIdsFromGET;

            try
            {
                // Get the common web service instance.
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();

                //Getting Farm Name
                FarmService.FarmInfo farm = farmService.GetFarmDetail(farmId);
                FarmNameLabel.Text = farm.FarmName;

                //Getting From Plot Name
                FarmService.PlotInfo plot = farmService.GetPlotDetail(plotId);
                PlotNameLabel.Text = plot.PlotName;

                //Get Plot List for the Farm
                IList<FarmService.PlotInfo> plots = farmService.GetPlotListSummaryForFarm(farmId);
                PlotListDropDownList.DataSource = plots;
                PlotListDropDownList.DataValueField = "PlotId";
                PlotListDropDownList.DataTextField = "PlotName";
                PlotListDropDownList.DataBind();
                PlotListDropDownList.Items.Insert(0, new ListItem("<Select a Plot>", "-1"));
                PlotListDropDownList.Items.Remove(PlotListDropDownList.Items.FindByValue(plotId.ToString()));
                PlotListDropDownList.Items.Add(new ListItem("New Plot ...", "-2"));
                PlotListDropDownList.Attributes.Add("onChange", "javascript: newPlot(this);");
                NewPlotHiddenField.Value = "";
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR WHILE LOADING MOVECONTACT:", exception);
                ErrorLiteral.Text = "Unable to Load the Farm";
                SaveButton.Visible = false;
            }
        }
        else
        {
            if ((NewPlotHiddenField.Value.ToString() != "") && (PlotListDropDownList.SelectedValue.ToString() == "-2"))
            {
                PlotListDropDownList.Items.FindByValue("-2").Text = NewPlotHiddenField.Value.ToString();
            }
            else
            {
                PlotListDropDownList.Items.FindByValue("-2").Text = "New Plot ...";
                NewPlotHiddenField.Value = "";
            }
        }
    }

    #endregion

    #endregion
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            FarmService.FarmService farmService = serviceLoader.GetFarm();
            string contactIds = ContactIdsHiddenField.Value.ToString();

            string[] arrContactId = contactIds.Split(new char[] { ';' });

            RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            int userId = loginInfo.UserId;

            if (PlotListDropDownList.SelectedValue.ToString() == "-2")
            {
                //Check the New Plot Name for Duplicate
                if (farmService.IsPlotNameDuplicateWhileAddingNewPlot(Convert.ToInt32(FarmIdHiddenField.Value.ToString()), NewPlotHiddenField.Value.ToString()))
                {
                    ErrorLiteral.Text = "Duplicate Plot Name provided. Please provide a different Plot Name";
                    PlotListDropDownList.Items.FindByValue("-2").Text = "New Plot ...";
                    PlotListDropDownList.SelectedIndex = 0;
                    NewPlotHiddenField.Value = "";
                    return;
                }

                //Default Plot Check
                if (farmService.IsDefaultPlot(Convert.ToInt32(PlotIdHiddenField.Value.ToString())))
                    if (arrContactId.Length >= farmService.GetContactCountForPlot(Convert.ToInt32(PlotIdHiddenField.Value.ToString())))
                    {
                        ErrorLiteral.Text = "Error: Default Plot Cannot be empty.";
                        PlotListDropDownList.Items.FindByValue("-2").Text = "New Plot ...";
                        NewPlotHiddenField.Value = "";
                        return;
                    }

                //Building Model Object
                FarmService.PlotInfo plot = new FarmService.PlotInfo();
                plot.PlotId = 0;
                plot.PlotName = NewPlotHiddenField.Value.ToString();
                plot.FarmId = Convert.ToInt32(FarmIdHiddenField.Value.ToString());
                plot.LastModifyBy = userId;
                int plotId = farmService.CreatePlotForMoveContacts(plot);
                for (int i = 0; i < arrContactId.Length; i++)
                {
                    farmService.MoveContactToPlot(Convert.ToInt64(arrContactId[i]), plotId, "", userId);
                }
            }
            else
            {
                int plotId = int.Parse(PlotListDropDownList.SelectedValue.ToString());
                for (int i = 0; i < arrContactId.Length; i++)
                {
                    farmService.MoveContactToPlot(Convert.ToInt64(arrContactId[i]), plotId, "", userId);
                }
            }

            ErrorLiteral.Text = "Contacts have been moved successfully.";
            SaveButton.Visible = false;
            CancelButton.OnClientClick = "javascript: opener.location.href('ViewFarm.aspx?farmId=" + FarmIdHiddenField.Value.ToString() + "'); window.close();";
            CancelButton.Text = "Close";
        }
        catch (Exception exception)
        {
            log.Error("UNKNOWN ERROR WHILE MOVING A CONTACT:", exception);
            if (exception.Message.Contains("Cannot Empty Default Plot"))
                ErrorLiteral.Text = "Cannot Empty Default Plot";
            else if (exception.Message.Contains("Plot Name already Exist. Please Provide a different Plot Name"))
            {
                ErrorLiteral.Text = "Plot Name already Exist. Please Provide a different Plot Name";
            }
            else
                ErrorLiteral.Text = "Unable to Move a Contact";
        }
    }
}

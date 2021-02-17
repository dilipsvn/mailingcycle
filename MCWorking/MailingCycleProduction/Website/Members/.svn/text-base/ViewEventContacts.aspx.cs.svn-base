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
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.Model;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using ScheduleService = Irmac.MailingCycle.BLLServiceLoader.Schedule;

public partial class Members_ViewEventContacts : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_ViewEventContacts));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();
    private string plotName = string.Empty;

    protected enum EventType
    {
        Future = 0,
        Past
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMessageLabel.Visible = false;

        // Get the query string values.
        NameValueCollection coll = Request.QueryString;

        int id = Convert.ToInt32(coll.Get("id"));
        int scheduleId = Convert.ToInt32(coll.Get("sId"));
        EventType eventType = EventType.Future;
        if (coll.Get("et") != "" && coll.Get("et") != null)
        {
            eventType = (EventType)Convert.ToInt32(coll.Get("et"));
        }
        int agentId = Convert.ToInt32(coll.Get("aId"));
        string agentName = coll.Get("aName");
        int planType = Convert.ToInt32(coll.Get("ptype"));
        int pageNumber = Convert.ToInt32(coll.Get("pg"));
        
        // Display the agent name if one exists.
        if (agentName != "")
        {
            AgentNameLabel.Text = "Agent Name: " + agentName + "&nbsp;";
        }

        if (!IsPostBack)
        {
            // Set the required query string varables into hidden fields.
            IdHiddenField.Value = id.ToString();
            ScheduleIdHiddenField.Value = scheduleId.ToString();
            EventTypeHiddenField.Value = Convert.ToInt32(eventType).ToString();
            AgentIdHiddenField.Value = agentId.ToString();
            AgentNameHiddenField.Value = agentName;
            PlanTypeHiddenField.Value = planType.ToString();
            PageNumberHiddenField.Value = pageNumber.ToString();
            
            // Get the schedule event contacts and display.
            try
            {
                ScheduleService.ScheduleService scheduleService =
                    serviceLoader.GetSchedule();
                IList<ScheduleService.ScheduleEventContactInfo> contacts =
                    scheduleService.GetScheduleEventContacts(id);

                EventNumberLabel.Text = contacts[0].EventNumber.ToString();
                EventDateLabel.Text = contacts[0].EventDate;
                FarmLabel.Text = contacts[0].FarmName;
                MailingPlanLabel.Text = contacts[0].PlanName;
                StartDateLabel.Text = contacts[0].StartDate;
                EndDateLabel.Text = contacts[0].EndDate;

                ContactsGrid.DataSource = contacts;
                ContactsGrid.DataBind();

                Session["SCHEDULE_EVENT_CONTACTS"] = contacts;
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                ErrorMessageLabel.Visible = true;

                log.Error("Unknown Error", ex);
            }
        }
    }

    protected void Contact_Bound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.Item.Cells[0].Text == plotName)
            {
                e.Item.Cells[0].Text = "";
            }
            else
            {
                plotName = e.Item.Cells[0].Text;
            }
        }
    }

    protected void Contacts_Changed(object sender, DataGridPageChangedEventArgs e)
    {
        ContactsGrid.CurrentPageIndex = e.NewPageIndex;

        ContactsGrid.DataSource = (IList<ScheduleService.ScheduleEventContactInfo>)Session["SCHEDULE_EVENT_CONTACTS"];
        ContactsGrid.DataBind();
    }

    protected void ExportButton_Click(object sender, EventArgs e)
    {
        try
        {
            // Get the event identifier.
            int eventId = Convert.ToInt32(IdHiddenField.Value);

            // Get the list of contacts of the event.
            ScheduleService.ScheduleService scheduleService =
                        serviceLoader.GetSchedule();
            IList<ScheduleService.ScheduleEventContactInfo> contacts =
                scheduleService.GetScheduleEventContacts(eventId);

            // Specify the source and desitination files.
            string path = Server.MapPath("~/Members/UserData/");
            string sourceFileName = path + "Templates\\EventContactListTemplate.xls";
            string destFileName = path + Util.GetFileName(contacts[0].FarmName) + "_Contacts.xls";

            // Create the target file by coping the template file.
            File.Copy(sourceFileName, destFileName, true);

            // Open a connection with the property settings specified.
            string connectionString = "Data Source=" + destFileName + ";" +
                    "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Extended Properties=Excel 8.0;";
            
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Get schema information from the data source.
                DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                string sheet = schemaTable.Rows[0]["Table_Name"].ToString();

                // Fill the [Event Details] sheet.
                string queryString = "INSERT INTO [" + sheet + "] ([Event Number], " +
                    "[Event Date], [Farm], " +
                    "[Mailing Plan], [Start Date], " +
                    "[End Date]) " +
                    "VALUES ('" + contacts[0].EventNumber.ToString() + "', " +
                    "'" + contacts[0].EventDate + "', '" + contacts[0].FarmName.Replace("'", "''") + "', " +
                    "'" + contacts[0].PlanName + "', '" + contacts[0].StartDate + "', " +
                    "'" + contacts[0].EndDate + "')";

                OleDbCommand command = new OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();

                // Fill the contacts in the respective [Plot #] sheets.
                int plotId = 0;
                int plotCounter = 0;

                foreach (ScheduleService.ScheduleEventContactInfo entry in contacts)
                {
                    if (entry.PlotId != plotId)
                    {
                        plotCounter++;

                        plotId = entry.PlotId;
                        sheet = Util.GetExcelSheetName(plotCounter.ToString() + "_" + entry.PlotName);

                        queryString = "CREATE TABLE [" + sheet + "] " +
                            "([Contact ID] TEXT(255), [First Name] TEXT(255), " +
                            "[Last Name] TEXT(255), [Address 1] TEXT(255), " +
                            "[Address 2] TEXT(255), [City] TEXT(255), " +
                            "[State] TEXT(255), [Zip] TEXT(255), " +
                            "[Country] TEXT(255))";

                        command = new OleDbCommand(queryString, connection);
                        command.ExecuteNonQuery();
                    }

                    // Create an SQL statement to execute against the data source.
                    queryString = "INSERT INTO [" + sheet + "$] ([Contact ID], " +
                        "[First Name], [Last Name], " +
                        "[Address 1], [Address 2], " +
                        "[City], [State], " +
                        "[Zip], [Country]) " +
                        "VALUES ('" + entry.ContactId.ToString() + "', " +
                        "'" + entry.FirstName + "', '" + entry.LastName + "', " +
                        "'" + entry.Address1 + "', '" + entry.Address2 + "', " +
                        "'" + entry.City + "', '" + entry.State + "', " +
                        "'" + entry.Zip + "', '" + entry.Country + "')";

                    command = new OleDbCommand(queryString, connection);
                    command.ExecuteNonQuery();
                }
            }

            // Open the target file.
            string fileLocation = destFileName.Substring(
                destFileName.IndexOf("Members\\UserData\\")).Replace("\\", "/");

            if (!ClientScript.IsStartupScriptRegistered(this.GetType(), "Startup"))
            {
                String script = "<script language=\"javascript\">";
                script += "window.open('../" + fileLocation + "');";
                script += "</script>";

                ClientScript.RegisterStartupScript(this.GetType(), "Startup", script);
            }
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        string queryString = "?id=" + IdHiddenField.Value +
            "&sId=" + ScheduleIdHiddenField.Value +
            "&aId=" + AgentIdHiddenField.Value +
            "&aName=" + AgentNameHiddenField.Value +
            "&et=" + EventTypeHiddenField.Value +
            "&ptype=" + PlanTypeHiddenField.Value +
            "&pg=" + PageNumberHiddenField.Value;

        Response.Redirect("~/Members/ViewEvent.aspx" + queryString);
    }
}

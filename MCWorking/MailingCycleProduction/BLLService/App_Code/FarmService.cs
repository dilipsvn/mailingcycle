using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;
using System.IO;
using System.Resources;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;

/// <summary>
/// Summary description for FarmService
/// </summary>
[WebService(Namespace = "http://mc.mkbedev.com/BLLService/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class FarmService : System.Web.Services.WebService
{

    public FarmService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /// <summary>
    /// Gets User Name for the Given User Id
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns>User Name of the Application User</returns>
    [WebMethod]
    public string GetUserName(int userId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        return bll.GetUserName(userId);
    }

    /// <summary>
    /// Get the List of Farms for the user
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns>List of FarmInfo Model Object as Farm List</returns>
    [WebMethod]
    public List<FarmInfo> GetFarmListForUser(int userId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();

        return bll.GetFarmListForUser(userId);
    }


    /// <summary>
    /// Gets the Farm Summary Lists
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Returns FarmInfo as farm Summary List</returns>
    [WebMethod]
    public List<FarmInfo> GetFarmSummary(int userId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        List<FarmInfo> farms = bll.GetFarmSummary(userId);
        return farms;
    }

    /// <summary>
    /// Get the Dleted (Archived) farm details of the specified registration account.
    /// </summary>
    /// <param name="userId">Internal identifier of the user.</param>
    /// <returns>Farm Details of the specified registration account.</returns>
    [WebMethod]
    public List<FarmInfo> GetArchivedFarmSummary(int userId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        List<FarmInfo> farms = bll.GetArchivedFarmSummary(userId);
        return farms;
    }

    /// <summary>
    /// Get the Dleted (Archived) farm details of the specified Farm.
    /// </summary>
    /// <param name="userId">Farm ID</param>
    /// <returns>FarmInfo Model object as details of the specified Farm.</returns>
    [WebMethod]
    public FarmInfo GetArchivedFarmSummaryDetails(int farmId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();

        return bll.GetArchivedFarmSummaryDetails(farmId);
    }

    /// <summary>
    /// Gets the List of Plots for a Farm
    /// </summary>
    /// <param name="farmId">Farm Id</param>
    /// <returns>List of PlotInfo Model object as a Plot List</returns>
    [WebMethod]
    public List<PlotInfo> GetPlotListForFarm(int farmId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        return bll.GetPlotListForFarm(farmId);
    }

    /// <summary>
    /// Get the Dleted (Archived) Plot details of the specified Farm with deleted contact Count.
    /// </summary>
    /// <param name="farmId">Farm Id</param>
    /// <returns>PlotInfo Model Object as Archived Plot Summary List Details</returns>
    [WebMethod]
    public List<PlotInfo> GetArchivedPlotSummary(int farmId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        List<PlotInfo> plots = bll.GetArchivedPlotSummary(farmId);
        return plots;
    }

    /// <summary>
    /// Get the Dleted (Archived) Plot details of the specified Plot with Contact count.
    /// </summary>
    /// <param name="plotId">Plot Id</param>
    /// <returns>PlotInfo Model Object as Archived Plot Summary Details</returns>
    [WebMethod]
    public PlotInfo GetArchivedPlotSummaryDetails(int plotId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        return bll.GetArchivedPlotSummaryDetails(plotId);
    }

    /// <summary>
    /// Gets the List of Mailing Plans
    /// </summary>
    /// <returns>Returns MailingPlanInfo as Mailing Plan List</returns>
    [WebMethod]
    public List<MailingPlanInfo> GetMailingPlanList()
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        List<MailingPlanInfo> mailingPlans = bll.GetMailingPlanList();

        return mailingPlans;
    }

    [WebMethod]
    public List<ContactInfo> GetFarmListFromFile(string fileName, ContactFileType fileType,
        byte[] bytes, int userId)
    {
        List<ContactInfo>  contacts = new List<ContactInfo>();
        String folderPath = System.Configuration.ConfigurationManager.AppSettings["ContactFileLocation"];
        String path = folderPath;
        FileStream fileStream;
        String filePath = "";
        string[] dateFormatSupport = { "MM/dd/yyyy", "MM/dd/yy", "ddMMMyyyy", "dMMMyyyy" };
      
        // Make sure the base directory ends with a "\".
        if (!path.EndsWith("\\"))
        {
            path += "\\";
        }
        path += userId;

        try
        {
            //Check for User Id Directory. If not existing create one
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            filePath  += path + "\\" + userId + "-" + fileName;
            fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write);
            int length = bytes.Length;
            fileStream.Write(bytes, 0, length);
            fileStream.Flush();
            fileStream.Close();

            //Load Contact Data From File
            string connectionString = string.Empty;
            DataTable schemaTable = new DataTable();
            DataTable dataTable = new DataTable();

            if (fileType == ContactFileType.Excel)
            {
                OleDbConnection connection = new OleDbConnection();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                connectionString = "Data Source=" + filePath + ";" +
                    "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Extended Properties=Excel 8.0;";
                connection = new OleDbConnection(connectionString);
                connection.Open();
                // Populate the DataTable with schema information on the data source tables.
                schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                string tableName = schemaTable.Rows[0]["Table_Name"].ToString();

                // Clear the DataTable.
                schemaTable.Clear();

                adapter = new OleDbDataAdapter("SELECT * FROM [" + tableName + "]",
                    connection);
                adapter.Fill(dataTable);
                connection.Close();
            }
            else if (fileType == ContactFileType.Csv)
            {
                OdbcConnection connection = new OdbcConnection();
                OdbcDataAdapter adapter = new OdbcDataAdapter();

                path = path.Replace("\\", "//");

                connectionString = "Driver={Microsoft Text Driver (*.txt; *.csv)};" +
                    "Dbq=" + path + ";" +
                    "Extensions=asc,csv,tab,txt;" + 
                    "Persist Security Info=False";
                
                /*connectionString= "Driver={Microsoft Text Driver (*.txt;*.csv)};" + 
                    "Dbq=" + path.Trim() + ";" +
                    "Extensions=asc,csv,tab,txt;" + 
                    "Persist Security Info=False";
                */
                connection = new OdbcConnection(connectionString);
                connection.Open();

                adapter = new OdbcDataAdapter("SELECT * FROM [" + userId + "-" + fileName + "]",
                    connection);
                adapter.Fill(dataTable);

                connection.Close();
            }
            else
            {
                throw new InvalidFileException();
            }

            if (dataTable.Rows.Count == 0)
            {
                throw new NoDataException();
            }

            if (dataTable.Columns.Count != 23)
            {
                throw new InvalidFormatException();
            }
            int countOfContacts = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //Check for a blank row ans skip
                bool skip = true;
                for (int i = 0; i < dataRow.ItemArray.Length; i++)
                    if (dataRow[i].ToString().Trim() != string.Empty)
                        skip = false;
                if (skip)
                    continue;
                
                if (dataRow[12].ToString().Trim() == string.Empty ||
                    dataRow[13].ToString().Trim() == string.Empty ||
                    dataRow[14].ToString().Trim() == string.Empty ||
                    dataRow[15].ToString().Trim() == string.Empty ||
                    dataRow[17].ToString().Trim() == string.Empty ||
                    dataRow[18].ToString().Trim() == string.Empty ||
                    dataRow[19].ToString().Trim() == string.Empty ||
                    dataRow[20].ToString().Trim() == string.Empty
                    )
                {
                    throw new InvalidFieldDataException();
                }
                
                ContactInfo contact = new ContactInfo();
                string temp;
                int tem;

                if (dataRow[0].ToString().Trim() == string.Empty)
                    contact.ScheduleNumber = 0;
                else
                {
                    temp = dataRow[0].ToString().Trim();
                    int.TryParse(temp, out tem);
                    contact.ScheduleNumber = tem;
                }

                if (dataRow[1].ToString().Trim() == string.Empty)
                    contact.OwnerFullName = "";
                else
                    contact.OwnerFullName = dataRow[1].ToString().Trim();

                if (dataRow[2].ToString().Trim() == string.Empty)
                    contact.Lot = 0;
                else
                {
                    temp = dataRow[2].ToString().Trim();
                    int.TryParse(temp, out tem);
                    contact.Lot = tem;
                }

                if (dataRow[3].ToString().Trim() == string.Empty)
                    contact.Block = "";
                else
                    contact.Block = dataRow[3].ToString().Trim();

                if (dataRow[4].ToString().Trim() == string.Empty)
                    contact.Subdivision = "";
                else
                    contact.Subdivision = dataRow[4].ToString().Trim();

                if (dataRow[5].ToString().Trim() == string.Empty)
                    contact.Filing = "";
                else
                    contact.Filing = dataRow[5].ToString().Trim();

                if (dataRow[6].ToString().Trim() == string.Empty)
                    contact.SiteAddress = "";
                else
                    contact.SiteAddress = dataRow[6].ToString().Trim();

                if (dataRow[7].ToString().Trim() == string.Empty)
                    contact.Bedrooms = 0;
                else
                {
                    temp = dataRow[7].ToString().Trim();
                    int.TryParse(temp, out tem);
                    contact.Bedrooms = tem;
                }

                if (dataRow[8].ToString().Trim() == string.Empty)
                    contact.FullBath = 0;
                else
                {
                    temp = dataRow[8].ToString().Trim();
                    int.TryParse(temp, out tem);
                    contact.FullBath = tem;
                }

                if (dataRow[9].ToString().Trim() == string.Empty)
                    contact.ThreeQuarterBath = 0;
                else
                {
                    temp = dataRow[9].ToString().Trim();
                    int.TryParse(temp, out tem);
                    contact.ThreeQuarterBath = tem;
                }

                if (dataRow[10].ToString().Trim() == string.Empty)
                    contact.HalfBath = 0;
                else
                {
                    temp = dataRow[10].ToString().Trim();
                    int.TryParse(temp, out tem);
                    contact.HalfBath = tem;
                }

                if (dataRow[11].ToString().Trim() == string.Empty)
                    contact.Acres = 0;
                else
                {
                    float ftem;
                    temp = dataRow[11].ToString().Trim();
                    float.TryParse(temp, out ftem);
                    contact.Acres = ftem;
                }

                contact.ActMktComb = dataRow[12].ToString().Trim();
                contact.OwnerFirstName = dataRow[13].ToString().Trim();
                contact.OwnerLastName = dataRow[14].ToString().Trim();
                contact.OwnerAddress1 = dataRow[15].ToString().Trim();
                contact.OwnerAddress2 = dataRow[16].ToString().Trim();
                contact.OwnerCity = dataRow[17].ToString().Trim();
                contact.OwnerState = dataRow[18].ToString().Trim();
                contact.OwnerZip = dataRow[19].ToString().Trim();
                contact.OwnerCountry = dataRow[20].ToString().Trim();

                if (dataRow[21].ToString().Trim() == string.Empty)
                    contact.SaleDate = System.DateTime.Now;
                else
                    contact.SaleDate = Convert.ToDateTime(dataRow[21].ToString().Trim());
                    //contact.SaleDate = DateTime.ParseExact(dataRow[21].ToString().Trim(), dateFormatSupport, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);

                if (dataRow[22].ToString().Trim() == string.Empty)
                    contact.TransAmount = 0;
                else
                {
                    decimal dtem;
                    temp = dataRow[22].ToString().Trim();
                    decimal.TryParse(temp, out dtem);
                    contact.TransAmount = dtem;
                }

                contact.LastModifyBy = userId;

                contacts.Add(contact);
                countOfContacts++;
            }
            if (countOfContacts == 0)
                throw new Exception("No valid Contact records in the uploaded File.");
        }
        finally
        {
            // Delete the file.
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        return contacts;
    }

    /// <summary>
    /// Creating a New Farm with a default Plot
    /// </summary>
    /// <param name="farm">farmInfo as a input parameter</param>
    [WebMethod]
    public void CreateFarmPlot(FarmInfo farm)
    {
        Farm bll = new Farm();
        bll.CreateFarmPlot(farm);
    }

    /// <summary>
    /// Creating a New Plot
    /// </summary>
    /// <param name="plot">PlotInfo as a input parameter</param>
    [WebMethod]
    public void CreatePlot(PlotInfo plot)
    {
        Farm bll = new Farm();
        bll.CreatePlot(plot);
    }

    /// <summary>
    /// Create a new plot
    /// </summary>
    /// <param name="Plot">Accepts PlotInfo as input</param>
    [WebMethod]
    public int CreatePlotForMoveContacts(PlotInfo plot)
    {
        Farm bll = new Farm();
        return bll.CreatePlotForMoveContacts(plot);
    }

    /// <summary>
    /// Updating Plot
    /// </summary>
    /// <param name="plot">PlotInfo as a input parameter</param>
    [WebMethod]
    public void UpdatePlot(PlotInfo plot)
    {
        Farm bll = new Farm();
        bll.UpdatePlot(plot);
    }


    /// <summary>
    /// Updating a Farm with a default Plot
    /// </summary>
    /// <param name="farm">farmInfo as a input parameter</param>
    [WebMethod]
    public void UpdateFarmPlot(FarmInfo farm)
    {
        Farm bll = new Farm();
        bll.UpdateFarmPlot(farm);
    }


    /// <summary>
    /// Get Farm Details Foa Farm Id
    /// </summary>
    /// <param name="FarmId">Farm Id</param>
    /// <returns>FarmInfo Model object as Farm details</returns>
    [WebMethod]
    public FarmInfo GetFarmDetail(int FarmId)
    {
        Farm bll = new Farm();
        FarmInfo farm = bll.GetFarmDetail(FarmId);
        return farm;
    }

    /// <summary>
    /// Get the number plots attached to the Farm
    /// </summary>
    /// <param name="farmId">Farm ID</param>
    /// <returns>Count of plots</returns>
    [WebMethod]
    public int GetPlotCountForFarm(int farmId)
    {
        Farm bll = new Farm();
        return bll.GetPlotCountForFarm(farmId);
    }


    /// <summary>
    /// Get Plot List for a Farm
    /// </summary>
    /// <param name="FarmId">Farm Id</param>
    /// <returns>List  PlotInfo Model object as Plot List</returns>
    [WebMethod]
    public List<PlotInfo> GetPlotListSummaryForFarm(int FarmId)
    {
        Farm bll = new Farm();
        List<PlotInfo> plots = bll.GetPlotListSummaryForFarm(FarmId);
        return plots;
    }

    /// <summary>
    /// Get Plot Detail for a Given Plot Id
    /// </summary>
    /// <param name="PlotId">Plot ID</param>
    /// <returns>PlotInfo Model object as Plot Details</returns>
    [WebMethod]
    public PlotInfo GetPlotDetail(int plotId)
    {
        Farm bll = new Farm();
        PlotInfo plot = bll.GetPlotDetail(plotId);
        return plot;
    }

    [WebMethod]
    public bool IsFarmExists(string farmName)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        bool isFarmExists = bll.IsFarmExists(farmName);

        return isFarmExists;
    }

    /// <summary>
    /// Get the number Contacts attached to the Plot
    /// </summary>
    /// <param name="farmId">Plot ID</param>
    /// <returns>Count of Contacts</returns>
    [WebMethod]
    public int GetContactCountForPlot(int plotId)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        return bll.GetContactCountForPlot(plotId);
    }

    [WebMethod]
    public bool IsPlotExists(string plotName)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        bool isPlotExists = bll.IsPlotExists(plotName);

        return isPlotExists;
    }

    /// <summary>
    /// Gets userId for the Farm
    /// </summary>
    /// <param name="farmId">Farm Id</param>
    /// <returns>User ID</returns>
    [WebMethod]
    public int GetUserIdForFarm(int farmId)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        return bll.GetUserIdForFarm(farmId);
    }

    /// <summary>
    /// Gets the User Id For Plot
    /// </summary>
    /// <param name="plotId">Plot Id</param>
    /// <returns>User Id</returns>
    [WebMethod]
    public int GetUserIdForPlot(int plotId)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        return bll.GetUserIdForPlot(plotId);
    }

    /// <summary>
    /// Get Contact List for the Plot
    /// </summary>
    /// <param name="plotId">Plot ID</param>
    /// <returns>List of ContactInfo Model object as Contact List in the Plot</returns>
    [WebMethod]
    public List<ContactInfo> GetContactListForPlot(int plotId)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        List<ContactInfo> contacts = bll.GetContactListForPlot(plotId);

        return contacts;
    }

    /// <summary>
    /// Gets the Contact Details for Contact Id
    /// </summary>
    /// <param name="contactId">Contact Id</param>
    /// <returns>ContactInfo Model Object as Contact Details </returns>
    [WebMethod]
    public ContactInfo GetContactDetails(Int64 contactId)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        ContactInfo contact = bll.GetContactDetails(contactId);

        return contact;
    }

    /// <summary>
    /// Update Contact Details
    /// </summary>
    /// <param name="contact">ContactInfo Model object as contact details</param>
    [WebMethod]
    public void UpdateContactDetails(ContactInfo contact)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        bll.UpdateContactDetails(contact);
    }

    /// <summary>
    /// Add a New Contact
    /// </summary>
    /// <param name="contact">ContactInfo Model Object as contact Details</param>
    [WebMethod]
    public void AddContact(ContactInfo contact)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        bll.AddContact(contact);
    }

    /// <summary>
    /// Delete a contact
    /// </summary>
    /// <param name="contactId">Contact ID to Identify the Contact to be deleted</param>
    /// <param name="lastModifyBy">Last Modify By User ID</param>
    [WebMethod]
    public void DeleteContact(Int64 contactId, int lastModifyBy)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        bll.DeleteContact(contactId, lastModifyBy);
    }

    /// <summary>
    /// Restore a contact
    /// </summary>
    /// <param name="contactId">Contact ID to Identify the Contact to be Restore</param>
    /// <param name="lastModifyBy">Last Modify By User ID</param>
    [WebMethod]
    public void RestoreContact(Int64 contactId, int lastModifyBy)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        bll.RestoreContact(contactId, lastModifyBy);
    }

    /// <summary>
    /// Get Archived Contact List For Plot
    /// </summary>
    /// <param name="plotId">Plot ID</param>
    /// <returns>ContactInfo Array as Contact details for Archived Contacts</returns>
    [WebMethod]
    public List<ContactInfo> GetArchivedContactListForPlot(int plotId)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        return bll.GetArchivedContactListForPlot(plotId);
    }


    /// <summary>
    /// Move a Contact to a desired Plot. 
    /// </summary>
    /// <param name="contactId">Contact Id on which the operation will happen</param>
    /// <param name="plotId">Plot Id is the ID of the plot to which it will be moved</param>
    /// <param name="newPlotName">New Plot Name</param>
    /// <param name="modifiedBy">It is the User Id who has made this changes</param>
    [WebMethod]
    public void MoveContactToPlot(Int64 contactId, int plotId, string newPlotName, int modifiedBy)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        bll.MoveContactToPlot(contactId, plotId, newPlotName, modifiedBy);
    }


    /// <summary>
    /// To Delete a Farm
    /// </summary>
    /// <param name="farmId">Farm Id of the Farm to be deleted</param>
    /// <param name="lastModifyBy">Last Modified By User Id</param>
    [WebMethod]
    public void DeleteFarm(int farmId, int lastModifyBy)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        bll.DeleteFarm(farmId, lastModifyBy);
    }


    /// <summary>
    /// To Delete a Plot
    /// </summary>
    /// <param name="plotId">Plot Id of the Plot Which is to be deleted</param>
    /// <param name="lastModifyBy">Last Modified By User Id</param>
    [WebMethod]
    public void DeletePlot(int plotId, int lastModifyBy)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        bll.DeletePlot(plotId,lastModifyBy);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="farmName"></param>
    /// <returns></returns>
    [WebMethod]
    public bool IsFarmNameDuplicateWhileAddingNewFarm(int userId, string farmName)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        return bll.CheckFarmNameDuplicateWhileAdding(userId, farmName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="farmId"></param>
    /// <param name="farmName"></param>
    /// <returns></returns>
    [WebMethod]
    public bool IsFarmNameDuplicateWhileEditingFarm(int userId, int farmId, string farmName)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        return bll.CheckFarmNameDuplicateWhileEditing(userId, farmId, farmName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="farmId"></param>
    /// <param name="plotName"></param>
    /// <returns></returns>
    [WebMethod]
    public bool IsPlotNameDuplicateWhileAddingNewPlot(int farmId, string plotName)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        return bll.CheckPlotNameDuplicateWhileAdding(farmId, plotName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="farmId"></param>
    /// <param name="plotId"></param>
    /// <param name="plotName"></param>
    /// <returns></returns>
    [WebMethod]
    public bool IsPlotNameDuplicateWhileEditingPlot(int farmId, int plotId, string plotName)
    {
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();

        return bll.CheckPlotNameDuplicateWhileEditing(farmId, plotId, plotName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="plotId"></param>
    /// <returns></returns>
    [WebMethod]
    public String ExportContactListToExcel(int userId,int plotId)
    {
        String sourceFileName = "ContactListTemplate.xls";
        String destinationFileName = plotId.ToString() + "_" + "ContactList.xls";
        
        //Build Source directory and Destination directory.

        String sourcePath = System.Configuration.ConfigurationManager.AppSettings["ContactFileLocation"];
        String destinationPath = sourcePath;
        
        if (!sourcePath.EndsWith("\\"))
        {
            sourcePath += "\\";
        }
        sourcePath += sourceFileName;
        if (!destinationPath.EndsWith("\\"))
        {
            destinationPath += "\\";
        }
        destinationPath += userId;
        destinationPath += "\\" + destinationFileName;

        //Getting the list of contacts for the Given Plot
        List<ContactInfo> contacts = new List<ContactInfo>();
        // Get an instance of the MailingCycle BO
        Farm bll = new Farm();
        contacts = bll.GetContactListForPlot(plotId);
        int totalContacts = contacts.Count;
        
        try
        {
            //Copy file to user Workspace
            if (File.Exists(destinationPath))
                File.Delete(destinationPath);
            File.Copy(sourcePath, destinationPath);

            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable schemaTable = new DataTable();
            string connectionString = string.Empty;
            connectionString = "Data Source=" + destinationPath + ";" +
                    "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Extended Properties=Excel 8.0;";
            OleDbConnection connection = new OleDbConnection();
            connection = new OleDbConnection(connectionString);
                        
            connection.Open();

            //To get the Table name
            schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
            string tableName = schemaTable.Rows[0]["Table_Name"].ToString();
            schemaTable.Clear();

            //Adding Contacts to the Excel file through OleDbCommand Object
            for (int i = 0; i < totalContacts; i++)
            {
                string sqlInsertQuery = "INSERT INTO [" + tableName + "] (";
                sqlInsertQuery += "[ScheduleNumber], [OwnerFullName], [Lot],";
                sqlInsertQuery += "[Block], [subdivision], [Filing],";
                sqlInsertQuery += "[SiteAddress], [BedRooms], [FullBath],";
                sqlInsertQuery += " [ThreeQuaterBath], [HalfBath], [Acres],";
                sqlInsertQuery += "[AckMktCombo], [OwnerFirstName], [OwerLastName],";
                sqlInsertQuery += "[OwnerAddressLine1], [OwnerAddressLine2], [OwnerCity],";
                sqlInsertQuery += "[OwnerState], [OwnerZip], [OwnerCountry],";
                sqlInsertQuery += "[SaleDate], [TransAmount]) ";
                sqlInsertQuery += "VALUES('" + contacts[i].ScheduleNumber.ToString() + "','" + contacts[i].OwnerFullName + "'," + contacts[i].Lot.ToString() + ",";
                sqlInsertQuery += "'" + contacts[i].Block + "','" + contacts[i].Subdivision + "','" + contacts[i].Filing + "',";
                sqlInsertQuery += "'" + contacts[i].SiteAddress + "'," + contacts[i].Bedrooms.ToString() + "," + contacts[i].FullBath.ToString() + ",";
                sqlInsertQuery += "" + contacts[i].ThreeQuarterBath.ToString() + "," + contacts[i].HalfBath.ToString() + "," + contacts[i].Acres.ToString() + ",";
                sqlInsertQuery += "'" + contacts[i].ActMktComb + "','" + contacts[i].OwnerFirstName + "','" + contacts[i].OwnerLastName + "',";
                sqlInsertQuery += "'" + contacts[i].OwnerAddress1 + "','" + contacts[i].OwnerAddress2 + "','" + contacts[i].OwnerCity + "',";
                sqlInsertQuery += "'" + contacts[i].OwnerState + "','" + contacts[i].OwnerZip + "','" + contacts[i].OwnerCountry + "',";
                sqlInsertQuery += "'" + contacts[i].SaleDate.ToShortDateString() + "'," + contacts[i].TransAmount.ToString();
                sqlInsertQuery += ")";
                OleDbCommand InsertCommand = new OleDbCommand(sqlInsertQuery, connection);
                InsertCommand.ExecuteNonQuery();
            }
            connection.Close();
        }
        catch 
        {
            //if (connection.State = ConnectionState.Open)
                //connection.Close();
            throw;
        }


        return destinationFileName;
    }

    /// <summary>
    ///  To Generate Contact List from Array of Contact Ids
    /// </summary>
    /// <param name="contactIds">String Array of Contact Ids</param>
    /// <returns>List of ContactInfo Model Object</returns>
    [WebMethod]
    public List<ContactInfo> GenerateContactListFromArrayOfContactID(string[] contactIds)
    {
        List<ContactInfo> contacts = new List<ContactInfo>();
        Farm bll = new Farm();
        for (int i = 0; i < contactIds.Length; i++)
        {
            contacts.Add(bll.GetContactDetails(Convert.ToInt64(contactIds[i])));
        }

        return contacts;
    }

    /// <summary>
    /// To delete Farm and related Plots and Contacts
    /// </summary>
    /// <param name="farmId">Farm Id</param>
    /// <param name="lastModifyBy">LastModifyBy User ID</param>
    [WebMethod]
    public void DeleteFarmPlot(int farmId, int lastModifyBy)
    {
        Farm bll = new Farm();
        bll.DeleteFarmPlot(farmId,lastModifyBy);
    }

    /// <summary>
    /// To Restore Farm and related Plots and Contacts
    /// </summary>
    /// <param name="farmId">Farm Id</param>
    /// <param name="lastModifyBy">Last Modified by User Id</param>
    [WebMethod]
    public void RestoreFarmPlot(int farmId, int lastModifyBy)
    {
        Farm bll = new Farm();
        bll.RestoreFarmPlot(farmId, lastModifyBy);
    }

    /// <summary>
    /// Delete Plot and its Contacts and if Farm is Empty it Deletes the Farm too.
    /// </summary>
    /// <param name="plotId">Plot Id</param>
    /// <param name="lastModifyBy">LastModifyBy User ID</param>
    [WebMethod]
    public void DeletePlotContact(int plotId, int lastModifyBy)
    {
        Farm bll = new Farm();
        bll.DeletePlotContact(plotId,lastModifyBy);
    }

    /// <summary>
    /// Restore Plot and its Contacts.
    /// </summary>
    /// <param name="plotId">Plot Id</param>
    /// <param name="lastModifyBy">Last Modify By User Id</param>
    [WebMethod]
    public void RestorePlotContact(int plotId, int lastModifyBy)
    {
        Farm bll = new Farm();
        bll.RestorePlotContact(plotId, lastModifyBy);
    }

    /// <summary>
    /// To Check weather a Given Plot is Delault Plot or Not
    /// </summary>
    /// <param name="plotId">Plot Id</param>
    /// <returns>Boolean True if it is a default Plot else False</returns>
    [WebMethod]
    public bool IsDefaultPlot(int plotId)
    {
        Farm bll = new Farm();
        return bll.IsDefaultPlot(plotId);
    }


    /// <summary>
    /// Total Count of Active Farms
    /// </summary>
    /// <returns>Count of Active Farms</returns>
    [WebMethod]
    public int TotalActiveFarmCount()
    {
        Farm bll = new Farm();
        return bll.TotalActiveFarmCount();
    }

    /// <summary>
    /// Total Count of Archived Farms
    /// </summary>
    /// <returns>Count of Archived Farms</returns>
    [WebMethod]
    public int TotalArchivedFarmCount()
    {
        Farm bll = new Farm();
        return bll.TotalArchivedFarmCount();
    }

    /// <summary>
    /// Total Count of Active Plots
    /// </summary>
    /// <returns>Count of Active Plots</returns>
    [WebMethod]
    public int TotalActivePlotCount()
    {
        Farm bll = new Farm();
        return bll.TotalActivePlotCount();
    }

    /// <summary>
    /// Total Count of Archived Plots
    /// </summary>
    /// <returns>Count of Archived Plots</returns>
    [WebMethod]
    public int TotalArchivedPlotCount()
    {
        Farm bll = new Farm();
        return bll.TotalArchivedPlotCount();
    }

    /// <summary>
    /// Total Count of Active Contact
    /// </summary>
    /// <returns>Count of Active Contacts</returns>
    [WebMethod]
    public Int64 TotalActiveContactCount()
    {
        Farm bll = new Farm();
        return bll.TotalActiveContactCount();
    }

    /// <summary>
    /// Total Count of Archived Contact
    /// </summary>
    /// <returns>Count of Archived Contacts</returns>
    [WebMethod]
    public Int64 TotalArchivedContactCount()
    {
        Farm bll = new Farm();
        return bll.TotalArchivedContactCount();
    }

    /// <summary>
    /// Datatable for Farm Plot Contact Report
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns>Model object of FarmDetailsReportInfo as Farm Plot Contact Report</returns>
    [WebMethod]
    public List<FarmDetailsReportInfo> ReportForFarmDetails(int userId)
    {
        Farm bll = new Farm();
        return bll.ReportForFarmDetails(userId);
    }

    /// <summary>
    /// Gets the List of contacts from the Search ceriteria 
    /// </summary>
    /// <param name="where">String where SQL WHERE clause is configured</param>
    /// <returns>Model object of FarmDetailsReportInfo</returns>
    [WebMethod]
    public List<FarmDetailsReportInfo> GetSearchFarmData(string where)
    {
        Farm bll = new Farm();
        return bll.GetSearchFarmData(where);
    }

    /// <summary>
    ///     Get the Summary List of Firmed Up Farms
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="FirmUpStatus">Firm Up Status</param>
    /// <returns>List of FirmUpStatusReportInfo Model Object </returns>
    [WebMethod]
    public List<FirmUpStatusReportInfo> GetFirmUpStatusSummaryDetails(int userId, bool FirmUpStatus)
    {
        Farm bll = new Farm();
        return bll.GetFirmUpStatusSummaryDetails(userId, FirmUpStatus);
    }

    [WebMethod]
    public List<MailingLabelInfo> GetMailingLabels(int userId, int farmId, int plotId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();

        List<MailingLabelInfo> mailingLabels = 
            bll.GetMailingLabels(userId, farmId, plotId);

        return mailingLabels;
    }

    /// <summary>
    ///     Getting Farm Data Report Data which is Agent wise Farm Summary
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="where">SQL Where Condition</param>
    /// <returns>FarmDataReportInfo Model Object List</returns>
    [WebMethod]
    public List<FarmDataReportInfo> GetFarmDataReportData(int userId, string where)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        return bll.GetFarmDataReportData(userId, where);
    }

    /// <summary>
    ///     Get the Consiquence of Deleting a Contact
    /// </summary>
    /// <param name="contactId">Contact Id</param>
    /// <returns>Consiquence as string</returns>
    [WebMethod]
    public string GetDeleteContactConsiquence(Int64 contactId)
    {
        // Get an instance of the Farm BO
        Farm bll = new Farm();
        return bll.GetDeleteContactConsiquence(contactId);
    }

}
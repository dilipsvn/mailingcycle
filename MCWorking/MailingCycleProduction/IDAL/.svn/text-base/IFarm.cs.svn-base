using System;
using System.Collections.Generic;
using Irmac.MailingCycle.Model;
using System.Data;

namespace Irmac.MailingCycle.IDAL
{
    /// <summary>
    /// Inteface for the Farm DAL.
    /// </summary>
    public interface IFarm
    {

        /// <summary>
        /// Gets User Name for the Given User Id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>User Name of the Application User</returns>
        string GetUserName(int userId);

        /// <summary>
        /// Get the List of Farms for the user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of FarmInfo Model Object as Farm List</returns>
        List<FarmInfo> GetFarmListForUser(int userId);
        
        /// <summary>
        /// Get the farm details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Farm Details of the specified registration account.</returns>
        List<FarmInfo> GetFarmSummary(int userId);

        /// <summary>
        /// Get the Dleted (Archived) farm details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Farm Details of the specified registration account.</returns>
        List<FarmInfo> GetArchivedFarmSummary(int userId);

        /// <summary>
        /// Get the Dleted (Archived) farm details of the specified Farm.
        /// </summary>
        /// <param name="farmId">Farm ID</param>
        /// <returns>FarmInfo Model object as details of the specified Farm.</returns>
        FarmInfo GetArchivedFarmSummaryDetails(int farmId);

        /// <summary>
        /// Gets the List of Plots for a Farm
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>List of PlotInfo Model object as a Plot List</returns>
        List<PlotInfo> GetPlotListForFarm(int farmId);

        /// <summary>
        /// Get the Dleted (Archived) Plot details of the specified Farm with deleted contact Count.
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>PlotInfo Model Object as Archived Plot Summary List Details</returns>
        List<PlotInfo> GetArchivedPlotSummary(int farmId);

        /// <summary>
        /// Get the Dleted (Archived) Plot details of the specified Plot with Contact count.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>PlotInfo Model Object as Archived Plot Summary Details</returns>
        PlotInfo GetArchivedPlotSummaryDetails(int plotId);

        /// <summary>
        ///     Get Archived Contact List For Plot
        /// </summary>
        /// <param name="plotId">Plot ID</param>
        /// <returns>ContactInfo Array as Contact details for Archived Contacts</returns>
        List<ContactInfo> GetArchivedContactListForPlot(int plotId);

        /// <summary>
        /// Get the List of Mailing Plan From TBL_Mailing Plan
        /// </summary>
        /// <returns>Returns the list of Mailing Plan</returns>
        List<MailingPlanInfo> GetMailingPlanList();


        /// <summary>
        /// Create a new farm with default plot with contacts
        /// </summary>
        /// <param name="fram">Accepts FarmInfo as input</param>
        void CreateFarmPlot(FarmInfo fram);

        
        /// <summary>
        /// updates the farm details and default plot details with contacts
        /// </summary>
        /// <param name="fram">Accepts FarmInfo as input</param>
        void UpdateFarmPlot(FarmInfo farm);


        /// <summary>
        /// To Delete a Farm
        /// </summary>
        /// <param name="farmId">Farm Id of the Farm to be deleted</param>
        /// <param name="lastModifyBy">Last Modified By User Id</param>
        void DeleteFarm(int farmId, int lastModifyBy);


        /// <summary>
        /// Gets userId for the Farm
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>User ID</returns>
        int GetUserIdForFarm(int farmId);

        /// <summary>
        /// Gets the User Id For Plot
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>User Id</returns>
        int GetUserIdForPlot(int plotId);

        /// <summary>
        /// Get the number plots attached to the Farm
        /// </summary>
        /// <param name="farmId">Farm ID</param>
        /// <returns>Count of plots</returns>
        int GetPlotCountForFarm(int farmId);


        /// <summary>
        /// Create a new plot
        /// </summary>
        /// <param name="Plot">Accepts PlotInfo as input</param>
        int CreatePlotForMoveContacts(PlotInfo plot);

        /// <summary>
        /// Create a new plot with contacts
        /// </summary>
        /// <param name="Plot">Accepts PlotInfo as input</param>
        void CreatePlot(PlotInfo plot);


        /// <summary>
        /// Update Plot
        /// </summary>
        /// <param name="Plot">Accepts PlotInfo as input</param>
        void UpdatePlot(PlotInfo plot);

        /// <summary>
        /// Get the number Contacts attached to the Plot
        /// </summary>
        /// <param name="farmId">Plot ID</param>
        /// <returns>Count of Contacts</returns>
        int GetContactCountForPlot(int plotId);

        /// <summary>
        /// To Delete a Plot
        /// </summary>
        /// <param name="plotId">Plot Id of the Plot Which is to be deleted</param>
        /// <param name="lastModifyBy">Last Modified By User Id</param>
        void DeletePlot(int plotId, int lastModifyBy);

        /// <summary>
        /// Get farm details for a Farm Id
        /// </summary>
        /// <param name="FarmId">Farm ID</param>
        /// <returns>FarmInfo Model Object as Farm Details</returns>
        FarmInfo GetFarmDetail(int FarmId);

        
        /// <summary>
        /// Gets the List of Plots for a Farm
        /// </summary>
        /// <param name="FarmId">Farm ID</param>
        /// <returns>PlotInfo as the List of Plots</returns>
        List<PlotInfo> GetPlotListSummaryForFarm(int FarmId);

        /// <summary>
        /// Get Plot Detail for a Given Plot Id
        /// </summary>
        /// <param name="PlotId">Plot ID</param>
        /// <returns>PlotInfo Model object as Plot Details</returns>
        PlotInfo GetPlotDetail(int PlotId);

        /// <summary>
        /// Returns a boolean value indicating whether the farm exists.
        /// </summary>
        /// <param name="farmId">farm Id</param>
        /// <returns>Returns a boolean value indicating whether the farm exists</returns>
        bool IsFarmExists(string farmName);

        /// <summary>
        /// Returns a boolean value indicating whether the farm exists for an User.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="farmName">Farm Name</param>
        /// <returns>Returns a boolean value indicating whether the farm exists for an user</returns>
        bool IsFarmExistsForUser(int userId, string farmName);

        /// <summary>
        /// Returns a boolean value indicating whether the farm exists for an User For Update.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="farmId">Farm Id</param>
        /// <param name="farmName">Farm Name</param>
        /// <returns>Returns a boolean value indicating whether the farm exists for an user</returns>
        bool IsFarmExistsForUserOnUpdate(int userId, int farmId, string farmName);

        /// <summary>
        /// Returns a boolean value indicating whether the Plot exists.
        /// </summary>
        /// <param name="PlotId">Plot Id</param>
        /// <returns>Returns a boolean value indicating whether the Plot exists</returns>
        bool IsPlotExists(string plotName);

        /// <summary>
        /// Returns a boolean value indicating whether the Plot exists with in the Farm.
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="plotName">Plot Name</param>
        /// <returns>Returns a boolean value indicating whether the Plot exists with in the Farm</returns>
        bool IsPlotExistsForFarm(int farmId, string plotName);

        /// <summary>
        /// Returns a boolean value indicating whether the Plot exists with in the Farm on Update.
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="plotId">Plot Id</param>
        /// <param name="plotName">Plot Name</param>
        /// <returns>Returns a boolean value indicating whether the Plot exists with in the Farm</returns>
        bool IsPlotExistsForFarmOnUpdate(int farmId, int plotId, string plotName);
        
        /// <summary>
        /// List of contacts in a Plot
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>Array of ContactInfo Model object as Contact List</returns>
        List<ContactInfo> GetContactListForPlot(int plotId);

        /// <summary>
        /// Gets the Contact Details for Contact Id
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>ContactInfo Model Object as Contact Details </returns>
        ContactInfo GetContactDetails(Int64 contactId);

        /// <summary>
        /// Update Contact Details
        /// </summary>
        /// <param name="contact">ContactInfo Model object as contact details</param>
        void UpdateContactDetails(ContactInfo contact);

        /// <summary>
        /// Add a New Contact
        /// </summary>
        /// <param name="contact">ContactInfo Model Object as contact Details</param>
        void AddContact(ContactInfo contact);

        /// <summary>
        /// Delete a contact
        /// </summary>
        /// <param name="contactId">Contact ID to Identify the Contact to be deleted</param>
        /// <param name="lastModifyBy">Last Modify By User ID</param>
        void DeleteContact(Int64 contactId, int lastModifyBy);

        /// <summary>
        /// Restore a contact
        /// </summary>
        /// <param name="contactId">Contact ID to Identify the Contact to be Restore</param>
        /// <param name="lastModifyBy">Last Modify By User ID</param>
        void RestoreContact(Int64 contactId, int lastModifyBy);

        /// <summary>
        /// Move a Contact to a desired Plot. 
        /// </summary>
        /// <param name="contactId">Contact Id on which the operation will happen</param>
        /// <param name="plotId">Plot Id is the ID of the plot to which it will be moved</param>
        /// <param name="newPlotName">New Plot Name</param>
        /// <param name="modifiedBy">It is the User Id who has made this changes</param>
        void MoveContactToPlot(Int64 contactId, int plotId, string newPlotName, int modifiedBy);

        /// <summary>
        /// Gets the count of Farms available by the Farm Name on a pirticular User
        /// </summary>
        /// <param name="userId">User Id of the user</param>
        /// <param name="farmName">Name of the Farm</param>
        /// <returns>Count of Forms</returns>
        int GetCountOfFarmsForFarmNameOnUser(int userId, string farmName);

        /// <summary>
        /// Gets the Count of Duplicate Farm Names While Editing
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="farmId">Farm Id</param>
        /// <param name="farmName">Farm Name</param>
        /// <returns>Count of Duplicate Farm</returns>
        int GetCountOfDuplicateFarmNameForEdit(int userId, int farmId, string farmName);

        /// <summary>
        /// Gets the Count of Duplicate Plot Names While Editing
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="plotId">Plot Id</param>
        /// <param name="plotName">Plot Name</param>
        /// <returns>Count of Duplicate Plots</returns>
        int GetCountOfDuplicatePlotNameForEdit(int farmId, int plotId, string plotName);


        /// <summary>
        /// Gets the count of Plots available by the Plot Name on a pirticular Farm
        /// </summary>
        /// <param name="farmId">Plot Id </param>
        /// <param name="plotName">Name of the Plot</param>
        /// <returns>Count of Plots</returns>
        int GetCountOfPlotsForPlotNameOnFarm(int farmId, string plotName);

        /// <summary>
        /// To delete Farm and related Plots and Contacts
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        void DeleteFarmPlot(int farmId,int lastModifyBy);

        /// <summary>
        /// To Restore Farm and related Plots and Contacts
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="lastModifyBy">Last Modified by User Id</param>
        void RestoreFarmPlot(int farmId, int lastModifyBy);

        /// <summary>
        /// Delete Plot and its Contacts and if Farm is Empty it Deletes the Farm too.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <param name="lastModifyBy">Last Modify By User Id</param>
        void DeletePlotContact(int plotId, int lastModifyBy);

        /// <summary>
        /// Restore Plot and its Contacts.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <param name="lastModifyBy">Last Modify By User Id</param>
        void RestorePlotContact(int plotId, int lastModifyBy);

        /// <summary>
        /// To Check weather a Given Plot is Delault Plot or Not
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>Boolean True if it is a default Plot else False</returns>
        bool IsDefaultPlot(int plotId);

        /// <summary>
        /// Total Count of Active Farms
        /// </summary>
        /// <returns>Count of Active Farms</returns>
        int TotalActiveFarmCount();

        /// <summary>
        /// Total Count of Archived Farms
        /// </summary>
        /// <returns>Count of Archived Farms</returns>
        int TotalArchivedFarmCount();

        /// <summary>
        /// Total Count of Active Plots
        /// </summary>
        /// <returns>Count of Active Plots</returns>
        int TotalActivePlotCount();

        /// <summary>
        /// Total Count of Archived Plots
        /// </summary>
        /// <returns>Count of Archived Plots</returns>
        int TotalArchivedPlotCount();
        
        /// <summary>
        /// Total Count of Active Contact
        /// </summary>
        /// <returns>Count of Active Contacts</returns>
        Int64 TotalActiveContactCount();

        /// <summary>
        /// Total Count of Archived Contact
        /// </summary>
        /// <returns>Count of Archived Contacts</returns>
        Int64 TotalArchivedContactCount();

        /// <summary>
        /// Datatable for Farm Plot Contact Report
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Model object of FarmDetailsReportInfo as Farm Plot Contact Report</returns>
        List<FarmDetailsReportInfo> ReportForFarmDetails(int userId);

        /// <summary>
        /// Gets the List of contacts from the Search ceriteria 
        /// </summary>
        /// <param name="where">String where SQL WHERE clause is configured</param>
        /// <returns>Model object of FarmDetailsReportInfo</returns>
        List<FarmDetailsReportInfo> GetSearchFarmData(string where);

        /// <summary>
        /// Gets the mailing labels for the specified parameters.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <returns>Mailing labels for the specified parameters.</returns>
        List<MailingLabelInfo> GetMailingLabels(int userId, int farmId, int plotId);

        /// <summary>
        ///     Get the Summary List of Firmed Up Farms
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="FirmUpStatus">Firm Up Status</param>
        /// <returns>List of FirmUpStatusReportInfo Model Object </returns>
        List<FirmUpStatusReportInfo> GetFirmUpStatusSummaryDetails(int userId, bool FirmUpStatus);

        /// <summary>
        ///     Getting Farm Data Report Data which is Agent wise Farm Summary
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="where">SQL Where Condition</param>
        /// <returns>FarmDataReportInfo Model Object List</returns>
        List<FarmDataReportInfo> GetFarmDataReportData(int userId, string where);

        /// <summary>
        ///     Get the Consiquence of Deleting a Contact
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>Consiquence as string</returns>
        string GetDeleteContactConsiquence(Int64 contactId);
    }
}

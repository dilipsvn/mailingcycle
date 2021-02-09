#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: Farm.cs
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/04/2007
	* Author			: Irmac Development Team 
	* Comment			: Farm
	* Source			: MailingCycle\BLL\Farm.cs

	****************************************************************/
#endregion

#region NameSpaces
using System;
using System.Collections.Generic;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;
using System.Data;
#endregion

namespace Irmac.MailingCycle.BLL
{
    /// <summary>
    /// A Business Component used to manage Farms.
    /// </summary>
    public class Farm
    {
        
        /// <summary>
        /// Gets User Name for the Given User Id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>User Name of the Application User</returns>
        public string GetUserName(int userId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.GetUserName(userId);
        }
        
        /// <summary>
        /// Get the List of Farms for the user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of FarmInfo Model Object as Farm List</returns>
        public List<FarmInfo> GetFarmListForUser(int userId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.GetFarmListForUser(userId);
        }

        /// <summary>
        /// Get the farm details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Farm Details of the specified registration account.</returns>
        public List<FarmInfo> GetFarmSummary(int userId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            List<FarmInfo> farms = dao.GetFarmSummary(userId);

            return farms;
        }
        
        /// <summary>
        /// Get the Dleted (Archived) farm details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Farm Details of the specified registration account.</returns>
        public List<FarmInfo> GetArchivedFarmSummary(int userId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            List<FarmInfo> farms = dao.GetArchivedFarmSummary(userId);

            return farms;
        }

        /// <summary>
        /// Get the Dleted (Archived) farm details of the specified Farm.
        /// </summary>
        /// <param name="userId">Farm ID</param>
        /// <returns>FarmInfo Model object as details of the specified Farm.</returns>
        public FarmInfo GetArchivedFarmSummaryDetails(int farmId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.GetArchivedFarmSummaryDetails(farmId);
        }

        /// <summary>
        /// Gets the List of Plots for a Farm
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>List of PlotInfo Model object as a Plot List</returns>
        public List<PlotInfo> GetPlotListForFarm(int farmId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.GetPlotListForFarm(farmId);
        }


        /// <summary>
        /// Get the Dleted (Archived) Plot details of the specified Farm with deleted contact Count.
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>PlotInfo Model Object as Archived Plot Summary List Details</returns>
        public List<PlotInfo> GetArchivedPlotSummary(int farmId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            List<PlotInfo> plots = dao.GetArchivedPlotSummary(farmId);

            return plots;
        }

        /// <summary>
        /// Get the Dleted (Archived) Plot details of the specified Plot with Contact count.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>PlotInfo Model Object as Archived Plot Summary Details</returns>
        public PlotInfo GetArchivedPlotSummaryDetails(int plotId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.GetArchivedPlotSummaryDetails(plotId);
        }

        /// <summary>
        /// Gets the List of Mailing Plan
        /// </summary>
        /// <returns>Returns the List of Mailing Plan</returns>
        public List<MailingPlanInfo> GetMailingPlanList()
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            List<MailingPlanInfo> mailingPlans = new List<MailingPlanInfo>();
            mailingPlans = dao.GetMailingPlanList();
            mailingPlans.Insert(0,new MailingPlanInfo(0, "<Select a Mailing Plan>"));
            return mailingPlans;
        }

        /// <summary>
        /// Creating Farm and a default plot
        /// </summary>
        /// <param name="farm">FarmInfo Model Object as a parameter</param>
        public void CreateFarmPlot(FarmInfo farm)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            
            if (dao.GetCountOfFarmsForFarmNameOnUser(farm.UserId, farm.FarmName) == 0)
                dao.CreateFarmPlot(farm);
            else
                throw new Exception("Farm Name Already Exist");
        }

        /// <summary>
        /// Updating Farm and a default plot
        /// </summary>
        /// <param name="farm">FarmInfo Model Object as a parameter</param>
        public void UpdateFarmPlot(FarmInfo farm)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            if (dao.GetCountOfDuplicateFarmNameForEdit(farm.UserId, farm.FarmId, farm.FarmName) == 0)
                dao.UpdateFarmPlot(farm);
            else
                throw new Exception("Farm Name already Exist.");
        }

        /// <summary>
        /// Gets userId for the Farm
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <returns>User ID</returns>
        public int GetUserIdForFarm(int farmId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            return dao.GetUserIdForFarm(farmId);
        }

        /// <summary>
        /// Gets the User Id For Plot
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>User Id</returns>
        public int GetUserIdForPlot(int plotId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            return dao.GetUserIdForPlot(plotId);
        }

        /// <summary>
        /// Create a new plot
        /// </summary>
        /// <param name="Plot">Accepts PlotInfo as input</param>
        public int CreatePlotForMoveContacts(PlotInfo plot)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.CreatePlotForMoveContacts(plot);
        }


        /// <summary>
        /// Creating plot
        /// </summary>
        /// <param name="Plot">PlotInfo Model Object as a parameter</param>
        public void CreatePlot(PlotInfo plot)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            if (dao.GetCountOfPlotsForPlotNameOnFarm(plot.FarmId, plot.PlotName) == 0)
                dao.CreatePlot(plot);
            else
                throw new Exception("Plot Name already exisist.");
        }


        /// <summary>
        /// Updating plot
        /// </summary>
        /// <param name="Plot">PlotInfo Model Object as a parameter</param>
        public void UpdatePlot(PlotInfo plot)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            if (dao.GetCountOfDuplicatePlotNameForEdit(plot.FarmId, plot.PlotId, plot.PlotName) == 0)
                dao.UpdatePlot(plot);
            else
                throw new Exception("Plot Name Already Exist.");
        }

        /// <summary>
        /// Gets the Farm Details for a given Farm Id
        /// </summary>
        /// <param name="FarmId">Farm Id</param>
        /// <returns>Return FarmInfo Model Object</returns>
        public FarmInfo GetFarmDetail(int FarmId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            FarmInfo farm = dao.GetFarmDetail(FarmId);

            return farm;
        }

        /// <summary>
        /// To Delete a Farm
        /// </summary>
        /// <param name="farmId">Farm Id of the Farm to be deleted</param>
        /// <param name="lastModifyBy">Last Modified By User Id</param>
        public void DeleteFarm(int farmId, int lastModifyBy)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            //Check if there is a Plot/s attached to the farm.
            if (dao.GetPlotCountForFarm(farmId) == 0)
                dao.DeleteFarm(farmId, lastModifyBy);
            else
                throw new Exception("Farm is not Empty");
        }


        /// <summary>
        /// To Delete a Plot
        /// </summary>
        /// <param name="plotId">Plot Id of the Plot Which is to be deleted</param>
        /// <param name="lastModifyBy">Last Modified By User Id</param>
        public void DeletePlot(int plotId, int lastModifyBy)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            //Check if any Contacts Attached to the Farm
            if (dao.GetContactCountForPlot(plotId) == 0)
                dao.DeletePlot(plotId, lastModifyBy);
            else
                throw new Exception("Plot is not Empty");
        }


        /// <summary>
        /// Getting Plot List for a farm
        /// </summary>
        /// <param name="FarmId">Farm Id</param>
        /// <returns>Returns List of Plot as PlotInfo Model object</returns>
        public List<PlotInfo> GetPlotListSummaryForFarm(int FarmId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            List<PlotInfo> plots = dao.GetPlotListSummaryForFarm(FarmId);

            return plots;
        }

        /// <summary>
        /// Get Plot Detail for a Given Plot Id
        /// </summary>
        /// <param name="PlotId">Plot ID</param>
        /// <returns>PlotInfo Model object as Plot Details</returns>
        public PlotInfo GetPlotDetail(int PlotId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            PlotInfo plot = dao.GetPlotDetail(PlotId);

            return plot;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the farm exists.
        /// </summary>
        /// <param name="farmId">farm Id</param>
        /// <returns>Returns a boolean value indicating whether the farm exists</returns>
        public bool IsFarmExists(string farmName)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            bool isFarmExists = dao.IsFarmExists(farmName);

            return isFarmExists;
        }


        /// <summary>
        /// Get the number plots attached to the Farm
        /// </summary>
        /// <param name="farmId">Farm ID</param>
        /// <returns>Count of plots</returns>
        public int GetPlotCountForFarm(int farmId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            return dao.GetPlotCountForFarm(farmId);
        }


        /// <summary>
        /// Returns a boolean value indicating whether the Plot exists.
        /// </summary>
        /// <param name="PlotId">Plot Id</param>
        /// <returns>Returns a boolean value indicating whether the Plot exists</returns>
        public bool IsPlotExists(string plotName)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            bool isPlotExists = dao.IsPlotExists(plotName);

            return isPlotExists;
        }

        
        /// <summary>
        /// Get the number Contacts attached to the Plot
        /// </summary>
        /// <param name="farmId">Plot ID</param>
        /// <returns>Count of Contacts</returns>
        public int GetContactCountForPlot(int plotId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            return dao.GetContactCountForPlot(plotId);
        }


        /// <summary>
        /// List of contacts in a Plot
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>Array of ContactInfo Model object as Contact List</returns>
        public List<ContactInfo> GetContactListForPlot(int plotId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            List<ContactInfo> contacts = dao.GetContactListForPlot(plotId);

            return contacts;
        }

        /// <summary>
        /// Gets the Contact Details for Contact Id
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>ContactInfo Model Object as Contact Details </returns>
        public ContactInfo GetContactDetails(Int64 contactId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            ContactInfo contact = dao.GetContactDetails(contactId);

            return contact;
        }

        /// <summary>
        /// Update Contact Details
        /// </summary>
        /// <param name="contact">ContactInfo Model object as contact details</param>
        public void UpdateContactDetails(ContactInfo contact)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            dao.UpdateContactDetails(contact);
        }

        /// <summary>
        /// Add a New Contact
        /// </summary>
        /// <param name="contact">ContactInfo Model Object as contact Details</param>
        public void AddContact(ContactInfo contact)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            dao.AddContact(contact);
        }


        /// <summary>
        /// Delete a contact
        /// </summary>
        /// <param name="contactId">Contact ID to Identify the Contact to be deleted</param>
        /// <param name="lastModifyBy">Last Modify By User ID</param>
        public void DeleteContact(Int64 contactId, int lastModifyBy)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            dao.DeleteContact(contactId, lastModifyBy);
        }

        /// <summary>
        /// Restore a contact
        /// </summary>
        /// <param name="contactId">Contact ID to Identify the Contact to be Restore</param>
        /// <param name="lastModifyBy">Last Modify By User ID</param>
        public void RestoreContact(Int64 contactId, int lastModifyBy)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            dao.RestoreContact(contactId, lastModifyBy);
        }

        /// <summary>
        ///     Get Archived Contact List For Plot
        /// </summary>
        /// <param name="plotId">Plot ID</param>
        /// <returns>ContactInfo Array as Contact details for Archived Contacts</returns>
        public List<ContactInfo> GetArchivedContactListForPlot(int plotId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            
            return dao.GetArchivedContactListForPlot(plotId);
        }

        /// <summary>
        /// To Check Duplicate Farm Name on User while Adding a Farm
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="farmName">Farm Name</param>
        /// <returns>Boolean Value True if Duplicate Exist or false it the farm Name is not duplicate</returns>
        public bool CheckFarmNameDuplicateWhileAdding(int userId, string farmName)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            
            if (dao.GetCountOfFarmsForFarmNameOnUser(userId, farmName) != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// To Check Duplicate Farm Name on User while Editing a Farm
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="farmId">Farm ID</param>
        /// <param name="farmName">Farm Name</param>
        /// <returns>Boolean Value True if Duplicate Exist or false it the farm Name is not duplicate</returns>
        public bool CheckFarmNameDuplicateWhileEditing(int userId, int farmId, string farmName)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            if (dao.GetCountOfDuplicateFarmNameForEdit(userId, farmId ,farmName) != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// To Check Duplicate Plot Name on User while Adding a Plot
        /// </summary>
        /// <param name="farmId">Farm ID</param>
        /// <param name="plotName">Plot Name</param>
        /// <returns>Boolean Value True if Duplicate Exist or false it the plot Name is not duplicate</returns>
        public bool CheckPlotNameDuplicateWhileAdding(int farmId, string plotName)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            if (dao.GetCountOfPlotsForPlotNameOnFarm(farmId, plotName) != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// To Check Duplicate Plot Name on User while Editing a Plot
        /// </summary>
        /// <param name="farmId">farm ID</param>
        /// <param name="plotId">Plot ID</param>
        /// <param name="plotName">Plot Name</param>
        /// <returns>Boolean Value True if Duplicate Exist or false it the plot Name is not duplicate</returns>
        public bool CheckPlotNameDuplicateWhileEditing(int farmId, int plotId, string plotName)
        {
            
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            if (dao.GetCountOfDuplicatePlotNameForEdit(farmId, plotId, plotName) != 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Move a Contact to a desired Plot. 
        /// </summary>
        /// <param name="contactId">Contact Id on which the operation will happen</param>
        /// <param name="plotId">Plot Id is the ID of the plot to which it will be moved</param>
        /// <param name="newPlotName">New Plot Name</param>
        /// <param name="modifiedBy">It is the User Id who has made this changes</param>
        public void MoveContactToPlot(Int64 contactId, int plotId, string newPlotName, int modifiedBy)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            dao.MoveContactToPlot(contactId, plotId, newPlotName, modifiedBy);
        }

        /// <summary>
        /// To delete Farm and related Plots and Contacts
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        public void DeleteFarmPlot(int farmId, int lastModifyBy)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            dao.DeleteFarmPlot(farmId,lastModifyBy);
        }

        /// <summary>
        /// To Restore Farm and related Plots and Contacts
        /// </summary>
        /// <param name="farmId">Farm Id</param>
        /// <param name="lastModifyBy">Last Modified by User Id</param>
        public void RestoreFarmPlot(int farmId, int lastModifyBy) 
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            dao.RestoreFarmPlot(farmId, lastModifyBy);
        }

        /// <summary>
        /// Delete Plot and its Contacts and if Farm is Empty it Deletes the Farm too.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <param name="lastModifyBy">Last Modify By User Id</param>
        public void DeletePlotContact(int plotId, int lastModifyBy)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            dao.DeletePlotContact(plotId, lastModifyBy);
        }

        /// <summary>
        /// Restore Plot and its Contacts.
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <param name="lastModifyBy">Last Modify By User Id</param>
        public void RestorePlotContact(int plotId, int lastModifyBy)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            dao.RestorePlotContact(plotId, lastModifyBy);
        }

        /// <summary>
        /// To Check weather a Given Plot is Delault Plot or Not
        /// </summary>
        /// <param name="plotId">Plot Id</param>
        /// <returns>Boolean True if it is a default Plot else False</returns>
        public bool IsDefaultPlot(int plotId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.IsDefaultPlot(plotId);
        }

        /// <summary>
        /// Total Count of Active Farms
        /// </summary>
        /// <returns>Count of Active Farms</returns>
        public int TotalActiveFarmCount()
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.TotalActiveFarmCount();
        }

        /// <summary>
        /// Total Count of Archived Farms
        /// </summary>
        /// <returns>Count of Archived Farms</returns>
        public int TotalArchivedFarmCount()
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.TotalArchivedFarmCount();
        }

        /// <summary>
        /// Total Count of Active Plots
        /// </summary>
        /// <returns>Count of Active Plots</returns>
        public int TotalActivePlotCount()
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.TotalActivePlotCount();
        }

        /// <summary>
        /// Total Count of Archived Plots
        /// </summary>
        /// <returns>Count of Archived Plots</returns>
        public int TotalArchivedPlotCount()
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.TotalArchivedPlotCount();
        }

        /// <summary>
        /// Total Count of Active Contact
        /// </summary>
        /// <returns>Count of Active Contacts</returns>
        public Int64 TotalActiveContactCount()
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.TotalActiveContactCount();
        }

        /// <summary>
        /// Total Count of Archived Contact
        /// </summary>
        /// <returns>Count of Archived Contacts</returns>
        public Int64 TotalArchivedContactCount()
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.TotalArchivedContactCount();
        }

        /// <summary>
        /// Datatable for Farm Plot Contact Report
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Model object of FarmDetailsReportInfo as Farm Plot Contact Report</returns>
        public List<FarmDetailsReportInfo> ReportForFarmDetails(int userId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            return dao.ReportForFarmDetails(userId);
        }

        /// <summary>
        /// Gets the List of contacts from the Search ceriteria 
        /// </summary>
        /// <param name="where">String where SQL WHERE clause is configured</param>
        /// <returns>Model object of FarmDetailsReportInfo</returns>
        public List<FarmDetailsReportInfo> GetSearchFarmData(string where)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.GetSearchFarmData(where);
        }

        /// <summary>
        /// Gets the mailing labels for the specified parameters.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="farmId">Internal identifier of the farm.</param>
        /// <param name="plotId">Internal identifier of the plot.</param>
        /// <returns>Mailing labels for the specified parameters.</returns>
        public List<MailingLabelInfo> GetMailingLabels(int userId, int farmId, int plotId)
        {
            // Get an instance of the Farm DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            List<MailingLabelInfo> mailingLabels =
                dao.GetMailingLabels(userId, farmId, plotId);

            return mailingLabels;
        }

        /// <summary>
        ///     Get the Summary List of Firmed Up Farms
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="FirmUpStatus">Firm Up Status</param>
        /// <returns>List of FirmUpStatusReportInfo Model Object </returns>
        public List<FirmUpStatusReportInfo> GetFirmUpStatusSummaryDetails(int userId, bool FirmUpStatus)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            return dao.GetFirmUpStatusSummaryDetails(userId, FirmUpStatus);
        }

        /// <summary>
        ///     Getting Farm Data Report Data which is Agent wise Farm Summary
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="where">SQL Where Condition</param>
        /// <returns>FarmDataReportInfo Model Object List</returns>
        public List<FarmDataReportInfo> GetFarmDataReportData(int userId, string where)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);

            return dao.GetFarmDataReportData(userId, where);
        }

        /// <summary>
        ///     Get the Consiquence of Deleting a Contact
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>Consiquence as string</returns>
        public string GetDeleteContactConsiquence(Int64 contactId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IFarm dao = (IFarm)DALFactory.DAO.Create(DALFactory.Module.Farm);
            return dao.GetDeleteContactConsiquence(contactId);
        }
    }
}

#region (C) Irmac USA Inc 2006
/***************************************************************** 

	* All rights are reserved. 
    * File				: Exception.cs
    * Created Date      : 30/Oct/2006
	* Last Modify Date  : 30/Oct/20056
	* Author			: Irmac Development Team 
	* Comment			: Represents the exception that is thrown when a duplicate database record is encountered during an insert or update operation.
	* Source			: MailingCycle\BLL\Exception.cs

	****************************************************************/
#endregion

#region NameSpaces
using System;
using System.Data;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;
using System.Collections.Generic;
#endregion

namespace Irmac.MailingCycle.BLL
{
	/// <summary>
	/// A Business Component used to manage Registrations.
	/// </summary>
	public class Registration
	{
        /// <summary>
        /// Inserts a registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        public int Insert(RegistrationInfo registration)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            try
            {
                int userId = dao.Insert(registration);
                return userId;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Inserts a registration account with user Work Space Area.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        /// <param name="workSpacePath">String Path in which Workspase Directory</param>
        public int InsertWithWorkSpaceDirectory(RegistrationInfo registration, string workSpacePath)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            try
            {
                int userId = dao.InsertWithWorkSpaceDirectory(registration, workSpacePath);
                return userId;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates a registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        public void Update(RegistrationInfo registration,int userLoginId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            try
            {
                dao.Update(registration, userLoginId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates secret details of the registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        public void UpdateSecretDetails(RegistrationInfo registration)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            try
            {
                dao.UpdateSecretDetails(registration);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates password details of the registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        public void UpdatePassword(RegistrationInfo registration)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            try
            {
                dao.UpdatePassword(registration);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Gets the list of Users
        /// </summary>
        /// <returns>List of registration objects</returns>
        public List<RegistrationInfo> GetUserList(UserRole userRole, string firstName, string lastName, string userName)
        {
            IRegistration registration = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);
            List<RegistrationInfo> userList = registration.GetUsers(userRole, firstName, lastName, userName);
            return userList;
        }

        
        /// <summary>
        /// Get the details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Details of the specified registration account.</returns>
        public RegistrationInfo GetDetails(int userId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            RegistrationInfo registration = dao.GetDetails(userId);

            return registration;
        }

        /// <summary>
        /// Get the details of the specified registration account.
        /// </summary>
        /// <param name="userName">user name of the user.</param>
        /// <returns>Details of the specified registration account.</returns>
        public RegistrationInfo GetDetails(string userName)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            RegistrationInfo registration = dao.GetDetails(userName);

            return registration;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the email exists.
        /// </summary>
        /// <param name="Email">Email</param>
        /// <returns>Returns a boolean value indicating whether the email exists</returns>
        public bool IsEmailExists(string email,int userId)
        {
            // Get an instance of the MailingCycle DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            bool isEmailExists = dao.IsEmailExists(email,userId);

            return isEmailExists;
        }


        /// <summary>
        /// Validate the user of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Validate user of the specified registration account.</returns>
        public bool ValidateUser(string userName,string password)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            bool loginStatus = dao.ValidateUser(userName, password);

            return loginStatus;
        }


        /// <summary>
        /// Updates the credit card details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="creditCard">Credit Card Information of the user.</param>
        public void UpdateCreditCard(int userId, CreditCardInfo creditCard)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            try
            {
                dao.UpdateCreditCard(userId, creditCard);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get the credit card details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Credit card details of the specified registration account.</returns>
        public CreditCardInfo GetCreditCard(int userId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            CreditCardInfo creditCard = dao.GetCreditCard(userId);

            return creditCard;
        }

        /// <summary>
        /// Updates the status of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="status">Status of the user.</param>
        public void UpdateStatus(int userId, RegistrationStatus status, int userLoginId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            try
            {
                dao.UpdateStatus(userId, status,userLoginId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the status of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Status of the specified registration account.</returns>
        public RegistrationStatus GetStatus(int userId)
        {
            // Get an instance of the Registration DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            RegistrationStatus status = dao.GetStatus(userId);

            return status;
        }

        /// <summary>
        /// deletes a user from the database
        /// </summary>
        /// <param name="userId">user id of the user to be deleted</param>
        /// <returns>bool value that represents success or failure</returns>
        public bool DeleteUser(int userId,int userLoginId)
        {
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);
            bool success = dao.DeleteUser(userId,userLoginId);
            return success;
        }

        /// <summary>
        /// Gets all the users who require approval
        /// </summary>
        /// <returns>List of Users</returns>
        public DataTable GetApprovalRequiredUsers()
        {
            // Get an instance of the Schedule DAO using the DALFactory
            IRegistration dao = (IRegistration)DALFactory.DAO.Create(DALFactory.Module.Registration);

            DataTable users = dao.GetApprovalRequiredUsers();

            return users;
        }


	}


}

using System;
using System.Data;
using Irmac.MailingCycle.Model;
using System.Collections.Generic;

namespace Irmac.MailingCycle.IDAL
{
	/// <summary>
	/// Inteface for the Registration DAL.
	/// </summary>
	public interface IRegistration
	{
        /// <summary>
        /// Inserts a registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        int Insert(RegistrationInfo registration);

        /// <summary>
        /// Inserts a registration account with user Work Space Area.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        /// <param name="workSpacePath">String Path in which Workspase Directory</param>
        int InsertWithWorkSpaceDirectory(RegistrationInfo registration, string workSpacePath);

        /// <summary>
        /// Updates a registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        void Update(RegistrationInfo registration,int userLoginId);


        /// <summary>
        /// Updates security details of the registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        void UpdateSecretDetails(RegistrationInfo registration);

        /// <summary>
        /// Updates password details of the registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        void UpdatePassword(RegistrationInfo registration);

        /// <summary>
        /// Gets the Users in the system
        /// </summary>
        /// <param name="userId">The user id of the logged in user</param>
        List<RegistrationInfo> GetUsers(UserRole userRole, string firstName, string lastName, string userName);


        DataTable GetApprovalRequiredUsers();
        /// <summary>
        /// Get the details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Details of the specified registration account.</returns>
        RegistrationInfo GetDetails(int userId);

        /// <summary>
        ///Check to see if the email address already exists
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>true/false</returns>
        bool IsEmailExists(string email,int userId);


        /// <summary>
        /// deletes the details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Deletes the details of the specified registration account.</returns>
        bool DeleteUser(int userId,int userLoginId);

        /// <summary>
        /// Get the details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Details of the specified registration account.</returns>
        RegistrationInfo GetDetails(string userName);

        /// <summary>
        /// Check for the valid user
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Login Details of the specified registration account.</returns>
        bool ValidateUser(string userName,string password);


        /// <summary>
        /// Updates the credit card details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="creditCard">Credit Card Information of the user.</param>
        void UpdateCreditCard(int userId, CreditCardInfo creditCard);

        /// <summary>
        /// Get the credit card details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Credit card details of the specified registration account.</returns>
        CreditCardInfo GetCreditCard(int userId);

        /// <summary>
        /// Updates the status of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="status">Status of the user.</param>
        void UpdateStatus(int userId, RegistrationStatus status,int userLoginId);

        /// <summary>
        /// Gets the status of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Status of the specified registration account.</returns>
        RegistrationStatus GetStatus(int userId);


	}
}

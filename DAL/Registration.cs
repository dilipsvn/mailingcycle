using System;
using System.Data;
using System.Data.SqlClient;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;
using System.Collections.Generic;

namespace Irmac.MailingCycle.DAL
{
	/// <summary>
	/// A Data Access Component used to manage Registrations.
	/// </summary>
	public class Registration : IRegistration
	{
        private const string MODULE_NAME = "Registration";
		
		public Registration()
		{
			//
		}

        /// <summary>
        /// Gets the database parameters for Registration.
        /// </summary>
        /// <returns>Parameter array.</returns>
        private static SqlParameter[] GetRegistrationParameters()
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_INSERT_ACCOUNT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserName", SqlDbType.NVarChar, 256),
                    new SqlParameter("@Password", SqlDbType.NVarChar, 128),
                    new SqlParameter("@Email", SqlDbType.NVarChar, 256),
                    new SqlParameter("@PasswordQuestion", SqlDbType.NVarChar,255),
                    new SqlParameter("@PasswordAnswer", SqlDbType.NVarChar, 256),
                    new SqlParameter("@FirstName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@MiddleName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@LastName", SqlDbType.NVarChar, 50),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar, 200),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@SignupDate", SqlDbType.DateTime),
                    new SqlParameter("@RoleId", SqlDbType.Int),
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_INSERT_ACCOUNT", parameters);
            }

            return parameters;
        }


        /// <summary>
        /// Gets the database parameters for Registration address.
        /// </summary>
        /// <returns>Parameter array.</returns>
        private static SqlParameter[] GetRegistrationAddressParameters()
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_INSERT_ACCOUNT_SHIPPINGADDRESS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int),
					new SqlParameter("@Address1", SqlDbType.NVarChar, 255),
					new SqlParameter("@Address2", SqlDbType.NVarChar, 255),
					new SqlParameter("@City", SqlDbType.NVarChar, 100),
					new SqlParameter("@StateId", SqlDbType.Int),
					new SqlParameter("@Zip", SqlDbType.NVarChar, 15),
					new SqlParameter("@CountryId", SqlDbType.Int),
					new SqlParameter("@Phone", SqlDbType.NVarChar, 20),
					new SqlParameter("@Fax", SqlDbType.NVarChar, 20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar, 20),
                };

                SQLHelper.CacheParameters("SQL_INSERT_ACCOUNT_SHIPPINGADDRESS", parameters);
            }

            return parameters;
        }

        
        /// <summary>
        /// Binds values to parameters.
        /// </summary>
        /// <param name="parameters">Database parameters.</param>
        /// <param name="registration">Values to bind to registration parameters.</param>
        private void SetRegistrationParameters(SqlParameter[] parameters, RegistrationInfo registration)
        {
            parameters[0].Value = registration.UserName;
            parameters[1].Value = registration.Password;
            parameters[2].Value = registration.Email;
            parameters[3].Value = registration.PasswordQuestion;
            parameters[4].Value = registration.PasswordAnswer;
            parameters[5].Value = registration.FirstName;
            parameters[6].Value = registration.MiddleName;
            parameters[7].Value = registration.LastName;
            parameters[8].Value = registration.CompanyName;
            parameters[9].Value = registration.Status;
            parameters[10].Value = DateTime.Now;
            parameters[11].Value = registration.Role;
            parameters[12].Direction = ParameterDirection.Output;
        }


        /// <summary>
        /// Binds values to parameters.
        /// </summary>
        /// <param name="parameters">Database parameters.</param>
        /// <param name="registration">Values to bind to registration address parameters.</param>
        private void SetRegistrationAddressParameters(int userId,SqlParameter[] parameters, RegistrationInfo registration)
        {

            parameters[0].Value = userId;
            parameters[1].Value = registration.Address.Address1;
            parameters[2].Value = registration.Address.Address2;
            parameters[3].Value = registration.Address.City;
            parameters[4].Value = registration.Address.State.StateId;
            parameters[5].Value = registration.Address.Zip;
            parameters[6].Value = registration.Address.Country.CountryId;
            parameters[7].Value = registration.Address.Phone;
            parameters[8].Value = registration.Address.Fax;
            parameters[9].Value = registration.Address.Mobile;
        }


        /// <summary>
        /// Updates the credit card details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="creditCard">Credit card details of the user.</param>
        /// <param name="transaction">Transaction under which the updation should occur.</param>
        internal void UpdateCreditCard(int userId, ref CreditCardInfo creditCard,
            SqlTransaction transaction)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_UPDATE_CREDIT_CARD");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int),
                    new SqlParameter("@CreditCardTypeId", SqlDbType.Int),
                    new SqlParameter("@CreditCardNo", SqlDbType.NVarChar, 20),
                    new SqlParameter("@CVVNo", SqlDbType.NVarChar, 4),
                    new SqlParameter("@HolderName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@ExpirationMonth", SqlDbType.Int),
					new SqlParameter("@ExpirationYear", SqlDbType.Int),
					new SqlParameter("@BillingAddress1", SqlDbType.NVarChar, 255),
					new SqlParameter("@BillingAddress2", SqlDbType.NVarChar, 255),
					new SqlParameter("@BillingCity", SqlDbType.NVarChar, 100),
					new SqlParameter("@BillingStateId", SqlDbType.Int),
					new SqlParameter("@BillingZip", SqlDbType.NVarChar, 15),
					new SqlParameter("@BillingCountryId", SqlDbType.Int)	
                };  

                SQLHelper.CacheParameters("SP_UPDATE_CREDIT_CARD", parameters);
            }

            parameters[0].Value = userId;
            parameters[1].Value = creditCard.Type.LookupId;
            parameters[2].Value = creditCard.Number;
            parameters[3].Value = creditCard.CvvNumber;
            parameters[4].Value = creditCard.HolderName;
            parameters[5].Value = creditCard.ExpirationMonth;
            parameters[6].Value = creditCard.ExpirationYear;
            parameters[7].Value = creditCard.Address.Address1;
            parameters[8].Value = creditCard.Address.Address2;
            parameters[9].Value = creditCard.Address.City;
            parameters[10].Value = creditCard.Address.State.StateId;
            parameters[11].Value = creditCard.Address.Zip;
            parameters[12].Value = creditCard.Address.Country.CountryId;

            SQLHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SP_UPDATE_CREDIT_CARD"),
                parameters);

        }

        /// <summary>
        /// Updates the status of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="status">Status of the user.</param>
        /// <param name="transaction">Transaction under which the updation should occur.</param>
        internal void UpdateStatus(int userId, RegistrationStatus status,
            SqlTransaction transaction)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_UPDATE_STATUS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int),
                    new SqlParameter("@Status", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_UPDATE_STATUS", parameters);
            }

            parameters[0].Value = userId;
            parameters[1].Value = status;

            SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_STATUS"),
                parameters);
        }

        /// <summary>
        /// Inserts a registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        public int Insert(RegistrationInfo registration)
        {

            int UserId=0;
            SqlParameter[] registrationparameters = GetRegistrationParameters();

            SqlParameter[] registrationAddressParameters;

            SetRegistrationParameters(registrationparameters, registration);

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {

                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                        SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_ACCOUNT"),
                        registrationparameters);

                        UserId = (int)registrationparameters[12].Value;
                        
                        registrationAddressParameters = GetRegistrationAddressParameters();
                        SetRegistrationAddressParameters(UserId,registrationAddressParameters, registration);
            
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_ACCOUNT_SHIPPINGADDRESS"),
                            registrationAddressParameters);

                        if (registration.CreditCard != null)
                        {
                            CreditCardInfo creditCard = registration.CreditCard;

                            UpdateCreditCard(UserId, ref creditCard,
                                transaction);
                        }

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.Registration, registration.UserName, "User Registered", UserId, UserId);
                        AuditTrail.WriteEntry(auditEntry, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
            return UserId;
        }


        /// <summary>
        /// Inserts a registration account with user Work Space Area.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        /// <param name="workSpacePath">String Path in which Workspase Directory</param>
        public int InsertWithWorkSpaceDirectory(RegistrationInfo registration,string workSpacePath)
        {

            int UserId = 0;
            SqlParameter[] registrationparameters = GetRegistrationParameters();

            SqlParameter[] registrationAddressParameters;

            SetRegistrationParameters(registrationparameters, registration);

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {

                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                        SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_ACCOUNT"),
                        registrationparameters);

                        UserId = (int)registrationparameters[12].Value;

                        registrationAddressParameters = GetRegistrationAddressParameters();
                        SetRegistrationAddressParameters(UserId, registrationAddressParameters, registration);

                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_ACCOUNT_SHIPPINGADDRESS"),
                            registrationAddressParameters);

                        if (registration.CreditCard != null)
                        {
                            CreditCardInfo creditCard = registration.CreditCard;

                            UpdateCreditCard(UserId, ref creditCard,
                                transaction);
                        }
                        
                        workSpacePath += UserId.ToString();
                        System.IO.Directory.CreateDirectory(workSpacePath);

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.Registration, registration.UserName, "User Registered", UserId, UserId);
                        AuditTrail.WriteEntry(auditEntry, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
            return UserId;
        }


        /// <summary>
        /// Updates a registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        public void Update(RegistrationInfo registration,int userLoginId)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SP_UPDATE_ACCOUNT");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int),
                    new SqlParameter("@FirstName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@MiddleName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@LastName", SqlDbType.NVarChar, 50),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar, 200),
					new SqlParameter("@Address1", SqlDbType.NVarChar, 255),
					new SqlParameter("@Address2", SqlDbType.NVarChar, 255),
					new SqlParameter("@City", SqlDbType.NVarChar, 100),
					new SqlParameter("@StateId", SqlDbType.Int),
					new SqlParameter("@Zip", SqlDbType.NVarChar, 15),
					new SqlParameter("@CountryId", SqlDbType.Int),
					new SqlParameter("@Phone", SqlDbType.NVarChar, 20),
					new SqlParameter("@Fax", SqlDbType.NVarChar, 20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar, 20),
                    new SqlParameter("@Email", SqlDbType.NVarChar, 256),
					new SqlParameter("@Role", SqlDbType.Int),
					new SqlParameter("@Status", SqlDbType.Int)
                };

            }
            SQLHelper.CacheParameters("SP_UPDATE_ACCOUNT", parameters);

            parameters[0].Value = registration.UserId;
            parameters[1].Value = registration.FirstName;
            parameters[2].Value = registration.MiddleName;
            parameters[3].Value = registration.LastName;
            parameters[4].Value = registration.CompanyName;
            parameters[5].Value = registration.Address.Address1;
            parameters[6].Value = registration.Address.Address2;
            parameters[7].Value = registration.Address.City;
            parameters[8].Value = registration.Address.State.StateId;
            parameters[9].Value = registration.Address.Zip;
            parameters[10].Value = registration.Address.Country.CountryId;
            parameters[11].Value = registration.Address.Phone;
            parameters[12].Value = registration.Address.Fax;
            parameters[13].Value = registration.Address.Mobile;
            parameters[14].Value = registration.Email;
            parameters[15].Value = registration.Role;
            parameters[16].Value = registration.Status;


            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SP_UPDATE_ACCOUNT"),
                            parameters);

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.UpdateProfile, registration.UserName, "Updated Profile", registration.UserId , userLoginId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch(SqlException ex)
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// Updates security details of the registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        public void UpdateSecretDetails(RegistrationInfo registration)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_UPDATE_SECURITYQUESTION");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@passwordQuestion", SqlDbType.NVarChar,255),
                    new SqlParameter("@passwordAnswer", SqlDbType.NVarChar,256),
                    new SqlParameter("@UserId", SqlDbType.Int)
                };
            }
            parameters[0].Value = registration.PasswordQuestion;
            parameters[1].Value = registration.PasswordAnswer;
            parameters[2].Value = registration.UserId;

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_SECURITYQUESTION"),
                            parameters);

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.ChangeSecretQuestion, registration.UserName, "Updated Security Details", registration.UserId, registration.UserId);
                        AuditTrail.WriteEntry(auditEntry, transaction);
                        
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// Updates password details of the registration account.
        /// </summary>
        /// <param name="registration">Registration Information of the user.</param>
        public void UpdatePassword(RegistrationInfo registration)
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_UPDATE_PASSWORD");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@password", SqlDbType.NVarChar,256),
                    new SqlParameter("@UserId", SqlDbType.Int)
                };
            }
            parameters[0].Value = registration.Password;
            parameters[1].Value = registration.UserId;

            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_UPDATE_PASSWORD"),
                            parameters);

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.ChangePassword, registration.UserName, "Updated Password", registration.UserId, registration.UserId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }


        public List<RegistrationInfo> GetUsers(UserRole userRole,string firstName,string lastName,string userName)
        {
            List<RegistrationInfo> userList = new List<RegistrationInfo>();
            
            RegistrationInfo userInfo;

            string sql = SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_USERS");
            if (userRole != UserRole.NullValue)
                sql += " AND U.role_id = " + (int)userRole;
            if (firstName  != "")
                sql += " AND U.first_name like '%" + firstName + "%'";
            if (lastName != "")
                sql += " AND U.last_name like '%" + lastName + "%'";
            if (userName != "")
                sql += " AND U.user_name like '%" + userName + "%'";


            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, sql,
                null))
            {
                while (reader.Read())
                {
                    
                    userInfo = new RegistrationInfo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetString(8),
                        reader.GetString(9), new AddressInfo(
                            reader.GetString(10), reader.GetString(11), reader.GetString(12),
                            new CountryInfo(reader.GetInt32(13), reader.GetString(14), false),
                            new StateInfo(reader.GetInt32(15), reader.GetString(16)),
                            reader.GetString(17), reader.GetString(18), reader.GetString(19),
                            reader.GetString(20)),
                        null, (RegistrationStatus)reader.GetInt32(21), reader.GetDateTime(22), (UserRole)reader.GetInt32(23));
                    userList.Add(userInfo);
                }
            }
            return userList;
        }


        /// <summary>
        /// Get the details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Details of the specified registration account.</returns>
        public RegistrationInfo GetDetails(int userId)
        {
            RegistrationInfo registration = null;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_ACCOUNT_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_ACCOUNT_DETAILS", parameters);
            }

            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_ACCOUNT_DETAILS"),
                parameters))
            {
                if (reader.Read())
                {

                    registration = new RegistrationInfo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetString(8),
                        reader.GetString(9), new AddressInfo(
                            reader.GetString(10), reader.GetString(11), reader.GetString(12),
                            new CountryInfo(reader.GetInt32(13), reader.GetString(14), false),
                            new StateInfo(reader.GetInt32(15), reader.GetString(16)),
                            reader.GetString(17), reader.GetString(18), reader.GetString(20),
                            reader.GetString(19)),
                        null, (RegistrationStatus)reader.GetInt32(21), reader.GetDateTime(22), (UserRole)reader.GetInt32(23));
                }
            }

            return registration;
        }


        /// <summary>
        /// Get the details of the specified registration account.
        /// </summary>
        /// <param name="userName">User name of the user.</param>
        /// <returns>Details of the specified registration account.</returns>
        public RegistrationInfo GetDetails(string userName)
        {
            RegistrationInfo registration = null;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_ACCOUNTNAME_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,256)
                };

                SQLHelper.CacheParameters("SQL_GET_ACCOUNTNAME_DETAILS", parameters);
            }

            parameters[0].Value = userName;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_ACCOUNTNAME_DETAILS"),
                parameters))
            {
                if (reader.Read())
                {
                    registration = new RegistrationInfo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetString(8),
                        reader.GetString(9), new AddressInfo(
                            reader.GetString(10), reader.GetString(11), reader.GetString(12),
                            new CountryInfo(reader.GetInt32(13), reader.GetString(14), false),
                            new StateInfo(reader.GetInt32(15), reader.GetString(16)),
                            reader.GetString(17), reader.GetString(18), reader.GetString(19),
                            reader.GetString(20)),
                        null, (RegistrationStatus)reader.GetInt32(21), reader.GetDateTime(22), (UserRole)reader.GetInt32(23));
                }
            }

            return registration;
        }


        /// <summary>
        /// Updates the credit card details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="creditCard">Credit Card Information of the user.</param>
        public void UpdateCreditCard(int userId, CreditCardInfo creditCard)
        {
            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        UpdateCreditCard(userId, ref creditCard, transaction);

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.UpdateCreditCard, creditCard.Number, "Updated Credit Card",userId,userId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Get the credit card details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Credit card details of the specified registration account.</returns>
        public CreditCardInfo GetCreditCard(int userId)
        {
            CreditCardInfo creditCard = null;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_CREDIT_CARD");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_CREDIT_CARD", parameters);
            }

            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_CREDIT_CARD"),
                parameters))
            {
                if (reader.Read())
                {
                    creditCard = new CreditCardInfo(new LookupInfo(reader.GetInt32(0), reader.GetString(1)),
                        reader.GetString(2), reader.GetString(3), reader.GetString(4),
                        reader.GetInt32(5), reader.GetInt32(6), new AddressInfo(
                            reader.GetString(7), reader.GetString(8), reader.GetString(9),
                            new CountryInfo(reader.GetInt32(10), reader.GetString(11), false),
                            new StateInfo(reader.GetInt32(12), reader.GetString(13)),
                            reader.GetString(14), "", "", ""));
                }
            }

            return creditCard;
        }

        /// <summary>
        /// Updates the status of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="status">Status of the user.</param>
        public void UpdateStatus(int userId, RegistrationStatus status,int userLoginId)
        {
            string statusText="";
            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        UpdateStatus(userId, status, transaction);

                        if(status==RegistrationStatus.Active)
                            statusText = "User Activated or Approved";
                        else
                            if(status==RegistrationStatus.Inactive)
                                statusText = "User Inactivated";

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.UserManagement, userId.ToString(), statusText, userId, userLoginId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the status of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Status of the specified registration account.</returns>
        public RegistrationStatus GetStatus(int userId)
        {
            RegistrationStatus status = RegistrationStatus.Inactive;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_USER_STATUS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_USER_STATUS", parameters);
            }

            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_STATUS"),
                parameters))
            {
                if (reader.Read())
                {
                    status = (RegistrationStatus)reader.GetInt32(0);
                }
            }

            return status;
        }

        /// <summary>
        /// Gets the login details of the specified registration account.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Validate user details of the specified registration account.</returns>
        public bool ValidateUser(string userName, string password)
        {

            bool loginStatus = false;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_VALIDATE_USER");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,256),
                    new SqlParameter("@Password", SqlDbType.NVarChar,128)
                };


                SQLHelper.CacheParameters("SQL_VALIDATE_USER", parameters);
            }

            parameters[0].Value = userName;
            parameters[1].Value = password;


            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_VALIDATE_USER"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) != 0)
                        loginStatus = true;
                }
            }

            return loginStatus;
        }

        public bool DeleteUser(int userId,int userLoginId)
        {
            bool success = false;
            SqlParameter[] userParamater = new SqlParameter[] { new SqlParameter("@user_id", DbType.Int32) };
            userParamater[0].Value = userId;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {

                        int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SP_DELETE_USER"), userParamater);
                        success = (noOfRecords > 0);


                        sqlTran.Commit();
                    }
                    catch(Exception ex)
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Gets a value indicating whether the specified Email already exists
        /// </summary>
        /// <param name="Email">Email Id</param>
        /// <returns>true if the specified Email exists
        /// otherwise, false.</returns>
        public bool IsEmailExists(string email,int userId)
        {
            bool isEmailExists = false;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_IS_EMAIL_EXISTS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@email", SqlDbType.NVarChar,256),
                    new SqlParameter("@UserId", SqlDbType.Int)

                };

                SQLHelper.CacheParameters("SQL_IS_EMAIL_EXISTS", parameters);
            }

            parameters[0].Value = email;
            parameters[1].Value = userId;


            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_IS_EMAIL_EXISTS"),
                parameters))
            {
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                        isEmailExists = true;
                }
            }

            return isEmailExists;
        }

        /// <summary>
        /// Gets All Users who require approval
        /// </summary>
        /// <returns>List of Users</returns>
        public DataTable GetApprovalRequiredUsers()
        {
            DataTable users = new DataTable("Approval_Users");

            // Execute the query to read the schedule summary.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_APPROVALREQUIRED_USERS"),
                null))
            {
                if (reader != null)
                {
                    users.Load(reader);
                }
            }

            return users;
        }

	}


}

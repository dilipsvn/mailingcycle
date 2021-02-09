using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.DAL
{
    /// <summary>
    /// A Data Access Component used to manage Common Utilities.
    /// </summary>
    public class Common : ICommon
    {
        private const string MODULE_NAME = "Common";

        public Common()
		{
			//
		}

        /// <summary>
        /// Gets the list of countries.
        /// </summary>
        /// <returns>List of countries.</returns>
        public List<CountryInfo> GetCountries()
        {
            List<CountryInfo> countries = new List<CountryInfo>();

            // Execute a query to read the countries.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_COUNTRIES"), 
                null))
            {
                while (reader.Read())
                {
                    CountryInfo country = new CountryInfo(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2));

                    countries.Add(country);
                }
            }

            return countries;
        }

        /// <summary>
        /// Gets the list of states for the specified country.
        /// </summary>
        /// <param name="countryId">The identifier of the country of the states to get.</param>
        /// <returns>List of states for the specified country.</returns>
        public List<StateInfo> GetStates(int countryId)
        {
            List<StateInfo> states = new List<StateInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_STATES");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@CountryId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_STATES", parameters);
            }

            parameters[0].Value = countryId;

            // Execute a query to read the states.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_STATES"),
                parameters))
            {
                while (reader.Read())
                {
                    StateInfo state = new StateInfo(reader.GetInt32(0), reader.GetString(1));

                    states.Add(state);
                }
            }

            return states;
        }

        /// <summary>
        /// Gets the lookup values for the specified category.
        /// </summary>
        /// <param name="category">The category of the lookup to get.</param>
        /// <returns>List of lookup values for the specified category.</returns>
        public List<LookupInfo> GetLookups(string category)
        {
            List<LookupInfo> lookups = new List<LookupInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_LOOKUP_VALUES");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@Category", SqlDbType.NVarChar, 250)
                };

                SQLHelper.CacheParameters("SQL_GET_LOOKUP_VALUES", parameters);
            }

            parameters[0].Value = category;

            // Execute a query to read the lookup values.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_LOOKUP_VALUES"),
                parameters))
            {
                while (reader.Read())
                {
                    LookupInfo lookup = new LookupInfo(reader.GetInt32(0), reader.GetString(1));

                    lookups.Add(lookup);
                }
            }

            return lookups;
        }

        /// <summary>
        /// Gets the lookup 
        /// </summary>
        /// <param name="LookupId">The LookupId</param>
        /// <returns>Lookup Name</returns>
        public LookupInfo GetLookupDetails(int lookupId)
        {
            LookupInfo lookupdetails = new LookupInfo();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_LOOKUPDETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@LookupId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_LOOKUPDETAILS", parameters);
            }

            parameters[0].Value = lookupId;

            // Execute a query to read the lookup values.
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_LOOKUPDETAILS"),
                parameters))
            {
                while (reader.Read())
                {
                    lookupdetails = new LookupInfo(reader.GetInt32(0), reader.GetString(1));

                }
            }

            return lookupdetails;
        }

        
        /// <summary>
        /// Searches for the application property with the specified name.
        /// </summary>
        /// <param name="name">The System.String containing the name of the property to get.</param>
        /// <returns>An Irmac.MailingCycle.Model.PropertyInfo object representing the 
        /// application property with the specified name, if found; otherwise, null.</returns>
        public PropertyInfo GetProperty(string name)
        {
            PropertyInfo property = null;

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_PROPERTY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@PropertyName", SqlDbType.NVarChar, 50)
                };

                SQLHelper.CacheParameters("SQL_GET_PROPERTY", parameters);
            }

            parameters[0].Value = name;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_PROPERTY"),
                parameters))
            {
                if (reader.Read())
                {
                    property = new PropertyInfo(reader.GetString(0), reader.GetString(1));
                }
            }

            return property;
        }

        private static SqlParameter[] GetPropertyParams()
        {
            SqlParameter[] propertyParams = SQLHelper.GetCachedParameters("SP_INSERTUPDATE_PROPERTY");
            if (propertyParams == null)
            {
                propertyParams = new SqlParameter[]{
                    new SqlParameter("@property_name",SqlDbType.Text),
                    new SqlParameter("@property_values",SqlDbType.Text)};
                SQLHelper.CacheParameters("SP_INSERTUPDATE_PROPERTY", propertyParams);
            }
            return propertyParams;
        }


        public bool InsertProperty(string name,string value)
        {
            bool success = false;
            SqlParameter[] PropertyParameters = GetPropertyParams();
            PropertyParameters[0].Value = name;
            PropertyParameters[1].Value = value;

            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SP_INSERTUPDATE_PROPERTY"), PropertyParameters);

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



        #region ICommon Members


        public List<RegistrationInfo> GetAgentList()
        {
            List<RegistrationInfo> regAgentsInfo = new List<RegistrationInfo>();
            RegistrationInfo regInfo;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_GETAGENTS"),null))
            {
                while (reader.Read())
                {
                    regInfo = new RegistrationInfo();
                    regInfo.UserId = (int)reader["user_id"];
                    regInfo.UserName = (string)reader["user_name"];
                    regInfo.Role = (UserRole)reader["role_id"];
                    regAgentsInfo.Add(regInfo);
                }
            }
            return regAgentsInfo;
        }

        /// <summary>
        /// Get the users of the specified roles.
        /// </summary>
        /// <param name="roles">Comma-delimited string containg the roles.</param>
        /// <returns>Users of the specified roles.</returns>
        public List<RegistrationInfo> GetUsersByRole(string roles)
        {
            List<RegistrationInfo> users = new List<RegistrationInfo>();

            SqlParameter[] parameters = 
                SQLHelper.GetCachedParameters("SQL_GET_USERS_BY_ROLE");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@roles", SqlDbType.NVarChar, 4000)
                };

                SQLHelper.CacheParameters("SQL_GET_USERS_BY_ROLE", parameters);
            }

            parameters[0].Value = roles;

            // Execute the query to read the users.
            using (SqlDataReader reader =
                SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text,
                SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_USERS_BY_ROLE"),
                parameters))
            {
                while (reader.Read())
                {
                    RegistrationInfo user = new RegistrationInfo(reader.GetInt32(0),
                        reader.GetString(1), string.Empty, reader.GetString(2), 
                        string.Empty, string.Empty, reader.GetString(3), string.Empty,
                        reader.GetString(4), string.Empty, null, null, 
                        RegistrationStatus.Active, new DateTime(), 
                        (UserRole)reader.GetInt32(5));

                    users.Add(user);
                }
            }

            return users;
        }

        #endregion
    }
}

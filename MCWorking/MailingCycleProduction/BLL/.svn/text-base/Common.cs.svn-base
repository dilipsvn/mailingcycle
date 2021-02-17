using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.BLL
{
    /// <summary>
    /// A Business Component used to manage Common Utilities.
    /// </summary>
    public class Common
    {
        /// <summary>
        /// Gets the list of countries.
        /// </summary>
        /// <returns>List of countries.</returns>
        public List<CountryInfo> GetCountries()
        {
            // Get an instance of the Common DAO using the DALFactory
            ICommon dao = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);

            List<CountryInfo> countries = dao.GetCountries();

            return countries;
        }

        /// <summary>
        /// Gets the list of states for the specified country.
        /// </summary>
        /// <param name="countryId">The identifier of the country of the states to get.</param>
        /// <returns>List of states for the specified country.</returns>
        public List<StateInfo> GetStates(int countryId)
        {
            // Get an instance of the Common DAO using the DALFactory
            ICommon dao = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);

            List<StateInfo> states = new List<StateInfo>();

            states.Add(new StateInfo(0, "<Select a State>"));
            states.AddRange(dao.GetStates(countryId));

            return states;
        }

        /// <summary>
        /// Gets the lookup values for the specified category.
        /// </summary>
        /// <param name="category">The category of the lookup to get.</param>
        /// <returns>List of lookup values for the specified category.</returns>
        public List<LookupInfo> GetLookups(string category)
        {
            // Get an instance of the Common DAO using the DALFactory
            ICommon dao = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);

            List<LookupInfo> lookups = new List<LookupInfo>();

            lookups.Add(new LookupInfo(0, "<Select a " + category + ">"));
            lookups.AddRange(dao.GetLookups(category));

            return lookups;
        }

        /// <summary>
        /// Gets the lookup details
        /// </summary>
        /// <param name="LookUpId">LookupId</param>
        /// <returns>Lookup Details</returns>
        public LookupInfo GetLookupDetails(int lookupId)
        {
            // Get an instance of the Common DAO using the DALFactory
            ICommon dao = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);

            LookupInfo lookupdetails = new LookupInfo();

            lookupdetails = dao.GetLookupDetails(lookupId);

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
            // Get an instance of the Common DAO using the DALFactory
            ICommon dao = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);

            PropertyInfo property = dao.GetProperty(name);

            return property;
        }

        /// <summary>
        /// Gets the list of agents
        /// </summary>
        /// <returns></returns>
        public List<RegistrationInfo> GetAgentList()
        {
            ICommon dao = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);
            return dao.GetAgentList();
        }

        /// <summary>
        /// Get the users of the specified roles.
        /// </summary>
        /// <param name="roles">Comma-delimited string containg the roles.</param>
        /// <returns>Users of the specified roles.</returns>
        public List<RegistrationInfo> GetUsersByRole(string roles)
        {
            // Get an instance of the Common DAO using the DALFactory
            ICommon dao = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);

            List<RegistrationInfo> users = dao.GetUsersByRole(roles);

            return users;
        }

        /// <summary>
        /// Inserts the property value
        /// </summary>
        /// <returns></returns>
        public bool InsertProperty(string name,string value)
        {
            ICommon dao = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);
            return dao.InsertProperty(name,value);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.Model;

namespace Irmac.MailingCycle.IDAL
{
    /// <summary>
    /// Inteface for the Common DAL.
    /// </summary>
    public interface ICommon
    {
        /// <summary>
        /// Gets the list of countries.
        /// </summary>
        /// <returns>List of countries.</returns>
        List<CountryInfo> GetCountries();

        /// <summary>
        /// Gets the list of states for the specified country.
        /// </summary>
        /// <param name="countryId">The identifier of the country of the states to get.</param>
        /// <returns>List of states for the specified country.</returns>
        List<StateInfo> GetStates(int countryId);

        /// <summary>
        /// Gets the lookup values for the specified category.
        /// </summary>
        /// <param name="category">The category of the lookup to get.</param>
        /// <returns>List of lookup values for the specified category.</returns>
        List<LookupInfo> GetLookups(string category);


        /// <summary>
        /// Gets the lookup name 
        /// </summary>
        /// <param name="LookupId">The LookupId</param>
        /// <returns>Lookup Name</returns>
        LookupInfo GetLookupDetails(int lookupId);


        /// <summary>
        /// Searches for the application property with the specified name.
        /// </summary>
        /// <param name="name">The System.String containing the name of the property to get.</param>
        /// <returns>An Irmac.MailingCycle.Model.PropertyInfo object representing the 
        /// application property with the specified name, if found; otherwise, null.</returns>
        PropertyInfo GetProperty(string name);

        /// <summary>
        /// Inserts the value into property table
        /// </summary>
        /// <param name="name">The System.String containing the name of the property to set.</param>
        /// <returns>An Irmac.MailingCycle.Model.PropertyInfo object representing the 
        /// application property with the specified name, if found; otherwise, null.</returns>
        bool InsertProperty(string name,string value);

        /// <summary>
        /// Inserts the value into property table
        /// </summary>
        /// <param name="name">The System.String containing the name of the property to set.</param>
        /// <returns>An Irmac.MailingCycle.Model.PropertyInfo object representing the 
        /// application property with the specified name, if found; otherwise, null.</returns>
        //PropertyInfo UpdateProperty(string name,string value);


        /// <summary>
        /// Returns the list of agents available
        /// </summary>
        /// <returns>The list containing the Irmac.MailingCycle.Model.RegistrationInfo objects that 
        /// contain the agent's information</returns>
        List<RegistrationInfo> GetAgentList();

        /// <summary>
        /// Get the users of the specified roles.
        /// </summary>
        /// <param name="roles">Comma-delimited string containg the roles.</param>
        /// <returns>Users of the specified roles.</returns>
        List<RegistrationInfo> GetUsersByRole(string roles);
    }
}

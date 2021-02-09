using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model Countries.
    /// </summary>
    [Serializable]
    public class CountryInfo : BaseInfo
    {
        private int countryId;
        private string name;
        private bool isDefault;

        /// <summary>
		/// Default constructor.
		/// </summary>
        public CountryInfo()
		{
			//
		}

        /// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
        /// <param name="countryId">Identifier of the country</param>
        /// <param name="name">Name of the country</param>
        /// <param name="isDefault">Wheather the country is a default one or not</param>
        public CountryInfo(int countryId, string name, bool isDefault)
		{
			this.countryId = countryId;
			this.name = name;
            this.isDefault = isDefault;
		}

        public int CountryId
        {
            get
            {
                return countryId;
            }
            set
            {
                countryId = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public bool IsDefault
        {
            get
            {
                return isDefault;
            }
            set
            {
                isDefault = value;
            }
        }
    }
}

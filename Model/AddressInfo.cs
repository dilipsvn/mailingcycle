using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
	/// <summary>
	/// Business Entity used to model Addresses.
	/// </summary>
	[Serializable]
	public class AddressInfo : BaseInfo
	{
		private string address1;
		private string address2;
		private string city;
        private CountryInfo country;
		private StateInfo state;
		private string zip;
		private string phone;
		private string mobile;
        private string fax;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AddressInfo()
		{
			//
		}

		/// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
		/// <param name="address1">Line #1 of the address</param>
		/// <param name="address2">Line #2 of the address</param>
		/// <param name="city">City of the address</param>
        /// <param name="country">Country of the address</param>
		/// <param name="state">State of the address</param>
		/// <param name="zip">Postal Code of the address</param>
		/// <param name="phone">Phone at the address</param>
		/// <param name="mobile">Mobile Phone at the address</param>
        /// <param name="fax">Fax at the address</param>
		public AddressInfo(string address1, string address2, string city, 
            CountryInfo country, StateInfo state, string zip, string phone, 
            string mobile, string fax)
		{
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
            this.country = country;
			this.state = state;
			this.zip = zip;
			this.phone = phone;
            this.mobile = mobile;
            this.fax = fax;
		}
		
        public string Address1
		{
			get
			{
				return address1;
			}
			set
			{
				address1 = value;
			}
		}

		public string Address2
		{
			get
			{
				return address2;
			}
			set
			{
				address2 = value;
			}
		}

		public string City
		{
			get
			{
				return city;
			}
			set
			{
				city = value;
			}
		}

        public CountryInfo Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

		public StateInfo State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
			}
		}

		public string Zip
		{
			get
			{
				return zip;
			}
			set
			{
				zip = value;
			}
		}

		public string Phone
		{
			get
			{
                return phone;
			}
			set
			{
				phone = value;
			}
		}

        public string Mobile
		{
			get
			{
                return mobile;
			}
			set
			{
                mobile = value;
			}
		}

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
	}
}

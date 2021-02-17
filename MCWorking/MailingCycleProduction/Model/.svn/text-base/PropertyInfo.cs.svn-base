using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model Properties.
    /// </summary>
    [Serializable]
    public class PropertyInfo : BaseInfo
    {
        private string name;
        private object _value;

        /// <summary>
		/// Default constructor.
		/// </summary>
        public PropertyInfo()
		{
			//
		}

        /// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
        /// <param name="name">Name of the Property</param>
        /// <param name="value">Value of the Property</param>
        public PropertyInfo(string name, object value)
		{
            this.name = name;
            this._value = value;
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

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}

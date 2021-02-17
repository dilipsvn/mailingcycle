using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model Lookup.
    /// </summary>
    [Serializable]
    public class LookupInfo : BaseInfo
    {
        private int lookupId;
        private string name;

        /// <summary>
		/// Default constructor.
		/// </summary>
        public LookupInfo()
		{
			//
		}

        /// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
        /// <param name="lookupId">Identifier of the lookup value</param>
        /// <param name="name">Name of the lookup value</param>
		public LookupInfo(int lookupId, string name)
		{
			this.lookupId = lookupId;
			this.name = name;
		}

        public int LookupId
        {
            get
            {
                return lookupId;
            }
            set
            {
                lookupId = value;
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
    }
}

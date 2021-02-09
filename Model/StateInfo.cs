using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model States.
    /// </summary>
    [Serializable]
    public class StateInfo : BaseInfo
    {
        private int stateId;
        private string name;

        /// <summary>
		/// Default constructor.
		/// </summary>
        public StateInfo()
		{
			//
		}

        /// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
        /// <param name="stateId">Identifier of the state</param>
        /// <param name="name">Name of the state</param>
        public StateInfo(int stateId, string name)
		{
            this.stateId = stateId;
			this.name = name;
		}

        public int StateId
        {
            get
            {
                return stateId;
            }
            set
            {
                stateId = value;
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

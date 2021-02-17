#region (C) Irmac USA Inc 2006
/***************************************************************** 

	* All rights are reserved. 
    * File				: CreditCardInfo.cs
    * Created Date      : 03/Nov/2006
	* Last Modify Date  : 03/Nov/20056
	* Author			: Irmac Development Team 
	* Comment			: Class for the Credit card Information
	* Source			: MailingCycle\Model\CreditCardInfo.cs

	****************************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    /// <summary>
    /// Business Entity used to model Credit Cards.
    /// </summary>
    [Serializable]
    public class CreditCardInfo: BaseInfo 
    {
        private LookupInfo type;
        private string number;
        private string cvvNumber;
        private string holderName;
        private int expirationMonth;
        private int expirationYear;
        private AddressInfo address;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CreditCardInfo()
        {
            //
        }

        /// <summary>
        /// Constructor with the specified initial values.
        /// </summary>
        /// <param name="type">Type of the credit card</param>
        /// <param name="number">Number of the credit card</param>
        /// <param name="cvvNumber">CVV number of the credit card</param>
        /// <param name="holderName">Holder name of the credit card</param>
        /// <param name="expirationMonth">Expiration month of the credit card</param>
        /// <param name="expirationYear">Expiration year of the credit card</param>
        /// <param name="address">Billing address of the credit card</param>
        public CreditCardInfo(LookupInfo type, 
            string number, string cvvNumber, string holderName, int expirationMonth, 
            int expirationYear, AddressInfo address)
        {
            this.type = type;
            this.number = number;
            this.cvvNumber = cvvNumber;
            this.holderName = holderName;
            this.expirationMonth = expirationMonth;
            this.expirationYear = expirationYear;
            this.address = address;
        }

        public LookupInfo Type
       {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string CvvNumber
        {
            get
            {
                return cvvNumber;
            }
            set
            {
                cvvNumber = value;
            }
        }

        public string HolderName
        {
            get
            {
                return holderName;
            }
            set
            {
                holderName = value;
            }
        }

        public int ExpirationMonth
        {
            get
            {
                return expirationMonth;
            }
            set
            {
                expirationMonth = value;
            }
        }

        public int ExpirationYear
        {
            get
            {
                return expirationYear;
            }
            set
            {
                expirationYear = value;
            }
        }

        public AddressInfo Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
    }
}

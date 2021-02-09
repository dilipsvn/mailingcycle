using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public enum RegistrationStatus
    {
        Inactive = 0,
        Active,
        ApprovalRequired
    };

    public enum UserRole
    {
        Agent = 1,
        Printer,
        CSR,
        Admin,
        NullValue
    };

	/// <summary>
	/// Business Entity used to model Registrations.
	/// </summary>
	[Serializable]
	public class RegistrationInfo : BaseInfo
	{
		private int userId;
		private string userName;
        private string password;
        private string email;
        private string passwordQuestion;
        private string passwordAnswer;
        private string firstName;
        private string middleName;
        private string lastName;
		private string companyName;
		private AddressInfo address;
        private CreditCardInfo creditCard;
        private RegistrationStatus status;
        private DateTime signupDate;
        private UserRole role;
        
		/// <summary>
		/// Default constructor.
		/// </summary>
		public RegistrationInfo()
		{
			//
		}

		/// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
		/// <param name="userId">Internal identifier of the registered user</param>
        /// <param name="userName">Login account identifier of the registered user</param>
        /// <param name="firstName">First Name of the registered user</param>
		/// <param name="middleName">Middle Name of the registered user</param>
        /// <param name="lastName">Middle Name of the registered user</param>
		/// <param name="companyName">Name of the registered user</param>
		/// <param name="companyName">Name of the Company for registered user</param>
		/// <param name="email">Email of the registered user</param>
		/// <param name="address">Address of the registered user</param>
        /// <param name="creditCard">Credit Card details of the registered user</param>
        /// <param name="status">Status of the registered user</param>
        public RegistrationInfo(int userId, string userName, string password, string email, string passwordQuestion, string passwordAnswer, string firstName, 
            string middleName, string lastName, string companyName, AddressInfo address, CreditCardInfo creditCard,  RegistrationStatus status,DateTime signupDate, UserRole role)
		{
			this.userId = userId;
			this.userName = userName;
            this.password  = password;
            this.email = email;
            this.passwordQuestion = passwordQuestion;
            this.passwordAnswer = passwordAnswer;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
			this.companyName = companyName;
			this.address = address;
            this.creditCard = creditCard;
            this.status = status;
            this.signupDate = signupDate;
            this.role = role;
		}

        public int UserId
		{
			get
			{
				return userId;
			}
            set
            {
                userId = value;
            }
		}

        public string UserName
		{
			get
			{
				return userName;
			}
            set
            {
                userName = value;
            }
		}

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string PasswordQuestion
        {
            get
            {
                return passwordQuestion;
            }
            set
            {
                passwordQuestion = value;
            }
        }

        public string PasswordAnswer
        {
            get
            {
                return passwordAnswer;
            }
            set
            {
                passwordAnswer = value;
            }
        }

        public string FirstName
		{
			get
			{
				return firstName;
			}
            set
            {
                firstName = value;
            }
		}

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

		public string CompanyName
		{
			get
			{
				return companyName;
			}
            set
            {
                companyName = value;
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

        public CreditCardInfo CreditCard
        {
            get
            {
                return creditCard;
            }
            set
            {
                creditCard = value;
            }
        }

        public RegistrationStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public DateTime SignupDate
        {
            get
            {
                return signupDate;
            }
            set
            {
                signupDate = value;
            }
        }

        public UserRole Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }

    }
}

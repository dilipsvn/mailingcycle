using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{

    /// <summary>
    /// Business Entity used to model Login.
    /// </summary>
    [Serializable]
    public class LoginInfo : BaseInfo
    {
        private int userId;
        private string userName;
        private string firstName;
        private string lastName;
        private UserRole role;
        private RegistrationStatus status;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LoginInfo()
        {
            //
        }

        public LoginInfo(int userId, string userName, string firstName,
            string lastName, RegistrationStatus status,UserRole role)
        {
            this.userId = userId;
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
            this.status = status;
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

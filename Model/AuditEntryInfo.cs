using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Irmac.MailingCycle.Model
{
    public enum Module
    {
        None,
        Registration,
        UserManagement,
        FarmManagement,
        DesignManagement,
        MessageManagement,
        ScheduleManagement,
        ProductCatalog,
        ProductManagement,
        OrderManagement,
        ChangeRegistrationFee,
        ShoppingCart,
        SearchFarmData,
        BillingHistory,
        SearchOrders,
        Inventory,
        ChangePassword,
        UpdateProfile,
        UpdateCreditCard,
        ChangeSecretQuestion,
        AccaProcess
    };

    /// <summary>
    /// Business Entity used to model Audit Trail.
    /// </summary>
    [Serializable]
    public class AuditEntryInfo : BaseInfo
    {
        private int auditId = 0;
        private Module module = Module.None;
        private string record = string.Empty;
        private string action = string.Empty;
        private int ownerId = 0;
        private int modifiedBy = 0;
        private DateTime modifiedOn = DateTime.Now;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AuditEntryInfo()
        {
            //
        }

        /// <summary>
        /// Constructor with the specified initial values.
        /// </summary>
        /// <param name="module">Name of the module for the audit entry.</param>
        /// <param name="record">Unique name of the record for the audit entry.</param>
        /// <param name="action">Action taken for the audit entry.</param>
        /// <param name="ownerId">Record owner for the audit entry.</param>
        /// <param name="modifiedBy">Modified user for the audit entry.</param>
        public AuditEntryInfo(Module module, string record, string action,
            int ownerId, int modifiedBy)
        {
            this.module = module;
            this.record = record;
            this.action = action;
            this.ownerId = ownerId;
            this.modifiedBy = modifiedBy;
        }

        public int AuditId
        {
            get
            {
                return auditId;
            }
            set
            {
                auditId = value;
            }
        }

        public Module Module
        {
            get
            {
                return module;
            }
            set
            {
                module = value;
            }
        }

        public string ModuleName
        {
            get
            {
                string result = string.Empty;
                char[] letters = module.ToString().ToCharArray();

                foreach (char c in letters)
                {
                    if (c.ToString() == c.ToString().ToLower())
                    {
                        result += c.ToString();
                    }
                    else
                    {
                        if (result == "")
                        {
                            result += c.ToString();
                        }
                        else
                        {
                            result += " " + c.ToString();
                        }
                    }
                }

                return result;
            }
        }

        public string Record
        {
            get
            {
                return record;
            }
            set
            {
                record = value;
            }
        }

        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }

        public int OwnerId
        {
            get
            {
                return ownerId;
            }
            set
            {
                ownerId = value;
            }
        }

        public int ModifiedBy
        {
            get
            {
                return modifiedBy;
            }
            set
            {
                modifiedBy = value;
            }
        }

        public DateTime ModifiedOn
        {
            get
            {
                return modifiedOn;
            }
            set
            {
                modifiedOn = value;
            }
        }
    }
}

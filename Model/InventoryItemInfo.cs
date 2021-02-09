using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public enum TransactionType
    {
        Purchased = 4,
        Used
    };

    [Serializable()]
    public class InventoryItemInfo : BaseInfo
    {
        private int transactionId;
        private TransactionType transactionType;
        private DateTime transactionDate;
        private int quantity;
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }

        public TransactionType OrderTransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }

        public int TransactionId
        {
            get { return transactionId; }
            set { transactionId = value; }
        }
    }
}

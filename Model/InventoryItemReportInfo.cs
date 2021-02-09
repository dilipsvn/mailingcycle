using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    [Serializable()]
    public class InventoryItemReportInfo : BaseInfo
    {
        private TransactionType transactionType;
        private DateTime transactionDate;
        private int quantityPK;
        private int quantityBR;
        private int quantityEN;
        private int sumQuantityBR;

        public int SumQuantityBR
        {
            get { return sumQuantityBR; }
            set { sumQuantityBR = value; }
        }
        private int sumQuantityPK;

        public int SumQuantityPK
        {
            get { return sumQuantityPK; }
            set { sumQuantityPK = value; }
        }
        private int sumQuantityEN;

        public int SumQuantityEN
        {
            get { return sumQuantityEN; }
            set { sumQuantityEN = value; }
        }

        public int QuantityEN
        {
            get { return quantityEN; }
            set { quantityEN = value; }
        }

        public int QuantityBR
        {
            get { return quantityBR; }
            set { quantityBR = value; }
        }
        
        public int QuantityPK
        {
            get { return quantityPK; }
            set { quantityPK = value; }
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
    }
}

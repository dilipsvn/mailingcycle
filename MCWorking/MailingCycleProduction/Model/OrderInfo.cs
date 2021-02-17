using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public enum OrderType
    {
        MembershipFee = 1,
        MailingFee,
        PrePrintedCards,
        ShoppingCart,
        Event
    };

	/// <summary>
	/// Business Entity used to model Orders.
	/// </summary>
	[Serializable]
	public class OrderInfo : BaseInfo
	{
        private int orderId;
        private object number = Guid.NewGuid();
        private OrderType type;
        private DateTime date = DateTime.Now;
        private decimal amount;
        private int transactionCode;
        private string transactionMessage = string.Empty;
        private CreditCardInfo creditCard = new CreditCardInfo();
        private List<OrderItemInfo> items;
        private string userName;
        private bool transactionStatus;
        private decimal refundAmount;

        public decimal RefundAmount
        {
            get { return refundAmount; }
            set { refundAmount = value; }
        }

        public bool TransactionStatus
        {
            get { return transactionStatus; }
            set { transactionStatus = value; }
        }

        /// <summary>
		/// Default constructor.
		/// </summary>
		public OrderInfo()
		{
			//
		}

		/// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
        /// <param name="orderId">Internal identifier of the order.</param>
        /// <param name="number">Order number for the order.</param>
        /// <param name="type">Type of the order.</param>
        /// <param name="date">Date on which the order placed.</param>
        /// <param name="amount">Amount of the order.</param>
        /// <param name="transactionId">Credit Card Transacrtion ID against which the
        /// order placed.</param>
        /// <param name="creditCard">Credit Card used for the order.</param>
        /// <param name="items">The collection of items in the order.</param>
        public OrderInfo(int orderId, object number, OrderType type,
            DateTime date, decimal amount, int transactionCode, string transactionMessage,
            CreditCardInfo creditCard, List<OrderItemInfo> items)
		{
            this.orderId = orderId;
            this.number = number;
            this.type = type;
            this.date = date;
            this.amount = amount;
            this.transactionCode = transactionCode;
            this.transactionMessage = transactionMessage;
            this.creditCard = creditCard;
            this.items = items;
		}

        public int OrderId
		{
			get
			{
                return orderId;
			}
            set
            {
                orderId = value;
            }
		}

        public object Number
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

        public OrderType Type
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

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public int TransactionCode
        {
            get
            {
                return transactionCode;
            }
            set
            {
                transactionCode = value;
            }
        }


        public string TransactionMessage
        {
            get
            {
                return transactionMessage;
            }
            set
            {
                transactionMessage = value;
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

        public List<OrderItemInfo> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public enum OrderItemType
    {
        Product = 1,
        ProductPackage
    };

	/// <summary>
	/// Business Entity used to model Order Items.
	/// </summary>
	[Serializable]
	public class OrderItemInfo : BaseInfo
	{
        private string itemId;
        private string title;
        private OrderItemType type;
        private int quantity;
        private decimal rate;
        
		/// <summary>
		/// Default constructor.
		/// </summary>
		public OrderItemInfo()
		{
			//
		}

		/// <summary>
		/// Constructor with the specified initial values.
		/// </summary>
        /// <param name="itemId">Internal identifier of the order item.</param>
        /// <param name="title">Title of the order item.</param>
        /// <param name="type">Type of the order item.</param>
        /// <param name="quantity">Quantity of the order item.</param>
        /// <param name="rate">Rate of the order item.</param>
        public OrderItemInfo(string itemId, string title, OrderItemType type, 
            int quantity, decimal rate)
		{
            this.itemId = itemId;
            this.title = title;
            this.type = type;
            this.quantity = quantity;
            this.rate = rate;
		}

        public string ItemId
		{
			get
			{
                return itemId;
			}
            set
            {
                itemId = value;
            }
		}

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public OrderItemType Type
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

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public decimal Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }
	}
}

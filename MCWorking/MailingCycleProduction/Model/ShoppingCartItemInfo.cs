using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    [Serializable()]
    public class ShoppingCartItemInfo : BaseInfo
    {
        private string productId;
        private string description;
        private int quantity;
        private decimal price;
        private decimal totalPrice;
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
    }
}

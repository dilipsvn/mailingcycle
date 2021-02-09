using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    [Serializable()]
    public class ShoppingCartInfo : BaseInfo
    {
        private List<ShoppingCartItemInfo> cartItems;
        private decimal subTotal;
        private decimal shippingAndHandling;
        private decimal tax;
        private string promotionCode;
        private decimal discount;
        private decimal grandTotal;

        public decimal GrandTotal
        {
            get { return grandTotal; }
            set { grandTotal = value; }
        }

        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public string PromotionCode
        {
            get { return promotionCode; }
            set { promotionCode = value; }
        }

        public decimal Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        public decimal ShippingAndHandling
        {
            get { return shippingAndHandling; }
            set { shippingAndHandling = value; }
        }

        public decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public List<ShoppingCartItemInfo> CartItems
        {
            get { return cartItems; }
            set { cartItems = value; }
        }
        
    }
}

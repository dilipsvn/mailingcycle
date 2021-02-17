using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.Model;

namespace Irmac.MailingCycle.IDAL
{
    public interface IShoppingCart
    {
        ShoppingCartInfo GetCartLineItems(int userId,IProduct product);

        bool InsertCartItem(ShoppingCartItemInfo cartInfo,int ownerId);

        void GetPromotionDiscount(ShoppingCartInfo cartInfo);

        ShoppingCartInfo DeleteCartItem(int userId, string productId, IProduct product,int ownerId);

        bool UpdateCartItem(List<ShoppingCartItemInfo> cartItems,int ownerId);
    }
}

#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ShoppingCart.cs
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/04/2007
	* Author			: Irmac Development Team 
	* Comment			: ShoppingCart
	* Source			: MailingCycle\BLL\ShoppingCart.cs

	****************************************************************/
#endregion

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;
#endregion

namespace Irmac.MailingCycle.BLL
{
    /// <summary>
    /// Component class for shopping cart
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Gets the shopping cart items for the user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>ShoppngCartInfo object</returns>
        public ShoppingCartInfo GetCartItems(int userId)
        {
            IShoppingCart shoppingCart = (IShoppingCart)DALFactory.DAO.Create(DALFactory.Module.ShoppingCart);
            IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            shoppingCartInfo = shoppingCart.GetCartLineItems(userId, product);
            shoppingCartInfo.SubTotal = 0;
            foreach (ShoppingCartItemInfo cartItem in shoppingCartInfo.CartItems)
            {
                shoppingCartInfo.SubTotal += cartItem.TotalPrice;
                shoppingCartInfo.SubTotal = Math.Round(shoppingCartInfo.SubTotal, 2);
            }
            CalculateGrandTotal(shoppingCartInfo);
            return shoppingCartInfo;
        }

        /// <summary>
        /// Calculates the total
        /// </summary>
        /// <param name="shoppingCartInfo">ShoppingCartInfo object</param>
        public void CalculateGrandTotal(ShoppingCartInfo shoppingCartInfo)
        {
            ICommon common = (ICommon)DALFactory.DAO.Create(DALFactory.Module.Common);
            shoppingCartInfo.ShippingAndHandling = Convert.ToDecimal((common.GetProperty("ShippingAndHandling")).Value);
            shoppingCartInfo.GrandTotal = (shoppingCartInfo.SubTotal + 
                (shoppingCartInfo.SubTotal * shoppingCartInfo.Tax / 100))
                + shoppingCartInfo.ShippingAndHandling;            
            if (shoppingCartInfo.Discount > 0)
                shoppingCartInfo.GrandTotal -= shoppingCartInfo.GrandTotal * shoppingCartInfo.Discount / 100;
            shoppingCartInfo.GrandTotal = Math.Round(shoppingCartInfo.GrandTotal, 2);
        }

        /// <summary>
        /// Inserts line item into database
        /// </summary>
        /// <param name="cartInfo">line item to be inserted</param>
        /// <returns>success value</returns>
        public bool InsertCartItem(ShoppingCartItemInfo cartInfo,int ownerId)
        {
            IShoppingCart shoppingCart = (IShoppingCart)DALFactory.DAO.Create(DALFactory.Module.ShoppingCart);
            return shoppingCart.InsertCartItem(cartInfo,ownerId);
        }

        /// <summary>
        /// Updates the discount amount in the shopping cart object
        /// </summary>
        /// <param name="cartInfo">ShoppingCartInfo object</param>
        public void GetPromotionDiscount(ShoppingCartInfo cartInfo)
        {
            IShoppingCart shoppingCart = (IShoppingCart)DALFactory.DAO.Create(DALFactory.Module.ShoppingCart);
            shoppingCart.GetPromotionDiscount(cartInfo);
            CalculateGrandTotal(cartInfo);
        }

        /// <summary>
        /// Deletes the cart item from the database
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="productId">product id to be deleted</param>
        /// <returns>updated shoppingcartinfo object</returns>
        public ShoppingCartInfo DeleteCartItem(int userId, string productId,int ownerId)
        {
            IShoppingCart shoppingCart = (IShoppingCart)DALFactory.DAO.Create(DALFactory.Module.ShoppingCart);
            IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            shoppingCartInfo = shoppingCart.DeleteCartItem(userId, productId, product,ownerId);
            shoppingCartInfo.SubTotal = 0;
            foreach (ShoppingCartItemInfo cartItem in shoppingCartInfo.CartItems)
            {
                shoppingCartInfo.SubTotal += cartItem.TotalPrice;
                shoppingCartInfo.SubTotal = Math.Round(shoppingCartInfo.SubTotal, 2);
            }
            CalculateGrandTotal(shoppingCartInfo);
            return shoppingCartInfo;
        }

        /// <summary>
        /// Updates the cart item in the db
        /// </summary>
        /// <param name="cartItems">list of cart items</param>
        /// <returns>Updated shopping cart info object</returns>
        public ShoppingCartInfo UpdateCartItem(List<ShoppingCartItemInfo> cartItems,int ownerId)
        {
            IShoppingCart shoppingCart = (IShoppingCart)DALFactory.DAO.Create(DALFactory.Module.ShoppingCart);
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            if (shoppingCart.UpdateCartItem(cartItems,ownerId))
            {
                shoppingCartInfo.CartItems = cartItems;
                shoppingCartInfo.SubTotal = 0;
                foreach (ShoppingCartItemInfo cartItem in shoppingCartInfo.CartItems)
                {
                    shoppingCartInfo.SubTotal += cartItem.TotalPrice;
                    shoppingCartInfo.SubTotal = Math.Round(shoppingCartInfo.SubTotal, 2);
                }
                CalculateGrandTotal(shoppingCartInfo);                
            }
            return shoppingCartInfo;
        }       
    }
}

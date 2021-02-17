#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: Product.cs
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/04/2007
	* Author			: Irmac Development Team 
	* Comment			: Message
	* Source			: MailingCycle\BLL\Product.cs

	****************************************************************/
#endregion

# region Namespace
using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;
#endregion

namespace Irmac.MailingCycle.BLL
{
    /// <summary>
    /// Product Component
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets the default product line items
        /// </summary>
        /// <returns>List of product item info objects</returns>
        public List<ProductItemInfo> GetProductItems()
        {
            IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            return product.GetProductItems();
        }

        /// <summary>
        /// Inserts a product into the database
        /// </summary>
        /// <param name="productInfo">Product to be inserted</param>
        /// <returns>success value</returns>
        public bool InsertProduct(ProductInfo productInfo)
        {
           IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            return product.InsertProduct(productInfo);
        }

        /// <summary>
        /// Gets the products of the specified product type
        /// </summary>
        /// <param name="productTypeId">Prodyct type</param>
        /// <param name="agentUserId">agent id</param>
        /// <returns>list of product info objects</returns>
        public List<ProductInfo> GetProducts(int productTypeId,int agentUserId)
        {
            IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            return product.GetProducts(productTypeId,agentUserId);
        }

        /// <summary>
        /// Gets the details of the given product
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <returns>Product info object</returns>
        public ProductInfo GetProductDetails(string productId)
        {
            IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            return product.GetProductDetails(productId);
        }

        /// <summary>
        /// Updates the details of the product
        /// </summary>
        /// <param name="productInfo">The product info objects</param>
        /// <returns>success value</returns>
        public bool UpdateProduct(ProductInfo productInfo)
        {
            IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            return product.UpdateProduct(productInfo);
        }
        
        /// <summary>
        /// Deletes a product from the database
        /// </summary>
        /// <param name="productId">product id of the product to be deleted</param>
        /// <returns>success value</returns>
        public bool DeleteProduct(string productId,int userId)
        {
            IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            return product.DeleteProduct(productId,userId);
        }

        /// <summary>
        /// Gets the inventory levels
        /// </summary>
        /// <param name="agentUserId">user id</param>
        /// <returns>list of productiteminfo objects with quantity</returns>
        public List<ProductItemInfo> GetInventoryTotalCount(int agentUserId)
        {
            IProduct product = (IProduct)DALFactory.DAO.Create(DALFactory.Module.Product);
            return product.GetInventoryTotalCount(agentUserId);
        }
    }
}

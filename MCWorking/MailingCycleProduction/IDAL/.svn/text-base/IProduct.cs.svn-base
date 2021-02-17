using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.Model;

namespace Irmac.MailingCycle.IDAL
{
    public interface IProduct
    {
        List<ProductItemInfo> GetProductItems();

        bool InsertProduct(ProductInfo productInfo);

        List<ProductInfo> GetProducts(int productTypeId, int agentUserId);

        ProductInfo GetProductDetails(string productId);

        bool UpdateProduct(ProductInfo productInfo);

        bool DeleteProduct(string productId,int userId);

        List<ProductItemInfo> GetInventoryTotalCount(int agentUserId);
    }
}

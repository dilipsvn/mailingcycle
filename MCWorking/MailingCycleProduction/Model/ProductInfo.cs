using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    public enum ProductCatalogType
    {
        Standard = 1,
        Custom ,
        Generic
    };

    public enum ProductStatus
    {
        Inactive = 1,
        Active,
        OnHold,
        Obsolete
    };

    public enum ProductCategory
    {
        PowerKard = 100000,
        Brochure,
        Envelope,
        House_Fliers,
        Generic_Product
    };

    public class ProductInfo : BaseInfo
    {
        private ProductCatalogType productCatalog = ProductCatalogType.Standard;
        private string productId;
        private string briefDesc;
        private string briefDescWithQuantity;

        public string BriefDescWithQuantity
        {
            get { return briefDescWithQuantity; }
            set { briefDescWithQuantity = value; }
        }
        private string extDesc;
        private ProductStatus productStatus = ProductStatus.Active;
        private List<ProductItemInfo> productItems;
        private decimal totalPrice;       
        private int ownerId;

        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        public int OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }

        public List<ProductItemInfo> ProductItems
        {
            get { return productItems; }
            set { productItems = value; }
        }

        public ProductStatus ProductStatus
        {
            get { return productStatus; }
            set { productStatus = value; }
        }

        public string ExtDesc
        {
            get { return extDesc; }
            set { extDesc = value; }
        }
        
        public string BriefDesc
        {
            get { return briefDesc; }
            set { briefDesc = value; }
        }
        
        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public ProductCatalogType ProductCatalog
        {
            get { return productCatalog; }
            set { productCatalog = value; }
        }
        
    }
}

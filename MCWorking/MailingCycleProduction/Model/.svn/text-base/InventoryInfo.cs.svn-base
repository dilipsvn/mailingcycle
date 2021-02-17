using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.Model
{
    [Serializable()]
    public class InventoryInfo : BaseInfo
    {
        private ProductCategory categoryType;
        private int quantityOnHand = 0;
        private List<InventoryItemInfo> inventoryItems;

        public List<InventoryItemInfo> InventoryItems
        {
            get { return inventoryItems; }
            set { inventoryItems = value; }
        }

        public int QuantityOnHand
        {
            get { return quantityOnHand; }
            set { quantityOnHand = value; }
        }

        public ProductCategory CategoryType
        {
            get { return categoryType; }
            set { categoryType = value; }
        }
    }
}

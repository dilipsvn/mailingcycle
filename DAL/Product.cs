using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.IDAL;
using Irmac.MailingCycle.Model;
using System.Data.SqlClient;
using System.Data;

namespace Irmac.MailingCycle.DAL
{
    public class Product : IProduct
    {

        #region IProduct Members

        public List<ProductItemInfo> GetProductItems()
        {
            List<ProductItemInfo> products = new List<ProductItemInfo>();
            ProductItemInfo itemInfo;            
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement("Product", "SP_GET_PRODUCTCATEGORIES"), null))
            {
                while (reader.Read())
                {
                    itemInfo = new ProductItemInfo();
                    string avlSize = string.Empty;
                    if(reader["avl_size"] != DBNull.Value)
                       avlSize = (string)reader["avl_size"];
                    List<string> size = new List<string>();
                    if (avlSize != string.Empty)
                    {
                        char[] delim = new char[] { '|' };
                        if (avlSize != DBNull.Value.ToString() && avlSize != string.Empty)
                        {
                            foreach (string splitSize in avlSize.Split(delim))
                                size.Add(splitSize.Trim());
                        }
                    }
                    itemInfo.Size = size;
                    itemInfo.ProductType = (string)reader["category_name"];
                    itemInfo.ProductTypeId = (int)reader["category_code"];
                    products.Add(itemInfo);
                }
            }
            return products;
        }

        public List<ProductInfo> GetProducts(int productTypeId,int agentUserId)
        {
            List<ProductInfo> products = new List<ProductInfo>();
            ProductInfo itemInfo;
            SqlParameter[] sqlParam = new SqlParameter[] { new SqlParameter("@product_type", SqlDbType.Int),
            new SqlParameter("@agent_userid",SqlDbType.Int)};
            if(productTypeId != Int32.MinValue)
                sqlParam[0].Value = productTypeId;
            if (agentUserId != Int32.MinValue)
                sqlParam[1].Value = agentUserId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement("Product", "SP_GET_PRODUCTS"), sqlParam))
            {
                itemInfo = new ProductInfo();
                while (reader.Read())
                {
                    bool productExists = false;
                    foreach (ProductInfo product in products)
                    {
                        if (product.ProductId == (string)reader["product_id"])
                        {
                            productExists = true;
                            itemInfo = product;
                            break;
                        }
                    }
                    if (!productExists)
                    {
                        itemInfo = new ProductInfo();
                    }
                    itemInfo.ProductId = (string)reader["product_id"];
                    itemInfo.TotalPrice = Math.Round((decimal)reader["price"], 2);
                    itemInfo.ProductStatus = (ProductStatus)((int)reader["status"]);
                    if (reader["short_desc"] != DBNull.Value)
                    {
                        itemInfo.BriefDesc = (string)reader["short_desc"];
                    }
                    if(itemInfo.BriefDescWithQuantity  == null || itemInfo.BriefDescWithQuantity == string.Empty)
                        itemInfo.BriefDescWithQuantity = itemInfo.BriefDesc + "<br><br><I> Contains </I>";
                    if (reader["agent_user_id"] != DBNull.Value)
                        itemInfo.ProductCatalog = ProductCatalogType.Custom;
                    List<ProductItemInfo> productItemInfo = new List<ProductItemInfo>();
                    ProductItemInfo productItem = new ProductItemInfo();
                    productItem.Quantity = (int)reader["quantity"];
                    List<string> size = new List<string>();
                    if(reader["size"] != DBNull.Value)
                        size.Add((string)reader["size"]);
                    productItem.Size = size;
                    productItemInfo.Add(productItem);
                    itemInfo.ProductItems = productItemInfo;
                    if (agentUserId == Int32.MinValue || (agentUserId != Int32.MinValue && productTypeId != Int32.MinValue))
                    {
                        if (productTypeId == (int)ProductCategory.Generic_Product && (int)reader["Product_Count"] > 1)
                        {
                            AddToGenericProduct(products, itemInfo, reader);
                        }
                        else if ((int)reader["Product_Count"] == 1 && productTypeId == (int)reader["category_code"])
                        {
                            AddToDesc(itemInfo, reader);
                            products.Add(itemInfo);
                            itemInfo = new ProductInfo();
                        }                        
                    }
                    if (productTypeId == Int32.MinValue)
                    {
                        if ((int)reader["Product_Count"] > 1)
                        {
                            AddToGenericProduct(products, itemInfo, reader);
                        }
                        else if ((int)reader["Product_Count"] == 1)
                        {
                            AddToDesc(itemInfo, reader);
                            products.Add(itemInfo);
                            itemInfo = new ProductInfo();
                        }
                    }
                    
                }
            }
            return products;
        }

        public List<ProductItemInfo> GetInventoryTotalCount(int agentUserId)
        {
            List<ProductItemInfo> products = new List<ProductItemInfo>();
            ProductItemInfo itemInfo;
            SqlParameter[] sqlParam = new SqlParameter[] {new SqlParameter("@agent_userid",SqlDbType.Int)};
            if (agentUserId != 0)
                sqlParam[0].Value = agentUserId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement("Product", "SP_GET_INVENTORYCOUNT"), sqlParam))
            {
                while (reader.Read())
                {
                    itemInfo = new ProductItemInfo();
                    itemInfo.ProductType = (string)reader["category_name"];
                    itemInfo.ProductTypeId = (int)reader["category_code"];
                    itemInfo.Quantity = (int)reader["Quantity"];
                    products.Add(itemInfo);
                }
            }
            return products;
        }

        private static void AddToGenericProduct(List<ProductInfo> products, ProductInfo itemInfo, SqlDataReader reader)
        {
            bool productExists = false;
            foreach (ProductInfo product in products)
            {
                if (product.ProductId == itemInfo.ProductId)
                {
                    productExists = true;
                    break;
                }
            }
            if (!productExists)
            {
                AddToDesc(itemInfo, reader);
                products.Add(itemInfo);
            }
            else
                AddToDesc(itemInfo, reader);
        }

        private static void AddToDesc(ProductInfo itemInfo, SqlDataReader reader)
        {
            itemInfo.BriefDescWithQuantity += "<I> " + ((int)reader["quantity"]).ToString() + " " +
                (Convert.ToString(reader["category_name"]).EndsWith("s") ? Convert.ToString(reader["category_name"]) : Convert.ToString(reader["category_name"]) + "s");
            if(reader["size"] != DBNull.Value)
                itemInfo.BriefDescWithQuantity += " of size " + (string)reader["size"] + " inch</I><br><br>";
            else
                itemInfo.BriefDescWithQuantity += "</I><br><br>";
        }

        public ProductInfo GetProductDetails(string productId)
        {
            ProductInfo info = new ProductInfo();
            ProductItemInfo itemInfo;
            SqlParameter[] sqlParam = new SqlParameter[] { new SqlParameter("@product_id", SqlDbType.NVarChar,30) };
            sqlParam[0].Value = productId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement("Product", "SP_GET_SINGLEPRODUCTDETAILS"), sqlParam))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    info.ProductId = (string)reader["product_id"];
                    info.TotalPrice = Math.Round((decimal)reader["price"],2);
                    if (reader["short_desc"] != DBNull.Value)
                    {
                        info.BriefDesc = (string)reader["short_desc"];
                    }
                    info.BriefDescWithQuantity = info.BriefDesc + "<br><br><I> Contains </I>";
                    info.ExtDesc = (string)reader["long_desc"];
                    info.ProductStatus = (ProductStatus)(Convert.ToInt32(reader["status"]));
                    info.TotalPrice = Math.Round(Convert.ToDecimal(reader["price"]),2);                    
                    List<ProductItemInfo> productItems = new List<ProductItemInfo>();
                    do
                    {
                        itemInfo = new ProductItemInfo();
                        if (reader["agent_user_id"] != DBNull.Value)
                        {
                            itemInfo.AgentUserId = (int)reader["agent_user_id"];
                            itemInfo.IsCustomSize = true;
                            info.ProductCatalog = ProductCatalogType.Custom;
                        }
                        itemInfo.ProductTypeId = (int)reader["category_code"];
                        itemInfo.ProductType = (string)reader["category_name"];
                        itemInfo.Quantity = (int)reader["quantity"];
                        itemInfo.Size = new List<string>();
                        if(reader["size"] != DBNull.Value)
                            itemInfo.Size.Add((string)reader["size"]);
                        AddToDesc(info, reader);
                        productItems.Add(itemInfo);
                    } while (reader.Read());
                    info.ProductItems = productItems;
                }
                else
                    info = null;
            }
            return info;
        }

        public bool InsertProduct(ProductInfo productInfo)
        {
            bool success = false;
            SqlParameter[] messageParameters = GetProductHeaderParams();
            messageParameters[0].Value = productInfo.ProductId;
            if (productInfo.BriefDesc != string.Empty && productInfo.BriefDesc != null)
                messageParameters[1].Value = productInfo.BriefDesc;
            else
                messageParameters[1].Value = DBNull.Value;
            messageParameters[2].Value = productInfo.ExtDesc;
            messageParameters[3].Value = (int)productInfo.ProductStatus;
            messageParameters[4].Value = productInfo.TotalPrice;
            messageParameters[5].Value = productInfo.OwnerId;
            
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement("Product", "SP_INSERT_PRODUCTHEADER"), messageParameters);
                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.ProductCatalog, productInfo.ProductId,
                                            "Inserted product header", productInfo.OwnerId,productInfo.OwnerId);
                        AuditTrail.WriteEntry(auditEntry, sqlTran);
                        success = (noOfRecords > 0);
                        
                        foreach (ProductItemInfo itemInfo in productInfo.ProductItems)
                        {
                            SqlParameter[] messageDetailsParameters = GetProductDetailsParams();
                            messageDetailsParameters[0].Value = productInfo.ProductId;
                            messageDetailsParameters[1].Value = 0;
                            messageDetailsParameters[2].Value = itemInfo.ProductTypeId;
                            messageDetailsParameters[3].Value = itemInfo.Quantity;
                            if (itemInfo.Size.Count > 0)
                                messageDetailsParameters[4].Value = itemInfo.Size[0];
                            if (itemInfo.IsCustomSize)
                            {
                                messageDetailsParameters[5].Value = itemInfo.AgentUserId;
                            }
                            noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                                SQLHelper.GetSQLStatement("Product", "SP_INSERT_PRODUCTDETAILS"), messageDetailsParameters);
                            auditEntry = new AuditEntryInfo(Module.ProductCatalog, productInfo.ProductId + "-" + itemInfo.ProductTypeId,
                                "Inserted product details", productInfo.OwnerId, itemInfo.IsCustomSize ? productInfo.OwnerId : itemInfo.AgentUserId);
                            AuditTrail.WriteEntry(auditEntry, sqlTran);
                            success = (noOfRecords > 0);
                        }
                        sqlTran.Commit();
                    }
                    catch
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
            return success;
        }

        public bool UpdateProduct(ProductInfo productInfo)
        {
            bool success = false;
            SqlParameter[] messageParameters = GetProductHeaderParams();
            messageParameters[0].Value = productInfo.ProductId;
            if(productInfo.BriefDesc != string.Empty)
                messageParameters[1].Value = productInfo.BriefDesc;
            messageParameters[2].Value = productInfo.ExtDesc;
            messageParameters[3].Value = (int)productInfo.ProductStatus;
            messageParameters[4].Value = productInfo.TotalPrice;
            messageParameters[5].Value = productInfo.OwnerId;

            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    bool isCustom = false;
                    try
                    {
                        int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement("Product", "SP_UPDATE_PRODUCTHEADER"), messageParameters);

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.ProductCatalog, productInfo.ProductId,
                                            "Updated product header", productInfo.OwnerId,productInfo.OwnerId);
                        AuditTrail.WriteEntry(auditEntry, sqlTran);
                        success = true;

                        foreach (ProductItemInfo itemInfo in productInfo.ProductItems)
                        {
                            SqlParameter[] messageDetailsParameters = GetProductDetailsParams();
                            messageDetailsParameters[0].Value = productInfo.ProductId;
                            messageDetailsParameters[1].Value = 0;
                            messageDetailsParameters[2].Value = itemInfo.ProductTypeId;
                            messageDetailsParameters[3].Value = itemInfo.Quantity;
                            if(itemInfo.Size.Count > 0)
                                messageDetailsParameters[4].Value = itemInfo.Size[0];
                            if (itemInfo.IsCustomSize || isCustom)
                            {
                                messageDetailsParameters[5].Value = itemInfo.AgentUserId;
                                isCustom = true;
                            }
                            else
                                messageDetailsParameters[5].Value = DBNull.Value;
                            noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                                SQLHelper.GetSQLStatement("Product", "SP_UPDATE_PRODUCTDETAILS"), messageDetailsParameters);
                            auditEntry = new AuditEntryInfo(Module.ProductCatalog, productInfo.ProductId + "-" + itemInfo.ProductTypeId,
                                "Updated product details", productInfo.OwnerId,isCustom ? itemInfo.AgentUserId : productInfo.OwnerId);
                            AuditTrail.WriteEntry(auditEntry, sqlTran);
                        }
                        sqlTran.Commit();
                        success = true;
                    }
                    catch
                    {
                        sqlTran.Rollback();
                        success = false;
                        throw;
                    }
                }
            }
            return success;
        }

        public bool DeleteProduct(string productId,int userId)
        {
            bool success = false;
            SqlParameter[] sqlParam = new SqlParameter[] { new SqlParameter("@product_id", SqlDbType.NVarChar, 30) };
            sqlParam[0].Value = productId;

            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement("Product", "SP_DELETE_PRODUCT"), sqlParam);
                        success = (noOfRecords > 0);
                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.ProductCatalog, productId,"Deleted product", userId, userId);
                        AuditTrail.WriteEntry(auditEntry, sqlTran);
                        sqlTran.Commit();
                    }
                    catch
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
            return success;
        }

        private static SqlParameter[] GetProductHeaderParams()
        {
            SqlParameter[] messageParams = SQLHelper.GetCachedParameters("SQL_INSERT_GetProductHeader");
            if (messageParams == null)
            {
                messageParams = new SqlParameter[]{
                    new SqlParameter("@product_id",SqlDbType.NVarChar,30),
                    new SqlParameter("@short_desc",SqlDbType.NVarChar,255),
                    new SqlParameter("@long_desc",SqlDbType.NVarChar,255),
                    new SqlParameter("@status",SqlDbType.Int),
                    new SqlParameter("@price",SqlDbType.SmallMoney),
                    new SqlParameter("@user_id",SqlDbType.Int)};
                SQLHelper.CacheParameters("SQL_INSERT_GetProductHeader", messageParams);
            }
            return messageParams;
        }

        private static SqlParameter[] GetProductDetailsParams()
        {
            SqlParameter[] messageParams = SQLHelper.GetCachedParameters("SQL_INSERT_GetProductDetails");
            if (messageParams == null)
            {
                messageParams = new SqlParameter[]{
                    new SqlParameter("@product_id",SqlDbType.NVarChar,30),
                    new SqlParameter("@item_no",SqlDbType.Int),
                    new SqlParameter("@category_code",SqlDbType.Int),
                    new SqlParameter("@quantity",SqlDbType.Int),
                    new SqlParameter("@size",SqlDbType.Text),
                    new SqlParameter("@agent_userid",SqlDbType.Int)};
                SQLHelper.CacheParameters("SQL_INSERT_GetProductDetails", messageParams);
            }
            return messageParams;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.IDAL;
using Irmac.MailingCycle.Model;
using System.Data;
using System.Data.SqlClient;

namespace Irmac.MailingCycle.DAL
{
    public class ShoppingCart : IShoppingCart
    {

        #region IShoppingCart Members

        public ShoppingCartInfo GetCartLineItems(int userId,IProduct product)
        {
            ShoppingCartInfo cartInfo = new ShoppingCartInfo();
            List<ShoppingCartItemInfo> cartItems = new List<ShoppingCartItemInfo>();
            ShoppingCartItemInfo cartItem; 
            SqlParameter[] sqlParam = new SqlParameter[] { new SqlParameter("@user_id", SqlDbType.Int) };
            sqlParam[0].Value = userId;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement("ShoppingCart", "SP_GET_CARTITEMS"), 
                sqlParam))
            {
                while (reader.Read())
                {
                    cartItem = new ShoppingCartItemInfo();
                    cartItem.ProductId = (string)reader["product_id"];
                    cartItem.Price = Math.Round((decimal)reader["price"],2);
                    cartItem.Quantity = (int)reader["quantity"];
                    cartItem.Description = product.GetProductDetails(cartItem.ProductId).BriefDescWithQuantity;
                    cartItem.TotalPrice = cartItem.Quantity * cartItem.Price;
                    cartItem.UserId = userId;
                    cartItems.Add(cartItem);
                    cartInfo.Tax = Math.Round(Convert.ToDecimal(reader["Tax"]), 2);
                }
            }
            cartInfo.CartItems = cartItems;

            return cartInfo;            
        }

        public void GetPromotionDiscount(ShoppingCartInfo cartInfo)
        {
            SqlParameter[] sqlParam = new SqlParameter[] { new SqlParameter("@promotion_code", SqlDbType.NVarChar,20) };
            sqlParam[0].Value = cartInfo.PromotionCode;
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement("ShoppingCart", "SP_GET_PROMOTIONDISCOUNT"),
                sqlParam))
            {
                while (reader.Read())
                {
                    cartInfo.Discount = Convert.ToDecimal(reader["percentage"]);
                }
            }            
        }
        

        public bool InsertCartItem(ShoppingCartItemInfo cartInfo,int ownerId)
        {
            bool success = false;
            SqlParameter[] messageParameters = GetCartItemParams();
            messageParameters[0].Value = cartInfo.UserId;
            messageParameters[1].Value = cartInfo.ProductId;
            messageParameters[2].Value = cartInfo.Quantity;

            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement("ShoppingCart", "SP_INSERT_CARTITEM"), messageParameters);
                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.ShoppingCart, cartInfo.ProductId,
                                            "Inserted cart item", cartInfo.UserId,ownerId);
                        AuditTrail.WriteEntry(auditEntry, sqlTran);
                        success = (noOfRecords > 0);
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

        public ShoppingCartInfo DeleteCartItem(int userId, string productId,IProduct product,int ownerId)
        {
            ShoppingCartInfo cartInfo = new ShoppingCartInfo();
            List<ShoppingCartItemInfo> cartItems = new List<ShoppingCartItemInfo>();
            ShoppingCartItemInfo cartItem; 
            SqlParameter[] messageParamater = new SqlParameter[] { new SqlParameter("@product_id", SqlDbType.NVarChar,30),
            new SqlParameter("@user_id", SqlDbType.Int)};
            messageParamater[0].Value = productId;
            messageParamater[1].Value = userId;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING, CommandType.StoredProcedure,
                            SQLHelper.GetSQLStatement("ShoppingCart", "SP_DELETE_CARTITEM"), messageParamater))
                        {
                            AuditEntryInfo auditEntry = new AuditEntryInfo(Module.ShoppingCart, productId, "deleted shopping cart item", userId, 
                                ownerId);
                            AuditTrail.WriteEntry(auditEntry, sqlTran);
                            while (reader.Read())
                            {
                                cartItem = new ShoppingCartItemInfo();
                                cartItem.ProductId = (string)reader["product_id"];
                                cartItem.Price = Math.Round((decimal)reader["price"],2);
                                cartItem.Quantity = (int)reader["quantity"];
                                cartItem.Description = product.GetProductDetails(cartItem.ProductId).BriefDescWithQuantity;
                                cartItem.TotalPrice = cartItem.Quantity * cartItem.Price;
                                cartItem.UserId = userId;
                                cartItems.Add(cartItem);
                                cartInfo.Tax = Math.Round((decimal)reader["Tax"], 2);
                            }
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
            cartInfo.CartItems = cartItems;
            return cartInfo;
        }

        public bool UpdateCartItem(List<ShoppingCartItemInfo> cartItems,int ownerId)
        {
            bool success = false;
            SqlParameter[] messageParamater = new SqlParameter[] { new SqlParameter("@product_id", SqlDbType.NVarChar,30),
            new SqlParameter("@user_id", SqlDbType.Int),
            new SqlParameter("@quantity", SqlDbType.Int)};
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    foreach (ShoppingCartItemInfo cartItem in cartItems)
                    {
                        try
                        {
                            messageParamater[0].Value = cartItem.ProductId;
                            messageParamater[1].Value = cartItem.UserId;
                            messageParamater[2].Value = cartItem.Quantity;

                            int noOfRecords = SQLHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure,
                                SQLHelper.GetSQLStatement("ShoppingCart", "SP_UPDATE_CARTITEM"), messageParamater);
                            AuditEntryInfo auditEntry = new AuditEntryInfo(Module.ShoppingCart, cartItem.ProductId,
                                            "Inserted cart item", cartItem.UserId,ownerId);
                            AuditTrail.WriteEntry(auditEntry, sqlTran);
                            success = (noOfRecords > 0);                            
                        }
                        catch
                        {
                            sqlTran.Rollback();
                            throw;
                        }
                    }
                    sqlTran.Commit();
                }
            }
            return success;
        }

        #endregion

        private static SqlParameter[] GetCartItemParams()
        {
            SqlParameter[] cartItemParams = SQLHelper.GetCachedParameters("SQL_INSERT_GetCartItem");
            if (cartItemParams == null)
            {
                cartItemParams = new SqlParameter[]{
                    new SqlParameter("@user_id",SqlDbType.Int),
                    new SqlParameter("@product_id",SqlDbType.NVarChar,30),
                    new SqlParameter("@quantity",SqlDbType.Int)};
                SQLHelper.CacheParameters("SQL_INSERT_GetCartItem", cartItemParams);
            }
            return cartItemParams;
        }        
    }
}

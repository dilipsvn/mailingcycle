using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.DAL
{
	/// <summary>
	/// A Data Access Component used to manage Orders.
	/// </summary>
    public class Order : IOrder
    {
        private const string MODULE_NAME = "Order";

        public Order()
        {
            //
        }

        /// <summary>
        /// Inserts an order for the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="order">Order Information for the user.</param>
        public int Insert(int userId, OrderInfo order,int ownerId)
        {
            int orderId = 0;
            using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRING))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Get the  details of the credit card.
                        Registration registration = new DAL.Registration();

                        // Insert Order Details.
                        SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_INSERT_ORDER");

                        if (parameters == null)
                        {
                            parameters = new SqlParameter[] {
                                new SqlParameter("@OrderId", SqlDbType.Int),
                                new SqlParameter("@OrderNumber", SqlDbType.Int),
                                new SqlParameter("@OrderType", SqlDbType.Int),
                                new SqlParameter("@OrderDate", SqlDbType.DateTime),
                                new SqlParameter("@Amount", SqlDbType.Decimal),
                                new SqlParameter("@TransactionCode", SqlDbType.Int),
                                new SqlParameter("@TransactionMessage", SqlDbType.NVarChar, 255),
                                new SqlParameter("@CreditCardTypeId", SqlDbType.Int),
                                new SqlParameter("@CreditCardNo", SqlDbType.NVarChar, 20),
                                new SqlParameter("@CVVNo", SqlDbType.NVarChar, 4),
                                new SqlParameter("@HolderName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@ExpirationMonth", SqlDbType.Int),
					            new SqlParameter("@ExpirationYear", SqlDbType.Int),
					            new SqlParameter("@BillingAddress1", SqlDbType.NVarChar, 255),
					            new SqlParameter("@BillingAddress2", SqlDbType.NVarChar, 255),
					            new SqlParameter("@BillingCity", SqlDbType.NVarChar, 100),
					            new SqlParameter("@BillingStateId", SqlDbType.Int),
					            new SqlParameter("@BillingZip", SqlDbType.NVarChar, 15),
					            new SqlParameter("@BillingCountryId", SqlDbType.Int),
                                new SqlParameter("@UserId", SqlDbType.Int)
                            };

                            SQLHelper.CacheParameters("SQL_INSERT_ORDER", parameters);
                        }

                        parameters[0].Direction = ParameterDirection.Output;
                        parameters[1].Value = order.Number;
                        parameters[2].Value = order.Type;
                        parameters[3].Value = order.Date;
                        parameters[4].Value = order.Amount;
                        parameters[5].Value = order.TransactionCode;
                        parameters[6].Value = order.TransactionMessage;
                        parameters[7].Value = order.CreditCard.Type.LookupId;
                        parameters[8].Value = order.CreditCard.Number;
                        parameters[9].Value = order.CreditCard.CvvNumber;
                        parameters[10].Value = order.CreditCard.HolderName;
                        parameters[11].Value = order.CreditCard.ExpirationMonth;
                        parameters[12].Value = order.CreditCard.ExpirationYear;
                        parameters[13].Value = order.CreditCard.Address.Address1;
                        parameters[14].Value = order.CreditCard.Address.Address2;
                        parameters[15].Value = order.CreditCard.Address.City;
                        parameters[16].Value = order.CreditCard.Address.State.StateId;
                        parameters[17].Value = order.CreditCard.Address.Zip;
                        parameters[18].Value = order.CreditCard.Address.Country.CountryId;
                        parameters[19].Value = userId;

                        SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                            SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_ORDER"),
                            parameters);                        
                        orderId = (int)parameters[0].Value;

                        AuditEntryInfo auditEntry = new AuditEntryInfo(Module.OrderManagement, orderId.ToString(), "Inserted order header",
                                                            userId, ownerId);
                        AuditTrail.WriteEntry(auditEntry, transaction);

                        if (order.Items != null)
                        {
                            parameters = SQLHelper.GetCachedParameters("SQL_INSERT_ORDER_DETAIL");

                            if (parameters == null)
                            {
                                parameters = new SqlParameter[] {
                                    new SqlParameter("@OrderId", SqlDbType.Int),
                                    new SqlParameter("@line_number", SqlDbType.Int),
                                    new SqlParameter("@ItemId", SqlDbType.NVarChar,30),
                                    new SqlParameter("@Quantity", SqlDbType.Int),
                                    new SqlParameter("@Rate", SqlDbType.Decimal)
                                };

                                SQLHelper.CacheParameters("SQL_INSERT_ORDER_DETAIL", parameters);
                            }
                            int lineNumber = 1;                            
                            foreach (OrderItemInfo orderItem in order.Items)
                            {                                
                                parameters[0].Value = orderId;
                                parameters[1].Value = lineNumber;
                                parameters[2].Value = orderItem.ItemId;
                                parameters[3].Value = orderItem.Quantity;
                                parameters[4].Value = orderItem.Rate;

                                SQLHelper.ExecuteNonQuery(transaction, CommandType.Text,
                                    SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_INSERT_ORDER_DETAIL"),
                                    parameters);

                                auditEntry = new AuditEntryInfo(Module.OrderManagement, orderId.ToString(), "Inserted order detail",
                                                            userId, ownerId);
                                AuditTrail.WriteEntry(auditEntry, transaction);

                                Product product = new Product();                            
                                if (order.Type == OrderType.ShoppingCart && order.TransactionStatus)
                                {
                                    ProductInfo productInfo = product.GetProductDetails(orderItem.ItemId);
                                    foreach (ProductItemInfo productItemInfo in productInfo.ProductItems)
                                    {
                                        SqlParameter[] messageParameters = GetCartItemParams();
                                        messageParameters[0].Value = userId;
                                        messageParameters[1].Value = productItemInfo.ProductTypeId;
                                        messageParameters[2].Value = orderItem.Quantity * productItemInfo.Quantity;
                                        SQLHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure,
                                            SQLHelper.GetSQLStatement(MODULE_NAME, "SP_INSERT_UPDATE_INVENTORY"), messageParameters);
                                        auditEntry = new AuditEntryInfo(Module.OrderManagement, productItemInfo.ProductTypeId.ToString(),
                                            "Updated inventory", userId, ownerId);
                                        AuditTrail.WriteEntry(auditEntry, transaction);
                                    }
                                }
                            }
                        }

                        // Update the user status if the type of payment is Membership Fees.
                        if (order.Type == OrderType.MembershipFee)
                        {
                            //registration.UpdateStatus(userId, 
                            //    RegistrationStatus.MembershipPaid, transaction);
                        }
                        if (order.Type == OrderType.ShoppingCart)
                        {
                            ShoppingCart cart = new ShoppingCart();
                            cart.DeleteCartItem(userId, string.Empty, new Product(),ownerId);                            
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
            return orderId;
        }


        private static SqlParameter[] GetCartItemParams()
        {
            SqlParameter[] cartItemParams = SQLHelper.GetCachedParameters("SQL_INSERT_INVENTORY");
            if (cartItemParams == null)
            {
                cartItemParams = new SqlParameter[]{
                    new SqlParameter("@user_id",SqlDbType.Int),
                    new SqlParameter("@category_code",SqlDbType.Int),
                    new SqlParameter("@quantity",SqlDbType.Int)};
                SQLHelper.CacheParameters("SQL_INSERT_INVENTORY", cartItemParams);
            }
            return cartItemParams;
        }

        /// <summary>
        /// Get the list of orders for the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>List of orders for the specified user.</returns>
        public List<OrderInfo> GetList(int userId)
        {
            List<OrderInfo> orders = new List<OrderInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_ORDERS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_ORDERS", parameters);
            }

            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_ORDERS"),
                parameters))
            {
                while (reader.Read())
                {
                    List<OrderItemInfo> orderItems = GetItems(reader.GetInt32(1));
                    CreditCardInfo cardInfo = new CreditCardInfo(new LookupInfo(reader.GetInt32(3), reader.GetString(4)), reader.GetString(5), string.Empty, string.Empty, Int32.MinValue, Int32.MinValue,
                        new AddressInfo(reader.GetString(8), reader.GetString(9), reader.GetString(10), new CountryInfo(reader.GetInt32(13), reader.GetString(14), false),
                        new StateInfo(reader.GetInt32(11), reader.GetString(12)), reader.GetString(15), null, null, null));

                    OrderInfo order = new OrderInfo(reader.GetInt32(1), null,
                        (OrderType)reader.GetInt32(16), reader.GetDateTime(2), Math.Round(reader.GetDecimal(6), 2),
                        reader.GetInt32(7), null, cardInfo, orderItems);

                    if (reader[17] != DBNull.Value)
                        order.RefundAmount = reader.GetDecimal(17);
                    orders.Add(order);
                }
            }

            return orders;
        }

        /// <summary>
        /// Get the items of the specified order.
        /// </summary>
        /// <param name="orderId">Internal identifier of the order.</param>
        /// <returns>Items of the specified order.</returns>
        public List<OrderItemInfo> GetItems(int orderId)
        {
            List<OrderItemInfo> items = new List<OrderItemInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_ORDER_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@OrderId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_ORDER_DETAILS", parameters);
            }

            parameters[0].Value = orderId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_ORDER_DETAILS"),
                parameters))
            {
                while (reader.Read())
                {
                    string desc = new Product().GetProductDetails(reader.GetString(0)).BriefDescWithQuantity;
                    OrderItemInfo item = new OrderItemInfo(reader.GetString(0), desc,
                        OrderItemType.Product, Convert.ToInt32(reader[1]), Math.Round(reader.GetDecimal(2), 2));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// Get the list of orders for the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>List of orders for the specified user.</returns>
        public List<OrderInfo> GetSearchOrders(int userId, int orderId, int cardType, DateTime startDate, DateTime endDate)
        {
            List<OrderInfo> orders = new List<OrderInfo>();

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_SEARCH_ORDERS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_SEARCH_ORDERS", parameters);
            }

            parameters[0].Value = userId;
            string sql = SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_SEARCH_ORDERS");
            if (userId != Int32.MinValue)
                sql += " AND TBL_ORDER_HEADER.user_id = '" + userId.ToString() + "'";
            if (orderId != Int32.MinValue)
                sql += " AND TBL_ORDER_HEADER.order_id like '" + orderId.ToString() + "%'";
            if (cardType != Int32.MinValue)
                sql += " AND TBL_ORDER_HEADER.card_type = " + cardType.ToString();
            if (startDate != DateTime.MinValue)
                sql += " AND TBL_ORDER_HEADER.order_date >= '" + startDate.ToString() + "'";
            if (endDate != DateTime.MinValue)
                sql += " AND TBL_ORDER_HEADER.order_date <= '" + endDate.AddDays(1).ToString() + "'";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, sql, parameters))
            {
                while (reader.Read())
                {
                    List<OrderItemInfo> orderItems = GetItems(reader.GetInt32(1));
                    CreditCardInfo cardInfo = new CreditCardInfo(new LookupInfo(reader.GetInt32(3), reader.GetString(4)), reader.GetString(5), string.Empty, string.Empty, Int32.MinValue, Int32.MinValue,
                        new AddressInfo(reader.GetString(8), reader.GetString(9), reader.GetString(10), new CountryInfo(reader.GetInt32(13), reader.GetString(14), false),
                        new StateInfo(reader.GetInt32(11), reader.GetString(12)), reader.GetString(15), null, null, null));

                    OrderInfo order = new OrderInfo(reader.GetInt32(1), null,
                        (OrderType)reader.GetInt32(16), reader.GetDateTime(2), Math.Round(reader.GetDecimal(6),2),
                        reader.GetInt32(7), null, cardInfo, orderItems);
                    order.UserName = reader.GetString(0);

                    if (reader[17] != DBNull.Value)
                        order.RefundAmount = reader.GetDecimal(17);
                    orders.Add(order);
                }
            }

            return orders;
        }

        public List<InventoryInfo> GetInventoryList(int userId)
        {
            List<InventoryInfo> items = new List<InventoryInfo>();
            InventoryInfo inventoryInfo = new InventoryInfo();
            InventoryItemInfo inventoryItemInfo;
            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_INVENTORY_DETAILS");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@user_id", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_INVENTORY_DETAILS", parameters);
            }

            parameters[0].Value = userId;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.StoredProcedure, SQLHelper.GetSQLStatement(MODULE_NAME, "SP_GET_INVENTORY_DETAILS"),
                parameters))
            {
                while (reader.Read())
                {
                    bool isExists = false;
                    foreach (InventoryInfo inventoryAddedInfo in items)
                    {
                        if ((int)inventoryAddedInfo.CategoryType == (int)reader["category_code"])
                        {
                            isExists = true;
                            inventoryInfo = inventoryAddedInfo;
                            break;
                        }
                    }
                    if (!isExists)
                    {
                        inventoryInfo = new InventoryInfo();
                        inventoryInfo.CategoryType = (ProductCategory)(Convert.ToInt32(reader["category_code"]));
                        inventoryInfo.InventoryItems = new List<InventoryItemInfo>();
                    }
                    inventoryItemInfo = new InventoryItemInfo();
                    inventoryItemInfo.OrderTransactionType = (TransactionType)(Convert.ToInt32(reader["order_type"]));                    
                    inventoryItemInfo.Quantity = Convert.ToInt32(reader["Quantity"]);
                    inventoryItemInfo.Remarks = (string)reader["cc_trxn_message"];
                    inventoryItemInfo.TransactionDate = Convert.ToDateTime(reader["order_date"]);
                    inventoryItemInfo.TransactionId = Convert.ToInt32(reader["cc_trxn_code"]);
                    inventoryInfo.InventoryItems.Add(inventoryItemInfo);
                    if (!isExists)
                        items.Add(inventoryInfo);
                }
            }
            Product product = new Product();
            List<ProductItemInfo> products = product.GetInventoryTotalCount(userId);
            foreach (ProductItemInfo itemInfo in products)
            {
                foreach (InventoryInfo inventoryInfoItem in items)
                {
                    if (itemInfo.ProductType == inventoryInfoItem.CategoryType.ToString().Replace("_"," "))
                        inventoryInfoItem.QuantityOnHand = itemInfo.Quantity;
                }
            }
            return items;
        }

        /// <summary>
        /// Get the list of orders for the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>List of orders for the specified user.</returns>
        public List<InventoryItemReportInfo> GetSearchInventory(int userId, DateTime startDate, DateTime endDate)
        {
            List<InventoryItemReportInfo> items = new List<InventoryItemReportInfo>();
            InventoryItemReportInfo inventoryInfo = new InventoryItemReportInfo();
            

            SqlParameter[] parameters = SQLHelper.GetCachedParameters("SQL_GET_SEARCH_INVENTORY");

            if (parameters == null)
            {
                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int)
                };

                SQLHelper.CacheParameters("SQL_GET_SEARCH_INVENTORY", parameters);
            }

            parameters[0].Value = userId;
            string sql = SQLHelper.GetSQLStatement(MODULE_NAME, "SQL_GET_INVETORY");
            if (startDate != DateTime.MinValue)
                sql += " AND convert(datetime,order_date) >= '" + startDate.ToString() + "'";
            if (endDate != DateTime.MinValue)
                sql += " AND convert(datetime,order_date) <= '" + endDate.AddDays(1).ToString() + "'";
            sql += " order by order_date";
            int sumQuantityPK = 0;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.CONNECTION_STRING,
                CommandType.Text, sql,parameters))
            {
                while (reader.Read())
                {
                    if (reader["quantity"] != DBNull.Value)
                    {
                        bool isExists = false;
                        foreach (InventoryItemReportInfo inventoryAddedInfo in items)
                        {

                            if (inventoryAddedInfo.TransactionDate == Convert.ToDateTime(reader["order_date"]))
                                if (inventoryAddedInfo.OrderTransactionType == (TransactionType)Convert.ToInt32(reader["order_type"]))
                                {
                                    isExists = true;
                                    if (((ProductCategory)(Convert.ToInt32(reader["category_code"]))) == ProductCategory.PowerKard)
                                    {
                                        inventoryAddedInfo.QuantityPK += Convert.ToInt32(reader["Quantity"]);                                        
                                    }
                                    else if (((ProductCategory)(Convert.ToInt32(reader["category_code"]))) == ProductCategory.Brochure)
                                    {
                                        inventoryAddedInfo.QuantityBR += Convert.ToInt32(reader["Quantity"]);                                        
                                    }
                                    else if (((ProductCategory)(Convert.ToInt32(reader["category_code"]))) == ProductCategory.Envelope)
                                    {
                                        inventoryAddedInfo.QuantityEN += Convert.ToInt32(reader["Quantity"]);                                        
                                    }
                                    break;
                                }
                        }

                        if (!isExists)
                        {
                            inventoryInfo = new InventoryItemReportInfo();
                            inventoryInfo.TransactionDate = Convert.ToDateTime(reader["order_date"]);
                            inventoryInfo.OrderTransactionType = (TransactionType)Convert.ToInt32(reader["order_type"]);
                            if (((ProductCategory)(Convert.ToInt32(reader["category_code"]))) == ProductCategory.PowerKard)
                            {
                                inventoryInfo.QuantityPK = Convert.ToInt32(reader["Quantity"]);

                            }
                            else if (((ProductCategory)(Convert.ToInt32(reader["category_code"]))) == ProductCategory.Brochure)
                            {
                                inventoryInfo.QuantityBR = Convert.ToInt32(reader["Quantity"]);
                            }
                            else if (((ProductCategory)(Convert.ToInt32(reader["category_code"]))) == ProductCategory.Envelope)
                            {
                                inventoryInfo.QuantityEN = Convert.ToInt32(reader["Quantity"]);
                            }
                            items.Add(inventoryInfo);
                        }
                    }
                }
            }
            if (items.Count > 0)
            {
                int rowCount = 0;
                items[rowCount].SumQuantityPK = items[rowCount].QuantityPK;
                items[rowCount].SumQuantityBR = items[rowCount].QuantityBR;
                items[rowCount].SumQuantityEN = items[rowCount].QuantityEN;
                rowCount++;
                while (rowCount < items.Count)
                {
                    if (items[rowCount].OrderTransactionType == TransactionType.Purchased)
                    {
                        items[rowCount].SumQuantityPK = items[rowCount - 1].SumQuantityPK + items[rowCount].QuantityPK;
                        items[rowCount].SumQuantityBR = items[rowCount - 1].SumQuantityBR + items[rowCount].QuantityBR;
                        items[rowCount].SumQuantityEN = items[rowCount - 1].SumQuantityEN + items[rowCount].QuantityEN;
                    }
                    else
                    {
                        items[rowCount].SumQuantityPK = items[rowCount - 1].SumQuantityPK - items[rowCount].QuantityPK;
                        items[rowCount].SumQuantityBR = items[rowCount - 1].SumQuantityBR - items[rowCount].QuantityBR;
                        items[rowCount].SumQuantityEN = items[rowCount - 1].SumQuantityEN - items[rowCount].QuantityEN;
                    }
                    rowCount++;
                }
            }
            return items;
        }
    }
}

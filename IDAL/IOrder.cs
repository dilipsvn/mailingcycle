using System;
using System.Collections.Generic;
using Irmac.MailingCycle.Model;

namespace Irmac.MailingCycle.IDAL
{
	/// <summary>
	/// Inteface for the Order DAL.
	/// </summary>
	public interface IOrder
	{
        /// <summary>
        /// Inserts an order for the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="order">Order Information for the user.</param>
        int Insert(int userId, OrderInfo order,int ownerId);

        /// <summary>
        /// Get the list of orders for the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>List of orders for the specified user.</returns>
        List<OrderInfo> GetList(int userId);

        /// <summary>
        /// Get the items of the specified order.
        /// </summary>
        /// <param name="orderId">Internal identifier of the order.</param>
        /// <returns>Items of the specified order.</returns>
        List<OrderItemInfo> GetItems(int orderId);

        /// <summary>
        /// Gets the list of inventory transactions for the specified user
        /// </summary>
        /// <param name="userId">Internal identifier of the user</param>
        /// <returns>Inventory transactions</returns>
        List<InventoryInfo> GetInventoryList(int userId);

        /// <summary>
        /// Gets the list of orders based on search criteria
        /// </summary>
        /// <param name="userId">Internal identifier of the user</param>
        /// <param name="orderId">order id</param>
        /// <param name="cardType">credit card type</param>
        /// <param name="startDate">start date</param>
        /// <param name="endDate">end date</param>
        /// <returns>List of orders</returns>
        List<OrderInfo> GetSearchOrders(int userId, int orderId, int cardType, DateTime startDate, DateTime endDate);

        List<InventoryItemReportInfo> GetSearchInventory(int userId, DateTime startDate, DateTime endDate);
	}
}

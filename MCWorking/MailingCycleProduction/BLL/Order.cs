#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: Order.cs
    * Created Date      : 10/02/2007
	* Last Modify Date  : 10/02/2007
	* Author			: Irmac Development Team 
	* Comment			: Order management
	* Source			: MailingCycle\BLL\Order.cs

	****************************************************************/
#endregion

#region NameSpaces
using System;
using System.Collections.Generic;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;
#endregion

namespace Irmac.MailingCycle.BLL
{
	/// <summary>
	/// A Business Component used to manage Orders.
	/// </summary>
	public class Order
	{
        /// <summary>
        /// Inserts an order for the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="order">Order Information for the user.</param>
        public int Insert(int userId, OrderInfo order,int ownerId)
        {
            // Get an instance of the Order DAO using the DALFactory
            IOrder dao = (IOrder)DALFactory.DAO.Create(DALFactory.Module.Order);
            int orderId = 0;
            try
            {
                orderId = dao.Insert(userId, order,ownerId);
            }
            catch
            {
                throw;
            }
            return orderId;
        }

        /// <summary>
        /// Get the list of orders for the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>List of orders for the specified user.</returns>
        public List<OrderInfo> GetList(int userId)
        {
            // Get an instance of the Order DAO using the DALFactory
            IOrder dao = (IOrder)DALFactory.DAO.Create(DALFactory.Module.Order);

            List<OrderInfo> orders = dao.GetList(userId);

            return orders;
        }

        /// <summary>
        /// Get the items of the specified order.
        /// </summary>
        /// <param name="orderId">Internal identifier of the order.</param>
        /// <returns>Items of the specified order.</returns>
        public List<OrderItemInfo> GetItems(int orderId)
        {
            // Get an instance of the Order DAO using the DALFactory
            IOrder dao = (IOrder)DALFactory.DAO.Create(DALFactory.Module.Order);

            List<OrderItemInfo> items = dao.GetItems(orderId);

            return items;
        }

        public List<InventoryInfo> GetInventoryList(int userId)
        {
            IOrder dao = (IOrder)DALFactory.DAO.Create(DALFactory.Module.Order);
            return dao.GetInventoryList(userId);
        }

        public List<OrderInfo> GetSearchOrders(int userId, int orderId, int cardType, DateTime startDate, DateTime endDate)
        {
            IOrder dao = (IOrder)DALFactory.DAO.Create(DALFactory.Module.Order);
            return dao.GetSearchOrders(userId,orderId,cardType,startDate,endDate);
        }

        public List<InventoryItemReportInfo> GetSearchInventory(int userId, DateTime startDate, DateTime endDate)
        {
            IOrder dao = (IOrder)DALFactory.DAO.Create(DALFactory.Module.Order);
            return dao.GetSearchInventory(userId, startDate, endDate);
        }
	}
}

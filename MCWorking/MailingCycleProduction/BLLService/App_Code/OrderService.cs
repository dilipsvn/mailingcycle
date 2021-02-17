using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;

/// <summary>
/// A Service Component used to manage Orders.
/// </summary>
[WebService(Namespace = "http://mc.mkbedev.com/BLLService/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class OrderService : System.Web.Services.WebService
{
    public OrderService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public int Insert(int userId, OrderInfo order,int ownerId)
    {
        // Get an instance of the Order BO
        Order bll = new Order();
        
        return bll.Insert(userId, order,ownerId);
    }

    [WebMethod]
    public CreditCardInfo GetCreditCard(int userId)
    {
        // Get an instance of the Registration BO
        RegistrationService service = new RegistrationService();

        CreditCardInfo creditCard = service.GetCreditCard(userId);

        return creditCard;
    }

    [WebMethod]
    public List<OrderInfo> GetList(int userId)
    {
        // Get an instance of the Order BO
        Order bll = new Order();

        List<OrderInfo> orders = bll.GetList(userId);

        return orders;
    }

    [WebMethod]
    public List<OrderItemInfo> GetItems(int orderId)
    {
        // Get an instance of the Order BO
        Order bll = new Order();

        List<OrderItemInfo> items = bll.GetItems(orderId);

        return items;
    }

    [WebMethod]
    public List<InventoryInfo> GetInventoryList(int userId)
    {
        // Get an instance of the Order BO
        Order bll = new Order();

        List<InventoryInfo> items = bll.GetInventoryList(userId);

        return items;
    }

    [WebMethod]
    public List<OrderInfo> GetSearchOrders(int userId, int orderId, int cardType, DateTime startDate, DateTime endDate)
    {
        Order bll = new Order();
        return bll.GetSearchOrders(userId, orderId, cardType, startDate, endDate);
    }

    [WebMethod]
    public List<InventoryItemReportInfo> GetSearchInventory(int userId, DateTime startDate, DateTime endDate)
    {
        Order bll = new Order();
        return bll.GetSearchInventory(userId,  startDate, endDate);
    }
}

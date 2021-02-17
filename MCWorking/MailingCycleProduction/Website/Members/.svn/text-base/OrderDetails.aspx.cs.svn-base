#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: OrderDetails.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to view order details
	* Source			: MailingCycle\OrderDetails.aspx.cs

	****************************************************************/
#endregion

#region Namespaces
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrderService = Irmac.MailingCycle.BLLServiceLoader.Order;
using Irmac.MailingCycle.BLLServiceLoader.ShoppingCart;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
#endregion

public partial class OrderDetails : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(OrderDetails));
    #region Properties
    public bool IsAgentRole
    {
        get
        {
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            return (regInfo.Role == Irmac.MailingCycle.BLLServiceLoader.Registration.UserRole.Agent);
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["itemSelected"] != null && Session["BillingInfo"] != null)
            {
                if (!IsAgentRole && Session["SelectedAgent"] != null)
                    AgentLiteral.Text = "Selected Agent: " + Session["SelectedAgent"].ToString();               

                OrderService.OrderInfo[] orderInfo = (OrderService.OrderInfo[])Session["BillingInfo"];
                int orderId = Convert.ToInt32(Request.QueryString["itemSelected"]);
                int selectedItem = 0;
                foreach (OrderService.OrderInfo orderInfoItem in orderInfo)
                {
                    if (orderInfoItem.OrderId == orderId)
                        break;
                    selectedItem++;
                }
                TransactionNoLiteral.Text = orderInfo[selectedItem].TransactionCode.ToString();
                if (!IsAgentRole && orderInfo[selectedItem].UserName != null && orderInfo[selectedItem].UserName != string.Empty)
                    AgentLiteral.Text = "Selected Agent: " + orderInfo[selectedItem].UserName;               
                AssignDataSource(orderInfo[selectedItem], orderInfo[selectedItem].CreditCard);
            }
            else
                ErrorLiteral.Text = "Error loading order details";
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        string redirectUrl = "BillingHistory.aspx?";
        if (!IsAgentRole && Request.QueryString["userId"] != null)
            redirectUrl += "userId=" + Request.QueryString["userId"] +"&";
        if (Request.QueryString["isFromSearch"] != null)
            redirectUrl += "isFromSearch=yes";
        Response.Redirect(redirectUrl);       
    }
    #endregion

    #region Methods
    private void AssignDataSource(OrderService.OrderInfo orderInfo, OrderService.CreditCardInfo cardInfo)
    {
        OrderNoLiteral.Text = orderInfo.OrderId.ToString();
        OrderDateLiteral.Text = orderInfo.Date.ToShortDateString();
        PaymentDetailsLiteral.Text = cardInfo.Type.Name + " ," + "XXXX-XXXX-XXXX-" + cardInfo.Number.Substring(cardInfo.Number.Length - 4);
        BillingAddressLiteral.Text = cardInfo.Address.Address1 + ", ";
        if (cardInfo.Address.Address2 != string.Empty && cardInfo.Address.Address2 != null)
            BillingAddressLiteral.Text += cardInfo.Address.Address2 + ", ";
        BillingAddressLiteral.Text += cardInfo.Address.City + ", " + cardInfo.Address.State.Name + "-" + cardInfo.Address.Zip;
        if (orderInfo.RefundAmount != null && orderInfo.RefundAmount != 0)
        {
            RefundAmountLiteral.Text = orderInfo.RefundAmount.ToString();
            RefundPanel.Visible = true;
        }
        else
            RefundPanel.Visible = false;
        if (orderInfo.Items.Length > 0)
        {
            ShoppingCartInfo cartInfo1 = new ShoppingCartInfo();
            ShoppingCartItemInfo cartItemInfo = new ShoppingCartItemInfo();
            List<ShoppingCartItemInfo> cartItems = new List<ShoppingCartItemInfo>();
            foreach (OrderService.OrderItemInfo orderItem in orderInfo.Items)
            {
                cartItemInfo = new ShoppingCartItemInfo();
                cartItemInfo.Description = orderItem.Title;
                cartItemInfo.Price = orderItem.Rate;
                cartItemInfo.Quantity = orderItem.Quantity;
                cartItemInfo.ProductId = orderItem.ItemId;
                cartItemInfo.TotalPrice = cartItemInfo.Quantity * cartItemInfo.Price;
                cartInfo1.SubTotal += cartItemInfo.TotalPrice;
                cartInfo1.SubTotal = Math.Round(cartInfo1.SubTotal, 2);
                cartItems.Add(cartItemInfo);
            }
            cartInfo1.CartItems = cartItems.ToArray();
            if (cardInfo.Address.State.Name.ToLower() == "colorado")
            {
                CommonService commonService = ServiceAccess.GetInstance().GetCommon();
                if (commonService.GetProperty("Tax") != null)
                    cartInfo1.Tax = Convert.ToDecimal(commonService.GetProperty("Tax").Value);
            }
            else
            {
                cartInfo1.Tax = 0;
            }
            ShoppingCartService cartService = ServiceAccess.GetInstance().GetShoppingCart();
            ShoppingCartInfo cartInfo = cartService.CalculateGrandTotal(cartInfo1);
            CartGridView.DataSource = cartInfo.CartItems;
            CartGridView.DataBind();
            SubTotalLiteral.Text = cartInfo.SubTotal.ToString();
            ShippingLiteral.Text = cartInfo.ShippingAndHandling.ToString();
            TaxLiteral.Text = cartInfo.Tax.ToString();
            GrandTotalLiteral.Text = cartInfo.GrandTotal.ToString();
            DiscountLiteral.Text = cartInfo.Discount.ToString();
        }
        else
            ProductsPanel.Visible = false;
    }
    #endregion    
}

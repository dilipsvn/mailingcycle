#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CheckoutConf.aspx
    * Created Date      : 11/20/2007
	* Last Modify Date  : 11/20/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to show confirmation message
	* Source			: MailingCycle\CheckoutConf.aspx.cs

	****************************************************************/
#endregion

#region Namespaces
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ShoppingCartService = Irmac.MailingCycle.BLLServiceLoader.ShoppingCart;
using OrderService = Irmac.MailingCycle.BLLServiceLoader.Order;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
#endregion

public partial class CheckoutConf : System.Web.UI.Page
{
    #region Properties
    public bool IsAgentRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Agent);
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CreditCardInfo"] != null && Session["CheckOutDataSource"] != null)
            {
                if (!IsAgentRole)
                    AgentLiteral.Text = "Selected Agent: " + Session["SelectedAgent"].ToString();
                ShoppingCartService.ShoppingCartInfo cartInfo = (ShoppingCartService.ShoppingCartInfo)Session["CheckOutDataSource"];
                OrderService.OrderInfo orderInfo = (OrderService.OrderInfo)Session["CreditCardInfo"];
                TransactionNoLiteral.Text = orderInfo.TransactionCode.ToString();
                AssignDataSource(cartInfo, orderInfo.CreditCard);
            }
            else
                Response.Redirect("~/Members/ProductCatalog.aspx");
        }
    }

    protected void DoneButton_Click(object sender, EventArgs e)
    {
        Session["SelectedAgent"] = null;
        Session["CheckOutDataSource"] = null;
        Session["CreditCardInfo"] = null;
        Session["TimeStamp"] = null;
        Response.Redirect("ProductCatalog.aspx");
    }
    #endregion

    #region Methods
    private void AssignDataSource(ShoppingCartService.ShoppingCartInfo cartInfo, OrderService.CreditCardInfo cardInfo)
    {
        OrderLiteral.Text = OrderNoLiteral.Text = Request.QueryString["orderId"];
        
        OrderDateLiteral.Text = DateTime.Now.ToShortDateString();
        PaymentDetailsLiteral.Text = cardInfo.Type.Name + " ," + "XXXX-XXXX-XXXX-" + cardInfo.Number.Substring(cardInfo.Number.Length - 4);
        BillingAddressLiteral.Text = cardInfo.Address.Address1 + ", ";
        if (cardInfo.Address.Address2 != string.Empty && cardInfo.Address.Address2 != null)
            BillingAddressLiteral.Text += cardInfo.Address.Address2 + ", ";
        BillingAddressLiteral.Text += cardInfo.Address.City + ", " + cardInfo.Address.State.Name + "-" + cardInfo.Address.Zip;
        if (cartInfo.CartItems.Length > 0)
        {
            CartGridView.DataSource = cartInfo.CartItems;
            CartGridView.DataBind();
            SubTotalLiteral.Text = cartInfo.SubTotal.ToString();
            ShippingLiteral.Text = cartInfo.ShippingAndHandling.ToString();
            TaxLiteral.Text = cartInfo.Tax.ToString();
            GrandTotalLiteral.Text = cartInfo.GrandTotal.ToString();
            DiscountLiteral.Text = cartInfo.Discount.ToString();
        }
    }
    #endregion



}

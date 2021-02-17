#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CheckOut.aspx
    * Created Date      : 11/20/2007
	* Last Modify Date  : 11/20/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to place order
	* Source			: MailingCycle\CheckOut.aspx.cs

	****************************************************************/
#endregion

# region Namespaces
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Net;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ShoppingCartService = Irmac.MailingCycle.BLLServiceLoader.ShoppingCart;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Common;
using OrderService = Irmac.MailingCycle.BLLServiceLoader.Order;
using log4net;
using TemplateParser;
#endregion

public partial class CheckOut : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(CheckOut));

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

    # region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        Response.AppendHeader("Pragma", "no-cache");

        if (Page.IsPostBack)
        {
            if (IsPageExpired())
            {
                Session["TimeStamp"] = null;
                Response.Redirect("ShoppingCart.aspx");
            }            
        }

        if (!IsPostBack)
        {          
            if (Session["CheckOutDataSource"] != null)
            {
                ShoppingCartService.ShoppingCartInfo cartInfo = (ShoppingCartService.ShoppingCartInfo)Session["CheckOutDataSource"];
                AssignDataSource(cartInfo);
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                RegistrationService.RegistrationService regService = serviceLoader.GetRegistration();
                int userId = 0;
                if (IsAgentRole)
                    userId = ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId;
                else
                {
                    userId = cartInfo.CartItems[0].UserId;
                    AgentLiteral.Text = "Selected Agent: " + Session["SelectedAgent"].ToString();
                }
                try
                {
                    RegistrationService.CreditCardInfo cardInfo = regService.GetCreditCard(userId);
                    AssignCardInfoDataSource(cardInfo);
                }
                catch (Exception ex)
                {
                    log.Error("Error getting the credit card details.",ex);
                    ErrorLiteral.Text = "Error getting credit card details";
                }
            }
            else
                Response.Redirect("~/Members/ProductCatalog.aspx");
           
        }
        CreditCardDetails1.OnStateDropDownChange += new EventHandler(CheckOut_SelectedIndexChanged);
        AsyncPostBackTrigger postBackTrigger = new AsyncPostBackTrigger();
        postBackTrigger.ControlID = "CreditCardDetails1";
        postBackTrigger.EventName = "OnStateDropDownChange";
        CartPanel.Triggers.Add(postBackTrigger);
    }

    private bool IsPageExpired()
    {
        /*if (Session["TimeStamp"] == null ||
           ViewState["TimeStamp"] == null)
            return false;
        else if (Session["TimeStamp"] == ViewState["TimeStamp"])
            return true;
        else
            return false;*/
        if (Session["TimeStamp"] != null)
            return true;
        return false;
    }

    void CheckOut_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ShoppingCartService.ShoppingCartInfo dataSource = (ShoppingCartService.ShoppingCartInfo)Session["CheckOutDataSource"];
            if (((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedItem.Text.ToLower() == "colorado")
            {
                CommonService commonService = ServiceAccess.GetInstance().GetCommon();
                if (commonService.GetProperty("Tax") != null)
                    dataSource.Tax = Convert.ToDecimal(commonService.GetProperty("Tax").Value);
            }
            else
            {
                dataSource.Tax = 0;
            }

            ShoppingCartService.ShoppingCartService shoppingCartService = ServiceAccess.GetInstance().GetShoppingCart();
            ShoppingCartService.ShoppingCartInfo updatedDataSource = shoppingCartService.CalculateGrandTotal(dataSource);
            AssignDataSource(updatedDataSource);
            Session["CheckOutDataSource"] = updatedDataSource;
        }
        catch (Exception ex)
        {
            log.Error("Error setting the tax", ex);
            ErrorLiteral.Text = "Error setting the tax value";
        }

    }

    protected void PayNowButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ShoppingCartService.ShoppingCartInfo cartInfo =
                (ShoppingCartService.ShoppingCartInfo)Session["CheckOutDataSource"];
            OrderService.OrderService orderService = ServiceAccess.GetInstance().GetOrder();
            OrderService.OrderInfo orderInfo = AssignOrderInfo(cartInfo);
            
            int userId = 0;
            if (IsAgentRole)
                userId = ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId;
            else
            {
                userId = cartInfo.CartItems[0].UserId;
            }
            try
            {
                orderInfo.OrderId = orderService.Insert(userId, orderInfo, ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId);
                Session["CreditCardInfo"] = orderInfo;
                if (orderInfo.OrderId > 0 && orderInfo.TransactionStatus)
                {
                    SendMail(orderInfo, userId);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error creating order", ex);
                ErrorLiteral.Text = "Error creating order. Please try again later";
            }
            if (orderInfo.OrderId > 0 && orderInfo.TransactionStatus)
            {
                Session["TimeStamp"] = "Completed";
                Response.Redirect("CheckoutConf.aspx?orderId=" + orderInfo.OrderId);                
            }
            else
            {
                if (!orderInfo.TransactionStatus)
                    ErrorLiteral.Text = "Could not process the order. Please contact the administrator";
                else
                    ErrorLiteral.Text = "Error creating order. Please try again later";
            }
        }

    }

    private void SendMail(OrderService.OrderInfo orderInfo,int userId)
    {
        bool IsDevelopmentPC = true;
        string URLAddress = CommonEvents.GetDynamicPath(Request);
        Hashtable templateVars = new Hashtable();
        templateVars.Add("URL", URLAddress);
        templateVars.Add("FIRSTNAME", orderInfo.CreditCard.HolderName);
        templateVars.Add("ORDER_NUMBER", orderInfo.OrderId);
        templateVars.Add("CARD_TYPE", orderInfo.CreditCard.Type.Name);
        templateVars.Add("CARD_NUMBER", "********" + orderInfo.CreditCard.Number.Substring(orderInfo.CreditCard.Number.Length - 4));
        templateVars.Add("CARDHOLDER_NAME", orderInfo.CreditCard.HolderName);
        templateVars.Add("BILLING_ADDRESS1", orderInfo.CreditCard.Address.Address1);
        templateVars.Add("BILLING_ADDRESS2", orderInfo.CreditCard.Address.Address2);
        templateVars.Add("BILLING_CITY", orderInfo.CreditCard.Address.City);
        templateVars.Add("BILLING_STATE", orderInfo.CreditCard.Address.State.Name);
        templateVars.Add("BILLING_ZIP", orderInfo.CreditCard.Address.Zip);
        String emailTemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_Order.html";
        Parser parser = new Parser(emailTemplateFilePath, templateVars);
        int index = parser.TemplateBlock.IndexOf("<!-- for inserting here-->");
        string htmlString = string.Empty;
        foreach (OrderService.OrderItemInfo orderItemInfo in orderInfo.Items)
        {
            htmlString += "<tr><td>" + orderItemInfo.ItemId + "</td><td>" +
                orderItemInfo.Quantity.ToString() + "</td>" + "<td>" + orderItemInfo.Rate + "</td></tr>";
        }
        parser.TemplateBlock = parser.TemplateBlock.Insert(index, htmlString);
        string mailBody = parser.Parse();
        RegistrationService.RegistrationService registrationService = ServiceAccess.GetInstance().GetRegistration();

        string toAddress = registrationService.GetDetails(userId).Email;

        //Creating Mail Message Body
        MailMessage mailmsg = new MailMessage();
        mailmsg.To.Add(toAddress);
        mailmsg.From =
                new MailAddress("MailingCycle@MailingCycle.com", "MailingCycle");
        mailmsg.Subject = "Order Confirmation at Mailing Cycle";
        mailmsg.IsBodyHtml = true;
        mailmsg.Body = mailBody;
        mailmsg.Priority = MailPriority.Normal;

        Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);

        MailSettingsSectionGroup mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
        if (mailSettings != null)
        {
            int port = mailSettings.Smtp.Network.Port;
            string host = mailSettings.Smtp.Network.Host;
            string password = mailSettings.Smtp.Network.Password;
            string username = mailSettings.Smtp.Network.UserName;

            SmtpClient smtpclient = new SmtpClient(host, 587);
            smtpclient.Credentials = new NetworkCredential(username, password);
            smtpclient.EnableSsl = true;
            smtpclient.Send(mailmsg);
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        if (!IsAgentRole)
            Response.Redirect("ShoppingCart.aspx?userId=" + Request.QueryString["userId"]);
        else
            Response.Redirect("ShoppingCart.aspx");
    }

    protected void ChangeCardDetailsButton_Click(object sender, EventArgs e)
    {
        ToggleEnableForCardInfo(true);
        ((DropDownList)CreditCardDetails1.FindControl("CardTypeDropDownList")).SelectedIndex = 0;
        ((TextBox)CreditCardDetails1.FindControl("CardNumberTextBox")).Text = string.Empty;
        ((DropDownList)CreditCardDetails1.FindControl("CardMonthDropDownList")).SelectedIndex = 0;
        ((DropDownList)CreditCardDetails1.FindControl("CardYearDropDownList")).SelectedIndex = 0;
        //((TextBox)CreditCardDetails1.FindControl("CVVNumberTextBox")).Text = cardInfo.CvvNumber.ToString();
        ((TextBox)CreditCardDetails1.FindControl("CardHolderNameTextBox")).Text = string.Empty;
        ((TextBox)CreditCardDetails1.FindControl("BillingAddress1TextBox")).Text = string.Empty;
        ((TextBox)CreditCardDetails1.FindControl("BillingAddress2TextBox")).Text = string.Empty;
        ((TextBox)CreditCardDetails1.FindControl("BillingCityTextBox")).Text = string.Empty;
        ((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedIndex = 0;
        ((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).SelectedIndex = 0;
        ((TextBox)CreditCardDetails1.FindControl("BillingZipTextBox")).Text = string.Empty;
    }
    #endregion

    #region Methods
    private void AssignCardInfoDataSource(RegistrationService.CreditCardInfo cardInfo)
    {
        ((DropDownList)CreditCardDetails1.FindControl("CardTypeDropDownList")).SelectedValue = cardInfo.Type.LookupId.ToString();
        ((TextBox)CreditCardDetails1.FindControl("CardNumberTextBox")).Text =
           "XXXX-XXXX-XXXX-" + cardInfo.Number.Substring(cardInfo.Number.Length - 4);
        CardLabel.Text = cardInfo.Number;        
        ((DropDownList)CreditCardDetails1.FindControl("CardMonthDropDownList")).SelectedValue = cardInfo.ExpirationMonth.ToString();
        ((DropDownList)CreditCardDetails1.FindControl("CardYearDropDownList")).SelectedValue = cardInfo.ExpirationYear.ToString();
        //((TextBox)CreditCardDetails1.FindControl("CVVNumberTextBox")).Text = cardInfo.CvvNumber.ToString();
        ((TextBox)CreditCardDetails1.FindControl("CardHolderNameTextBox")).Text = cardInfo.HolderName.ToString();
        ((TextBox)CreditCardDetails1.FindControl("BillingAddress1TextBox")).Text = cardInfo.Address.Address1.ToString();
        ((TextBox)CreditCardDetails1.FindControl("BillingAddress2TextBox")).Text = cardInfo.Address.Address2.ToString();
        ((TextBox)CreditCardDetails1.FindControl("BillingCityTextBox")).Text = cardInfo.Address.City.ToString();
        ((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedValue = cardInfo.Address.State.StateId.ToString();
        ((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).SelectedValue = cardInfo.Address.Country.CountryId.ToString();
        ((TextBox)CreditCardDetails1.FindControl("BillingZipTextBox")).Text = cardInfo.Address.Zip.ToString();
        ((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).AutoPostBack = true;
        ToggleEnableForCardInfo(false);
    }

    private void ToggleEnableForCardInfo(bool isEnabled)
    {
        ((DropDownList)CreditCardDetails1.FindControl("CardTypeDropDownList")).Enabled = isEnabled;
        ((TextBox)CreditCardDetails1.FindControl("CardNumberTextBox")).Enabled = isEnabled;
        ((DropDownList)CreditCardDetails1.FindControl("CardMonthDropDownList")).Enabled = isEnabled;
        ((DropDownList)CreditCardDetails1.FindControl("CardYearDropDownList")).Enabled = isEnabled;
        ((TextBox)CreditCardDetails1.FindControl("CVVNumberTextBox")).Enabled = isEnabled;
        ((TextBox)CreditCardDetails1.FindControl("CardHolderNameTextBox")).Enabled = isEnabled;
        ((TextBox)CreditCardDetails1.FindControl("BillingAddress1TextBox")).Enabled = isEnabled;
        ((TextBox)CreditCardDetails1.FindControl("BillingAddress2TextBox")).Enabled = isEnabled;
        ((TextBox)CreditCardDetails1.FindControl("BillingCityTextBox")).Enabled = isEnabled;
        ((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).Enabled = isEnabled;
        ((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).Enabled = isEnabled;
        ((TextBox)CreditCardDetails1.FindControl("BillingZipTextBox")).Enabled = isEnabled;
        ((CustomValidator)CreditCardDetails1.FindControl("CardNumberTextBoxCustomValidator")).Enabled = isEnabled;
    }
    
    

    private void AssignDataSource(ShoppingCartService.ShoppingCartInfo cartInfo)
    {
        if (cartInfo.CartItems.Length > 0)
        {
            CartPanel.Visible = true;
            CartGridView.DataSource = cartInfo.CartItems;
            CartGridView.DataBind();
            SubTotalLiteral.Text = cartInfo.SubTotal.ToString();
            ShippingLiteral.Text = cartInfo.ShippingAndHandling.ToString();
            TaxLiteral.Text = cartInfo.Tax.ToString();
            DiscountLiteral.Text = cartInfo.Discount.ToString();
            GrandTotalLiteral.Text = cartInfo.GrandTotal.ToString();            
        }
    }
    

    private OrderService.OrderInfo AssignOrderInfo(ShoppingCartService.ShoppingCartInfo cartInfo)
    {
        OrderService.OrderInfo orderInfo = new OrderService.OrderInfo();
        orderInfo.CreditCard = new OrderService.CreditCardInfo();
        
        orderInfo.Type = OrderService.OrderType.ShoppingCart;
        orderInfo.Number = 100;
        orderInfo.Date = DateTime.Now;
        List<OrderService.OrderItemInfo> orderItems = new List<OrderService.OrderItemInfo>();
        OrderService.OrderItemInfo orderItem;
        foreach (ShoppingCartService.ShoppingCartItemInfo itemInfo in cartInfo.CartItems)
        {
            orderItem = new OrderService.OrderItemInfo();
            orderItem.ItemId = itemInfo.ProductId;
            orderItem.Quantity = itemInfo.Quantity;
            orderItem.Rate = itemInfo.Price;
            orderItem.Type = OrderService.OrderItemType.Product;
            orderItems.Add(orderItem);
        }
        orderInfo.Items = orderItems.ToArray();
        orderInfo.Amount = cartInfo.GrandTotal;
        ProcessCreditCard processCard = new ProcessCreditCard();
        processCard.CardNumber = ((TextBox)CreditCardDetails1.FindControl("CardNumberTextBox")).Text;
        processCard.ExpiryDate = new DateTime(Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("CardYearDropDownList")).SelectedValue),
            Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("CardMonthDropDownList")).SelectedValue), 1);
        processCard.CvvCode = ((TextBox)CreditCardDetails1.FindControl("CVVNumberTextBox")).Text ;
        string[] names = ((TextBox)CreditCardDetails1.FindControl("CardHolderNameTextBox")).Text.Split(new char[] { ' ' });
        processCard.FirstName = names[0];
        if (names.Length > 1)
            processCard.LastName = names[1];
        processCard.Address1 = ((TextBox)CreditCardDetails1.FindControl("BillingAddress1TextBox")).Text ;
        processCard.Address2 = ((TextBox)CreditCardDetails1.FindControl("BillingAddress2TextBox")).Text ;
        processCard.City =  ((TextBox)CreditCardDetails1.FindControl("BillingCityTextBox")).Text ;
        processCard.State = ((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedItem.Text;
        processCard.Country = ((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).SelectedItem.Text;
        processCard.ZipCode = ((TextBox)CreditCardDetails1.FindControl("BillingZipTextBox")).Text;
        processCard.Amount = orderInfo.Amount;
        processCard.AuthorizeCard();
        orderInfo.TransactionCode = processCard.TransactionId;
        orderInfo.TransactionMessage = processCard.Message;
        orderInfo.TransactionStatus = (processCard.CreditCardStatus == CardStatus.Approved);
        AssignCardInfo(orderInfo.CreditCard);
        return orderInfo;
    }

    private void AssignCardInfo(OrderService.CreditCardInfo creditCardInfo)
    {        
        OrderService.StateInfo billingState = new OrderService.StateInfo();
        billingState.StateId = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedValue);
        billingState.Name = ((DropDownList)CreditCardDetails1.FindControl("BillingStateDropDownList")).SelectedItem.Text;

        OrderService.CountryInfo billingCountry = new OrderService.CountryInfo();
        billingCountry.CountryId = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).SelectedValue);
        billingCountry.Name = ((DropDownList)CreditCardDetails1.FindControl("BillingCountryDropDownList")).SelectedItem.Text;

        OrderService.AddressInfo billingAddress = new OrderService.AddressInfo();
        billingAddress.Address1 = ((TextBox)CreditCardDetails1.FindControl("BillingAddress1TextBox")).Text;
        billingAddress.Address2 = ((TextBox)CreditCardDetails1.FindControl("BillingAddress2TextBox")).Text;
        billingAddress.City = ((TextBox)CreditCardDetails1.FindControl("BillingCityTextBox")).Text;
        billingAddress.State = billingState;
        billingAddress.Zip = ((TextBox)CreditCardDetails1.FindControl("BillingZipTextBox")).Text;
        billingAddress.Country = billingCountry;

        OrderService.LookupInfo creditCardType = new OrderService.LookupInfo();
        creditCardType.LookupId = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("CardTypeDropDownList")).SelectedValue);
        creditCardType.Name = ((DropDownList)CreditCardDetails1.FindControl("CardTypeDropDownList")).SelectedItem.Text;

        creditCardInfo.Type = creditCardType;
        if (((TextBox)CreditCardDetails1.FindControl("CardNumberTextBox")).Text.StartsWith("XXXX"))
            creditCardInfo.Number = CardLabel.Text;
        else
            creditCardInfo.Number = ((TextBox)CreditCardDetails1.FindControl("CardNumberTextBox")).Text;
        creditCardInfo.CvvNumber = ((TextBox)CreditCardDetails1.FindControl("CVVNumberTextBox")).Text;
        creditCardInfo.HolderName = ((TextBox)CreditCardDetails1.FindControl("CardHolderNameTextBox")).Text;
        creditCardInfo.ExpirationMonth = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("CardMonthDropDownList")).SelectedValue);
        creditCardInfo.ExpirationYear = Convert.ToInt32(((DropDownList)CreditCardDetails1.FindControl("CardYearDropDownList")).SelectedValue);
        creditCardInfo.Address = billingAddress;
        
    }

    #endregion
}

#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ShoppingCart.cs
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/04/2007
	* Author			: Irmac Development Team 
	* Comment			: ShoppingCart
	* Source			: Website\Members\ShoppingCart.cs

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
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.ShoppingCart;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
#endregion

public partial class ShoppingCart : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(ShoppingCart));
    
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

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int userId = 0;
            if (!IsAgentRole)
            {
                AgentPanel.Visible = true;
                AgentRFValidator.Enabled = true;
                ListOfAgentsWebUserControl1.FillDropDown();
                //if coming from product list page
                if (Request.QueryString["userId"] != null)
                {
                    userId = Convert.ToInt32(Request.QueryString["userId"]);
                    ListOfAgentsWebUserControl1.SelectedValue = userId.ToString();
                    Session["SelectedAgent"] = ListOfAgentsWebUserControl1.SelectedText;
                    FillCart(userId);
                }
                else
                {
                    CartPanel.Visible = false;
                    CheckOutButton.Enabled = false;
                    RecalculateButton.Enabled = false;
                }
            }
            else
            {
                userId = ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId;
                FillCart(userId);
            }
        }
    }
       
    protected void CheckOutButton_Click(object sender, EventArgs e)
    {
        if (!IsAgentRole)
            Response.Redirect("~/Members/Checkout.aspx?userId=" + Request.QueryString["userId"]);
        else
            Response.Redirect("~/Members/Checkout.aspx");
    }

    protected void GoButton_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int userId = Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
            Session["SelectedAgent"] = ListOfAgentsWebUserControl1.SelectedText;
            FillCart(userId);
        }
    }

    protected void RecalculateButton_Click(object sender, EventArgs e)
    {
        try
        {
            List<ShoppingCartItemInfo> cartItems = new List<ShoppingCartItemInfo>();
            bool isValid = FillCartItemsInfo(cartItems);
            if (isValid)
            {
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                ShoppingCartService shoppingCartService = serviceLoader.GetShoppingCart();
                ShoppingCartInfo cartInfo = shoppingCartService.UpdateCartItem(cartItems.ToArray(), 
                    ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId);
                AssignDataSource(cartInfo);
                ErrorLiteral.Text = "";
            }
        }
        catch (Exception ex)
        {
            log.Error("Error updating the cart", ex);
            ErrorLiteral.Text = "Error updating the cart";
        }
    }

    private bool FillCartItemsInfo(List<ShoppingCartItemInfo> cartItems)
    {
        ShoppingCartItemInfo cartItem;
        int userId = 0;
        if (IsAgentRole)
            userId = ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId;
        else
            userId = Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
        bool isValid = true;
        foreach (GridViewRow gridViewRow in CartGridView.Rows)
        {
            cartItem = new ShoppingCartItemInfo();
            cartItem.ProductId = gridViewRow.Cells[0].Text;
            cartItem.UserId = userId;
            try
            {

                cartItem.Quantity = Convert.ToInt32(((TextBox)gridViewRow.Cells[2].FindControl("QuantityTextBox")).Text);
            }
            catch
            {
                ErrorLiteral.Text = "Please enter a valid quantity";
                ((TextBox)gridViewRow.Cells[2].FindControl("QuantityTextBox")).Focus();
                isValid = false;
                break;
            }
            if (cartItem.Quantity <= 0)
            {
                ErrorLiteral.Text = "Please enter a valid quantity";
                ((TextBox)gridViewRow.Cells[2].FindControl("QuantityTextBox")).Focus();
                isValid = false;
                break;
            }

            cartItem.Price = Convert.ToDecimal(gridViewRow.Cells[3].Text);
            cartItem.Description = ((Label)gridViewRow.Cells[1].FindControl("DescLabel")).Text;
            cartItem.TotalPrice = cartItem.Quantity * cartItem.Price;
            cartItems.Add(cartItem);
        }
        return isValid;
    }

    protected void CartGridView_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "RemoveItem")
        {
            try
            {
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                ShoppingCartService shoppingCartService = serviceLoader.GetShoppingCart();
                int userId = 0;
                if (IsAgentRole)
                    userId = ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId;
                else
                    userId = Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
                ShoppingCartInfo cartInfo = shoppingCartService.DeleteCartItem
                    (userId, CartGridView.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text, 
                    ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId);
                AssignDataSource(cartInfo);
            }
            catch (Exception ex)
            {
                log.Error("Error deleting the cart item", ex);
                ErrorLiteral.Text = "Error deleting the cart item";
            }
        }
    }

    protected void PCodeButton_Click(object sender, EventArgs e)
    {
        try
        {
            ShoppingCartInfo cartInfo = new ShoppingCartInfo();
            List<ShoppingCartItemInfo> cartItems = new List<ShoppingCartItemInfo>();
            FillCartItemsInfo(cartItems);
            cartInfo.CartItems = cartItems.ToArray();
            if (PCodeButton.Text == "Apply")
                cartInfo.PromotionCode = PCodeTextBox.Text;
            else
                cartInfo.PromotionCode = string.Empty;
            cartInfo.SubTotal = Convert.ToDecimal(SubTotalLiteral.Text);
            cartInfo.ShippingAndHandling = Convert.ToDecimal(ShippingLiteral.Text);
            cartInfo.Tax = Convert.ToDecimal(TaxLiteral.Text);
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            ShoppingCartService shoppingCartService = serviceLoader.GetShoppingCart();
            ShoppingCartInfo cartInfo1 = shoppingCartService.GetPromotionDiscount(cartInfo);
            Session["CheckOutDataSource"] = cartInfo1;
            DiscountLiteral.Text = cartInfo1.Discount.ToString();
            GrandTotalLiteral.Text = cartInfo1.GrandTotal.ToString();
            if (PCodeButton.Text == "Apply")
            {
                if (cartInfo1.Discount <= 0)
                    DiscountErrorLiteral.Text = "Invalid promotion code";
                else
                {
                    PCodeButton.Text = "Revoke";
                    DiscountErrorLiteral.Text = "";
                    PCodeTextBox.Enabled = false;
                }
            }
            else
            {
                PCodeButton.Text = "Apply";
                PCodeTextBox.Text = "";
                PCodeTextBox.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            log.Error("Error applying the promotion code", ex);
            ErrorLiteral.Text = "Error applying the promotion code";
        }
    }

    protected void ServerValidation(object source, ServerValidateEventArgs arguments)
    {
        arguments.IsValid = (ListOfAgentsWebUserControl1.SelectedValue != "0");
    }
    #endregion

    # region Methods
    private void FillCart(int userId)
    {
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            ShoppingCartService shoppingCartService = serviceLoader.GetShoppingCart();
            ShoppingCartInfo cartInfo = shoppingCartService.GetCartItems(userId);
            AssignDataSource(cartInfo);
        }
        catch(Exception ex)
        {
            log.Error("Error loading the shopping cart", ex);
            ErrorLiteral.Text = "Error loading shopping cart";
        }
    }

    private void AssignDataSource(ShoppingCartInfo cartInfo)
    {
        if (cartInfo.CartItems.Length > 0)
        {
            CartPanel.Visible = true;
            CheckOutButton.Enabled = true;
            RecalculateButton.Enabled = true;
            CartGridView.DataSource = cartInfo.CartItems;
            CartGridView.DataBind();
            SubTotalLiteral.Text = cartInfo.SubTotal.ToString();
            ShippingLiteral.Text = cartInfo.ShippingAndHandling.ToString();
            TaxLiteral.Text = cartInfo.Tax.ToString();
            GrandTotalLiteral.Text = cartInfo.GrandTotal.ToString();
            Session["CheckOutDataSource"] = cartInfo;
        }
        else
        {
            CartPanel.Visible = false;
            NoRecordsLabel.Text = "There are no products added to the cart";
            NoRecordsLabel.Visible = true;
            NoRecordsTable.Visible = true;
            CheckOutButton.Enabled = false;
            RecalculateButton.Enabled = false;
        }
    }
    #endregion
}

#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: ProductCatalog.aspx.cs
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/04/2007
	* Author			: Irmac Development Team 
	* Comment			: Message
	* Source			: Website\members\ProductCatalog.aspx.cs

	****************************************************************/
#endregion

# region Namespace
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
using Irmac.MailingCycle.BLLServiceLoader.Product;
using Irmac.MailingCycle.BLLServiceLoader;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader.ShoppingCart;
#endregion

/// <summary>
/// Displays list of products
/// </summary>
public partial class ViewProduct : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(ViewProduct));

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
            if (Request.QueryString["ProductId"] != null)
            {
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                ProductService productService = serviceLoader.GetProduct();
                string productId = Request.QueryString["ProductId"];
                ProductInfo dataSource = null;
                try
                {
                    dataSource = productService.GetProductDetails(productId);
                }
                catch (Exception ex)
                {
                    log.Error("Failed to get product details", ex);
                    ErrorLiteral.Text = "Error loading product details";
                }
                if (dataSource != null)
                {
                    Session["SelectedProduct"] = dataSource;
                    ProductIdLabel.Text = "Product Id: " + dataSource.ProductId;
                    BriefDescLabel.Text = dataSource.BriefDescWithQuantity;
                    ExtDescLabel.Text = dataSource.ExtDesc;
                    ProductPriceLabel.Text = "Price: US $ " + dataSource.TotalPrice.ToString();
                    switch (dataSource.ProductItems[0].ProductType.ToLower())
                    {
                        case "powerkard":
                            ProductImage.ImageUrl = "../Images/Powerkard_small.jpg";
                            break;
                        case "brochure":
                            ProductImage.ImageUrl = "../Images/Brochure_small.jpg";
                            break;
                        case "generic product":
                            ProductImage.ImageUrl = "../Images/kit_small.jpg";
                            break;
                        case "envelope":
                            ProductImage.ImageUrl = "../Images/Envelope_small.jpg";
                            break;
                        case "house fliers":
                            ProductImage.ImageUrl = "../Images/Housefliers_small.jpg";
                            break;
                        default:
                            break;
                    }
                }
                if (!IsAgentRole)
                {
                    EditButton.Visible = true;
                    DeleteButton.Visible = true;
                    if (dataSource.ProductStatus == ProductStatus.Active)
                        DeleteButton.Enabled = false;
                    if (dataSource.ProductCatalog == ProductCatalogType.Custom)
                        ShoppingCartButton.Visible = true;
                    else
                        ShoppingCartButton.Visible = false;
                    CustomProductLabel.Visible = false;
                }
                else if (dataSource.ProductCatalog == ProductCatalogType.Custom)
                {
                    ShoppingCartButton.Visible = false;
                    CustomProductLabel.Visible = true;
                }
                else
                {
                    ShoppingCartButton.Visible = true;
                    CustomProductLabel.Visible = false;
                }
                if (dataSource.ProductStatus != ProductStatus.Active)
                {
                    ShoppingCartButton.Visible = false;
                    CustomProductLabel.Visible = true;
                    CustomProductLabel.Text = "This product is not purchasable currently";
                }
            }
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["userId"] == null)
            Response.Redirect("ProductList.aspx?type=" + Request.QueryString["type"] + "&typeName=" + Request.QueryString["typeName"] );
        else
            Response.Redirect("ProductList.aspx?userId=" + Request.QueryString["userId"] + "&type=" + Request.QueryString["type"] + "&typeName=" + Request.QueryString["typeName"]);

    }
    protected void EditButton_Click(object sender, EventArgs e)
    {
        if(Request.QueryString["userId"] != null)
            Response.Redirect("CreateProduct.aspx?fromModify=yes&fromPage=ViewProduct&type=" + Request.QueryString["type"] + "&typeName=" + Request.QueryString["typeName"] + "&userId=" + Request.QueryString["userId"] );
        else
            Response.Redirect("CreateProduct.aspx?fromModify=yes&fromPage=ViewProduct&type=" + Request.QueryString["type"] + "&typeName=" + Request.QueryString["typeName"]);
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        ProductService productService = serviceLoader.GetProduct();
        string productId = Request.QueryString["ProductId"];
        bool success = true;
        try
        {
            success = productService.DeleteProduct(productId, ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId);
        }
        catch (Exception ex)
        {
            log.Error("Error deleting product", ex);
            success = false;
        }
        if (success)
        {
            if (Request.QueryString["userId"] != null)
                Response.Redirect("~/Members/ProductList.aspx?type=" + Request.QueryString["type"] + "&typeName=" + Request.QueryString["typeName"] + "&userId=" + Request.QueryString["userId"]) ;
            else
                Response.Redirect("~/Members/ProductList.aspx?type=" + Request.QueryString["type"] + "&typeName=" + Request.QueryString["typeName"]);
        }
        else
            ErrorLiteral.Text = "Product has already been purchased. It cannot be deleted.";
    }

    protected void AddToCart(object sender, EventArgs e)
    {
        string productId = Request.QueryString["ProductId"];
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        ShoppingCartService shoppingCartService = serviceLoader.GetShoppingCart();
        bool success = true;
        try
        {
            ShoppingCartItemInfo cartInfo = new ShoppingCartItemInfo();
            cartInfo.ProductId = productId;
            if (IsAgentRole)
            {
                cartInfo.UserId = ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId;
            }
            else
                cartInfo.UserId = Convert.ToInt32(Request.QueryString["userId"]);
            cartInfo.Quantity = 1;
            success = shoppingCartService.InsertCartItem(cartInfo, ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId);
            RedirectToShoppingCart();
        }
        catch (Exception ex)
        {
            success = false;
            ErrorLiteral.Text = "Unable to add product to cart. Please try later";
            log.Error("Error adding product to cart", ex);
        }
    }

    private void RedirectToShoppingCart()
    {
        if (!IsAgentRole)
            Response.Redirect("~/Members/ShoppingCart.aspx?userId=" + Request.QueryString["userId"]);
        else
            Response.Redirect("~/Members/ShoppingCart.aspx");
    }

    #endregion
}

#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CreateProduct.aspx.cs
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/04/2007
	* Author			: Irmac Development Team 
	* Comment			: Message
	* Source			: Website\members\CreateProduct.cs

	****************************************************************/
#endregion

#region NameSpace
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
using Irmac.MailingCycle.BLLServiceLoader.Product;
using Irmac.MailingCycle.BLLServiceLoader.ShoppingCart;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader.Design;
#endregion

/// <summary>
/// Displays list of products
/// </summary>
public partial class ProductList : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(ProductList));

    # region Properties
    public bool IsAgentRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Agent);
        }
    }
    public bool IsPrinterRole
    {
        get
        {
            RegistrationService.LoginInfo regInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            return (regInfo.Role == RegistrationService.UserRole.Printer);
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if ((Request.QueryString["type"] != null && Request.QueryString["typeName"] != null ) || Request.QueryString["userId"] != null)
            {
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                ProductService productService = serviceLoader.GetProduct();
                int productTypeId = Int32.MinValue;
                if(Request.QueryString["type"] != null )
                   productTypeId = Convert.ToInt32(Request.QueryString["type"]);
                string productType = Request.QueryString["typeName"];
                SubTitleLiteral.Text = "List Of " + productType;
                try
                {
                    if (IsAgentRole)
                    {
                        int userId = ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId;
                        ProductListGridView.Columns[4].Visible = false;
                        if (productType != "House Fliers")
                            ValidateDesignAndAssignDataSource(productService, productTypeId, userId, productType);
                        else
                        {
                            AssignWithoutDesignValidation(productService, productTypeId, userId);
                        }
                    }
                    else
                    {
                        ProductListGridView.Columns[4].Visible = true;
                        ProductListGridView.Columns[0].Visible = true;
                        if (Request.QueryString["userId"] == null)
                        {
                            AssignWithoutDesignValidation(productService,productTypeId, Int32.MinValue);
                            ProductListGridView.Columns[5].Visible = false;
                            ViewShoppingCartButton.Visible = false;
                        }
                        else
                        {
                            SubTitleLiteral.Text = "List Of Custom Products";
                            int agentId = Convert.ToInt32(Request.QueryString["userId"]);
                            AssignWithoutDesignValidation(productService, productTypeId, agentId);
                            if (IsPrinterRole)
                            {
                                ProductListGridView.Columns[5].Visible = false;
                                ViewShoppingCartButton.Visible = false;
                            }                           

                        }                        
                    }                                         
                }
                catch (Exception ex)
                {
                    log.Error("Error loading product list", ex);
                    ErrorLiteral.Text = "Error loading product list";
                }               
            }
        }
    }

    private void AssignWithoutDesignValidation(ProductService productService, int productTypeId, int userId)
    {
        ProductInfo[] dataSource = productService.GetProducts(productTypeId, userId);
        if (dataSource == null || dataSource.Length == 0)
        {
            NoRecordsLabel.Text = "Products have not yet been added for this product type";
            NoRecordsLabel.Visible = true;
            NoRecordsTable.Visible = true;
        }
        else
        {
            ProductListGridView.DataSource = dataSource;
            ViewState["DataSource"] = ProductListGridView.DataSource;
            ProductListGridView.DataBind();
        }
    }

    private void ValidateDesignAndAssignDataSource(ProductService productService, int productTypeId, int userId,string productType)
    {
        DesignService designService = ServiceAccess.GetInstance().GetDesign();
        DesignInfo[] designs = designService.GetList(userId);
        bool isDesignAvl = true;
        ProductInfo[] dataSource = null;
        if (productType == "Envelope")
            productType = "Brochure";
        foreach (DesignInfo designInfo in designs)
        {           
            if (designInfo.Category.Name == productType && designInfo.Status.Name != "Approved")
            {
                isDesignAvl = false;
                NoRecordsLabel.Text = "You are not seeing any products in this page because either you have not uploaded the design "
                    + "(" + productType + ") file or your design is still being reviewed. Once design is approved, you would have access to the online product listing. Please speak to the customer service at 1-800-XYZ-ABCD if you need further assistance. ";
                NoRecordsLabel.Visible = true;
                NoRecordsTable.Visible = true;
                break;
            }
        }
        if(isDesignAvl)
            dataSource = productService.GetProducts(productTypeId, userId);
        
        if (productType == "Generic Product" && isDesignAvl)
        {            
            List<ProductInfo> productApprovedItems = new List<ProductInfo>();
            bool isApproved = true;
            foreach (ProductInfo productInfo in dataSource)
            {
                isApproved = true;
                if (productInfo.ProductItems != null)
                {
                    if (productInfo.BriefDescWithQuantity.Contains("PowerKard") ||
                        productInfo.BriefDescWithQuantity.Contains("Brochure"))
                    {
                        foreach (DesignInfo designInfo in designs)
                        {
                            if ((designInfo.Category.Name == "PowerKard" || designInfo.Category.Name == "Brochure")
                                && designInfo.Status.Name != "Approved")
                            {                                
                                isApproved = false;
                                break;
                            }
                        }
                    }
                    if (isApproved)
                        productApprovedItems.Add(productInfo);
                }
            }
            dataSource = productApprovedItems.ToArray();
            if (dataSource.Length == 0 && !isApproved)
            {
                NoRecordsLabel.Text = "You are not seeing any products in this page because either you have not uploaded the design "
                    + "(PowerKard or Brochure) file or your design is still being reviewed. Once design is approved, you would have access to the online product listing. Please speak to the customer service at 1-800-XYZ-ABCD if you need further assistance. ";
                NoRecordsLabel.Visible = true;
                NoRecordsTable.Visible = true;
                isDesignAvl = false;
            }
        }
        if (isDesignAvl)
        {            
            if (dataSource == null || dataSource.Length == 0)
            {
                NoRecordsLabel.Text = "Products have not yet been added for this product type";
                NoRecordsLabel.Visible = true;
                NoRecordsTable.Visible = true;
                isDesignAvl = false;
            }
            else
            {
                ProductListGridView.DataSource = dataSource;
                ViewState["DataSource"] = ProductListGridView.DataSource;
                ProductListGridView.DataBind();
            }
        }
    }

    protected void ProductListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandArgument != string.Empty && e.CommandName != string.Empty)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = ProductListGridView.Rows[rowIndex];
            int productTypeId = 0;
            string productId = string.Empty;
            string productType = string.Empty;

            if (Request.QueryString["type"] != null && Request.QueryString["type"] != string.Empty)
                productTypeId = Convert.ToInt32(Request.QueryString["type"]);
            if (selectedRow.Cells[1].Controls[0] != null)
                productId = ((LinkButton)selectedRow.Cells[1].Controls[0]).Text;
            if (Request.QueryString["typeName"] != null && Request.QueryString["typeName"] != string.Empty)
                productType = Request.QueryString["typeName"];

            if (e.CommandName == "ViewProduct")
            {

                if (Request.QueryString["userId"] == null)
                    Response.Redirect("ViewProduct.aspx?type=" + productTypeId.ToString() + "&typeName=" + productType + "&ProductId=" + productId);
                else
                    Response.Redirect("ViewProduct.aspx?userId=" + Request.QueryString["userId"] + "&type=" + productTypeId.ToString() + "&typeName=" + productType + "&ProductId=" + productId);
            }
            else if (e.CommandName == "EditProduct")
            {
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                ProductService productService = serviceLoader.GetProduct();
                try
                {
                    Session["SelectedProduct"] = productService.GetProductDetails(productId);
                    if (Request.QueryString["userId"] == null)
                        Response.Redirect("CreateProduct.aspx?fromModify=yes&fromPage=ProductList" + "&type=" + productTypeId.ToString() + "&typeName=" + productType);
                    else
                        Response.Redirect("CreateProduct.aspx?fromModify=yes&fromPage=ProductList" + "&userId=" + Request.QueryString["userId"]);
                }
                catch (Exception ex)
                {
                    ErrorLiteral.Text = "Error loading product details";
                    log.Error("Error loading product details", ex);
                }
            }
        }
    }

    protected void ViewShoppingCartButton_Click(object sender, EventArgs e)
    {
        RedirectToShoppingCart();
    }

    protected void AddToCart(object sender, EventArgs e)
    {
        string productId = ((Button)sender).CommandArgument;
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

    protected void ProductListGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            ProductInfo info = (ProductInfo)e.Row.DataItem;
            string productType = Request.QueryString["typeName"];
            
            //For Non-Agents, show product status, disable add to cart if product not active
            if (!IsAgentRole)
            {
                e.Row.Cells[4].Text = info.ProductStatus.ToString();
                if (info.ProductStatus != ProductStatus.Active)
                    ((Button)e.Row.Cells[5].FindControl("AddToCartButton")).Enabled = false;
            }
            //For agents, custom products cannot be purchased directly
            if (info.ProductCatalog == ProductCatalogType.Custom && IsAgentRole)
            {
                ((Button)e.Row.Cells[5].FindControl("AddToCartButton")).Visible = false;
                ((Label)e.Row.Cells[5].FindControl("CustomProductLabel")).Visible = true;
            }
            else
            {
                ((Button)e.Row.Cells[5].FindControl("AddToCartButton")).Visible = true;
                ((Label)e.Row.Cells[5].FindControl("CustomProductLabel")).Visible = false;
            }
            //Agents cannot purchase "On Hold" products.
            if (IsAgentRole && info.ProductStatus == ProductStatus.OnHold)
            {
                ((Button)e.Row.Cells[5].FindControl("AddToCartButton")).Visible = false;
                ((Label)e.Row.Cells[5].FindControl("CustomProductLabel")).Visible = true;
                ((Label)e.Row.Cells[5].FindControl("CustomProductLabel")).Text = "This product is not purchasable currently";
            }
        }
    }
    #endregion
    
}

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

#region Namespace
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
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Product;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
#endregion

/// <summary>
/// Displays the list of product catalogs
/// </summary>
public partial class ProductCatalog : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(ProductCatalog));

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
            Session["TimeStamp"] = null;
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            ProductService productService = serviceLoader.GetProduct();
            try
            {
                ProductListDataList.DataSource = productService.GetProductItems();
                ProductListDataList.DataBind();
            }
            catch (Exception ex)
            {
                log.Error("Error loading products", ex);
                ErrorLiteral.Text = "Error loading products";
            }
            if (!IsAgentRole)
            {
                AgentPanel.Visible = true;
                AddPanel.Visible = true;
                try
                {
                    ListOfAgentsWebUserControl1.FillDropDown();
                }
                catch (Exception ex)
                {
                    ErrorLiteral.Text = "Unable to load the agents list";
                    log.Error("Unknown error", ex);
                }
                AgentRFValidator.Enabled = true;
            }
        }
    }
    protected void ProductListDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        ProductItemInfo itemInfo = (ProductItemInfo)e.Item.DataItem;
        if (itemInfo != null)
        {
            HyperLink productLink = (HyperLink)e.Item.FindControl("ProductHyperLink");
            Literal productText = (Literal)e.Item.FindControl("ProductTypeLiteral");
            Image productImage = (Image)e.Item.FindControl("ProductImage");
            productText.Text = itemInfo.ProductType;
            productLink.NavigateUrl = "ProductList.aspx?type=" + itemInfo.ProductTypeId.ToString() + "&typeName=" + itemInfo.ProductType;
            switch (itemInfo.ProductType.ToLower())
            {
                case "powerkard":
                    productImage.ImageUrl = "../Images/Powerkard_small.jpg";                    
                    break;
                case "brochure":
                    productImage.ImageUrl = "../Images/Brochure_small.jpg";
                    break;
                case "generic product":
                    productImage.ImageUrl = "../Images/kit_small.jpg";
                    break;
                case "envelope":
                    productImage.ImageUrl = "../Images/Envelope_small.jpg";
                    break;
                case "house fliers":
                    productImage.ImageUrl = "../Images/Housefliers_small.jpg";
                    break;
                default:
                    break;
            }
        }

    }
    protected void GoButton_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Session["SelectedAgent"] = ListOfAgentsWebUserControl1.SelectedText;
            Response.Redirect("ProductList.aspx?userId=" + ListOfAgentsWebUserControl1.SelectedValue);
        }
    }

    protected void ServerValidation(object source, ServerValidateEventArgs arguments)
    {
        arguments.IsValid = (ListOfAgentsWebUserControl1.SelectedValue != "0");
    }
    #endregion
}

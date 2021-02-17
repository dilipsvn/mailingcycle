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

# region Namespace
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
using Irmac.MailingCycle.BLLServiceLoader.Product;
using Irmac.MailingCycle.BLLServiceLoader;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLLServiceLoader.Design;
using log4net;
# endregion

public partial class CreateProduct : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(CreateProduct));

    # region Properties
    private bool IsFromModifyPage
    {
        get
        {
            return (Convert.ToString(Request.QueryString["fromModify"]) == "yes");
        }
    }
    #endregion

    # region events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            ProductService productService = serviceLoader.GetProduct();
            FillListFromEnum(ProductCatalogDropDownList, typeof(ProductCatalogType));
            ProductCatalogDropDownList.Items.Insert(0, "<Select a product type>");
            try
            {
                ProductListGridView.DataSource = productService.GetProductItems();
                ProductListGridView.DataBind();
            }
            catch(Exception ex)
            {
                log.Error("Error loading product line items", ex);
                ErrorLiteral.Text = "Error loading product line items";
            }

            if (IsFromModifyPage)
            {
                ActivateButton.Visible = true;
                HoldButton.Visible = true;
                ObsoleteButton.Visible = true;
                ProductIdTextBox.Enabled = false;
                SubTitleLiteral.Text = "Please modify Product details in the below form";
                FillDetailsForModify();
            }
            else
            {
                StatusPanel.Visible = false;
            }
        }
       
        

    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bool success = false;
            try
            {
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                ProductService productService = serviceLoader.GetProduct();
                ProductInfo productInfo = new ProductInfo();
                if (ProductCatalogDropDownList.SelectedItem.Text == ProductCatalogType.Custom.ToString())
                    ListOfAgentsWebUserControlRFValidator.Validate();
                if (IsValid)
                {
                    //For hold button and obsolete button, update only the status
                    switch (((Button)sender).CommandName)
                    {
                        case "Hold":
                            productInfo = (ProductInfo)Session["SelectedProduct"];
                            productInfo.ProductStatus = ProductStatus.OnHold;

                            break;
                        case "Activate":
                            productInfo.ProductStatus = ProductStatus.Active;
                            AssignValuesToDataItem(productInfo);
                            break;
                        case "Obsolete":
                            productInfo = (ProductInfo)Session["SelectedProduct"];
                            productInfo.ProductStatus = ProductStatus.Obsolete;
                            break;
                        default:
                            if (!IsFromModifyPage)
                                productInfo.ProductStatus = ProductStatus.Inactive;
                            else
                                productInfo.ProductStatus = (ProductStatus)ViewState["Status"];
                            AssignValuesToDataItem(productInfo);
                            break;
                    }
                    productInfo.OwnerId = ((RegistrationService.LoginInfo)Session["loginInfo"]).UserId;
                    if (IsFromModifyPage)
                    {
                        success = productService.UpdateProductDetails(productInfo);
                    }
                    else
                        success = productService.InsertProduct(productInfo);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error saving product", ex);
                success = false;
            }
            if (success)
            {
                if (IsFromModifyPage)
                {
                    if (Request.QueryString["userId"] != null)
                        RedirectPage("?userId=" + Request.QueryString["userId"] + "&ProductId=" + ProductIdTextBox.Text);
                    else
                        RedirectPage("?type=" + Request.QueryString["type"] + "&typeName=" + Request.QueryString["typeName"] + "&ProductId=" + ProductIdTextBox.Text);
                }
                else
                    RedirectPage(string.Empty);
            }
            else
                ErrorLiteral.Text = "Product could not be saved. Please try again later.";
        }
    }

    private void AssignValuesToDataItem(ProductInfo productInfo)
    {
        productInfo.ProductId = ProductIdTextBox.Text;
        productInfo.BriefDesc = BriefDescTextBox.Text;
        productInfo.ExtDesc = ExtDescTextBox.Text;
        productInfo.ProductCatalog = (ProductCatalogType)Convert.ToInt32(ProductCatalogDropDownList.SelectedValue);

        List<ProductItemInfo> productItems = new List<ProductItemInfo>();
        DataGridItem gridItem1 = null;
        foreach (DataGridItem gridItem in ProductListGridView.Items)
        {
            ProductItemInfo itemInfo = new ProductItemInfo();
            if (((TextBox)gridItem.FindControl("QuantityTextBox")).Text != string.Empty)
            {
                if(gridItem.FindControl("CustomSizeCheckBox") != null)
                    itemInfo.IsCustomSize = ((CheckBox)gridItem.FindControl("CustomSizeCheckBox")).Checked;
                itemInfo.ProductType = gridItem.Cells[1].Text;
                itemInfo.ProductTypeId = Convert.ToInt32(gridItem.Cells[0].Text);

                string[] size = new string[1]; { };
                if (ProductCatalogDropDownList.SelectedValue == ((int)ProductCatalogType.Custom).ToString())
                    itemInfo.AgentUserId = Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
                if (itemInfo.IsCustomSize && gridItem.FindControl("SizeText1") != null)
                {
                    itemInfo.AgentUserId = Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
                    size[0] = ((TextBox)gridItem.FindControl("SizeText1")).Text + " X " + ((TextBox)gridItem.FindControl("SizeText2")).Text;
                }
                else if (gridItem.FindControl("SizeDropDownList") != null &&
                    ((DropDownList)gridItem.FindControl("SizeDropDownList")).SelectedIndex != -1)
                    size[0] = ((DropDownList)gridItem.FindControl("SizeDropDownList")).SelectedItem.Text;
                itemInfo.Size = size;

                itemInfo.Quantity = Convert.ToInt32(((TextBox)gridItem.FindControl("QuantityTextBox")).Text);
                productItems.Add(itemInfo);
            }
            gridItem1 = gridItem;
        }
        if (IsFromModifyPage)
        {
            ProductInfo productSourceInfo = (ProductInfo)Session["SelectedProduct"];
            foreach (ProductItemInfo productItemInfo in productSourceInfo.ProductItems)
            {
                bool itemExists = false;
                foreach (ProductItemInfo productItemInfo1 in productItems)
                {
                    if (productItemInfo.ProductType == productItemInfo1.ProductType)
                    {
                        itemExists = true;
                        break;
                    }
                }
                if (!itemExists)
                {
                    productItemInfo.Quantity = 0;
                    productItems.Add(productItemInfo);
                }
            }
        }
        productInfo.ProductItems = productItems.ToArray();        
        productInfo.TotalPrice = Convert.ToDecimal(FinalPriceTextBox.Text);
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        if (IsFromModifyPage)
        {
            if (Request.QueryString["userId"] != null)
                RedirectPage("?userId=" + Request.QueryString["userId"] + "&ProductId=" + ProductIdTextBox.Text);
            else
                RedirectPage("?type=" + Request.QueryString["type"] + "&typeName=" + Request.QueryString["typeName"] + "&ProductId=" + ProductIdTextBox.Text);
        }
        else
            RedirectPage(string.Empty);
    }

    protected void ProductCatalogDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ProductCatalogDropDownList.SelectedValue) == Convert.ToInt32(ProductCatalogType.Custom))
        {
            if (!AgentPanel.Visible)
            {
                AgentPanel.Visible = true;
                ListOfAgentsWebUserControl1.FillDropDown();
                ListOfAgentsWebUserControlRFValidator.Enabled = true;
            }
        }
        else
        {
            AgentPanel.Visible = false;
            ListOfAgentsWebUserControlRFValidator.Enabled = false;
            foreach (DataGridItem dataGridItem in ProductListGridView.Items)
            {
                if (dataGridItem.Cells[2].FindControl("CustomSizeCheckBox") != null)
                {
                    ((CheckBox)dataGridItem.Cells[2].FindControl("CustomSizeCheckBox")).Checked = false;
                    if (((DropDownList)dataGridItem.Cells[3].FindControl("SizeDropDownList")).Items.Count > 0)
                        ((Panel)dataGridItem.Cells[3].FindControl("SizeDropDownPanel")).Visible = true;
                    ((Panel)dataGridItem.Cells[3].FindControl("SizePanel")).Visible = false;
                }
            }
        }

    }

    protected void ProductListGridView_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        ProductItemInfo itemInfo = (ProductItemInfo)e.Item.DataItem;
        if (itemInfo != null)
        {
            if (itemInfo.Size.Length <= 0)
            {
                ((Panel)e.Item.FindControl("SizeDropDownPanel")).Visible = false;
                ((CheckBox)e.Item.FindControl("CustomSizeCheckBox")).Visible = false;
                ((Label)e.Item.FindControl("NAPanel")).Visible = true;
            }
        }
    }

    protected void customCheck_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox customCheck = (CheckBox)sender;
        DataGridItem gridItem = (DataGridItem)customCheck.Parent.Parent;
        if (gridItem != null)
        {
            Panel sizePanel = (Panel)gridItem.FindControl("SizePanel");
            Panel sizeDropDownPanel = (Panel)gridItem.FindControl("SizeDropDownPanel");
            if (customCheck.Checked)
            {
                sizePanel.Visible = true;
                sizeDropDownPanel.Visible = false;
                ProductCatalogDropDownList.SelectedValue = (Convert.ToInt32(ProductCatalogType.Custom)).ToString();
                ProductCatalogDropDownList_SelectedIndexChanged(sender, e);
            }
            else
            {
                sizePanel.Visible = false;
                sizeDropDownPanel.Visible = true;
                ListOfAgentsWebUserControlRFValidator.Enabled = false;
                bool moreChecked = false;
                foreach (DataGridItem dataGridItem in ProductListGridView.Items)
                {
                    if (((CheckBox)dataGridItem.Cells[2].FindControl("CustomSizeCheckBox")).Checked)
                    {
                        moreChecked = true;
                        break;
                    }
                }
                if (!moreChecked)
                {
                    ProductCatalogDropDownList.SelectedValue = (Convert.ToInt32(ProductCatalogType.Standard)).ToString();
                    ProductCatalogDropDownList_SelectedIndexChanged(sender, e);
                }
            }
        }
    }

    #endregion

    # region Methods
    private void FillDetailsForModify()
    {
        ProductInfo productInfo = (ProductInfo)Session["SelectedProduct"];
        if (productInfo != null)
        {
            BriefDescTextBox.Text = productInfo.BriefDesc;
            ExtDescTextBox.Text = productInfo.ExtDesc;
            ProductIdTextBox.Text = productInfo.ProductId;
            ProductStatusLabel.Text = productInfo.ProductStatus.ToString();
            ViewState["Status"] = productInfo.ProductStatus;
            if (productInfo.ProductStatus == ProductStatus.Obsolete)
            {
                SaveButton.Enabled = false;
                ActivateButton.Enabled = false;
                ObsoleteButton.Enabled = false;
                HoldButton.Enabled = false;
            }
            FinalPriceTextBox.Text = productInfo.TotalPrice.ToString();
            if (productInfo.ProductItems.Length > 1)
                ProductCatalogDropDownList.SelectedValue = ((int)ProductCatalogType.Generic).ToString();
            else
                ProductCatalogDropDownList.SelectedValue = ((int)ProductCatalogType.Standard).ToString();
            if (productInfo.ProductStatus == ProductStatus.Active)
            {
                ProductCatalogDropDownList.Enabled = false;
                ProductListGridView.Enabled = false;
                FinalPriceTextBox.Enabled = false;
            }
            foreach (DataGridItem gridItem in ProductListGridView.Items)
            {
                foreach (ProductItemInfo itemInfo in productInfo.ProductItems)
                {
                    if (gridItem.Cells[0].Text == itemInfo.ProductTypeId.ToString())
                    {
                        if (itemInfo.IsCustomSize)
                        {
                            if (itemInfo.Size.Length > 0 && ((DropDownList)gridItem.FindControl("SizeDropDownList")).Items.FindByText(itemInfo.Size[0]) == null)
                            {
                                ((CheckBox)gridItem.Cells[2].FindControl("CustomSizeCheckBox")).Checked = true;
                                ((Panel)gridItem.Cells[2].FindControl("SizePanel")).Visible = true;
                                ((Panel)gridItem.Cells[2].FindControl("SizeDropDownPanel")).Visible = false;
                                ((TextBox)gridItem.Cells[2].FindControl("SizeText1")).Text = itemInfo.Size[0].Split(new char[] { 'X' })[0];
                                ((TextBox)gridItem.Cells[2].FindControl("SizeText2")).Text = itemInfo.Size[0].Split(new char[] { 'X' })[1];
                                if (productInfo.ProductStatus == ProductStatus.Active)
                                {
                                    ((TextBox)gridItem.Cells[2].FindControl("SizeText1")).Enabled = false;
                                    ((TextBox)gridItem.Cells[2].FindControl("SizeText2")).Enabled = false;
                                }
                            }
                            ProductCatalogDropDownList.SelectedValue = ((int)ProductCatalogType.Custom).ToString();
                            AgentPanel.Visible = true;
                            ListOfAgentsWebUserControl1.FillDropDown();
                            ListOfAgentsWebUserControl1.SelectedValue = itemInfo.AgentUserId.ToString();
                            
                        }
                        if (itemInfo.Size.Length > 0 && ((DropDownList)gridItem.FindControl("SizeDropDownList")).Items.FindByText(itemInfo.Size[0]) != null)
                        {
                            ((Panel)gridItem.Cells[2].FindControl("SizePanel")).Visible = false;
                            ((Panel)gridItem.Cells[2].FindControl("SizeDropDownPanel")).Visible = true;
                            ((DropDownList)gridItem.FindControl("SizeDropDownList")).SelectedValue = itemInfo.Size[0];                          
                        }
                        ((TextBox)gridItem.Cells[2].FindControl("QuantityTextBox")).Text = itemInfo.Quantity.ToString();
                    }                    
                }
            }
        }
    }

    
     
    private void FillListFromEnum(DropDownList dropDownList, Type enumObject)
    {
        string[] enumNames = Enum.GetNames(enumObject);        
        int arrCount = 0;
        while (arrCount < enumNames.Length)
        {
            dropDownList.Items.Add(new ListItem(enumNames[arrCount], arrCount.ToString()));
            arrCount++;
        }
    }

    protected void ValidateAgents(object source, ServerValidateEventArgs arguments)
    {
        arguments.IsValid = (ListOfAgentsWebUserControl1.SelectedValue != "0");
    }

    protected void CheckProductId(object source, ServerValidateEventArgs arguments)
    {
        if (!IsFromModifyPage)
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            ProductService productService = serviceLoader.GetProduct();
            if (productService.GetProductDetails(arguments.Value) != null)
                arguments.IsValid = false;
        }
    }   

    protected void ValidateProductTypes(object source, ServerValidateEventArgs arguments)
    {
        int noItemAdded = 0;
        int noCustomProd = 0;
        DesignInfo[] designs = null;
        
        if (ProductCatalogDropDownList.SelectedItem.Text == ProductCatalogType.Custom.ToString())
        {
            ListOfAgentsWebUserControlRFValidator.Validate();
            if (IsValid)
            {
                DesignService designService = ServiceAccess.GetInstance().GetDesign();
                designs = designService.GetList(Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue));
            }
        }
        foreach (DataGridItem gridItem in ProductListGridView.Items)
        {
            bool isCustomSize = ((CheckBox)gridItem.FindControl("CustomSizeCheckBox")).Checked;
            string quantity = ((TextBox)gridItem.FindControl("QuantityTextBox")).Text.Trim();
            if (isCustomSize)
            {
                noCustomProd++;
                if (((TextBox)gridItem.FindControl("SizeText1")).Text.Trim() == string.Empty ||
                    ((TextBox)gridItem.FindControl("SizeText2")).Text.Trim() == string.Empty)
                {
                    ProductListGridViewCustomValidator.ErrorMessage = "Please enter a valid size";
                    arguments.IsValid = false;
                    break;
                }
                if (designs != null)
                {
                    foreach (DesignInfo designInfo in designs)
                    {
                        if (designInfo.Category.Name == gridItem.Cells[1].Text)
                        {
                            if (designInfo.Type.Name != "Custom")
                            {
                                ProductListGridViewCustomValidator.ErrorMessage = "Agent does not have a custom " 
                                    + designInfo.Category.Name + " defined";
                                arguments.IsValid = false;
                            }
                        }
                    }
                }
                
            }            
            else if (quantity != string.Empty)
            {
                try
                {
                    int dummyInt = Convert.ToInt32(quantity);
                    if (dummyInt <= 0)
                    {
                        ProductListGridViewCustomValidator.ErrorMessage = "Please enter a valid quantity";
                        arguments.IsValid = false;
                        break;
                    }
                }
                catch
                {
                    ProductListGridViewCustomValidator.ErrorMessage = "Please enter a valid quantity";
                    arguments.IsValid = false;
                    break;
                }
            }
            if (quantity != string.Empty) 
                noItemAdded++;

        }
        if (noItemAdded == 0 && arguments.IsValid)
        {
            ProductListGridViewCustomValidator.ErrorMessage = "Please enter quantity for atleast one product type";
            arguments.IsValid = false;
        }
        try
        {
            Convert.ToDecimal(FinalPriceTextBox.Text);
        }
        catch
        {
            ProductListGridViewCustomValidator.ErrorMessage = "Please enter a valid price";
            arguments.IsValid = false;
        }
        if(arguments.IsValid && Convert.ToDecimal(FinalPriceTextBox.Text) < 0 )
        {
            ProductListGridViewCustomValidator.ErrorMessage = "Please enter a valid price";
            arguments.IsValid = false;
        }
        if (ProductCatalogDropDownList.SelectedItem.Text == ProductCatalogType.Custom.ToString() && noCustomProd == 0)
        {
            ProductListGridViewCustomValidator.ErrorMessage = "Please enter a custom size for atleast one product type";
            arguments.IsValid = false;
        }
        if (ProductCatalogDropDownList.SelectedItem.Text == ProductCatalogType.Generic.ToString() && noItemAdded == 1)
        {
            ProductListGridViewCustomValidator.ErrorMessage = "Please select more than one product type for generic products";
            arguments.IsValid = false;
        }

    }

    private void RedirectPage(string queryString)
    {
        string redirectPage = Convert.ToString(Request.QueryString["fromPage"]);
        string redirectUrl;
        switch (redirectPage)
        {
            case "ProductList":
                redirectUrl = "~/Members/ProductList.aspx" + queryString;
                break;
            case "ViewProduct":
                redirectUrl = "~/Members/ViewProduct.aspx" + queryString;
                break;
            default:
                redirectUrl = "~/Members/ProductCatalog.aspx" + queryString;
                break;
        }
        Response.Redirect(redirectUrl);
    }
    #endregion
}

using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;
using System.Collections.Generic;


/// <summary>
/// Summary description for ProductService
/// </summary>
[WebService(Namespace = "http://localhost:3555/BLLService/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ProductService : System.Web.Services.WebService
{

    public ProductService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<ProductItemInfo> GetProductItems()
    {
        Product bll = new Product();
        return bll.GetProductItems();
    }

    [WebMethod]
    public bool InsertProduct(ProductInfo productInfo)
    {
        Product bll = new Product();
        return bll.InsertProduct(productInfo);
    }

    [WebMethod]
    public List<ProductInfo> GetProducts(int productTypeId,int agentUserId)
    {
        Product bll = new Product();
        return bll.GetProducts(productTypeId,agentUserId);
    }

    [WebMethod]
    public ProductInfo GetProductDetails(string productId)
    {
        Product bll = new Product();
        return bll.GetProductDetails(productId);
    }

    [WebMethod]
    public bool UpdateProductDetails(ProductInfo productInfo)
    {
        Product bll = new Product();
        return bll.UpdateProduct(productInfo);
    }

    [WebMethod]
    public bool DeleteProduct(string productId,int userId)
    {
        Product bll = new Product();
        return bll.DeleteProduct(productId, userId);
    }

    [WebMethod]
    public List<ProductItemInfo> GetInventoryTotalCount(int agentUserId)
    {
        Product bll = new Product();
        return bll.GetInventoryTotalCount(agentUserId);
    }
}


using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.BLL;


/// <summary>
/// Summary description for ShoppingCartService
/// </summary>
[WebService(Namespace = "http://localhost:3555/BLLService/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ShoppingCartService : System.Web.Services.WebService
{

    public ShoppingCartService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ShoppingCartInfo GetCartItems(int userId)
    {
        ShoppingCart bll = new ShoppingCart();
        return bll.GetCartItems(userId);
    }

    [WebMethod]
    public bool InsertCartItem(ShoppingCartItemInfo cartInfo,int ownerId)
    {
        ShoppingCart bll = new ShoppingCart();
        return bll.InsertCartItem(cartInfo,ownerId);
    }

    [WebMethod]
    public ShoppingCartInfo UpdateCartItem(List<ShoppingCartItemInfo> cartInfo,int ownerId)
    {
        ShoppingCart bll = new ShoppingCart();
        return bll.UpdateCartItem(cartInfo,ownerId);
    }

    [WebMethod]
    public ShoppingCartInfo DeleteCartItem(int userId, string productId,int ownerId)
    {
        ShoppingCart bll = new ShoppingCart();
        return bll.DeleteCartItem(userId,productId,ownerId);
    }
         
    [WebMethod]
    public ShoppingCartInfo GetPromotionDiscount(ShoppingCartInfo cartInfo)
    {
        ShoppingCart bll = new ShoppingCart();
        bll.GetPromotionDiscount(cartInfo);
        return cartInfo;
    }

    [WebMethod]
    public ShoppingCartInfo CalculateGrandTotal(ShoppingCartInfo cartInfo)
    {
        ShoppingCart bll = new ShoppingCart();
        bll.CalculateGrandTotal(cartInfo);
        return cartInfo;
    }
}


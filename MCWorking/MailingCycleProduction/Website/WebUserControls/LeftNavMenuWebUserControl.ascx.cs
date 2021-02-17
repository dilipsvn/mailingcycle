#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: LeftNavMenuWebusercontrol.aspx
    * Created Date      : 22/Nov/2007
	* Last Modify Date  : 22/Nov/2007
	* Author			: Irmac Development Team 
	* Comment			: Master Page 
	* Source			: MailingCycle\Webusercontrols\LeftNavMenuWebusercontrol.aspx.cs

	****************************************************************/
#endregion

#region Namespaces

using System;
using System.Data.SqlClient;
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
using Irmac.MailingCycle.Model;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
#endregion


public partial class WebUserControls_LeftNavMenuWebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["loginInfo"] == null || Session["loginInfo"].ToString() == "")
                if (Request.Url.AbsolutePath.ToUpper().Contains("ABOUTUS.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("CONTACTUS.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("FEEDBACK.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("SITEMAP.ASPX"))
                {
                    MenuePanelWhenLogin.Visible = false;
                    MenuePanelTextWhenNotLogin.Visible = true;
                }
                else
                {
                    Response.Redirect("~/userLogin.aspx?Message=SessionExpired");
                }
            else
            {
                MenuePanelWhenLogin.Visible = true;
                MenuePanelTextWhenNotLogin.Visible = false;
                RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
                switch (loginInfo.Role)
                {
                    case RegistrationService.UserRole.Agent:
                        a_UserManagement.Visible = false;
                        a_ProductManagement.Visible = false;
                        a_AuditTrail.Visible = false;
                        a_OrderManagement.Visible = false;
                        a_ChangeRegistrationFee.Visible = false;
                        a_PrinterReports.Visible = false;
                        break;
                    case RegistrationService.UserRole.Printer:
                        //a_UserManagement.Visible = false;
                        a_ProductCatalog.Visible = false;
                        a_ProductManagement.Visible = false;
                        a_ChangeRegistrationFee.Visible = false;
                        a_ShoppingCart.Visible = false;
                        a_SearchOrders.Visible = false;
                        a_AgentReports.Visible = false;
                        a_ChangeCreditCard.Visible = false;
                        break;
                    case RegistrationService.UserRole.CSR:
                        //a_UserManagement.Visible = false;
                        a_ProductCatalog.Visible = false;
                        a_SearchOrders.Visible = false;
                        a_AgentReports.Visible = false;
                        a_ChangeCreditCard.Visible = false;
                        break;
                    case RegistrationService.UserRole.Admin:
                        a_ProductCatalog.Visible = false;
                        a_SearchOrders.Visible = false;
                        a_AgentReports.Visible = false;
                        a_ChangeCreditCard.Visible = false;
                        break;

                }
            }
            
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Default.aspx?msg=" + ex.Message);
        }
    }
}

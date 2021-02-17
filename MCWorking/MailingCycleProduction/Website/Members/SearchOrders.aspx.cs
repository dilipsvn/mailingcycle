#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: SearchOrders.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to search orders
	* Source			: MailingCycle\SearchOrders.aspx.cs

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
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Common;
using System.Collections.Generic;
using Irmac.MailingCycle.BLLServiceLoader.Order;
using Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
#endregion

public partial class SearchOrders : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(SearchOrders));

    # region Properties
    public bool IsAgentRole
    {
        get
        {
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            return (regInfo.Role == Irmac.MailingCycle.BLLServiceLoader.Registration.UserRole.Agent);
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                CommonService commonService = ServiceAccess.GetInstance().GetCommon();
                IList<Irmac.MailingCycle.BLLServiceLoader.Common.LookupInfo> cardTypes = commonService.GetLookups("Credit Card Type");

                CardTypeDropDownList.DataSource = cardTypes;
                CardTypeDropDownList.DataValueField = "LookupId";
                CardTypeDropDownList.DataTextField = "Name";
                CardTypeDropDownList.DataBind();
            }
            catch (Exception ex)
            {
                log.Error("Error loading credit card types", ex);
                ErrorLiteral.Text = "Error loading credit card types";
            }
            StartDateLink.HRef = "javascript: NewCal('" + StartDateTextBox.ClientID +"','mmddyyyy')";
            EndDateLink.HRef = "javascript: NewCal('" + EndDateTextBox.ClientID + "','mmddyyyy')";
            if (!IsAgentRole)
            {
                try
                {
                    AgentPanel.Visible = true;
                    ListOfAgentsWebUserControl1.FillDropDown();
                    ((Label)ListOfAgentsWebUserControl1.FindControl("SelectLabel")).Visible = false;
                }
                catch (Exception ex)
                {
                    log.Error("Error loading agents", ex);
                    ErrorLiteral.Text = "Error loading agents";
                }
            }
        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        OrderService orderService = ServiceAccess.GetInstance().GetOrder();
        int orderId = OrderIdTextBox.Text == string.Empty ? Int32.MinValue : Convert.ToInt32(OrderIdTextBox.Text);
        int cardType = CardTypeDropDownList.SelectedIndex == 0 ? Int32.MinValue : Convert.ToInt32(CardTypeDropDownList.SelectedValue);
        DateTime startDate = StartDateTextBox.Text == string.Empty ? DateTime.MinValue : Convert.ToDateTime(StartDateTextBox.Text);
        DateTime endDate = EndDateTextBox.Text == string.Empty ? DateTime.MinValue : Convert.ToDateTime(EndDateTextBox.Text);
        LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
        int userId = regInfo.UserId;
        if (!IsAgentRole)
            userId = ListOfAgentsWebUserControl1.SelectedValue == "0" ? Int32.MinValue : Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
        try
        {
            OrderInfo[] searchResults = orderService.GetSearchOrders(userId, orderId, cardType, startDate, endDate);
            Session["SearchResults"] = searchResults;
            if (!IsAgentRole && ListOfAgentsWebUserControl1.SelectedValue != "0")
                Response.Redirect("BillingHistory.aspx?isFromSearch=yes&userId=" + ListOfAgentsWebUserControl1.SelectedValue);
            else
                Response.Redirect("BillingHistory.aspx?isFromSearch=yes");
        }
        catch (Exception ex)
        {
            log.Error("Error searching orders", ex);
            ErrorLiteral.Text = "Error searching orders";
        }
    }
}

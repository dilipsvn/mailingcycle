#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: BillingHistory.aspx
    * Created Date      : 10/04/2007
	* Last Modify Date  : 10/22/2007
	* Author			: Irmac Development Team 
	* Comment			: Page is used to view billing history
	* Source			: MailingCycle\BillingHistory.aspx.cs

	****************************************************************/
#endregion

# region Namespaces
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
using Irmac.MailingCycle.BLLServiceLoader.Order;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Registration;
using log4net;
#endregion


public partial class BillingHistory : System.Web.UI.Page
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(BillingHistory));

    # region Properties
    public bool IsAgentRole
    {
        get
        {
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            return (regInfo.Role == UserRole.Agent);
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int userId = 0;
            if (Request.QueryString["isFromSearch"] != null)
            {
                OrderInfo[] dataSource = (OrderInfo[])Session["SearchResults"];
                
                if (dataSource.Length == 0)
                {
                    NoRecordsTable.Visible = true;
                }
                else
                {
                    NoRecordsTable.Visible = false;
                    BillingGridView.DataSource = dataSource;
                    Session["BillingInfo"] = BillingGridView.DataSource;
                    BillingGridView.DataBind();
                }
                BillingGridView.DataBind();
                TitleLiteral.Text = "Orders result - " + dataSource.Length + " order(s) found";
                SubTitleLiteral.Text = "Search results";
                BackButton.Visible = true;
                if (!IsAgentRole)
                {
                    BillingGridView.Columns[1].Visible = true;                    
                }
            }
            else
            {
                Session["BillingInfo"] = null;
                if (!IsAgentRole)
                {
                    AgentPanel.Visible = true;
                    ListOfAgentsWebUserControl1.FillDropDown();
                    if (Request.QueryString["userId"] != null)
                    {
                        ListOfAgentsWebUserControl1.SelectedValue = Request.QueryString["userId"];
                        FillGridView(Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue));
                    }
                }
                else
                {
                    LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
                    userId = regInfo.UserId;
                    FillGridView(userId);
                }
            }
        }        
    }

    protected void BillingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewTransaction")
        {

            string redirectUrl = "OrderDetails.aspx?itemSelected=" + ((LinkButton)BillingGridView.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[0]).Text;
            if (!IsAgentRole && ListOfAgentsWebUserControl1.SelectedValue != "0")
                redirectUrl += "&userId=" + ListOfAgentsWebUserControl1.SelectedValue;
            if (Request.QueryString["isFromSearch"] != null)
                redirectUrl += "&isFromSearch=yes";
            Response.Redirect(redirectUrl);
        }
    }

    protected void GoButton_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int userId = Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
            Session["SelectedAgent"] = ListOfAgentsWebUserControl1.SelectedText;
            FillGridView(userId);
        }
    }

    protected void BillingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            OrderInfo orderInfo = (OrderInfo)e.Row.DataItem;
            e.Row.Cells[2].Text = orderInfo.Date.ToShortDateString();
            e.Row.Cells[3].Text = orderInfo.Type.ToString();
            if (orderInfo.Type == OrderType.ShoppingCart)
                e.Row.Cells[3].Text = "Purchased";
            e.Row.Cells[4].Text = orderInfo.CreditCard.Type.Name;
            e.Row.Cells[1].Text = orderInfo.UserName;
            if (orderInfo.CreditCard.Number.Length > 4)
                e.Row.Cells[5].Text = "XXXX-XXXX-XXXX-" + orderInfo.CreditCard.Number.Substring(orderInfo.CreditCard.Number.Length - 4);
            else
                e.Row.Cells[5].Text = "XXXX-XXXX-XXXX-" + orderInfo.CreditCard.Number;
        }
    }

    protected void ServerValidation(object source, ServerValidateEventArgs arguments)
    {
        arguments.IsValid = (ListOfAgentsWebUserControl1.SelectedValue != "0");
    }

    protected void SearchUsersResultGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BillingGridView.PageIndex = e.NewPageIndex;
        BillingGridView.DataSource = (OrderInfo[])Session["BillingInfo"];
        BillingGridView.DataBind();
    }
    #endregion

    #region Methods
    private void FillGridView(int userId)
    {
        try
        {
            OrderService orderService = ServiceAccess.GetInstance().GetOrder();
            OrderInfo[] dataSource = orderService.GetList(userId);             
            if (dataSource.Length == 0)
            {
                NoRecordsTable.Visible = true;
            }
            else
            {
                NoRecordsTable.Visible = false;
                BillingGridView.DataSource = dataSource;
                Session["BillingInfo"] = BillingGridView.DataSource;
                BillingGridView.DataBind();
            }
            
        }
        catch (Exception ex)
        {
            log.Error("Error loading billing history", ex);
            ErrorLiteral.Text = "Error loading billing history";
        }

    }
    #endregion
}

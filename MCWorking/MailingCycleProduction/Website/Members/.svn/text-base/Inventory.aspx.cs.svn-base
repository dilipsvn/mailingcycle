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
using System.Collections.Generic;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Registration;

public partial class Inventory : System.Web.UI.Page
{
    public bool IsAgentRole
    {
        get
        {
            LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
            return (regInfo.Role == UserRole.Agent);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int userId = 0;
            if (!IsAgentRole)
            {
                AgentPanel.Visible = true;
                ListOfAgentsWebUserControl1.FillDropDown();
                if (Request.QueryString["userId"] != null)
                {
                    ListOfAgentsWebUserControl1.SelectedValue = Request.QueryString["userId"];
                    FillRepeater(Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue));
                }
            }
            else
            {
                LoginInfo regInfo = (LoginInfo)Session["loginInfo"];
                userId = regInfo.UserId;
                FillRepeater(userId);
            }
            
        }
    }

    protected void GoButton_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int userId = Convert.ToInt32(ListOfAgentsWebUserControl1.SelectedValue);
            Session["SelectedAgent"] = ListOfAgentsWebUserControl1.SelectedText;
            FillRepeater(userId);
        }
    }

    private void FillRepeater(int userId)
    {
        OrderService orderService = ServiceAccess.GetInstance().GetOrder();
        InventoryInfo[] dataSource = orderService.GetInventoryList(userId);
        if (dataSource.Length == 0)
        {
            NoRecordsTable.Visible = true;
        }
        else
        {
            ViewState["DataSource"] = dataSource;
            InventoryGridView.DataSource = dataSource;
            InventoryGridView.DataBind();
        }
    }

    protected void InventoryGridView_Command(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "InventoryLink")
        {
            InventoryInfo[] dataSource = (InventoryInfo[])ViewState["DataSource"];
            Session["SelectedCategory"] = dataSource[e.Item.ItemIndex];
            if (!IsAgentRole)
                Response.Redirect("InventoryDetails.aspx?userId=" + ListOfAgentsWebUserControl1.SelectedValue);
            else
                Response.Redirect("InventoryDetails.aspx");
        }
    }

    protected void InventoryGridView_DataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            InventoryInfo dataSource = (InventoryInfo)e.Item.DataItem;
            Repeater repeater = (Repeater)e.Item.FindControl("InventoryRepeater");
            LinkButton inventoryLink = (LinkButton)e.Item.FindControl("InventoryLink");
            List<InventoryItemInfo> newDataSource = new List<InventoryItemInfo>();
            if (dataSource.InventoryItems.Length > 5)
            {
                foreach (InventoryItemInfo itemInfo in dataSource.InventoryItems)
                {
                    if (newDataSource.Count < 5)
                        newDataSource.Add(itemInfo);
                    else
                        break;
                }
                repeater.DataSource = newDataSource;
            }
            else
            {
                repeater.DataSource = dataSource.InventoryItems;
                inventoryLink.Enabled = false;
            }
            repeater.DataBind();
        }
    }

    protected void ServerValidation(object source, ServerValidateEventArgs arguments)
    {
        arguments.IsValid = (ListOfAgentsWebUserControl1.SelectedValue != "0");
    }
}

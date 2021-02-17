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
using Irmac.MailingCycle.BLLServiceLoader.Registration;

public partial class InventoryDetails : System.Web.UI.Page
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
            InventoryInfo inventoryInfo = (InventoryInfo)Session["SelectedCategory"];
            InventoryRepeater.DataSource = inventoryInfo.InventoryItems;
            InventoryRepeater.DataBind();
            CategoryTypeLiteral.Text = inventoryInfo.CategoryType.ToString() + "s";
            QuantityOnHandLiteral.Text = inventoryInfo.QuantityOnHand.ToString();
            if (!IsAgentRole)
                AgentLiteral.Text = "Selected Agent: " + Session["SelectedAgent"].ToString();
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        if (!IsAgentRole)
        {
            Response.Redirect("Inventory.aspx?userId=" + Request.QueryString["userId"]);
        }
        else
            Response.Redirect("Inventory.aspx");
    }
}

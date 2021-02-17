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

public partial class ContactManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ModifyButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/ModifyContact.aspx");
    }

    protected void CreateButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/CreateContact.aspx");
    }

    protected void ExportButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SampleFarm.xls");
    }

    
}

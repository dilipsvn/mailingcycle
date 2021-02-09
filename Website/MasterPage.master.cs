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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginInfo"] == null || Session["loginInfo"] == "")
        {
            a_Default.HRef = "~/Default.aspx";
            a_Default_Bottom.HRef = "~/Default.aspx";
        }
        else
        {
            a_Default.HRef = "~/Members/Welcome.aspx";
            a_Default_Bottom.HRef = "~/Members/Welcome.aspx";
        }

    }
}

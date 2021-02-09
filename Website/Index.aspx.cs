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

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Page"] != "0")
        {
            if (Request.Cookies["myFlashVisitCookie"] != null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {

                HttpCookie myCookie = new HttpCookie("myFlashVisitCookie"); //Instance the new cookie

                Response.Cookies.Remove("myFlashVisitCookie"); //Remove previous cookie

                Response.Cookies.Add(myCookie); //Create the new cookie

                //myCookie.Values.Add("UserName", this.loginBox.UserName); //Add the username field to the cookie

                DateTime deathDate = DateTime.Now.AddDays(15); //Days of life

                Response.Cookies["myFlashVisitCookie"].Expires = deathDate; //Assign the life period
            }
        }

    }
}

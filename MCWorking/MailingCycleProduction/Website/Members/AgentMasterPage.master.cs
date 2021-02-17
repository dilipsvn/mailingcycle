#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: MasterPage.aspx
    * Created Date      : 05/Nov/2007
	* Last Modify Date  : 05/Nov/2007
	* Author			: Irmac Development Team 
	* Comment			: Master Page 
	* Source			: MailingCycle\Agent\MasterPage.aspx.cs

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


public partial class Agent_AgentMasterPage : System.Web.UI.MasterPage
{
    protected override void OnInit(EventArgs e)
    {
        if (Session["loginInfo"] == null || Session["loginInfo"] == "")
        {
            if (!(Request.Url.AbsolutePath.ToUpper().Contains("ABOUTUS.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("CONTACTUS.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("FEEDBACK.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("SITEMAP.ASPX")))
                Response.Redirect("../userLogin.aspx?Message=SessionExpired");
            else
                LoginPanel.Visible = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["loginInfo"] == null || Session["loginInfo"] == "")
        {
            if (!(Request.Url.AbsolutePath.ToUpper().Contains("ABOUTUS.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("CONTACTUS.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("FEEDBACK.ASPX") || Request.Url.AbsolutePath.ToUpper().Contains("SITEMAP.ASPX")))
                Response.Redirect("../userLogin.aspx?Message=SessionExpired");

        }
        else
        {
            RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
            NameLabel.Text = loginInfo.FirstName + " " + loginInfo.LastName;
            RoleLabel.Text = loginInfo.Role.ToString();

            pageDateLabel.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " " + GetTimeZoneText();
        }
    }

    protected void LogoutLinkButton_Click(object sender, EventArgs e)
    {
        Session.Remove("loginInfo");
        Response.Redirect("~/default.aspx");
    }

    protected string GetTimeZoneText()
    {
        string timeZoneText="";

        if (TimeZone.CurrentTimeZone.StandardName.Contains("Central"))
            timeZoneText = "(CST)";
        if (TimeZone.CurrentTimeZone.StandardName.Contains("Eastern"))
            timeZoneText = "(EST)";
        if (TimeZone.CurrentTimeZone.StandardName.Contains("Pacific"))
            timeZoneText = "(PST)";
        if (TimeZone.CurrentTimeZone.StandardName.Contains("Mountain"))
            timeZoneText = "(MST)";

        return timeZoneText;
    }
}

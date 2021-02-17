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
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Text;
using log4net;

public partial class Members_DesignPageExtractor : System.Web.UI.Page
{
    protected static readonly ILog log =
        LogManager.GetLogger(typeof(Members_DesignPageExtractor));

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the query string values.
        NameValueCollection coll = Request.QueryString;

        int agentId = Convert.ToInt32(coll.Get("aId"));
        string agentName = coll.Get("aName");
        string lowResolutionFile = coll.Get("lrf");

        if (agentName != "")
        {
            AgentNameLabel.Text = "Agent Name: " + agentName + "&nbsp;";
        }

        // Set the required query string varables into hidden fields.
        AgentIdHiddenField.Value = agentId.ToString();

        // Set the attributes required.
        string urlPrefix = Request.ServerVariables["HTTP_REFERER"].Substring(
            0, Request.ServerVariables["HTTP_REFERER"].LastIndexOf("/Members/"));

        string pdfFile = urlPrefix + "/Members/ApprovedDesignPages/" + lowResolutionFile;
        string fileUploader = urlPrefix + "/Members/FileUploader.aspx?pdf=" + 
            lowResolutionFile;
        string serverName = Request.ServerVariables["SERVER_NAME"];
        string serverPort = Request.ServerVariables["SERVER_PORT"];

        // Register the client side script.
        ClientScriptManager csManager = Page.ClientScript;
        Type type = this.GetType();
        string newLine = Environment.NewLine;

        if (!csManager.IsClientScriptBlockRegistered(type, "ObjectLoadScript"))
        {
            StringBuilder csText = new StringBuilder();
            csText.Append("<script language=\"javascript\">" + newLine);
            csText.Append("<!--" + newLine);
            csText.Append("function onObjectLoad() {" + newLine);
            csText.Append("var oMCDE = document.getElementById(\"ctlMCDE\");" + newLine);
            csText.Append("if (oMCDE != null) {" + newLine);
            csText.Append("oMCDE.PDFFile = \"" + pdfFile + "\";" + newLine);
            csText.Append("oMCDE.FileUploader = \"" + fileUploader + "\";" + newLine);
            csText.Append("oMCDE.ServerName = \"" + serverName + "\";" + newLine);
            csText.Append("oMCDE.ServerPort = " + serverPort + ";" + newLine);
            csText.Append("oMCDE.ExtractDesign();" + newLine);
            csText.Append("}" + newLine);
            csText.Append("}" + newLine);
            csText.Append("document.body.onload = onObjectLoad;" + newLine);
            csText.Append("// -->" + newLine);
            csText.Append("</script>");
            csManager.RegisterClientScriptBlock(type, "ObjectLoadScript", csText.ToString(), false);
        }
    }

    protected void OKButton_Click(object sender, EventArgs e)
    {
        string queryString = "?aId=" + AgentIdHiddenField.Value;

        Response.Redirect("~/Members/DesignManagement.aspx" + queryString);
    }
}

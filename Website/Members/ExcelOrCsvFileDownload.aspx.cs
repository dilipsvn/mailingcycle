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
using Irmac.MailingCycle.BLLServiceLoader;
using FarmService = Irmac.MailingCycle.BLLServiceLoader.Farm;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using Irmac.MailingCycle.BLL;

using log4net;
using log4net.Config;
#endregion

public partial class Members_ExcelOrCsvFileDownload : System.Web.UI.Page
{
    #region Field Declarations

    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(Members_ExcelOrCsvFileDownload));
    #endregion

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["plotId"] == "") && (Request.QueryString["plotId"] == null))
            ErrorLiteral.Text = "Improper Parameter.";
        else
        {
            int plotId = 0;
            int.TryParse(Request.QueryString["plotId"].ToString(), out plotId);
            try
            {
                ServiceAccess serviceLoader = ServiceAccess.GetInstance();
                FarmService.FarmService farmService = serviceLoader.GetFarm();
                RegistrationService.LoginInfo loginInfo = (RegistrationService.LoginInfo)Session["loginInfo"];
                String fileName = farmService.ExportContactListToExcel(loginInfo.UserId, plotId);
                Response.Redirect("~/Members/UserData/" + loginInfo.UserId.ToString() + "/" + fileName);
            }
            catch (Exception exception)
            {
                log.Error("UNKNOWN ERROR WHILE EXPORTING CONTACT LIST:", exception);
                ErrorLiteral.Text = "Error: Unable to Export Contact List to Excel File";
            }
        }
    }
}

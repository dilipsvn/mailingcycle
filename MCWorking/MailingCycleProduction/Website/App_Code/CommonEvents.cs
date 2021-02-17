#region (C) Irmac USA Inc 2007
/***************************************************************** 

	* All rights are reserved. 
    * File				: CommonEvents
    * Created Date      : 02/Nov/2007
	* Last Modify Date  : 02/Nov/2007
	* Author			: Irmac Development Team 
	* Comment			: Class is used for the common methods
	* Source			: MailingCycle\CommonEvents.cs

	****************************************************************/
#endregion

#region Namespaces

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Irmac.MailingCycle.BLLServiceLoader;
using System.Collections.Generic;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using log4net;
using log4net.Config;

#endregion

/// <summary>
/// Contains the methods for the common events
/// </summary>
public class CommonEvents : System.Web.UI.Page
{
    # region Methods

    public static void LoadCountries(DropDownList countryDropDownList)
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        CommonService.CommonService commonService = serviceLoader.GetCommon();

        // Get the list of contries and populate.
        IList<CommonService.CountryInfo> countries = commonService.GetCountries();

        countryDropDownList.DataSource = countries;
        countryDropDownList.DataValueField = "CountryId";
        countryDropDownList.DataTextField = "Name";
        countryDropDownList.DataBind();                        
    }

    public static void LoadStates(DropDownList countryDropDownList, DropDownList stateDropDownList)
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();

        stateDropDownList.Items.Clear();
        int countryId = Convert.ToInt32(countryDropDownList.SelectedValue);

        if (countryId == 0)
        {
            stateDropDownList.Items.Add(new ListItem("&lt;Select a State&gt;", "0"));
        }
        else
        {
            CommonService.CommonService commonService = serviceLoader.GetCommon();
            System.Collections.Generic.IList<CommonService.StateInfo> states = commonService.GetStates(countryId);

            stateDropDownList.DataSource = states;
            stateDropDownList.DataValueField = "StateId";
            stateDropDownList.DataTextField = "Name";
            stateDropDownList.DataBind();
        }
    }

    public static string GetDynamicPath(HttpRequest Request)
    {
        return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath;
    }
    #endregion
}

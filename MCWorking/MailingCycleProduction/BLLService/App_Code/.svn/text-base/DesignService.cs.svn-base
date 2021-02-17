using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Xml;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;

/// <summary>
/// A Service Component used to manage Design Utilities.
/// </summary>
[WebService(Namespace = "http://irmac.com/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class DesignService : System.Web.Services.WebService
{
    public DesignService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public object[] GetSummary()
    {
        // Get an instance of the Design BO
        Design bll = new Design();

        DataTable summary = bll.GetSummary();

        object[] result = Util.GetArray(summary);

        return result;
    }

    [WebMethod]
    public List<DesignInfo> GetList(int userId)
    {
        // Get an instance of the Design BO
        Design bll = new Design();

        List<DesignInfo> designs = bll.GetList(userId);

        return designs;
    }

    [WebMethod]
    public List<DesignInfo> GetListAll(int userId)
    {
        // Get an instance of the Design BO
        Design bll = new Design();

        List<DesignInfo> designs = bll.GetListAll(userId);

        return designs;
    }

    [WebMethod]
    public void Update(int userId, DesignInfo design)
    {
        // Get an instance of the Design BO
        Design bll = new Design();

        bll.Update(userId, design);
    }

    [WebMethod]
    public DesignInfo Get(int designId)
    {
        // Get an instance of the Design BO
        Design bll = new Design();

        DesignInfo design = bll.Get(designId);

        return design;
    }

    [WebMethod]
    public void Delete(int designId, int userId)
    {
        // Get an instance of the Design BO
        Design bll = new Design();

        bll.Delete(designId, userId);
    }

    [WebMethod]
    public List<DesignStatusInfo> GetDesignStatuses(int userId, int category,
            int status)
    {
        // Get an instance of the Design BO
        Design bll = new Design();

        List<DesignStatusInfo> designs = bll.GetDesignStatuses(userId, category, status);

        return designs;
    }
}

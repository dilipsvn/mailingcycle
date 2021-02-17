using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;

[WebService(Namespace = "http://localhost:3555/BLLService/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class CommonService : System.Web.Services.WebService
{
    public CommonService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<CountryInfo> GetCountries()
    {
        // Get an instance of the Common BO
        Common bll = new Common();

        List<CountryInfo> countries = bll.GetCountries();

        return countries;
    }

    [WebMethod]
    public List<StateInfo> GetStates(int countryId)
    {
        // Get an instance of the Common BO
        Common bll = new Common();

        List<StateInfo> states = bll.GetStates(countryId);

        return states;
    }

    [WebMethod]
    public List<LookupInfo> GetLookups(string category)
    {
        // Get an instance of the Common BO
        Common bll = new Common();

        List<LookupInfo> lookups = bll.GetLookups(category);

        return lookups;
    }

    [WebMethod]
    public LookupInfo GetLookupDetails(int lookupId)
    {
        // Get an instance of the Common BO
        Common bll = new Common();

        LookupInfo lookupdetails = bll.GetLookupDetails(lookupId);

        return lookupdetails;
    }


    [WebMethod]
    public PropertyInfo GetProperty(string name)
    {
        // Get an instance of the Common BO
        Common bll = new Common();

        PropertyInfo property = bll.GetProperty(name);

        return property;
    }

    [WebMethod]
    public List<RegistrationInfo> GetAgentsList()
    {
        Common bll = new Common();
        return bll.GetAgentList();
    }

    [WebMethod]
    public List<RegistrationInfo> GetUsersByRole(string roles)
    {
        // Get an instance of the Common BO
        Common bll = new Common();

        List<RegistrationInfo> users = bll.GetUsersByRole(roles);

        return users;
    }

    [WebMethod]
    public bool InsertProperty(string name,string value)
    {
        Common bll = new Common();
        return bll.InsertProperty(name, value);
    }

}

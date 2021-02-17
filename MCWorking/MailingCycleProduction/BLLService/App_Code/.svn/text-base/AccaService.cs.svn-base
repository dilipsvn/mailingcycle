using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;
using System.Collections.Generic;


/// <summary>
/// Summary description for AccaService
/// </summary>
[WebService(Namespace = "http://localhost:2676/BLLService/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class AccaService : System.Web.Services.WebService
{

    public AccaService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<AccaInfo> GetCreditCardDetailsForScheduledEvents(DateTime eventDate)
    {
        AccaProcess bll = new AccaProcess();
        return bll.GetCreditCardDetailsForScheduledEvents(eventDate);
    }

    [WebMethod]
    public List<AccaInfo> UpdateEventInfo(List<AccaInfo> eventsInfo)
    {
        AccaProcess bll = new AccaProcess();
        return bll.UpdateEventInfo(eventsInfo);
    }
}


using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Net;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.BLLServiceLoader.Acca;
using System.Collections.Generic;
using TemplateParser;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net.Configuration;
using log4net;
using log4net.Config;
using Irmac.MailingCycle.BLLServiceLoader.Common;


public partial class StartAcca : System.Web.UI.Page
{
    #region Form specific variable declaration
    protected static readonly ILog log = LogManager.GetLogger(typeof(StartAcca));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "ACCA Processing..";
       // Do the processing only if it is loaded on tuesday, 10 PM
        if ((DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && DateTime.Now.TimeOfDay.Hours == 22) || Request.QueryString["eventDate"] != null)
        {
            Label1.Text = "ACCA Processing..";
            try
            {
                AccaService accaService = ServiceAccess.GetInstance().GetAcca();
                DateTime eventDate = DateTime.MinValue;
                if (Request.QueryString["eventDate"] != null)
                    eventDate = Convert.ToDateTime(Request.QueryString["eventDate"]);
                AccaInfo[] allAccaInfo = accaService.GetCreditCardDetailsForScheduledEvents(eventDate);
                Irmac.MailingCycle.BLLServiceLoader.Order.OrderService orderService = ServiceAccess.GetInstance().GetOrder();

                foreach (Irmac.MailingCycle.BLLServiceLoader.Acca.AccaInfo accaInfo in allAccaInfo)
                {
                    //if quantity sufficient
                    if (accaInfo.EventStatus != ScheduleEventStatus.ACCAError)
                    {
                        accaInfo.EventStatus = ScheduleEventStatus.InProgress;
                        accaInfo.Remarks = "Billed successfully";
                        ProcessCreditCard processCreditCard = new ProcessCreditCard();
                        processCreditCard.Address1 = accaInfo.AccaCreditCardInfo.Address.Address1;
                        processCreditCard.Address2 = accaInfo.AccaCreditCardInfo.Address.Address2;
                        processCreditCard.Amount = accaInfo.AccaOrderInfo.Amount;
                        processCreditCard.CardNumber = accaInfo.AccaCreditCardInfo.Number;
                        processCreditCard.City = accaInfo.AccaCreditCardInfo.Address.City;
                        processCreditCard.Country = accaInfo.AccaCreditCardInfo.Address.Country.Name;
                        processCreditCard.ExpiryDate = new DateTime
                            (accaInfo.AccaCreditCardInfo.ExpirationYear, accaInfo.AccaCreditCardInfo.ExpirationMonth, 1);
                        string[] names = accaInfo.AccaCreditCardInfo.HolderName.Split(new char[] { ' ' });
                        processCreditCard.FirstName = names[0];
                        if (names.Length > 1)
                            processCreditCard.LastName = names[1];
                        processCreditCard.State = accaInfo.AccaCreditCardInfo.Address.State.Name;
                        processCreditCard.ZipCode = accaInfo.AccaCreditCardInfo.Address.Zip;

                        processCreditCard.AuthorizeCard();
                        OrderInfo orderInfo = accaInfo.AccaOrderInfo;
                        if (processCreditCard.CreditCardStatus != CardStatus.Approved)
                        {
                            accaInfo.EventStatus = ScheduleEventStatus.ACCAError;
                            accaInfo.Remarks = processCreditCard.Message;
                        }
                        else
                        {
                            orderInfo.CreditCard = accaInfo.AccaCreditCardInfo;
                            orderInfo.Date = DateTime.Now;
                            orderInfo.Number = 10000;
                        }
                        orderInfo.TransactionCode = processCreditCard.TransactionId;
                        orderInfo.TransactionMessage = processCreditCard.Message;
                        accaInfo.AccaOrderInfo = orderInfo;
                    }
                }
                AccaInfo[] updatedInfo = accaService.UpdateEventInfo(allAccaInfo);
                SendACCAMail(updatedInfo);
             
                Label1.Text = "ACCA Process Completed Successfully..";
            }
            catch (Exception ex)
            {
                log.Error("Acca Error", ex);
            }
        }
    }

    #endregion

    #region Methods
    private void SendACCAMail(AccaInfo[] allACCAInfo)
    {
        List<AccaInfo> successInfo = new List<AccaInfo>();
        List<AccaInfo> failureInfo = new List<AccaInfo>();
        foreach (AccaInfo accaInfo in allACCAInfo)
        {
            if (accaInfo.EventStatus != ScheduleEventStatus.InProgress)
            {
                bool isfEvent = false;
                foreach (AccaInfo fInfo in failureInfo)
                {
                    if (fInfo.EventId == accaInfo.EventId)
                    {
                        isfEvent = true;
                        break;
                    }
                }
                if(!isfEvent)
                    failureInfo.Add(accaInfo);
            }
            else
            {
                bool issEvent = false;
                foreach (AccaInfo fInfo in successInfo)
                {
                    if (fInfo.EventId == accaInfo.EventId)
                    {
                        issEvent = true;
                        break;
                    }
                }
                if (!issEvent)
                    successInfo.Add(accaInfo);
            }
        }
        Hashtable templateVars = new Hashtable();
        string URLAddress = CommonEvents.GetDynamicPath(Request);
        templateVars.Add("URL", URLAddress);
        String emailTemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\HTMLTemplate\\Email_AccaCompleted.html";
        Parser parser = new Parser(emailTemplateFilePath, templateVars);
        int index = parser.TemplateBlock.IndexOf("<!-- for inserting here-->");
        AssignTemplateBlock(successInfo, parser, index);
        index = parser.TemplateBlock.IndexOf("<!-- for inserting cancelled here-->");
        AssignTemplateBlock(failureInfo, parser, index);
        SendEmail(parser.Parse());
    }

    private static void AssignTemplateBlock(List<AccaInfo> successInfo, Parser parser, int index)
    {
        foreach (AccaInfo sucInfo in successInfo)
        {
            string htmlString = "<tr><td align=center>" + sucInfo.EventId.ToString() + "</td><td align=center>" + 
                sucInfo.EventDate.ToShortDateString() + "</td>" + "<td align=center>" + sucInfo.FarmName + 
                "</td><td align=center>" + sucInfo.PlanName + "</td><td align=center>" + sucInfo.UserId.ToString() +
                "</td><td align=center>" + sucInfo.UserName.ToString() + "</td>";
            if (sucInfo.EventStatus != ScheduleEventStatus.Cancelled)
                htmlString += "<td align=center>" + sucInfo.AccaOrderInfo.Amount.ToString() +
                "</td><td align=center>" + sucInfo.AccaOrderInfo.OrderId;
            else
                htmlString += "<td align=center>&nbsp;</td><td align=center>&nbsp;";
            htmlString += "<td align=center>" + sucInfo.AccaOrderInfo.TransactionCode.ToString() + "</td>";
            if (sucInfo.EventStatus != ScheduleEventStatus.InProgress)
                htmlString += "</td><td align=center>" + sucInfo.Remarks;
            htmlString += "</td></tr>";
            parser.TemplateBlock = parser.TemplateBlock.Insert(index, htmlString);
            index += htmlString.Length;
        }
        if (successInfo.Count == 0)
        {
            string htmlString = "<tr><td colspan=8>No Events in this section</td></tr>";
            parser.TemplateBlock = parser.TemplateBlock.Insert(index, htmlString);
        }        
    }

    private void SendEmail(string mailBody)
    {
        string toAddress = ServiceAccess.GetInstance().GetCommon().GetProperty("ACCAMailAdmin").Value.ToString();

        //Creating Mail Message Body
        MailMessage mailmsg = new MailMessage();
        mailmsg.To.Add(toAddress);
        mailmsg.From =
                new MailAddress("shailu521@yahoo.com", "MailingCycle");
        mailmsg.Subject = "Mailing cycle ACCA report for " + DateTime.Today.ToShortDateString();
        mailmsg.IsBodyHtml = true;
        mailmsg.Body = mailBody;
        mailmsg.Priority = MailPriority.Normal;

        Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);

        MailSettingsSectionGroup mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
        if (mailSettings != null)
        {
            int port = mailSettings.Smtp.Network.Port;
            string host = mailSettings.Smtp.Network.Host;
            string password = mailSettings.Smtp.Network.Password;
            string username = mailSettings.Smtp.Network.UserName;

            SmtpClient smtpclient = new SmtpClient(host, 587);
            smtpclient.Credentials = new NetworkCredential(username, password);
            smtpclient.EnableSsl = true;
            smtpclient.Send(mailmsg);
        }
    }
    #endregion
}

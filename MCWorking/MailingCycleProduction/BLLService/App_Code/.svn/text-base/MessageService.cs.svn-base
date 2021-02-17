using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;
using System.Collections.Generic;


/// <summary>
/// Summary description for MessageService
/// </summary>
[WebService(Namespace = "http://localhost:3130/BLLService/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class MessageService : System.Web.Services.WebService
{

    public MessageService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<MessageInfo> GetStandardMessageList(bool isAgent,string gender,string agentName)
    {
        Message bll = new Message();
        return bll.GetStandardMessageList(isAgent, gender, agentName);
    }

    [WebMethod]
    public List<MessageInfo> GetCustomMessageList(int userId)
    {
        Message bll = new Message();
        return bll.GetCustomMessageList(userId);
    }

    [WebMethod]
    public bool InsertMessage(MessageInfo messageInfo,int userId)
    {
        Message bll = new Message();
        return bll.InsertMessage(messageInfo,userId);
    }
    [WebMethod]
    public bool DeleteMessage(int messageId,int userId,int deletedBy)
    {
        Message bll = new Message();
        return bll.DeleteMessage(messageId, userId, deletedBy);
    }

    [WebMethod]
    public bool UpdateMessage(MessageInfo msgInfo,int userId,int ownerId)
    {
        Message bll = new Message();
        return bll.UpdateMessage(msgInfo, userId, ownerId);
    }

    [WebMethod]
    public List<MessageInfo> GetSearchMessages(int messageId, MessageStatus messageStatus, MessageType messageType)
    {
        Message bll = new Message();
        return bll.GetSearchMessages(messageId, messageStatus, messageType);
    }
}


using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Irmac.MailingCycle.BLL;
using Irmac.MailingCycle.Model;
using System.Collections.Generic;


[WebService(Namespace = "http://localhost:3130/BLLService/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class RegistrationService : System.Web.Services.WebService
{
    public RegistrationService ()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public int Insert(RegistrationInfo registration)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();
        String folderPath = System.Configuration.ConfigurationManager.AppSettings["ContactFileLocation"];
        if (!folderPath.EndsWith("\\"))
        {
            folderPath += "\\";
        }

        int userId = bll.InsertWithWorkSpaceDirectory(registration,folderPath);
        return userId;
    }

    [WebMethod]
    public void Update(RegistrationInfo registration, int userLoginId)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        bll.Update(registration, userLoginId);
    }

    [WebMethod]
    public void UpdateSecretDetails(RegistrationInfo registration)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        bll.UpdateSecretDetails(registration);
    }


    [WebMethod]
    public void UpdatePassword(RegistrationInfo registration)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        bll.UpdatePassword(registration);
    }


    [WebMethod]
    public List<RegistrationInfo> GetUsersList(UserRole userRole, string firstName, string lastName, string userName)
    {
        Registration bll = new Registration();
        return bll.GetUserList(userRole, firstName, lastName, userName);
    }


    [WebMethod]
    public RegistrationInfo GetDetails(int userId)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        RegistrationInfo registration = bll.GetDetails(userId);

        return registration;
    }

    [WebMethod]
    public RegistrationInfo GetUserDetails(string userName)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        RegistrationInfo registration = bll.GetDetails(userName);

        return registration;
    }


    [WebMethod]
    public bool ValidateUser(string userName, string password)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        bool loginStatus = bll.ValidateUser(userName, password);

        return loginStatus;
    }


    [WebMethod]
    public LoginInfo Login(string userName, string password)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();


        RegistrationInfo registration = new RegistrationInfo();
        LoginInfo login = new LoginInfo();
        registration = null;

        bool loginStatus = bll.ValidateUser(userName, password);

        if (loginStatus == true)
        {
            registration = bll.GetDetails(userName);
            login.UserId = registration.UserId;
            login.UserName = registration.UserName;
            login.FirstName = registration.FirstName;
            login.LastName = registration.LastName;
            login.Role = registration.Role;
            login.Status = registration.Status;
        }
        else
            login = null;
        return login;
    }


    [WebMethod]
    public void UpdateCreditCard(int userId, CreditCardInfo creditCard)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        bll.UpdateCreditCard(userId, creditCard);
    }

    [WebMethod]
    public bool IsEmailExists(string email,int userId)
    {
        // Get an instance of the MailingCycle BO
        Registration bll = new Registration();

        bool isEmailExists = bll.IsEmailExists(email,userId);

        return isEmailExists;
    }

    [WebMethod]
    public CreditCardInfo GetCreditCard(int userId)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        CreditCardInfo creditCard = bll.GetCreditCard(userId);

        return creditCard;
    }

    [WebMethod]
    public void UpdateStatus(int userId, RegistrationStatus status, int userLoginId)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        bll.UpdateStatus(userId, status,userLoginId);
    }

    [WebMethod]
    public RegistrationStatus GetStatus(int userId)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        RegistrationStatus status = bll.GetStatus(userId);

        return status;
    }

    [WebMethod]
    public bool DeleteUser(int userId, int userLoginId)
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();
        bool success = bll.DeleteUser(userId,userLoginId);
        return success;
    }

    [WebMethod]
    public object[] GetApprovalRequiredUsers()
    {
        // Get an instance of the Registration BO
        Registration bll = new Registration();

        DataTable users = bll.GetApprovalRequiredUsers();

        object[] result = Util.GetArray(users);

        return result;
    }


}

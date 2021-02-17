using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;

/// <summary>
/// Summary description for ProcessCreditCard
/// </summary>

public enum CardStatus
{
    Approved = 1,
    Declined,
    Error
}

public class ProcessCreditCard
{
    private decimal amount;
    private string cardNumber;
    private string cvvCode;
    private string address1;
    private string address2;
    private string city;
    private string state;
    private string zipCode;
    private string country;
    private int transactionId;
    private string message;
    private CardStatus cardStatus;
    private DateTime expiryDate;
    private string firstName;
    private string lastName;


    public DateTime ExpiryDate
    {
        get { return expiryDate; }
        set { expiryDate = value; }
    }
    public int TransactionId
    {
        get { return transactionId; }
        set { transactionId = value; }
    }
    public string Message
    {
        get { return message; }
        set { message = value; }
    }
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public CardStatus CreditCardStatus
    {
        get { return cardStatus; }
        set { cardStatus = value; }
    }

    public string Address1
    {
        get { return address1; }
        set { address1 = value; }
    }

    public string Address2
    {
        get { return address2; }
        set { address2 = value; }
    }
    public string City
    {
        get { return city; }
        set { city = value; }
    }
    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public string ZipCode
    {
        get { return zipCode; }
        set { zipCode = value; }
    }

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    public string CvvCode
    {
        get { return cvvCode; }
        set { cvvCode = value; }
    }

    public string CardNumber
    {
        get { return cardNumber; }
        set { cardNumber = value; }
    }

    public decimal Amount
    {
        get { return amount; }
        set { amount = value; }
    }
    public ProcessCreditCard()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public String AuthorizeCard()
    {
        String result = "";
        string address = Address1 + (Address2 != null ? "," + Address2 : string.Empty);
        String strPost = "x_login=authnet06&x_tran_key=Authnet44&x_method=CC&x_type=AUTH_CAPTURE" +
            "&x_amount=" + amount.ToString() + "&x_delim_data=TRUE&x_delim_char=|&x_relay_response=FALSE&x_card_num=" + CardNumber +
            "&x_exp_date=" + ExpiryDate.Month.ToString() + expiryDate.Year.ToString() + "&x_first_name=" + FirstName + "&x_last_name=" + lastName +
            "&x_address=" + address + "&x_city=" + City + "&x_state=" + State + "&x_zip=" + zipCode + "&x_country=" +
            "&x_test_request=TRUE&x_version=3.1";
        StreamWriter myWriter = null;

        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create("https://test.authorize.net/gateway/transact.dll");
        objRequest.Method = "POST";
        objRequest.ContentLength = strPost.Length;
        objRequest.ContentType = "application/x-www-form-urlencoded";

        try
        {
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(strPost);
        }
        catch (Exception e)
        {
            return e.Message;
        }
        finally
        {
            myWriter.Close();
        }

        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        using (StreamReader sr =
           new StreamReader(objResponse.GetResponseStream()))
        {
            result = sr.ReadToEnd();
            char[] delim = new char[]{'|'};
            string[] resultArray = result.Split(delim);
            if (resultArray.Length > 1)
            {
                this.cardStatus = CardStatus.Approved;//(CardStatus)(Convert.ToInt32(resultArray[0]));
                this.transactionId = Convert.ToInt32(resultArray[6]);
                this.message = resultArray[3];
            }
            // Close and clean up the StreamReader
            sr.Close();
        }
        return result;
    }
}

using System;
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
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLL;
using System.Text.RegularExpressions;

public partial class WebUserControls_CreditCardWebUserControl : System.Web.UI.UserControl
{
    public event EventHandler OnStateDropDownChange;
    public event EventHandler OnCardDropDownChange;

    protected void Page_Load(object sender, EventArgs e)
    {
        Util.Validations.RegisterZipScriptBlock(Page.ClientScript, this.GetType(),
            BillingCountryDropDownList.ClientID);

        if (!Page.IsPostBack)
        {
            // Get the common web service instance.
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();
            CommonService.CommonService commonService = serviceLoader.GetCommon();

            // Get the list of Card Types and populate.
            IList<CommonService.LookupInfo> cardTypes = commonService.GetLookups("Credit Card Type");

            CardTypeDropDownList.DataSource = cardTypes;
            CardTypeDropDownList.DataValueField = "LookupId";
            CardTypeDropDownList.DataTextField = "Name";
            CardTypeDropDownList.DataBind();


            //Credit Card Expiry Year List
            int currentYear = DateTime.Now.Year;
            List<int> avlYears = new List<int>();
            for (int i = currentYear; i <= (currentYear + 20); i++)
            {
                avlYears.Add(i);                
            }
            CardYearDropDownList.DataSource = avlYears;
            CardYearDropDownList.DataBind();
            //Get country List for Billing Address
            IList<CommonService.CountryInfo> countries = commonService.GetCountries();

            BillingCountryDropDownList.DataSource = countries;
            BillingCountryDropDownList.DataValueField = "CountryId";
            BillingCountryDropDownList.DataTextField = "Name";
            BillingCountryDropDownList.DataBind();

            //BillingCountryDropDownList.Items.FindByText("United States").Selected = true;
            BillingCountryDropDownList_SelectedIndexChanged(BillingCountryDropDownList, new EventArgs());
        }
    }


    protected void BillingCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList countryDropDownList = (DropDownList)sender;
        try
        {
            ServiceAccess serviceLoader = ServiceAccess.GetInstance();

            BillingStateDropDownList.Items.Clear();
            int countryId = Convert.ToInt32(countryDropDownList.SelectedValue);

            if (countryId == 0)
            {
                BillingStateDropDownList.Items.Add(new ListItem("Choose a State", ""));
            }
            else
            {
                CommonService.CommonService commonService = serviceLoader.GetCommon();
                IList<CommonService.StateInfo> states = commonService.GetStates(countryId);

                BillingStateDropDownList.DataSource = states;
                BillingStateDropDownList.DataValueField = "StateId";
                BillingStateDropDownList.DataTextField = "Name";
                BillingStateDropDownList.DataBind();
                
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void CreditCard_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        //Credit Card Server Side Validation

        String strRegExp;

        if (CardTypeDropDownList.SelectedValue== "Visa")
        {
            // Visa: length 16, prefix 4, dashes optional.
            strRegExp = "/^4\\d{3}-?\\d{4}-?\\d{4}-?\\d{4}$/";
        }
        else if (CardTypeDropDownList.SelectedValue == "Master")
        {
            // Mastercard: length 16, prefix 51-55, dashes optional.
            strRegExp = "/^5[1-5]\\d{2}-?\\d{4}-?\\d{4}-?\\d{4}$/";
        }
        else if (CardTypeDropDownList.SelectedValue == "Discover")
        {
            // Discover: length 16, prefix 6011, dashes optional.
            strRegExp = "/^6011-?\\d{4}-?\\d{4}-?\\d{4}$/";
        }
        else if (CardTypeDropDownList.SelectedValue == "American Express")
        {
            // American Express: length 15, prefix 34 or 37.
            strRegExp = "/^3[4,7]\\d{13}$/";
        }
        else if (CardTypeDropDownList.SelectedValue == "Diners")
        {
            // Diners: length 14, prefix 30, 36, or 38.
            strRegExp = "/^3[0,6,8]\\d{12}$/";
        }
        else
        {
            //Others .. Matching Pattern not avl.... So let it through
            args.IsValid = true;
            return;
        }

        Regex reg = new Regex(strRegExp);
        if (reg.IsMatch(args.Value))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }

    }

    protected void CCExpiryCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int month = Convert.ToInt32(CardMonthDropDownList.SelectedValue);
        int year = Convert.ToInt32(CardYearDropDownList.SelectedValue);

        if (year <= DateTime.Now.Year)
        {
            if (year == DateTime.Now.Year)
            {
                if (month < DateTime.Now.Month)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void GetCreditCardDetails(ref RegistrationService.RegistrationInfo regInfo)
    {
       // regInfo.CreditCard = 1;
    }
    protected void BillingStateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (OnStateDropDownChange != null)
            OnStateDropDownChange(sender, e);        
    }
    protected void CardTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (OnCardDropDownChange != null)
            OnCardDropDownChange(sender, e);
    }
}

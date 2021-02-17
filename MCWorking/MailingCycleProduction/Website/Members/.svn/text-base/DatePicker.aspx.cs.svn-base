using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

public partial class Members_DatePicker : System.Web.UI.Page
{
    DateTime minDate = DateTime.Today.AddDays(14);
    DateTime maxDate = DateTime.Today.AddDays(42);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TargetHiddenField.Value = Request.QueryString["field"];

            // Get the query string values.
            NameValueCollection coll = Request.QueryString;

            if (coll.Get("sA") != "" && coll.Get("sA") != null)
            {
                ModeHiddenField.Value = coll.Get("sA");
            }
            else
            {
                ModeHiddenField.Value = "0";
            }

            if (ModeHiddenField.Value == "0")
            {
                Calendar1.VisibleDate = minDate;
            }
            else
            {
                Calendar1.VisibleDate = DateTime.Today;
            }
        }
    }

    protected void Calendar1_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Day.IsSelectable = false;
        }
        else
        {
            if (ModeHiddenField.Value == "0")
            {
                if (e.Day.Date >= minDate && e.Day.Date <= maxDate)
                {
                    e.Cell.Controls.Clear();

                    HtmlGenericControl link = new HtmlGenericControl();
                    link.TagName = "a";
                    link.InnerText = e.Day.DayNumberText;
                    string href = "javascript: SelectDate('" +
                        e.Day.Date.ToString("MM/dd/yyyy") + "');";
                    link.Attributes.Add("href", href);

                    e.Cell.Controls.Add(link);
                }
                else
                {
                    e.Day.IsSelectable = false;
                }
            }
            else
            {
                e.Cell.Controls.Clear();

                HtmlGenericControl link = new HtmlGenericControl();
                link.TagName = "a";
                link.InnerText = e.Day.DayNumberText;
                string href = "javascript: SelectDate('" +
                    e.Day.Date.ToString("MM/dd/yyyy") + "');";
                link.Attributes.Add("href", href);

                e.Cell.Controls.Add(link);
            }
        }
    }
}

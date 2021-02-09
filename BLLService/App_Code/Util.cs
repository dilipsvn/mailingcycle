using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// A Component used to manage common tasks.
/// </summary>
public class Util
{
    public Util()
    {
        //
    }

    public static object[] GetArray(DataTable dataTable)
    {
        object[] rowArray = new object[dataTable.Rows.Count];

        if (dataTable.Rows.Count > 0)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                rowArray[i] = dataTable.Rows[i].ItemArray;
            }
        }

        return rowArray;
    }
}

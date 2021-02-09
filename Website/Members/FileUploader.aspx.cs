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
using System.IO;

public partial class Members_FileUploader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.TotalBytes > 0)
        {
            string pdfFile = Request.QueryString.Get("pdf");
            string path = ConfigurationManager.AppSettings["ApprovedDesignRoot"] +
                "\\ExtractedPages\\" +
                pdfFile.Substring(0, pdfFile.LastIndexOf(".")) +
                "_Page.jpg";
            byte[] buffer;
            int offset = 0;
            FileStream fs = new FileStream(path, FileMode.Create);

            buffer = Request.BinaryRead(Request.TotalBytes);

            for (int i = 0; i < Request.TotalBytes; i++)
            {
                if (Convert.ToInt32(buffer.GetValue(i)) == 13 &&
                    Convert.ToInt32(buffer.GetValue(i + 1)) == 10 &&
                    Convert.ToInt32(buffer.GetValue(i + 2)) == 13 &&
                    Convert.ToInt32(buffer.GetValue(i + 3)) == 10)
                {
                    offset = i + 4;
                    break;
                }
            }
            
            fs.Write(buffer, offset, buffer.Length - (offset + 2));

            fs.Close();
        }
    }
}

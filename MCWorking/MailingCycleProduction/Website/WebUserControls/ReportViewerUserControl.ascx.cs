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
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class WebUserControls_ReportViewerUserControl : System.Web.UI.UserControl
{
    private object dataSource;
    private string dataSourceName;
    private string reportPath;
    private UInt16 reportHeight;
    private UInt16 reportWidth;

    private List<ReportParameter> reportParameters;

    public List<ReportParameter> ReportParameters
    {
        get { return reportParameters; }
        set { reportParameters = value; }
    }

    public object DataSource
    {
        get { return dataSource; }
        set { dataSource = value; }
    }    

    public string DataSourceName
    {
        get { return dataSourceName; }
        set { dataSourceName = value; }
    }

    public string ReportPath
    {
        get { return reportPath; }
        set { reportPath = value; }
    }

    public UInt16 ReportHeight
    {
        get { return reportHeight; }
        set { reportHeight = value; }
    }

    public UInt16 ReportWidth
    {
        get { return reportWidth; }
        set { reportWidth = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportViewer1.LocalReport.ReportPath = ReportPath;
            if (ReportParameters != null && ReportParameters.Count > 0)
                ReportViewer1.LocalReport.SetParameters(ReportParameters);
            if (ReportHeight != 0)
                ReportViewer1.Height = ReportHeight;
            else
                ReportViewer1.Height = 480;
            if (ReportWidth != 0)
                ReportViewer1.Width = ReportWidth;
            else
                ReportViewer1.Width = 720;


            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(dataSourceName, dataSource));
            
        }
    }
}

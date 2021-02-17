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
using Irmac.MailingCycle.BLLServiceLoader.Common;
using Irmac.MailingCycle.BLLServiceLoader;
using log4net;

[ValidationProperty("SelectedValue")]
public partial class ListOfAgentsWebUserControl : System.Web.UI.UserControl
{
    protected static readonly ILog log = LogManager.GetLogger(typeof(ListOfAgentsWebUserControl));
    public event EventHandler OnSelectChanged;
    public string SelectedValue
    {
        get { return AgentIdDropDownList.SelectedValue; }
        set { AgentIdDropDownList.SelectedValue = value; }
    }
    public string SelectedText
    {
        get { return AgentIdDropDownList.SelectedItem.Text; }
    }
    public bool AutoPostBack
    {
        set { AgentIdDropDownList.AutoPostBack = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void FillDropDown()
    {
        ServiceAccess serviceLoader = ServiceAccess.GetInstance();
        CommonService commonService = serviceLoader.GetCommon();
        AgentIdDropDownList.DataSource = commonService.GetAgentsList();
        AgentIdDropDownList.DataValueField = "UserId";
        AgentIdDropDownList.DataTextField = "UserName";
        AgentIdDropDownList.DataBind();
        AgentIdDropDownList.Items.Insert(0, new ListItem("<Select An Agent>","0"));
    }
    protected void AgentIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (OnSelectChanged != null)
            OnSelectChanged(sender, e);
    }
}

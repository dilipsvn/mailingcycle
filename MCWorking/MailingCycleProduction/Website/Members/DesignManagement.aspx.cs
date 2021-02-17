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
using System.Collections.Generic;
using System.Collections.Specialized;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.Model;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using DesignService = Irmac.MailingCycle.BLLServiceLoader.Design;

public partial class Agent_DesignManagement : System.Web.UI.Page
{
    protected static readonly ILog log = 
        LogManager.GetLogger(typeof(Agent_DesignManagement));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    #region Private Methods

    private void DisplayDesigns(int agentId)
    {
        try
        {
            DesignService.DesignService designService = serviceLoader.GetDesign();
            IList<DesignService.DesignInfo> designs =
                designService.GetListAll(agentId);

            DesignService.DesignInfo design = new DesignService.DesignInfo();
            design.Category = new DesignService.LookupInfo();
            design.Category.LookupId = 17;
            design.Category.Name = DesignCategory.PowerKard.ToString();
            design.Status = new DesignService.LookupInfo();
            design.Status.LookupId = 21;
            design.Status.Name = "Not Uploaded";
            DesignService.DesignInfo brochure = new DesignService.DesignInfo();
            brochure.Category = new DesignService.LookupInfo();
            brochure.Category.LookupId = 18;
            brochure.Category.Name = DesignCategory.Brochure.ToString();
            brochure.Status = new DesignService.LookupInfo();
            brochure.Status.LookupId = 21;
            brochure.Status.Name = "Not Uploaded";
            List<DesignService.DesignInfo> prevDesigns =
                new List<DesignService.DesignInfo>();
            List<DesignService.DesignInfo> prevBrochures =
                new List<DesignService.DesignInfo>();
            
            foreach (DesignService.DesignInfo designInfo in designs)
            {
                if (designInfo.Category.LookupId == (int)DesignCategory.PowerKard)
                {
                    if (designInfo.Status.LookupId == (int)DesignStatus.Inactivated)
                    {
                        prevDesigns.Add(designInfo);
                    }
                    else
                    {
                        design = designInfo;
                    }
                }
                else
                {
                    if (designInfo.Status.LookupId == (int)DesignStatus.Inactivated)
                    {
                        prevBrochures.Add(designInfo);
                    }
                    else
                    {
                        brochure = designInfo;
                    }
                }
            }

            SetControls(design, PowerKardLengthTextBox, PowerKardWidthTextBox,
                PowerkardHyperLink, PowerKardTypeDropDownList, PowerKardEditButton,
                PowerKardStatusLabel);
            SetControls(brochure, BrochureLengthTextBox, BrochureWidthTextBox,
                BrochureHyperLink, BrochureTypeDropDownList, BrochureEditButton,
                BrochureStatusLabel);

            DesignIdHiddenField.Value = design.DesignId.ToString();
            BrochureIdHiddenField.Value = brochure.DesignId.ToString();

            // Display previous designs.
            if (prevDesigns.Count > 0)
            {
                PreviousDesignsRow.Visible = true;
                ShowPreviousDesigns(prevDesigns, PreviousDesignsGridView, "EditDesign");
            }
            else
            {
                PreviousDesignsRow.Visible = false;
            }
            if (prevBrochures.Count > 0)
            {
                PreviousBrochuresRow.Visible = true;
                ShowPreviousDesigns(prevBrochures, PreviousBrochuresGridView, "EditBrochure");
            }
            else
            {
                PreviousBrochuresRow.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
        }
    }

    private void ShowPreviousDesigns(List<DesignService.DesignInfo> designs,
        GridView gridView, string pageName)
    {
        DataTable items = new DataTable();
        DataRow row;

        items.Columns.Add("DesignId");
        items.Columns.Add("Url");
        items.Columns.Add("DeletedOn");

        foreach (DesignService.DesignInfo designInfo in designs)
        {
            row = items.NewRow();

            row["DesignId"] = designInfo.DesignId.ToString();
            row["Url"] = "~/Members/" + pageName + ".aspx?" +
                "id=" + designInfo.DesignId.ToString() +
                "&aId=" + designInfo.UserId.ToString() +
                "&aName=" + AgentNameHiddenField.Value +
                "&mode=View" +
                "&type=" + designInfo.Type.Name.Substring(0, 1) +
                "&length=" + designInfo.Size.Width.ToString("####.####") +
                "&width=" + designInfo.Size.Height.ToString("####.####");
            row["DeletedOn"] = designInfo.LastModifyDate.ToString("MM/dd/yyyy");

            items.Rows.Add(row);
        }

        gridView.DataSource = items;
        gridView.DataBind();
    }

    private void SetControls(DesignService.DesignInfo designInfo,
        TextBox lengthTextBox, TextBox widthTextBox,
        HyperLink hyperLink, DropDownList typeDropDownList,
        Button editButton, Label statusLabel)
    {
        if (designInfo.Status.LookupId == (int)DesignStatus.NotUploaded)
        {
            lengthTextBox.Enabled = false;
            widthTextBox.Enabled = false;
        }
        else
        {
            // Display the data.
            hyperLink.NavigateUrl = "~/Members/UserData/" + AgentIdHiddenField.Value + "/" + designInfo.LowResolutionFile;
            hyperLink.Target = "_blank";
            typeDropDownList.SelectedValue = designInfo.Type.Name.Substring(0, 1) + "|" +
                (designInfo.Type.Name == "Standard" ? designInfo.Size.Width.ToString("####.####") : "0") + "|" +
                (designInfo.Type.Name == "Standard" ? designInfo.Size.Height.ToString("####.####") : "0");
            typeDropDownList.Enabled = false;
            lengthTextBox.Text = designInfo.Size.Width.ToString("####.####");
            lengthTextBox.Enabled = false;
            widthTextBox.Text = designInfo.Size.Height.ToString("####.####");
            widthTextBox.Enabled = false;

            // Set the action button.
            if (designInfo.Status.Name == "Uploaded")
            {
                editButton.Text = "Edit " + designInfo.Category.Name;
            }
            else if (designInfo.Status.Name == "Hold")
            {
                editButton.Text = "View " + designInfo.Category.Name;
            }
            else
            {
                RegistrationService.LoginInfo loginInfo =
                    (RegistrationService.LoginInfo)Session["loginInfo"];

                if (loginInfo.Role == RegistrationService.UserRole.Agent)
                {
                    editButton.Text = "View " + designInfo.Category.Name;
                }
                else if (loginInfo.Role == RegistrationService.UserRole.Printer)
                {
                    if (designInfo.Status.Name == "Submitted")
                    {
                        editButton.Text = "Review " + designInfo.Category.Name;
                    }
                    else
                    {
                        editButton.Text = "Edit " + designInfo.Category.Name;
                    }
                }
                else
                {
                    editButton.Text = "Edit " + designInfo.Category.Name;
                }
            }
        }

        statusLabel.Text = designInfo.Status.Name;
    }

    private void EnableControls(bool enable)
    {
        PowerKardTypeDropDownList.Enabled = enable;
        PowerKardLengthTextBox.Enabled = enable;
        PowerKardWidthTextBox.Enabled = enable;
        PowerKardEditButton.Enabled = enable;

        BrochureTypeDropDownList.Enabled = enable;
        BrochureLengthTextBox.Enabled = enable;
        BrochureWidthTextBox.Enabled = enable;
        BrochureEditButton.Enabled = enable;
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Get the logged in account information.
            RegistrationService.LoginInfo loginInfo = 
                (RegistrationService.LoginInfo)Session["loginInfo"];

            if (loginInfo.Role == RegistrationService.UserRole.Agent)
            {
                // Load the agent specific design and brochure details.
                AgentIdHiddenField.Value = loginInfo.UserId.ToString();

                DisplayDesigns(loginInfo.UserId);
            }
            else
            {
                try
                {
                    AgentSelectionPanel.Visible = true;

                    // Get the list of agents and display.
                    CommonService.CommonService commonService = serviceLoader.GetCommon();

                    AgentNameDropDownList.DataSource = commonService.GetAgentsList();
                    AgentNameDropDownList.DataValueField = "UserId";
                    AgentNameDropDownList.DataTextField = "UserName";
                    AgentNameDropDownList.DataBind();

                    AgentNameDropDownList.Items.Insert(0, new ListItem("<Select an Agent>", "-1"));

                    // Set the design controls.
                    EnableControls(false);

                    // Get the query string values and set the agent id.
                    NameValueCollection coll = Request.QueryString;

                    if (coll.Get("aId") != "" && coll.Get("aId") != null)
                    {
                        AgentNameDropDownList.SelectedValue = coll.Get("aId");
                        GoButton_Click(AgentNameDropDownList, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                    ErrorMessageLabel.Visible = true;

                    log.Error("Unknown Error", ex);
                }
            }
        }
    }

    protected void GoButton_Click(object sender, EventArgs e)
    {
        EnableControls(true);

        // Load the agent specific design and brochure details.
        AgentIdHiddenField.Value = AgentNameDropDownList.SelectedValue;
        AgentNameHiddenField.Value = AgentNameDropDownList.SelectedItem.Text;

        DisplayDesigns(Convert.ToInt32(AgentNameDropDownList.SelectedValue));
    }

    protected void PowerKardEditButton_Click(object sender, EventArgs e)
    {
        string caption = ((Button)sender).Text;
        string mode = caption.Substring(0, caption.IndexOf(" "));
        string[] selectedArgs = PowerKardTypeDropDownList.SelectedValue.Split("|".ToCharArray());
        string type = selectedArgs[0];
        decimal length = 0, width = 0;

        if (type == DesignType.Standard.ToString().Substring(0, 1))
        {
            length = Convert.ToDecimal(selectedArgs[1]);
            width = Convert.ToDecimal(selectedArgs[2]);
        }
        else
        {
            length = Convert.ToDecimal(PowerKardLengthTextBox.Text);
            width = Convert.ToDecimal(PowerKardWidthTextBox.Text);
        }

        string queryString = "?id=" + DesignIdHiddenField.Value + 
            "&aId=" + AgentIdHiddenField.Value +
            "&aName=" + AgentNameHiddenField.Value +
            "&mode=" + mode + "&type=" + type +
            "&length=" + length.ToString() + "&width=" + width.ToString();

        Response.Redirect("~/Members/EditDesign.aspx" + queryString);
    }

    protected void BrochureEditButton_Click(object sender, EventArgs e)
    {
        string caption = ((Button)sender).Text;
        string mode = caption.Substring(0, caption.IndexOf(" "));
        string[] selectedArgs = BrochureTypeDropDownList.SelectedValue.Split("|".ToCharArray());
        string type = selectedArgs[0];
        decimal length = 0, width = 0;

        if (type == DesignType.Standard.ToString().Substring(0, 1))
        {
            length = Convert.ToDecimal(selectedArgs[1]);
            width = Convert.ToDecimal(selectedArgs[2]);
        }
        else
        {
            length = Convert.ToDecimal(BrochureLengthTextBox.Text);
            width = Convert.ToDecimal(BrochureWidthTextBox.Text);
        }

        string queryString = "?id=" + BrochureIdHiddenField.Value +
            "&aId=" + AgentIdHiddenField.Value +
            "&aName=" + AgentNameHiddenField.Value +
            "&mode=" + mode + "&type=" + type +
            "&length=" + length.ToString() + "&width=" + width.ToString();

        Response.Redirect("~/Members/EditBrochure.aspx" + queryString);
    }
}

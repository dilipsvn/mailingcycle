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
using System.Collections.Generic;
using System.IO;
using log4net;
using Irmac.MailingCycle.BLLServiceLoader;
using Irmac.MailingCycle.Model;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using DesignService = Irmac.MailingCycle.BLLServiceLoader.Design;

public partial class Members_EditBrochure : System.Web.UI.Page
{
    protected static readonly ILog log = 
        LogManager.GetLogger(typeof(Members_EditBrochure));
    ServiceAccess serviceLoader = ServiceAccess.GetInstance();

    private void DisableDesignInformation()
    {
        TypeDropDownList.Enabled = false;
        LengthTextBox.Enabled = false;
        WidthTextBox.Enabled = false;

        LowResolutionFileRemoveHyperLink.HRef = "";
        LowResolutionFileRemoveHyperLink.Disabled = true;
        HighResolutionFileRemoveHyperLink.HRef = "";
        HighResolutionFileRemoveHyperLink.Disabled = true;
        AdditionalFileUpload.Enabled = false;
        AdditionalFileRemoveHyperLink.HRef = "";
        AdditionalFileRemoveHyperLink.Disabled = true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the query string values.
        NameValueCollection coll = Request.QueryString;

        int id = Convert.ToInt32(coll.Get("id"));
        string mode = coll.Get("mode");
        string type = coll.Get("type");
        decimal length = Convert.ToDecimal(coll.Get("length"));
        decimal width = Convert.ToDecimal(coll.Get("width"));
        int agentId = Convert.ToInt32(coll.Get("aId"));
        string agentName = coll.Get("aName");

        // Change the title of the page.
        Page.Title = "Mailing Cycle " + mode + " Brochure";
        PageTitleLabel.Text = mode + " Brochure";
        if (mode == "Edit")
        {
            AddPageDescriptionPanel.Visible = false;
            EditPageDescriptionPanel.Visible = true;
        }
        else if (mode == "Review")
        {
            AddPageDescriptionPanel.Visible = false;
            ReviewPageDescriptionPanel.Visible = true;
        }
        else if (mode == "View")
        {
            AddPageDescriptionPanel.Visible = false;
            ViewPageDescriptionPanel.Visible = true;
        }
        if (agentName != "")
        {
            AgentNameLabel.Text = "Agent Name: " + agentName + "&nbsp;";
        }

        ErrorMessageLabel.Visible = false;

        if (!IsPostBack)
        {
            // Get the logged in account information.
            RegistrationService.LoginInfo loginInfo =
                (RegistrationService.LoginInfo)Session["loginInfo"];

            // Set the required query string varables into hidden fields.
            IdHiddenField.Value = id.ToString();
            ModeHiddenField.Value = mode.ToString();
            AgentIdHiddenField.Value = agentId.ToString();

            // Set the controls based on the role.
            if (loginInfo.Role == RegistrationService.UserRole.Agent)
            {
                NotesRow.Visible = false;
            }

            // Set the design details section.
            TypeDropDownList.SelectedValue = type
                + "|" + (type == "S" ? length.ToString("####.####") : "0")
                + "|" + (type == "S" ? width.ToString("####.####") : "0");
            LengthTextBox.Text = length.ToString("####.####");
            WidthTextBox.Text = width.ToString("####.####");
            if (type != "C")
            {
                LengthTextBox.Enabled = false;
                WidthTextBox.Enabled = false;
            }

            // Get the design details, if one exists.
            if (id != 0)
            {
                try
                {
                    DesignService.DesignService designService = serviceLoader.GetDesign();

                    DesignService.DesignInfo design = designService.Get(id);

                    // Display Data - Status.
                    AgentIdHiddenField.Value = design.UserId.ToString();
                    StatusLabel.Text = design.Status.Name;
                    UsedHiddenField.Value = design.Used.ToString();

                    // Display Data - Upload Files.
                    string path = Server.MapPath("~/Members/UserData/" + AgentIdHiddenField.Value) + "\\";
                    string lowResolutionFile, highResolutionFile, additionalFile = string.Empty;

                    lowResolutionFile = design.LowResolutionFile;
                    LowResolutionFileHyperLink.Text = lowResolutionFile.Substring(lowResolutionFile.IndexOf("_") + 1);
                    LowResolutionFileHyperLink.NavigateUrl = "~/Members/UserData/" +
                        AgentIdHiddenField.Value + "/" + lowResolutionFile;
                    LowResolutionFileHyperLink.Target = "_blank";
                    FileInfo file = new FileInfo(path + lowResolutionFile);
                    if (file.Exists)
                    {
                        LowResolutionFileSizeLabel.Text = Convert.ToInt32(file.Length / 1024).ToString() + " KB";
                    }
                    else
                    {
                        LowResolutionFileSizeLabel.Text = "-";
                    }
                    LowResolutionFileNotExistsPanel.Style.Value =
                        "position: absolute; visibility: hidden;";
                    LowResolutionFileExistsPanel.Style.Value =
                        "position: relative; visibility: visible;";
                    LowResolutionFileRequiredFieldValidator.Enabled = false;
                    LowResolutionFileHiddenField.Value = lowResolutionFile;

                    highResolutionFile = design.HighResolutionFile;
                    HighResolutionFileHyperLink.Text = highResolutionFile.Substring(highResolutionFile.IndexOf("_") + 1);
                    HighResolutionFileHyperLink.NavigateUrl = "~/Members/UserData/" +
                        AgentIdHiddenField.Value + "/" + highResolutionFile;
                    HighResolutionFileHyperLink.Target = "_blank";
                    file = new FileInfo(path + highResolutionFile);
                    if (file.Exists)
                    {
                        HighResolutionFileSizeLabel.Text = Convert.ToInt32(file.Length / 1024).ToString() + " KB";
                    }
                    else
                    {
                        HighResolutionFileSizeLabel.Text = "-";
                    }
                    HighResolutionFileNotExistsPanel.Style.Value =
                        "position: absolute; visibility: hidden;";
                    HighResolutionFileExistsPanel.Style.Value =
                        "position: relative; visibility: visible;";
                    HighResolutionFileRequiredFieldValidator.Enabled = false;
                    HighResolutionFileHiddenField.Value = highResolutionFile;

                    if (design.ExtraFile != "")
                    {
                        additionalFile = design.ExtraFile;
                        AdditionalFileHyperLink.Text = additionalFile.Substring(additionalFile.IndexOf("_") + 1);
                        AdditionalFileHyperLink.NavigateUrl = "~/Members/UserData/" +
                            AgentIdHiddenField.Value + "/" + additionalFile;
                        AdditionalFileHyperLink.Target = "_blank";
                        file = new FileInfo(path + additionalFile);
                        if (file.Exists)
                        {
                            AdditionalFileSizeLabel.Text = Convert.ToInt32(file.Length / 1024).ToString() + " KB";
                        }
                        else
                        {
                            AdditionalFileSizeLabel.Text = "-";
                        }
                        AdditionalFileNotExistsPanel.Style.Value =
                            "position: absolute; visibility: hidden;";
                        AdditionalFileExistsPanel.Style.Value =
                            "position: relative; visibility: visible;";
                        AdditionalFileHiddenField.Value = additionalFile;
                    }

                    // Display Data - History.
                    HistoryTextBox.Text = design.History;

                    if (mode == "View")
                    {
                        DisableDesignInformation();

                        NotesTextBox.Enabled = false;

                        AgentButtonsPanel.Visible = false;
                        ReadOnlyButtonsPanel.Visible = true;
                        AgentButtonsHelpPanel.Visible = false;
                        ReadOnlyButtonsHelpPanel.Visible = true;
                    }
                    else if (mode == "Review")
                    {
                        AgentButtonsPanel.Visible = false;
                        ReviewButtonsPanel.Visible = true;
                        AgentButtonsHelpPanel.Visible = false;
                        ReviewButtonsHelpPanel.Visible = true;
                    }
                    else if (mode == "Edit")
                    {
                        if (StatusLabel.Text == "Uploaded")
                        {
                            if (loginInfo.Role != RegistrationService.UserRole.Agent)
                            {
                                AgentButtonsPanel.Visible = false;
                                ReadWriteButtonsPanel.Visible = true;
                                AgentButtonsHelpPanel.Visible = false;
                                ReadWriteButtonsHelpPanel.Visible = true;
                            }
                        }
                        else if (StatusLabel.Text == "Submitted")
                        {
                            DisableDesignInformation();

                            AgentButtonsPanel.Visible = false;
                            ReadWriteButtonsPanel.Visible = true;
                            AgentButtonsHelpPanel.Visible = false;
                            ReadWriteButtonsHelpPanel.Visible = true;
                        }
                        else if (StatusLabel.Text == "Approved")
                        {
                            DisableDesignInformation();

                            AgentButtonsPanel.Visible = false;
                            DeleteButtonsPanel.Visible = true;
                            AgentButtonsHelpPanel.Visible = false;
                            DeleteButtonsHelpPanel.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                    ErrorMessageLabel.Visible = true;

                    log.Error("Unknown Error", ex);
                }
            }

            if (mode == "Add")
            {
                if (loginInfo.Role != RegistrationService.UserRole.Agent)
                {
                    AgentButtonsPanel.Visible = false;
                    ReadWriteButtonsPanel.Visible = true;
                    AgentButtonsHelpPanel.Visible = false;
                    ReadWriteButtonsHelpPanel.Visible = true;
                }
            }
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        RegistrationService.LoginInfo loginInfo =
                (RegistrationService.LoginInfo)Session["loginInfo"];
        int statusId = 0;

        switch (StatusLabel.Text)
        {
            case "Not Uploaded":
                statusId = (int)DesignStatus.Uploaded;
                break;
            case "Uploaded":
                statusId = (int)DesignStatus.Uploaded;
                break;
            case "Submitted":
                statusId = (int)DesignStatus.Submitted;
                break;
        }

        if (Save(statusId))
        {
            string queryString = "?aId=" + AgentIdHiddenField.Value;

            Response.Redirect("~/Members/DesignManagement.aspx" + queryString);
        }
        else
        {
            ResetUploadFilePanels();
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        if (Save((int)DesignStatus.Submitted))
        {
            string queryString = "?aId=" + AgentIdHiddenField.Value;

            Response.Redirect("~/Members/DesignManagement.aspx" + queryString);
        }
        else
        {
            ResetUploadFilePanels();
        }
    }

    protected void ApproveButton_Click(object sender, EventArgs e)
    {
        if (Save((int)DesignStatus.Approved))
        {
            string queryString = "?aId=" + AgentIdHiddenField.Value;

            Response.Redirect("~/Members/DesignManagement.aspx" + queryString);
        }
        else
        {
            ResetUploadFilePanels();
        }
    }

    protected void RejectButton_Click(object sender, EventArgs e)
    {
        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        // Get the upload location.
        string path = Server.MapPath("~/Members/UserData/" + AgentIdHiddenField.Value);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        // Delete the files and the record.
        string lowResolutionFile = LowResolutionFileHiddenField.Value;
        string highResolutionFile = HighResolutionFileHiddenField.Value;
        string additionalFile = AdditionalFileHiddenField.Value;

        try
        {
            if (IdHiddenField.Value != "0")
            {
                if (File.Exists(path + "\\" + lowResolutionFile))
                {
                    File.Delete(path + "\\" + lowResolutionFile);
                }
            }

            if (IdHiddenField.Value != "0")
            {
                if (File.Exists(path + "\\" + highResolutionFile))
                {
                    File.Delete(path + "\\" + highResolutionFile);
                }
            }

            if (IdHiddenField.Value != "0" && additionalFile != "")
            {
                if (File.Exists(path + "\\" + additionalFile))
                {
                    File.Delete(path + "\\" + additionalFile);
                }
            }

            DesignService.DesignService designService = serviceLoader.GetDesign();

            int designId = Convert.ToInt32(IdHiddenField.Value);

            designService.Delete(designId, loginInfo.UserId);

            try
            {
                Util.Design.SendEmailAsRejected(Convert.ToInt32(AgentIdHiddenField.Value), 
                    "Brochure", NotesTextBox.Text.Trim(), Request.ApplicationPath);
            }
            catch (Exception ex)
            {
                log.Error("Unknown Error", ex);
            }

            string queryString = "?aId=" + AgentIdHiddenField.Value;

            Response.Redirect("~/Members/DesignManagement.aspx" + queryString);
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
            ResetUploadFilePanels();
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        if (UsedHiddenField.Value == DesignUsed.Never.ToString())
        {
            // Get the upload location.
            string path = Server.MapPath("~/Members/UserData/" + AgentIdHiddenField.Value);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Delete the files and the record.
            string lowResolutionFile = LowResolutionFileHiddenField.Value;
            string highResolutionFile = HighResolutionFileHiddenField.Value;
            string additionalFile = AdditionalFileHiddenField.Value;

            try
            {
                if (File.Exists(path + "\\" + lowResolutionFile))
                {
                    File.Delete(path + "\\" + lowResolutionFile);
                }

                if (File.Exists(path + "\\" + highResolutionFile))
                {
                    File.Delete(path + "\\" + highResolutionFile);
                }

                if (additionalFile != "")
                {
                    if (File.Exists(path + "\\" + additionalFile))
                    {
                        File.Delete(path + "\\" + additionalFile);
                    }
                }

                DesignService.DesignService designService = serviceLoader.GetDesign();

                int designId = Convert.ToInt32(IdHiddenField.Value);

                designService.Delete(designId, loginInfo.UserId);

                string queryString = "?aId=" + AgentIdHiddenField.Value;

                Response.Redirect("~/Members/DesignManagement.aspx" + queryString);
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
                ErrorMessageLabel.Visible = true;

                log.Error("Unknown Error", ex);
                ResetUploadFilePanels();
            }
        }
        else if (UsedHiddenField.Value == DesignUsed.Found.ToString())
        {
            if (Save((int)DesignStatus.Inactivated))
            {
                string queryString = "?aId=" + AgentIdHiddenField.Value;

                Response.Redirect("~/Members/DesignManagement.aspx" + queryString);
            }
            else
            {
                ResetUploadFilePanels();
            }
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        string queryString = "?aId=" + AgentIdHiddenField.Value;

        Response.Redirect("~/Members/DesignManagement.aspx" + queryString);
    }

    private bool ValidateFiles()
    {
        return Util.Design.ValidateFiles(LowResolutionFileUpload,
            HighResolutionFileUpload, AdditionalFileUpload,
            ref ErrorMessageLabel);
    }

    private bool Save(int statusId)
    {
        // Get the logged in account information.
        RegistrationService.LoginInfo loginInfo =
            (RegistrationService.LoginInfo)Session["loginInfo"];

        // Get the upload location.
        string path = Server.MapPath("~/Members/UserData/" + AgentIdHiddenField.Value);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (!ValidateFiles())
        {
            return false;
        }

        // Upload the files.
        string lowResolutionFile = LowResolutionFileHiddenField.Value;
        string highResolutionFile = HighResolutionFileHiddenField.Value;
        string additionalFile = AdditionalFileHiddenField.Value;

        try
        {
            Util.Design.UploadFiles(path, ref lowResolutionFile,
                ref highResolutionFile, ref additionalFile,
                Convert.ToInt32(IdHiddenField.Value),
                LowResolutionFileUpload, HighResolutionFileUpload,
                AdditionalFileUpload, ref RemoveAdditionalFileHiddenField);
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
            return false;
        }

        // Save the data.
        try
        {
            string[] typeArgs = TypeDropDownList.SelectedValue.Split("|".ToCharArray());
            decimal length = 0, width = 0;

            DesignService.DesignService designService = serviceLoader.GetDesign();
            DesignService.DesignInfo design = new DesignService.DesignInfo();

            // Design Details.
            design.DesignId = Convert.ToInt32(IdHiddenField.Value);
            design.UserId = Convert.ToInt32(AgentIdHiddenField.Value);
            DesignService.LookupInfo category = new DesignService.LookupInfo();
            category.LookupId = (int)DesignCategory.Brochure;
            category.Name = DesignCategory.Brochure.ToString();
            design.Category = category;
            DesignService.LookupInfo type = new DesignService.LookupInfo();
            if (typeArgs[0] == DesignType.Standard.ToString().Substring(0, 1))
            {
                type.LookupId = (int)DesignType.Standard;
                type.Name = DesignType.Standard.ToString();
                length = Convert.ToDecimal(typeArgs[1]);
                width = Convert.ToDecimal(typeArgs[2]);
            }
            else
            {
                type.LookupId = (int)DesignType.Custom;
                type.Name = DesignType.Custom.ToString();
                length = Convert.ToDecimal(LengthTextBox.Text);
                width = Convert.ToDecimal(WidthTextBox.Text);
            }
            design.Type = type;
            DesignService.SizeF size = new DesignService.SizeF();
            size.Width = (float)length;
            size.Height = (float)width;
            design.Size = size;

            // Upload Files.
            design.LowResolutionFile = lowResolutionFile;
            design.HighResolutionFile = highResolutionFile;
            design.ExtraFile = additionalFile;

            // Additional fields.
            DesignService.LookupInfo status = new DesignService.LookupInfo();
            status.LookupId = statusId;
            design.Status = status;
            design.LastModifyBy = loginInfo.UserId;
            design.Comments = NotesTextBox.Text;
            if (statusId == (int)DesignStatus.Approved)
            {
                design.ApproveBy = loginInfo.UserId;
            }
            else
            {
                design.ApproveBy = 0;
            }

            designService.Update(loginInfo.UserId, design);

            try
            {
                if (statusId == (int)DesignStatus.Approved)
                {
                    if (StatusLabel.Text == "Submitted")
                    {
                        Util.Design.SendEmailAsApproved(design, Request.ApplicationPath,
                            Request.Url.ToString());
                    }
                }
                else if (statusId == (int)DesignStatus.Submitted)
                {
                    if (design.UserId == design.LastModifyBy)
                    {
                        Util.Design.SendEmailAsSubmitted(design, Request.ApplicationPath,
                            Request.Url.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Unknown Error", ex);
            }

            return true;
        }
        catch (Exception ex)
        {
            ErrorMessageLabel.Text = "Unable to process the request. Please contact your administrator.";
            ErrorMessageLabel.Visible = true;

            log.Error("Unknown Error", ex);
            return false;
        }
    }

    private void ResetUploadFilePanels()
    {
        Util.Design.ResetUploadFilePanels(IdHiddenField, LowResolutionFileUpload,
            LowResolutionFileNotExistsPanel, LowResolutionFileExistsPanel,
            LowResolutionFileRequiredFieldValidator,
            HighResolutionFileUpload,
            HighResolutionFileNotExistsPanel, HighResolutionFileExistsPanel,
            HighResolutionFileRequiredFieldValidator,
            AdditionalFileUpload,
            AdditionalFileNotExistsPanel, AdditionalFileExistsPanel);
    }
}

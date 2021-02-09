using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web.Configuration;
using log4net;
using TemplateParser;
using Irmac.MailingCycle.BLLServiceLoader;
using DesignService = Irmac.MailingCycle.BLLServiceLoader.Design;
using ScheduleService = Irmac.MailingCycle.BLLServiceLoader.Schedule;
using RegistrationService = Irmac.MailingCycle.BLLServiceLoader.Registration;
using CommonService = Irmac.MailingCycle.BLLServiceLoader.Common;

/// <summary>
/// A Component used to manage common tasks.
/// </summary>
public class Util
{
    protected static readonly ILog log = 
        LogManager.GetLogger(typeof(Util));
    protected static readonly ServiceAccess serviceLoader = 
        ServiceAccess.GetInstance();

    public Util()
    {
        //
    }

    public static string GetFileName(string name)
    {
        string[] invalidChars = new string[] { "\\", "/", ":", "*", "?", "'", 
            "\"", "<", ">", "|", ";", "+", "#", "%" };

        foreach (string c in invalidChars)
        {
            name = name.Replace(c, "");
        }

        return name;
    }

    public static string GetExcelSheetName(string name)
    {
        string[] invalidChars = new string[] { " ", "\\", "/", ":", "*", "?", 
            "-", "'", "\"", "`", "<", ">", "|", "[", "]", "{", "}", "(", ")", 
            "=", ";", ",", "~", "+", "!", "@", "&", "#", "$", "%", "^" };

        foreach (string c in invalidChars)
        {
            name = name.Replace(c, "");
        }

        if (name.Length > 30)
        {
            name = name.Substring(0, 30);
        }

        return name;
    }

    public static DataTable GetDataTable(object[] rowArray)
    {
        DataTable dataTable = new DataTable("DATA_SUMMARY");

        if (rowArray.Length > 0)
        {
            object[] row = (object[])rowArray[0];

            for (int i = 0; i < row.Length; i++)
            {
                dataTable.Columns.Add();
            }

            for (int i = 0; i < rowArray.Length; i++)
            {
                row = (object[])rowArray[i];

                dataTable.Rows.Add(row);
            }
        }

        return dataTable;
    }

    public static void CalculateMessageActual(ScheduleService.RectangleF messageRectangle,
        ScheduleService.SizeF size, string pageImagePath, out float zoomFactor, 
        out RectangleF messageRectangleActual)
    {
        // Load the image file and get the zoom factor.
        Bitmap bitmap = new Bitmap(pageImagePath);

        float imageResolution = bitmap.HorizontalResolution;
        float screenResolution = bitmap.Width / size.Width;
        zoomFactor = screenResolution / imageResolution;

        bitmap.Dispose();

        // Reclaculate the message location in pixels.
        messageRectangleActual = new RectangleF();
        messageRectangleActual.X = messageRectangle.X * screenResolution;
        messageRectangleActual.Y = messageRectangle.Y * screenResolution;
        messageRectangleActual.Width = messageRectangle.Width * screenResolution;
        messageRectangleActual.Height = messageRectangle.Height * screenResolution;
    }

    public class Mail
    {
        public Mail()
        {
            //
        }

        public static void Send(string templatePath, Hashtable variables,
            MailAddressCollection mailAddresses, string subject,
            string applicationPath)
        {
            Parser parser = new Parser(templatePath, variables);
            
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = 
                new MailAddress("MailingCycle@MailingCycle.com", "MailingCycle");
            foreach (MailAddress mailAddress in mailAddresses)
            {
                mailMessage.To.Add(mailAddress);
            }
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = parser.Parse();
            mailMessage.Priority = MailPriority.Normal;

            Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(applicationPath);
            MailSettingsSectionGroup mailSettingsSection =
                configuration.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;

            if (mailSettingsSection != null)
            {
                int port = mailSettingsSection.Smtp.Network.Port;
                string host = mailSettingsSection.Smtp.Network.Host;
                string password = mailSettingsSection.Smtp.Network.Password;
                string username = mailSettingsSection.Smtp.Network.UserName;

                SmtpClient smtpClient = new SmtpClient(host, 587);
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);
            }
        }
    }

    public class Design
    {
        public Design()
        {
            //
        }

        public static void ResetUploadFilePanels(HiddenField designId,
            FileUpload lowResolutionFileUpload,
            HtmlGenericControl lowResolutionFileNotExistsPanel,
            HtmlGenericControl lowResolutionFileExistsPanel,
            RequiredFieldValidator lowResolutionFileRequiredFieldValidator,
            FileUpload highResolutionFileUpload,
            HtmlGenericControl highResolutionFileNotExistsPanel,
            HtmlGenericControl highResolutionFileExistsPanel,
            RequiredFieldValidator highResolutionFileRequiredFieldValidator,
            FileUpload additionalFileUpload,
            HtmlGenericControl additionalFileNotExistsPanel,
            HtmlGenericControl additionalFileExistsPanel)
        {
            if (lowResolutionFileUpload.HasFile && designId.Value != "0")
            {
                lowResolutionFileNotExistsPanel.Style.Value =
                        "position: relative; visibility: visible;";
                lowResolutionFileExistsPanel.Style.Value =
                    "position: absolute; visibility: hidden;";
                lowResolutionFileRequiredFieldValidator.Enabled = true;
            }

            if (highResolutionFileUpload.HasFile && designId.Value != "0")
            {
                highResolutionFileNotExistsPanel.Style.Value =
                        "position: relative; visibility: visible;";
                highResolutionFileExistsPanel.Style.Value =
                    "position: absolute; visibility: hidden;";
                highResolutionFileRequiredFieldValidator.Enabled = true;
            }

            if (additionalFileUpload.HasFile && designId.Value != "0")
            {
                additionalFileNotExistsPanel.Style.Value =
                        "position: relative; visibility: visible;";
                additionalFileExistsPanel.Style.Value =
                    "position: absolute; visibility: hidden;";
            }
        }

        public static bool ValidateFiles(FileUpload lowResolutionFileUpload,
            FileUpload highResolutionFileUpload, FileUpload additionalFileUpload,
            ref Label errorMessageLabel)
        {
            if (lowResolutionFileUpload.HasFile)
            {
                if (!lowResolutionFileUpload.FileName.ToLower().EndsWith(".pdf"))
                {
                    errorMessageLabel.Text = "Enter a valid Low-Resolution File (.pdf only).";
                    errorMessageLabel.Visible = true;

                    return false;
                }

                if (lowResolutionFileUpload.PostedFile.ContentLength > (2 * 1024 * 1024))
                {
                    errorMessageLabel.Text = "Enter a valid Low-Resolution File (Maximum size limit 2 MB).";
                    errorMessageLabel.Visible = true;

                    return false;
                }
            }

            if (highResolutionFileUpload.HasFile)
            {
                if (!highResolutionFileUpload.FileName.ToLower().EndsWith(".pdf"))
                {
                    errorMessageLabel.Text = "Enter a valid High-Resolution File (.pdf only).";
                    errorMessageLabel.Visible = true;

                    return false;
                }

                if (highResolutionFileUpload.PostedFile.ContentLength > (20 * 1024 * 1024))
                {
                    errorMessageLabel.Text = "Enter a valid High-Resolution File (Maximum size limit 20 MB).";
                    errorMessageLabel.Visible = true;

                    return false;
                }
            }

            if (additionalFileUpload.HasFile)
            {
                if (additionalFileUpload.FileName.ToLower().EndsWith(".exe") ||
                    additionalFileUpload.FileName.ToLower().EndsWith(".dll") ||
                    additionalFileUpload.FileName.ToLower().EndsWith(".com") ||
                    additionalFileUpload.FileName.ToLower().EndsWith(".msi") ||
                    additionalFileUpload.FileName.ToLower().EndsWith(".js") ||
                    additionalFileUpload.FileName.ToLower().EndsWith(".vb") ||
                    additionalFileUpload.FileName.ToLower().EndsWith(".vbs"))
                {
                    errorMessageLabel.Text = "Enter a valid Additional File (non executable files only).";
                    errorMessageLabel.Visible = true;

                    return false;
                }

                if (additionalFileUpload.PostedFile.ContentLength > (3 * 1024 * 1024))
                {
                    errorMessageLabel.Text = "Enter a valid Additional File (Maximum size limit 3 MB).";
                    errorMessageLabel.Visible = true;

                    return false;
                }
            }

            return true;
        }

        public static void UploadFiles(string path, ref string lowResolutionFile, 
            ref string highResolutionFile, ref string additionalFile,
            int designId, FileUpload lowResolutionFileUpload,
            FileUpload highResolutionFileUpload, FileUpload additionalFileUpload,
            ref HiddenField RemoveAdditionalFileHiddenField)
        {
            try
            {
                if (lowResolutionFileUpload.HasFile)
                {
                    if (designId != 0)
                    {
                        if (File.Exists(path + "\\" + lowResolutionFile))
                        {
                            File.Delete(path + "\\" + lowResolutionFile);
                        }
                    }

                    lowResolutionFile = DateTime.Now.ToString("yyyyMMddHHmmssffff$1")
                        + "_" + lowResolutionFileUpload.FileName;

                    lowResolutionFileUpload.SaveAs(path + "\\" + lowResolutionFile);
                }

                if (highResolutionFileUpload.HasFile)
                {
                    if (designId != 0)
                    {
                        if (File.Exists(path + "\\" + highResolutionFile))
                        {
                            File.Delete(path + "\\" + highResolutionFile);
                        }
                    }

                    highResolutionFile = DateTime.Now.ToString("yyyyMMddHHmmssffff$2")
                        + "_" + highResolutionFileUpload.FileName;

                    highResolutionFileUpload.SaveAs(path + "\\" + highResolutionFile);
                }

                if (additionalFileUpload.HasFile)
                {
                    if (designId != 0 && additionalFile != "")
                    {
                        if (File.Exists(path + "\\" + additionalFile))
                        {
                            File.Delete(path + "\\" + additionalFile);
                        }
                    }

                    additionalFile = DateTime.Now.ToString("yyyyMMddHHmmssffff$3")
                        + "_" + additionalFileUpload.FileName;

                    additionalFileUpload.SaveAs(path + "\\" + additionalFile);
                }
                else
                {
                    if (designId != 0 && additionalFile != "" &&
                        RemoveAdditionalFileHiddenField.Value == "YES")
                    {
                        RemoveAdditionalFileHiddenField.Value = "NO";

                        if (File.Exists(path + "\\" + additionalFile))
                        {
                            File.Delete(path + "\\" + additionalFile);
                        }

                        additionalFile = string.Empty;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private static string BuildInformation(DesignService.DesignInfo design, 
            int userId, string url)
        {
            StringBuilder designInfo = new StringBuilder();
            string urlPrefix = url.Substring(0, url.IndexOf("Members")) +
                "Members/UserData/" + userId.ToString() + "/";

            designInfo.Append("Type: " + design.Type.Name + "<br />");
            designInfo.Append("Size: " + design.Size.Width.ToString() + " x " + design.Size.Height.ToString() + " inch." + "<br />");

            if (design.Category.Name == "PowerKard")
            {
                designInfo.Append("Gender: " + design.Gender + "<br />");
                designInfo.Append("Agent Name: " + design.OnDesignName + "<br />");
                designInfo.Append("Justification: " + design.Justification.ToString() + "<br />");
                if (design.Gutter != "")
                {
                    designInfo.Append("Gutter: " + design.Gutter + "<br />");
                }
                if (design.MessageRectangle.X > 0)
                {
                    designInfo.Append("Message Location: " + design.MessageRectangle.X.ToString() + " x " + design.MessageRectangle.Y.ToString() + " inch." + "<br />");
                }
                if (design.MessageRectangle.Width > 0)
                {
                    designInfo.Append("Message Size: " + design.MessageRectangle.Width.ToString() + " x " + design.MessageRectangle.Height.ToString() + " inch." + "<br />");
                }
            }

            designInfo.Append("Low-Resolution File: <a href=\"" + urlPrefix + design.LowResolutionFile + "\">" + design.LowResolutionFile.Substring(design.LowResolutionFile.IndexOf("_") + 1) + "</a><br />");
            designInfo.Append("High-Resolution File: <a href=\"" + urlPrefix + design.HighResolutionFile + "\">" + design.HighResolutionFile.Substring(design.HighResolutionFile.IndexOf("_") + 1) + "</a><br />");
            if (design.ExtraFile != "")
            {
                designInfo.Append("Additional File: <a href=\"" + urlPrefix + design.ExtraFile + "\">" + design.ExtraFile.Substring(design.ExtraFile.IndexOf("_") + 1) + "</a><br />");
            }

            designInfo.Append("Notes: " + (design.Comments == "" ? "---" : design.Comments));

            return designInfo.ToString();
        }

        public static bool SendEmailAsSubmitted(DesignService.DesignInfo design,
            string applicationPath, string url)
        {
            try
            {
                RegistrationService.RegistrationService registrationService =
                    serviceLoader.GetRegistration();
                RegistrationService.RegistrationInfo agent =
                    registrationService.GetDetails(design.UserId);

                // Send email to all the Printers.
                CommonService.CommonService commonService =
                    serviceLoader.GetCommon();
                IList<CommonService.RegistrationInfo> users =
                    commonService.GetUsersByRole(CommonService.UserRole.Printer.ToString());

                string templatePath = AppDomain.CurrentDomain.BaseDirectory +
                    "HTMLTemplate\\Email_DesignSubmitted.html";

                Hashtable variables = new Hashtable();
                variables.Add("ROLE", CommonService.UserRole.Printer.ToString());
                variables.Add("DESIGN_CATEGORY", design.Category.Name);
                variables.Add("FIRST_NAME", agent.FirstName);
                variables.Add("LAST_NAME", agent.LastName);
                variables.Add("DESIGN_INFO", BuildInformation(design, agent.UserId, url));

                MailAddressCollection mailAddresses = new MailAddressCollection();
                foreach (CommonService.RegistrationInfo user in users)
                {
                    mailAddresses.Add(user.Email);
                }

                Mail.Send(templatePath, variables, mailAddresses,
                    "MailingCycle Design Submitted for Approval", applicationPath);

                // Send email to all the Admins.
                users = commonService.GetUsersByRole(CommonService.UserRole.Admin.ToString());

                templatePath = AppDomain.CurrentDomain.BaseDirectory +
                    "HTMLTemplate\\Email_DesignSubmitted.html";

                variables = new Hashtable();
                variables.Add("ROLE", "Administrator");
                variables.Add("DESIGN_CATEGORY", design.Category.Name);
                variables.Add("FIRST_NAME", agent.FirstName);
                variables.Add("LAST_NAME", agent.LastName);
                variables.Add("DESIGN_INFO", BuildInformation(design, agent.UserId, url));

                mailAddresses = new MailAddressCollection();
                foreach (CommonService.RegistrationInfo user in users)
                {
                    mailAddresses.Add(user.Email);
                }

                Mail.Send(templatePath, variables, mailAddresses,
                    "MailingCycle Design Submitted for Approval", applicationPath);
            }
            catch (Exception ex)
            {
                log.Error("Unknown Error", ex);
                return false;
            }

            return true;
        }

        public static bool SendEmailAsApproved(DesignService.DesignInfo design,
            string applicationPath, string url)
        {
            try
            {
                // Send email to the Agent.
                RegistrationService.RegistrationService registrationService =
                    serviceLoader.GetRegistration();
                RegistrationService.RegistrationInfo agent =
                    registrationService.GetDetails(design.UserId);

                string templatePath = AppDomain.CurrentDomain.BaseDirectory +
                    "HTMLTemplate\\Email_DesignApproved_Agent.html";

                Hashtable variables = new Hashtable();
                variables.Add("FIRST_NAME", agent.FirstName);
                variables.Add("LAST_NAME", agent.LastName);
                variables.Add("DESIGN_CATEGORY", design.Category.Name);
                variables.Add("DESIGN_INFO", BuildInformation(design, agent.UserId, url));

                MailAddressCollection mailAddresses = new MailAddressCollection();
                mailAddresses.Add(agent.Email);

                Mail.Send(templatePath, variables, mailAddresses,
                    "MailingCycle Design Approved", applicationPath);

                // Send email to all the Admins.
                CommonService.CommonService commonService = serviceLoader.GetCommon();
                IList<CommonService.RegistrationInfo> users =
                    commonService.GetUsersByRole(CommonService.UserRole.Admin.ToString());

                templatePath = AppDomain.CurrentDomain.BaseDirectory +
                    "HTMLTemplate\\Email_DesignApproved_Admin.html";

                variables = new Hashtable();
                variables.Add("DESIGN_CATEGORY", design.Category.Name);
                variables.Add("FIRST_NAME", agent.FirstName);
                variables.Add("LAST_NAME", agent.LastName);
                variables.Add("DESIGN_INFO", BuildInformation(design, agent.UserId, url));

                mailAddresses = new MailAddressCollection();
                foreach (CommonService.RegistrationInfo user in users)
                {
                    mailAddresses.Add(user.Email);
                }

                Mail.Send(templatePath, variables, mailAddresses,
                    "MailingCycle Design Approved", applicationPath);
            }
            catch (Exception ex)
            {
                log.Error("Unknown Error", ex);
                return false;
            }

            return true;
        }

        public static bool SendEmailAsRejected(int agentId, string category,
            string notes, string applicationPath)
        {
            try
            {
                // Send email to the Agent.
                RegistrationService.RegistrationService registrationService =
                    serviceLoader.GetRegistration();
                RegistrationService.RegistrationInfo agent =
                    registrationService.GetDetails(agentId);

                string templatePath = AppDomain.CurrentDomain.BaseDirectory +
                    "HTMLTemplate\\Email_DesignRejected_Agent.html";

                Hashtable variables = new Hashtable();
                variables.Add("FIRST_NAME", agent.FirstName);
                variables.Add("LAST_NAME", agent.LastName);
                variables.Add("DESIGN_CATEGORY", category);
                variables.Add("DESIGN_NOTES", (notes == "" ? "---" : notes));

                MailAddressCollection mailAddresses = new MailAddressCollection();
                mailAddresses.Add(agent.Email);

                Mail.Send(templatePath, variables, mailAddresses,
                    "MailingCycle Design Rejected", applicationPath);

                // Send email to all the Admins.
                CommonService.CommonService commonService = serviceLoader.GetCommon();
                IList<CommonService.RegistrationInfo> users =
                    commonService.GetUsersByRole(CommonService.UserRole.Admin.ToString());

                templatePath = AppDomain.CurrentDomain.BaseDirectory +
                    "HTMLTemplate\\Email_DesignRejected_Admin.html";

                variables = new Hashtable();
                variables.Add("DESIGN_CATEGORY", category);
                variables.Add("FIRST_NAME", agent.FirstName);
                variables.Add("LAST_NAME", agent.LastName);
                variables.Add("DESIGN_NOTES", (notes == "" ? "---" : notes));

                mailAddresses = new MailAddressCollection();
                foreach (CommonService.RegistrationInfo user in users)
                {
                    mailAddresses.Add(user.Email);
                }

                Mail.Send(templatePath, variables, mailAddresses,
                    "MailingCycle Design Rejected", applicationPath);
            }
            catch (Exception ex)
            {
                log.Error("Unknown Error", ex);
                return false;
            }

            return true;
        }
    }

    public class Schedule
    {
        public Schedule()
        {
            //
        }

        public static bool SendEmailAsFirmedUp(string farmName, string planName,
            DateTime startDate, string firstName, string lastName, 
            string applicationPath)
        {
            try
            {
                // Send email to all the Printers.
                CommonService.CommonService commonService =
                    serviceLoader.GetCommon();
                IList<CommonService.RegistrationInfo> users =
                    commonService.GetUsersByRole(CommonService.UserRole.Printer.ToString());

                string templatePath = AppDomain.CurrentDomain.BaseDirectory +
                    "HTMLTemplate\\Email_PlanFirmedUp.html";

                Hashtable variables = new Hashtable();
                variables.Add("ROLE", CommonService.UserRole.Printer.ToString());
                variables.Add("PLAN_NAME", planName);
                variables.Add("FARM_NAME", farmName);
                variables.Add("START_DATE", startDate.ToString("MM/dd/yyyy"));
                variables.Add("FIRST_NAME", firstName);
                variables.Add("LAST_NAME", lastName);

                MailAddressCollection mailAddresses = new MailAddressCollection();
                foreach (CommonService.RegistrationInfo user in users)
                {
                    mailAddresses.Add(user.Email);
                }

                Mail.Send(templatePath, variables, mailAddresses,
                    "MailingCycle Plan Firmed Up", applicationPath);

                // Send email to all the Admins.
                commonService = serviceLoader.GetCommon();
                users = commonService.GetUsersByRole(CommonService.UserRole.Admin.ToString());

                templatePath = AppDomain.CurrentDomain.BaseDirectory +
                    "HTMLTemplate\\Email_PlanFirmedUp.html";

                variables = new Hashtable();
                variables.Add("ROLE", "Administrator");
                variables.Add("PLAN_NAME", planName);
                variables.Add("FARM_NAME", farmName);
                variables.Add("START_DATE", startDate.ToString("MM/dd/yyyy"));
                variables.Add("FIRST_NAME", firstName);
                variables.Add("LAST_NAME", lastName);

                mailAddresses = new MailAddressCollection();
                foreach (CommonService.RegistrationInfo user in users)
                {
                    mailAddresses.Add(user.Email);
                }

                Mail.Send(templatePath, variables, mailAddresses,
                    "MailingCycle Plan Firmed Up", applicationPath);
            }
            catch (Exception ex)
            {
                log.Error("Unknown Error", ex);
                return false;
            }

            return true;
        }
    }

    public class Validations
    {
        public Validations()
        {
            //
        }

        public static void RegisterZipScriptBlock(ClientScriptManager csManager, 
            Type type, string countryID)
        {
            string newLine = Environment.NewLine;

            if (!csManager.IsClientScriptBlockRegistered(type, "MCU_ValidateZip"))
            {
                StringBuilder csText = new StringBuilder();

                csText.Append("<script language=\"javascript\">" + newLine);
                csText.Append("<!--" + newLine);
                csText.Append("function MCU_ValidateZip(source, arguments) {" + newLine);
                csText.Append("var oCountry = document.getElementById(\"" + countryID + "\");" + newLine);
                csText.Append("var vCountry = oCountry.options[oCountry.selectedIndex].value;" + newLine);
                csText.Append("var re;" + newLine);
                csText.Append("if (vCountry == 1)" + newLine);
                csText.Append("re = new RegExp(/(^\\d{5}$)|(^\\d{5}-\\d{4}$)/); // United States." + newLine);
                csText.Append("else" + newLine);
                csText.Append("re = new RegExp(/^[A-Z]{1}\\d{1}[A-Z]{1} \\d{1}[A-Z]{1}\\d{1}$/); // Canada." + newLine);
                csText.Append("if (arguments.Value.match(re)) arguments.IsValid = true; else arguments.IsValid = false;" + newLine);
                csText.Append("}" + newLine);
                csText.Append("// -->" + newLine);
                csText.Append("</script>" + newLine);

                csManager.RegisterClientScriptBlock(type, "MCU_ValidateZip", csText.ToString(), false);
            }
        }
    }
}

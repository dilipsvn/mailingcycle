using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using Acrobat;

namespace DesignService
{
    public partial class MainForm : Form
    {
        ContextMenu contextMenu1 = new ContextMenu();
        MenuItem menuItem1 = new MenuItem();
        FileSystemWatcher watcher = new FileSystemWatcher();
        ArrayList pdfFiles = new ArrayList();
        string rootPath = ConfigurationManager.AppSettings["DesignRoot"];

        private void LogEvent(string message)
        {
            LogEvent(message, EventLogEntryType.Information);
        }

        private void LogEvent(Exception ex)
        {
            LogEvent(ex.Source + " : " + ex.Message + " >> " + ex.StackTrace, 
                EventLogEntryType.Error);
        }

        private void LogEvent(string message, EventLogEntryType entryType)
        {
            eventLog1.WriteEntry(message, entryType);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Set the notification area icon.
                contextMenu1.MenuItems.AddRange(new MenuItem[] { menuItem1 });

                menuItem1.Index = 0;
                menuItem1.Text = "E&xit";
                menuItem1.Click += new EventHandler(menuItem_Click);

                notifyIcon1.ContextMenu = contextMenu1;

                notifyIcon1.Text = "Mailing Cycle Design Service program";
                notifyIcon1.Visible = true;

                // Set the event log.
                string logSource = "MailingCycleSource";
                string logName = "MailingCycleLog";

                if (!EventLog.SourceExists(logSource))
                {
                    EventLog.CreateEventSource(logSource, logName);
                }

                eventLog1.Source = logSource;
                eventLog1.Log = logName;

                // Set the directory to watch.
                watcher.Path = rootPath;
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Filter = "*.pdf";
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.EnableRaisingEvents = true;

                // Set the timer.
                int interval = Convert.ToInt32(ConfigurationManager.AppSettings["DesignInterval"]);

                timer1.Interval = interval * 1000;
                timer1.Enabled = true;

                LogEvent("The Mailing Cycle Design Service entered the running state" +
                    " and watching \"" + rootPath + "\".", 
                    EventLogEntryType.SuccessAudit);
            }
            catch (Exception ex)
            {
                LogEvent(ex);
            }
        }

        private void menuItem_Click(object Sender, EventArgs e)
        {
            Close();
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            try
            {
                ArrayList file = new ArrayList();

                file.Add(e.Name);
                file.Add(e.FullPath);

                pdfFiles.Add(file);

                LogEvent("The file \"" + e.Name + "\" is created.");
            }
            catch (Exception ex)
            {
                LogEvent(ex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pdfFiles.Count > 0)
                {
                    ArrayList file = (ArrayList)pdfFiles[0];

                    string fileName = file[0].ToString();
                    string filePath = file[1].ToString();

                    ExportAsImages(fileName, filePath);

                    pdfFiles.RemoveAt(0);

                    LogEvent("Extracted image from the file \"" + fileName + "\".");
                }
            }
            catch (Exception ex)
            {
                LogEvent(ex);
            }
        }

        private void ExportAsImages(string fileName, string filePath)
        {
            try
            {
                CAcroPDDoc acroPDDoc = new AcroPDDocClass();

                if (!acroPDDoc.Open(filePath))
                {
                    Marshal.ReleaseComObject(acroPDDoc);
                    acroPDDoc = null;

                    throw new ApplicationException("Can't open file \"" + 
                        fileName + "\"");
                }

                int pageCount = acroPDDoc.GetNumPages();

                if (pageCount == 2)
                {
                    CAcroPDPage acroPDPage = (CAcroPDPage)acroPDDoc.AcquirePage(1);

                    CAcroPoint acroPoint = (CAcroPoint)acroPDPage.GetSize();
                    CAcroRect acroRect = new AcroRectClass();
                    acroRect.Top = 0;
                    acroRect.bottom = acroPoint.y;
                    acroRect.Left = 0;
                    acroRect.right = acroPoint.x;

                    if (!acroPDPage.CopyToClipboard(acroRect, 0, 0, 100))
                    {
                        Marshal.ReleaseComObject(acroPDPage);
                        acroPDPage = null;
                        Marshal.ReleaseComObject(acroPDDoc);
                        acroPDDoc = null;

                        throw new ApplicationException("Unknown error while extracting pages of " + filePath);
                    }

                    acroRect = null;
                    acroPoint = null;
                    Marshal.ReleaseComObject(acroPDPage);
                    acroPDPage = null;

                    IDataObject dataObject = Clipboard.GetDataObject();
                    Bitmap bitmap = (Bitmap)dataObject.GetData(DataFormats.Bitmap);

                    string newFileName = 
                        fileName.Substring(0, fileName.LastIndexOf(".")) + "_Page2.jpg";
                    string targetPath = rootPath + "\\" + newFileName;

                    if (File.Exists(targetPath))
                    {
                        File.Delete(targetPath);
                    }

                    bitmap.Save(targetPath, ImageFormat.Jpeg);

                    bitmap.Dispose();
                }

                Marshal.ReleaseComObject(acroPDDoc);
                acroPDDoc = null;
            }
            catch
            {
                throw;
            }
        }
    }
}
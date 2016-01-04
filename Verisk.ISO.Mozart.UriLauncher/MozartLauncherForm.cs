using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Mime;
using System.IO;

namespace Verisk.ISO.Mozart.UriLauncher
{
    public partial class MozartLauncherForm : Form
    {
        private string[] arguments;

        private const string downloadUrl = "http://localhost:5734/Home/GetFileDownloadObjectId?objectIdValue={0}";

        private string tempFileName = string.Empty;

        public MozartLauncherForm(string[] args)
        {
            InitializeComponent();

            arguments = args;

            // The URL handler for this app

            string prefix = "iso-mozart://";

            // The name of this app for user messages
            string title = "Verisk Mozart URL Protocol Handler";

            // Verify the command line arguments
            if (args.Length == 0 || !args[0].StartsWith(prefix))
            {
                MessageBox.Show("Syntax:\niso-mozart://<key>", title);
                return;
            }
            else
            {
                arguments = args;
            }
        }

        private void MozartLauncherForm_Load(object sender, EventArgs e)
        {
            // Obtain the part of the protocol we're interested in
            string key = Regex.Match(arguments[0], @"(?<=://).+?(?=:|/|\Z)").Value;
            if (key.Contains("open;"))
            {
                var fileId = key.Replace("open;id=", string.Empty);

                var client = new WebClient();

                var tempPath = System.IO.Path.GetTempPath();
                tempFileName = string.Format("{0}\\~temp-{1}.docx", tempPath, Guid.NewGuid().ToString());

                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                client.DownloadProgressChanged += Client_DownloadProgressChanged;

                client.DownloadFileAsync(new Uri(string.Format(downloadUrl, fileId)), tempFileName);
            }

        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage == 100)
                progressBar1.Enabled = false;
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                var contentDispositionString = ((System.Net.WebClient)sender).ResponseHeaders["Content-Disposition"];

                ContentDisposition contentDisposition = new ContentDisposition(contentDispositionString);

                var tempPath = System.IO.Path.GetTempPath();

                var actualFile = string.Format("{0}\\{1}", tempPath, contentDisposition.FileName);

                File.Copy(tempFileName, actualFile, true);

                Microsoft.Office.Interop.Word._Application oWord;
                Microsoft.Office.Interop.Word._Document oDoc;
                oWord = new Microsoft.Office.Interop.Word.Application();
                var fileNameObject = actualFile as object;
                oWord.Documents.Open(ref fileNameObject);
                oWord.Visible = true;
                oWord.Activate();
            }
           

            this.Close();
            Application.Exit();
        }
    }
}

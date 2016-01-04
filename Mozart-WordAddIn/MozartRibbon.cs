using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Net.Http;
using System.IO;
using System.Windows.Forms;
using OfficeWord = Microsoft.Office.Interop.Word;

namespace Mozart_WordAddIn
{
    public partial class MozartRibbon
    {
        private const string UploadUrl = "http://localhost:5734/api/Upload/";
        private const string MozartUrl = "https://mozart.iso.com";

        public Microsoft.Office.Interop.Word.Document ActiveDocument
        {
            get { return Globals.ThisAddIn.Application.ActiveDocument; }
        }

        private void MozartRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, RibbonControlEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();          
        }

        private void buttonUpload_Click(object sender, RibbonControlEventArgs e)
        {

            if(this.ActiveDocument.Saved)
            {

                var message = new HttpRequestMessage();
                var content = new MultipartFormDataContent();

                var tempPath = System.IO.Path.GetTempPath();

                var tempFileName = string.Format("{0}\\~temp-{1}.docx", tempPath, Guid.NewGuid().ToString());
                File.Copy(this.ActiveDocument.FullName, tempFileName);

                var fileStream = new FileStream(tempFileName, FileMode.Open);
                var fileName = System.IO.Path.GetFileName(this.ActiveDocument.FullName);
                content.Add(new StreamContent(fileStream), "file", fileName);

                message.Method = HttpMethod.Post;
                message.Content = content;
                message.RequestUri = new Uri(UploadUrl);

                var client = new HttpClient();
                client.SendAsync(message).ContinueWith(task =>
                {
                    if (task.Result.IsSuccessStatusCode)
                    {
                        //do something with response
                        System.Windows.Forms.MessageBox.Show("File uploaded successfully!");
                        File.Delete(tempFileName);
                    }
                });
            }
        }

        private void buttonMozartWeb_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start(MozartUrl);
        }

        private void toggleButtonSearch_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.SearchTaskPane.Visible = (sender as Microsoft.Office.Tools.Ribbon.RibbonToggleButton).Checked;
        }

        private void buttonFleschReading_Click(object sender, RibbonControlEventArgs e)
        {
            var content = this.ActiveDocument.Content.Text;
            var result = TextStatistics.Parse(content);

            var message = "Flesch Grade Level : " + result.FleschKincaidGradeLevel();

            message += "\r\nFlesch Reading Ease : " + result.FleschKincaidReadingEase();

            message += "\r\nAutomated readibility index : " + result.AutomatedReadabilityIndex();

            MessageBox.Show(message);
        }

		private void button1_Click(object sender, RibbonControlEventArgs e)
		{

		}

		private void btnCompare_Click(object sender, RibbonControlEventArgs e)
		{		
			//TODO: Need to find out how are we selecting a target document	?
			string fileToCompare = @"D:\Wish.docx";			

			object readOnly = false;
			object AddToRecent = false;
			object Visible = false;
			object missing = System.Reflection.Missing.Value;

			//OfficeWord.Document docZero = app.Documents.Open(fileToOpen, ref missing, ref readOnly, ref AddToRecent, Visible: ref Visible);

			this.ActiveDocument.Final = false;
			this.ActiveDocument.TrackRevisions = false;
			this.ActiveDocument.ShowRevisions = false;
			this.ActiveDocument.PrintRevisions = false;

			//The OfficeWord.WdCompareTargetNew defines a new file, you can change this valid value to change how word will open the document
			this.ActiveDocument.Compare(fileToCompare, missing, OfficeWord.WdCompareTarget.wdCompareTargetCurrent, true, false, false, false, false);

		}
	}
}

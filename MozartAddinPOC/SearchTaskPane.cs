using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace MozartAddinPOC
{
	public partial class SearchTaskPane : UserControl
	{
		private const string DownloadUrl = "http://localhost:5734/api/Upload/GetFileByObjectId";
		private const string SearchResultsUrl = "http://localhost:5734/api/Upload/GetFilesBySearchText";

		public SearchTaskPane()
		{
			InitializeComponent();
			listBoxSearchResults.DrawMode = DrawMode.OwnerDrawVariable;
		}


		private void btnSearch_Click(object sender, EventArgs e)
		{
			listBoxSearchResults.Items.Clear();
			string url = string.Format("{0}?searchText={1}", SearchResultsUrl, txtSearchWord.Text);
			HttpContent httpcontent = HttpClientGetAsync(url).Result;
			List<MozartForm> docs = JsonConvert.DeserializeObject<List<MozartForm>>(httpcontent.ReadAsStringAsync().Result);
			List<ListBoxItem> listItems = new List<ListBoxItem>();
			foreach(MozartForm mform in docs)
			{
				string title = mform.FormTitle;
				if(string.IsNullOrEmpty(title))
				{
					title = mform.FileName;
				}

				//listBoxSearchResults.Items.Add(string.Format("{0} - {1}", title, mform.FileId));

				listItems.Add(new ListBoxItem { Title = title, Key = mform.FileId, SubTitle = mform.FileName });
			}

			listBoxSearchResults.Items.AddRange(listItems.ToArray());
		}

		public async Task<HttpContent> HttpClientGetAsync(string uri)
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(uri);
			response.EnsureSuccessStatusCode();
			return response.Content;
		}

		private void listBoxSearchResults_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string curItem = ((ListBoxItem)listBoxSearchResults.SelectedItem).Key;
			string url = string.Format("{0}?objectId={1}", DownloadUrl, curItem);
			HttpContent httpcontent = HttpClientGetAsync(url).Result;
			byte[] result = httpcontent.ReadAsByteArrayAsync().Result;

			var tempFileName = string.Format("{0}\\{1}.docx", Path.GetTempPath(), curItem);
			File.WriteAllBytes(tempFileName, result);

			StringBuilder content = new StringBuilder();
			Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

			object miss = System.Reflection.Missing.Value;
			object path = tempFileName;
			object readOnly = true;
			Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss,
												   ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
			Microsoft.Office.Interop.Word.Document currentDocument = AddinModule.CurrentInstance.WordApp.ActiveDocument;
			Microsoft.Office.Interop.Word.Selection currentPos = AddinModule.CurrentInstance.WordApp.Application.Selection;

			currentDocument.Range(currentPos.Range.Start, currentPos.Range.End).InsertAfter(docs.Content.Text);
			docs.Close();

		}

		private void listBoxSearchResults_DrawItem_1(object sender, DrawItemEventArgs e)
		{
			// Draw the background of the ListBox control for each item.
			e.DrawBackground();
			// Define the default color of the brush as black.
			Brush myBrush = Brushes.Black;

			// Determine the color of the brush to draw each item based 
			// on the index of the item to draw.

			switch((e.Index % 2) > 0)
			{
			case true:
				myBrush = Brushes.Navy;
				break;
			case false:
				myBrush = Brushes.Green;
				break;
			}

			// Draw the current item text based on the current Font 
			// and the custom brush settings.

			//e.Graphics.DrawString(((ListBoxItem)listBoxSearchResults.Items[e.Index]).Title,
			// e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

			// Create font and brush.
			Font drawFont = new Font("Arial", 16);
			SolidBrush drawBrush = new SolidBrush(Color.Black);

			// Create rectangle for drawing.
			float x = e.Bounds.X;
			float y = e.Bounds.Y;
			float width = e.Bounds.Width;
			float height = e.Bounds.Height * 2;

			RectangleF drawRect = new RectangleF(x, y, width, height);

			// Draw rectangle to screen.
			Pen blackPen = new Pen(Color.Black);

			e.Graphics.DrawRectangle(blackPen, x, y, width, height);

			e.Graphics.DrawString(((ListBoxItem)listBoxSearchResults.Items[e.Index]).Title,
				new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Bold),
				myBrush, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 5),
				StringFormat.GenericDefault);

			// If the ListBox has focus, draw a focus rectangle around the selected item.
			e.DrawFocusRectangle();
		}
	}
}

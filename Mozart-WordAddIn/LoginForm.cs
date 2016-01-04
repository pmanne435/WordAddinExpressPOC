using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Mozart_WordAddIn
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{			
			this.Close();
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			//this.DialogResult = DialogResult.OK;

			bool isUserValid = ValidateUser().Result;
			if(isUserValid)
			{
				EnableRibbonButtons();
            }
			else
			{
				MessageBox.Show("Please enter valid credentials.");
			}			
			this.Close();
		}

		public async Task<bool> ValidateUser()
		{
			User user = new User()
			{
				UserName = txtUserId.Text,
				Password = txtPassword.Text
			};

			var userSerialized = JsonConvert.SerializeObject(user);

			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5734/api/Login");
			webRequest.Method = "POST";
			webRequest.ContentType = "application/json";

			using(StreamWriter sw = new StreamWriter(webRequest.GetRequestStream()))
			{
				sw.Write(userSerialized);
			}

			HttpWebResponse httpWebResponse = webRequest.GetResponse() as HttpWebResponse;
			using(StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
			{
				if(httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					return false;
				}
				bool ff = Convert.ToBoolean(sr.ReadToEnd());
				return ff;
			}

			//var message = new HttpRequestMessage();
			//message.Method = HttpMethod.Post;
			//message.Content = content;
			//message.RequestUri = new Uri("http://localhost:5734/api/Login");

			//var client = new HttpClient();
			//client.SendAsync(message).ContinueWith(task =>
			//{
			//	//Need check response data to verufy user authentication.
			//	if(task.Result.IsSuccessStatusCode)
			//	{

			//	}
			//});

			//HttpResponseMessage response = await client.SendAsync(message);
			//var responseString = await response.Content.ReadAsStringAsync();



			//using(var client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri("http://localhost:5734/");
			//	client.DefaultRequestHeaders.Accept.Clear();
			//	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//	var values = new Dictionary<string, string>()
			//	{
			//		{"UserName", txtUserId.Text},
			//		{"Password", txtPassword.Text}
			//	};
			//	var content = new FormUrlEncodedContent(values);

			//	HttpResponseMessage response = await client.PostAsync("api/Login", content);

			//	if(response.IsSuccessStatusCode)
			//	{
			//		return true;
			//	}
			//	return false;
			//}

		}

		private void EnableRibbonButtons()
		{
			Globals.Ribbons.MozartRibbon.buttonMozartWeb.Enabled = true;
			Globals.Ribbons.MozartRibbon.buttonUpload.Enabled = true;
			Globals.Ribbons.MozartRibbon.toggleButtonSearch.Enabled = true;
			Globals.Ribbons.MozartRibbon.btnAddHeader.Enabled = true;
			Globals.Ribbons.MozartRibbon.btnAddFooter.Enabled = true;
			Globals.Ribbons.MozartRibbon.buttonInsertClause.Enabled = true;
			Globals.Ribbons.MozartRibbon.btnRules.Enabled = true;
			Globals.Ribbons.MozartRibbon.btnExclusions.Enabled = true;
			Globals.Ribbons.MozartRibbon.buttonFleschReading.Enabled = true;
		}
	}
}

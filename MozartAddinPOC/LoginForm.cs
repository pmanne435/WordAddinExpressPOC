using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MozartAddinPOC
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			//this.DialogResult = DialogResult.OK;

			bool isUserValid = ValidateUser().Result;
			if(isUserValid)
			{
				MessageBox.Show("Success");
				//EnableRibbonButtons();
				AddinModule module = AddinModule.CurrentInstance;
				module.EnableRibbonButtons(true);				
				this.Close();
			}
			else
			{
				MessageBox.Show("Please enter valid credentials.");
			}
			
		}

		public async Task<bool> ValidateUser()
		{
			User user = new User()
			{
				UserName = txtUserName.Text,
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

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

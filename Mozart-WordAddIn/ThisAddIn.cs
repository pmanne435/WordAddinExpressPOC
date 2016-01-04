using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.AspNet.SignalR.Client;
using Mozart_WordAddIn.Properties;

namespace Mozart_WordAddIn
{
	public partial class ThisAddIn
	{
		private SearchTaskPane searchUserControl;
		private Microsoft.Office.Tools.CustomTaskPane searchTaskPane;
		public Word.Document ActiveDocument
		{ get; private set; }

		//using Word = Microsoft.Office.Interop.Word;
		//using Office = Microsoft.Office.Core;

		private readonly Dictionary<string, Office.CommandBarButton> contextButtons = new Dictionary<string, Office.CommandBarButton>();

		Word.Application application;

		private void ThisAddIn_Startup(object sender, System.EventArgs e)
		{
			application = this.Application;
			application.WindowBeforeRightClick +=
				new Word.ApplicationEvents4_WindowBeforeRightClickEventHandler(Application_WindowBeforeRightClick);

			//application.CustomizationContext = application.ActiveDocument;

			//AddContextMenu("Find Matches", "find-matches");
			//AddContextMenu("My Custom Button", "my-custom-button");

			searchUserControl = new SearchTaskPane();
			searchTaskPane = this.CustomTaskPanes.Add(searchUserControl, Resources.SEARCH_TASK_PANE);
			searchTaskPane.VisibleChanged += SearchTaskPane_VisibleChanged;
			searchTaskPane.Width = 300;
			//searchTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionLeft;
			//searchTaskPane.Visible = true;
			//InitializeSignalR();
			DisableRibbonButtons();
		}

		private void DisableRibbonButtons()
		{
			Globals.Ribbons.MozartRibbon.buttonMozartWeb.Enabled = false;
			Globals.Ribbons.MozartRibbon.buttonUpload.Enabled = false;
			Globals.Ribbons.MozartRibbon.toggleButtonSearch.Enabled = false;
			Globals.Ribbons.MozartRibbon.btnAddHeader.Enabled = false;
			Globals.Ribbons.MozartRibbon.btnAddFooter.Enabled = false;
			Globals.Ribbons.MozartRibbon.buttonInsertClause.Enabled = false;
			Globals.Ribbons.MozartRibbon.btnRules.Enabled = false;
			Globals.Ribbons.MozartRibbon.btnExclusions.Enabled = false;
			Globals.Ribbons.MozartRibbon.buttonFleschReading.Enabled = false;
		}

		private void SearchTaskPane_VisibleChanged(object sender, EventArgs e)
		{
			Globals.Ribbons.MozartRibbon.toggleButtonSearch.Checked = searchTaskPane.Visible;
		}

		private object AddContextMenu(string caption, string tag)
		{
			//application.CustomizationContext = application.ActiveDocument;

			Office.CommandBar commandBar = application.CommandBars["Text"];

			// Remove if there is a duplicate already.
			Office.CommandBarButton control =
				(Office.CommandBarButton)commandBar.FindControl
				(Office.MsoControlType.msoControlButton, missing,
				tag, true, true);

			if((control != null))
			{
				contextButtons.Remove(tag);
				control.Delete(true);
			}

			//Create the new menu buttion and add it.
			Office.CommandBarButton button = (Office.CommandBarButton)commandBar.Controls.Add(
				Office.MsoControlType.msoControlButton);
			button.accName = caption;
			button.Caption = caption;
			button.Tag = tag;
			button.Click += ConextMenu_Click;
			contextButtons.Add(tag, button);

			return button;
		}

		private void ConextMenu_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			if(Ctrl.Tag == "find-matches")
			{
				System.Windows.Forms.MessageBox.Show("Clicked find matches");
			}
		}

		private void InitializeSignalR()
		{
			IHubProxy _hub;
			string url = @"http://localhost:5734/";
			var connection = new HubConnection(url);
			_hub = connection.CreateHubProxy("NotificationHub");
			connection.Received += NotificationReceived;
			connection.Start().Wait();
		}

		private void NotificationReceived(string obj)
		{
			System.Windows.Forms.MessageBox.Show("Notification :: " + obj);
		}

		private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
		{
			//GC.Collect();
		}

		public void Application_WindowBeforeRightClick(Word.Selection selection, ref bool Cancel)
		{
			//if (selection != null && !String.IsNullOrEmpty(selection.Text))
			//{
			//    //string selectionText = selection.Text;
			//    SetCommandVisibility("Find Matches", true);
			//    //if (!string.IsNullOrEmpty(selectionText))
			//    //    SetCommandVisibility("Find Matches", true);
			//    //else
			//    //    SetCommandVisibility("Find Matches", false);
			//}else
			//{
			//    SetCommandVisibility("Find Matches", false);
			//}
		}

		private void SetCommandVisibility(string name, bool visible)
		{
			if(application.ActiveDocument != null)
			{
				application.CustomizationContext = application.ActiveDocument;
				Office.CommandBar commandBar = application.CommandBars["Text"];
				commandBar.Controls[name].Visible = visible;
			}
		}

		protected override object RequestService(Guid serviceGuid)
		{
			return base.RequestService(serviceGuid);
		}

		public Microsoft.Office.Tools.CustomTaskPane SearchTaskPane
		{
			get
			{
				return searchTaskPane;
			}
		}

		#region VSTO generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(ThisAddIn_Startup);
			this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
		}

		#endregion
	}
}

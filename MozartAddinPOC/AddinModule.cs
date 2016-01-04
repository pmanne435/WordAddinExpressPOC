using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using AddinExpress.MSO;
using Word = Microsoft.Office.Interop.Word;

namespace MozartAddinPOC
{
	/// <summary>
	///   Add-in Express Add-in Module
	/// </summary>
	[GuidAttribute("93022FA2-221A-4D0F-8859-D26D6BFD5591"), ProgId("MozartAddinPOC.AddinModule")]
	public partial class AddinModule : AddinExpress.MSO.ADXAddinModule
	{

		private const string UploadUrl = "http://localhost:5734/api/Upload/";
		private const string MozartUrl = "https://mozart.iso.com";

		public AddinModule()
		{
			Application.EnableVisualStyles();
			InitializeComponent();
			// Please add any initialization code to the AddinInitialize event handler

			adxRibbonButton1.OnClick += new ADXRibbonOnAction_EventHandler(adxRibbonButton1_OnClick);
			adxRibbonButton2.OnClick += new ADXRibbonOnAction_EventHandler(adxRibbonButton2_OnClick);
			adxRibbonButton3.OnClick += new ADXRibbonOnAction_EventHandler(adxRibbonButton3_OnClick);

			EnableRibbonButtons(false);
		}

		public void EnableRibbonButtons(bool isEnable)
		{
			adxRibbonButton2.Enabled = isEnable;
			adxRibbonButton3.Enabled = isEnable;
		}

		#region Add-in Express automatic code

		// Required by Add-in Express - do not modify
		// the methods within this region

		public override System.ComponentModel.IContainer GetContainer()
		{
			if(components == null)
				components = new System.ComponentModel.Container();
			return components;
		}

		[ComRegisterFunctionAttribute]
		public static void AddinRegister(Type t)
		{
			AddinExpress.MSO.ADXAddinModule.ADXRegister(t);
		}

		[ComUnregisterFunctionAttribute]
		public static void AddinUnregister(Type t)
		{
			AddinExpress.MSO.ADXAddinModule.ADXUnregister(t);
		}

		public override void UninstallControls()
		{
			base.UninstallControls();
		}

		#endregion

		public static new AddinModule CurrentInstance
		{
			get
			{
				return AddinExpress.MSO.ADXAddinModule.CurrentInstance as AddinModule;
			}
		}

		public Word._Application WordApp
		{
			get
			{
				return (HostApplication as Word._Application);
			}
		}

		private void adxRibbonButton1_OnClick(object sender, AddinExpress.MSO.IRibbonControl control, bool pressed)
		{
			LoginForm loginForm = new LoginForm();
			loginForm.ShowDialog();
		}

		private void adxRibbonButton2_OnClick(object sender, AddinExpress.MSO.IRibbonControl control, bool pressed)
		{
			System.Diagnostics.Process.Start(MozartUrl);
		}

		private void adxRibbonButton3_OnClick(object sender, AddinExpress.MSO.IRibbonControl control, bool pressed)
		{
			//TODO: Need to find out how are we selecting a target document	?
			string fileToCompare = @"D:\Wish.docx";

			object readOnly = false;
			object AddToRecent = false;
			object Visible = false;
			object missing = System.Reflection.Missing.Value;

			//OfficeWord.Document docZero = app.Documents.Open(fileToOpen, ref missing, ref readOnly, ref AddToRecent, Visible: ref Visible);
			this.WordApp.ActiveDocument.Final = false;
			this.WordApp.ActiveDocument.TrackRevisions = false;
			this.WordApp.ActiveDocument.ShowRevisions = false;
			this.WordApp.ActiveDocument.PrintRevisions = false;

			//The OfficeWord.WdCompareTargetNew defines a new file, you can change this valid value to change how word will open the document
			this.WordApp.ActiveDocument.Compare(fileToCompare, missing, Word.WdCompareTarget.wdCompareTargetCurrent, true, false, false, false, false);
		}

	}
}


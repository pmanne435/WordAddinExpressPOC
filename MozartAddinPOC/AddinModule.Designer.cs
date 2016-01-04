namespace MozartAddinPOC
{
    partial class AddinModule
    {
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;
 
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.tabMozartAddinExpress = new AddinExpress.MSO.ADXRibbonTab(this.components);
			this.adxRibbonGroup1 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
			this.adxRibbonButton1 = new AddinExpress.MSO.ADXRibbonButton(this.components);
			this.adxRibbonSeparator1 = new AddinExpress.MSO.ADXRibbonSeparator(this.components);
			this.adxRibbonButton2 = new AddinExpress.MSO.ADXRibbonButton(this.components);
			this.adxRibbonGroup2 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
			this.adxRibbonButton3 = new AddinExpress.MSO.ADXRibbonButton(this.components);
			this.adxTaskPane2 = new AddinExpress.MSO.ADXTaskPane(this.components);
			// 
			// tabMozartAddinExpress
			// 
			this.tabMozartAddinExpress.Caption = "MozartAddinExpress";
			this.tabMozartAddinExpress.Controls.Add(this.adxRibbonGroup1);
			this.tabMozartAddinExpress.Controls.Add(this.adxRibbonGroup2);
			this.tabMozartAddinExpress.Id = "adxRibbonTab_3f854ba9522a4f8484983f15e023124a";
			this.tabMozartAddinExpress.Ribbons = AddinExpress.MSO.ADXRibbons.msrWordDocument;
			this.tabMozartAddinExpress.Shared = true;
			// 
			// adxRibbonGroup1
			// 
			this.adxRibbonGroup1.Caption = "Mozart Access";
			this.adxRibbonGroup1.Controls.Add(this.adxRibbonButton1);
			this.adxRibbonGroup1.Controls.Add(this.adxRibbonSeparator1);
			this.adxRibbonGroup1.Controls.Add(this.adxRibbonButton2);
			this.adxRibbonGroup1.Id = "adxRibbonGroup_1d0adf03f4d84a7997a404110808fe6b";
			this.adxRibbonGroup1.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.adxRibbonGroup1.Ribbons = AddinExpress.MSO.ADXRibbons.msrWordDocument;
			// 
			// adxRibbonButton1
			// 
			this.adxRibbonButton1.Caption = "Login";
			this.adxRibbonButton1.Id = "adxRibbonButton_4d49d7a5d6c14c83b6aa3d4070ff0b10";
			this.adxRibbonButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.adxRibbonButton1.Ribbons = AddinExpress.MSO.ADXRibbons.msrWordDocument;
			// 
			// adxRibbonSeparator1
			// 
			this.adxRibbonSeparator1.Id = "adxRibbonSeparator_283ed371bb4a45ff859cfe50dd84ce92";
			this.adxRibbonSeparator1.Ribbons = AddinExpress.MSO.ADXRibbons.msrWordDocument;
			// 
			// adxRibbonButton2
			// 
			this.adxRibbonButton2.Caption = "Mozart Web";
			this.adxRibbonButton2.Id = "adxRibbonButton_a870eca63ae948268e3a307e26f3b2d9";
			this.adxRibbonButton2.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.adxRibbonButton2.Ribbons = AddinExpress.MSO.ADXRibbons.msrWordDocument;
			// 
			// adxRibbonGroup2
			// 
			this.adxRibbonGroup2.Caption = "Compare";
			this.adxRibbonGroup2.Controls.Add(this.adxRibbonButton3);
			this.adxRibbonGroup2.Id = "adxRibbonGroup_65cefa8cccf843ee97c8d6627998a49a";
			this.adxRibbonGroup2.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.adxRibbonGroup2.Ribbons = AddinExpress.MSO.ADXRibbons.msrWordDocument;
			// 
			// adxRibbonButton3
			// 
			this.adxRibbonButton3.Caption = "Compare";
			this.adxRibbonButton3.Id = "adxRibbonButton_24ccff977a49418eb7cb5a663d561479";
			this.adxRibbonButton3.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.adxRibbonButton3.Ribbons = AddinExpress.MSO.ADXRibbons.msrWordDocument;
			// 
			// adxTaskPane2
			// 
			this.adxTaskPane2.ControlProgID = "MozartAddinPOC.SearchTaskPane";
			this.adxTaskPane2.DockPosition = AddinExpress.MSO.ADXCTPDockPosition.ctpDockPositionLeft;
			// 
			// AddinModule
			// 
			this.AddinName = "MozartAddinPOC";
			this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaWord;
			this.TaskPanes.Add(this.adxTaskPane2);

        }
		#endregion
		private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup1;
		private AddinExpress.MSO.ADXRibbonButton adxRibbonButton1;
		private AddinExpress.MSO.ADXRibbonSeparator adxRibbonSeparator1;
		private AddinExpress.MSO.ADXRibbonButton adxRibbonButton2;
		private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup2;
		private AddinExpress.MSO.ADXRibbonButton adxRibbonButton3;
		public AddinExpress.MSO.ADXRibbonTab tabMozartAddinExpress;
		private AddinExpress.MSO.ADXTaskPane adxTaskPane2;
	}
}


namespace Mozart_WordAddIn
{
    partial class MozartRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MozartRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tabMozart = this.Factory.CreateRibbonTab();
			this.groupLogin = this.Factory.CreateRibbonGroup();
			this.buttonLogin = this.Factory.CreateRibbonButton();
			this.buttonMozartWeb = this.Factory.CreateRibbonButton();
			this.groupSearch = this.Factory.CreateRibbonGroup();
			this.toggleButtonSearch = this.Factory.CreateRibbonToggleButton();
			this.grpSave = this.Factory.CreateRibbonGroup();
			this.buttonUpload = this.Factory.CreateRibbonButton();
			this.grpPageSetup = this.Factory.CreateRibbonGroup();
			this.btnAddHeader = this.Factory.CreateRibbonButton();
			this.btnAddFooter = this.Factory.CreateRibbonButton();
			this.grpStyles = this.Factory.CreateRibbonGroup();
			this.grpInsert = this.Factory.CreateRibbonGroup();
			this.buttonInsertClause = this.Factory.CreateRibbonButton();
			this.btnRules = this.Factory.CreateRibbonButton();
			this.btnExclusions = this.Factory.CreateRibbonButton();
			this.btnCompare = this.Factory.CreateRibbonButton();
			this.grpInfo = this.Factory.CreateRibbonGroup();
			this.buttonFleschReading = this.Factory.CreateRibbonButton();
			this.menuMozart = this.Factory.CreateRibbonMenu();
			this.menu1 = this.Factory.CreateRibbonMenu();
			this.tabMozart.SuspendLayout();
			this.groupLogin.SuspendLayout();
			this.groupSearch.SuspendLayout();
			this.grpSave.SuspendLayout();
			this.grpPageSetup.SuspendLayout();
			this.grpInsert.SuspendLayout();
			this.grpInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMozart
			// 
			this.tabMozart.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
			this.tabMozart.Groups.Add(this.groupLogin);
			this.tabMozart.Groups.Add(this.groupSearch);
			this.tabMozart.Groups.Add(this.grpSave);
			this.tabMozart.Groups.Add(this.grpPageSetup);
			this.tabMozart.Groups.Add(this.grpStyles);
			this.tabMozart.Groups.Add(this.grpInsert);
			this.tabMozart.Groups.Add(this.grpInfo);
			this.tabMozart.Label = "Mozart";
			this.tabMozart.Name = "tabMozart";
			// 
			// groupLogin
			// 
			this.groupLogin.Items.Add(this.buttonLogin);
			this.groupLogin.Items.Add(this.buttonMozartWeb);
			this.groupLogin.Label = "Mozart Access";
			this.groupLogin.Name = "groupLogin";
			// 
			// buttonLogin
			// 
			this.buttonLogin.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.buttonLogin.Image = global::Mozart_WordAddIn.Properties.Resources.login_icon;
			this.buttonLogin.Label = "Login";
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.ShowImage = true;
			this.buttonLogin.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonLogin_Click);
			// 
			// buttonMozartWeb
			// 
			this.buttonMozartWeb.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.buttonMozartWeb.Image = global::Mozart_WordAddIn.Properties.Resources.Verisk;
			this.buttonMozartWeb.Label = "Mozart Web";
			this.buttonMozartWeb.Name = "buttonMozartWeb";
			this.buttonMozartWeb.ShowImage = true;
			this.buttonMozartWeb.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonMozartWeb_Click);
			// 
			// groupSearch
			// 
			this.groupSearch.Items.Add(this.toggleButtonSearch);
			this.groupSearch.Label = "Search";
			this.groupSearch.Name = "groupSearch";
			// 
			// toggleButtonSearch
			// 
			this.toggleButtonSearch.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.toggleButtonSearch.Image = global::Mozart_WordAddIn.Properties.Resources.search;
			this.toggleButtonSearch.Label = "Search";
			this.toggleButtonSearch.Name = "toggleButtonSearch";
			this.toggleButtonSearch.ShowImage = true;
			this.toggleButtonSearch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButtonSearch_Click);
			// 
			// grpSave
			// 
			this.grpSave.Items.Add(this.buttonUpload);
			this.grpSave.Label = "Upload";
			this.grpSave.Name = "grpSave";
			// 
			// buttonUpload
			// 
			this.buttonUpload.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.buttonUpload.Image = global::Mozart_WordAddIn.Properties.Resources.document_add;
			this.buttonUpload.Label = "Upload";
			this.buttonUpload.Name = "buttonUpload";
			this.buttonUpload.ShowImage = true;
			this.buttonUpload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonUpload_Click);
			// 
			// grpPageSetup
			// 
			this.grpPageSetup.Items.Add(this.btnAddHeader);
			this.grpPageSetup.Items.Add(this.btnAddFooter);
			this.grpPageSetup.Label = "Page Setup";
			this.grpPageSetup.Name = "grpPageSetup";
			// 
			// btnAddHeader
			// 
			this.btnAddHeader.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnAddHeader.Image = global::Mozart_WordAddIn.Properties.Resources.add_file_512;
			this.btnAddHeader.Label = "Add Header";
			this.btnAddHeader.Name = "btnAddHeader";
			this.btnAddHeader.ShowImage = true;
			this.btnAddHeader.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
			// 
			// btnAddFooter
			// 
			this.btnAddFooter.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnAddFooter.Image = global::Mozart_WordAddIn.Properties.Resources.add_file_512;
			this.btnAddFooter.Label = "Add Footer";
			this.btnAddFooter.Name = "btnAddFooter";
			this.btnAddFooter.ShowImage = true;
			// 
			// grpStyles
			// 
			this.grpStyles.Label = "Styles";
			this.grpStyles.Name = "grpStyles";
			// 
			// grpInsert
			// 
			this.grpInsert.Items.Add(this.buttonInsertClause);
			this.grpInsert.Items.Add(this.btnRules);
			this.grpInsert.Items.Add(this.btnExclusions);
			this.grpInsert.Items.Add(this.btnCompare);
			this.grpInsert.Label = "Insert";
			this.grpInsert.Name = "grpInsert";
			// 
			// buttonInsertClause
			// 
			this.buttonInsertClause.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.buttonInsertClause.Image = global::Mozart_WordAddIn.Properties.Resources.approve_list_512;
			this.buttonInsertClause.Label = "Insert Clause";
			this.buttonInsertClause.Name = "buttonInsertClause";
			this.buttonInsertClause.ShowImage = true;
			// 
			// btnRules
			// 
			this.btnRules.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnRules.Image = global::Mozart_WordAddIn.Properties.Resources.slide_4_2;
			this.btnRules.Label = "Rules";
			this.btnRules.Name = "btnRules";
			this.btnRules.ShowImage = true;
			// 
			// btnExclusions
			// 
			this.btnExclusions.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnExclusions.Image = global::Mozart_WordAddIn.Properties.Resources.exclude_128;
			this.btnExclusions.Label = "Exclusions";
			this.btnExclusions.Name = "btnExclusions";
			this.btnExclusions.ShowImage = true;
			// 
			// btnCompare
			// 
			this.btnCompare.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnCompare.Label = "Compare";
			this.btnCompare.Name = "btnCompare";
			this.btnCompare.ShowImage = true;
			this.btnCompare.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCompare_Click);
			// 
			// grpInfo
			// 
			this.grpInfo.Items.Add(this.buttonFleschReading);
			this.grpInfo.Label = "Info";
			this.grpInfo.Name = "grpInfo";
			// 
			// buttonFleschReading
			// 
			this.buttonFleschReading.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.buttonFleschReading.Image = global::Mozart_WordAddIn.Properties.Resources.Read_1127205431;
			this.buttonFleschReading.Label = "Flesch Score";
			this.buttonFleschReading.Name = "buttonFleschReading";
			this.buttonFleschReading.ShowImage = true;
			this.buttonFleschReading.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonFleschReading_Click);
			// 
			// menuMozart
			// 
			this.menuMozart.Image = global::Mozart_WordAddIn.Properties.Resources.Verisk;
			this.menuMozart.Items.Add(this.menu1);
			this.menuMozart.ItemSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.menuMozart.Label = "Mozart V2";
			this.menuMozart.Name = "menuMozart";
			this.menuMozart.ShowImage = true;
			// 
			// menu1
			// 
			this.menu1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.menu1.Label = "Sample Menu";
			this.menu1.Name = "menu1";
			this.menu1.ShowImage = true;
			// 
			// MozartRibbon
			// 
			this.Name = "MozartRibbon";
			// 
			// MozartRibbon.OfficeMenu
			// 
			this.OfficeMenu.Items.Add(this.menuMozart);
			this.RibbonType = "Microsoft.Word.Document";
			this.Tabs.Add(this.tabMozart);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MozartRibbon_Load);
			this.tabMozart.ResumeLayout(false);
			this.tabMozart.PerformLayout();
			this.groupLogin.ResumeLayout(false);
			this.groupLogin.PerformLayout();
			this.groupSearch.ResumeLayout(false);
			this.groupSearch.PerformLayout();
			this.grpSave.ResumeLayout(false);
			this.grpSave.PerformLayout();
			this.grpPageSetup.ResumeLayout(false);
			this.grpPageSetup.PerformLayout();
			this.grpInsert.ResumeLayout(false);
			this.grpInsert.PerformLayout();
			this.grpInfo.ResumeLayout(false);
			this.grpInfo.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabMozart;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpSave;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpPageSetup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpStyles;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpInsert;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpInfo;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupLogin;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonLogin;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonMozartWeb;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuMozart;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonUpload;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCompare;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupSearch;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButtonSearch;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAddHeader;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAddFooter;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRules;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnExclusions;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonInsertClause;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonFleschReading;
    }

    partial class ThisRibbonCollection
    {
        internal MozartRibbon MozartRibbon
        {
            get { return this.GetRibbon<MozartRibbon>(); }
        }
    }
}

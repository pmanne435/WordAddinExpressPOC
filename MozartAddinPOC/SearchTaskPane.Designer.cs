namespace MozartAddinPOC
{
	partial class SearchTaskPane
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
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
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtSearchWord = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabISO = new System.Windows.Forms.TabPage();
			this.listBoxSearchResults = new System.Windows.Forms.ListBox();
			this.tabClauses = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.tabISO.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(166, 42);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearchWord
			// 
			this.txtSearchWord.Location = new System.Drawing.Point(16, 45);
			this.txtSearchWord.Name = "txtSearchWord";
			this.txtSearchWord.Size = new System.Drawing.Size(100, 20);
			this.txtSearchWord.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabISO);
			this.tabControl1.Controls.Add(this.tabClauses);
			this.tabControl1.Location = new System.Drawing.Point(16, 86);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(249, 460);
			this.tabControl1.TabIndex = 2;
			// 
			// tabISO
			// 
			this.tabISO.Controls.Add(this.listBoxSearchResults);
			this.tabISO.Location = new System.Drawing.Point(4, 22);
			this.tabISO.Name = "tabISO";
			this.tabISO.Padding = new System.Windows.Forms.Padding(3);
			this.tabISO.Size = new System.Drawing.Size(241, 434);
			this.tabISO.TabIndex = 0;
			this.tabISO.Text = "Forms";
			this.tabISO.UseVisualStyleBackColor = true;
			// 
			// listBoxSearchResults
			// 
			this.listBoxSearchResults.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBoxSearchResults.FormattingEnabled = true;
			this.listBoxSearchResults.Location = new System.Drawing.Point(3, 3);
			this.listBoxSearchResults.Name = "listBoxSearchResults";
			this.listBoxSearchResults.Size = new System.Drawing.Size(238, 428);
			this.listBoxSearchResults.TabIndex = 0;
			this.listBoxSearchResults.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxSearchResults_DrawItem_1);
			this.listBoxSearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxSearchResults_MouseDoubleClick);
			// 
			// tabClauses
			// 
			this.tabClauses.Location = new System.Drawing.Point(4, 22);
			this.tabClauses.Name = "tabClauses";
			this.tabClauses.Padding = new System.Windows.Forms.Padding(3);
			this.tabClauses.Size = new System.Drawing.Size(241, 434);
			this.tabClauses.TabIndex = 1;
			this.tabClauses.Text = "Clauses";
			this.tabClauses.UseVisualStyleBackColor = true;
			// 
			// SearchTaskPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.txtSearchWord);
			this.Controls.Add(this.btnSearch);
			this.Name = "SearchTaskPane";
			this.Size = new System.Drawing.Size(283, 549);
			this.tabControl1.ResumeLayout(false);
			this.tabISO.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox txtSearchWord;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabISO;
		private System.Windows.Forms.TabPage tabClauses;
		private System.Windows.Forms.ListBox listBoxSearchResults;
	}
}

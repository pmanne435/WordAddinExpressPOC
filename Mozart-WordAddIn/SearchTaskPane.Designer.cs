namespace Mozart_WordAddIn
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
            this.tabControlSearchResults = new System.Windows.Forms.TabControl();
            this.tabPageForms = new System.Windows.Forms.TabPage();
            this.listBoxSearchResults = new System.Windows.Forms.ListBox();
            this.tabPageClauses = new System.Windows.Forms.TabPage();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.linkLabelAdvancedSearch = new System.Windows.Forms.LinkLabel();
            this.tabControlSearchResults.SuspendLayout();
            this.tabPageForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSearchResults
            // 
            this.tabControlSearchResults.Controls.Add(this.tabPageForms);
            this.tabControlSearchResults.Controls.Add(this.tabPageClauses);
            this.tabControlSearchResults.Location = new System.Drawing.Point(4, 63);
            this.tabControlSearchResults.Name = "tabControlSearchResults";
            this.tabControlSearchResults.SelectedIndex = 0;
            this.tabControlSearchResults.Size = new System.Drawing.Size(281, 470);
            this.tabControlSearchResults.TabIndex = 0;
            // 
            // tabPageForms
            // 
            this.tabPageForms.Controls.Add(this.listBoxSearchResults);
            this.tabPageForms.Location = new System.Drawing.Point(4, 22);
            this.tabPageForms.Name = "tabPageForms";
            this.tabPageForms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageForms.Size = new System.Drawing.Size(273, 444);
            this.tabPageForms.TabIndex = 0;
            this.tabPageForms.Text = "Forms";
            this.tabPageForms.UseVisualStyleBackColor = true;
            // 
            // listBoxSearchResults
            // 
            this.listBoxSearchResults.FormattingEnabled = true;
            this.listBoxSearchResults.Location = new System.Drawing.Point(6, 6);
            this.listBoxSearchResults.Name = "listBoxSearchResults";
            this.listBoxSearchResults.Size = new System.Drawing.Size(261, 433);
            this.listBoxSearchResults.TabIndex = 0;
            this.listBoxSearchResults.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxSearchResults_DrawItem);
            this.listBoxSearchResults.SelectedIndexChanged += new System.EventHandler(this.listBoxSearchResults_SelectedIndexChanged);
            this.listBoxSearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxSearchResults_MouseDoubleClick);
            // 
            // tabPageClauses
            // 
            this.tabPageClauses.Location = new System.Drawing.Point(4, 22);
            this.tabPageClauses.Name = "tabPageClauses";
            this.tabPageClauses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClauses.Size = new System.Drawing.Size(273, 444);
            this.tabPageClauses.TabIndex = 1;
            this.tabPageClauses.Text = "Clauses";
            this.tabPageClauses.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(231, 22);
            this.textBoxSearch.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackgroundImage = global::Mozart_WordAddIn.Properties.Resources.search;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Location = new System.Drawing.Point(241, 21);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(40, 38);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // linkLabelAdvancedSearch
            // 
            this.linkLabelAdvancedSearch.AutoSize = true;
            this.linkLabelAdvancedSearch.Location = new System.Drawing.Point(142, 46);
            this.linkLabelAdvancedSearch.Name = "linkLabelAdvancedSearch";
            this.linkLabelAdvancedSearch.Size = new System.Drawing.Size(93, 13);
            this.linkLabelAdvancedSearch.TabIndex = 2;
            this.linkLabelAdvancedSearch.TabStop = true;
            this.linkLabelAdvancedSearch.Text = "Advanced Search";
            // 
            // SearchTaskPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelAdvancedSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.tabControlSearchResults);
            this.Name = "SearchTaskPane";
            this.Size = new System.Drawing.Size(290, 536);
            this.tabControlSearchResults.ResumeLayout(false);
            this.tabPageForms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSearchResults;
        private System.Windows.Forms.TabPage tabPageForms;
        private System.Windows.Forms.TabPage tabPageClauses;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.LinkLabel linkLabelAdvancedSearch;
        private System.Windows.Forms.ListBox listBoxSearchResults;
    }
}

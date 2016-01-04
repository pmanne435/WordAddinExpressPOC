namespace MozartAddinPOC
{
	partial class LoginForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(180, 177);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 0;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(294, 176);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(110, 81);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(66, 13);
			this.lblUserName.TabIndex = 2;
			this.lblUserName.Text = "User Name :";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(113, 123);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(59, 13);
			this.lblPassword.TabIndex = 3;
			this.lblPassword.Text = "Password :";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(200, 81);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(120, 20);
			this.txtUserName.TabIndex = 4;
			this.txtUserName.Text = "Verisk";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(200, 116);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(120, 20);
			this.txtPassword.TabIndex = 5;
			this.txtPassword.TabStop = false;
			this.txtPassword.Text = "Verisk";
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 269);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnLogin);
			this.Name = "LoginForm";
			this.Text = "LoginForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
	}
}
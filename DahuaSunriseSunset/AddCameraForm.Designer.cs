namespace DahuaSunriseSunset
{
	partial class AddCameraForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.txtHostAndPort = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txtUser = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.cbHttps = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Host name and port number";
			this.toolTip1.SetToolTip(this.label1, "e.g. \"127.0.0.1:8080\"");
			// 
			// txtHostAndPort
			// 
			this.txtHostAndPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHostAndPort.Location = new System.Drawing.Point(15, 25);
			this.txtHostAndPort.Name = "txtHostAndPort";
			this.txtHostAndPort.Size = new System.Drawing.Size(257, 20);
			this.txtHostAndPort.TabIndex = 1;
			this.txtHostAndPort.Text = "127.0.0.1:8080";
			this.toolTip1.SetToolTip(this.txtHostAndPort, "e.g. \"127.0.0.1:8080\"");
			// 
			// txtUser
			// 
			this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUser.Location = new System.Drawing.Point(15, 73);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(257, 20);
			this.txtUser.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "User Name";
			// 
			// txtPass
			// 
			this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPass.Location = new System.Drawing.Point(15, 126);
			this.txtPass.Name = "txtPass";
			this.txtPass.Size = new System.Drawing.Size(257, 20);
			this.txtPass.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Password";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(78, 215);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(130, 23);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.Text = "Add Camera";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// cbHttps
			// 
			this.cbHttps.AutoSize = true;
			this.cbHttps.Location = new System.Drawing.Point(15, 167);
			this.cbHttps.Name = "cbHttps";
			this.cbHttps.Size = new System.Drawing.Size(146, 17);
			this.cbHttps.TabIndex = 7;
			this.cbHttps.Text = "Use https:// (secure http)";
			this.cbHttps.UseVisualStyleBackColor = true;
			// 
			// AddCameraForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 250);
			this.Controls.Add(this.cbHttps);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtHostAndPort);
			this.Controls.Add(this.label1);
			this.Name = "AddCameraForm";
			this.Text = "Add Camera";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtHostAndPort;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.CheckBox cbHttps;
	}
}
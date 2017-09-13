namespace DahuaSunriseSunset
{
	partial class ConfigurationForm
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
			this.txtLat = new System.Windows.Forms.TextBox();
			this.txtLon = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lbCameras = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.txtSetOffset = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtRiseOffset = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnEditSelected = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Latitude";
			// 
			// txtLat
			// 
			this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLat.Location = new System.Drawing.Point(15, 25);
			this.txtLat.Name = "txtLat";
			this.txtLat.Size = new System.Drawing.Size(257, 20);
			this.txtLat.TabIndex = 1;
			// 
			// txtLon
			// 
			this.txtLon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLon.Location = new System.Drawing.Point(15, 64);
			this.txtLon.Name = "txtLon";
			this.txtLon.Size = new System.Drawing.Size(257, 20);
			this.txtLon.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Longitude";
			// 
			// lbCameras
			// 
			this.lbCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbCameras.FormattingEnabled = true;
			this.lbCameras.Location = new System.Drawing.Point(15, 194);
			this.lbCameras.Name = "lbCameras";
			this.lbCameras.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbCameras.Size = new System.Drawing.Size(257, 121);
			this.lbCameras.TabIndex = 9;
			this.toolTip1.SetToolTip(this.lbCameras, "These cameras will have their profiles changed to Day at sunrise and changed to N" +
        "ight at sunset.");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 173);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Dahua Cameras";
			this.toolTip1.SetToolTip(this.label3, "These cameras will have their profiles changed to Day at sunrise and changed to N" +
        "ight at sunset.");
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.Location = new System.Drawing.Point(15, 353);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(114, 23);
			this.btnAdd.TabIndex = 12;
			this.btnAdd.Text = "Add Camera";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRemove.Location = new System.Drawing.Point(135, 353);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(137, 23);
			this.btnRemove.TabIndex = 13;
			this.btnRemove.Text = "Remove Selected";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// txtSetOffset
			// 
			this.txtSetOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSetOffset.Location = new System.Drawing.Point(15, 146);
			this.txtSetOffset.Name = "txtSetOffset";
			this.txtSetOffset.Size = new System.Drawing.Size(257, 20);
			this.txtSetOffset.TabIndex = 7;
			this.toolTip1.SetToolTip(this.txtSetOffset, "Number of hours after calculated sunset before camera profiles are changed.");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 130);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Sunset Offset Hours";
			this.toolTip1.SetToolTip(this.label4, "Number of hours after calculated sunset before camera profiles are changed.");
			// 
			// txtRiseOffset
			// 
			this.txtRiseOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRiseOffset.Location = new System.Drawing.Point(15, 107);
			this.txtRiseOffset.Name = "txtRiseOffset";
			this.txtRiseOffset.Size = new System.Drawing.Size(257, 20);
			this.txtRiseOffset.TabIndex = 5;
			this.toolTip1.SetToolTip(this.txtRiseOffset, "Number of hours after calculated sunrise before camera profiles are changed.");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Sunrise Offset Hours";
			this.toolTip1.SetToolTip(this.label5, "Number of hours after calculated sunrise before camera profiles are changed.");
			// 
			// btnEditSelected
			// 
			this.btnEditSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEditSelected.Location = new System.Drawing.Point(135, 324);
			this.btnEditSelected.Name = "btnEditSelected";
			this.btnEditSelected.Size = new System.Drawing.Size(137, 23);
			this.btnEditSelected.TabIndex = 11;
			this.btnEditSelected.Text = "Edit Selected";
			this.btnEditSelected.UseVisualStyleBackColor = true;
			this.btnEditSelected.Click += new System.EventHandler(this.btnEditSelected_Click);
			// 
			// ConfigurationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 384);
			this.Controls.Add(this.btnEditSelected);
			this.Controls.Add(this.txtSetOffset);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtRiseOffset);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbCameras);
			this.Controls.Add(this.txtLon);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtLat);
			this.Controls.Add(this.label1);
			this.Name = "ConfigurationForm";
			this.Text = "Configuration";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
			this.Load += new System.EventHandler(this.ConfigurationForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtLat;
		private System.Windows.Forms.TextBox txtLon;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbCameras;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.TextBox txtSetOffset;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRiseOffset;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnEditSelected;
	}
}
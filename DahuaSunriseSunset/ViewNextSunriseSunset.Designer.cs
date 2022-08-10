namespace DahuaSunriseSunset
{
	partial class ViewNextSunriseSunset
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
			this.label1 = new System.Windows.Forms.Label();
			this.pbSunriseSunsetGraph = new System.Windows.Forms.PictureBox();
			this.pbDay = new System.Windows.Forms.PictureBox();
			this.pbNight = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblComputingYear = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbSunriseSunsetGraph)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbNight)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(369, 173);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// pbSunriseSunsetGraph
			// 
			this.pbSunriseSunsetGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pbSunriseSunsetGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbSunriseSunsetGraph.Location = new System.Drawing.Point(15, 185);
			this.pbSunriseSunsetGraph.Name = "pbSunriseSunsetGraph";
			this.pbSunriseSunsetGraph.Size = new System.Drawing.Size(366, 240);
			this.pbSunriseSunsetGraph.TabIndex = 1;
			this.pbSunriseSunsetGraph.TabStop = false;
			// 
			// pbDay
			// 
			this.pbDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pbDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.pbDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbDay.Location = new System.Drawing.Point(87, 431);
			this.pbDay.Name = "pbDay";
			this.pbDay.Size = new System.Drawing.Size(20, 20);
			this.pbDay.TabIndex = 2;
			this.pbDay.TabStop = false;
			// 
			// pbNight
			// 
			this.pbNight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pbNight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.pbNight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbNight.Location = new System.Drawing.Point(244, 431);
			this.pbNight.Name = "pbNight";
			this.pbNight.Size = new System.Drawing.Size(20, 20);
			this.pbNight.TabIndex = 3;
			this.pbNight.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(113, 435);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Day";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(270, 435);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Night";
			// 
			// lblComputingYear
			// 
			this.lblComputingYear.AutoSize = true;
			this.lblComputingYear.Location = new System.Drawing.Point(82, 299);
			this.lblComputingYear.Name = "lblComputingYear";
			this.lblComputingYear.Size = new System.Drawing.Size(242, 13);
			this.lblComputingYear.TabIndex = 6;
			this.lblComputingYear.Text = "Computing Sunrise/Sunset graph for next 1 year...";
			// 
			// ViewNextSunriseSunset
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 462);
			this.Controls.Add(this.lblComputingYear);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pbNight);
			this.Controls.Add(this.pbDay);
			this.Controls.Add(this.pbSunriseSunsetGraph);
			this.Controls.Add(this.label1);
			this.Name = "ViewNextSunriseSunset";
			this.Text = "Next Sunrise and Sunset";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewNextSunriseSunset_FormClosing);
			this.Load += new System.EventHandler(this.ViewNextSunriseSunset_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbSunriseSunsetGraph)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbNight)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pbSunriseSunsetGraph;
		private System.Windows.Forms.PictureBox pbDay;
		private System.Windows.Forms.PictureBox pbNight;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblComputingYear;
	}
}
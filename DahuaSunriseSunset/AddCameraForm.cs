using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DahuaSunriseSunset
{
	public partial class AddCameraForm : Form
	{
		public CameraDefinition newCamera;

		public AddCameraForm()
		{
			InitializeComponent();
		}

		public void ConvertIntoEditForm(CameraDefinition existingCameraData)
		{
			newCamera = existingCameraData;
			txtHostAndPort.Text = newCamera.hostAndPort;
			txtUser.Text = newCamera.user;
			txtPass.Text = newCamera.pass;
			cbHttps.Checked = newCamera.https;
			txtDayZoom.Text = newCamera.dayZoom;
			txtDayFocus.Text = newCamera.dayFocus;
			txtNightZoom.Text = newCamera.nightZoom;
			txtNightFocus.Text = newCamera.nightFocus;
			this.Text = "Edit Camera";
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnGetCurrent_Click(object sender, EventArgs e)
		{
			WebClient wc = new WebClient();
			wc.Credentials = new NetworkCredential(txtUser.Text, txtPass.Text);
			wc.DownloadStringCompleted += (sender2, e2) =>
			{
				TextMessageBox.Show(e2.Result);
			};
			wc.DownloadStringAsync(new Uri("http" + (cbHttps.Checked ? "s" : "") + "://" + txtHostAndPort.Text + "/cgi-bin/devVideoInput.cgi?action=getFocusStatus"));
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			new CameraHelpForm().Show();
		}

		private void AddCameraForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			newCamera = new CameraDefinition(txtHostAndPort.Text, txtUser.Text, txtPass.Text, cbHttps.Checked, txtDayZoom.Text, txtDayFocus.Text, txtNightZoom.Text, txtNightFocus.Text);
		}
	}
}

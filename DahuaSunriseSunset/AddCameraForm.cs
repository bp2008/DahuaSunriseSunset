using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			newCamera = new CameraDefinition(txtHostAndPort.Text, txtUser.Text, txtPass.Text, cbHttps.Checked);
			this.Close();
		}
	}
}

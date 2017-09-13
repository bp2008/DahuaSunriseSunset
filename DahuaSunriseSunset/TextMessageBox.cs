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
	public partial class TextMessageBox : Form
	{
		public TextMessageBox(string text)
		{
			InitializeComponent();
			txtOutput.Text = text;
		}
		public void SetText(string text)
		{
			txtOutput.Text = text;
		}
		public static void Show(string text)
		{
			TextMessageBox box = new TextMessageBox(text);
			box.Show();
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BPUtil;
using BPUtil.Forms;

namespace DahuaSunriseSunset
{
	static class Program
	{
		static ServiceManager sm;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			Globals.Initialize(exePath);
			Directory.SetCurrentDirectory(Globals.ApplicationDirectoryBase);

			if (Environment.UserInteractive)
			{
				string Title = "DahuaSunriseSunset " + Assembly.GetEntryAssembly().GetName().Version.ToString() + " Service Manager";
				Logger.Info(Title + " Startup");
				string ServiceName = "DahuaSunriseSunset";
				ButtonDefinition btnConfigure = new ButtonDefinition("Configure Service", btnConfigure_Click);
				ButtonDefinition btnSimulateSunrise = new ButtonDefinition("Simulate Sunrise", btnSimulateSunrise_Click);
				ButtonDefinition btnViewNextTimes = new ButtonDefinition("View rise/set", btnViewNextTimes_Click);
				ButtonDefinition btnSimulateSunset = new ButtonDefinition("Simulate Sunset", btnSimulateSunset_Click);
				ButtonDefinition[] customButtons = new ButtonDefinition[] { btnConfigure, btnSimulateSunrise, btnViewNextTimes, btnSimulateSunset };

				Application.Run(sm = new ServiceManager(Title, ServiceName, customButtons));
			}
			else
			{
				ServiceBase[] ServicesToRun;
				ServicesToRun = new ServiceBase[]
				{
				new DahuaSunriseSunsetService()
				};
				ServiceBase.Run(ServicesToRun);
			}
		}
		static Form cfgForm = null;

		private static void btnConfigure_Click(object sender, EventArgs e)
		{
			if (cfgForm == null)
			{
				cfgForm = new ConfigurationForm();
				cfgForm.StartPosition = FormStartPosition.CenterParent;
				cfgForm.FormClosed += CfgForm_FormClosed;
				cfgForm.Show(sm);
			}
			else
				cfgForm.Focus();
		}

		private static void CfgForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			cfgForm = null;
		}

		private static void btnViewNextTimes_Click(object sender, EventArgs e)
		{
			ViewNextSunriseSunset f = new ViewNextSunriseSunset();
			f.StartPosition = FormStartPosition.CenterParent;
			f.Show(sm);
		}
		private static void btnSimulateSunrise_Click(object sender, EventArgs e)
		{
			ServiceWrapper.TriggerSunriseActions();
		}
		private static void btnSimulateSunset_Click(object sender, EventArgs e)
		{
			ServiceWrapper.TriggerSunsetActions();
		}
	}
}

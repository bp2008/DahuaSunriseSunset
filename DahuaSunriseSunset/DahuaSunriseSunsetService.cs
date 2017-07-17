using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BPUtil;

namespace DahuaSunriseSunset
{
	public partial class DahuaSunriseSunsetService : ServiceBase
	{
		public DahuaSunriseSunsetService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			Logger.Info("DahuaSunriseSunset " + Assembly.GetEntryAssembly().GetName().Version.ToString() + " Service OnStart");
			ServiceWrapper.Start();
		}

		protected override void OnStop()
		{
			Logger.Info("DahuaSunriseSunset " + Assembly.GetEntryAssembly().GetName().Version.ToString() + " Service OnStop");
			ServiceWrapper.Stop();
		}
	}
}

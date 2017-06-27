using System;
using System.Net;
using System.Threading;
using BPUtil;

namespace DahuaSunriseSunset
{
	public static class ServiceWrapper
	{
		private static object syncLockStartStop = new object();
		private static object syncLockCameraControl = new object();

		private static Thread thrRunner;

		public static void Start()
		{
			lock (syncLockStartStop)
			{
				Stop();
				thrRunner = new Thread(scheduler);
				thrRunner.IsBackground = true;
				thrRunner.Name = "Scheduler";
				thrRunner.Start();
			}
		}
		public static void Stop()
		{
			lock (syncLockStartStop)
			{
				thrRunner?.Abort();
				thrRunner = null;
			}
		}
		private static void scheduler()
		{
			try
			{
				while (true)
				{
					try
					{
						// Calculate the next SunEvent
						SunEvent nextEvent = null;

						DahuaSunriseSunsetConfig cfg = new DahuaSunriseSunsetConfig();
						cfg.Load();

						DateTime rise, set;
						SunHelper.Calc(cfg.latitude, cfg.longitude, out rise, out set);

						if (rise < set)
							nextEvent = new SunEvent(rise, true);
						else if (set < rise)
							nextEvent = new SunEvent(set, false);
						else
							nextEvent = new SunEvent(rise, false); // Rise and set are at the same time ... lets just call it a sunset.

						// Now we know when the next event is and what type it is, so we know what profile the cameras should be now.
						if (nextEvent.rise)
						{
							// Next event is a sunrise, which means it is currently Night.
							TriggerSunsetActions();
						}
						else
						{
							// Next event is a sunset, which means it is currently Day.
							TriggerSunriseActions();
						}
						while (DateTime.Now < nextEvent.time)
							Thread.Sleep(1000);
					}
					catch (ThreadAbortException) { throw; }
					catch (Exception ex) { Logger.Debug(ex); }
				}
			}
			catch (ThreadAbortException) { }
			catch (Exception ex) { Logger.Debug(ex); }
		}
		public static void TriggerSunriseActions()
		{
			lock (syncLockCameraControl)
			{
				DahuaSunriseSunsetConfig cfg = new DahuaSunriseSunsetConfig();
				cfg.Load();
				foreach (CameraDefinition cam in cfg.DahuaCameras)
				{
					WebClient wc = new WebClient();
					wc.Credentials = cam.GetCredentials();
					wc.DownloadString(cam.GetUrlBase() + "cgi-bin/configManager.cgi?action=setConfig&VideoInMode[0].Config[0]=0");
				}
			}
		}
		public static void TriggerSunsetActions()
		{
			lock (syncLockCameraControl)
			{
				DahuaSunriseSunsetConfig cfg = new DahuaSunriseSunsetConfig();
				cfg.Load();
				foreach (CameraDefinition cam in cfg.DahuaCameras)
				{
					WebClient wc = new WebClient();
					wc.Credentials = cam.GetCredentials();
					wc.DownloadString(cam.GetUrlBase() + "cgi-bin/configManager.cgi?action=setConfig&VideoInMode[0].Config[0]=1");
				}
			}
		}
	}
	class SunEvent
	{
		public DateTime time;
		public bool rise = false;
		public SunEvent(DateTime time, bool rise)
		{
			this.time = time;
			this.rise = rise;
		}
	}
}
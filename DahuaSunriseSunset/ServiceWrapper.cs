using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BPUtil;

namespace DahuaSunriseSunset
{
	public static class ServiceWrapper
	{
		private static object syncLockStartStop = new object();
		private static object syncLockCameraControl = new object();

		private static Thread thrRunner;

		static ServiceWrapper()
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
		}
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
						bool timeZoneAndLongitudeAreCompatible;
						SunHelper.Calc(cfg.latitude, cfg.longitude, out rise, out set, out timeZoneAndLongitudeAreCompatible, cfg.sunriseOffsetHours, cfg.sunsetOffsetHours);
						if (!timeZoneAndLongitudeAreCompatible)
						{
							Logger.Debug("Pausing scheduler for 1 day due to incompatible time zone and longitude. Please fix the problem and restart the service.");
							Thread.Sleep(TimeSpan.FromDays(1));
							continue;
						}
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
							TriggerSunsetActions(nextEvent.time);
						}
						else
						{
							// Next event is a sunset, which means it is currently Day.
							TriggerSunriseActions(nextEvent.time);
						}
						while (DateTime.Now <= nextEvent.time)
							Thread.Sleep(1000);
					}
					catch (ThreadAbortException) { throw; }
					catch (Exception ex)
					{
						Logger.Debug(ex);
						Thread.Sleep(1000);
					}
				}
			}
			catch (ThreadAbortException) { }
			catch (Exception ex) { Logger.Debug(ex); }
		}
		public static void TriggerSunriseActions(DateTime nextEventTime)
		{
			Logger.Info("TriggerSunriseActions");
			lock (syncLockCameraControl)
			{
				DahuaSunriseSunsetConfig cfg = new DahuaSunriseSunsetConfig();
				cfg.Load();
				ParallelOptions opt = new ParallelOptions();
				opt.MaxDegreeOfParallelism = NumberUtil.Clamp(cfg.DahuaCameras.Count, 1, 8);
				Parallel.ForEach(cfg.DahuaCameras, opt, (cam) =>
				{
					try
					{
						WebClient wc = new WebClient();
						wc.Credentials = cam.GetCredentials();
						int[] channelIndexes = cam.ChannelIndexes;
						for (int i = 0; i < channelIndexes.Length; i++)
						{
							WebRequestRobust(nextEventTime, wc, cam.GetUrlBase() + "cgi-bin/configManager.cgi?action=setConfig&VideoInMode[" + channelIndexes[i] + "].Config[0]=" + (int)cam.sunriseProfile);
							if (i + 1 < channelIndexes.Length)
								Thread.Sleep(5000);
						}
						HandleZoomAndFocus(nextEventTime, wc, cam, cam.dayZoom, cam.dayFocus);
					}
					catch (ThreadAbortException) { throw; }
					catch (Exception ex)
					{
						Logger.Debug(ex);
					}
				});
			}
		}

		public static void TriggerSunsetActions(DateTime nextEventTime)
		{
			Logger.Info("TriggerSunsetActions");
			lock (syncLockCameraControl)
			{
				DahuaSunriseSunsetConfig cfg = new DahuaSunriseSunsetConfig();
				cfg.Load();
				ParallelOptions opt = new ParallelOptions();
				opt.MaxDegreeOfParallelism = NumberUtil.Clamp(cfg.DahuaCameras.Count, 1, 8);
				Parallel.ForEach(cfg.DahuaCameras, opt, (cam) =>
				{
					try
					{
						WebClient wc = new WebClient();
						wc.Credentials = cam.GetCredentials();
						int[] channelIndexes = cam.ChannelIndexes;
						for (int i = 0; i < channelIndexes.Length; i++)
						{
							WebRequestRobust(nextEventTime, wc, cam.GetUrlBase() + "cgi-bin/configManager.cgi?action=setConfig&VideoInMode[" + channelIndexes[i] + "].Config[0]=" + (int)cam.sunsetProfile);
							if (i + 1 < channelIndexes.Length)
								Thread.Sleep(5000);
						}
						HandleZoomAndFocus(nextEventTime, wc, cam, cam.nightZoom, cam.nightFocus);
					}
					catch (ThreadAbortException) { throw; }
					catch (Exception ex)
					{
						Logger.Debug(ex);
					}
				});
			}
		}

		private static void HandleZoomAndFocus(DateTime nextEventTime, WebClient wc, CameraDefinition cam, string zoom, string focus)
		{
			double dbl;
			bool SetZoom = !string.IsNullOrWhiteSpace(zoom) && double.TryParse(zoom, out dbl);
			bool FocusIsEmpty = string.IsNullOrWhiteSpace(focus);
			bool ManualFocus = FocusIsEmpty ? false : double.TryParse(focus, out dbl);
			// There are 4 cases
			if (SetZoom)
			{
				if (ManualFocus)
				{
					// Case 1: Manual Zoom, Manual Focus
					Thread.Sleep(3000);
					// Do this in a loop, because Dahua's API is buggy.
					// Often, the first command causes only focus to happen.
					// The second typically causes zoom and autofocus.
					// The third or fourth usually causes our manual focus level to be set.
					for (int i = 0; i < 5; i++)
					{
						WebRequestRobust(nextEventTime, wc, cam.GetUrlBase() + "cgi-bin/devVideoInput.cgi?action=adjustFocus&focus=" + focus + "&zoom=" + zoom);
						Thread.Sleep(Math.Max(1, cam.secondsBetweenLensCommands) * 1000);
					}
				}
				else
				{
					// Case 2: Manual Zoom, Autofocus
					focus = zoom;
					Thread.Sleep(3000);
					// Do this in a loop, because Dahua's API is buggy.
					// Often, the first command causes only focus to happen.
					// The second typically causes zoom and autofocus.
					// The third or fourth usually causes our manual focus level to be set.
					for (int i = 0; i < 4; i++)
					{
						WebRequestRobust(nextEventTime, wc, cam.GetUrlBase() + "cgi-bin/devVideoInput.cgi?action=adjustFocus&focus=" + focus + "&zoom=" + zoom);
						Thread.Sleep(Math.Max(1, cam.secondsBetweenLensCommands) * 1000);
					}
					// This method has been, in my experience, reliable enough to call only once.
					WebRequestRobust(nextEventTime, wc, cam.GetUrlBase() + "cgi-bin/devVideoInput.cgi?action=autoFocus");
				}
			}
			else
			{
				if (FocusIsEmpty || ManualFocus)
				{
					// Case 4: Don't zoom and don't focus.  Do nothing.
				}
				else
				{
					// Case 3: Autofocus Only
					// This method has been, in my experience, reliable enough to call only once.
					WebRequestRobust(nextEventTime, wc, cam.GetUrlBase() + "cgi-bin/devVideoInput.cgi?action=autoFocus");
				}
			}
		}
		private static void WebRequestRobust(DateTime nextEventTime, WebClient wc, string URL)
		{
			WaitProgressivelyLonger wpl = WaitProgressivelyLonger.Linear(600000, 5000, 0);
			while (true)
			{
				if (DateTime.Now >= nextEventTime)
				{
					Logger.Info("Cancelled web request (" + URL + ") due to the next event time being reached.");
					return;
				}
				try
				{
					wc.DownloadString(URL);
					return;
				}
				catch (ThreadAbortException) { throw; }
				catch (Exception ex)
				{
					Logger.Info("Exception thrown attempting web request (" + URL + "): " + ex.Message);
					wpl.Wait();
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
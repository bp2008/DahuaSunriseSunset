using BPUtil;
using CoordinateSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DahuaSunriseSunset
{
	public partial class ViewNextSunriseSunset : Form
	{
		public ViewNextSunriseSunset()
		{
			InitializeComponent();
		}
		BackgroundWorker bw;
		private void ViewNextSunriseSunset_Load(object sender, EventArgs e)
		{
			DahuaSunriseSunsetConfig cfg = new DahuaSunriseSunsetConfig();
			cfg.Load();

			DateTime rise, set;
			TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
			bool timeZoneAndLongitudeAreCompatible;
			SunHelper.Calc(cfg.latitude, cfg.longitude, out rise, out set, out timeZoneAndLongitudeAreCompatible, cfg.sunriseOffsetHours, cfg.sunsetOffsetHours);
			label1.Text = "Lat " + cfg.latitude + Environment.NewLine
				+ "Lon " + cfg.longitude + Environment.NewLine
				+ "UTC Offset: " + utcOffset.TotalSeconds + " seconds (" + utcOffset.TotalHours + " hours)" + Environment.NewLine
				+ Environment.NewLine
				+ (timeZoneAndLongitudeAreCompatible ? "" : "Your machine's time zone needs to be on the same side " + Environment.NewLine
														  + "of the prime meridian as the longitude you have entered." + Environment.NewLine + Environment.NewLine)
				+ (rise > set ?
				("Sunset at " + set + OffsetStr(cfg.sunsetOffsetHours) + Environment.NewLine
				+ "Sunrise at " + rise + OffsetStr(cfg.sunriseOffsetHours))
				:
				("Sunrise at " + rise + OffsetStr(cfg.sunriseOffsetHours) + Environment.NewLine
				+ "Sunset at " + set + OffsetStr(cfg.sunsetOffsetHours)));

			bw = new BackgroundWorker();
			bw.DoWork += Bw_DoWork;
			bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
			bw.WorkerSupportsCancellation = true;
			bw.RunWorkerAsync(cfg);
		}

		private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			bw = null;
			if (e.Result == null)
			{
				lblComputingYear.Text = "Cancelled...";
				return;
			}
			lblComputingYear.Visible = false;
			pbSunriseSunsetGraph.BorderStyle = BorderStyle.None;
			pbSunriseSunsetGraph.Image = ((dynamic)e.Result).bmp as Bitmap;
			BasicEventTimer bet = ((dynamic)e.Result).timing as BasicEventTimer;
			label1.Text += Environment.NewLine + Environment.NewLine + "It took " + bet.GetEventTime(0).TotalMilliseconds.ToString("0") + "ms to compute Sunrise/Sunset times for 1 year, and " + bet.GetEventTime(1).TotalMilliseconds.ToString("0") + "ms to render the graph.";
		}

		private void Bw_DoWork(object sender, DoWorkEventArgs e)
		{
			DahuaSunriseSunsetConfig cfg = (DahuaSunriseSunsetConfig)e.Argument;
			try
			{
				BasicEventTimer bet = new BasicEventTimer();
				bet.Start("Sunrise/Sunset Computations");
				DateTime startDate = DateTime.Today;
				DateTime start = startDate;
				DateTime end = startDate.AddYears(1);
				List<SunriseSunsetEvent> events = new List<SunriseSunsetEvent>();
				while (start < end)
				{
					if (e.Cancel)
						return;
					Coordinate c = new Coordinate(cfg.latitude, cfg.longitude, start);
					c.Offset = TimeZone.CurrentTimeZone.GetUtcOffset(start).TotalHours;
					DateTime nextRise = Celestial.Get_Next_SunRise(c);
					DateTime nextSet = Celestial.Get_Next_SunSet(c);
					if (nextRise > nextSet)
					{
						events.Add(new SunriseSunsetEvent(nextSet, false));
						events.Add(new SunriseSunsetEvent(nextRise, true));
						start = nextRise.AddSeconds(1);
					}
					else
					{
						events.Add(new SunriseSunsetEvent(nextRise, true));
						events.Add(new SunriseSunsetEvent(nextSet, false));
						start = nextSet.AddSeconds(1);
					}
				}
				// Add fake event much later so that the graph rendering will complete correctly.
				events.Add(new SunriseSunsetEvent(events[events.Count - 1].time.AddYears(1), !events[events.Count - 1].isRise));
				bet.Start("Graph Rendering");
				Bitmap bmp = new Bitmap(366, 240, PixelFormat.Format24bppRgb);
				List<AxisLabel> xAxisLabels = new List<AxisLabel>();
				List<AxisLabel> yAxisLabels = new List<AxisLabel>();
				if (events.Count > 0)
				{
					int i = 0;
					for (int x = 0; x < bmp.Width; x++)
					{
						for (int y = 0; y < bmp.Height; y++)
						{
							DateTime pixelTime = startDate.AddDays(x).AddHours(y / 10.0);
							if (events[i].time < pixelTime)
								i++;
							if (y > bmp.Height - 6 && pixelTime.Day == 1)
							{
								// This pixel is a tickmark on the y-axis.
								if (y == bmp.Height - 5)
									xAxisLabels.Add(new AxisLabel(x, y, pixelTime.Month.ToString()));
								bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
							}
							else if (x < 6 && y > 0 && y % 10 == 0)
							{
								// This pixel is a tickmark on the x-axis.
								if (x == 5)
									yAxisLabels.Add(new AxisLabel(x, y, pixelTime.Hour.ToString()));
								bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
							}
							else
							{
								bool isDay = !events[i].isRise;
								if (isDay)
									bmp.SetPixel(x, y, Color.FromArgb(255, 255, 128));
								else
									bmp.SetPixel(x, y, Color.FromArgb(128, 128, 255));
							}
						}
					}
				}

				Graphics g = Graphics.FromImage(bmp);

				Font yAxisFont = new Font("Tahoma", 6);
				Font xAxisFont = new Font("Tahoma", 8);
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;

				PointF upperLeftDrawnPoint = PointF.Empty;
				foreach (AxisLabel lbl in xAxisLabels)
				{
					SizeF size = g.MeasureString(lbl.label, xAxisFont);
					float x = lbl.x - (size.Width / 2) + 1;
					float y = lbl.y - size.Height;
					g.DrawString(lbl.label, xAxisFont, Brushes.Black, x, y);
					if (upperLeftDrawnPoint.IsEmpty)
						upperLeftDrawnPoint = new PointF(x, y);
				}
				foreach (AxisLabel lbl in yAxisLabels)
				{
					SizeF size = g.MeasureString(lbl.label, yAxisFont);
					float x = lbl.x + 1;
					float y = lbl.y - (size.Height / 2) + 1;
					if (x + size.Width <= upperLeftDrawnPoint.X || y + size.Height <= upperLeftDrawnPoint.Y)
						g.DrawString(lbl.label, yAxisFont, Brushes.Black, x, y);
				}
				g.Flush();
				bet.Stop();
				pbSunriseSunsetGraph.Image = bmp;
				e.Result = new { bmp, timing = bet };
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		class SunriseSunsetEvent
		{
			public DateTime time;
			public bool isRise;

			public SunriseSunsetEvent(DateTime time, bool isRise)
			{
				this.time = time;
				this.isRise = isRise;
			}
		}
		class AxisLabel
		{
			public int x;
			public int y;
			public string label;

			public AxisLabel(int x, int y, string label)
			{
				this.x = x;
				this.y = y;
				this.label = label;
			}
		}
		private static string OffsetStr(double hours)
		{
			if (hours == 0)
				return "";
			else
				return " (time was offset " + hours + " hr)";
		}

		private void ViewNextSunriseSunset_FormClosing(object sender, FormClosingEventArgs e)
		{
			bw?.CancelAsync();
		}
	}
}

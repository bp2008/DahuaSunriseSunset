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
	public partial class ViewNextSunriseSunset : Form
	{
		public ViewNextSunriseSunset()
		{
			InitializeComponent();
		}

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
		}
		private static string OffsetStr(double hours)
		{
			if (hours == 0)
				return "";
			else
				return " (time was offset " + hours + " hr)";
		}
	}
}

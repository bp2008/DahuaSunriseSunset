using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoordinateSharp;

namespace DahuaSunriseSunset
{
	public static class SunHelper
	{
		/// <summary>
		/// Calculates the next sunrise and sunset that occur AFTER this moment in local time.
		/// If providing offset hours arguments, the rise and set times will be adjusted by those offsets
		/// (e.g. a rise time of 5 AM with an offset of -0.5 hours will result in the rise time being considered as 4:30 AM)
		/// </summary>
		/// <param name="lat">Latitude</param>
		/// <param name="lon">Longitude</param>
		/// <param name="nextRise">The next sunrise date</param>
		/// <param name="nextSet">The next sunset date</param>
		public static void Calc(double lat, double lon, out DateTime nextRise, out DateTime nextSet, out bool timeZoneAndLongitudeAreCompatible, double sunriseOffsetHours = 0, double sunsetOffsetHours = 0)
		{
			nextRise = DateTime.MinValue;
			nextSet = DateTime.MinValue;
			timeZoneAndLongitudeAreCompatible = true;
			DateTime now = DateTime.Now;
			for (int offsetMinutes = 0; offsetMinutes < 525600; offsetMinutes += 10)  // 525600 minutes in 1 year
			{
				DateTime t = now.AddMinutes(offsetMinutes);
				Coordinate c = new Coordinate(lat, lon, t);
				c.Offset = TimeZone.CurrentTimeZone.GetUtcOffset(t).TotalHours;

				nextRise = Celestial.Get_Next_SunRise(c).AddHours(sunriseOffsetHours);
				nextSet = Celestial.Get_Next_SunSet(c).AddHours(sunsetOffsetHours);

				if (nextRise > now && nextSet > now)
					return;
			}

			//for (int offsetDays = 0; offsetDays < 366; offsetDays++)
			//{
			//	if (nextRise == DateTime.MinValue && c.CelestialInfo.SunRise != null && c.CelestialInfo.SunRise.Value.AddHours(sunriseOffsetHours) > now)
			//		nextRise = c.CelestialInfo.SunRise.Value.AddHours(sunriseOffsetHours).AddHours(-4);
			//	if (nextSet == DateTime.MinValue && c.CelestialInfo.SunSet != null && c.CelestialInfo.SunSet.Value.AddHours(sunsetOffsetHours) > now)
			//		nextSet = c.CelestialInfo.SunSet.Value.AddHours(sunsetOffsetHours).AddHours(-4);
			//	if (nextRise != DateTime.MinValue && nextSet != DateTime.MinValue)
			//		return;
			//}
			//timeZoneAndLongitudeAreCompatible = true;

			//DateTime now = DateTime.Now;
			//nextRise = DateTime.MinValue;
			//nextSet = DateTime.MinValue;

			//DateTime rise = DateTime.MinValue, set = DateTime.MinValue;
			//bool doesRise = false, doesSet = false;

			//for (int offsetDays = 0; offsetDays < 366; offsetDays++)
			//{
			//	DateTime calcDay = now.AddDays(offsetDays);
			//	timeZoneAndLongitudeAreCompatible = SunTimes.Instance.CalculateSunRiseSetTimes(lat, lon, calcDay, ref rise, ref set, ref doesRise, ref doesSet);
			//	if (!timeZoneAndLongitudeAreCompatible)
			//		return;
			//	if (nextRise == DateTime.MinValue && rise.AddHours(sunriseOffsetHours) > now)
			//		nextRise = rise.AddHours(sunriseOffsetHours);
			//	if (nextSet == DateTime.MinValue && set.AddHours(sunsetOffsetHours) > now)
			//		nextSet = set.AddHours(sunsetOffsetHours);
			//	if (nextRise != DateTime.MinValue && nextSet != DateTime.MinValue)
			//		return;
			//}
		}
	}
}

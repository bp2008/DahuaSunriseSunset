using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPUtil;

namespace DahuaSunriseSunset
{
	public class DahuaSunriseSunsetConfig : SerializableObjectBase
	{
		public double latitude = 0;
		public double longitude = 0;
		public double sunriseOffsetHours = 0;
		public double sunsetOffsetHours = 0;
		public List<CameraDefinition> DahuaCameras = new List<CameraDefinition>();
	}
}

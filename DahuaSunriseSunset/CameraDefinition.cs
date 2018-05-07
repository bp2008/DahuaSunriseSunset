using System;
using System.Net;

namespace DahuaSunriseSunset
{
	public class CameraDefinition
	{
		public string hostAndPort;
		public string user;
		public string pass;
		public bool https;
		public string dayZoom = "";
		public string dayFocus = "";
		public string nightZoom = "";
		public string nightFocus = "";
		public int secondsBetweenLensCommands = 4;
		public Profile sunriseProfile = Profile.Day;
		public Profile sunsetProfile = Profile.Night;

		public CameraDefinition()
		{
		}
		public CameraDefinition(string hostAndPort, string user, string pass, bool https)
		{
			this.hostAndPort = hostAndPort;
			this.user = user;
			this.pass = pass;
			this.https = https;
		}

		public CameraDefinition(string hostAndPort, string user, string pass, bool https, string dayZoom, string dayFocus, string nightZoom, string nightFocus, int lensDelay, Profile sunriseProfile, Profile sunsetProfile) : this(hostAndPort, user, pass, https)
		{
			this.dayZoom = dayZoom;
			this.dayFocus = dayFocus;
			this.nightZoom = nightZoom;
			this.nightFocus = nightFocus;
			this.secondsBetweenLensCommands = lensDelay;
			this.sunriseProfile = sunriseProfile;
			this.sunsetProfile = sunsetProfile;
		}

		public override string ToString()
		{
			return "http" + (https ? "s" : "") + "://" + user + ":" + pass + "@" + hostAndPort + "/";
		}

		public ICredentials GetCredentials()
		{
			if (!string.IsNullOrEmpty(user))
				return new NetworkCredential(user, pass);
			return null;
		}

		public string GetUrlBase()
		{
			return "http" + (https ? "s" : "") + "://" + hostAndPort + "/";
		}
	}
	public enum Profile
	{
		Day = 0,
		Night = 1,
		Normal = 2
	}
}
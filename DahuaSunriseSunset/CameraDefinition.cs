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

		public CameraDefinition(string hostAndPort, string user, string pass, bool https, string dayZoom, string dayFocus, string nightZoom, string nightFocus, int lensDelay) : this(hostAndPort, user, pass, https)
		{
			this.dayZoom = dayZoom;
			this.dayFocus = dayFocus;
			this.nightZoom = nightZoom;
			this.nightFocus = nightFocus;
			this.secondsBetweenLensCommands = lensDelay;
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
}
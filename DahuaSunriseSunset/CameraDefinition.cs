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
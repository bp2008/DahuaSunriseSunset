using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public string channelNumbers = "1";
		public int secondsBetweenLensCommands = 4;
		public Profile sunriseProfile = Profile.Day;
		public Profile sunsetProfile = Profile.Night;

		/// <summary>
		/// Gets the channel number minus 1, clamped between [0-255].
		/// </summary>
		public int[] ChannelIndexes
		{
			get
			{
				GetChannelIndexes(channelNumbers, out int[] channelIndexes);
				return channelIndexes;
			}
		}

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

		public CameraDefinition(string hostAndPort, string user, string pass, bool https, string dayZoom, string dayFocus, string nightZoom, string nightFocus, int lensDelay, Profile sunriseProfile, Profile sunsetProfile, string channelNumbers) : this(hostAndPort, user, pass, https)
		{
			this.dayZoom = dayZoom;
			this.dayFocus = dayFocus;
			this.nightZoom = nightZoom;
			this.nightFocus = nightFocus;
			this.secondsBetweenLensCommands = lensDelay;
			this.sunriseProfile = sunriseProfile;
			this.sunsetProfile = sunsetProfile;
			this.channelNumbers = channelNumbers;
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
		/// <summary>
		/// Parses the input string and returns true if it is valid or false if invalid. Also outputs an array of valid channel indexes that is guaranteed not to be empty.
		/// </summary>
		/// <param name="channelIndexes"></param>
		/// <returns></returns>
		public static bool GetChannelIndexes(string str, out int[] channelIndexes)
		{
			List<int> indexes = new List<int>();
			bool allOk = true;
			if (!string.IsNullOrWhiteSpace(str))
			{
				foreach (string strNum in str.Split(','))
				{
					if (int.TryParse(strNum.Trim(), out int num))
						indexes.Add(NumberUtil.Clamp(num - 1, 0, 255));
					else
						allOk = false;
				}
			}
			if (indexes.Count == 0)
				indexes.Add(0);
			channelIndexes = indexes.ToArray();
			return allOk;
		}
	}
	public enum Profile
	{
		Day = 0,
		Night = 1,
		Normal = 2
	}
}
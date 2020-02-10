using System;
using System.Linq;

namespace Bitbucket.Cloud.Net.Common
{
	public static class UriExtensions
	{
		public static string GetLastPathSegment(this string s) => new Uri(s).Segments.LastOrDefault();
	}
}

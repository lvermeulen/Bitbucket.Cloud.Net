using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class BuildResultStatesConverter : JsonEnumConverter<BuildResultStates>
	{
		private static readonly Dictionary<BuildResultStates, string> s_map = new Dictionary<BuildResultStates, string>
		{
			[BuildResultStates.Successful] = "SUCCESSFUL",
			[BuildResultStates.Failed] = "FAILED",
			[BuildResultStates.InProgress] = "INPROGRESS",
			[BuildResultStates.Stopped] = "STOPPED"
		};

		protected override string ConvertToString(BuildResultStates value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown build result state: {value}");
			}

			return result;
		}

		protected override BuildResultStates ConvertFromString(string s)
		{
			var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<BuildResultStates, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown build result state: {s}");
			}

			return pair.Key;
		}
	}
}

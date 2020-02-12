using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class PullRequestStatesConverter : JsonEnumConverter<PullRequestStates>
	{
		private static readonly Dictionary<PullRequestStates, string> s_map = new Dictionary<PullRequestStates, string>
		{
			[PullRequestStates.Merged] = "MERGED",
			[PullRequestStates.Superseded] = "SUPERSEDED",
			[PullRequestStates.Open] = "OPEN",
			[PullRequestStates.Declined] = "DECLINED"
		};

		protected override string ConvertToString(PullRequestStates value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown pullrequest state: {value}");
			}

			return result;
		}

		protected override PullRequestStates ConvertFromString(string s)
		{
			var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<PullRequestStates, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown pullrequest state: {s}");
			}

			return pair.Key;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class MergeStrategiesConverter : JsonEnumConverter<MergeStrategies>
	{
		private static readonly Dictionary<MergeStrategies, string> s_map = new Dictionary<MergeStrategies, string>
		{
			[MergeStrategies.MergeCommit] = "merge_commit",
			[MergeStrategies.Squash] = "squash",
			[MergeStrategies.FastForward] = "fast_forward"
		};

		protected override string ConvertToString(MergeStrategies value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown pullrequest state: {value}");
			}

			return result;
		}

		protected override MergeStrategies ConvertFromString(string s)
		{
			var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<MergeStrategies, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown pullrequest state: {s}");
			}

			return pair.Key;
		}
	}
}

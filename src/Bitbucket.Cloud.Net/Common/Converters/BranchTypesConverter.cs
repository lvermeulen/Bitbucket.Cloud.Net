using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class BranchTypesConverter : JsonEnumConverter<BranchTypes>
	{
		private static readonly Dictionary<BranchTypes, string> s_map = new Dictionary<BranchTypes, string>
		{
			[BranchTypes.Feature] = "feature",
			[BranchTypes.Bugfix] = "bugfix",
			[BranchTypes.Release] = "release",
			[BranchTypes.Hotfix] = "hotfix",
			[BranchTypes.Development] = "development",
			[BranchTypes.Production] = "production",
		};

		protected override string ConvertToString(BranchTypes value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown branch type: {value}");
			}

			return result;
		}

		protected override BranchTypes ConvertFromString(string s)
		{
			var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<BranchTypes, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown branch type: {s}");
			}

			return pair.Key;
		}
	}
}

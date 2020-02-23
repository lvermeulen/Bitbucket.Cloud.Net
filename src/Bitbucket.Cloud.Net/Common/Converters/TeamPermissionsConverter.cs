using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class TeamPermissionsConverter : JsonEnumConverter<TeamPermissions>
	{
		private static readonly Dictionary<TeamPermissions, string> s_map = new Dictionary<TeamPermissions, string>
		{
			[TeamPermissions.Admin] = "admin",
			[TeamPermissions.Collaborator] = "collaborator"
		};

		public static string ToString(TeamPermissions value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown team permission: {value}");
			}

			return result;
		}

		public static string ToString(TeamPermissions? value)
		{
			return value.HasValue
				? ToString(value.Value)
				: null;
		}

		protected override string ConvertToString(TeamPermissions value)
		{
			return ToString(value);
		}

		protected override TeamPermissions ConvertFromString(string s)
		{
			var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<TeamPermissions, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown team permission: {s}");
			}

			return pair.Key;
		}
	}
}

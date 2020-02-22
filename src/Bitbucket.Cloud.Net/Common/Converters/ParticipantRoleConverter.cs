using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class ParticipantRoleConverter : JsonEnumConverter<ParticipantRole>
	{
		private static readonly Dictionary<ParticipantRole, string> s_map = new Dictionary<ParticipantRole, string>
		{
			[ParticipantRole.Participant] = "PARTICIPANT",
			[ParticipantRole.Reviewer] = "REVIEWER"
		};

		protected override string ConvertToString(ParticipantRole value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown participant role: {value}");
			}

			return result;
		}

		protected override ParticipantRole ConvertFromString(string s)
		{
			var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<ParticipantRole, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown participant role: {s}");
			}

			return pair.Key;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class PullRequestParticipantRoleConverter : JsonEnumConverter<PullRequestParticipantRole>
	{
		private static readonly Dictionary<PullRequestParticipantRole, string> s_map = new Dictionary<PullRequestParticipantRole, string>
		{
			[PullRequestParticipantRole.Participant] = "PARTICIPANT",
			[PullRequestParticipantRole.Reviewer] = "REVIEWER"
		};

		protected override string ConvertToString(PullRequestParticipantRole value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown participant role: {value}");
			}

			return result;
		}

		protected override PullRequestParticipantRole ConvertFromString(string s)
		{
			var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<PullRequestParticipantRole, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown participant role: {s}");
			}

			return pair.Key;
		}
	}
}

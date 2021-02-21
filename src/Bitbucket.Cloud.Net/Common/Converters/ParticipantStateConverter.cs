using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class ParticipantStateConverter : JsonEnumConverter<ParticipantState>
	{
		private static readonly Dictionary<ParticipantState, string> s_map = new Dictionary<ParticipantState, string>
		{
			[ParticipantState.Approved] = "approved",
			[ParticipantState.ChangesRequested] = "changes_requested",
			[ParticipantState.None] = null
		};

		protected override string ConvertToString(ParticipantState value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown participant role: {value}");
			}

			return result;
		}

		protected override ParticipantState ConvertFromString(string s)
		{
			KeyValuePair<ParticipantState, string> pair = new KeyValuePair<ParticipantState, string>();
			//Someone who comments on a PR (or completes task, adds task, etc) won't have a participant state.
			if (string.IsNullOrEmpty(s))
			{
				pair = s_map.FirstOrDefault(kvp => string.IsNullOrEmpty(kvp.Value));
			}
			//Someone who approves or requests changes will have that participant state assocated.
			else {
				pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			}
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<ParticipantState, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown participant role: {s}");
			}

			return pair.Key;
		}
	}
}

using System;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Participant : User
	{
		[JsonConverter(typeof(ParticipantRoleConverter))]
		public ParticipantRole Role { get; set; }

		public bool Approved { get; set; }

		[JsonProperty("participated_on")]
		public DateTime? ParticipatedOn { get; set; }

		/// <summary>
		/// Used with pull requests, a participant will have a state if they've approved/requested changes on the PR.
		/// </summary>
		[JsonConverter(typeof(ParticipantStateConverter))]
		public ParticipantState State { get; set; }

		/// <summary>
		/// Despite a Participant being an extension of a user, it has a separate "user" section on it as well.
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
	}
}

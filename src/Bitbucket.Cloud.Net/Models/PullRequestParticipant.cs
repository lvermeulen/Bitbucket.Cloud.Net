using System;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public class PullRequestParticipant : User
	{
		[JsonConverter(typeof(PullRequestParticipantRoleConverter))]
		public PullRequestParticipantRole Role { get; set; }
		public bool Approved { get; set; }
		[JsonProperty("participated_on")]
		public DateTime? ParticipatedOn { get; set; }
	}
}

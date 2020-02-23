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
	}
}

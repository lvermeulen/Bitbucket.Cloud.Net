using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public class Owner
	{
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }

		public Guid Uuid { get; set; }

		[JsonProperty("is_team")]
		public bool IsTeam { get; set; }

		[JsonProperty("mention_id")]
		public string MentionId { get; set; }

		public string Avatar { get; set; }
		public string NickName { get; set; }

		[JsonProperty("account_id")]
		public string AccountId { get; set; }
	}
}
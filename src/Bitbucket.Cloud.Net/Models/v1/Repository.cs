using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public class Repository : RepositoryInfo<string>
	{
		public string Website { get; set; }

		[JsonProperty("read_only")]
		public bool ReadOnly { get; set; }

		[JsonProperty("has_wiki")]
		public bool HasWiki { get; set; }

		[JsonProperty("last_updated")]
		public DateTime? LastUpdated { get; set; }

		public string Language { get; set; }
		public bool Deleted { get; set; }

		[JsonProperty("is_mq")]
		public bool IsMq { get; set; }

		[JsonProperty("mq_of")]
		public object MqOf { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		[JsonProperty("fork_of")]
		public object ForkOf { get; set; }

		[JsonProperty("email_writers")]
		public bool EmailWriters { get; set; }

		public long Size { get; set; }

		[JsonProperty("has_issues")]
		public bool HasIssues { get; set; }

		[JsonProperty("no_public_forks")]
		public bool NoPublicForks { get; set; }

		[JsonProperty("email_mailinglist")]
		public string EmailMailinglist { get; set; }

		[JsonProperty("is_fork")]
		public bool IsFork { get; set; }

		[JsonProperty("is_private")]
		public bool IsPrivate { get; set; }

		public string Description { get; set; }
	}
}
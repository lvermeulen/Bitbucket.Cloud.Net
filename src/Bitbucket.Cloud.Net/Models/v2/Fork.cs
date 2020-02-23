using System;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Fork
	{
		[JsonConverter(typeof(ScmConverter))]
		public Scm Scm { get; set; }

		public object Website { get; set; }

		[JsonProperty("has_wiki")]
		public bool HasWiki { get; set; }

		public Guid Uuid { get; set; }
		public Links Links { get; set; }

		[JsonProperty("fork_policy")]
		[JsonConverter(typeof(ForkPolicyConverter))]
		public ForkPolicies ForkPolicy { get; set; }

		public string Name { get; set; }
		public string Language { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public RepositoryInfo Parent { get; set; }
		public TypedName MainBranch { get; set; }

		[JsonProperty("full_name")]
		public string FullName { get; set; }

		[JsonProperty("has_issues")]
		public bool HasIssues { get; set; }

		public AccountInfo Owner { get; set; }

		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }

		public int Size { get; set; }
		public string Type { get; set; }
		public string Slug { get; set; }

		[JsonProperty("is_private")]
		public bool IsPrivate { get; set; }

		public string Description { get; set; }
	}
}

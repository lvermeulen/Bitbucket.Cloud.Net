using System;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
    public class Repository : RepositoryInfo
    {
        [JsonConverter(typeof(ScmConverter))]
        public Scm Scm { get; set; }

        public string Website { get; set; }

        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }

        [JsonProperty("fork_policy")]
        [JsonConverter(typeof(ForkPolicyConverter))]
        public ForkPolicies ForkPolicy { get; set; }

        public string Language { get; set; }

        [JsonProperty("created_on")]
        public DateTime? CreatedOn { get; set; }

        public Branch MainBranch { get; set; }

        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; }

        public Person Owner { get; set; }

        [JsonProperty("updated_on")]
        public DateTime? UpdatedOn { get; set; }

        public long Size { get; set; }
        public string Slug { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        public string Description { get; set; }
        public string Key { get; set; }
    }
}
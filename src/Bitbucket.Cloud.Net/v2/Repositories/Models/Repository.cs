using System;
using Bitbucket.Cloud.Net.v2.Converters;
using Bitbucket.Cloud.Net.v2.Models;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.v2.Repositories.Models
{
    public class Repository
    {
        [JsonConverter(typeof(ScmConverter))]
        public Scm Scm { get; set; }
        public string Website { get; set; }
        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }
        public string Name { get; set; }
        public Links Links { get; set; }
        [JsonProperty("fork_policy")]
        [JsonConverter(typeof(ForkPolicyConverter))]
        public ForkPolicies ForkPolicy { get; set; }
        public Guid Uuid { get; set; }
        public string Language { get; set; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }
        public Branch MainBranch { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; }
        public Owner Owner { get; set; }
        [JsonProperty("updated_on")]
        public DateTime UpdatedOn { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }
        public string Description { get; set; }
    }
}
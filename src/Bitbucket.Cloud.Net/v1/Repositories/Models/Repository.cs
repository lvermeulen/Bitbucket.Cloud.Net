using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.Cloud.Net.v1.Repositories.Models
{
    public class Repository
    {
        public string Scm { get; set; }
        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }
        [JsonProperty("last_updated")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime LastUpdated { get; set; }
        public object Creator { get; set; }
        [JsonProperty("forks_count")]
        public int ForksCount { get; set; }
        [JsonProperty("created_on")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedOn { get; set; }
        public string Owner { get; set; }
        public object Logo { get; set; }
        [JsonProperty("email_mailinglist")]
        public string EmailMailinglist { get; set; }
        [JsonProperty("is_mq")]
        public bool IsMq { get; set; }
        public int Size { get; set; }
        [JsonProperty("read_only")]
        public bool ReadOnly { get; set; }
        [JsonProperty("fork_of")]
        public object ForkOf { get; set; }
        [JsonProperty("mq_of")]
        public object MqOf { get; set; }
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }
        public string State { get; set; }
        [JsonProperty("utc_created_on")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UtcCreatedOn { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; }
        [JsonProperty("is_fork")]
        public bool IsFork { get; set; }
        public string Slug { get; set; }
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        [JsonProperty("utc_last_updated")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UtcLastUpdated { get; set; }
        [JsonProperty("email_writers")]
        public bool EmailWriters { get; set; }
        [JsonProperty("no_public_forks")]
        public bool NoPublicForks { get; set; }
        [JsonProperty("resource_uri")]
        public string ResourceUri { get; set; }
    }

}

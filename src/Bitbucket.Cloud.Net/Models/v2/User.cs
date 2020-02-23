using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.Cloud.Net.Models.v2
{
    public class User : UserInfo
    {
        [JsonProperty("account_status")]
        public string AccountStatus { get; set; }

        public object Website { get; set; }

        [JsonProperty("created_on")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedOn { get; set; }

        [JsonProperty("has_2fa_enabled")]
        public bool? Has2FaEnabled { get; set; }

        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }
    }
}

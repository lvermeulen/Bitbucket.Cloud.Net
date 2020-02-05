using System;
using Bitbucket.Cloud.Net.v2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.Cloud.Net.v2.User.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        [JsonProperty("account_status")]
        public string AccountStatus { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        public object Website { get; set; }
        [JsonProperty("created_on")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedOn { get; set; }
        public Guid Uuid { get; set; }
        [JsonProperty("has_2fa_enabled")]
        public bool? Has2FaEnabled { get; set; }
        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        public Links Links { get; set; }
        public string Type { get; set; }
    }
}

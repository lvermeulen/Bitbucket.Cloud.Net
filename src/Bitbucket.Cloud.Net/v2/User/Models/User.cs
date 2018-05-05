using System;
using Bitbucket.Cloud.Net.v2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.Cloud.Net.v2.User.Models
{
    public class User
    {
        public string UserName { get; set; }
        public object Website { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        public Links Links { get; set; }
        [JsonProperty("created_on")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedOn { get; set; }
        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }
        public object Location { get; set; }
        public string Type { get; set; }
        public Guid Uuid { get; set; }
    }
}

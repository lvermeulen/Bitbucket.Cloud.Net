using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.Cloud.Net.Models
{
	public class SshKey
	{
		public string Comment { get; set; }
		[JsonProperty("created_on")]
		[JsonConverter(typeof(IsoDateTimeConverter))]
		public DateTime CreatedOn { get; set; }
		public string Key { get; set; }
		public string Label { get; set; }
		[JsonProperty("last_used")]
		[JsonConverter(typeof(IsoDateTimeConverter))]
		public DateTime? LastUsed { get; set; }
		public Links Links { get; set; }
		public User Owner { get; set; }
		public string Type { get; set; }
		public string Uuid { get; set; }
	}
}

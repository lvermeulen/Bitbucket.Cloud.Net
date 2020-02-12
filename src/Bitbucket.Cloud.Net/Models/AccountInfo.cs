using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public class AccountInfo : HasUuid
	{
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }
		public Links Links { get; set; }
		public string Nickname { get; set; }
		public string Type { get; set; }
		[JsonProperty("account_id")]
		public string AccountId { get; set; }
	}
}
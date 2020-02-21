using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public class AccountInfo : UserInfo
	{
		[JsonProperty("account_id")]
		public string AccountId { get; set; }
	}
}
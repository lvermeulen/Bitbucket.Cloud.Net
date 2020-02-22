using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class AccountInfo : UserInfo
	{
		[JsonProperty("account_id")]
		public string AccountId { get; set; }
	}
}
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public abstract class AccountBase : HasUuid
	{
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }

		public string NickName { get; set; }
	}
}
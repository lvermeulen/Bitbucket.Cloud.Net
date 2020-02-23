using Bitbucket.Cloud.Net.Models.v2;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public abstract class PersonBase : AccountBase
	{
		[JsonProperty("account_id")]
		public string AccountId { get; set; }

		[JsonProperty("is_team")]
		public bool IsTeam { get; set; }

		public string Avatar { get; set; }
	}
}
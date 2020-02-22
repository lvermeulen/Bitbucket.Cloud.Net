using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public class Person : PersonBase
	{
		[JsonProperty("mention_id")]
		public string MentionId { get; set; }
	}
}
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public class User : PersonBase
	{
		[JsonProperty("is_staff")]
		public bool IsStaff { get; set; }

		[JsonProperty("resource_uri")]
		public string ResourceUri { get; set; }
	}
}

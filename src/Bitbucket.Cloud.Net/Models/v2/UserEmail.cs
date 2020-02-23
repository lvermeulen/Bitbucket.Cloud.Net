using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class UserEmail
	{
		[JsonProperty("is_primary")]
		public bool IsPrimary { get; set; }

		[JsonProperty("is_confirmed")]
		public bool IsConfirmed { get; set; }

		public string Type { get; set; }
		public string Email { get; set; }
		public Links Links { get; set; }
	}
}

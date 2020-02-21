using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public abstract class PersonBase : HasUuid
	{
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }
		public string Type { get; set; }
		public OwnerLinks Links { get; set; }
	}
}
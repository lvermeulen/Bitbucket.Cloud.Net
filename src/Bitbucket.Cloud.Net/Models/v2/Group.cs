using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Group
	{
		public string Name { get; set; }
		public Links Links { get; set; }

		[JsonProperty("full_slug")]
		public string FullSlug { get; set; }

		public Person Owner { get; set; }
		public string Type { get; set; }
		public string Slug { get; set; }
	}
}
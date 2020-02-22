using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class RepositoryInfo
	{
		public string Name { get; set; }
		[JsonProperty("full_name")]
		public string FullName { get; set; }
		public string Type { get; set; }
		public Guid Uuid { get; set; }
		public Links Links { get; set; }
	}
}
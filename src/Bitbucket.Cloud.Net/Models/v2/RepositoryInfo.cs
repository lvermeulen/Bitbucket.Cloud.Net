using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class RepositoryInfo : HasUuid
	{
		public string Name { get; set; }

		[JsonProperty("full_name")]
		public string FullName { get; set; }

		public string Type { get; set; }
		public Links Links { get; set; }
	}
}
using System;
using Bitbucket.Cloud.Net.v2.Models;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.v2.Repositories.Models
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
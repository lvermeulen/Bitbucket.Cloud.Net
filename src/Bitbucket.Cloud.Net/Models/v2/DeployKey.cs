using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class DeployKey
	{
		public int Id { get; set; }
		public string Key { get; set; }
		public string Label { get; set; }
		public string Type { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public RepositoryInfo Repository { get; set; }
		public Links Links { get; set; }

		[JsonProperty("last_used")]
		public DateTime? LastUsed { get; set; }

		public string Comment { get; set; }
	}
}

using System;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class BuildResult
	{
		public string Key { get; set; }
		public string Description { get; set; }
		public RepositoryInfo Repository { get; set; }
		public string Url { get; set; }
		public Links Links { get; set; }
		public string RefName { get; set; }

		[JsonConverter(typeof(BuildResultStatesConverter))]
		public BuildResultStates State { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public CommitInfo Commit { get; set; }

		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }

		public string Type { get; set; }
		public string Name { get; set; }
	}
}

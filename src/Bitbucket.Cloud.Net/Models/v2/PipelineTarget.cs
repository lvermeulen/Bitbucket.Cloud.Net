using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PipelineTarget
	{
		public string Type { get; set; }

		[JsonProperty("ref_type")]
		public string RefType { get; set; }

		[JsonProperty("ref_name")]
		public string RefName { get; set; }

		public HasType Selector { get; set; }
		public CommitInfo Commit { get; set; }
	}
}
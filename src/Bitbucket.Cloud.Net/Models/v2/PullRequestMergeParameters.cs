using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PullRequestMergeParameters
	{
		public string Type { get; set; }
		public string Message { get; set; }

		[JsonProperty("close_source_branch")]
		public bool? CloseSourceBranch { get; set; }

		[JsonProperty("merge_strategy")]
		[JsonConverter(typeof(MergeStrategiesConverter))]
		public MergeStrategies MergeStrategy { get; set; }

	}
}

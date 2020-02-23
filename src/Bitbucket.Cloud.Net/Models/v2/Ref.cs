using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Ref
	{
		public string Name { get; set; }
		public Links Links { get; set; }

		[JsonProperty("default_merge_strategy")]
		public string DefaultMergeStrategy { get; set; }

		[JsonProperty("merge_strategies")]
		public IEnumerable<string> MergeStrategies { get; set; }

		public string Type { get; set; }
		public Target Target { get; set; }
	}
}

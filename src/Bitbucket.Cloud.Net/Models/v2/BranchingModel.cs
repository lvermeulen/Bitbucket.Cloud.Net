using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class BranchingModel
	{
		public BranchInfo Development { get; set; }
		public BranchInfo Production { get; set; }

		[JsonProperty("branch_types")]
		public IEnumerable<BranchTypeInfo> BranchTypes { get; set; }

		public string Type { get; set; }
		public Links Links { get; set; }
	}
}

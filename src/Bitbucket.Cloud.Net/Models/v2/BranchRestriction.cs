using System.Collections.Generic;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class BranchRestriction
	{
		[JsonConverter(typeof(BranchRestrictionKindsConverter))]
		public BranchRestrictionKinds Kind { get; set; }

		public IEnumerable<User> Users { get; set; }
		public Links Links { get; set; }
		public string Pattern { get; set; }
		public int? Value { get; set; }

		[JsonProperty("branch_match_kind")]
		[JsonConverter(typeof(BranchMatchKindsConverter))]
		public BranchMatchKinds BranchMatchKind { get; set; }

		public IEnumerable<Group> Groups { get; set; }

		[JsonProperty("branch_type")]
		[JsonConverter(typeof(BranchTypesConverter))]
		public BranchTypes BranchType { get; set; }

		public string Type { get; set; }
		public int Id { get; set; }
	}
}

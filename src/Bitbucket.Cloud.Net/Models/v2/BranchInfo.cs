using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class BranchInfo : HasName
	{
		public Branch Branch { get; set; }

		[JsonProperty("use_mainbranch")]
		public bool UseMainbranch { get; set; }

		[JsonProperty("is_valid")]
		public bool? IsValid { get; set; }

		public bool? Enabled { get; set; }
	}
}
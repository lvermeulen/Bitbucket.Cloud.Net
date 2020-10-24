using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PullRequestCreationParameters
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public HasBranch Source { get; set; }
		public HasBranch Destination { get; set; }
		public IEnumerable<HasUuid> Reviewers { get; set; }
		public bool? CloseSourceBranch { get; set; }
	}
}

using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Models
{
	public class PullRequestCreationParameters
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public HasName Source { get; set; }
		public HasName Destination { get; set; }
		public IEnumerable<HasUuid> Reviewers { get; set; }
		public bool? CloseSourceBranch { get; set; }
	}
}

using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public class PullRequestActivity
	{
		public PullRequestApproval Approval { get; set; }
		[JsonProperty("pull_request")]
		public PullRequestInfo PullRequest { get; set; }
		public PullRequestUpdate Update { get; set; }
	}
}

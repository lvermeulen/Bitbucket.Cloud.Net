using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PullRequestTaskStatus
	{
		[JsonProperty("task_status")]
		public string TaskStatus { get; set; }

		public Links Links { get; set; }
		public PullRequest PullRequest { get; set; }
	}
}

using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public class PullRequestTaskStatus
	{
		[JsonProperty("task_status")]
		public string TaskStatus { get; set; }
		public Links Links { get; set; }
		public PullRequest PullRequest { get; set; }
	}
}

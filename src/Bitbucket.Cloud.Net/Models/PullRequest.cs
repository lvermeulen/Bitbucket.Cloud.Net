using System;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public class PullRequest : PullRequestInfo
	{
		public string Description { get; set; }
		[JsonProperty("close_source_branch")]
		public bool CloseSourceBranch { get; set; }
		public FromToRef Destination { get; set; }
		[JsonProperty("created_on")]
		public DateTime CreatedOn { get; set; }
		public Message Summary { get; set; }
		public FromToRef Source { get; set; }
		[JsonProperty("comment_count")]
		public int CommentCount { get; set; }
		[JsonConverter(typeof(PullRequestStatesConverter))]
		public PullRequestStates State { get; set; }
		[JsonProperty("task_count")]
		public int TaskCount { get; set; }
		public string Reason { get; set; }
		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }
		public AccountInfo Author { get; set; }
		[JsonProperty("merge_commit")]
		public object MergeCommit { get; set; }
		[JsonProperty("")]
		public object ClosedBy { get; set; }
	}
}

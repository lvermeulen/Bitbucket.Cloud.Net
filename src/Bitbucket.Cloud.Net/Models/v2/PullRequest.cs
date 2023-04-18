using System;
using System.Collections.Generic;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
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

		[JsonProperty("closed_by")]
		public object ClosedBy { get; set; }

		/// <summary>
		/// The participants on the pull request. Anyone who's commented, approved, requested changes, etc.
		/// </summary>
		[JsonProperty("participants")]
		public IEnumerable<Participant> Participants { get; set; }

		/// <summary>
		/// Reviewers on the pull request. Technically, you can be a participant without being a reviewer, and the "Participant" record can have more information. 
		/// But to that point, the reviewers can also not hae participated in the PR yet.
		/// </summary>
		[JsonProperty("reviewers")]
		public IEnumerable<Participant> Reviewers { get; set; }
	}
}

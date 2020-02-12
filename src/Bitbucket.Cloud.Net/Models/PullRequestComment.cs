using System;

namespace Bitbucket.Cloud.Net.Models
{
	public class PullRequestComment
	{
		public Links Links { get; set; }
		public bool Deleted { get; set; }
		public PullRequestInfo PullRequest { get; set; }
		public Message Content { get; set; }
		public DateTime? CreatedOn { get; set; }
		public AccountInfo User { get; set; }
		public PullRequestInlineComment Inline { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public string Type { get; set; }
		public int Id { get; set; }
	}
}

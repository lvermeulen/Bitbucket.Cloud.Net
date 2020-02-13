namespace Bitbucket.Cloud.Net.Models
{
	public class PullRequestComment : Comment
	{
		public PullRequestInfo PullRequest { get; set; }
		public PullRequestInlineComment Inline { get; set; }
	}
}
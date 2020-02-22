namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PullRequestComment : Comment
	{
		public PullRequestInfo PullRequest { get; set; }
		public PullRequestInlineComment Inline { get; set; }
	}
}
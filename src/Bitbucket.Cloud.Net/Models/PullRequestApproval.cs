using System;

namespace Bitbucket.Cloud.Net.Models
{
	public class PullRequestApproval
	{
		public DateTime? Date { get; set; }
		public PullRequestInfo Pullrequest { get; set; }
		public AccountInfo User { get; set; }
	}
}
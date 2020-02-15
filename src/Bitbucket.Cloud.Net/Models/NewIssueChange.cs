using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Models
{
	public class NewIssueChange
	{
		public IEnumerable<Change> Changes { get; set; }
		public Message Message { get; set; }
	}
}
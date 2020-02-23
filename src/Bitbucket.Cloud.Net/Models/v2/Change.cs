using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Change
	{
		public ChangeItem Priority { get; set; }
		public ChangeItem Assignee { get; set; }

		[JsonProperty("assignee_account_id")]
		public ChangeItem AssigneeAccountId { get; set; }

		public ChangeItem Kind { get; set; }
		public ChangeItem State { get; set; }
	}
}

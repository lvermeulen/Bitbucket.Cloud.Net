using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class IssueComment
	{
		public OwnerLinks Links { get; set; }
		public IssueInfo Issue { get; set; }
		public Message Content { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public UserInfo User { get; set; }

		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }

		public string Type { get; set; }
		public int Id { get; set; }
	}
}

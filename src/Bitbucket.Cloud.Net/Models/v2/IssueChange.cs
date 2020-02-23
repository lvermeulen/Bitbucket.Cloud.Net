using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class IssueChange
	{
		public Change Changes { get; set; }
		public Links Links { get; set; }
		public IssueInfo Issue { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public UserInfo User { get; set; }
		public Message Message { get; set; }
		public string Type { get; set; }
		public int Id { get; set; }
	}
}

using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Issue : IssueInfo
	{
		public string Priority { get; set; }
		public string Kind { get; set; }
		public AccountInfo Reporter { get; set; }
		public object Component { get; set; }
		public int Votes { get; set; }
		public int Watches { get; set; }
		public Message Content { get; set; }
		public AccountInfo Assignee { get; set; }
		public string State { get; set; }
		public object Version { get; set; }

		[JsonProperty("edited_on")]
		public object EditedOn { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public object Milestone { get; set; }

		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }
	}
}

using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Comment
	{
		public Links Links { get; set; }
		public bool Deleted { get; set; }
		public Message Content { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public User User { get; set; }
		public CommitInfo Commit { get; set; }

		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }

		public string Type { get; set; }
		public int Id { get; set; }
	}
}

using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class SnippetComment
	{
		public SnippetInfo Snippet { get; set; }
		public Links Links { get; set; }
		public bool Deleted { get; set; }
		public Message Content { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public AccountInfo User { get; set; }

		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }

		public string Type { get; set; }
		public string Id { get; set; }
	}
}

using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Snippet : SnippetInfo
	{
		public string Title { get; set; }

		[JsonProperty("created_on")]
		public DateTime CreatedOn { get; set; }

		public UserInfo Owner { get; set; }

		[JsonProperty("updated_on")]
		public DateTime UpdatedOn { get; set; }

		[JsonProperty("is_private")]
		public bool IsPrivate { get; set; }
	}
}

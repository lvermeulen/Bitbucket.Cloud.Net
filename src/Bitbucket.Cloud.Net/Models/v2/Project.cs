using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Project
	{
		public string Type { get; set; }
		public OwnerLinks Links { get; set; }
		public Guid Uuid { get; set; }
		public string Key { get; set; }
		public User User { get; set; }
		public Team Team { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		[JsonProperty("is_private")]
		public bool IsPrivate { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }
	}
}

using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public class TeamInfo
	{
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }
		public Guid Uuid { get; set; }
	}
}

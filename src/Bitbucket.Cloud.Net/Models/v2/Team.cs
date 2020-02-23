using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Team : TeamInfo
	{
		public string UserName { get; set; }
		public Links Links { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		public string Type { get; set; }
		public Properties Properties { get; set; }

		[JsonProperty("has_2fa_enabled")]
		public object Has2FaEnabled { get; set; }
	}
}

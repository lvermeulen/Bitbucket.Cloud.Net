using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public class UserInfo
	{
		public string UserName { get; set; }
		public string NickName { get; set; }
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }
		public string Type { get; set; }
		public Guid Uuid { get; set; }
		public Links Links { get; set; }
	}
}
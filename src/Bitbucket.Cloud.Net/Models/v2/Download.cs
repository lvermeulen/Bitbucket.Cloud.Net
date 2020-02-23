using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Download
	{
		public string Name { get; set; }
		public Links Links { get; set; }
		public int Downloads { get; set; }

		[JsonProperty("created_on")]
		public DateTime CreatedOn { get; set; }

		public User User { get; set; }
		public string Type { get; set; }
		public int Size { get; set; }
	}

}

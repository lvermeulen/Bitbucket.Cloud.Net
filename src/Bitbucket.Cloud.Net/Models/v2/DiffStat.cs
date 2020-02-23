using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class DiffStat
	{
		public string Type { get; set; }

		public string Status { get; set; }

		[JsonProperty("lines_removed")]
		public int LinesRemoved { get; set; }

		[JsonProperty("lines_added")]
		public int LinesAdded { get; set; }

		public DiffStatVersion Old { get; set; }
		public DiffStatVersion New { get; set; }
	}
}

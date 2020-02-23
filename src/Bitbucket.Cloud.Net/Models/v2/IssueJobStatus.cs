using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class IssueJobStatus
	{
		public string Type { get; set; }

		[JsonConverter(typeof(IssueJobStatusConverter))]
		public IssueJobStatuses Status { get; set; }

		public string Phase { get; set; }
		public int Total { get; set; }
		public int Count { get; set; }
		public int Pct { get; set; }
	}
}

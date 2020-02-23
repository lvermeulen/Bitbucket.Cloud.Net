using System;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PullRequestUpdate
	{
		public string Description { get; set; }
		public string Title { get; set; }
		public FromToRef Destination { get; set; }
		public string Reason { get; set; }
		public FromToRef Source { get; set; }

		[JsonConverter(typeof(PullRequestStatesConverter))]
		public PullRequestStates State { get; set; }

		public AccountInfo Author { get; set; }
		public DateTime? Date { get; set; }
	}
}
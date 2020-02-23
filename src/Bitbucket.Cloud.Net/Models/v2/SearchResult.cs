using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class SearchResult
	{
		public string Type { get; set; }

		[JsonProperty("content_match_count")]
		public int ContentMatchCount { get; set; }

		[JsonProperty("content_matches")]
		public IEnumerable<ContentMatches> ContentMatches { get; set; }

		[JsonProperty("path_matches")]
		public IEnumerable<object> PathMatches { get; set; }

		public FileSearchResult File { get; set; }
	}
}
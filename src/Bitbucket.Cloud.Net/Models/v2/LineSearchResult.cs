using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class LineSearchResult
	{
		public int Line { get; set; }
		public IEnumerable<Segment> Segments { get; set; }
	}
}
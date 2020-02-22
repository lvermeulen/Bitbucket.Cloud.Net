using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class FileHistoryItem
	{
		public Links Links { get; set; }
		public CommitInfo Commit { get; set; }
		public IEnumerable<object> Attributes { get; set; }
		public string Path { get; set; }
		public string Type { get; set; }
		public int Size { get; set; }
	}
}

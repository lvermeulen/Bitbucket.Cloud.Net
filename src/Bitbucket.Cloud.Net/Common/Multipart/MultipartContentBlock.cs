using System.Collections.Generic;
using System.Linq;

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public class MultipartContentBlock
	{
		public IList<string> Lines { get; }

		public MultipartContentBlock(IEnumerable<string> lines)
		{
			Lines = lines.ToList();
		}
	}
}

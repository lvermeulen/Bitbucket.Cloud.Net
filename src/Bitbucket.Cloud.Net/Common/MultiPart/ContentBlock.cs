using System.Collections.Generic;
using System.Linq;

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public class ContentBlock
	{
		public IList<string> Lines { get; }

		public ContentBlock(IEnumerable<string> lines)
		{
			Lines = lines.ToList();
		}
	}
}

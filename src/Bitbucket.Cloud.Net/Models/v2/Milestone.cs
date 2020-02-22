using Bitbucket.Cloud.Net.Common;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Milestone
	{
		public string Type { get; set; }
		public OwnerLinks Links { get; set; }
		public string Name { get; set; }

		public string Id => Links?.Self?.Href.GetLastPathSegment();
	}
}

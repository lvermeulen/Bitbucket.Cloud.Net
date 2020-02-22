using Bitbucket.Cloud.Net.Common;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Version
	{
		public string Type { get; set; }
		public Links Links { get; set; }
		public string Name { get; set; }
		public RepositoryInfo Repository { get; set; }

		public string Id => Links?.Self?.Href.GetLastPathSegment();
	}
}

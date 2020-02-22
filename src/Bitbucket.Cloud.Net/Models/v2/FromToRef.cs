namespace Bitbucket.Cloud.Net.Models.v2
{
	public class FromToRef
	{
		public CommitInfo Commit { get; set; }
		public RepositoryInfo Repository { get; set; }
		public HasName Branch { get; set; }
	}
}
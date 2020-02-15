namespace Bitbucket.Cloud.Net.Models
{
	public class IssueInfo
	{
		public Links Links { get; set; }
		public string Type { get; set; }
		public int Id { get; set; }
		public RepositoryInfo Repository { get; set; }
		public string Title { get; set; }
	}
}
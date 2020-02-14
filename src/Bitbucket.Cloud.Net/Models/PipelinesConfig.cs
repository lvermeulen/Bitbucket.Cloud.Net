namespace Bitbucket.Cloud.Net.Models
{
	public class PipelinesConfig
	{
		public RepositoryInfo Repository { get; set; }
		public bool Enabled { get; set; }
		public string Type { get; set; }
	}
}

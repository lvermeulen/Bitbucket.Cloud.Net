namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PipelinesConfig
	{
		public RepositoryInfo Repository { get; set; }
		public bool Enabled { get; set; }
		public string Type { get; set; }
	}
}

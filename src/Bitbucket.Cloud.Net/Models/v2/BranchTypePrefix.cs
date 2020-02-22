namespace Bitbucket.Cloud.Net.Models.v2
{
	public class BranchTypeInfo
	{
		public BranchTypes Kind { get; set; }
		public string Prefix { get; set; }
		public bool? Enabled { get; set; }
	}
}
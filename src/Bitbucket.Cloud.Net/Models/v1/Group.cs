namespace Bitbucket.Cloud.Net.Models.v1
{
	public class Group
	{
		public Owner Owner { get; set; }
		public string Name { get; set; }
		public object[] Members { get; set; }
		public string Slug { get; set; }
	}
}
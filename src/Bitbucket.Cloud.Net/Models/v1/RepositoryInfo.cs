namespace Bitbucket.Cloud.Net.Models.v1
{
	public class RepositoryInfo<TOwnerType>
	{
		public TOwnerType Owner { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
	}
}
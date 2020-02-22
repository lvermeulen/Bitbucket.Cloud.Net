using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public class Group
	{
		public Person Owner { get; set; }
		public string Name { get; set; }
		public IEnumerable<User> Members { get; set; }
		public string Slug { get; set; }
	}
}
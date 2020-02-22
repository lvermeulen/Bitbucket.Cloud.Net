using System;
using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Target
	{
		public string Hash { get; set; }
		public RepositoryInfo Repository { get; set; }
		public Links Links { get; set; }
		public Author Author { get; set; }
		public IEnumerable<RefParent> Parents { get; set; }
		public DateTime Date { get; set; }
		public string Message { get; set; }
		public string Type { get; set; }
	}
}
using System;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Variable
	{
		public string Type { get; set; }
		public Guid Uuid { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }
		public bool Secured { get; set; }
	}
}

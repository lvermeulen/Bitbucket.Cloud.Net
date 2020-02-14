using System;

namespace Bitbucket.Cloud.Net.Models
{
	public class PipelineKnownHost
	{
		public string Type { get; set; }
		public Guid Uuid { get; set; }
		public string HostName { get; set; }
		public KnownHostKey Key { get; set; }
	}
}

using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PipelineSshKey
	{
		public string Type { get; set; }

		[JsonProperty("private_key")] 
		public string PrivateKey { get; set; }

		[JsonProperty("public_key")] 
		public string PublicKey { get; set; }
	}
}

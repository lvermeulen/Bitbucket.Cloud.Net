using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class KnownHostKey
	{
		public string Type { get; set; }

		[JsonProperty("key_type")] 
		public string KeyType { get; set; }

		public string Key { get; set; }

		[JsonProperty("md5_fingerprint")]
		public string Md5Fingerprint { get; set; }

		[JsonProperty("sha256_fingerprint")]
		public string Sha256Fingerprint { get; set; }
	}
}
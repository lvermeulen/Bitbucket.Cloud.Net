using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class BranchTypeInfo
	{
		[JsonConverter(typeof(BranchTypesConverter))]
		public BranchTypes Kind { get; set; }
		public string Prefix { get; set; }
		public bool? Enabled { get; set; }
	}
}
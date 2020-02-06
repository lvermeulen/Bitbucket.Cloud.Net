using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models
{
	public abstract class UserPermission
	{
		public string Type { get; set; }
		public User User { get; set; }
		[JsonConverter(typeof(PermissionsConverter))]
		public Permissions Permission { get; set; }
	}
}

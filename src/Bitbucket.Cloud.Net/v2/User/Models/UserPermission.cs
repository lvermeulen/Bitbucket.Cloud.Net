using Bitbucket.Cloud.Net.v2.Converters;
using Bitbucket.Cloud.Net.v2.Repositories.Models;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.v2.User.Models
{
	public abstract class UserPermission
	{
		public string Type { get; set; }
		public User User { get; set; }
		[JsonConverter(typeof(PermissionsConverter))]
		public Permissions Permission { get; set; }
	}
}

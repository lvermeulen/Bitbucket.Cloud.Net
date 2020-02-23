using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;
using Permissions = Bitbucket.Cloud.Net.Models.v2.Permissions;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public class GroupPrivilege
	{
		public string Repo { get; set; }

		[JsonConverter(typeof(PermissionsConverter))]
		public Permissions Privilege { get; set; }

		public Group Group { get; set; }
		public RepositoryInfo<string> Repository { get; set; }
	}
}
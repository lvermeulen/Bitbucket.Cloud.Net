using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Models.v2;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public class GroupPrivilege
	{
		public string Repo { get; set; }

		[JsonConverter(typeof(PermissionsConverter))]
		public Permissions Privilege { get; set; }

		public Group Group { get; set; }
		public RepositoryInfo Repository { get; set; }
	}
}
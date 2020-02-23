using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class TeamRepositoryPermission
	{
		public string Type { get; set; }
		public TeamUser User { get; set; }
		public RepositoryInfo Repository { get; set; }

		[JsonConverter(typeof(PermissionsConverter))]
		public Permissions Permission { get; set; }
	}
}

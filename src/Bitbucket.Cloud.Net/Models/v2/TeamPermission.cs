using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class TeamPermission
	{
		[JsonConverter(typeof(TeamPermissionsConverter))]
		public TeamPermissions Permission { get; set; }

		public string Type { get; set; }
		public TeamUser User { get; set; }
		public TeamInfo Team { get; set; }
	}
}

using Bitbucket.Cloud.Net.v2.Teams.Models;

namespace Bitbucket.Cloud.Net.v2.User.Models
{
	public class UserPermissionTeam : UserPermission
	{
		public TeamInfo Team { get; set; }
	}
}

using Bitbucket.Cloud.Net.v2.Repositories.Models;

namespace Bitbucket.Cloud.Net.v2.User.Models
{
	public class UserPermissionRepository : UserPermission
	{
		public RepositoryInfo Repository { get; set; }
	}
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Models.v1;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetGroupPrivilegesUrl() => GetBaseUrl("1.0/group-privileges");

		private IFlurlRequest GetGroupPrivilegesUrl(string path) => GetGroupPrivilegesUrl().AppendPathSegment(path);

		public async Task<IEnumerable<GroupPrivilege>> GetGroupPrivilegesAsync(string workspaceId, string repositorySlug = null, Permissions? permission = null, bool? isPrivate = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				["filter"] = PermissionsConverter.ToString(permission),
				["private"] = isPrivate
			};

			var url = GetGroupPrivilegesUrl(workspaceId);
			if (repositorySlug != null)
			{
				url = url.AppendPathSegment(repositorySlug);
			}

			return await url
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<IEnumerable<GroupPrivilege>>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<GroupPrivilege>> GetGroupPrivilegesAsync(string workspaceId, string repositorySlug, string groupOwner, string groupSlug)
		{
			return await GetGroupPrivilegesUrl(workspaceId)
				.AppendPathSegment(repositorySlug)
				.AppendPathSegment(groupOwner)
				.AppendPathSegment(groupSlug)
				.GetJsonAsync<IEnumerable<GroupPrivilege>>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<GroupPrivilege>> GetRepositoriesWithGroupPrivilegeAsync(string workspaceId, string groupOwner, string groupSlug)
		{
			return await GetGroupPrivilegesUrl(workspaceId)
				.AppendPathSegment(groupOwner)
				.AppendPathSegment(groupSlug)
				.GetJsonAsync<IEnumerable<GroupPrivilege>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> GrantGroupPrivilegeToRepositoryAsync(string workspaceId, string repositorySlug, string groupOwner, string groupSlug, Permissions permission)
		{
			var response = await GetGroupPrivilegesUrl(workspaceId)
				.AppendPathSegment(repositorySlug)
				.AppendPathSegment(groupOwner)
				.AppendPathSegment(groupSlug)
				.PutStringAsync(PermissionsConverter.ToString(permission))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveGroupPrivilegeFromRepositoryAsync(string workspaceId, string repositorySlug, string groupOwner, string groupSlug)
		{
			var response = await GetGroupPrivilegesUrl(workspaceId)
				.AppendPathSegment(repositorySlug)
				.AppendPathSegment(groupOwner)
				.AppendPathSegment(groupSlug)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveGroupPrivilegeAsync(string workspaceId, string groupOwner, string groupSlug)
		{
			var response = await GetGroupPrivilegesUrl(workspaceId)
				.AppendPathSegment(groupOwner)
				.AppendPathSegment(groupSlug)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Models.v1;
using Flurl.Http;
using Permissions = Bitbucket.Cloud.Net.Models.v2.Permissions;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetGroupsUrl() => GetBaseUrl("1.0/groups");

		private IFlurlRequest GetGroupsUrl(string path) => GetGroupsUrl().AppendPathSegment(path);

		public async Task<IEnumerable<Group>> GetMatchingGroupsAsync(params string[] filters)
		{
			var queryParamValues = new Dictionary<string, object>();
			foreach (string filter in filters)
			{
				queryParamValues.Add("group", filter);
			}

			return await GetGroupsUrl()
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<IEnumerable<Group>>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Group>> GetGroupsAsync(string workspaceId)
		{
			return await GetGroupsUrl()
				.AppendPathSegment(workspaceId)
				.GetJsonAsync<IEnumerable<Group>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> CreateGroupAsync(string workspaceId, string groupName)
		{
			var response = await GetGroupsUrl(workspaceId)
				.PostStringAsync($"name={groupName}")
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> UpdateGroupAsync(string workspaceId, string groupSlug, string groupName = null, Permissions? permission = null, bool? isAutoAdd = null)
		{
			var data = new
			{
				name = groupName,
				permission = PermissionsConverter.ToString(permission),
				auto_add = isAutoAdd
			};

			var response = await GetGroupsUrl(workspaceId)
				.WithHeader("Accept", "application/json")
				.AppendPathSegment(groupSlug)
				.PutJsonAsync(data)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteGroupAsync(string workspaceId, string groupSlug)
		{
			var response = await GetGroupsUrl(workspaceId)
				.AppendPathSegment(groupSlug)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<User>> GetGroupMembersAsync(string workspaceId, string groupSlug)
		{
			return await GetGroupsUrl(workspaceId)
				.AppendPathSegment(groupSlug)
				.AppendPathSegment("/members")
				.GetJsonAsync<IEnumerable<User>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> AddGroupMemberAsync(string workspaceId, string groupSlug, Guid memberUuid)
		{
			var response = await GetGroupsUrl(workspaceId)
				.WithHeader("Content-Type", "application/json")
				.AppendPathSegment(groupSlug)
				.AppendPathSegment("/members")
				.AppendPathSegment(memberUuid.ToString("B"))
				.PutStringAsync("")
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveGroupMemberAsync(string workspaceId, string groupSlug, Guid memberUuid)
		{
			var response = await GetGroupsUrl(workspaceId)
				.AppendPathSegment(groupSlug)
				.AppendPathSegment("/members")
				.AppendPathSegment(memberUuid.ToString("B"))
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

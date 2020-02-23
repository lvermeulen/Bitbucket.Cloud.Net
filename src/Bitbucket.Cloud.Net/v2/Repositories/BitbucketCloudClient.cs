using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetRepositoriesUrl() => GetBaseUrl("2.0/repositories");

		private IFlurlRequest GetRepositoriesUrl(string path) => GetRepositoriesUrl()
			.AppendPathSegment(path);

		public async Task<IEnumerable<Repository>> GetRepositoriesAsync(int? maxPages = null, DateTime? after = null, Roles? role = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(after)] = DateTimeConverter.ConvertToString(after),
				[nameof(role)] = RolesConverter.ConvertToString(role),
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetRepositoriesUrl()
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Repository>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Repository>> GetWorkspaceRepositoriesAsync(string workspaceId, int? maxPages = null, Roles? role = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(role)] = RolesConverter.ConvertToString(role),
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetRepositoriesUrl($"/{workspaceId}")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Repository>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Repository> CreateWorkspaceRepositoryAsync(string workspaceId, string repositorySlug, Repository repository)
		{
			var response = await GetRepositoriesUrl($"/{workspaceId}/{repositorySlug}")
				.PostJsonAsync(repository)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Repository>(response).ConfigureAwait(false);
		}

		public async Task<Repository> GetRepositoryAsync(string workspaceId, string repositorySlug)
		{
			return await GetRepositoriesUrl($"/{workspaceId}/{repositorySlug}")
				.GetJsonAsync<Repository>()
				.ConfigureAwait(false);
		}

		public async Task<Repository> UpdateRepositoryAsync(string workspaceId, string repositorySlug, Repository repository)
		{
			var response = await GetRepositoriesUrl($"/{workspaceId}/{repositorySlug}")
				.PutJsonAsync(repository)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Repository>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryAsync(string userName, string repositorySlug)
		{
			var response = await GetRepositoriesUrl($"/{userName}/{repositorySlug}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

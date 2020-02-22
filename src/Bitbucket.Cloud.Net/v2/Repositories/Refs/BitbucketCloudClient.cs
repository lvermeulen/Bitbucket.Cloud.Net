using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetRefsUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/refs");

		private IFlurlRequest GetRefsUrl(string workspaceId, string repositorySlug, string path) => GetRefsUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		private IFlurlRequest GetRefsBranchesUrl(string workspaceId, string repositorySlug) => GetRefsUrl(workspaceId, repositorySlug, "branches");

		private IFlurlRequest GetRefsTagsUrl(string workspaceId, string repositorySlug) => GetRefsUrl(workspaceId, repositorySlug, "tags");

		public async Task<IEnumerable<Ref>> GetRepositoryRefsAsync(string workspaceId, string repositorySlug, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetRefsUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Ref>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Ref> CreateRepositoryBranchAsync(string workspaceId, string repositorySlug, string branchName, string targetHash)
		{
			var data = new
			{
				name = branchName,
				target = new
				{
					hash = targetHash
				}
			};

			var response = await GetRefsBranchesUrl(workspaceId, repositorySlug)
				.PostJsonAsync(data)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Ref>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Ref>> GetRepositoryBranchesAsync(string workspaceId, string repositorySlug, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetRefsBranchesUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Ref>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Ref> CreateRepositoryTagAsync(string workspaceId, string repositorySlug, string branchName, string targetHash)
		{
			var data = new
			{
				name = branchName,
				target = new
				{
					hash = targetHash
				}
			};

			var response = await GetRefsTagsUrl(workspaceId, repositorySlug)
				.PostJsonAsync(data)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Ref>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Ref>> GetRepositoryTagsAsync(string workspaceId, string repositorySlug, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetRefsTagsUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Ref>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

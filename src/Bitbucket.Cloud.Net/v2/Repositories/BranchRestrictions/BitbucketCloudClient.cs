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
		private IFlurlRequest GetBranchRestrictionsUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/branch-restrictions");

		private IFlurlRequest GetBranchRestrictionsUrl(string workspaceId, string repositorySlug, string path) => GetBranchRestrictionsUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<BranchRestriction> CreateRepositoryBranchRestrictionAsync(string workspaceId, string repositorySlug, BranchRestriction branchRestriction)
		{
			var response = await GetBranchRestrictionsUrl(workspaceId, repositorySlug)
				.PostJsonAsync(branchRestriction)
				.ConfigureAwait(false);

			return await HandleResponseAsync<BranchRestriction>(response);
		}

		public async Task<IEnumerable<BranchRestriction>> GetRepositoryBranchRestrictionsAsync(string workspaceId, string repositorySlug, int? maxPages = null, string kind = null, string pattern = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(kind)] = kind,
				[nameof(pattern)] = pattern
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetBranchRestrictionsUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<BranchRestriction>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<BranchRestriction> UpdateRepositoryBranchRestrictionAsync(string workspaceId, string repositorySlug, string branchRestrictionId, BranchRestriction branchRestriction)
		{
			var response = await GetBranchRestrictionsUrl(workspaceId, repositorySlug, branchRestrictionId)
				.PutJsonAsync(branchRestriction)
				.ConfigureAwait(false);

			return await HandleResponseAsync<BranchRestriction>(response);
		}

		public async Task<BranchRestriction> GetRepositoryBranchRestrictionAsync(string workspaceId, string repositorySlug, string branchRestrictionId)
		{
			return await GetBranchRestrictionsUrl(workspaceId, repositorySlug, branchRestrictionId)
				.GetJsonAsync<BranchRestriction>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryBranchRestrictionAsync(string workspaceId, string repositorySlug, string branchRestrictionId)
		{
			var response = await GetBranchRestrictionsUrl(workspaceId, repositorySlug, branchRestrictionId)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response);
		}
	}
}

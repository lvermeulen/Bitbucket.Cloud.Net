using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetDefaultReviewersUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/default-reviewers");

		private IFlurlRequest GetDefaultReviewersUrl(string workspaceId, string repositorySlug, string path) => GetDefaultReviewersUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<IEnumerable<User>> GetRepositoryDefaultReviewersAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetDefaultReviewersUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<User>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<bool> AddRepositoryDefaultReviewerAsync(string workspaceId, string repositorySlug, string targetUserName)
		{
			var response = await GetDefaultReviewersUrl(workspaceId, repositorySlug, targetUserName)
				.PutJsonAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<User> GetRepositoryDefaultReviewerAsync(string workspaceId, string repositorySlug, string targetUserName)
		{
			return await GetDefaultReviewersUrl(workspaceId, repositorySlug, targetUserName)
				.GetJsonAsync<User>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryDefaultReviewerAsync(string workspaceId, string repositorySlug, string targetUserName)
		{
			var response = await GetDefaultReviewersUrl(workspaceId, repositorySlug, targetUserName)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

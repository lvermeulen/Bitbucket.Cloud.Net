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
		private IFlurlRequest GetForksUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/forks");

		public async Task<Fork> ForkRepositoryAsync(string workspaceId, string repositorySlug, Fork fork)
		{
			var response = await GetForksUrl(workspaceId, repositorySlug)
				.PostJsonAsync(fork)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Fork>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Fork>> GetRepositoryForksAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetForksUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Fork>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

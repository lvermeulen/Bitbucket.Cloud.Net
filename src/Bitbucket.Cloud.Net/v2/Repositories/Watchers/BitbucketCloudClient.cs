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
		private IFlurlRequest GetWatchersUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/watchers");

		public async Task<IEnumerable<User>> GetRepositoryWatchersAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			return await GetPagedResultsAsync(maxPages, GetWatchersUrl(workspaceId, repositorySlug), async req =>
					await req
						.GetJsonAsync<PagedResults<User>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

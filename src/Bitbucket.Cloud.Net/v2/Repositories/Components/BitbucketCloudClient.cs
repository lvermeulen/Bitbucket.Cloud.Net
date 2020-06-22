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
		private IFlurlRequest GetComponentsUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/components");

		public async Task<IEnumerable<Component>> GetRepositoryComponentsAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			return await GetPagedResultsAsync(maxPages, GetComponentsUrl(workspaceId, repositorySlug), async req =>
					await req
						.GetJsonAsync<PagedResults<Component>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Component> GetRepositoryComponentAsync(string workspaceId, string repositorySlug, string componentId)
		{
			return await GetComponentsUrl(workspaceId, repositorySlug)
				.AppendPathSegment($"{componentId}")
				.GetJsonAsync<Component>()
				.ConfigureAwait(false);
		}
	}
}

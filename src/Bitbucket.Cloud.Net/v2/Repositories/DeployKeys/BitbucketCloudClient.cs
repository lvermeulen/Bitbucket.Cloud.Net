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
		private IFlurlRequest GetDeployKeysUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/deploy-keys");

		private IFlurlRequest GetDeployKeysUrl(string workspaceId, string repositorySlug, string path) => GetDeployKeysUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<bool> CreateRepositoryDeployKeyAsync(string workspaceId, string repositorySlug, string key, string label)
		{
			var data = new
			{
				key,
				label
			};

			var response = await GetDeployKeysUrl(workspaceId, repositorySlug)
				.PostJsonAsync(data)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<DeployKey>> GetRepositoryDeployKeysAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetDeployKeysUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<DeployKey>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<bool> UpdateRepositoryDeployKeyAsync(string workspaceId, string repositorySlug, string keyId, string key, string label, string comment)
		{
			var data = new
			{
				key, 
				label, 
				comment
			};

			var response = await GetDeployKeysUrl(workspaceId, repositorySlug, keyId)
				.PutJsonAsync(data)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<DeployKey> GetRepositoryDeployKeyAsync(string workspaceId, string repositorySlug, string keyId)
		{
			return await GetDeployKeysUrl(workspaceId, repositorySlug, keyId)
				.GetJsonAsync<DeployKey>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryDeployKeyAsync(string workspaceId, string repositorySlug, string keyId)
		{
			var response = await GetDeployKeysUrl(workspaceId, repositorySlug, keyId)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

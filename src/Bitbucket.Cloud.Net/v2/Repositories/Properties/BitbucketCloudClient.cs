using System.Threading.Tasks;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetPropertiesUrl(string workspaceId, string repositorySlug, string appKey, string propertyName) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/properties/{appKey}/{propertyName}");

		public async Task<bool> UpdateRepositoryApplicationPropertyValueAsync(string workspaceId, string repositorySlug, string appKey, string propertyName, string propertyValue)
		{
			var response = await GetPropertiesUrl(workspaceId, repositorySlug, appKey, propertyName)
				.PutStringAsync(propertyValue)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryApplicationPropertyValueAsync(string workspaceId, string repositorySlug, string appKey, string propertyName)
		{
			return await GetPropertiesUrl(workspaceId, repositorySlug, appKey, propertyName)
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryApplicationPropertyValueAsync(string workspaceId, string repositorySlug, string appKey, string propertyName)
		{
			var response = await GetPropertiesUrl(workspaceId, repositorySlug, appKey, propertyName)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

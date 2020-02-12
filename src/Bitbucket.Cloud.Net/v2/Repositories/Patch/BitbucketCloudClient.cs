using System.Threading.Tasks;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetPatchUrl(string workspaceId, string repositorySlug, string spec) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/patch/{spec}");

		public async Task<string> GetRepositoryPatchAsync(string workspaceId, string repositorySlug, string spec)
		{
			return await GetPatchUrl(workspaceId, repositorySlug, spec)
				.GetStringAsync()
				.ConfigureAwait(false);
		}
	}
}

using System.Threading.Tasks;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetDiffUrl(string workspaceId, string repositorySlug, string spec) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/diff/{spec}");

		public async Task<string> GetRepositoryDiffAsync(string workspaceId, string repositorySlug, string spec)
		{
			return await GetDiffUrl(workspaceId, repositorySlug, spec)
				.GetStringAsync()
				.ConfigureAwait(false);
		}
	}
}

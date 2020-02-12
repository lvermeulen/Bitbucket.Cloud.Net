using System.Threading.Tasks;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetDiffUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/diff");

		public async Task<string> GetRepositoryDiffAsync(string workspaceId, string repositorySlug, string spec)
		{
			return await GetDiffUrl(workspaceId, repositorySlug)
				.AppendPathSegment($"/{spec}")
				.GetStringAsync()
				.ConfigureAwait(false);
		}
	}
}

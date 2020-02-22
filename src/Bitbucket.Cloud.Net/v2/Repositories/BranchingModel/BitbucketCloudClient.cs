using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetBranchingModelUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/branching-model");

		public async Task<BranchingModel> GetRepositoryBranchingModelAsync(string workspaceId, string repositorySlug)
		{
			return await GetBranchingModelUrl(workspaceId, repositorySlug)
				.GetJsonAsync<BranchingModel>()
				.ConfigureAwait(false);
		}

		public async Task<string> UpdateRepositoryBranchingModelSettingsAsync(string workspaceId, string repositorySlug, BranchingModel branchingModel)
		{
			var response = await GetBranchingModelUrl(workspaceId, repositorySlug)
				.AppendPathSegment("/settings")
				.PutJsonAsync(branchingModel)
				.ConfigureAwait(false);

			return await HandleResponseAsync<string>(response);
		}

		public async Task<BranchingModel> GetRepositoryBranchingModelSettingsAsync(string workspaceId, string repositorySlug)
		{
			return await GetBranchingModelUrl(workspaceId, repositorySlug)
				.AppendPathSegment("/settings")
				.GetJsonAsync<BranchingModel>()
				.ConfigureAwait(false);
		}
	}
}

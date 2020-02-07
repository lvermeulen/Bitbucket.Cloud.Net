using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryBranchingModelAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryBranchingModelAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryBranchingModelSettingsAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryBranchingModelSettingsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

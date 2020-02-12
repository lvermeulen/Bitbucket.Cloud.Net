using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryRefsAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryRefsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryBranchesAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryBranchesAsync(workspaceId, repositorySlug);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryTagsAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryTagsAsync(workspaceId, repositorySlug);
			Assert.NotNull(result);
		}
	}
}

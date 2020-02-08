using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryDefaultReviewersAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryDefaultReviewersAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test", "luve")]
		public async Task GetRepositoryDefaultReviewerAsync(string workspaceId, string repositorySlug, string targetUserName)
		{
			var result = await _client.GetRepositoryDefaultReviewerAsync(workspaceId, repositorySlug, targetUserName).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

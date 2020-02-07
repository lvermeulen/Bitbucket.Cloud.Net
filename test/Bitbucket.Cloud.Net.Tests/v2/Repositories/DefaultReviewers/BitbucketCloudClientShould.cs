using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test")]
		public async Task GetDefaultReviewersAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetDefaultReviewersAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test", "luve")]
		public async Task GetDefaultReviewerAsync(string workspaceId, string repositorySlug, string targetUserName)
		{
			var result = await _client.GetDefaultReviewerAsync(workspaceId, repositorySlug, targetUserName).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

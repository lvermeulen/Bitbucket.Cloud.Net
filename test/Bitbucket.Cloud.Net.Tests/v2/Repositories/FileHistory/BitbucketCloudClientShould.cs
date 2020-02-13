using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test", "development", "something.txt")]
		public async Task GetRepositoryFileHistoryAsync(string workspaceId, string repositorySlug, string node, string path)
		{
			var result = await _client.GetRepositoryFileHistoryAsync(workspaceId, repositorySlug, node, path).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

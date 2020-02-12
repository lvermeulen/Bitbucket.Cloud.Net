using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositorySourceAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositorySourceAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

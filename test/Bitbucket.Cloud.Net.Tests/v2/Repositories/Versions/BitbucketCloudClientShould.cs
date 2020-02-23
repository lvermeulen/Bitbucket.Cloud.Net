using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryVersionsAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryVersionsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryVersionAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryVersionsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryVersionAsync(workspaceId, repositorySlug, firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

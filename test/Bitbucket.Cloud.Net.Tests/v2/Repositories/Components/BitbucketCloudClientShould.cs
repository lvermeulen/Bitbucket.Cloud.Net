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
		public async Task GetRepositoryComponentsAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryComponentsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryComponentAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryComponentsAsync(workspaceId, repositorySlug);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryComponentAsync(workspaceId, repositorySlug, firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

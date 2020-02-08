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
		public async Task GetRepositoryDeployKeysAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryDeployKeysAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryDeployKeyAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryDeployKeysAsync(workspaceId, repositorySlug);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryDeployKeyAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

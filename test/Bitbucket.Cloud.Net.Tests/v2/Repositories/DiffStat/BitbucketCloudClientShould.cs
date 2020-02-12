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
		public async Task GetRepositoryDiffStatAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryCommitsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryDiffStatAsync(workspaceId, repositorySlug, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

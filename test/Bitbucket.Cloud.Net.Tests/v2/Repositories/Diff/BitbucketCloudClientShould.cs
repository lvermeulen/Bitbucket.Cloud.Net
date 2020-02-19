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
		public async Task GetRepositoryDiffAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryCommitsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			string result = await _client.GetRepositoryDiffAsync(workspaceId, repositorySlug, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

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
		public async Task GetRepositoryBranchRestrictionsAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryBranchRestrictionsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryBranchRestrictionAsync(string workspaceId, string repositorySlug)
		{
			var branchRestrictions = await _client.GetRepositoryBranchRestrictionsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var branchRestriction = branchRestrictions.FirstOrDefault();
			var result = await _client.GetRepositoryBranchRestrictionAsync(workspaceId, repositorySlug, branchRestriction?.Id.ToString());
			Assert.NotNull(result);
		}
	}
}

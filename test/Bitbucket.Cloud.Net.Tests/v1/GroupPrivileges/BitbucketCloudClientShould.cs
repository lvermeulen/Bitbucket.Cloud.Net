using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve")]
		public async Task GetGroupPrivilegesForWorkspaceAsync(string workspaceId)
		{
			var result = await _client.GetGroupPrivilegesAsync(workspaceId).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetGroupPrivilegesForRepositoryAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetGroupPrivilegesAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetGroupPrivilegesForGroupAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetGroupPrivilegesAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetGroupPrivilegesAsync(workspaceId, repositorySlug, firstResult.Group.Owner.Uuid.ToString("B"), firstResult.Group.Slug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoriesWithGroupPrivilegeAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetGroupPrivilegesAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoriesWithGroupPrivilegeAsync(workspaceId, firstResult.Group.Owner.Uuid.ToString("B"), firstResult.Group.Slug).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test-group")]
		public async Task GetMatchingGroupsAsync(string groupOwner, string groupSlug)
		{
			var result = await _client.GetMatchingGroupsAsync($"{groupOwner}/{groupSlug}").ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetGroupsAsync(string workspaceId)
		{
			var result = await _client.GetGroupsAsync(workspaceId).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test-group")]
		public async Task GetGroupMembersAsync(string workspaceId, string groupSlug)
		{
			var result = await _client.GetGroupMembersAsync(workspaceId, groupSlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Models.v2;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Fact]
		public async Task GetHookEventsAsync()
		{
			var result = await _client.GetHookEventsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData(HookEventSubjectTypes.Workspace)]
		[InlineData(HookEventSubjectTypes.User)]
		[InlineData(HookEventSubjectTypes.Repository)]
		[InlineData(HookEventSubjectTypes.Team)]
		public async Task GetHookEventsAsyncForSubjectType(HookEventSubjectTypes hookEventSubjectType)
		{
			var result = await _client.GetHookEventsAsync(hookEventSubjectType).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

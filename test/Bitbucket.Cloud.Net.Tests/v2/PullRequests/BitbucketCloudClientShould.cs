using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
    public partial class BitbucketCloudClientShould
    {
        [Theory]
        [InlineData("luve")]
        public async Task GetPullRequestsAsync(string userName)
        {
            var result = await _client.GetPullRequestsAsync(userName).ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}

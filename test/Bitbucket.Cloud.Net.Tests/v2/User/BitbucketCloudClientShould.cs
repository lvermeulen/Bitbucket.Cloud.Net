using System.Threading.Tasks;
using Xunit;

namespace Bitbucket.Cloud.Net.Tests
{
    public partial class BitbucketCloudClientShould
    {
        [Fact]
        public async Task GetUserAsync()
        {
            var result = await _client.GetUserAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserEmailsAsync()
        {
            var result = await _client.GetUserEmailsAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("luk.vermeulen@gmail.com")]
        public async Task GetUserEmailAsync(string email)
        {
            var result = await _client.GetUserEmailAsync(email).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserPermissionsForRepositoriesAsync()
        {
            var result = await _client.GetUserPermissionsForRepositoriesAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserPermissionsForTeamsAsync()
        {
            var result = await _client.GetUserPermissionsForTeamsAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}

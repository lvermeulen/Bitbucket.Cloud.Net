using System;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
    public partial class BitbucketCloudClientShould
    {
        [Fact]
        public async Task GetRepositoriesAsync()
        {
            var result = await _client.GetRepositoriesAsync(1, DateTime.Now.AddYears(-1)).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("luve", "test")]
        public async Task GetRepositoryAsync(string userName, string repositorySlug)
        {
            var result = await _client.GetRepositoryAsync(userName, repositorySlug).ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}

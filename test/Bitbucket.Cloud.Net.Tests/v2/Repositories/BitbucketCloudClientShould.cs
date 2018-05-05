using System;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.v2.Repositories;
using Xunit;

namespace Bitbucket.Cloud.Net.Tests.v2.Repositories
{
    public class BitbucketCloudClientShould : Tests.BitbucketCloudClientShould
    {
        [Fact]
        public async Task GetRepositoriesAsync()
        {
            var result = await Client.GetRepositoriesAsync(1, DateTime.Now.AddYears(-1)).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("tobaniaeps", "descenumgenerator")]
        public async Task GetRepositoryAsync(string userName, string repositorySlug)
        {
            var result = await Client.GetRepositoryAsync(userName, repositorySlug).ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}

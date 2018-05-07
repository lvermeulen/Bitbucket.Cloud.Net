using System.Threading.Tasks;
using Bitbucket.Cloud.Net.v1.Repositories;
using Xunit;

namespace Bitbucket.Cloud.Net.Tests.v1.Repositories
{
    public class BitbucketCloudClientShould : Tests.BitbucketCloudClientShould
    {
        [Theory]
        [InlineData("tobaniaeps", "DescEnumGenerator")]
        public async Task GetRepositoryAsync(string accountName, string repositorySlug)
        {
            var result = await Client.GetRepositoryAsync(accountName, repositorySlug);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("tobaniaeps", "DescEnumGenerator")]
        public async Task GetRepositoryBranchesAsync(string accountName, string repositorySlug)
        {
            var result = await Client.GetRepositoryBranchesAsync(accountName, repositorySlug);
            Assert.NotNull(result);
        }
    }
}

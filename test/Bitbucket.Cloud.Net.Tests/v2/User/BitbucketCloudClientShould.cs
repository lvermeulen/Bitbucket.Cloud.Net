using System.Threading.Tasks;
using Bitbucket.Cloud.Net.v2.User;
using Xunit;

namespace Bitbucket.Cloud.Net.Tests.v2.User
{
    public class BitbucketCloudClientShould : Tests.BitbucketCloudClientShould
    {
        [Fact]
        public async Task GetUserAsync()
        {
            var result = await Client.GetUserAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}

using System.IO;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Auth;
using Bitbucket.Cloud.Net.v2.Repositories;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Bitbucket.Cloud.Net.OAuth.Tests
{
    public class BitbucketCloudClientShould
    {
        protected readonly BitbucketCloudClient Client;

        public BitbucketCloudClientShould()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Client = new BitbucketCloudClient(configuration["url"], new OAuthAuthentication { ConsumerKey = configuration["consumerKey"], ConsumerSecret = configuration["consumerSecret"] });
        }

        [Theory]
        [InlineData("tobaniaeps", "DescEnumGenerator")]
        public async Task UseOAuthAsync(string userName, string repositorySlug)
        {
            var result = await Client.GetRepositoryAsync(userName, repositorySlug).ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}

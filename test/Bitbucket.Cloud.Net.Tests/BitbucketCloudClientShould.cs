using System.IO;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Authentication;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Bitbucket.Cloud.Net.Tests
{
    public partial class BitbucketCloudClientShould
    {
        private readonly IConfigurationRoot _configuration;
        private readonly BitbucketCloudClient _client;

        public BitbucketCloudClientShould()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _client = new BitbucketCloudClient(_configuration["url"], new BasicAuthentication(_configuration["username"], _configuration["password"]));
        }

        [Fact]
        public async Task AuthenticateWithAppPassword()
        {
            var client = new BitbucketCloudClient(_configuration["url"], new AppPasswordAuthentication(_configuration["username"], _configuration["appPassword"]));
            var results = await client.GetRepositoriesAsync(1).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }
    }
}

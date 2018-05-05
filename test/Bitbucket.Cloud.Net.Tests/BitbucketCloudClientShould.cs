using System.IO;
using Microsoft.Extensions.Configuration;

namespace Bitbucket.Cloud.Net.Tests
{
    public class BitbucketCloudClientShould
    {
        protected readonly BitbucketCloudClient Client;

        protected BitbucketCloudClientShould()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Client = new BitbucketCloudClient(configuration["url"], configuration["username"], configuration["password"]);
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Bitbucket.Cloud.Net.Tests
{
    public class BitbucketCloudClientShould
    {
        private readonly BitbucketCloudClient _client;

        public BitbucketCloudClientShould()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _client = new BitbucketCloudClient(configuration["url"], configuration["username"], configuration["password"]);
        }
    }
}

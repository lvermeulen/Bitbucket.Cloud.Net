using System.Threading.Tasks;
using Bitbucket.Cloud.Net.v1.Repositories.Models;
using Flurl.Http;

namespace Bitbucket.Cloud.Net.v1.Repositories
{
    public static class BitbucketCloudClientExtensions
    {
        private static IFlurlRequest GetRepositoriesUrl(this BitbucketCloudClient client, string accountName, string repositorySlug)
        {
            return client.GetBaseUrl($"1.0/repositories/{accountName}/{repositorySlug}");
        }

        public static async Task<Repository> GetRepositoryAsync(this BitbucketCloudClient client, string accountName, string repositorySlug)
        {
            return await client.GetRepositoriesUrl(accountName, repositorySlug)
                .GetJsonAsync<Repository>();
        }
    }
}

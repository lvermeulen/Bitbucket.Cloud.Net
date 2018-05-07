using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.v1.Repositories.Models;
using Flurl.Http;

namespace Bitbucket.Cloud.Net.v1.Repositories
{
    public static class BitbucketCloudClientExtensions
    {
        private static IFlurlRequest GetRepositoriesUrl(this BitbucketCloudClient client, string accountName, string repositorySlug) =>
            client.GetBaseUrl($"1.0/repositories/{accountName}/{repositorySlug}");

        private static IFlurlRequest GetRepositoriesUrl(this BitbucketCloudClient client, string accountName, string repositorySlug, string path) =>
            client.GetRepositoriesUrl(accountName, repositorySlug)
                .AppendPathSegment(path);

        public static async Task<Repository> GetRepositoryAsync(this BitbucketCloudClient client, string accountName, string repositorySlug)
        {
            return await client.GetRepositoriesUrl(accountName, repositorySlug)
                .GetJsonAsync<Repository>()
                .ConfigureAwait(false);
        }

        public static async Task<Dictionary<string, BranchObject>> GetRepositoryBranchesAsync(this BitbucketCloudClient client, string accountName, string repositorySlug)
        {
            return await client.GetRepositoriesUrl(accountName, repositorySlug, "/branches")
                .GetJsonAsync<Dictionary<string, BranchObject>>()
                .ConfigureAwait(false);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common;
using Bitbucket.Cloud.Net.Common.Converters;
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

        public static async Task<Repository> ForkRepositoryAsync(this BitbucketCloudClient client, string accountName, string repositorySlug,
            string name, string description = null, string language = null, bool? isPrivate = false)
        {
            var data = new Dictionary<string, object>
            {
                ["name"] = name,
                ["description"] = description,
                ["language"] = language,
                ["is_private"] = BoolConverter.ConvertToString(isPrivate)
            };

            var response = await client.GetRepositoriesUrl(accountName, repositorySlug, "/fork")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await BitbucketCloudHelper.HandleResponseAsync<Repository>(response).ConfigureAwait(false);
        }

        public static async Task<Repository> UpdateRepositoryAsync(this BitbucketCloudClient client, string accountName, string repositorySlug,
            string name, string description = null, string language = null, bool? isPrivate = false, string landingPage = null,
            string website = null, string mainBranch = null, string analyticsKey = null, string akismetKey = null)
        {
            var data = new Dictionary<string, object>
            {
                ["name"] = name,
                ["description"] = description,
                ["language"] = language,
                ["is_private"] = BoolConverter.ConvertToString(isPrivate),
                ["landing_page"] = landingPage,
                ["website"] = website,
                ["main_branch"] = mainBranch,
                ["analytics_key"] = analyticsKey,
                ["akismet_key"] = akismetKey
            };

            var response = await client.GetRepositoriesUrl(accountName, repositorySlug)
                .PutJsonAsync(data)
                .ConfigureAwait(false);

            return await BitbucketCloudHelper.HandleResponseAsync<Repository>(response).ConfigureAwait(false);
        }

        public static async Task<Dictionary<string, BranchObject>> GetRepositoryBranchesAsync(this BitbucketCloudClient client, string accountName, string repositorySlug)
        {
            return await client.GetRepositoriesUrl(accountName, repositorySlug, "/branches")
                .GetJsonAsync<Dictionary<string, BranchObject>>()
                .ConfigureAwait(false);
        }

        public static async Task<BranchName> GetRepositoryMainBranchAsync(this BitbucketCloudClient client, string accountName, string repositorySlug)
        {
            return await client.GetRepositoriesUrl(accountName, repositorySlug, "/main-branch")
                .GetJsonAsync<BranchName>()
                .ConfigureAwait(false);
        }
    }
}

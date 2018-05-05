using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Common.Models.v2;
using Bitbucket.Cloud.Net.v2.Repositories.Models;
using Flurl.Http;

namespace Bitbucket.Cloud.Net.v2.Repositories
{
    public static class BitbucketCloudClientExtensions
    {
        private static IFlurlRequest GetRepositoriesUrl(this BitbucketCloudClient client) => client.GetBaseUrl("2.0/repositories");

        private static IFlurlRequest GetRepositoriesUrl(this BitbucketCloudClient client, string path) => client.GetRepositoriesUrl()
            .AppendPathSegment(path);

        //[Scope: repository]
        public static async Task<IEnumerable<Repository>> GetRepositoriesAsync(this BitbucketCloudClient client, int? maxPages = null, DateTime? after = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["after"] = DateTimeConverter.ConvertToString(after)
            };

            return await BitbucketCloudHelper.GetPagedResultsV2Async(maxPages, queryParamValues, async qpv =>
                    await client.GetRepositoriesUrl()
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResultsV2<Repository>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        //[Scope: repository]
        public static async Task<Repository> GetRepositoryAsync(this BitbucketCloudClient client, string userName, string repositorySlug)
        {
            return await client.GetRepositoriesUrl($"/{userName}/{repositorySlug}")
                .GetJsonAsync<Repository>()
                .ConfigureAwait(false);
        }

        //[Scope: repository:admin]
        public static async Task<Repository> CreateRepositoryAsync(this BitbucketCloudClient client, string userName, string repositorySlug,
            Repository repository)
        {
            var response = await client.GetRepositoriesUrl($"/{userName}/{repositorySlug}")
                .PostJsonAsync(repository)
                .ConfigureAwait(false);

            return await BitbucketCloudHelper.HandleResponseAsync<Repository>(response).ConfigureAwait(false);
        }

        //[Scope: repository:admin]
        public static async Task<Repository> UpdateRepositoryAsync(this BitbucketCloudClient client, string userName, string repositorySlug,
            Repository repository)
        {
            var response = await client.GetRepositoriesUrl($"/{userName}/{repositorySlug}")
                .PutJsonAsync(repository)
                .ConfigureAwait(false);

            return await BitbucketCloudHelper.HandleResponseAsync<Repository>(response).ConfigureAwait(false);
        }

        //[Scope: repository:delete]
        public static async Task<bool> DeleteRepositoryAsync(this BitbucketCloudClient client, string userName, string repositorySlug)
        {
            var response = await client.GetRepositoriesUrl($"/{userName}/{repositorySlug}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return await BitbucketCloudHelper.HandleResponseAsync(response).ConfigureAwait(false);
        }
    }
}

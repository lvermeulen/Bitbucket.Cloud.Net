using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
    public partial class BitbucketCloudClient
    {
        private IFlurlRequest GetRepositoriesUrl() => GetBaseUrl("2.0/repositories");

        private IFlurlRequest GetRepositoriesUrl(string path) => GetRepositoriesUrl()
            .AppendPathSegment(path);

        public async Task<IEnumerable<Repository>> GetRepositoriesAsync(int? maxPages = null, DateTime? after = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["after"] = DateTimeConverter.ConvertToString(after)
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetRepositoriesUrl()
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<Repository>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<Repository> GetRepositoryAsync(string userName, string repositorySlug)
        {
            return await GetRepositoriesUrl($"/{userName}/{repositorySlug}")
                .GetJsonAsync<Repository>()
                .ConfigureAwait(false);
        }

        public async Task<Repository> CreateRepositoryAsync(string userName, string repositorySlug,
            Repository repository)
        {
            var response = await GetRepositoriesUrl($"/{userName}/{repositorySlug}")
                .PostJsonAsync(repository)
                .ConfigureAwait(false);

            return await HandleResponseAsync<Repository>(response).ConfigureAwait(false);
        }

        public async Task<Repository> UpdateRepositoryAsync(string userName, string repositorySlug,
            Repository repository)
        {
            var response = await GetRepositoriesUrl($"/{userName}/{repositorySlug}")
                .PutJsonAsync(repository)
                .ConfigureAwait(false);

            return await HandleResponseAsync<Repository>(response).ConfigureAwait(false);
        }

        public async Task<bool> DeleteRepositoryAsync(string userName, string repositorySlug)
        {
            var response = await GetRepositoriesUrl($"/{userName}/{repositorySlug}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return await HandleResponseAsync(response).ConfigureAwait(false);
        }
    }
}

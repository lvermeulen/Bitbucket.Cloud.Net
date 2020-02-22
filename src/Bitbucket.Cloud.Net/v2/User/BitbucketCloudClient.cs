using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
    public partial class BitbucketCloudClient
    {
        private IFlurlRequest GetUserUrl() => GetBaseUrl("2.0/user");

        public async Task<User> GetUserAsync()
        {
            return await GetUserUrl()
                .GetJsonAsync<User>()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserEmail>> GetUserEmailsAsync(int? maxPages = null)
        {
            var queryParamValues = new Dictionary<string, object>();

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetUserUrl()
                        .AppendPathSegment("/emails")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<UserEmail>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<UserEmail> GetUserEmailAsync(string email)
        {
            return await GetUserUrl()
                .AppendPathSegment($"/emails/{email}")
                .GetJsonAsync<UserEmail>()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserPermissionRepository>> GetUserPermissionsForRepositoriesAsync(int? maxPages = null)
        {
            var queryParamValues = new Dictionary<string, object>();

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetUserUrl()
                        .AppendPathSegment("/permissions/repositories")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<UserPermissionRepository>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserPermissionTeam>> GetUserPermissionsForTeamsAsync(int? maxPages = null)
        {
            var queryParamValues = new Dictionary<string, object>();

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetUserUrl()
                        .AppendPathSegment("/permissions/teams")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<UserPermissionTeam>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }
    }
}

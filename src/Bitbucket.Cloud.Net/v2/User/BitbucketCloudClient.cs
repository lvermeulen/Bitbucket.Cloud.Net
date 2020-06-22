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
            return await GetPagedResultsAsync(maxPages, 
                         GetUserUrl()
                        .AppendPathSegment("/emails"), async req =>
                    await req
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
            return await GetPagedResultsAsync(maxPages,
                         GetUserUrl()
                        .AppendPathSegment("/permissions/repositories"), async req =>
                    await req
                        .GetJsonAsync<PagedResults<UserPermissionRepository>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserPermissionTeam>> GetUserPermissionsForTeamsAsync(int? maxPages = null)
        {
            return await GetPagedResultsAsync(maxPages,
                         GetUserUrl()
                        .AppendPathSegment("/permissions/teams"), async req =>
                    await req
                        .GetJsonAsync<PagedResults<UserPermissionTeam>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }
    }
}

using System.Threading.Tasks;
using Flurl.Http;

namespace Bitbucket.Cloud.Net.v2.User
{
    public static class BitbucketCloudClientExtensions
    {
        private static IFlurlRequest GetUserUrl(this BitbucketCloudClient client) => client.GetBaseUrl("2.0/user");

        //[Scope: account]
        public static async Task<Models.User> GetUserAsync(this BitbucketCloudClient client)
        {
            return await client.GetUserUrl()
                .GetJsonAsync<Models.User>()
                .ConfigureAwait(false);
        }
    }
}

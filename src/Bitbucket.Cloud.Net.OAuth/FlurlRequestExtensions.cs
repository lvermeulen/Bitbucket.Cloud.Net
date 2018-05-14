using System.Threading.Tasks;
using Flurl.Http;
using IdentityModel.Client;

namespace Bitbucket.Cloud.Net.OAuth
{
    public static class FlurlRequestExtensions
    {
        private static async Task<string> AuthorizeAsync(string consumerKey, string consumerSecret)
        {
            var client = new TokenClient("https://bitbucket.org/site/oauth2/authorize", consumerKey, consumerSecret, style: AuthenticationStyle.PostValues);
            var response = await client.RequestClientCredentialsAsync("repository:admin");

            return response.Json.ToString();
        }

        public static IFlurlRequest WithOAuth(this IFlurlRequest request, string consumerKey, string consumerSecret)
        {
            string accessToken = AuthorizeAsync(consumerKey, consumerSecret)
                .GetAwaiter()
                .GetResult();
            return request.WithOAuthBearerToken(accessToken);
        }
    }
}

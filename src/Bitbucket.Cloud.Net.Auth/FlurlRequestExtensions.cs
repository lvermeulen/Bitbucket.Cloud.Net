using System;
using Bitbucket.Cloud.Net.OAuth;
using Flurl.Http;

namespace Bitbucket.Cloud.Net.Auth
{
    public static class FlurlRequestExtensions
    {
        public static IFlurlRequest WithAuthentication(this IFlurlRequest request, Authentication auth)
        {
            if (auth is BasicAuthentication basicAuth)
            {
                return request.WithBasicAuth(basicAuth.UserName, basicAuth.Password);
            }

            if (auth is OAuthAuthentication oauth)
            {
                return request.WithOAuth(oauth.ConsumerKey, oauth.ConsumerSecret);
            }

            throw new InvalidOperationException("Unknown authentication method");
        }
    }
}

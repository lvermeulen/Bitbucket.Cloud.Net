using System;
using Flurl.Http;

namespace Bitbucket.Cloud.Net.Common
{
    public static class FlurlRequestExtensions
    {
        public static IFlurlRequest WithAuthentication(this IFlurlRequest request, Authentication auth)
        {
            if (!string.IsNullOrEmpty(auth.UserName) && !string.IsNullOrEmpty(auth.Password))
            {
                return request.WithBasicAuth(auth.UserName, auth.Password);
            }

            throw new InvalidOperationException("Unknown authentication method");
        }
    }
}

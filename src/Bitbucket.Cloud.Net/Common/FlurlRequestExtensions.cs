using System;
using Bitbucket.Cloud.Net.Common.Authentication;
using Flurl.Http;

namespace Bitbucket.Cloud.Net.Common
{
	public static class FlurlRequestExtensions
	{
		public static IFlurlRequest WithAuthentication(this IFlurlRequest request, AuthenticationMethod auth)
		{
			if (auth.GetType() == typeof(BasicAuthentication))
			{
				var basic = (BasicAuthentication)auth;
				return request.WithBasicAuth(basic.UserName, basic.Password);
			}

			if (auth.GetType() == typeof(AppPasswordAuthentication))
			{
				var appPassword = (AppPasswordAuthentication)auth;
				return request.WithBasicAuth(appPassword.UserName, appPassword.AppPassword);
			}

			if (auth.GetType() == typeof(OAuthAuthentication))
			{
				var oauth = (OAuthAuthentication)auth;
				return request.WithOAuthBearerToken(oauth.Token);
			}

			throw new InvalidOperationException("Unknown authentication method");
		}
	}
}

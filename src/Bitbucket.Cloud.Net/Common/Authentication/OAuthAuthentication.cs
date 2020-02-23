namespace Bitbucket.Cloud.Net.Common.Authentication
{
	public class OAuthAuthentication : AuthenticationMethod
	{
		public string Token { get; }

		public OAuthAuthentication(string token)
		{
			Token = token;
		}
	}
}

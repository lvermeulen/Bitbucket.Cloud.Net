namespace Bitbucket.Cloud.Net.Common.Authentication
{
	public class BasicAuthentication : AuthenticationMethod
	{
		public string UserName { get; }
		public string Password { get; }

		public BasicAuthentication(string userName, string password)
		{
			UserName = userName;
			Password = password;
		}
	}
}

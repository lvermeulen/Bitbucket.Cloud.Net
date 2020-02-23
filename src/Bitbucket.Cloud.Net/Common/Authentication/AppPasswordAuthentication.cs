namespace Bitbucket.Cloud.Net.Common.Authentication
{
	public class AppPasswordAuthentication : AuthenticationMethod
	{
		public string UserName { get; }
		public string AppPassword { get; }

		public AppPasswordAuthentication(string userName, string appPassword)
		{
			UserName = userName;
			AppPassword = appPassword;
		}
	}
}

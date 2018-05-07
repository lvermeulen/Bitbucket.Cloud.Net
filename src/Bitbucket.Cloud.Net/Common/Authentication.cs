namespace Bitbucket.Cloud.Net.Common
{
    public class Authentication
    {
        // oauth
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        
        // app password
        public string AppPassword { get; set; }

        // basic
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

using Bitbucket.Cloud.Net.Common;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bitbucket.Cloud.Net
{
    public class BitbucketCloudClient
    {
        private static readonly ISerializer s_serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

        private readonly Authentication _auth = new Authentication();
        private readonly Url _url;

        private BitbucketCloudClient(string url)
        {
            _url = url;
        }

        public BitbucketCloudClient(string url, string consumerKey, string consumerSecret, string oauth)
            : this(url)
        {
            _auth.ConsumerKey = consumerKey;
            _auth.ConsumerSecret = consumerSecret;
        }

        public BitbucketCloudClient(string url, string userName, string password)
            : this(url)
        {
            _auth.UserName = userName;
            _auth.Password = password;
        }

        public IFlurlRequest GetBaseUrl(string path) => new Url(_url)
            .AppendPathSegment(path)
            .ConfigureRequest(settings => settings.JsonSerializer = s_serializer)
            .WithAuthentication(_auth);
    }
}

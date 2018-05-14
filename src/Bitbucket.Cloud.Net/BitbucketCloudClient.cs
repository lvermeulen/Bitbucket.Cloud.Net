using Bitbucket.Cloud.Net.Auth;
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

        private readonly Url _url;
        private readonly Authentication _authentication;

        public BitbucketCloudClient(string url, Authentication authentication)
        {
            _url = url;
            _authentication = authentication;
        }

        public IFlurlRequest GetBaseUrl(string path) => new Url(_url)
            .AppendPathSegment(path)
            .ConfigureRequest(settings => settings.JsonSerializer = s_serializer)
            .WithAuthentication(_authentication);
    }
}

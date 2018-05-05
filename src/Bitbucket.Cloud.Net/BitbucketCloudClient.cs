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
        private readonly string _userName;
        private readonly string _password;

        public BitbucketCloudClient(string url, string userName, string password)
        {
            _url = url;
            _userName = userName;
            _password = password;
        }

        public IFlurlRequest GetBaseUrl(string path) => new Url(_url)
            .AppendPathSegment(path)
            .ConfigureRequest(settings => settings.JsonSerializer = s_serializer)
            .WithBasicAuth(_userName, _password);
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common;
using Bitbucket.Cloud.Net.Common.Authentication;
using Bitbucket.Cloud.Net.Common.Models;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private static readonly ISerializer s_serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

		private readonly Url _url;
		private readonly AuthenticationMethod _auth;

		private BitbucketCloudClient(string url)
		{
			_url = url;
		}

		public BitbucketCloudClient(string url, OAuthAuthentication oauth)
			: this(url)
		{
			_auth = oauth;
		}

		public BitbucketCloudClient(string url, AppPasswordAuthentication appPassword)
			: this(url)
		{
			_auth = appPassword;
		}

		public BitbucketCloudClient(string url, BasicAuthentication basic)
			: this(url)
		{
			_auth = basic;
		}

		public IFlurlRequest GetBaseUrl(string path) => new Url(_url)
			.AppendPathSegment(path)
			.ConfigureRequest(settings => settings.JsonSerializer = s_serializer)
			.WithAuthentication(_auth);

		private async Task<TResult> ReadResponseContentAsync<TResult>(HttpResponseMessage responseMessage, Func<string, TResult> contentHandler = null)
		{
			string content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			return contentHandler != null
				? contentHandler(content)
				: JsonConvert.DeserializeObject<TResult>(content);
		}

		private async Task<bool> ReadResponseContentAsync(HttpResponseMessage responseMessage)
		{
			string content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			return content.Length == 0;
		}

		private async Task HandleErrorsAsync(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
			{
				var errorResponse = await ReadResponseContentAsync<ErrorResponse>(response).ConfigureAwait(false);

				string errorMessage = string.Join(Environment.NewLine, errorResponse?.Error?.Message);
				throw new InvalidOperationException($"Http request failed ({(int)response.StatusCode} - {response.StatusCode}):\n{errorMessage}");
			}
		}

		private async Task<TResult> HandleResponseAsync<TResult>(HttpResponseMessage responseMessage, Func<string, TResult> contentHandler = null)
		{
			await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
			return await ReadResponseContentAsync(responseMessage, contentHandler).ConfigureAwait(false);
		}

		private async Task<bool> HandleResponseAsync(HttpResponseMessage responseMessage)
		{
			await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
			return await ReadResponseContentAsync(responseMessage).ConfigureAwait(false);
		}

		private async Task<IEnumerable<T>> GetPagedResultsAsync<T>(int? maxPages, IFlurlRequest request, Func<IFlurlRequest, Task<PagedResults<T>>> selector)
		{
			var results = new List<T>();
			int numPages = 0;
			while (maxPages == null || numPages < maxPages)
			{
				var selectorResults = await selector(request).ConfigureAwait(false);
				results.AddRange(selectorResults.Values);

				if (string.IsNullOrWhiteSpace(selectorResults.Next))
				{
                  break;
				}
                request.Url = new Url(selectorResults.Next);
                numPages++;
			}

			return results;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Common.Models.v2;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Common
{
    public static class BitbucketCloudHelper
    {
        private static async Task<TResult> ReadResponseContentAsync<TResult>(HttpResponseMessage responseMessage, Func<string, TResult> contentHandler = null)
        {
            string content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return contentHandler != null
                ? contentHandler(content)
                : JsonConvert.DeserializeObject<TResult>(content);
        }

        private static async Task<bool> ReadResponseContentAsync(HttpResponseMessage responseMessage)
        {
            string content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return content == "";
        }

        private static async Task HandleErrorsAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await ReadResponseContentAsync<ErrorResponse>(response).ConfigureAwait(false);
                string errorMessage = string.Join(Environment.NewLine, errorResponse.Errors.Select(x => x.Message));
                throw new InvalidOperationException($"Http request failed ({(int)response.StatusCode} - {response.StatusCode}):\n{errorMessage}");
            }
        }

        internal static async Task<TResult> HandleResponseAsync<TResult>(HttpResponseMessage responseMessage, Func<string, TResult> contentHandler = null)
        {
            await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
            return await ReadResponseContentAsync(responseMessage, contentHandler).ConfigureAwait(false);
        }

        internal static async Task<bool> HandleResponseAsync(HttpResponseMessage responseMessage)
        {
            await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
            return await ReadResponseContentAsync(responseMessage).ConfigureAwait(false);
        }

        internal static async Task<IEnumerable<T>> GetPagedResultsV2Async<T>(int? maxPages, IDictionary<string, object> queryParamValues, Func<IDictionary<string, object>, Task<PagedResultsV2<T>>> selector)
        {
            var results = new List<T>();
            bool isLastPage = false;
            int numPages = 0;

            while (!isLastPage && (maxPages == null || numPages < maxPages))
            {
                var selectorResults = await selector(queryParamValues).ConfigureAwait(false);
                results.AddRange(selectorResults.Values);

                isLastPage = selectorResults.Next == null;
                numPages++;
            }

            return results;
        }
    }
}

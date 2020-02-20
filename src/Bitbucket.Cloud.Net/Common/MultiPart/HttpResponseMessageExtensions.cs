using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public static class HttpResponseMessageExtensions
	{
		static HttpResponseMessageExtensions()
		{
			Encoding.RegisterProvider(MultipartEncodingProvider.Instance);
		}

		public static async Task<IEnumerable<MultipartContentSection>> ReceiveMultipartAsync(this Task<HttpResponseMessage> response)
		{
			using var resp = await response.ConfigureAwait(false);
			if (resp == null)
			{
				return null;
			}

			string contentString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
			return contentString.ReadMultipartContent();
		}

		public static async Task<object> WithMultipartContentSectionsAsync(this Task<IEnumerable<MultipartContentSection>> multipartContentSectionsTask, Func<MultipartContentSection, object> multipartContentSectionHandler)
		{
			var multipartContentSections = await multipartContentSectionsTask.ConfigureAwait(false);
			foreach (var multipartContentSection in multipartContentSections)
			{
				await Task.Run(() => multipartContentSectionHandler?.Invoke(multipartContentSection)).ConfigureAwait(false);
			}

			return multipartContentSectionsTask;
		}
	}
}

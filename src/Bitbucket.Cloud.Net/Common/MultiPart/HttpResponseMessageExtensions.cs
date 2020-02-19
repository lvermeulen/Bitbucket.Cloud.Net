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
			return contentString.ParseContent();
		}

		public static async Task<object> WithContentPartsAsync(this Task<IEnumerable<MultipartContentSection>> multipartContentSectionsTask, Func<MultipartContentSection, object> contentSectionHandler)
		{
			var contentSections = await multipartContentSectionsTask.ConfigureAwait(false);
			foreach (var contentSection in contentSections)
			{
				await Task.Run(() => contentSectionHandler?.Invoke(contentSection)).ConfigureAwait(false);
			}

			return multipartContentSectionsTask;
		}
	}
}

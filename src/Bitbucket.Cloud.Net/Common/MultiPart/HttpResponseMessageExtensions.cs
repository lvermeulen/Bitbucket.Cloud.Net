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
			Encoding.RegisterProvider(CustomEncodingProvider.Instance);
		}

		public static async Task<IEnumerable<ContentPart>> ReceiveMultiPartRelatedAsync(this Task<HttpResponseMessage> response)
		{
			using var resp = await response.ConfigureAwait(false);
			if (resp == null)
			{
				return null;
			}

			var contentString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
			return contentString.ParseContent();
		}

		public static async Task<IEnumerable<ContentPart>> ReceiveMultiPartFormDataAsync(this Task<HttpResponseMessage> response)
		{
			using var resp = await response.ConfigureAwait(false);
			if (resp == null)
			{
				return null;
			}

			var contentString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
			return contentString.ParseContent();
		}

		public static async Task<object> WithContentPartsAsync(this Task<IEnumerable<ContentPart>> contentPartsTask, Func<ContentPart, object> contentPartsHandler)
		{
			var contentParts = await contentPartsTask.ConfigureAwait(false);
			foreach (var contentPart in contentParts)
			{
				await Task.Run(() => contentPartsHandler?.Invoke(contentPart)).ConfigureAwait(false);
			}

			return contentPartsTask;
		}
	}
}

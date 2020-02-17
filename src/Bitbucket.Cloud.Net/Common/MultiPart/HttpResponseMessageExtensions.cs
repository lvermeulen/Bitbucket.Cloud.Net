using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public static class HttpResponseMessageExtensions
	{
		public static async Task<IEnumerable<ContentPart>> ReceiveMultiPartRelatedAsync(this Task<HttpResponseMessage> response)
		{
			using var resp = await response.ConfigureAwait(false);
			if (resp == null) return null;
			var contentString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);

			return contentString.ParseContent();
		}

		public static async Task<IEnumerable<ContentPart>> ReceiveMultiPartFormDataAsync(this Task<HttpResponseMessage> response)
		{
			using var resp = await response.ConfigureAwait(false);
			if (resp == null) return null;
			var contentString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);

			return contentString.ParseContent();
		}

		public static async Task<object> WithContentPartsAsync(this Task<IEnumerable<ContentPart>> contentPartsTask, Func<ContentPart, (object, string)> contentPartAction)
		{
			var contentParts = await contentPartsTask.ConfigureAwait(false);
			foreach (var contentPart in contentParts)
			{
				await Task.Run(() => contentPartAction?.Invoke(contentPart)).ConfigureAwait(false);
			}

			return contentPartsTask;
		}
	}
}

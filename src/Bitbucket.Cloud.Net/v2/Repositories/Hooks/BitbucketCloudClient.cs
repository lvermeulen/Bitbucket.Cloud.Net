using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetHooksUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/hooks");

		private IFlurlRequest GetHooksUrl(string workspaceId, string repositorySlug, string path) => GetHooksUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<Webhook> CreateRepositoryWebhookAsync(string workspaceId, string repositorySlug, Webhook webhook)
		{
			var response = await GetHooksUrl(workspaceId, repositorySlug)
				.PostJsonAsync(webhook)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Webhook>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Webhook>> GetRepositoryWebhooksAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetHooksUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Webhook>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Webhook> UpdateRepositoryWebhookAsync(string workspaceId, string repositorySlug, string webhookId, Webhook webhook)
		{
			var response = await GetHooksUrl(workspaceId, repositorySlug, webhookId)
				.PutJsonAsync(webhook)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Webhook>(response).ConfigureAwait(false);
		}

		public async Task<Webhook> GetRepositoryWebhookAsync(string workspaceId, string repositorySlug, Guid webhookUuid)
		{
			return await GetHooksUrl(workspaceId, repositorySlug, webhookUuid.ToString("B"))
				.GetJsonAsync<Webhook>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryWebhookAsync(string workspaceId, string repositorySlug, string webhookId)
		{
			var response = await GetHooksUrl(workspaceId, repositorySlug, webhookId)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync<bool>(response).ConfigureAwait(false);
		}
	}
}

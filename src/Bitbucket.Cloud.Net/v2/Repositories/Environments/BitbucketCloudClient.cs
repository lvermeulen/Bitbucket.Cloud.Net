using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Flurl.Http;
using Environment = Bitbucket.Cloud.Net.Models.v2.Environment;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetEnvironmentsUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/environments");

		private IFlurlRequest GetEnvironmentsUrl(string workspaceId, string repositorySlug, string path) => GetEnvironmentsUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<Environment> CreateRepositoryEnvironmentAsync(string workspaceId, string repositorySlug, string fileName)
		{
			var response = await GetEnvironmentsUrl(workspaceId, repositorySlug)
				.PostMultipartAsync(content => content.AddFile(Path.GetFileName(fileName), fileName))
				.ConfigureAwait(false);

			return await HandleResponseAsync<Environment>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Environment>> GetRepositoryEnvironmentsAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			return await GetPagedResultsAsync(maxPages, GetEnvironmentsUrl(workspaceId, repositorySlug), async req =>
					await req
						.GetJsonAsync<PagedResults<Environment>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Environment> GetRepositoryEnvironmentAsync(string workspaceId, string repositorySlug, Guid environmentUuid)
		{
			return await GetEnvironmentsUrl(workspaceId, repositorySlug, environmentUuid.ToString("B"))
				.GetJsonAsync<Environment>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryEnvironmentAsync(string workspaceId, string repositorySlug, Guid environmentUuid)
		{
			var response = await GetEnvironmentsUrl(workspaceId, repositorySlug, environmentUuid.ToString("B"))
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> UpdateRepositoryEnvironmentAsync(string workspaceId, string repositorySlug, Guid environmentUuid)
		{
			var response = await GetEnvironmentsUrl(workspaceId, repositorySlug, environmentUuid.ToString("B"))
				.AppendPathSegment("/changes")
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

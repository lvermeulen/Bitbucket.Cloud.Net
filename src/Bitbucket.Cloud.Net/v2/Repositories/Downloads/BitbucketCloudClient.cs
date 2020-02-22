using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetDownloadsUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/downloads");

		private IFlurlRequest GetDownloadsUrl(string workspaceId, string repositorySlug, string path) => GetDownloadsUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<bool> CreateRepositoryDownloadAsync(string workspaceId, string repositorySlug, string fileName)
		{
			var response = await GetDownloadsUrl(workspaceId, repositorySlug)
				.PostMultipartAsync(content => content.AddFile(Path.GetFileName(fileName), fileName))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Download>> GetRepositoryDownloadsAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetDownloadsUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Download>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryDownloadAsync(string workspaceId, string repositorySlug, string fileName, string localFolderPath)
		{
			return await GetDownloadsUrl(workspaceId, repositorySlug, fileName)
				.DownloadFileAsync(localFolderPath)
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryDownloadAsync(string workspaceId, string repositorySlug, string fileName)
		{
			var response = await GetDownloadsUrl(workspaceId, repositorySlug, fileName)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

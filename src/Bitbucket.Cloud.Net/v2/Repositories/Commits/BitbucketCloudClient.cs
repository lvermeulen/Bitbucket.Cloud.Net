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
		private IFlurlRequest GetCommitsUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/commits");

		private IFlurlRequest GetCommitsUrl(string workspaceId, string repositorySlug, string path) => GetCommitsUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<IEnumerable<Commit>> GetRepositoryCommitsAsync(string workspaceId, string repositorySlug, int? maxPages = null, string path = null,
			IEnumerable<string> includes = null, IEnumerable<string> excludes = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(path)] = path,
				["include"] = includes,
				["exclude"] = excludes
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetCommitsUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Commit>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Commit>> GetRepositoryReferenceCommitsAsync(string workspaceId, string repositorySlug, string reference, int? maxPages = null, string path = null,
			IEnumerable<string> includes = null, IEnumerable<string> excludes = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(path)] = path,
				["include"] = includes,
				["exclude"] = excludes
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetCommitsUrl(workspaceId, repositorySlug, reference)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Commit>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

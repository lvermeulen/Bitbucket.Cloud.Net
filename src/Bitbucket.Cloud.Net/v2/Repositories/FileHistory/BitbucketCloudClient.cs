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
		private IFlurlRequest GetFileHistoryUrl(string workspaceId, string repositorySlug, string node, string path) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/filehistory/{node}/{path}");

		public async Task<IEnumerable<FileHistoryItem>> GetRepositoryFileHistoryAsync(string workspaceId, string repositorySlug, string node, string path, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetFileHistoryUrl(workspaceId, repositorySlug, node, path)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<FileHistoryItem>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

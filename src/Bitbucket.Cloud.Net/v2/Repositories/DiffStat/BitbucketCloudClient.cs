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
		private IFlurlRequest GetDiffStatUrl(string workspaceId, string repositorySlug, string spec) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/diffstat/{spec}");

		public async Task<IEnumerable<DiffStat>> GetRepositoryDiffStatAsync(string workspaceId, string repositorySlug, string spec, int? maxPages = null, bool ignoreWhiteSpace = false)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				["ignore_whitespace"] = ignoreWhiteSpace
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetDiffStatUrl(workspaceId, repositorySlug, spec)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<DiffStat>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

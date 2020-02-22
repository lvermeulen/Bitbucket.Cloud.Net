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
		private IFlurlRequest GetMilestonesUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/milestones");

		private IFlurlRequest GetMilestonesUrl(string workspaceId, string repositorySlug, string milestoneId) => GetMilestonesUrl(workspaceId, repositorySlug)
			.AppendPathSegment($"/{milestoneId}");

		public async Task<IEnumerable<Milestone>> GetRepositoryMilestonesAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetMilestonesUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Milestone>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Milestone> GetRepositoryMilestoneAsync(string workspaceId, string repositorySlug, string milestoneId)
		{
			return await GetMilestonesUrl(workspaceId, repositorySlug, milestoneId)
				.GetJsonAsync<Milestone>()
				.ConfigureAwait(false);
		}
	}
}

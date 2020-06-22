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
			return await GetPagedResultsAsync(maxPages, GetMilestonesUrl(workspaceId, repositorySlug), async req =>
					await req
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

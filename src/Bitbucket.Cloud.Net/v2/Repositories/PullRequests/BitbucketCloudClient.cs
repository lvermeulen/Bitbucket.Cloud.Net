using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetPullRequestsUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/pullrequests");

		private IFlurlRequest GetPullRequestsUrl(string workspaceId, string repositorySlug, string path) => GetPullRequestsUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<PullRequest> CreateRepositoryPullRequestAsync(string workspaceId, string repositorySlug, PullRequestCreationParameters pullRequestCreationParameters)
		{
			var data = new
			{
				title = pullRequestCreationParameters.Title,
				description = pullRequestCreationParameters.Description,
				source = pullRequestCreationParameters.Source,
				destination = pullRequestCreationParameters.Destination,
				reviewers = pullRequestCreationParameters.Reviewers,
				close_source_branch = pullRequestCreationParameters.CloseSourceBranch
			};

			var response = await GetPullRequestsUrl(workspaceId, repositorySlug)
				.PostJsonAsync(data)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PullRequest>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<PullRequest>> GetRepositoryPullRequestsAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPullRequestsUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PullRequest>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<PullRequestActivity>> GetRepositoryPullRequestActivityAsync(string workspaceId, string repositorySlug, string pullRequestId, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/activity")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PullRequestActivity>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<PullRequest> UpdatePullRequestAsync(string workspaceId, string repositorySlug, string pullRequestId, PullRequest pullRequest)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}")
				.PutJsonAsync(pullRequest)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PullRequest>(response).ConfigureAwait(false);
		}

		public async Task<PullRequest> GetRepositoryPullRequestAsync(string workspaceId, string repositorySlug, string pullRequestId)
		{
			return await GetPullRequestsUrl(workspaceId, repositorySlug, $"{pullRequestId}")
				.GetJsonAsync<PullRequest>()
				.ConfigureAwait(false);
		}

		public async Task<Participant> ApprovePullRequestAsync(string workspaceId, string repositorySlug, string pullRequestId)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/approve")
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync<Participant>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryPullRequestApprovalAsync(string workspaceId, string repositorySlug, string pullRequestId)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/approve")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<PullRequestComment> CreateRepositoryPullRequestCommentAsync(string workspaceId, string repositorySlug, string pullRequestId, PullRequestComment pullRequestComment)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/comments")
				.PostJsonAsync(pullRequestComment)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PullRequestComment>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<PullRequestComment>> GetRepositoryPullRequestCommentsAsync(string workspaceId, string repositorySlug, string pullRequestId, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/comments")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PullRequestComment>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<PullRequestComment> UpdateRepositoryPullRequestCommentAsync(string workspaceId, string repositorySlug, string pullRequestId, string pullRequestCommentId, PullRequestComment pullRequestComment)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/comments/{pullRequestCommentId}")
				.PutJsonAsync(pullRequestComment)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PullRequestComment>(response).ConfigureAwait(false);
		}

		public async Task<PullRequestComment> GetRepositoryPullRequestCommentAsync(string workspaceId, string repositorySlug, string pullRequestId, string pullRequestCommentId)
		{
			return await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/comments/{pullRequestCommentId}")
				.GetJsonAsync<PullRequestComment>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryPullRequestCommentAsync(string workspaceId, string repositorySlug, string pullRequestId, string pullRequestCommentId)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/comments/{pullRequestCommentId}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Commit>> GetRepositoryPullRequestCommitsAsync(string workspaceId, string repositorySlug, string pullRequestId, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/commits")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Commit>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<PullRequest> DeclineRepositoryPullRequestAsync(string workspaceId, string repositorySlug, string pullRequestId)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/decline")
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync<PullRequest>(response).ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryPullRequestDiffAsync(string workspaceId, string repositorySlug, string pullRequestId)
		{
			return await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/diff")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<DiffStat>> GetRepositoryPullRequestDiffStatAsync(string workspaceId, string repositorySlug, string pullRequestId, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/diffstat")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<DiffStat>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<PullRequest> MergeRepositoryPullRequestAsync(string workspaceId, string repositorySlug, string pullRequestId, PullRequestMergeParameters pullRequestMergeParameters)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/merge")
				.PostJsonAsync(pullRequestMergeParameters)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PullRequest>(response).ConfigureAwait(false);
		}

		public async Task<PullRequestTaskStatus> GetRepositoryPullRequestTaskStatusAsync(string workspaceId, string repositorySlug, string pullRequestId, string taskId)
		{
			return await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/merge/task-status/{taskId}")
				.GetJsonAsync<PullRequestTaskStatus>()
				.ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryPullRequestPatchAsync(string workspaceId, string repositorySlug, string pullRequestId)
		{
			return await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/patch")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<BuildResult>> GetRepositoryPullRequestBuildResultsAsync(string workspaceId, string repositorySlug, string pullRequestId, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/statuses")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<BuildResult>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<bool> UpdateRepositoryPullRequestPropertyValueAsync(string workspaceId, string repositorySlug, string pullRequestId, string appKey, string propertyName, string propertyValue)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/properties/{appKey}/{propertyName}")
				.PutStringAsync(propertyValue)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryPullRequestPropertyValueAsync(string workspaceId, string repositorySlug, string pullRequestId, string appKey, string propertyName)
		{
			return await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/properties/{appKey}/{propertyName}")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryPullRequestPropertyValueAsync(string workspaceId, string repositorySlug, string pullRequestId, string appKey, string propertyName)
		{
			var response = await GetPullRequestsUrl(workspaceId, repositorySlug, $"/{pullRequestId}/properties/{appKey}/{propertyName}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

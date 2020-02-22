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
		private IFlurlRequest GetCommitUrl(string workspaceId, string repositorySlug, string commit) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/commit/{commit}");

		private IFlurlRequest GetCommitUrl(string workspaceId, string repositorySlug, string commit, string path) => GetCommitUrl(workspaceId, repositorySlug, commit)
			.AppendPathSegment(path);

		public async Task<bool> UpdateRepositoryCommitPropertyValueAsync(string workspaceId, string repositorySlug, string commit, string appKey, string propertyName, string propertyValue)
		{
			var response = await GetCommitUrl(workspaceId, repositorySlug, commit, $"/properties/{appKey}/{propertyName}")
				.PutStringAsync(propertyValue)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryCommitPropertyValueAsync(string workspaceId, string repositorySlug, string commit, string appKey, string propertyName)
		{
			return await GetCommitUrl(workspaceId, repositorySlug, commit, $"/properties/{appKey}/{propertyName}")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryCommitPropertyValueAsync(string workspaceId, string repositorySlug, string commit, string appKey, string propertyName)
		{
			var response = await GetCommitUrl(workspaceId, repositorySlug, commit, $"/properties/{appKey}/{propertyName}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<PullRequestInfo>> GetRepositoryCommitPullRequestsAsync(string workspaceId, string repositorySlug, string commit, int? maxPages = null, int? page = null, int? pageLength = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(page)] = page,
				["pagelen"] = pageLength
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetCommitUrl(workspaceId, repositorySlug, commit, "/pullrequests")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PullRequestInfo>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Commit> GetRepositoryCommitAsync(string workspaceId, string repositorySlug, string commit)
		{
			return await GetCommitUrl(workspaceId, repositorySlug, commit)
				.GetJsonAsync<Commit>()
				.ConfigureAwait(false);
		}

		public async Task<Participant> ApproveRepositoryCommitAsync(string workspaceId, string repositorySlug, string commit)
		{
			var response = await GetCommitUrl(workspaceId, repositorySlug, commit, "/approve")
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync<Participant>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryCommitApprovalAsync(string workspaceId, string repositorySlug, string commit)
		{
			var response = await GetCommitUrl(workspaceId, repositorySlug, commit, "/approve")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<PullRequestComment> CreateRepositoryCommitCommentAsync(string workspaceId, string repositorySlug, string commit, Comment comment)
		{
			var response = await GetCommitUrl(workspaceId, repositorySlug, commit, "/comments")
				.PostJsonAsync(comment)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PullRequestComment>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Comment>> GetRepositoryCommitCommentsAsync(string workspaceId, string repositorySlug, string commit, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetCommitUrl(workspaceId, repositorySlug, commit, "/comments")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Comment>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Comment> GetRepositoryCommitCommentAsync(string workspaceId, string repositorySlug, string commit, string commentId)
		{
			return await GetCommitUrl(workspaceId, repositorySlug, commit, $"/comments/{commentId}")
				.GetJsonAsync<Comment>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<BuildResult>> GetRepositoryCommitBuildResultsAsync(string workspaceId, string repositorySlug, string commit, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetCommitUrl(workspaceId, repositorySlug, commit, "/statuses")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<BuildResult>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<BuildResult> CreateRepositoryCommitBuildResultAsync(string workspaceId, string repositorySlug, string commit, BuildResult buildResult)
		{
			var response = await GetCommitUrl(workspaceId, repositorySlug, commit, "/statuses/build")
				.PostJsonAsync(buildResult)
				.ConfigureAwait(false);

			return await HandleResponseAsync<BuildResult>(response).ConfigureAwait(false);
		}

		public async Task<BuildResult> UpdateRepositoryCommitBuildResultAsync(string workspaceId, string repositorySlug, string commit, string key, BuildResult buildResult)
		{
			var response = await GetCommitUrl(workspaceId, repositorySlug, commit, $"/statuses/build/{key}")
				.PutJsonAsync(buildResult)
				.ConfigureAwait(false);

			return await HandleResponseAsync<BuildResult>(response).ConfigureAwait(false);
		}

		public async Task<BuildResult> GetRepositoryCommitBuildResultAsync(string workspaceId, string repositorySlug, string commit, string key)
		{
			return await GetCommitUrl(workspaceId, repositorySlug, commit, $"/statuses/build/{key}")
				.GetJsonAsync<BuildResult>()
				.ConfigureAwait(false);
		}
	}
}

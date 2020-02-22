using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;
using Flurl.Http.Content;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetIssuesUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/issues");

		private IFlurlRequest GetIssuesUrl(string workspaceId, string repositorySlug, string path) => GetIssuesUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<Issue> CreateRepositoryIssueAsync(string workspaceId, string repositorySlug, Issue issue)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug)
				.PostJsonAsync(issue)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Issue>> GetRepositoryIssuesAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetIssuesUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Issue>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<string> ExportRepositoryIssuesAsync(string workspaceId, string repositorySlug)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, "/export")
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return response.Headers.TryGetValues("Location", out var values) ? values.FirstOrDefault() : null;
		}

		public async Task<string> GetRepositoryIssuesExportAsync(string workspaceId, string repositorySlug, string fileName, string localFolderPath)
		{
			return await GetIssuesUrl(workspaceId, repositorySlug, $"/export/{fileName}")
				.DownloadFileAsync(localFolderPath)
				.ConfigureAwait(false);
		}

		public async Task<IssueJobStatus> GetRepositoryIssuesExportStatusAsync(string workspaceId, string repositorySlug)
		{
			return await GetIssuesUrl(workspaceId, repositorySlug, "/export")
				.GetJsonAsync<IssueJobStatus>()
				.ConfigureAwait(false);
		}

		public async Task<IssueJobStatus> ImportRepositoryIssuesAsync(string workspaceId, string repositorySlug, string fileName)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, "/import")
				.PostMultipartAsync(content => content.AddString("archive", fileName))
				.ConfigureAwait(false);

			return await HandleResponseAsync<IssueJobStatus>(response).ConfigureAwait(false);
		}

		public async Task<IssueJobStatus> GetRepositoryIssuesImportAsync(string workspaceId, string repositorySlug)
		{
			return await GetIssuesUrl(workspaceId, repositorySlug, "/import")
				.GetJsonAsync<IssueJobStatus>()
				.ConfigureAwait(false);
		}

		public async Task<Issue> UpdateRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId, Issue issue)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.PutJsonAsync(issue)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<Issue> GetRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId)
		{
			return await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.GetJsonAsync<Issue>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<Issue> CreateRepositoryIssueAttachmentAsync(string workspaceId, string repositorySlug, string issueId, IssueAttachment issueAttachment)
		{
			var capturedContent = new CapturedMultipartContent();
			foreach (var propertyInfo in issueAttachment.GetType().GetProperties())
			{
				capturedContent.Add(propertyInfo.Name, new StringContent(propertyInfo.GetValue(issueAttachment).ToString()));
			}

			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.PostMultipartAsync(content => content.AddStringParts(capturedContent))
				.ConfigureAwait(false);

			return await HandleResponseAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<IssueAttachment>> GetRepositoryIssueAttachmentsAsync(string workspaceId, string repositorySlug, string issueId, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetIssuesUrl(workspaceId, repositorySlug, issueId)
						.AppendPathSegment("/attachments")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<IssueAttachment>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryIssueAttachmentAsync(string workspaceId, string repositorySlug, string issueId, string fileName, string localFolderPath)
		{
			return await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment($"/attachments/{fileName}")
				.DownloadFileAsync(localFolderPath)
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryIssueAttachmentAsync(string workspaceId, string repositorySlug, string issueId, string fileName)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment($"/attachments/{fileName}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IssueChange> CreateRepositoryIssueChangeAsync(string workspaceId, string repositorySlug, string issueId, NewIssueChange newIssueChange)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment("/changes")
				.PostJsonAsync(newIssueChange)
				.ConfigureAwait(false);

			return await HandleResponseAsync<IssueChange>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<IssueChange>> GetRepositoryIssueChangesAsync(string workspaceId, string repositorySlug, string issueId, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetIssuesUrl(workspaceId, repositorySlug, issueId)
						.AppendPathSegment("/changes")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<IssueChange>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<IssueChange> GetRepositoryIssueChangeAsync(string workspaceId, string repositorySlug, string issueId, string changeId)
		{
			return await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment($"/changes/{changeId}")
				.GetJsonAsync<IssueChange>()
				.ConfigureAwait(false);
		}

		public async Task<IssueComment> CreateRepositoryIssueCommentAsync(string workspaceId, string repositorySlug, string issueId, IssueComment issueComment)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment("/comments")
				.PostJsonAsync(issueComment)
				.ConfigureAwait(false);

			return await HandleResponseAsync<IssueComment>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<IssueComment>> GetRepositoryIssueCommentsAsync(string workspaceId, string repositorySlug, string issueId, int? maxPages = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetIssuesUrl(workspaceId, repositorySlug, issueId)
						.AppendPathSegment("/comments")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<IssueComment>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Issue> UpdateRepositoryIssueCommentAsync(string workspaceId, string repositorySlug, string issueId, string commentId, IssueComment issueComment)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment($"/comments/{commentId}")
				.PutJsonAsync(issueComment)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<IssueComment> GetRepositoryIssueCommentAsync(string workspaceId, string repositorySlug, string issueId, string commentId)
		{
			return await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment($"/comments/{commentId}")
				.GetJsonAsync<IssueComment>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryIssueCommentAsync(string workspaceId, string repositorySlug, string issueId, string commentId)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment($"/comments/{commentId}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> VoteForRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment("/vote")
				.PutJsonAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> HasVotedForRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment("/vote")
				.GetAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RetractVoteForRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment("/vote")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> StartWatchingRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment("/watch")
				.PutJsonAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> IsWatchingRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment("/watch")
				.GetAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> StopWatchingRepositoryIssueAsync(string workspaceId, string repositorySlug, string issueId)
		{
			var response = await GetIssuesUrl(workspaceId, repositorySlug, issueId)
				.AppendPathSegment("/watch")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Common.MultiPart;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetSnippetsUrl() => GetBaseUrl("2.0/snippets");

		private IFlurlRequest GetSnippetsUrl(string path) => GetSnippetsUrl()
			.AppendPathSegment(path);

		public async Task<Snippet> CreateSnippetAsync(Snippet snippet)
		{
			var response = await GetSnippetsUrl()
				.PostJsonAsync(snippet)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Snippet>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Snippet>> GetSnippetsAsync(Roles? role = null, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(role)] = RolesConverter.ConvertToString(role)
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetSnippetsUrl()
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Snippet>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Snippet> CreateWorkspaceSnippetAsync(string workspaceId, Snippet snippet)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.PostJsonAsync(snippet)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Snippet>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Snippet>> GetWorkspaceSnippetsAsync(string workspaceId, Roles? role = null, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(role)] = RolesConverter.ConvertToString(role)
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetSnippetsUrl(workspaceId)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Snippet>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Snippet> UpdateWorkspaceSnippetAsync(string workspaceId, string snippetId, Snippet snippet)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.PutJsonAsync(snippet)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Snippet>(response).ConfigureAwait(false);
		}

		public async Task<object> GetWorkspaceSnippetAsync(string workspaceId, string snippetId, SnippetsContentTypes accept = SnippetsContentTypes.ApplicationJson, Func<MultipartContentSection, object> contentSectionHandler = null)
		{
			string acceptString = SnippetsContentTypesConverter.ConvertToString(accept);
			var request = GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AllowHttpStatus(HttpStatusCode.NotAcceptable)
				.WithHeader("Accept", acceptString);

			return accept switch
			{
				SnippetsContentTypes.MultipartRelated => await request
					.GetMultipartAsync()
					.WithMultipartContentSectionsAsync(contentSectionHandler)
					.ConfigureAwait(false),

				SnippetsContentTypes.MultipartFormdata => await request
					.GetMultipartAsync()
					.WithMultipartContentSectionsAsync(contentSectionHandler)
					.ConfigureAwait(false),

				_ => await request
					.GetJsonAsync<Snippet>()
					.ConfigureAwait(false)
			};
		}

		public async Task<bool> DeleteWorkspaceSnippetAsync(string workspaceId, string snippetId)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<SnippetComment> CreateWorkspaceSnippetCommentAsync(string workspaceId, string snippetId, SnippetComment snippetComment)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/comments")
				.PostJsonAsync(snippetComment)
				.ConfigureAwait(false);

			return await HandleResponseAsync<SnippetComment>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<SnippetComment>> GetWorkspaceSnippetCommentsAsync(string workspaceId, string snippetId, int? maxPages = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetSnippetsUrl(workspaceId)
						.AppendPathSegment(snippetId)
						.AppendPathSegment("/comments")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<SnippetComment>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<SnippetComment> UpdateWorkspaceSnippetCommentAsync(string workspaceId, string snippetId, string snippetCommentId, SnippetComment snippetComment)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/comments")
				.AppendPathSegment(snippetCommentId)
				.PutJsonAsync(snippetComment)
				.ConfigureAwait(false);

			return await HandleResponseAsync<SnippetComment>(response).ConfigureAwait(false);
		}

		public async Task<SnippetComment> GetWorkspaceSnippetCommentAsync(string workspaceId, string snippetId, string snippetCommentId)
		{
			return await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/comments")
				.AppendPathSegment(snippetCommentId)
				.GetJsonAsync<SnippetComment>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteWorkspaceSnippetCommentAsync(string workspaceId, string snippetId, string snippetCommentId)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/comments")
				.AppendPathSegment(snippetCommentId)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<SnippetCommit>> GetWorkspaceSnippetCommitsAsync(string workspaceId, string snippetId, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetSnippetsUrl(workspaceId)
						.AppendPathSegment(snippetId)
						.AppendPathSegment("/commits")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<SnippetCommit>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<SnippetCommit> GetWorkspaceSnippetCommitAsync(string workspaceId, string snippetId, string commit)
		{
			return await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/commits")
				.AppendPathSegment(commit)
				.GetJsonAsync<SnippetCommit>()
				.ConfigureAwait(false);
		}

		public async Task<string> GetWorkspaceSnippetFileAsync(string workspaceId, string snippetId, string fileName)
		{
			return await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/files")
				.AppendPathSegment(fileName)
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<bool> StartWatchingWorkspaceSnippetAsync(string workspaceId, string snippetId)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/watch")
				.PutJsonAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> IsWatchingWorkspaceSnippetAsync(string workspaceId, string snippetId)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/watch")
				.GetAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> StopWatchingWorkspaceSnippetAsync(string workspaceId, string snippetId)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment("/watch")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<User>> GetWorkspaceSnippetWatchersAsync(string workspaceId, string snippetId, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetSnippetsUrl(workspaceId)
						.AppendPathSegment(snippetId)
						.AppendPathSegment("/watchers")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<User>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Snippet> UpdateWorkspaceSnippetAsync(string workspaceId, string snippetId, string node, Snippet snippet)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment(node)
				.PutJsonAsync(snippet)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Snippet>(response).ConfigureAwait(false);
		}

		public async Task<object> GetWorkspaceSnippetAsync(string workspaceId, string snippetId, string node)
		{
			return await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment(node)
				.GetJsonAsync<Snippet>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteWorkspaceSnippetAsync(string workspaceId, string snippetId, string node)
		{
			var response = await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment(node)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<string> GetWorkspaceSnippetFileAsync(string workspaceId, string snippetId, string node, string fileName)
		{
			return await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment(node)
				.AppendPathSegment("/files")
				.AppendPathSegment(fileName)
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<string> GetWorkspaceSnippetDiffAsync(string workspaceId, string snippetId, string spec)
		{
			return await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment(spec)
				.AppendPathSegment("/diff")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<string> GetWorkspaceSnippetPatchAsync(string workspaceId, string snippetId, string spec)
		{
			return await GetSnippetsUrl(workspaceId)
				.AppendPathSegment(snippetId)
				.AppendPathSegment(spec)
				.AppendPathSegment("/patch")
				.GetStringAsync()
				.ConfigureAwait(false);
		}
	}
}

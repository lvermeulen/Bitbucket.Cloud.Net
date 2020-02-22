using System.Linq;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.MultiPart;
using Bitbucket.Cloud.Net.Models.v2;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData(Roles.Owner)]
		public async Task GetSnippetsAsync(Roles role)
		{
			var result = await _client.GetSnippetsAsync(role).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", Roles.Owner)]
		public async Task GetWorkspaceSnippetsAsync(string workspaceId, Roles role)
		{
			var result = await _client.GetWorkspaceSnippetsAsync(workspaceId, role).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetAsync(string workspaceId)
		{
			var results = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetAsync(workspaceId, firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", SnippetsContentTypes.ApplicationJson)]
		[InlineData("luve", SnippetsContentTypes.MultipartRelated)]
		public async Task GetWorkspaceSnippetWithMultipartContentSectionHandlerAsync(string workspaceId, SnippetsContentTypes accept)
		{
			static object MultipartContentSectionHandler(MultipartContentSection multipartContentSection)
			{
				return multipartContentSection?.ContentType switch
				{
					"text/plain" => multipartContentSection.AsText(),
					"image/png" => multipartContentSection.AsBytes(),
					"application/octet-stream" => multipartContentSection.AsBytes(),
					_ => multipartContentSection?.AsJson<Snippet>()
				};
			}

			var results = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetAsync(workspaceId, firstResult.Id, accept, MultipartContentSectionHandler).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetCommentsAsync(string workspaceId)
		{
			var results = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetCommentsAsync(workspaceId, firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetCommentAsync(string workspaceId)
		{
			var snippets = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstSnippet = snippets.FirstOrDefault();
			if (firstSnippet == null)
			{
				return;
			}

			var results = await _client.GetWorkspaceSnippetCommentsAsync(workspaceId, firstSnippet.Id).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetCommentAsync(workspaceId, firstSnippet.Id, firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetCommitsAsync(string workspaceId)
		{
			var results = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetCommitsAsync(workspaceId, firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetCommitAsync(string workspaceId)
		{
			var snippets = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstSnippet = snippets.FirstOrDefault();
			if (firstSnippet == null)
			{
				return;
			}

			var results = await _client.GetWorkspaceSnippetCommitsAsync(workspaceId, firstSnippet.Id).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetCommitAsync(workspaceId, firstSnippet.Id, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test_snippet_filename.txt")]
		public async Task GetWorkspaceSnippetFileAsync(string workspaceId, string fileName)
		{
			var results = await _client.GetWorkspaceSnippetsAsync(workspaceId).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetFileAsync(workspaceId, firstResult.Id, fileName).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetWatchersAsync(string workspaceId)
		{
			var results = await _client.GetWorkspaceSnippetsAsync(workspaceId).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetWatchersAsync(workspaceId, firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetDiffAsync(string workspaceId)
		{
			var snippets = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstSnippet = snippets.FirstOrDefault();
			if (firstSnippet == null)
			{
				return;
			}

			var results = await _client.GetWorkspaceSnippetCommitsAsync(workspaceId, firstSnippet.Id).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			string result = await _client.GetWorkspaceSnippetDiffAsync(workspaceId, firstSnippet.Id, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetPatchAsync(string workspaceId)
		{
			var snippets = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstSnippet = snippets.FirstOrDefault();
			if (firstSnippet == null)
			{
				return;
			}

			var results = await _client.GetWorkspaceSnippetCommitsAsync(workspaceId, firstSnippet.Id).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			string result = await _client.GetWorkspaceSnippetPatchAsync(workspaceId, firstSnippet.Id, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetWorkspaceSnippetWithHashAsync(string workspaceId)
		{
			var snippets = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstSnippet = snippets.FirstOrDefault();
			if (firstSnippet == null)
			{
				return;
			}

			var results = await _client.GetWorkspaceSnippetCommitsAsync(workspaceId, firstSnippet.Id).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetAsync(workspaceId, firstSnippet.Id, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test_snippet_filename.txt")]
		public async Task GetWorkspaceSnippetFileWithHashAsync(string workspaceId, string fileName)
		{
			var snippets = await _client.GetWorkspaceSnippetsAsync(workspaceId, Roles.Owner).ConfigureAwait(false);
			var firstSnippet = snippets.FirstOrDefault();
			if (firstSnippet == null)
			{
				return;
			}

			var results = await _client.GetWorkspaceSnippetCommitsAsync(workspaceId, firstSnippet.Id).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWorkspaceSnippetFileAsync(workspaceId, firstSnippet.Id, firstResult.Hash, fileName).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

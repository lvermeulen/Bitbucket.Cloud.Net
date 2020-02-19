using System.Linq;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.MultiPart;
using Bitbucket.Cloud.Net.Models;
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
		[InlineData("luve", SnippetsAccept.ApplicationJson)]
		[InlineData("luve", SnippetsAccept.MultipartRelated)]
		public async Task GetWorkspaceSnippetWithMultipartContentSectionHandlerAsync(string workspaceId, SnippetsAccept accept)
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
	}
}

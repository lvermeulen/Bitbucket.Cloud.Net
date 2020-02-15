using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryIssuesAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryIssuesAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryIssueAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryIssuesAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryIssueAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryIssueChangesAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryIssuesAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryIssueChangesAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryIssueCommentsAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryIssuesAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryIssueCommentsAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryIssueCommentAsync(string workspaceId, string repositorySlug)
		{
			var issues = await _client.GetRepositoryIssuesAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstIssue = issues.FirstOrDefault();
			if (firstIssue == null)
			{
				return;
			}

			var results = await _client.GetRepositoryIssueCommentsAsync(workspaceId, repositorySlug, firstIssue.Id.ToString()).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryIssueCommentAsync(workspaceId, repositorySlug, firstIssue.Id.ToString(), firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

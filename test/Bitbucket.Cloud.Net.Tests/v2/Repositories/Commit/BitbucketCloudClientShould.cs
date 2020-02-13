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
		public async Task GetRepositoryCommitPullRequestsAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryCommitsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryCommitPullRequestsAsync(workspaceId, repositorySlug, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryCommitAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryCommitsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryCommitAsync(workspaceId, repositorySlug, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryCommitCommentsAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryCommitsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryCommitCommentsAsync(workspaceId, repositorySlug, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryCommitCommentAsync(string workspaceId, string repositorySlug)
		{
			var commits = await _client.GetRepositoryCommitsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstCommit = commits.FirstOrDefault();
			if (firstCommit == null)
			{
				return;
			}

			var results = await _client.GetRepositoryCommitCommentsAsync(workspaceId, repositorySlug, firstCommit.Hash).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryCommitCommentAsync(workspaceId, repositorySlug, firstCommit.Hash, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryCommitBuildResultsAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryCommitsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryCommitBuildResultsAsync(workspaceId, repositorySlug, firstResult.Hash).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryCommitBuildResultAsync(string workspaceId, string repositorySlug)
		{
			var commits = await _client.GetRepositoryCommitsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstCommit = commits.FirstOrDefault();
			if (firstCommit == null)
			{
				return;
			}

			var results = await _client.GetRepositoryCommitBuildResultsAsync(workspaceId, repositorySlug, firstCommit.Hash).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryCommitBuildResultAsync(workspaceId, repositorySlug, firstCommit.Hash, firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

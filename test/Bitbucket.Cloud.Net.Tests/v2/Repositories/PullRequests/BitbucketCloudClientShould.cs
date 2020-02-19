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
		public async Task GetRepositoryPullRequestsAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestActivityAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryPullRequestActivityAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryPullRequestAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestCommentsAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryPullRequestCommentsAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestCommentAsync(string workspaceId, string repositorySlug)
		{
			var pullRequests = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstPullRequest = pullRequests.FirstOrDefault();
			if (firstPullRequest == null)
			{
				return;
			}

			var results = await _client.GetRepositoryPullRequestCommentsAsync(workspaceId, repositorySlug, firstPullRequest.Id.ToString()).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryPullRequestCommentAsync(workspaceId, repositorySlug, firstPullRequest.Id.ToString(), firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestCommitsAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryPullRequestCommitsAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestDiffAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			string result = await _client.GetRepositoryPullRequestDiffAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestDiffStatAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryPullRequestDiffStatAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test", "1")]
		public async Task GetRepositoryPullRequestTaskStatusAsync(string workspaceId, string repositorySlug, string taskId)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryPullRequestTaskStatusAsync(workspaceId, repositorySlug, firstResult.Id.ToString(), taskId).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestPatchAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			string result = await _client.GetRepositoryPullRequestPatchAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryPullRequestBuildResultsAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryPullRequestsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryPullRequestBuildResultsAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

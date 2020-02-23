using System.Linq;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Models.v2;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Fact]
		public async Task GetTeamsAsync()
		{
			var result = await _client.GetTeamsAsync(Permissions.Admin).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("test-group")]
		public async Task GetTeamPublicInformationAsync(string teamName)
		{
			var result = await _client.GetTeamPublicInformationAsync(teamName).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("test-group")]
		public async Task GetTeamFollowersAsync(string teamName)
		{
			var result = await _client.GetTeamFollowersAsync(teamName).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("test-group")]
		public async Task GetTeamFollowingAsync(string teamName)
		{
			var result = await _client.GetTeamFollowingAsync(teamName).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetTeamWebhooksAsync(string userName)
		{
			var result = await _client.GetTeamWebhooksAsync(userName).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetTeamWebhookAsync(string userName)
		{
			var results = await _client.GetTeamWebhooksAsync(userName).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetTeamWebhookAsync(userName, firstResult.Uuid.ToString("B")).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetTeamRepositoryPermissionsAsync(string userName)
		{
			var result = await _client.GetTeamRepositoryPermissionsAsync(userName).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetTeamRepositoryPermissionsForRepositoryAsync(string userName, string repositorySlug)
		{
			var result = await _client.GetTeamRepositoryPermissionsAsync(userName, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetTeamProjectsAsync()
		{
			var results = await _client.GetTeamsAsync(Permissions.Admin).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetTeamProjectsAsync(firstResult.Uuid.ToString("B")).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetTeamProjectAsync()
		{
			var teams = await _client.GetTeamsAsync(Permissions.Admin).ConfigureAwait(false);
			var firstTeam = teams.FirstOrDefault();
			if (firstTeam == null)
			{
				return;
			}

			var results = await _client.GetTeamProjectsAsync(firstTeam.Uuid.ToString("B")).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetTeamProjectAsync(firstTeam.Uuid.ToString("B"), firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve")]
		public async Task GetTeamRepositoriesAsync(string userName)
		{
			var result = await _client.GetTeamRepositoriesAsync(userName).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("test-group")]
		public async Task SearchTeamCodeAsync(string teamName)
		{
			var result = await _client.SearchTeamCodeAsync(teamName, "\"something\"").ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

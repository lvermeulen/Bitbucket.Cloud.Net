using System;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test", "{9f5c3b89-40e6-4a7c-9429-4c8072ed571e}")]
		public async Task GetRepositoryPipelineAsync(string workspaceId, string repositorySlug, string pipelineUuid)
		{
			var result = await _client.GetRepositoryPipelineAsync(workspaceId, repositorySlug, Guid.Parse(pipelineUuid)).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}

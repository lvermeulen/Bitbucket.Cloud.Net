using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetDeploymentsUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/deployments");

		private IFlurlRequest GetDeploymentsUrl(string workspaceId, string repositorySlug, string path) => GetDeploymentsUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<IEnumerable<Deployment>> GetRepositoryDeploymentsAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetDeploymentsUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Deployment>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Deployment> GetRepositoryDeploymentAsync(string workspaceId, string repositorySlug, Guid deploymentUuid)
		{
			return await GetDeploymentsUrl(workspaceId, repositorySlug, deploymentUuid.ToString("B"))
				.GetJsonAsync<Deployment>()
				.ConfigureAwait(false);
		}
	}
}

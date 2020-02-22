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
		private IFlurlRequest GetDeploymentsConfigUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/deployments_config");

		private IFlurlRequest GetDeploymentsConfigUrl(string workspaceId, string repositorySlug, string path) => GetDeploymentsConfigUrl(workspaceId, repositorySlug)
			.AppendPathSegment(path);

		public async Task<Variable> CreateRepositoryDeploymentsConfigVariableAsync(string workspaceId, string repositorySlug, Guid environmentUuid, Variable variable)
		{
			var response = await GetDeploymentsConfigUrl(workspaceId, repositorySlug, $"/environments/{environmentUuid:B}/variables")
				.PostJsonAsync(variable)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Variable>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Variable>> GetRepositoryDeploymentsConfigVariablesAsync(string workspaceId, string repositorySlug, Guid environmentUuid, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetDeploymentsConfigUrl(workspaceId, repositorySlug, $"/environments/{environmentUuid:B}/variables")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Variable>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Variable> UpdateRepositoryDeploymentsConfigVariableAsync(string workspaceId, string repositorySlug, Guid environmentUuid, Guid variableUuid, Variable variable)
		{
			var response = await GetDeploymentsConfigUrl(workspaceId, repositorySlug, $"/environments/{environmentUuid:B}/variables/{variableUuid:B}")
				.PutJsonAsync(variable)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Variable>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryDeploymentsConfigVariableAsync(string workspaceId, string repositorySlug, Guid environmentUuid, Guid variableUuid)
		{
			var response = await GetDeploymentsConfigUrl(workspaceId, repositorySlug, $"/environments/{environmentUuid:B}/variables/{variableUuid:B}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

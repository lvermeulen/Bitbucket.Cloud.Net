using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetPipelinesUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/pipelines");

		private IFlurlRequest GetPipelinesUrl(string workspaceId, string repositorySlug, Guid pipelineUuid) => GetPipelinesUrl(workspaceId, repositorySlug)
			.AppendPathSegment($"/pipelines/{pipelineUuid:B}");

		private IFlurlRequest GetPipelineStepsUrl(string workspaceId, string repositorySlug, Guid pipelineUuid) => GetPipelinesUrl(workspaceId, repositorySlug, pipelineUuid)
			.AppendPathSegment("/steps");

		private IFlurlRequest GetPipelineStepUrl(string workspaceId, string repositorySlug, Guid pipelineUuid, string stepId) => GetPipelineStepsUrl(workspaceId, repositorySlug, pipelineUuid)
			.AppendPathSegment($"/{stepId}");

		public async Task<IEnumerable<Pipeline>> GetRepositoryPipelinesAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPipelinesUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Pipeline>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Pipeline> GetRepositoryPipelineAsync(string workspaceId, string repositorySlug, Guid pipelineUuid)
		{
			return await GetPipelinesUrl(workspaceId, repositorySlug, pipelineUuid)
				.GetJsonAsync<Pipeline>()
				.ConfigureAwait(false);
		}

		public async Task<bool> StopRepositoryPipelineAsync(string workspaceId, string repositorySlug, Guid pipelineUuid)
		{
			var response = await GetPipelinesUrl(workspaceId, repositorySlug, pipelineUuid)
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<PipelineStep>> GetRepositoryPipelineStepsAsync(string workspaceId, string repositorySlug, Guid pipelineUuid, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPipelineStepsUrl(workspaceId, repositorySlug, pipelineUuid)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PipelineStep>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<PipelineStep> GetRepositoryPipelineStepAsync(string workspaceId, string repositorySlug, Guid pipelineUuid, string stepId)
		{
			return await GetPipelineStepUrl(workspaceId, repositorySlug, pipelineUuid, stepId)
				.GetJsonAsync<PipelineStep>()
				.ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryPipelineStepLogsAsync(string workspaceId, string repositorySlug, Guid pipelineUuid, string stepId)
		{
			return await GetPipelineStepUrl(workspaceId, repositorySlug, pipelineUuid, stepId)
				.AppendPathSegment("/log")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryPipelineStepLogsAsync(string workspaceId, string repositorySlug, Guid pipelineUuid, string stepId, string logId)
		{
			return await GetPipelineStepUrl(workspaceId, repositorySlug, pipelineUuid, stepId)
				.AppendPathSegment($"/logs/{logId}")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryPipelineStepTestReportsAsync(string workspaceId, string repositorySlug, Guid pipelineUuid, string stepId)
		{
			return await GetPipelineStepUrl(workspaceId, repositorySlug, pipelineUuid, stepId)
				.AppendPathSegment("/test_reports")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryPipelineStepTestCasesAsync(string workspaceId, string repositorySlug, Guid pipelineUuid, string stepId)
		{
			return await GetPipelineStepUrl(workspaceId, repositorySlug, pipelineUuid, stepId)
				.AppendPathSegment("/test_reports/test_cases")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<string> GetRepositoryPipelineStepTestCasesAsync(string workspaceId, string repositorySlug, Guid pipelineUuid, string stepId, string testCaseId)
		{
			return await GetPipelineStepUrl(workspaceId, repositorySlug, pipelineUuid, stepId)
				.AppendPathSegment($"/test_reports/test_cases/{testCaseId}/test_case_reasons")
				.GetStringAsync()
				.ConfigureAwait(false);
		}
	}
}

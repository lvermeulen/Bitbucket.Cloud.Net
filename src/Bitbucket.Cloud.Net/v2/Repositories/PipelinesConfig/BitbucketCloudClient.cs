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
		private IFlurlRequest GetPipelinesConfigUrl(string workspaceId, string repositorySlug) => GetBaseUrl($"2.0/repositories/{workspaceId}/{repositorySlug}/pipelines_config");

		private IFlurlRequest GetPipelinesConfigSchedulesUrl(string workspaceId, string repositorySlug) => GetPipelinesConfigUrl(workspaceId, repositorySlug)
			.AppendPathSegment("/schedules");

		private IFlurlRequest GetPipelinesConfigSchedulesUrl(string workspaceId, string repositorySlug, string scheduleId) => GetPipelinesConfigSchedulesUrl(workspaceId, repositorySlug)
			.AppendPathSegment($"/{scheduleId}");

		private IFlurlRequest GetPipelinesConfigSshUrl(string workspaceId, string repositorySlug) => GetPipelinesConfigUrl(workspaceId, repositorySlug).AppendPathSegment("/ssh");

		private IFlurlRequest GetPipelinesConfigSshKnownHostsUrl(string workspaceId, string repositorySlug) => GetPipelinesConfigSshUrl(workspaceId, repositorySlug).AppendPathSegment("/known_hosts");

		private IFlurlRequest GetPipelinesConfigSshKnownHostsUrl(string workspaceId, string repositorySlug, string knownHostUuid) => GetPipelinesConfigSshKnownHostsUrl(workspaceId, repositorySlug).AppendPathSegment($"/{knownHostUuid}");

		private IFlurlRequest GetPipelinesConfigVariablesUrl(string workspaceId, string repositorySlug) => GetPipelinesConfigUrl(workspaceId, repositorySlug)
			.AppendPathSegment("/variables");

		private IFlurlRequest GetPipelinesConfigVariablesUrl(string workspaceId, string repositorySlug, string variableId) => GetPipelinesConfigVariablesUrl(workspaceId, repositorySlug)
			.AppendPathSegment($"/{variableId}");

		public async Task<PipelinesConfig> GetRepositoryPipelinesConfigAsync(string workspaceId, string repositorySlug)
		{
			return await GetPipelinesConfigUrl(workspaceId, repositorySlug)
				.GetJsonAsync<PipelinesConfig>()
				.ConfigureAwait(false);
		}

		public async Task<BuildNumber> SetRepositoryNextBuildNumberAsync(string workspaceId, string repositorySlug, BuildNumber nextBuildNumber)
		{
			var response = await GetPipelinesConfigUrl(workspaceId, repositorySlug)
				.AppendPathSegment("/build_number")
				.PutJsonAsync(nextBuildNumber)
				.ConfigureAwait(false);

			return await HandleResponseAsync<BuildNumber>(response).ConfigureAwait(false);
		}

		public async Task<PipelineSchedule> CreateRepositoryPipelinesConfigScheduleAsync(string workspaceId, string repositorySlug, PipelineSchedule schedule)
		{
			var response = await GetPipelinesConfigSchedulesUrl(workspaceId, repositorySlug)
				.PostJsonAsync(schedule)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PipelineSchedule>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<PipelineSchedule>> GetRepositoryPipelinesConfigSchedulesAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPipelinesConfigSchedulesUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PipelineSchedule>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<PipelineSchedule> UpdateRepositoryPipelinesConfigScheduleAsync(string workspaceId, string repositorySlug, string scheduleId, PipelineSchedule schedule)
		{
			var response = await GetPipelinesConfigSchedulesUrl(workspaceId, repositorySlug, scheduleId)
				.PutJsonAsync(schedule)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PipelineSchedule>(response).ConfigureAwait(false);
		}

		public async Task<PipelineSchedule> GetRepositoryPipelinesConfigScheduleAsync(string workspaceId, string repositorySlug, string scheduleId)
		{
			return await GetPipelinesConfigSchedulesUrl(workspaceId, repositorySlug)
				.AppendPathSegment($"/{scheduleId}")
				.GetJsonAsync<PipelineSchedule>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryPipelinesConfigScheduleAsync(string workspaceId, string repositorySlug, string scheduleId)
		{
			var response = await GetPipelinesConfigSchedulesUrl(workspaceId, repositorySlug, scheduleId)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<PipelineScheduleExecution>> GetRepositoryPipelinesConfigScheduleExecutionsAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPipelinesConfigSchedulesUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PipelineScheduleExecution>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<PipelineSshKey> UpdateRepositoryPipelinesConfigSshKeyAsync(string workspaceId, string repositorySlug, PipelineSshKey sshKey)
		{
			var response = await GetPipelinesConfigSshUrl(workspaceId, repositorySlug)
				.PutJsonAsync(sshKey)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PipelineSshKey>(response).ConfigureAwait(false);
		}

		public async Task<PipelineSshKey> GetRepositoryPipelinesConfigSshKeyAsync(string workspaceId, string repositorySlug)
		{
			return await GetPipelinesConfigSshUrl(workspaceId, repositorySlug)
				.GetJsonAsync<PipelineSshKey>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryPipelinesConfigSshKeyAsync(string workspaceId, string repositorySlug)
		{
			var response = await GetPipelinesConfigSshUrl(workspaceId, repositorySlug)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<PipelineKnownHost> CreateRepositoryPipelinesConfigKnownHostAsync(string workspaceId, string repositorySlug, PipelineKnownHost knownHost)
		{
			var response = await GetPipelinesConfigSshKnownHostsUrl(workspaceId, repositorySlug)
				.PostJsonAsync(knownHost)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PipelineKnownHost>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<PipelineKnownHost>> GetRepositoryPipelinesConfigKnownHostsAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPipelinesConfigSshKnownHostsUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PipelineKnownHost>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<PipelineKnownHost> UpdateRepositoryPipelinesConfigKnownHostAsync(string workspaceId, string repositorySlug, string knownHostUuid, PipelineKnownHost knownHost)
		{
			var response = await GetPipelinesConfigSshKnownHostsUrl(workspaceId, repositorySlug, knownHostUuid)
				.PutJsonAsync(knownHost)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PipelineKnownHost>(response).ConfigureAwait(false);
		}

		public async Task<PipelineKnownHost> GetRepositoryPipelinesConfigKnownHostAsync(string workspaceId, string repositorySlug, string knownHostUuid)
		{
			return await GetPipelinesConfigSshKnownHostsUrl(workspaceId, repositorySlug, knownHostUuid)
				.GetJsonAsync<PipelineKnownHost>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryPipelinesConfigKnownHostAsync(string workspaceId, string repositorySlug, string knownHostUuid)
		{
			var response = await GetPipelinesConfigSshKnownHostsUrl(workspaceId, repositorySlug, knownHostUuid)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<Variable> CreateRepositoryPipelinesConfigVariableAsync(string workspaceId, string repositorySlug, Variable variable)
		{
			var response = await GetPipelinesConfigVariablesUrl(workspaceId, repositorySlug)
				.PostJsonAsync(variable)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Variable>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Variable>> GetRepositoryPipelinesConfigVariablesAsync(string workspaceId, string repositorySlug, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPipelinesConfigVariablesUrl(workspaceId, repositorySlug)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Variable>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Variable> UpdateRepositoryPipelinesConfigVariableAsync(string workspaceId, string repositorySlug, string variableId, Variable variable)
		{
			var response = await GetPipelinesConfigVariablesUrl(workspaceId, repositorySlug, variableId)
				.PutJsonAsync(variable)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Variable>(response).ConfigureAwait(false);
		}

		public async Task<Variable> GetRepositoryPipelinesConfigVariableAsync(string workspaceId, string repositorySlug, string variableId)
		{
			return await GetPipelinesConfigVariablesUrl(workspaceId, repositorySlug, variableId)
				.GetJsonAsync<Variable>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteRepositoryPipelinesConfigVariableAsync(string workspaceId, string repositorySlug, string variableId)
		{
			var response = await GetPipelinesConfigVariablesUrl(workspaceId, repositorySlug, variableId)
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync<bool>(response).ConfigureAwait(false);
		}
	}
}

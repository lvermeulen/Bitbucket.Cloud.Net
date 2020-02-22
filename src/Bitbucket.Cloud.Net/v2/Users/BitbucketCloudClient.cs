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
		private IFlurlRequest GetUsersUrl() => GetBaseUrl("2.0/users");

		public async Task<User> GetUserByNameAsync(string userName)
		{
			return await GetUsersUrl()
				.AppendPathSegment($"/{userName}")
				.GetJsonAsync<User>()
				.ConfigureAwait(false);
		}

		public async Task<Webhook> CreateUserWebhookAsync(string userName, Webhook webhook)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/hooks")
				.PostJsonAsync(webhook)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Webhook>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Webhook>> GetUserWebhooksAsync(string userName, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetUsersUrl()
						.AppendPathSegment($"/{userName}/hooks")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Webhook>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Webhook> UpdateUserWebhookAsync(string userName, string webhookId, Webhook webhook)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/hooks/{webhookId}")
				.PutJsonAsync(webhook)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Webhook>(response).ConfigureAwait(false);
		}

		public async Task<Webhook> GetUserWebhookAsync(string userName, string webhookId)
		{
			return await GetUsersUrl()
				.AppendPathSegment($"/{userName}/hooks/{webhookId}")
				.GetJsonAsync<Webhook>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteUserWebhookAsync(string userName, string webhookId)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/hooks/{webhookId}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync<bool>(response).ConfigureAwait(false);
		}

		public async Task<Variable> CreateUserVariableAsync(string userName, Variable variable)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/pipelines_config/variables/")
				.PostJsonAsync(variable)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Variable>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Variable>> GetUserVariablesAsync(string userName, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetUsersUrl()
						.AppendPathSegment($"/{userName}/pipelines_config/variables/")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Variable>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<Variable> UpdateUserVariableAsync(string userName, string variableId, Variable variable)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/pipelines_config/variables/{variableId}")
				.PutJsonAsync(variable)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Variable>(response).ConfigureAwait(false);
		}

		public async Task<Variable> GetUserVariableAsync(string userName, string variableId)
		{
			return await GetUsersUrl()
				.AppendPathSegment($"/{userName}/pipelines_config/variables/{variableId}")
				.GetJsonAsync<Variable>()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteUserVariableAsync(string userName, string variableId)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/pipelines_config/variables/{variableId}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync<bool>(response).ConfigureAwait(false);
		}

		public async Task<bool> UpdateUserApplicationPropertyValueAsync(string userName, string appKey, string propertyName, string propertyValue)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/properties/{appKey}/{propertyName}")
				.PutStringAsync(propertyValue)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<string> GetUserApplicationPropertyValueAsync(string userName, string appKey, string propertyName)
		{
			return await GetUsersUrl()
				.AppendPathSegment($"/{userName}/properties/{appKey}/{propertyName}")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<bool> DeleteUserApplicationPropertyValueAsync(string userName, string appKey, string propertyName)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/properties/{appKey}/{propertyName}")
				.DeleteAsync()
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Repository>> GetUserRepositoriesAsync(string userName, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetUsersUrl()
						.AppendPathSegment($"/{userName}/repositories")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<Repository>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<SearchResult>> SearchCodeAsync(string userName, string searchQuery, int? maxPages = null, int? page = null, int? pageLength = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				["search_query"] = searchQuery,
				["page"] = page,
				["pagelen"] = pageLength
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetUsersUrl()
						.AppendPathSegment($"/{userName}/search/code")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<SearchResult>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}

		public async Task<SshKey> CreateUserSshKeyAsync(string userName, SshKey sshKey)
		{
			var response = await GetUsersUrl()
				.AppendPathSegment($"/{userName}/ssh-keys")
				.PostJsonAsync(sshKey)
				.ConfigureAwait(false);

			return await HandleResponseAsync<SshKey>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<SshKey>> GetUserSshKeysAsync(string userName, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetUsersUrl()
						.AppendPathSegment($"/{userName}/ssh-keys")
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<SshKey>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

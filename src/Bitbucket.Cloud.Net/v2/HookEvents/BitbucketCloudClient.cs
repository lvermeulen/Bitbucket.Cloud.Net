using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Common.Models;
using Bitbucket.Cloud.Net.Models.v2;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetHookEventsUrl() => GetBaseUrl("2.0/hook_events");

		private IFlurlRequest GetHookEventsUrl(string path) => GetHookEventsUrl().AppendPathSegment(path);

		public async Task<HookEventSubjects> GetHookEventsAsync()
		{
			return await GetHookEventsUrl()
				.GetJsonAsync<HookEventSubjects>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<HookEvent>> GetHookEventsAsync(HookEventSubjectTypes hookEventSubjectType, int? maxPages = null)
		{
			var queryParamValues = new Dictionary<string, object>();

			var subjectType = HookEventSubjectTypeConverter.ConvertToString(hookEventSubjectType);
			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetHookEventsUrl(subjectType)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<HookEvent>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

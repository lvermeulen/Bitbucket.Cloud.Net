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
		private IFlurlRequest GetPullRequestsUrl() => GetBaseUrl("2.0/pullrequests");

		private IFlurlRequest GetPullRequestsUrl(string userName) => GetPullRequestsUrl().AppendPathSegment(userName);

		public async Task<IEnumerable<PullRequest>> GetPullRequestsAsync(string userName, int? maxPages = null, PullRequestStates? state = null, string q = null, string sort = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(state)] = PullRequestStatesConverter.ToString(state),
				[nameof(q)] = q,
				[nameof(sort)] = sort
			};

			return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
					await GetPullRequestsUrl(userName)
						.SetQueryParams(qpv)
						.GetJsonAsync<PagedResults<PullRequest>>()
						.ConfigureAwait(false))
				.ConfigureAwait(false);
		}
	}
}

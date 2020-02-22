using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetUserInvitationsUrl() => GetBaseUrl("1.0/users");

		private IFlurlRequest GetUserInvitationsUrl(string path) => GetUserInvitationsUrl().AppendPathSegment(path).AppendPathSegment("/invitations");

		public async Task<string> GetPendingInvitationsAsync(Guid uuid)
		{
			return await GetUserInvitationsUrl()
				.AppendPathSegment(uuid.ToString("B"))
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<bool> InviteGroupAsync(string accountName, string emailAddress, string groupSlug)
		{
			var data = new
			{
				email = emailAddress,
				group_slug = groupSlug
			};

			var response = await GetUserInvitationsUrl(accountName)
				.WithHeader("Content-Type", "application/json")
				.PutJsonAsync(data)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> DeletePendingInvitationsByEmailAddressAsync(string accountName, string emailAddress)
		{
			var data = new
			{
				email = emailAddress
			};

			var response = await GetUserInvitationsUrl(accountName)
				.WithHeader("Content-Type", "application/json")
				.SendJsonAsync(HttpMethod.Delete, data)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> DeletePendingInvitationsByGroupAsync(string accountName, string emailAddress, string groupSlug)
		{
			var data = new
			{
				email = emailAddress,
				group_slug = groupSlug
			};

			var response = await GetUserInvitationsUrl(accountName)
				.WithHeader("Content-Type", "application/json")
				.SendJsonAsync(HttpMethod.Delete, data)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}

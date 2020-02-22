using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Models.v1;
using Flurl.Http;
using Permissions = Bitbucket.Cloud.Net.Models.v2.Permissions;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private IFlurlRequest GetInvitationsUrl() => GetBaseUrl("1.0/invitations");

		public async Task<Invitation> InviteUserAsync(string accountName, string repositorySlug, Permissions permission, string emailAddress)
		{
			var data = new
			{
				permission = PermissionsConverter.ToString(permission),
				email = emailAddress
			};

			var response = await GetInvitationsUrl()
				.AppendPathSegment(accountName)
				.AppendPathSegment(repositorySlug)
				.PostUrlEncodedAsync(data)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Invitation>(response).ConfigureAwait(false);
		}
	}
}

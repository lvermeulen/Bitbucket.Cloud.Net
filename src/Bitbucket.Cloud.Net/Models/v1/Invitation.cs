using System;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.Models.v2;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v1
{
	public class Invitation
	{
		[JsonProperty("sent_on")]
		public DateTime? SentOn { get; set; }

		[JsonConverter(typeof(PermissionsConverter))]
		public Permissions Permission { get; set; }

		[JsonProperty("invited_by")]
		public User InvitedBy { get; set; }

		public Repository Repository { get; set; }
		public string Email { get; set; }
	}
}

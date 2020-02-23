using System;
using System.Collections.Generic;
using Bitbucket.Cloud.Net.Common.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Webhook
	{
		[JsonProperty("read_only")]
		public bool? ReadOnly { get; set; }

		public string Description { get; set; }
		public Links Links { get; set; }
		public string Url { get; set; }

		[JsonProperty("created_at")]
		[JsonConverter(typeof(IsoDateTimeConverter))]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("skip_cert_verification")]
		public bool SkipCertVerification { get; set; }

		public string Source { get; set; }

		[JsonProperty("history_enabled")]
		public bool HistoryEnabled { get; set; }

		public bool Active { get; set; }
		public User Subject { get; set; }
		public string Type { get; set; }

		[JsonConverter(typeof(WebhookEventsConverter))]
		public IEnumerable<WebhookEvents> Events { get; set; }

		public Guid Uuid { get; set; }
	}
}

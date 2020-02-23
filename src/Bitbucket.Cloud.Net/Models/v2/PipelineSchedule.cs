using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PipelineSchedule
	{
		public string Type { get; set; }
		public Guid Uuid { get; set; }
		public bool Enabled { get; set; }
		public PipelineSchedulePattern Pattern { get; set; }

		[JsonProperty("cron_pattern")]
		public string CronPattern { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn { get; set; }
	}
}

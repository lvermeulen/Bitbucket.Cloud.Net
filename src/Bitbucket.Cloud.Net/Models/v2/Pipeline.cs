using System;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class Pipeline
	{
		public string Type { get; set; }
		public Guid Uuid { get; set; }
		public RepositoryInfo Repository { get; set; }
		public PipelineState State { get; set; }

		[JsonProperty("build_number")]
		public int BuildNumber { get; set; }

		public AccountInfo Creator { get; set; }

		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		[JsonProperty("completed_on")]
		public DateTime? CompletedOn { get; set; }

		public Target Target { get; set; }
		public TypedName Trigger { get; set; }

		[JsonProperty("run_number")]
		public int RunNumber { get; set; }

		[JsonProperty("duration_in_seconds")]
		public int DurationInSeconds { get; set; }

		[JsonProperty("build_seconds_used")]
		public int BuildSecondsUsed { get; set; }

		public bool Expired { get; set; }
		public Links Links { get; set; }

		[JsonProperty("has_variables")]
		public bool HasVariables { get; set; }
	}
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PipelineStep
	{
		public string Type { get; set; }
		public Guid Uuid { get; set; }

		[JsonProperty("started_on")]
		public DateTime? StartedOn { get; set; }

		[JsonProperty("completed_on")]
		public DateTime? CompletedOn { get; set; }

		public DockerImage Image { get; set; }

		[JsonProperty("setup_commands")]
		public IEnumerable<PipelineCommand> SetupCommands { get; set; }

		[JsonProperty("script_commands")]
		public IEnumerable<PipelineCommand> ScriptCommands { get; set; }
	}
}

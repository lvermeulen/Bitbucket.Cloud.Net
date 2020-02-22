namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PipelineSchedulePattern
	{
		public string PatternType { get; set; } // branches, tags, bookmarks, default, custom
		public string Pattern { get; set; }
	}
}
namespace Bitbucket.Cloud.Net.Models
{
	public class PipelineSchedulePattern
	{
		public string PatternType { get; set; } // branches, tags, bookmarks, default, custom
		public string Pattern { get; set; }
	}
}
namespace Bitbucket.Cloud.Net.Models
{
	public class HookEventSubjects
	{
		public HasEventsLink User { get; set; }
		public HasEventsLink Repository { get; set; }
		public HasEventsLink Team { get; set; }
	}
}

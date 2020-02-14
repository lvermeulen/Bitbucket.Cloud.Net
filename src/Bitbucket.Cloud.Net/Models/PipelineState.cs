namespace Bitbucket.Cloud.Net.Models
{
	public class PipelineState
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public TypedName Result { get; set; }
	}
}
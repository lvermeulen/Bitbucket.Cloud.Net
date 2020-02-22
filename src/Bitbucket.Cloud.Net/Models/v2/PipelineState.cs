namespace Bitbucket.Cloud.Net.Models.v2
{
	public class PipelineState
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public TypedName Result { get; set; }
	}
}
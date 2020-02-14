namespace Bitbucket.Cloud.Net.Models
{
    public class Branch : TypedName
    {
        public HasHash Target { get; set; }
    }
}
namespace Bitbucket.Cloud.Net.Models
{
    public class Branch : TypedBranchName
    {
        public HasHash Target { get; set; }
    }
}
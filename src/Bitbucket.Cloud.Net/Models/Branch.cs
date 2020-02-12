namespace Bitbucket.Cloud.Net.Models
{
    public class Branch : BranchName
    {
        public string Type { get; set; }
        public HasHash Target { get; set; }
    }
}
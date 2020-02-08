namespace Bitbucket.Cloud.Net.Models
{
    public class Branch
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public HasHash Target { get; set; }
    }
}
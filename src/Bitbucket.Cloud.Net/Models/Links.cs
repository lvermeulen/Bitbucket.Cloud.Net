using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Models
{
    public class Links : OwnerLinks
    {
        public Link Followers { get; set; }
        public Link Following { get; set; }
        public Link Repositories { get; set; }
        public Link Watchers { get; set; }
        public Link Branches { get; set; }
        public Link Tags { get; set; }
        public Link Commits { get; set; }
        public List<CloneLink> Clone { get; set; }
        public Link Source { get; set; }
        public Link Hooks { get; set; }
        public Link Forks { get; set; }
        public Link Downloads { get; set; }
        public Link Issues { get; set; }
        public Link PullRequests { get; set; }
        public Link Comments { get; set; }
        public Link Patch { get; set; }
        public Link Diff { get; set; }
        public Link Diffstat { get; set; }
        public Link Approve { get; set; }
        public Link Decline { get; set; }
        public Link Statuses { get; set; }
        public Link Merge { get; set; }
        public Link Activity { get; set; }
        public Link Code { get; set; }
        public Link Meta { get; set; }
        public Link History { get; set; }

    }
}
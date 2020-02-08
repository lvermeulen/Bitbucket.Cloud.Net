using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models;

namespace Bitbucket.Cloud.Net.Common.Converters
{
    public class WebhookEventsConverter : JsonEnumConverter<WebhookEvents>
    {
        private static readonly Dictionary<WebhookEvents, string> s_map = new Dictionary<WebhookEvents, string>
        {
            [WebhookEvents.PullrequestUnapproved] = "pullrequest:unapproved",
            [WebhookEvents.IssueCommentCreated] = "issue:comment_created",
            [WebhookEvents.PullrequestApproved] = "pullrequest:approved",
            [WebhookEvents.RepoCreated] = "repo:created",
            [WebhookEvents.RepoDeleted] = "repo:deleted",
            [WebhookEvents.RepoImported] = "repo:imported",
            [WebhookEvents.PullrequestCommentUpdated] = "pullrequest:comment_updated",
            [WebhookEvents.IssueUpdated] = "issue:updated",
            [WebhookEvents.ProjectUpdated] = "project:updated",
            [WebhookEvents.PullrequestCommentCreated] = "pullrequest:comment_created",
            [WebhookEvents.RepoCommitStatusUpdated] = "repo:commit_status_updated",
            [WebhookEvents.PullrequestUpdated] = "pullrequest:updated",
            [WebhookEvents.IssueCreated] = "issue:created",
            [WebhookEvents.RepoFork] = "repo:fork",
            [WebhookEvents.PullrequestCommentDeleted] = "pullrequest:comment_deleted",
            [WebhookEvents.RepoCommitStatusCreated] = "repo:commit_status_created",
            [WebhookEvents.RepoUpdated] = "repo:updated",
            [WebhookEvents.PullrequestRejected] = "pullrequest:rejected",
            [WebhookEvents.PullrequestFulfilled] = "pullrequest:fulfilled",
            [WebhookEvents.RepoPush] = "repo:push",
            [WebhookEvents.PullrequestCreated] = "pullrequest:created",
            [WebhookEvents.RepoTransfer] = "repo:transfer",
            [WebhookEvents.RepoCommitCommentCreated] = "repo:commit_comment_created"
        };

        protected override string ConvertToString(WebhookEvents value)
        {
            if (!s_map.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown webhook event: {value}");
            }

            return result;
        }

        protected override WebhookEvents ConvertFromString(string s)
        {
            var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<WebhookEvents, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown webhook event: {s}");
            }

            return pair.Key;
        }
    }
}

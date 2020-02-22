using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
    public class IssueJobStatusConverter : JsonEnumConverter<IssueJobStatuses>
    {
        private static readonly Dictionary<IssueJobStatuses, string> s_map = new Dictionary<IssueJobStatuses, string>
        {
            [IssueJobStatuses.Accepted] = "ACCEPTED",
            [IssueJobStatuses.Started] = "STARTED",
            [IssueJobStatuses.Running] = "RUNNING",
            [IssueJobStatuses.Failure] = "FAILURE"
        };

        protected override string ConvertToString(IssueJobStatuses value)
        {
            if (!s_map.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown issue job status: {value}");
            }

            return result;
        }

        protected override IssueJobStatuses ConvertFromString(string s)
        {
            var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<IssueJobStatuses, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown issue job status: {s}");
            }

            return pair.Key;
        }
    }
}

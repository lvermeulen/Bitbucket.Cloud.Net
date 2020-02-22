using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
    public class BranchMatchKindsConverter : JsonEnumConverter<BranchMatchKinds>
    {
        private static readonly Dictionary<BranchMatchKinds, string> s_map = new Dictionary<BranchMatchKinds, string>
        {
            [BranchMatchKinds.BranchingModel] = "branching_model",
            [BranchMatchKinds.Glob] = "glob"
        };

        protected override string ConvertToString(BranchMatchKinds value)
        {
            if (!s_map.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown branch match kind: {value}");
            }

            return result;
        }

        protected override BranchMatchKinds ConvertFromString(string s)
        {
            var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<BranchMatchKinds, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown branch match kind: {s}");
            }

            return pair.Key;
        }
    }
}

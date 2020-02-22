using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
    public class ScmConverter : JsonEnumConverter<Scm>
    {
        private static readonly Dictionary<Scm, string> s_map = new Dictionary<Scm, string>
        {
            [Scm.Hg] = "hg",
            [Scm.Git] = "git"
        };

        protected override string ConvertToString(Scm value)
        {
            if (!s_map.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown scm: {value}");
            }

            return result;
        }

        protected override Scm ConvertFromString(string s)
        {
            var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<Scm, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown scm: {s}");
            }

            return pair.Key;
        }
    }
}

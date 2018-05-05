using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.v2.Repositories.Models;

namespace Bitbucket.Cloud.Net.v2.Converters
{
    public class ScmConverter : JsonEnumConverter<Scm>
    {
        private static readonly Dictionary<Scm, string> s_stringByScm = new Dictionary<Scm, string>
        {
            [Scm.Hg] = "hg",
            [Scm.Git] = "git"
        };

        protected override string ConvertToString(Scm value)
        {
            if (!s_stringByScm.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown scm: {value}");
            }

            return result;
        }

        protected override Scm ConvertFromString(string s)
        {
            var pair = s_stringByScm.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<Scm, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown scm: {s}");
            }

            return pair.Key;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Common.Converters;
using Bitbucket.Cloud.Net.v2.Repositories.Models;

namespace Bitbucket.Cloud.Net.v2.Converters
{
    public class ForkPolicyConverter : JsonEnumConverter<ForkPolicies>
    {
        private static readonly Dictionary<ForkPolicies, string> s_stringByForkPolicy = new Dictionary<ForkPolicies, string>
        {
            [ForkPolicies.AllowForks] = "allow_forks",
            [ForkPolicies.NoPublicForks] = "no_public_forks",
            [ForkPolicies.NoForks] = "no_forks"
        };

        protected override string ConvertToString(ForkPolicies value)
        {
            if (!s_stringByForkPolicy.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown fork policy: {value}");
            }

            return result;
        }

        protected override ForkPolicies ConvertFromString(string s)
        {
            var pair = s_stringByForkPolicy.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<ForkPolicies, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown fork policy: {s}");
            }

            return pair.Key;
        }
    }
}

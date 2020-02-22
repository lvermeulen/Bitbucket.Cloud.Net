using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public class BranchRestrictionKindsConverter : JsonEnumConverter<BranchRestrictionKinds>
	{
		private static readonly Dictionary<BranchRestrictionKinds, string> s_map = new Dictionary<BranchRestrictionKinds, string>
		{
			[BranchRestrictionKinds.RequireTasksToBeCompleted] = "require_tasks_to_be_completed",
			[BranchRestrictionKinds.Force] = "force",
			[BranchRestrictionKinds.RestrictMerges] = "restrict_merges",
			[BranchRestrictionKinds.EnforceMergeChecks] = "enforce_merge_checks",
			[BranchRestrictionKinds.RequireApprovalsToMerge] = "require_approvals_to_merge",
			[BranchRestrictionKinds.Delete] = "delete",
			[BranchRestrictionKinds.RequireAllDependenciesMerged] = "require_all_dependencies_merged",
			[BranchRestrictionKinds.Push] = "push",
			[BranchRestrictionKinds.RequirePassingBuildsToMerge] = "require_passing_builds_to_merge",
			[BranchRestrictionKinds.ResetPullRequestApprovalsOnChange] = "reset_pullrequest_approvals_on_change",
			[BranchRestrictionKinds.RequireDefaultReviewerApprovalsToMerge] = "require_default_reviewer_approvals_to_merge"
		};

		protected override string ConvertToString(BranchRestrictionKinds value)
		{
			if (!s_map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown branch restriction kind: {value}");
			}

			return result;
		}

		protected override BranchRestrictionKinds ConvertFromString(string s)
		{
			var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<BranchRestrictionKinds, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown branch restriction kind: {s}");
			}

			return pair.Key;
		}
	}
}

namespace Bitbucket.Cloud.Net.Models.v2
{
	public enum BranchRestrictionKinds
	{
		RequireTasksToBeCompleted,
		Force,
		RestrictMerges,
		EnforceMergeChecks,
		RequireApprovalsToMerge,
		Delete,
		RequireAllDependenciesMerged,
		Push,
		RequirePassingBuildsToMerge,
		ResetPullRequestApprovalsOnChange,
		RequireDefaultReviewerApprovalsToMerge
	}
}

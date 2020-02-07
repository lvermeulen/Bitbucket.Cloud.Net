namespace Bitbucket.Cloud.Net.Models
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
		ResetPullrequestApprovalsOnChange,
		RequireDefaultReviewerApprovalsToMerge
	}
}

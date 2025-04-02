namespace Domain.Workflows;

public enum WorkflowTrigger
{
    OnPush,
    OnPullRequest,
    OnRelease,
    Scheduled,
}
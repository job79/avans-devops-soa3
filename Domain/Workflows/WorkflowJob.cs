namespace Domain.Workflows;

// Chain of Responsibility pattern

public abstract class WorkflowJob
{
    public WorkflowJob? Next { get; }

    protected WorkflowJob(WorkflowJob? nextJob)
    {
        this.Next = nextJob;
    }

    public abstract WorkflowResult Run();
    
    public WorkflowResult RunNext()
    {
        if (this.Next == null)
        {
            return new WorkflowResult(true);
        }
        return this.Next.Run();
    }
}
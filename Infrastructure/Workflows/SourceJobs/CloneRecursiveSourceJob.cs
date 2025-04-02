using Domain.Workflows;

namespace Infrastructure.Workflows.SourceJobs;

public class CloneRecursiveSourceJob : WorkflowJob
{
    public CloneRecursiveSourceJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[CloneRecursiveSourceJob]: Running workflow job...");
        return this.RunNext();
    }
}
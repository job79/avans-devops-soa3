using Domain.Workflows;

namespace Infrastructure.Workflows.SourceJobs;

public class CloneSourceJob : WorkflowJob
{
    public CloneSourceJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[CloneSouceJob]: Running workflow job...");
        return this.RunNext();
    }
}
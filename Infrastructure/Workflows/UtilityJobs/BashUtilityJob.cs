using Domain.Workflows;

namespace Infrastructure.Workflows.UtilityJobs;

public class BashUtilityJob : WorkflowJob
{
    public BashUtilityJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[BashUtilityJob]: Running workflow job...");
        return this.RunNext();
    }
}
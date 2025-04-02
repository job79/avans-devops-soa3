using Domain.Workflows;

namespace Infrastructure.Workflows.BuildJobs;

public class DotnetBuildJob : WorkflowJob
{
    public DotnetBuildJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[DotnetBuildJob]: Running workflow job...");
        return new WorkflowResult(true, "DotnetBuildJob failed");
    }
}
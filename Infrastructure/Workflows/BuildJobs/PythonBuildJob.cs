using Domain.Workflows;

namespace Infrastructure.Workflows.BuildJobs;

public class PythonBuildJob : WorkflowJob
{
    public PythonBuildJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[PythonBuildJob]: Running workflow job...");
        return this.RunNext();
    }
}
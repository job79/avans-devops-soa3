using Domain.Workflows;

namespace Infrastructure.Workflows.AnalyzeJobs;

public class SonarCubeAnalyzeJob : WorkflowJob
{
    public SonarCubeAnalyzeJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[SonarCubeAnalyzeJob]: Running workflow job...");
        return this.RunNext();
    }
}
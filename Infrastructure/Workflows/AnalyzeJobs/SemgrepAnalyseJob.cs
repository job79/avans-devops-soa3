using Domain.Workflows;

namespace Infrastructure.Workflows.AnalyzeJobs;

public class SemgrepAnalyseJob : WorkflowJob
{
    public SemgrepAnalyseJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[SemgrepAnalyseJob]: Running workflow job...");
        return this.RunNext();
    }
}
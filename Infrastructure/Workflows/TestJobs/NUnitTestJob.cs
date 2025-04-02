using Domain.Workflows;

namespace Infrastructure.Workflows.TestJobs;

public class NUnitTestJob : WorkflowJob
{
    public NUnitTestJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[NUnitTestJob]: Running workflow job...");
        return this.RunNext();
    }
}
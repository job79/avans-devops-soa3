using Domain.Workflows;

namespace Infrastructure.Workflows.TestJobs;

public class SeleniumTestJob : WorkflowJob
{
    public SeleniumTestJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    public override WorkflowResult Run()
    {
        Console.WriteLine("[SeleniumTestJob]: Running workflow job...");
        return this.RunNext();
    }
}
using Domain.Workflows;

namespace Infrastructure.Workflows.PackageJobs;

public class PipPackageJob : WorkflowJob
{
    public PipPackageJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[PipPackageJob]: Running workflow job...");
        return this.RunNext();
    }
}
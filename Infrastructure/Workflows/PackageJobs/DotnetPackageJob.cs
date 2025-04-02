using Domain.Workflows;

namespace Infrastructure.Workflows.PackageJobs;

public class DotnetPackageJob : WorkflowJob
{
    public DotnetPackageJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[DotnetPackageJobs]: Running workflow job...");
        return this.RunNext();
    }
}
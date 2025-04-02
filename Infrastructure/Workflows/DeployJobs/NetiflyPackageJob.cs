using Domain.Workflows;

namespace Infrastructure.Workflows.DeployJobs;

public class NetiflyPackageJob : WorkflowJob
{
    public NetiflyPackageJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[NetiflyPackageJob]: Running workflow job...");
        return this.RunNext();
    }
}
using Domain.Workflows;

namespace Infrastructure.Workflows.DeployJobs;

public class AzureDeployJob : WorkflowJob
{
    public AzureDeployJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[AzureDeployJob]: Running workflow job...");
        return this.RunNext();
    }
}
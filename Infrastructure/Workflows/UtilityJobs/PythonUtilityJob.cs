using Domain.Workflows;

namespace Infrastructure.Workflows.UtilityJobs;

public class PythonUtilityJob : WorkflowJob
{
    public PythonUtilityJob(string settings, WorkflowJob? nextJob) : base(nextJob) 
    {
    }
    
    public override WorkflowResult Run()
    {
        Console.WriteLine("[PythonUtiltyJob]: Running workflow job...");
        return this.RunNext();
    }
}
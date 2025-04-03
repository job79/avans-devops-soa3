namespace Domain.Workflows;

public class Workflow
{
    public List<WorkflowTrigger> WorkflowTriggers { get; }
    private readonly WorkflowJob _workflowJob;
    
    public Workflow(List<WorkflowTrigger> workflowTriggers, WorkflowJob workflowJob)
    {
        this.WorkflowTriggers = workflowTriggers;
        this._workflowJob = workflowJob;
    }

    public WorkflowResult Run()
    {
       return this._workflowJob.Run(); 
    }
}
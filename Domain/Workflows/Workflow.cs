namespace Domain.Workflows;

public class Workflow
{
    public IList<WorkflowTrigger> WorkflowTriggers { get; }
    private WorkflowJob _workflowJob;
    
    public Workflow(IList<WorkflowTrigger> workflowTriggers, WorkflowJob workflowJob)
    {
        this.WorkflowTriggers = workflowTriggers;
        this._workflowJob = workflowJob;
    }

    public WorkflowResult Run()
    {
       return this._workflowJob.Run(); 
    }
}
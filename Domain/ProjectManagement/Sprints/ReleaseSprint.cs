using Domain.Account;
using Domain.SourceManagement;
using Domain.Workflows;

namespace Domain.ProjectManagement.Sprints;

public class ReleaseSprint : Sprint
{
    public WorkflowResult? WorkflowResult { get; private set; }
    
    public ReleaseSprint(string name, DateTime startDate, DateTime endDate, ScrumMaster scrumMaster, Repository repository) : base(name, startDate, endDate, scrumMaster, repository)
    {
    }
    
    public void ToRelease()
    {
        WorkflowResult = this.Repository.RunWorkflows(WorkflowTrigger.OnRelease);
        CurrentState.ToRelease();
    }
}
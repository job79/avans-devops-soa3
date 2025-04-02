using Domain.Workflows;

namespace Domain.SourceManagement;

public abstract class Repository
{
    public string Name { get; }
    public IList<Commit> Commits { get; } = new List<Commit>();
    public IList<File> Files { get; } = new List<File>();
    public IList<Branch> Branches { get; } = new List<Branch>();
    public IList<Workflow> Workflows { get; } = new List<Workflow>();

    public Repository(string name)
    {
        this.Name = name;
    }
    
    public void Commit(Commit commit)
    {
        this.Commits.Add(commit);
    }
    
    public abstract void Push();
    public abstract void Pull();

    public WorkflowResult RunWorkflows(WorkflowTrigger workflowTrigger)
    {
        foreach (var workflow in this.Workflows)
        {
            if (workflow.WorkflowTriggers.Contains(workflowTrigger))
            {
                var result = workflow.Run();
                if (!result.IsSuccessful)
                {
                    return result;
                }
            }
        }

        return new WorkflowResult(true);
    }
}
using Domain.Workflows;

namespace Domain.SourceManagement;

// Template pattern
public abstract class Repository
{
    public string Name { get; }
    public List<Commit> Commits { get; } = new();
    public Dictionary<string, File> Files { get; } = new();
    public List<Branch> Branches { get; } = new();
    public List<Workflow> Workflows { get; } = new();

    protected Repository(string name)
    {
        this.Name = name;
    }

    public virtual void Commit(Commit commit)
    {
        this.Commits.Add(commit);
        
        // Should be extended so it handles deletions
        commit.ChangedFiles.ForEach(f => this.Files[f.Path] = f);
    }

    public virtual void Push()
    {
        this.RunWorkflows(WorkflowTrigger.OnPush);
    }
    
    public abstract void Pull();

    public WorkflowResult RunWorkflows(WorkflowTrigger workflowTrigger)
    {
        foreach (var workflow in this.Workflows.Where(x => x.WorkflowTriggers.Contains(workflowTrigger)))
        {
            var result = workflow.Run();
            if (!result.IsSuccessful)
            {
                return result;
            }
        }

        return new WorkflowResult(true);
    }
}
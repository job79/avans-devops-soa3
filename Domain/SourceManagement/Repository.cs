namespace Domain.SourceManagement;

public abstract class Repository
{
    public string Name { get; }
    public IList<Commit> Commits { get; } = new List<Commit>();
    public IList<File> Files { get; } = new List<File>();
    public IList<Branch> Branches { get; } = new List<Branch>();

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
}
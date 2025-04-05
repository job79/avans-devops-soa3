namespace Domain.SourceManagement;

// Template pattern
public class GitRepository : Repository
{
    public GitRepository(string name) : base(name)
    {
    }
    
    public override void Commit(Commit commit)
    {
        base.Commit(commit);
        Console.WriteLine("[GitRepository] Commiting data to git repository");
    }

    public override void Push()
    {
        base.Push();
        Console.WriteLine("[GitRepository] Pushing data to git repository");
    }

    public override void Pull()
    {
        Console.WriteLine("[GitRepository] Pulling data from git repository");
    }
}
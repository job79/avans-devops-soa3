namespace Domain.SourceManagement;

// Template pattern
public class SvnRepository : Repository
{
    public SvnRepository(string name) : base(name)
    {
    }
    
    public override void Commit(Commit commit)
    {
        Console.WriteLine("[SvnRepository] Commiting data to svn repository");
    }

    public override void Pull()
    {
        Console.WriteLine("[SvnRepository] Pulling data from svn repository");
    }
}
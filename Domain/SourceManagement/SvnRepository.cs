namespace Domain.SourceManagement;

public class SvnRepository : Repository
{
    public SvnRepository(string name) : base(name)
    {
    }
    
    public new void Commit(Commit commit)
    {
        Console.WriteLine("[SvnRepository] Commiting data to svn repository");
    }

    public override void Push()
    {
        // SVN doesn't push data, data is pushed automatically on commit
    }

    public override void Pull()
    {
        Console.WriteLine("[SvnRepository] Pulling data from svn repository");
    }
}
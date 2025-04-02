using Domain.Account;

namespace Domain.SourceManagement;

public class Branch
{
    public string Name { get; }
    public Commit Commit { get; }

    public Branch(string name, Commit commit)
    {
        this.Name = name;
        this.Commit = commit;
    }
}
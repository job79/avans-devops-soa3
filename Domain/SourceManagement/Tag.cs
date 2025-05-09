using Domain.Account;

namespace Domain.SourceManagement;

public class Tag : Commit
{
    public string Name { get; }

    public Tag(string name, string id, string message, User author, List<File> changedFiles, Commit? previousCommit) : base(id, message, author, changedFiles, previousCommit)
    {
        this.Name = name;
    }
}
using Domain.Account;

namespace Domain.SourceManagement;

public class Commit
{
    public string ID { get; }
    public string Message { get; }
    public User Author { get; }
    public IList<File> ChangedFiles { get; }
    public Commit? PreviousCommit { get; }

    public Commit(string id, string message, User author, IList<File> changedFiles, Commit? previousCommit)
    {
        this.ID = id;
        this.Message = message;
        this.Author = author;
        this.ChangedFiles = changedFiles;
        this.PreviousCommit = previousCommit;
    }
}
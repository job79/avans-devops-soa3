using Domain.Account;

namespace Domain.ProjectManagement.Discussions;

public class Post
{
    public string Description { get; } 
    public User Author { get; }

    public Post(string description, User author)
    {
        this.Description = description;
        this.Author = author;
    }
}
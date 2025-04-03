namespace Domain.Account;

public abstract class User
{
    public string Name { get; }
    public string Email { get; }

    protected User(string name, string email)
    {
        this.Name = name;
        this.Email = email;
    }
}
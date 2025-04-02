namespace Domain.Account;

public class User
{
    public string Name { get; }
    public string Email { get; }

    public User(string name, string email)
    {
        this.Name = name;
        this.Email = email;
    }
}
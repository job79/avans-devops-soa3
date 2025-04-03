using Domain;
using Domain.Account;

namespace Infrastructure.Email;

// Adapter pattern
public class EmailAdapter : ISendMethod
{
    public void SendMessage(User user, string message)
    {
        // Nuget package for email messages is used here...
        Console.WriteLine($"[EmailAdapter] sending message to {user.Email} with content {message}");
    }
}
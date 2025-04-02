using Domain;
using Domain.Account;

namespace Infrastructure.Slack;

public class SlackAdapter : ISendMethod
{
    public void SendMessage(User user, string message)
    {
        // Nuget package for slack messages is used here...
        Console.WriteLine($"[SlackAdapter] sending message to {user.Email} with content {message}");
    }
}
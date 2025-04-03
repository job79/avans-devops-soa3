using Domain.Account;

namespace Domain;

// Adapter pattern
public interface ISendMethod
{
    public void SendMessage(User user, string message);
}
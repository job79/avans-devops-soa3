using Domain.Account;

namespace Domain;

public interface ISendMethod
{
    public void SendMessage(User user, string message);
}
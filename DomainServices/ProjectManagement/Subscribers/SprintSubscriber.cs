using Domain;
using Domain.Account;
using Domain.ProjectManagement.Sprints;

namespace DomainServices.ProjectManagement.Subscribers;

public class SprintSubscriber : ISubscriber<Sprint>
{
    private User _user;
    private ISendMethod _sendMethod;
    
    public SprintSubscriber(User user, ISendMethod sendMethod)
    {
        this._user = user;
        this._sendMethod = sendMethod;
    }

    public void Update(Sprint sprint)
    {
        if (sprint.CurrentState is Closed)
        {
            string state = sprint.CurrentState.GetType().Name;
            this._sendMethod.SendMessage(this._user, $"Sprint has updated! State: {state}");
        }
    }
}
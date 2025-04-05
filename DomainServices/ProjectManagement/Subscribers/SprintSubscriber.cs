using Domain;
using Domain.Account;
using Domain.ProjectManagement.Sprints;

namespace DomainServices.ProjectManagement.Subscribers;

// Observer pattern
public class SprintSubscriber : ISubscriber<Sprint>
{
    private readonly User _user;
    private readonly ISendMethod _sendMethod;

    public SprintSubscriber(User user, ISendMethod sendMethod)
    {
        this._user = user;
        this._sendMethod = sendMethod;
    }

    public void Update(Sprint sprint)
    {
        switch (sprint.CurrentState)
        {
            case Released:
                var isSuccessful = sprint is ReleaseSprint { WorkflowResult.IsSuccessful: true };
                if (!isSuccessful && sprint.ScrumMaster == this._user)
                {
                    this._sendMethod.SendMessage(this._user, "Sprint release pipeline failed");
                }
                else if (isSuccessful)
                {
                    this._sendMethod.SendMessage(this._user, "Sprint release pipeline was successful");
                }

                break;

            case Closed:
                this._sendMethod.SendMessage(this._user, "Sprint has been cancelled");
                break;
        }
    }
}
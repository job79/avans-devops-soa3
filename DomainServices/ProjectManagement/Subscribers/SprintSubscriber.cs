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
        switch (sprint.CurrentState)
        {
            case Released:
                var isSuccesful = sprint is ReleaseSprint { WorkflowResult.IsSuccessful: true };
                if (!isSuccesful && sprint.ScrumMaster == this._user)
                {
                    this._sendMethod.SendMessage(this._user, "Sprint release pipeline failed");
                }
                else if (isSuccesful)
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
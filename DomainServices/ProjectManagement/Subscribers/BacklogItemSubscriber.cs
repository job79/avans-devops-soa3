using Domain;
using Domain.Account;
using Domain.ProjectManagement.BacklogItems;

namespace DomainServices.ProjectManagement.Subscribers;

//Observer pattern
public class BacklogItemSubscriber : ISubscriber<BacklogItem>
{
    private readonly User _user;
    private readonly ISendMethod _sendMethod;
    private IBacklogItemState? _previousState;

    public BacklogItemSubscriber(User user, ISendMethod sendMethod)
    {
        this._user = user;
        this._sendMethod = sendMethod;
    }

    public void Update(BacklogItem sprint)
    {
        bool notifyUser = (sprint.Tester == this._user && sprint.CurrentState is ReadyForTesting) ||
                          (sprint.Sprint.ScrumMaster == this._user && sprint.CurrentState is Todo && this._previousState is Testing) ||
                          (sprint.Developer == _user);

        if (notifyUser)
        {
            string state = sprint.CurrentState.GetType().Name;
            string previousState = this._previousState?.GetType()?.Name ?? "-";
            this._sendMethod.SendMessage(this._user, $"BacklogItem \"{sprint.Title}\" updated! Status: {previousState} -> {state}");
        }
        this._previousState = sprint.CurrentState;
    }
}
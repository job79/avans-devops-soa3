using Domain;
using Domain.Account;
using Domain.ProjectManagement.BacklogItems;

namespace DomainServices.ProjectManagement.Subscribers;

// Observer pattern
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

    public void Update(BacklogItem backlogItem)
    {
        bool notifyUser = (backlogItem.Tester == this._user && backlogItem.CurrentState is ReadyForTesting) ||
                          (backlogItem.Sprint.ScrumMaster == this._user && backlogItem.CurrentState is Todo && this._previousState is Testing) ||
                          (backlogItem.Developer == _user);

        if (notifyUser)
        {
            string state = backlogItem.CurrentState.GetType().Name;
            string previousState = this._previousState?.GetType().Name ?? "-";
            this._sendMethod.SendMessage(this._user, $"BacklogItem \"{backlogItem.Title}\" updated! Status: {previousState} -> {state}");
        }
        this._previousState = backlogItem.CurrentState;
    }
}
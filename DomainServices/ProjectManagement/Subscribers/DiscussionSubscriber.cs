using Domain;
using Domain.Account;
using Domain.ProjectManagement.Discussions;

namespace DomainServices.ProjectManagement.Subscribers;

//Observer pattern
public class DiscussionSubscriber : ISubscriber<Discussion>
{
    private readonly User _user;
    private readonly ISendMethod _sendMethod;
    
    public DiscussionSubscriber(User user, ISendMethod sendMethod)
    {
        this._user = user;
        this._sendMethod = sendMethod;
    }

    public void Update(Discussion sprint)
    {
        this._sendMethod.SendMessage(this._user, $"Discussion \"{sprint.Title}\" has been updated! Total posts: {sprint.Posts.Count}");
    }
}